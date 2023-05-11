namespace FanfictionBackend.Models;

public class User
{
    public int Id { get; set; }
    public string Username { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public List<Fanfic> Fanfics { get; set; }
    public string HashedPassword { get; set; }
    public byte[] PasswordSalt { get; set; }
}