namespace FanfictionBackend.Models;

public class Tag
{
    public string Name { get; set; }
    public List<Fanfic> Fanfics { get; set; }
}