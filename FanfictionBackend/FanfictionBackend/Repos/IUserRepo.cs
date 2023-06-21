using FanfictionBackend.Models;
using FanfictionBackend.Pagination;

namespace FanfictionBackend.Repos;

public interface IUserRepo
{
    public PagedList<User> GetUsers(PagingParameters pagingParameters);
    public void AddUser(User user);
    public User? GetByUsername(string? name);
    public User? GetByEmail(string? email);
}