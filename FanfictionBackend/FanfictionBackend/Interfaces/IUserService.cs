using FanfictionBackend.Dto;
using FanfictionBackend.Models;
using FanfictionBackend.Pagination;

namespace FanfictionBackend.Interfaces;

public interface IUserService
{
    IResult GetUsers(PagingParameters pagingParameters);
    Task<IResult> GetUserByUsername(string username);
    Task<IResult> RegisterUser(UserDto user, string password);
    Task<IResult> LoginUser(string username, string password);
}