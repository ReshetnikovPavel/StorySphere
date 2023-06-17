namespace FanfictionBackend.Models;

public class User
{
    public int Id { get; set; }
    public string Username { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string Email { get; set; }
    public List<Fanfic> Fanfics { get; set; }
    public Password Password { get; set; }
    public List<Like> Likes { get; set; }
}