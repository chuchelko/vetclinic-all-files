namespace API.gRPCService.Services
{
    using System.IdentityModel.Tokens.Jwt;
    using System.Security.Claims;
    using System.Threading.Tasks;

    using API.Resources.DataLogic;
    using API.Resources.DataLogic.Repositories;

    using Grpc.Core;

    using Microsoft.IdentityModel.Tokens;

    public class OwnerService : gRPCService.OwnerService.OwnerServiceBase
    {
        private readonly CoreRepository repository;

        private readonly IConfiguration configuration;

        public OwnerService(CoreRepository _repository, IConfiguration _configuration)
        {
            repository = _repository;
            configuration = _configuration;
        }

        public override async Task<CreateOwnerResponse> CreateOwner(CreateOwnerRequest request, ServerCallContext context)
        {
            var oldOwner = await repository.GetOwnerByPhoneAsync(request.Owner.PhoneNumber);
            if (oldOwner != null)
                return new CreateOwnerResponse() { Created = false, ExceptionMessage = "Владелец с этим номером телефона существует", Token = string.Empty };

            oldOwner = await repository.Owners.GetAsync(request.Owner.Passport);

            if(oldOwner != null)
                return new CreateOwnerResponse() { Created = false, ExceptionMessage = "Владелец с этим номером паспорта уже существует", Token = string.Empty };

            PasswordManager.HashPassword(request.Password, out byte[] hash, out byte[] salt);

            Resources.Entities.Owner owner = new()
            {
                Passport = request.Owner.Passport,
                Birthday = request.Owner.Birthday.ToDateTime(),
                FirstName = request.Owner.FirstName,
                LastName = request.Owner.LastName,
                Patronymic = request.Owner.Patronymic,
                Phone = request.Owner.PhoneNumber,
                Salt = Convert.ToBase64String(salt),
                HashedPassword = Convert.ToBase64String(hash),
            };

            await repository.Owners.CreateAsync(owner);
            return new CreateOwnerResponse() { 
                Created = true,
                ExceptionMessage = string.Empty,
                Token = GetToken(request.Owner.PhoneNumber, request.Owner.FirstName) 
            };
        }

        public override async Task<GetTokenResponse> GetJwtToken(GetTokenRequest request, ServerCallContext context)
        {
            var owner = await repository.GetOwnerByPhoneAsync(request.PhoneNumber);

            if(owner == null)
                return new GetTokenResponse() { Token = string.Empty, ExceptionMessage = "Пользователь не найден" };

            if (!PasswordManager.VerifyPassword(request.Password, owner.HashedPassword, owner.Salt))
                return new GetTokenResponse() { Token = string.Empty, ExceptionMessage = "Неправильный пароль" };

            return new GetTokenResponse() {
                ExceptionMessage = string.Empty,
                Token = GetToken(owner.Phone, owner.FirstName) 
            };

        }

        private string GetToken(string phoneNumber, string firstName)
        {
            var defaults = new AuthDefaults(configuration);
            var credentials = new SigningCredentials(defaults.SymmetricSecurityKey, SecurityAlgorithms.HmacSha256);
            var claims = new List<Claim>()
            {
            new Claim(Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames.PhoneNumber, phoneNumber),
            new Claim(Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames.Sub, firstName),
            };

            var token = new JwtSecurityToken(
                issuer: defaults.Issuer,
                audience: defaults.Audience,
                claims: claims,
                signingCredentials: credentials,
                expires: DateTime.Now.AddMinutes(20)
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public override async Task<OwnerModel> GetOwner(GetOwnerRequest request, ServerCallContext context)
        {
            var httpContext = context.GetHttpContext();

            string phone = httpContext.User.Claims.First(claim => claim.Type == Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames.PhoneNumber).Value;

            var owner = await repository.GetOwnerByPhoneAsync(phone);

            var owners = repository.GetOwners();

            DateTime dateTime = new DateTime(owner.Birthday.Ticks, DateTimeKind.Utc);

            var bd = Google.Protobuf.WellKnownTypes.Timestamp.FromDateTime(dateTime);

            OwnerModel ownerModel = new OwnerModel()
            {
                Birthday = bd,
                FirstName = owner.FirstName,
                LastName = owner.LastName,
                Patronymic = owner.Patronymic,
                Passport = owner.Passport,
                PhoneNumber = owner.Phone
            };

            return ownerModel;
        }

    }
}
