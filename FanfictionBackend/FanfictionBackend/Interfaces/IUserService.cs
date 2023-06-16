using FanfictionBackend.Models;

namespace FanfictionBackend.Interfaces;

public interface IUserService
{
    Task<IResult> GetAllUsers();
    Task<IResult> GetUserById(int id);
    Task<IResult> RegisterUser(User user, string password);
    Task<IResult> LoginUser(string username, string password);
}