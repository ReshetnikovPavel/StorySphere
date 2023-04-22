namespace FanfictionBackend.Models;
using Microsoft.EntityFrameworkCore;

public class Fanfic
{
    public int Id { get; set; }
    public string? Title { get; set; }
    public string? Description { get; set; }
    public string? Text { get; set; }
    public List<Tag> Tags { get; set; }
    public DateTime PostedOn { get; set; }
    public User Author { get; set; }
    public AgeLimit AgeLimit { get; set; }
    public Category Category { get; set; }
}