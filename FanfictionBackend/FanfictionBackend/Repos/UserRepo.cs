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
            .Include(u => u.Fanfics)
            .OrderByDescending(u => u.ReceivedLikes)
            .ToPagedList(pagingParameters);
    }

    public async void AddUser(User user)
    {
        await _dataContext.Users.AddAsync(user);
        await _dataContext.Passwords.AddAsync(user.Password);
        await _dataContext.SaveChangesAsync();
    }

    public User? GetByUsername(string? username)
    {
        return _dataContext.Users
            .Include(u => u.Fanfics)
            .ThenInclude(f => f.Likes)
            .FirstOrDefault(user => username != null && string.Equals(
                user.Username, username, StringComparison.CurrentCultureIgnoreCase));
    }
    
    public User? GetByEmail(string? email)
    {
        return _dataContext.Users
            .Include(u => u.Fanfics)
            .Include(u => u.Password)
            .FirstOrDefault(user => string.Equals(
                user.Email, email, StringComparison.CurrentCultureIgnoreCase));
    }

    public void SetPicture(string picture, User user)
    {
        user.Picture = picture;
        _dataContext.SaveChanges();
    }
}