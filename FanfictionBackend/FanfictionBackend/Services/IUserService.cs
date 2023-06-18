using FanfictionBackend.Dto;
using FanfictionBackend.Pagination;

namespace FanfictionBackend.Services;

public interface IUserService
{
    IResult GetUsers(PagingParameters pagingParameters);
    IResult GetUserByUsername(string username);
    IResult RegisterUser(UserDto user, string password);
    IResult LoginUser(string email, string password);
}