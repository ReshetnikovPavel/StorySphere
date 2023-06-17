using FanfictionBackend.Dto;
using FanfictionBackend.Models;

namespace FanfictionBackend.Interfaces;

public interface IUserRepo
{
    public Task<IEnumerable<User>> GetAllUsers();
    public Task AddUser(UserDto user);
    public Task<User?> GetByUsername(string name);
}