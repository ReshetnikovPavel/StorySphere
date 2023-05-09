using FanfictionBackend.Interfaces;
using FanfictionBackend.Models;
using FanfictionBackend.Repos;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace FanfictionBackend.EndpointDefinitions;

public class FanficAppDefinition : IAppDefinition
{
    public void DefineApp(WebApplication app)
    {
        app.MapGet("/", GetRecentlyUpdatedFanfics);
        app.MapGet("/", LoginUser);
        app.MapGet("/", RegisterUser);
        app.MapGet("/authors", GetAllUsers);
        app.MapGet("/fanfic", GetFanficByName);
        app.MapGet("/fanfic/{id:int}", GetFanficById);
    }

    public void DefineServices(IServiceCollection services, IConfiguration config)
    {
        services.AddDbContext<FanficDb>(options =>
            options.UseNpgsql(config.GetConnectionString("FanfictionDatabase")));
        services.AddScoped<IFanficRepo, FanficRepo>();
    }
    
    public static async Task<IEnumerable<Fanfic>> GetRecentlyUpdatedFanfics(IFanficRepo repo)
    {
        throw new NotImplementedException();
    }

    public static async Task<IEnumerable<User>> GetAllUsers(IFanficRepo repo)
    {
        throw new NotImplementedException();
    }

    public static async Task<IResult> GetFanficByName(IFanficRepo repo, string name)
    {
        throw new NotImplementedException();
    }

    public static async Task<IResult> RegisterUser(IFanficRepo repo, User user)
    {
        throw new NotImplementedException();
    }

    public static async Task<IResult> LoginUser(IFanficRepo repo, string username, string password)
    {
        throw new NotImplementedException();
    }
    
    public static async Task<IResult> GetFanficById(IFanficRepo repo, int id)
    {
        var fanfic = await repo.GetById(id);
        return fanfic == null ? TypedResults.NotFound() : TypedResults.Ok(fanfic);
    }
}