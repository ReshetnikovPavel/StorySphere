namespace FanfictionBackend.Models;

public class Like
{
    public int Id { get; set; }
    public string Username { get; set; }
    public int FanficId { get; set; }
}