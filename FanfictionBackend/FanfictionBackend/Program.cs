using FanfictionBackend.EndpointDefinitions;
using FanfictionBackend.ExtensionClasses;

var builder = WebApplication.CreateBuilder(args);

var app = builder.BuildWithEndpoints(
    new FanficAppDefinition(),
    new SwaggerAppDefinition()
);

app.Run();