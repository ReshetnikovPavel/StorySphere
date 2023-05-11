﻿using FanfictionBackend.Interfaces;
using FanfictionBackend.Models;
using FanfictionBackend.Repos;
using FanfictionBackend.Services;
using Microsoft.EntityFrameworkCore;

namespace FanfictionBackend.AppDefinitions;

public class FanficAppDefinition : IAppDefinition
{
    public void DefineApp(WebApplication app)
    {
        app.MapGet("/", GetRecentlyUpdatedFanfics);
        app.MapGet("/", LoginUser);
        app.MapGet("/", RegisterUser);
        app.MapGet("/authors", GetAllUsers);
        app.MapGet("/author/{id:int}", GetUserById);
        app.MapGet("/fanfic", GetFanficByTitle);
        app.MapGet("/fanfic/{id:int}", GetFanficById);
    }

    public void DefineServices(IServiceCollection services, IConfiguration config)
    {
        services.AddDbContext<FanficDb>(options =>
            options.UseNpgsql(config.GetConnectionString("FanfictionDatabase")));
        services.AddScoped<IFanficRepo, FanficRepo>();
        services.AddScoped<IUserRepo, UserRepo>();
        services.AddScoped<IPasswordHasher, PasswordHasher>();
    }
    
    public static async Task<IEnumerable<Fanfic>> GetRecentlyUpdatedFanfics(IFanficRepo repo)
    {
        throw new NotImplementedException();
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
        var hashedPassword = hasher.HashPassword(password, out var salt);
        user.HashedPassword = hashedPassword;
        user.PasswordSalt = salt;
        await repo.AddUser(user);
        return TypedResults.Created($"/author/{user.Id}");
    }

    public static async Task<IResult> LoginUser(IUserRepo repo, string username, string password)
    {
        var user = await repo.GetByUsername(username);
        if (user == null) // TODO: check password
            return TypedResults.NotFound("Invalid username or password");
        return Results.Ok(user);
    }
    
    public static async Task<IResult> GetFanficById(IFanficRepo repo, int id)
    {
        var fanfic = await repo.GetById(id);
        return fanfic == null ? TypedResults.NotFound() : TypedResults.Ok(fanfic);
    }
}