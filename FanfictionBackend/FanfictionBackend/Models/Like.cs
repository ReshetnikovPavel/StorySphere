namespace FanfictionBackend.Models;

public class Like
{
    public int Id { get; set; }
    public User User { get; set; }
    public Fanfic Fanfic { get; set; }
}