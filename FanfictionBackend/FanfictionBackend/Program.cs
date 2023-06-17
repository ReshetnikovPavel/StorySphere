using FanfictionBackend.AppDefinitions;
using FanfictionBackend.ExtensionClasses;
using FanfictionBackend.Interfaces;
using FanfictionBackend.Services;

var builder = WebApplication.CreateBuilder(args);

var app = builder.BuildByDefinitions(
    new FanficAppDefinition(),
    new SwaggerAppDefinition()
);

app.UseFileServer();
app.Run();