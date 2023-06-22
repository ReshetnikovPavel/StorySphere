using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using FanfictionBackend.AppDefinitions;
using FanfictionBackend.ExtensionClasses;
using FanfictionBackend.Interfaces;
using FanfictionBackend.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

var app = builder.BuildByDefinitions(
    new SwaggerAppDefinition(),
    new AuthenticationAppDefinition()
    // new FanficAppDefinition()
);

// using (var scope = app.Services.CreateScope())
// {
//     var demoFactory = scope.ServiceProvider.GetRequiredService<DemoFactory>();
//     demoFactory.InitData();
// }

DefineJwtTestingEndpoints(app);

app.UseFileServer();
app.Run();

void DefineJwtTestingEndpoints(WebApplication app)
{
    app.MapPost("/login", (string username) => 
    {
        var claims = new[]
        {
            new Claim(ClaimTypes.NameIdentifier, username),
        };

        var token = new JwtSecurityToken
        (
            issuer: builder.Configuration["Jwt:Issuer"],
            audience: builder.Configuration["Jwt:Audience"],
            claims: claims,
            expires: DateTime.UtcNow.AddDays(60),
            notBefore: DateTime.UtcNow,
            signingCredentials: new SigningCredentials(
                new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"])),
                SecurityAlgorithms.HmacSha256)
        );

        var tokenString = new JwtSecurityTokenHandler().WriteToken(token);

        return Results.Ok(tokenString);
    });

    app.MapGet("/hello",
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        (ClaimsPrincipal user) => 
        {
            var name = user.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            return $"Hello, {name}";
        });
}