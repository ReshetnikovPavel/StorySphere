using FanfictionBackend.Dto;
using FanfictionBackend.Models;
using FanfictionBackend.Pagination;

namespace FanfictionBackend.Interfaces;

public interface IUserRepo
{
    public IEnumerable<User> GetUsers(PagingParameters pagingParameters);
    public Task AddUser(User user);
    public Task<User?> GetByUsername(string name);
    public Task<User?> GetByEmail(string email);
}