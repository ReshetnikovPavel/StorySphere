using FanfictionBackend;
using FanfictionBackend.EndpointDefinitions;
using FanfictionBackend.ExtensionClasses;
using FanfictionBackend.Interfaces;
using FanfictionBackend.Models;
using Microsoft.OpenApi.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo {
        Title = "Fanfiction API",
        Version = "v1" });
});
builder.Services.AddDbContext<IFanficRepo, FanficDb>(options => options.UseInMemoryDatabase("items"));

var app = builder.BuildWithEndpoints(new FanficAppDefinition());
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "PizzaStore API V1");
});

app.Run();