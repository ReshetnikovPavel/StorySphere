namespace FanfictionBackend.Models;

public class Fanfic
{
    public int Id { get; set; }
    public User Author { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public AgeLimit AgeLimit { get; set; }
    public Category Category { get; set; }
    public DateTimeOffset Created { get; set; }
    public DateTimeOffset Updated { get; set; }
    public string Warnings { get; set; }
    
    public string Genre { get; set; }
    public List<Chapter> Chapters { get; set; }
    public List<Like> Likes { get; set; }
}