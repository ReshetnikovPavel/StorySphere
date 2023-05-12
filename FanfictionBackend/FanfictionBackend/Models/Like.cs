namespace FanfictionBackend.Models;

public class Like
{
    public int UserId { get; set; }
    public User User { get; set; }
    public int FanficId { get; set; }
    public Fanfic Fanfic { get; set; }
}