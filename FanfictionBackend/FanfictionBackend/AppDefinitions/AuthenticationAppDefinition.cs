using System.Text;
using FanfictionBackend.Interfaces;
using FanfictionBackend.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

namespace FanfictionBackend.AppDefinitions;

public class AuthenticationAppDefinition : IAppDefinition
{
    public void DefineApp(WebApplication app)
    {
        app.UseAuthorization();
        app.UseAuthentication();
    }

    public void DefineServices(IServiceCollection services, IConfiguration config)
    {
        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
        {
            options.TokenValidationParameters = new TokenValidationParameters()
            {
                ValidateActor = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = config["Jwt:Issuer"],
                ValidAudience = config["Jwt:Audience"],
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(
                    config["Jwt:Key"] ?? throw new InvalidOperationException("Security key can't be null")))
            };
        });
        services.AddAuthorization();
        
        services.AddScoped<ITokenService, TokenService>();
    }
}