using FanfictionBackend.Models;

namespace FanfictionBackend.Dto;

public class UserDto
{
    public int Id { get; set; }
    public string Username { get; set; }
    public string Email { get; set; }
    public string? Picture { get; set; }
    public int NumFanfics { get; set; }
    public int ReceivedLikes { get; set; }
}