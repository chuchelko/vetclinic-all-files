namespace API.gRPCService.Services
{
    using System.Threading.Tasks;

    using API.Resources.DataLogic.Repositories;

    using Google.Protobuf.WellKnownTypes;

    using Grpc.Core;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.IdentityModel.JsonWebTokens;

    [Authorize]
    public class AnimalService : gRPCService.AnimalService.AnimalServiceBase
    {

        private readonly CoreRepository repository;


        public AnimalService(CoreRepository _repository)
        {
            repository = _repository;
        }
        
        public override async Task<CreateAnimalResponse> CreateAnimal(
            CreateAnimalRequest request, ServerCallContext context)
        {
            Resources.Entities.AnimalPassport passport = new() 
            { 
                ChipNumber = request.Animal.ChipNumber 
            };

            string phone = context.GetHttpContext().User.Claims.First(claim => claim.Type == JwtRegisteredClaimNames.PhoneNumber).Value;

            var owner = await repository.GetOwnerByPhoneAsync(phone);

            if (owner == null)
                return new CreateAnimalResponse() { Created = false, ExceptionMessage = "Владелец не найден" };

            if(await repository.Animals.GetAsync(request.Animal.ChipNumber) != null)
                return new CreateAnimalResponse() { Created = false, ExceptionMessage = "Животное уже зарегистрировано" };


            Resources.Entities.Animal animal = new()
            {
                AnimalPassportChipNumber = request.Animal.ChipNumber,
                Birthday = request.Animal.Birthday.ToDateTime(),
                Breed = request.Animal.Breed,
                Color = request.Animal.Color,
                Kind = request.Animal.Kind,
                Nickname = request.Animal.Nickname,
                SpecificTraits = request.Animal.SpecificTraits,
                OwnerPassport = owner.Passport,
            };

            animal.AnimalPassport = passport;

            await repository.AnimalPassports.CreateAsync(passport);
            await repository.Animals.CreateAsync(animal);

            return new CreateAnimalResponse() { Created = true };
        }

        public override async Task<DeleteAnimalResponse> DeleteAnimal(
            DeleteAnimalRequest request, ServerCallContext context)
        {
            var animal = await repository.Animals.GetAsync(request.ChipNumber);

            if(animal == null)
                return new DeleteAnimalResponse() { Deleted = false, ExceptionMessage = "Животное не найдено" };

            await repository.Animals.DeleteAsync(request.ChipNumber);
            return new DeleteAnimalResponse() { Deleted = true };
        }

        public override async Task<GetAllAnimalsResponse> GetAllAnimals(
            GetAllAnimalsRequest request, ServerCallContext context)
        {
            string phone = context.GetHttpContext().User.Claims.First(claim => claim.Type == JwtRegisteredClaimNames.PhoneNumber).Value;

            var owner = await repository.GetOwnerByPhoneAsync(phone);
            var response = new GetAllAnimalsResponse();

            if (owner == null)
                return response;

            var ownerAnimals = await repository.GetOwnerAnimalsAsync(owner);

            if (ownerAnimals == null)
                return response;

            List<Animal> animals = new List<Animal>();
            foreach(var animal in ownerAnimals)
            {
                animals.Add(new Animal()
                {
                    Birthday = Timestamp.FromDateTime(animal.Birthday),
                    Breed = animal.Breed,
                    ChipNumber = animal.AnimalPassportChipNumber,
                    Color = animal.Color,
                    Nickname = animal.Nickname,
                    SpecificTraits = animal.SpecificTraits,
                    Kind = animal.Kind,
                });
            }

            response.Animals.AddRange(animals);

            return response;
        }

        public override Task<GetBreedsResponse> GetBreeds(
            GetBreedsRequest request, ServerCallContext context)
        {
            var breeds = StaticResourcesRepository.GetAnimalKinds()[request.Kind];

            var response = new GetBreedsResponse();
            response.Breeds.AddRange(breeds);

            return Task.FromResult(response);
        }

        public override async Task<GetDiseasesResponse> GetDiseases(
            GetDiseasesRequest request, ServerCallContext context)
        {
            var animal = await repository.Animals.GetAsync(request.ChipNumber);
            if (animal == null)
            {
                return new GetDiseasesResponse() { ExceptionMessage = "Животного не существует" };
            }

            var response = new GetDiseasesResponse();

            var diseases = await repository.GetDiseasesAsync(animal);
            if (diseases == null)
            {
                return response;
            }

            foreach (var disease in diseases)
            {
                response.Diseases.Add(new Disease()
                {
                    DoctorName = $"{disease.Doctor.LastName} {disease.Doctor.FirstName[0]}. {disease.Doctor.LastName[0]}.",
                    AdditionalInformation = disease.AdditionalInformation,
                    AnimalStatus = disease.AnimalCondition,
                    ClassificationCode = disease.CodeInClassification,
                    Name = disease.Name,
                    Treatment = disease.Treatment
                });
            }

            return response;
        }
    }
}
