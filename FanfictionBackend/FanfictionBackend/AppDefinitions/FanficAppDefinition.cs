using FanfictionBackend.Interfaces;
using FanfictionBackend.Models;
using FanfictionBackend.Repos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FanfictionBackend.EndpointDefinitions;

public class FanficAppDefinition : IAppDefinition
{
    public void DefineApp(WebApplication app)
    {
        app.MapGet("/", HelloWorld);
        app.MapGet("/fanfics", GetAllFanfics);
        app.MapPost("/fanfics", AddFanfic);
        app.MapGet("/fanfics/{id:int}", GetFanficById);
    }

    public void DefineServices(IServiceCollection services, IConfiguration config)
    {
        services.AddDbContext<FanficDb>(options =>
            options.UseNpgsql(config.GetConnectionString("FanfictionDatabase")));
        services.AddScoped<IFanficRepo, FanficRepo>();
    }
    
    public static string HelloWorld()
    {
        return "Hello World!";
    }

    public static async Task<IEnumerable<Fanfic>> GetAllFanfics(IFanficRepo db)
    {
        return await db.GetAll();
    }

    public static async Task<IResult> AddFanfic(IFanficRepo db, Fanfic fanfic)
    {
        await db.AddFanfic(fanfic);
        return Results.Created($"/fanfics/{fanfic.Id}", fanfic);
    }

    public static async Task<Fanfic> GetFanficById(IFanficRepo db, int id)
    {
        return await db.GetById(id);
    }
}