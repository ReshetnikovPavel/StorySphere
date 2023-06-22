using System.Security.Claims;
using AutoMapper;
using FanfictionBackend.Dto;
using FanfictionBackend.Interfaces;
using FanfictionBackend.Models;
using FanfictionBackend.Pagination;
using FanfictionBackend.Repos;
using FanfictionBackend.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FanfictionBackend.AppDefinitions;

public class FanficAppDefinition : IAppDefinition
{
    public void DefineApp(WebApplication app)
    {
        DefineFanficEndpoints(app);
        DefineChapterEndpoints(app);
        DefineUserEndpoints(app);
    }

    public void DefineServices(IServiceCollection services, IConfiguration config)
    {
        services.AddDbContext<FanficDb>(options =>
            options.UseInMemoryDatabase("FanfictionDatabase"));

        services.AddScoped<IFanficRepo, FanficRepo>();
        services.AddScoped<IUserRepo, UserRepo>();
        services.AddScoped<IChapterRepo, ChapterRepo>();
        services.AddScoped<IPasswordHasher, PasswordHasher>();
        services.AddScoped<IDateTimeProvider, UtcDateTimeProvider>();
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IFanficService, FanficService>();
        services.AddScoped<DemoFactory>();

        services.AddAutoMapper(typeof(MappingProfile));
    }

    private static void DefineFanficEndpoints(IEndpointRouteBuilder app)
    {
        app.MapGet("/fanfics/recent",  (IFanficService fs, int? pageSize, int? pageNumber)
            => fs.GetRecentlyUpdatedFanfics(new PagingParameters(pageSize, pageNumber)));

        app.MapGet("/fanfics/title",  (IFanficService fs, string title, int? pageSize, int? pageNumber)
            => fs.GetFanficsByTitle(title, new PagingParameters(pageSize, pageNumber)));

        app.MapGet("/fanfics/author",  (IFanficService fs, string? authorName, int? pageSize, int? pageNumber)
            => fs.GetFanficsByAuthor(authorName, new PagingParameters(pageSize, pageNumber)));

        app.MapPost("/fanfics",
            [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
            (IFanficService fs, HttpContext context, AddFanficDto fanfic) =>
            {
                var userNameClaim = context.User.FindFirst(c => c.Type == ClaimTypes.NameIdentifier);
                return fs.AddFanfic(fanfic, userNameClaim?.Value);
            });
    }

    private static void DefineChapterEndpoints(IEndpointRouteBuilder app)
    {
        app.MapGet("/chapters",  (IFanficService fs, int fanficId, int chapterNo)
            => fs.GetChapter(fanficId, chapterNo));

        app.MapPost("/chapters",  (IFanficService fs, [FromQuery] int fanficId, AddChapterDto chapter)
            => fs.AddChapter(fanficId, chapter));
    }

    private static void DefineUserEndpoints(IEndpointRouteBuilder app)
    {
        app.MapGet("/authors", (IUserService us, int? pageSize, int? pageNumber)
            => us.GetUsers(new PagingParameters(pageSize, pageNumber)));

        app.MapGet("/author/{username}",  (IUserService us, string? username)
            => us.GetUserByUsername(username));

        app.MapPost("/authors",  (IUserService us, RegisterDto user, string password)
            => us.RegisterUser(user, password));

        app.MapGet("/session",  (IUserService us, string? email, string password)
            => us.LoginUser(email, password));
    }
}
