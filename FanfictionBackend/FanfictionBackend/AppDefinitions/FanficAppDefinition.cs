using System.Security.Claims;
using AutoMapper;
using FanfictionBackend.Dto;
using FanfictionBackend.Interfaces;
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
        DefineImageEndpoints(app);
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
        services.AddScoped<ILikeService, LikeService>();
        services.AddScoped<DemoFactory>();

        var imgurKey = config.GetSection("ImgurKey").Value;
        if (imgurKey is null)
            throw new Exception("ImgurKey is not in appsettings.json");
        services.AddScoped<IImageService, ImgurImageService>(provider => new ImgurImageService(imgurKey));

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

        app.MapGet("/fanfics", (IFanficService fs, [FromQuery] int fanficId)
            => fs.GetFanficById(fanficId));

        app.MapPost("/fanfics",
            [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
            (ClaimsPrincipal user, IFanficService fs, AddFanficDto fanfic) =>
            {
                var authorName = user.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                return fs.AddFanfic(fanfic, authorName);
            });
    }

    private static void DefineChapterEndpoints(IEndpointRouteBuilder app)
    {
        app.MapGet("/chapters",  (IFanficService fs, [FromQuery] int fanficId, [FromQuery] int chapterNo)
            => fs.GetChapter(fanficId, chapterNo));

        app.MapPost("/chapters",
            [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
            (ClaimsPrincipal user, IFanficService fs, [FromQuery] int fanficId, AddChapterDto chapter) =>
        {
            var authorName = user.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            return fs.AddChapter(fanficId, chapter, authorName);
        });
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

    private static void DefineImageEndpoints(IEndpointRouteBuilder app)
    {
        app.MapPost("/image", (IImageService imageService, IFormFile image)
            => imageService.Upload(image));
    }

    private static void DefineLikeEndpoints(IEndpointRouteBuilder app)
    {
        app.MapPost("/likes",
            [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
            (ClaimsPrincipal user, ILikeService ls, int fanficId) =>
            {
                var username = user.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                return ls.AddLike(fanficId, username);
            });
        
        app.MapPost("/delete",
            [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
            (ClaimsPrincipal user, ILikeService ls, int fanficId) =>
            {
                var username = user.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                return ls.RemoveLike(fanficId, username);
            });
    }
}
