using FanfictionBackend.Models;

namespace FanfictionBackend.Dto;

public class FanficDto
{
    public int Id { get; set; }
    public string? Title { get; set; }
    public string? Description { get; set; }
    public List<TagDto> Tags { get; set; }
    public int AuthorId { get; set; }
    public AgeLimit AgeLimit { get; set; }
    public Category Category { get; set; }
}