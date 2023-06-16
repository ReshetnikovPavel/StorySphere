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
        app.MapGet("/", HelloWorld);
        DefineFanficEndpoints(app);
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
        
        services.AddAutoMapper(typeof(MappingProfile));
    }

    private static void DefineFanficEndpoints(IEndpointRouteBuilder app)
    {
        app.MapGet("/fanfics/recent", async (IFanficService fs, int pageNumber, int pageSize)
            => await fs.GetRecentlyUpdatedFanfics(pageNumber, pageSize));
        
        app.MapGet("/fanfic", async (IFanficService fs, string? title)
            => await fs.GetFanficByTitle(title));
        
        app.MapGet("/fanfic/{id:int}", async (IFanficService fs, int id)
            => await fs.GetFanficById(id));
        
        app.MapPost("/fanfics", async (IFanficService fs, Fanfic fanfic)
            => await fs.AddFanfic(fanfic));
        
        app.MapPost("/fanfic/{id:int}/chapters", async (IFanficService fs, Chapter chapter, int id)
            => await fs.AddChapter(chapter, id));
    }

    private static void DefineUserEndpoints(IEndpointRouteBuilder app)
    {
        app.MapGet("/authors", async (IUserService us)
            => await us.GetAllUsers());
        
        app.MapGet("/author/{id:int}", async (IUserService us, int id)
            => await us.GetUserById(id));
        
        app.MapPost("/authors", async (IUserService us, User user, string password)
            => await us.RegisterUser(user, password));
        
        app.MapGet("/session", async (IUserService us, string username, string password)
            => await us.LoginUser(username, password));
    }

    private static async Task<IResult> HelloWorld()
    {
        async Task<Fanfic> CreateAsync() => new() { Title = "Greetings, thou cosmos!" };
        var res = await CreateAsync();
        return TypedResults.Ok(res);
    }
}