using FanfictionBackend.AppDefinitions;
using FanfictionBackend.Interfaces;

namespace FanfictionBackend.ExtensionClasses;

public static class ApplicationBuilderExtensions
{
    public static WebApplication BuildByDefinitions(this WebApplicationBuilder builder,
        params IAppDefinition[] appDefs)
    {
        foreach (var def in appDefs)
            def.DefineServices(builder.Services, builder.Configuration);
        var app = builder.Build();
        foreach (var def in appDefs)
            def.DefineApp(app);

        return app;
    }
}