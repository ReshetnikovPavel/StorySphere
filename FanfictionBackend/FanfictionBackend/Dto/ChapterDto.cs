namespace FanfictionBackend.Dto;

public class ChapterDto
{
    public int FanficId { get; set; }
    public string Title { get; set; }
    public string? Description { get; set; }
    public string? Text { get; set; }
}