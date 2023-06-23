namespace FanfictionBackend.Dto;

public class SessionDto
{
    public UserDto User { get; set; }
    public string Token { get; set; }
}