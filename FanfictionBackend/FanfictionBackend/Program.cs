using FanfictionBackend.AppDefinitions;
using FanfictionBackend.EndpointDefinitions;
using FanfictionBackend.ExtensionClasses;

var builder = WebApplication.CreateBuilder(args);

var app = builder.BuildByDefinitions(
    new FanficAppDefinition(),
    new SwaggerAppDefinition()
);

app.Run();