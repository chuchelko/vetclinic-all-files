namespace API.gRPCService.Services
{
    using System.Threading.Tasks;

    using API.Resources.DataLogic.Repositories;

    using Google.Protobuf.WellKnownTypes;

    using Grpc.Core;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.IdentityModel.JsonWebTokens;

    [Authorize]
    public class ServicesService : gRPCService.ServicesService.ServicesServiceBase
    {
        private readonly CoreRepository repository;


        public ServicesService(CoreRepository _repository)
        {
            repository = _repository;
        }

        public override Task<GetAllServicesResponse> GetAllServices(
            GetAllServicesRequest request, ServerCallContext context)
        {
            var services = StaticResourcesRepository.GetServices();
            GetAllServicesResponse response = new GetAllServicesResponse();

            services.ForEach(service =>
                response.Services.Add(new gRPCService.Service()
                {
                    DoctorName = service.DoctorName,
                    DoctorPhone = service.DoctorPhone,
                    Name = service.Name,
                    Price = service.Price,
                }));

            return Task.FromResult(response);
        }

        public override async Task<GetProvidedServicesResponse> GetProvidedServices(
            GetProvidedServicesRequest request, ServerCallContext context)
        {
            string ownerPhone = context.GetHttpContext().User.Claims.First(claim => claim.Type == JwtRegisteredClaimNames.PhoneNumber).Value;
            var owner = await repository.GetOwnerByPhoneWithServicesAsync(ownerPhone);
            var services = owner.Services;

            GetProvidedServicesResponse response = new GetProvidedServicesResponse();
            services.ForEach(async service =>
            {
                var doctor = await repository.Doctors.GetAsync(service.DoctorPassport);
                var doctorName = $"{doctor.LastName} {doctor.FirstName[0]}. {doctor.Patronymic[0]}.";
                response.Services.Add(new ProvidedService()
                {
                    AnimalChipNumber = service.AnimalPassportChipNumber,
                    Date = Timestamp.FromDateTime(service.Date),
                    DoctorName = doctorName,
                    Name = service.Name,
                    Price = service.Price.ToString(),
                });
            });

            return response;
        }
    }
}
