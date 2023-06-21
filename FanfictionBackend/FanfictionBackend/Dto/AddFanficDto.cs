using FanfictionBackend.Models;

namespace FanfictionBackend.Dto;

public class AddFanficDto
{
    public string Title { get; set; }
    public string Fandom { get; set; }
    public string Characters { get; set; }
    public string Pairings { get; set; }
    public AgeLimit AgeLimit { get; set; }
    public Category Category { get; set; }
    public string Genre { get; set; }
    public string Warnings { get; set; }
    public string AuthorNotes { get; set; }
    public string Description { get; set; }
    public bool IsTranslation { get; set; }
}