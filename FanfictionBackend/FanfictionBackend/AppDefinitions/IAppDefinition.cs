namespace FanfictionBackend.AppDefinitions;

public interface IAppDefinition
{
    public void DefineApp(WebApplication app);
    public void DefineServices(IServiceCollection services, IConfiguration config);
}