using FanfictionBackend.Interfaces;

namespace FanfictionBackend.ExtensionClasses;

public static class ApplicationBuilderExtensions
{
    public static WebApplication BuildWithEndpoints(this WebApplicationBuilder builder, 
        params IAppDefinition[] endpointDefs)
    {
        var app = builder.Build();
        foreach (var def in endpointDefs)
        {
            def.DefineEndpoints(app);
        }
        return app;
    }
}