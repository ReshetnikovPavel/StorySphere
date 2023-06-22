using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using FanfictionBackend.AppDefinitions;
using FanfictionBackend.ExtensionClasses;
using FanfictionBackend.Interfaces;
using FanfictionBackend.Models;
using FanfictionBackend.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

var app = builder.BuildByDefinitions(
    new SwaggerAppDefinition(),
    new AuthenticationAppDefinition(),
    new FanficAppDefinition()
);

using (var scope = app.Services.CreateScope())
{
    var demoFactory = scope.ServiceProvider.GetRequiredService<DemoFactory>();
    demoFactory.InitData();
}


app.UseFileServer();
app.Run();

