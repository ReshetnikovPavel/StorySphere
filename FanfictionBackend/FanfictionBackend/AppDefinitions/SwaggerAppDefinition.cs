using FanfictionBackend.Interfaces;
using Microsoft.OpenApi.Models;

namespace FanfictionBackend.EndpointDefinitions;

public class SwaggerAppDefinition : IAppDefinition
{
    public void DefineApp(WebApplication app)
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    public void DefineServices(IServiceCollection services, IConfiguration config)
    {
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
    }
}