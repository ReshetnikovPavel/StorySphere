namespace FanfictionBackend.Models;

public class Chapter
{
    public int FanficId { get; set; }
    public Fanfic Fanfic { get; set; }
    public string Title { get; set; }
    public string? Description { get; set; }
    public string? Text { get; set; }
}