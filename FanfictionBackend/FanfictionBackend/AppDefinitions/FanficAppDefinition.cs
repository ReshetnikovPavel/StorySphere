﻿using AutoMapper;
using FanfictionBackend.Dto;
using FanfictionBackend.Interfaces;
using FanfictionBackend.Models;
using FanfictionBackend.Pagination;
using FanfictionBackend.Repos;
using FanfictionBackend.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FanfictionBackend.AppDefinitions;

public class FanficAppDefinition : IAppDefinition
{
    public void DefineApp(WebApplication app)
    {
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
        services.AddScoped<DemoFactory>();
        
        services.AddAutoMapper(typeof(MappingProfile));
    }

    private static void DefineFanficEndpoints(IEndpointRouteBuilder app)
    {
        app.MapGet("/fanfics/recent",  (IFanficService fs, int? pageSize, int? pageNumber)
            => fs.GetRecentlyUpdatedFanfics(new PagingParameters(pageSize, pageNumber)));
        
        app.MapGet("/fanfic",  (IFanficService fs, string title)
            => fs.GetFanficByTitle(title));
        
        app.MapGet("/fanfics",  (IFanficService fs, string authorName, int? pageSize, int? pageNumber)
            => fs.GetFanficsByAuthor(authorName, new PagingParameters(pageSize, pageNumber)));

        app.MapPost("/fanfics",  (IFanficService fs, AddFanficDto fanfic, string userName)
            => fs.AddFanfic(fanfic, userName));
    }

    private static void DefineUserEndpoints(IEndpointRouteBuilder app)
    {
        app.MapGet("/authors", (IUserService us, int? pageSize, int? pageNumber)
            => us.GetUsers(new PagingParameters(pageSize, pageNumber)));
        
        app.MapGet("/author/{username}",  (IUserService us, string username)
            => us.GetUserByUsername(username));
        
        app.MapPost("/authors",  (IUserService us, RegisterDto user, string password)
            => us.RegisterUser(user, password));
        
        app.MapGet("/session",  (IUserService us, string email, string password)
            => us.LoginUser(email, password));
    }
}