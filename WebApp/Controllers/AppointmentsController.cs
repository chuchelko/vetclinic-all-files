namespace WebApp.Controllers
{
    using API.gRPCService;

    using Google.Protobuf.WellKnownTypes;

    using Grpc.Net.Client;

    using Microsoft.AspNetCore.Mvc;

    public class AppointmentsController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly GrpcChannel _channel;

        private readonly AppointmentService.AppointmentServiceClient _appointmentServiceClient;

        private readonly ServicesService.ServicesServiceClient _servicesServiceClient;

        public AppointmentsController(ILogger<HomeController> logger)
        {
            _logger = logger;
            _channel = GrpcChannel.ForAddress("https://localhost:5001");
            _appointmentServiceClient = new(_channel);
            _servicesServiceClient = new(_channel);
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.Services = await _servicesServiceClient.GetAllServicesAsync(new GetAllServicesRequest(), CookieHelper.GetHeaders(HttpContext));
            ViewBag.OwnerAppointments = await _appointmentServiceClient.GetOwnerAppointmentsAsync(new GetOwnerAppointmentsRequest(), CookieHelper.GetHeaders(HttpContext));
            return View();
        }


        [HttpGet]
        public async Task<IActionResult> Add(string doctorPhone, string serviceName)
        {
            if (doctorPhone == null || serviceName == null)
                return RedirectToAction("Index", "Animals");

            var appointments = await _appointmentServiceClient.GetAvailableWeekAppointmentsAsync(new GetWeekAppointmentsRequest() { DoctorPhone = doctorPhone }
            , CookieHelper.GetHeaders(HttpContext));

            if (appointments.ExceptionMessage != string.Empty)
                return RedirectToAction("Index", "Animals");

            ViewBag.Appointments = appointments;
            ViewBag.DoctorPhone = doctorPhone;
            ViewBag.ServiceName = serviceName;

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> PostForm(long ticks, string doctorPhone, string serviceName)
        {
            DateTime dt = new DateTime(ticks, DateTimeKind.Utc);
            Appointment appointment = new Appointment()
            {
                Date = Timestamp.FromDateTime(dt),
                DoctorPhone = doctorPhone,
                ServiceName = serviceName,
            };

            CreateAppointmentRequest request = new CreateAppointmentRequest() 
            {
              Appointment = appointment  
            };

            var response = await _appointmentServiceClient.CreateAppointmentAsync(request, CookieHelper.GetHeaders(HttpContext));

            if (response.Created == false)
                return BadRequest(response.ExceptionMessage);

            return RedirectToAction("Index", "Appointments");
        }
    }
}
