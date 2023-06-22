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
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Name = "Authorization",
        Description = "Bearer Authentication with JWT Token",
        Type = SecuritySchemeType.Http
    });
    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Id = "Bearer",
                    Type = ReferenceType.SecurityScheme
                }
            },
            new List<string>()
        }
    });
});

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateActor = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidAudience = builder.Configuration["Jwt:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
    };
});
builder.Services.AddAuthorization();

builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

app.UseSwagger();
app.UseAuthorization();
app.UseAuthentication();

app.MapPost("/login", (string username) => Login(username));

app.MapDelete("/hello",
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    () => "Hello, world!");

IResult Login(string username)
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
}

app.UseSwaggerUI();

app.Run();
