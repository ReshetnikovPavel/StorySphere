using FanfictionBackend.Dto;
using FanfictionBackend.Models;

namespace FanfictionBackend.Services;

public interface ITokenService
{
    public string GenerateToken(User user);
}