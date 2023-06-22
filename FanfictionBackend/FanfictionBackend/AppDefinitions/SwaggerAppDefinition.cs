using FanfictionBackend.Interfaces;
using Microsoft.OpenApi.Models;

namespace FanfictionBackend.AppDefinitions;

public class SwaggerAppDefinition : IAppDefinition
{
    public void DefineApp(WebApplication app)
    {
        app.UseSwagger();
        app.UseSwaggerUI(c =>
        {
            c.SwaggerEndpoint("/swagger/v1/swagger.json", "StorySphere API V1");
            c.RoutePrefix = "swagger";
        });
    }

    public void DefineServices(IServiceCollection services, IConfiguration config)
    {
        services.AddSwaggerGen(options =>
        {
            options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                Scheme = "Bearer",
                BearerFormat = "JWT",
                In = ParameterLocation.Header,
                Name = "Authorization",
                Description = "Bearer Authentication with JWT Token",
                Type = SecuritySchemeType.Http
            });
            options.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Id = "Bearer",
                            Type = ReferenceType.SecurityScheme
                        }
                    },
                    new List<string>()
                }
            });
        });
        
        services.AddEndpointsApiExplorer();
    }
}