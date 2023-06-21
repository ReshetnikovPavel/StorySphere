using FanfictionBackend.Interfaces;

namespace FanfictionBackend.AppDefinitions;

public class AuthenticationAppDefinition : IAppDefinition
{
    public void DefineApp(WebApplication app){ }

    public void DefineServices(IServiceCollection services, IConfiguration config) { }
}