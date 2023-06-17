using FanfictionBackend.Interfaces;
using FanfictionBackend.Models;

// ReSharper disable StaticMemberInitializerReferesToMemberBelow

namespace FanfictionBackend.Services;

public class DemoFactory
{
    private readonly IUserService _userService;
    private readonly IFanficService _fanficService;
    
    public DemoFactory(IUserService userService, IFanficService fanficService)
    {
        _userService = userService;
        _fanficService = fanficService;
    }

    public void InitData()
    {
        InitUsers();
        InitFanfics();
    }
    
    private void InitUsers()
    {
        _userService.RegisterUser(new User
        {
            Username = "Capitulation",
            Email = "Andreydolphin@mail.ru"
        }, "Capitulation");
        
        _userService.RegisterUser(new User
        {
            Username = "SoftOwl",
            Email = "AnyaSok@mail.ru"
        }, "SoftOwl");
        
        _userService.RegisterUser(new User
        {
            Username = "PavelResh",
            Email = "pasha.keyzet@yandex.ru"
        }, "PavelResh");
    }

    private static void InitFanfics()
    {
        //TODO: Implement
    }
}

