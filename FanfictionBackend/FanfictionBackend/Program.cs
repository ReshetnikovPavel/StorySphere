using FanfictionBackend;
using FanfictionBackend.EndpointDefinitions;
using FanfictionBackend.ExtensionClasses;
using FanfictionBackend.Interfaces;
using FanfictionBackend.Models;
using Microsoft.OpenApi.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var app = builder.BuildWithEndpoints(
    new FanficAppDefinition(),
    new SwaggerAppDefinition()
);

app.Run();