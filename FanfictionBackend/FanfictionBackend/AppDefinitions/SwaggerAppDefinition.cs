using FanfictionBackend.Interfaces;
using Microsoft.OpenApi.Models;

namespace FanfictionBackend.EndpointDefinitions;

public class SwaggerAppDefinition : IAppDefinition
{
    public void DefineApp(WebApplication app)
    {
        app.UseSwagger();
        //TODO: Pizza :D
        app.UseSwaggerUI(c => { c.SwaggerEndpoint("/swagger/v1/swagger.json", "PizzaStore API V1"); });
    }

    public void DefineServices(IServiceCollection services, IConfiguration config)
    {
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "Fanfiction API",
                Version = "v1"
            });
        });
    }
}