using FanfictionBackend.Dto;
using FanfictionBackend.Models;

namespace FanfictionBackend.Interfaces;

public interface IUserRepo
{
    public Task<IEnumerable<User>> GetAllUsers();
    public Task AddUser(User user);
    public Task<User?> GetByUsername(string name);
    public Task<User?> GetByEmail(string email);
}