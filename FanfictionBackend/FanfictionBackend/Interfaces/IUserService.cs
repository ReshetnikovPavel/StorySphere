using FanfictionBackend.Dto;
using FanfictionBackend.Models;

namespace FanfictionBackend.Interfaces;

public interface IUserService
{
    Task<IResult> GetAllUsers();
    Task<IResult> GetUserByUsername(string username);
    Task<IResult> RegisterUser(UserDto user, string password);
    Task<IResult> LoginUser(string username, string password);
}