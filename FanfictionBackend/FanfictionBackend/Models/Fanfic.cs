namespace FanfictionBackend.Models;

public class Fanfic
{
    public int Id { get; set; }
    public string? Title { get; set; }
    public string? Description { get; set; }
    public List<Tag> Tags { get; set; }
    public DateTimeOffset Created { get; set; }
    public DateTimeOffset Updated { get; set; }
    public int AuthorId { get; set; }
    public User Author { get; set; }
    public AgeLimit AgeLimit { get; set; }
    public Category Category { get; set; }
    public List<Chapter> Chapters { get; set; }
    public List<Like> Likes { get; set; }
}