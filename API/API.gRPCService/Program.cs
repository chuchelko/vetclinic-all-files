using API.Resources.DataLogic;
using API.Resources.DataLogic.Repositories;
using API.Resources.Entities;

using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.CookiePolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

// Additional configuration is required to successfully run gRPC on macOS.
// For instructions on how to configure Kestrel and gRPC clients on macOS, visit https://go.microsoft.com/fwlink/?linkid=2099682

// Add services to the container.
builder.Services.AddGrpc();
builder.Services.AddDbContext<NpsqlContext>(options => options.UseNpgsql(API.Resources.DataLogic.Secrets.ConnectionString), ServiceLifetime.Singleton);
builder.Services.AddScoped<IAppointmentRepository, AppointmentRepository>();
builder.Services.AddScoped<IEntityRepository<Animal, string>, EntityRepository<Animal, string>>();
builder.Services.AddScoped<IEntityRepository<AnimalPassport, string>, EntityRepository<AnimalPassport, string>>();
builder.Services.AddScoped<IEntityRepository<AnimalProcedure, int>, EntityRepository<AnimalProcedure, int>>();
builder.Services.AddScoped<IEntityRepository<Disease, int>, EntityRepository<Disease, int>>();
builder.Services.AddScoped<IEntityRepository<Doctor, string>, EntityRepository<Doctor, string>>();
builder.Services.AddScoped<IEntityRepository<Owner, string>, EntityRepository<Owner, string>>();
builder.Services.AddScoped<IEntityRepository<ProvidedService, int>, EntityRepository<ProvidedService, int>>();
builder.Services.AddScoped<CoreRepository, CoreRepository>();


API.gRPCService.AuthDefaults authOptions = new API.gRPCService.AuthDefaults(builder.Configuration);

builder.Services.AddAuthentication(options => 
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
    .AddJwtBearer(options =>
    {
        options.SaveToken = true;
        options.TokenValidationParameters = new TokenValidationParameters()
        {
            ValidateIssuer = true,
            ValidIssuer = authOptions.Issuer,

            ValidateIssuerSigningKey = true,
            IssuerSigningKey = authOptions.SymmetricSecurityKey,

            ValidateAudience = true,
            ValidAudience = authOptions.Audience,

            ValidateLifetime = true,
        };
    });

builder.Services.AddAuthorization();

var app = builder.Build();
AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapGrpcService<API.gRPCService.Services.AnimalService>();
    endpoints.MapGrpcService<API.gRPCService.Services.AppointmentService>();
    endpoints.MapGrpcService<API.gRPCService.Services.OwnerService>();
    endpoints.MapGrpcService<API.gRPCService.Services.ServicesService>();
});
app.MapGet("/", () => "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");

app.Run();
