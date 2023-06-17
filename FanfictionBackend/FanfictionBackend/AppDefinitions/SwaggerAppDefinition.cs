using FanfictionBackend.Interfaces;

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
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
    }
}