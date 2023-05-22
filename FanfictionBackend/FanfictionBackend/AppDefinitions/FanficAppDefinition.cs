using AutoMapper;
using FanfictionBackend.Dto;
using FanfictionBackend.Interfaces;
using FanfictionBackend.Models;
using FanfictionBackend.Repos;
using FanfictionBackend.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FanfictionBackend.AppDefinitions;

public class FanficAppDefinition : IAppDefinition
{
    public void DefineApp(WebApplication app)
    {
        app.MapGet("/fanfics/recent", GetRecentlyUpdatedFanfics);
        app.MapGet("/fanfic", GetFanficByTitle);
        app.MapGet("/fanfic/{id:int}", GetFanficById);
        app.MapPost("/fanfics", AddFanfic);
        app.MapPost("/fanfic/{id:int}/chapters", AddChapter);

        app.MapGet("/authors", GetAllUsers);
        app.MapGet("/author/{id:int}", GetUserById);
        app.MapPost("/authors", RegisterUser);
        
        app.MapGet("/session", LoginUser);
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
        
        services.AddAutoMapper(typeof(MappingProfile));

    }
    public static async Task<IResult> GetRecentlyUpdatedFanfics(IFanficRepo repo, int pageNumber, int pageSize)
    {
        try
        {
            return TypedResults.Ok(await repo.GetRecentlyUpdated(pageNumber, pageSize));
        }
        catch (ArgumentException e)
        {
            return TypedResults.BadRequest(e);
        }
    }

    public static async Task<IEnumerable<User>> GetAllUsers(IFanficRepo repo)
    {
        throw new NotImplementedException();
    }

    public static async Task<User> GetUserById(IUserRepo repo, int id)
    {
        throw new NotImplementedException();
    }
    
    public static async Task<IResult> GetFanficByTitle(IFanficRepo repo, string? title)
    {
        if (title == null)
            return TypedResults.BadRequest("Fanfic title can't be null");
        var fanfic = await repo.GetByTitle(title);
        return fanfic == null ? TypedResults.NotFound() : TypedResults.Redirect($"/fanfic/{fanfic.Id}");
    }

    public static async Task<IResult> RegisterUser(IPasswordHasher hasher, IUserRepo repo, User user, string password)
    {
        var existingUser = repo.GetByUsername(user.Username);
        if (existingUser.Result != null)
            return TypedResults.Conflict("Username already registered");
        user.Password = hasher.HashPassword(password);
        await repo.AddUser(user);
        return TypedResults.Created($"/author/{user.Id}");
    }

    public static async Task<IResult> LoginUser(IPasswordHasher hasher, IUserRepo repo, string username, string password)
    {
        var user = await repo.GetByUsername(username);
        if (user == null || !hasher.VerifyPassword(password, user.Password))
            return TypedResults.NotFound("Invalid username or password");
        return Results.Ok(user);
    }
    
    public static async Task<IResult> GetFanficById(IFanficRepo repo, int id)
    {
        var fanfic = await repo.GetById(id);
        return fanfic == null ? TypedResults.NotFound() : TypedResults.Ok(fanfic);
    }

    public static async Task<IResult> AddFanfic(IFanficRepo repo, IMapper mapper, IDateTimeProvider datetimeProvider, FanficDto fanficDto)
    {
        var fanfic = mapper.Map<FanficDto, Fanfic>(fanficDto);
        fanfic.Created = datetimeProvider.Now;
        fanfic.Updated = fanfic.Created;
        
        await repo.AddFanfic(fanfic);
        return TypedResults.Ok();
    }

    public static async Task<IResult> AddChapter(IChapterRepo repo, IMapper mapper, ChapterDto chapterDto, int id)
    {
        var chapter = mapper.Map<ChapterDto, Chapter>(chapterDto);
        chapter.FanficId = id;
        
        await repo.AddChapter(chapter);
        return TypedResults.Ok();
    }
}