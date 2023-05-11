using FanfictionBackend.Models;

namespace FanfictionBackend.Interfaces;

public interface IUserRepo
{
    public Task AddUser(User user);
    public Task<User?> GetByUsername(string name);
}