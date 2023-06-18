namespace FanfictionBackend.Models;

public class User
{
    public int Id { get; set; }
    public string Username { get; set; }
    public string Email { get; set; }
    public string? Picture { get; set; }
    public List<Fanfic> Fanfics { get; set; } = new();
    public Password Password { get; set; }
    public List<Like> Likes { get; set; } = new();
    public int ReceivedLikes { get; set; } 
}