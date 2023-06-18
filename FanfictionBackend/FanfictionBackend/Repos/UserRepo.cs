using FanfictionBackend.Dto;
using FanfictionBackend.ExtensionClasses;
using FanfictionBackend.Interfaces;
using FanfictionBackend.Models;
using FanfictionBackend.Pagination;
using Microsoft.EntityFrameworkCore;

namespace FanfictionBackend.Repos;

public class UserRepo : IUserRepo
{
    private readonly FanficDb _dataContext;

    public UserRepo(FanficDb dataContext)
    {
        _dataContext = dataContext;
    }

    public PagedList<User> GetUsers(PagingParameters pagingParameters)
    {
        return _dataContext.Users
            .OrderByDescending(u => u.NumLikes)
            .ToPagedList(pagingParameters);
    }

    public async Task AddUser(User user)
    {
        await _dataContext.Users.AddAsync(user);
        await _dataContext.Passwords.AddAsync(user.Password);
        await _dataContext.SaveChangesAsync();
    }

    public async Task<User?> GetByUsername(string username)
    {
        return await _dataContext.Users.FirstOrDefaultAsync(user => user.Username == username.ToLower());
    }
    
    public async Task<User?> GetByEmail(string email)
    {
        return await _dataContext.Users
            .Include(u => u.Password)
            .FirstOrDefaultAsync(user => user.Email == email.ToLower());
    }
}