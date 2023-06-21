using FanfictionBackend.AppDefinitions;
using FanfictionBackend.ExtensionClasses;
using FanfictionBackend.Interfaces;
using FanfictionBackend.Services;

var builder = WebApplication.CreateBuilder(args);

var app = builder.BuildByDefinitions(
    new FanficAppDefinition(),
    new SwaggerAppDefinition(),
    new AuthenticationAppDefinition()
);

using (var scope = app.Services.CreateScope())
{
    var demoFactory = scope.ServiceProvider.GetRequiredService<DemoFactory>();
    demoFactory.InitData();
}

app.UseFileServer();
app.Run();