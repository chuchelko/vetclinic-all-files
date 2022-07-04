namespace WebApp.Controllers
{
    using API.gRPCService;

    using Google.Protobuf.WellKnownTypes;

    using Grpc.Core;
    using Grpc.Net.Client;

    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;

    using WebApp.Models;

    public class AnimalsController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly GrpcChannel _channel;

        private readonly AnimalService.AnimalServiceClient _animalServiceClient;

        private readonly ServicesService.ServicesServiceClient _servicesServiceClient;

        public AnimalsController(ILogger<HomeController> logger)
        {
            _logger = logger;
            _channel = GrpcChannel.ForAddress("https://localhost:5001");
            _animalServiceClient = new(_channel);
            _servicesServiceClient = new(_channel);
        }

        [HttpGet("{controller}")]
        public async Task<IActionResult> Index(string id)
        {
            var headers = CookieHelper.GetHeaders(HttpContext);

            var animals = await _animalServiceClient.GetAllAnimalsAsync(new GetAllAnimalsRequest(), headers);
            if(id == null)
            {
                ViewBag.Animals = animals;
                return View();
            }

            var animal = animals.Animals.FirstOrDefault(animal => animal.ChipNumber == id);
            if (animal == null)
                return RedirectToAction("Index");
            ViewBag.Animal = animal;
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var headers = CookieHelper.GetHeaders(HttpContext);
            Dictionary<string, List<string>> kindsAndBreeds = new();
            kindsAndBreeds["Кошка"] = new List<string>();
            kindsAndBreeds["Собака"] = new List<string>();
            kindsAndBreeds["Попугай"] = new List<string>();

            foreach (var kind in kindsAndBreeds.Keys)
            {
                var breeds = await _animalServiceClient.GetBreedsAsync(new GetBreedsRequest() { Kind = kind }, headers);
                foreach (var breed in breeds.Breeds)
                {
                    kindsAndBreeds[kind].Add(breed);
                }
            }
            ViewBag.Kinds = new SelectList(new string[] { "Кошка", "Собака", "Попугай" });
            ViewBag.Breeds = new SelectList(kindsAndBreeds["Кошка"]);

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(AnimalViewModel animalVM)
        {
            Metadata headers = CookieHelper.GetHeaders(HttpContext);

            var dateTime = Timestamp.FromDateTime(new DateTime(animalVM.Birthday.Ticks, DateTimeKind.Utc));
            CreateAnimalRequest request = new CreateAnimalRequest()
            {
                Animal = new Animal() 
                {
                    Birthday = dateTime,
                    Breed = animalVM.Breed,
                    ChipNumber = animalVM.Passport,
                    Color = animalVM.Color,
                    Kind = animalVM.Kind,
                    Nickname = animalVM.Nickname,
                    SpecificTraits = animalVM.SpecificTraits
                }
            };

            _animalServiceClient.CreateAnimal(request, headers);
            return RedirectToAction("Index");
            
        }
    }
}
