using FanfictionBackend.Dto;

namespace FanfictionBackend.Services;

public class TokenService : ITokenService
{
    private readonly IConfiguration _configuration;

    public TokenService(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public string GenerateToken()
    {
        throw new NotImplementedException();
    }
}