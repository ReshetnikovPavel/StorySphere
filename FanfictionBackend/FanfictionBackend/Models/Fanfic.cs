namespace FanfictionBackend.Models;
using Microsoft.EntityFrameworkCore;

public class Fanfic
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
}