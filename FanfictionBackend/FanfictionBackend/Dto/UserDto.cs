using FanfictionBackend.Models;

namespace FanfictionBackend.Dto;

public class UserDto
{
    public string Username { get; set; }
    public string Email { get; set; }
    public int NumFanfics { get; set; }
    public int NumLikes { get; set; }
}