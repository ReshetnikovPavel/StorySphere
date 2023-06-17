using FanfictionBackend.Models;
using Microsoft.EntityFrameworkCore;

namespace FanfictionBackend;

public class FanficDb : DbContext
{
    public FanficDb(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Fanfic> Fanfics { get; set; }
    public DbSet<Chapter> Chapters { get; set; }
    public DbSet<Password> Passwords { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Tag> Tags { get; set; }
    public DbSet<Like> Likes { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
    }
}