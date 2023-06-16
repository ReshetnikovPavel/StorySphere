using FanfictionBackend.Interfaces;
using FanfictionBackend.Models;

namespace FanfictionBackend.Services;

public class UserService : IUserService
{
    public async Task<IResult> GetAllUsers()
    {
        throw new NotImplementedException();
    }

    public async Task<IResult> GetUserById(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<IResult> RegisterUser(User user, string password)
    {
        throw new NotImplementedException();
    }

    public async Task<IResult> LoginUser(string username, string password)
    {
        throw new NotImplementedException();
    }
}