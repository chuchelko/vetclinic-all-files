namespace API.gRPCService
{
    using System.Text;

    using Microsoft.IdentityModel.Tokens;

    public class AuthDefaults
    {
        private readonly IConfiguration configuration;

        public AuthDefaults(IConfiguration _configuration)
        {
            configuration = _configuration;
        }

        public string Issuer => configuration.GetSection("Auth").GetSection("Issuer").Value;

        public string Audience => configuration.GetSection("Auth").GetSection("Audience").Value;

        private string Key => Environment.GetEnvironmentVariable("AUTH_KEY") ?? "$$as9a9d2(hd@32fd%$$7#sdhs&&";

        public SymmetricSecurityKey SymmetricSecurityKey => new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Key));
    }
}
