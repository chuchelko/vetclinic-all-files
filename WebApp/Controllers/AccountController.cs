namespace WebApp.Controllers
{
    using API.gRPCService;

    using Google.Protobuf.WellKnownTypes;

    using Grpc.Core;
    using Grpc.Net.Client;

    using Microsoft.AspNetCore.Mvc;

    using WebApp.Models;

    public class AccountController : Controller
    {

        private readonly ILogger<HomeController> _logger;

        private readonly GrpcChannel _channel;

        private readonly OwnerService.OwnerServiceClient _ownerServiceClient;

        public AccountController(ILogger<HomeController> logger)
        {
            _logger = logger;
            _channel = GrpcChannel.ForAddress("https://localhost:5001");
            _ownerServiceClient = new(_channel);
        }

        public async Task<IActionResult> Index()
        {
            if(!CookieHelper.Authorize(HttpContext))
            {
                return Unauthorized();
            }

            var headers = CookieHelper.GetHeaders(HttpContext);
            var owner = await _ownerServiceClient.GetOwnerAsync(new GetOwnerRequest() { }, headers: headers);
            ViewBag.Owner = owner;
            return View();
        }

        [HttpGet]
        public IActionResult Login()
        {
            if (CookieHelper.Authorize(HttpContext))
            {
                return BadRequest();
            }

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(string phoneNumber, string password)
        {
            if (CookieHelper.Authorize(HttpContext))
            {
                return BadRequest();
            }
            var headers = CookieHelper.GetHeaders(HttpContext);

            var response = await _ownerServiceClient.GetJwtTokenAsync(new GetTokenRequest() { Password = password, PhoneNumber = phoneNumber }, headers: headers);

            if (response.ExceptionMessage != string.Empty || response.Token == string.Empty)
                return BadRequest(response.ExceptionMessage);
            
            CookieHelper.Authenticate(HttpContext, response.Token);
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult Register()
        {

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel registerVM)
        {
            registerVM.Birthday = new DateTime(registerVM.Birthday.Ticks, DateTimeKind.Utc);
            var request = new CreateOwnerRequest();
            request.Owner = new OwnerModel()
            {
                Birthday = Timestamp.FromDateTime(registerVM.Birthday),
                FirstName = registerVM.FirstName,
                LastName = registerVM.LastName,
                Passport = registerVM.Passport,
                Patronymic = registerVM.Patronymic,
                PhoneNumber = registerVM.PhoneNumber,
            };

            request.Password = registerVM.Password;

            var response = await _ownerServiceClient.CreateOwnerAsync(request);
            if (response.Created == false || response.ExceptionMessage != string.Empty)
                return BadRequest(response.ExceptionMessage);

            CookieHelper.Authenticate(HttpContext, response.Token);

            return RedirectToAction("Index", "Home");
        }

        public IActionResult Logout()
        {
            if (!CookieHelper.Authorize(HttpContext))
            {
                return Unauthorized(); 
            }

            CookieHelper.Logout(HttpContext);
            return RedirectToAction("Index", "Home");
        }
    }
}
