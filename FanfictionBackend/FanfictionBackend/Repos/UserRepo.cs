using FanfictionBackend.Interfaces;
using FanfictionBackend.Models;
using Microsoft.EntityFrameworkCore;

namespace FanfictionBackend.Repos;

public class UserRepo : IUserRepo
{
    private readonly FanficDb _dataContext;

    public UserRepo(FanficDb dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task AddUser(User user)
    {
        await _dataContext.Users.AddAsync(user);
        await _dataContext.SaveChangesAsync();
    }

    public async Task<User?> GetByUsername(string username)
    {
        return await _dataContext.Users.FirstOrDefaultAsync(user => user.Username == username);
    }
}