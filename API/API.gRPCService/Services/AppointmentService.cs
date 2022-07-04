namespace API.gRPCService.Services
{
    using System.Threading.Tasks;

    using API.Resources.DataLogic.Repositories;

    using Google.Protobuf.WellKnownTypes;

    using Grpc.Core;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.IdentityModel.JsonWebTokens;

    [Authorize]
    public class AppointmentService : gRPCService.AppointmentService.AppointmentServiceBase
    {
        private readonly CoreRepository coreRepository;

        private readonly IAppointmentRepository appointmentRepository;

        private readonly ILogger<AppointmentService> logger;

        public AppointmentService(CoreRepository _coreRepository
            , IAppointmentRepository _appointmentRepository, ILogger<AppointmentService> _logger)
        {
            coreRepository = _coreRepository;
            appointmentRepository = _appointmentRepository;
            logger = _logger;
        }

        public override async Task<CreateAppointmentResponse> CreateAppointment(
            CreateAppointmentRequest request, ServerCallContext context)
        {
            var doctor = await coreRepository.GetDoctorByPhoneAsync(request.Appointment.DoctorPhone);

            if (doctor == null)
                return new CreateAppointmentResponse() { Created = false, ExceptionMessage = "Доктор не найден" };

            var oldAppointments = await coreRepository.Appointments.GetDoctorWeekAppointments(doctor);

            var appointmentWithDate = oldAppointments.Where(app => app.AppointmentDate == request.Appointment.Date.ToDateTime()).Single();

            if (appointmentWithDate.Owner != null)
                return new CreateAppointmentResponse() { Created = false, ExceptionMessage = "Занято" };

            string ownerPhone = context.GetHttpContext().User.Claims.First(claim => claim.Type == JwtRegisteredClaimNames.PhoneNumber).Value;
            var owner = await coreRepository.GetOwnerByPhoneAsync(ownerPhone);

            appointmentWithDate.ServiceName = request.Appointment.ServiceName;
            appointmentWithDate.OwnerPassport = owner.Passport;

            await appointmentRepository.SaveAsync(appointmentWithDate);
            logger.LogInformation($"{appointmentWithDate.AppointmentDate} {appointmentWithDate.OwnerPassport}");

            return new CreateAppointmentResponse() { Created = true, ExceptionMessage = string.Empty };
        }

        public override async Task<GetWeekAppointmentsResponse> GetAvailableWeekAppointments(
            GetWeekAppointmentsRequest request, ServerCallContext context)
        {
            var doctor = await coreRepository.GetDoctorByPhoneAsync(request.DoctorPhone);

            if (doctor == null)
                return new GetWeekAppointmentsResponse() { ExceptionMessage = "Доктор не найден" };

            var appointments = await appointmentRepository.GetDoctorWeekAppointments(doctor);

            GetWeekAppointmentsResponse response = new GetWeekAppointmentsResponse();
            foreach (var appointment in appointments)
            {
                logger.LogInformation(appointment.AppointmentDate + " " + appointment.OwnerPassport);
                if(appointment.OwnerPassport == null)
                    response.Appointments.Add(Timestamp.FromDateTime(new DateTime(appointment.AppointmentDate.Ticks, DateTimeKind.Utc)));
            }
            return response;
        }

        public override async Task<GetOwnerAppointmentsResponse> GetOwnerAppointments(
            GetOwnerAppointmentsRequest request, ServerCallContext context)
        {
            string ownerPhone = context.GetHttpContext().User.Claims.First(claim => claim.Type == JwtRegisteredClaimNames.PhoneNumber).Value;
            var owner = await coreRepository.GetOwnerByPhoneAsync(ownerPhone);

            var appointments = await appointmentRepository.GetAsync(owner);

            GetOwnerAppointmentsResponse response = new GetOwnerAppointmentsResponse();

            foreach (var appointment in appointments)
            {
                var doctor = await coreRepository.Doctors.GetAsync(appointment.DoctorPassport);
                DateTime dt = new DateTime(appointment.AppointmentDate.Ticks, DateTimeKind.Utc);

                response.Appointments.Add(new Appointment()
                {
                    Date = Timestamp.FromDateTime(dt),
                    DoctorPhone = doctor.Phone,
                    ServiceName = appointment.ServiceName
                });
            }

            return response;
        }

        public override async Task<CancelAppointmentResponse> CancelAppointment(
            CancelAppointmentRequest request, ServerCallContext context)
        {
            bool deleted = await appointmentRepository.DeleteAsync(request.DoctorPhone, request.Date.ToDateTime());
            return new CancelAppointmentResponse() { Cancelled = deleted };
        }
    }
}
