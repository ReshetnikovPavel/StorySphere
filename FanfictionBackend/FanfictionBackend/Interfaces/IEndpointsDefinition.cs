namespace FanfictionBackend.Interfaces;

public interface IAppDefinition
{
    public void DefineEndpoints(WebApplication app);
    public void DefineServices(IServiceCollection services);
}