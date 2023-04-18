using FanfictionBackend.Models;
using Microsoft.EntityFrameworkCore;

namespace FanfictionBackend;

public class FanficDb : DbContext
{
    public FanficDb(DbContextOptions options) : base(options) { }
    public DbSet<Fanfic> Fanfics { get; set; } = null!;
}