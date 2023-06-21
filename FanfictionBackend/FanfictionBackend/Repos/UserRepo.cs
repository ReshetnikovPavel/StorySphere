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
            .OrderByDescending(u => u.ReceivedLikes)
            .ToPagedList(pagingParameters);
    }

    public async void AddUser(User user)
    {
        await _dataContext.Users.AddAsync(user);
        await _dataContext.Passwords.AddAsync(user.Password);
        await _dataContext.SaveChangesAsync();
    }

    public User? GetByUsername(string username)
    {
        return _dataContext.Users
            .Include(u => u.Fanfics)
            .FirstOrDefault(user => user.Username == username.ToLower());
    }
    
    public User? GetByEmail(string email)
    {
        return _dataContext.Users
            .Include(u => u.Password)
            .FirstOrDefault(user => user.Email == email.ToLower());
    }
}