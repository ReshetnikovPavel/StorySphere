using FanfictionBackend.Models;

namespace FanfictionBackend.Dto;

public class FanficDto
{
    public int Id { get; set; }
    public string AuthorName { get; set; }
    public string Title { get; set; }
    public string Fandom { get; set; }
    public string Characters { get; set; }
    public string Pairings { get; set; }
    public string AgeLimit { get; set; }
    public string Category { get; set; }
    public string Genre { get; set; }
    public string Warnings { get; set; }
    public string AuthorNotes { get; set; }
    public string Description { get; set; }
    public bool IsTranslation { get; set; }
    
    public int NumLikes { get; set; }
    public int NumChapters { get; set; }
    public DateTimeOffset Created { get; set; }
    public DateTimeOffset LastUpdated { get; set; }
}