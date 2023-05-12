using FanfictionBackend.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FanfictionBackend.Configurations;

public class FanficConfiguration : IEntityTypeConfiguration<Fanfic>
{
    public void Configure(EntityTypeBuilder<Fanfic> builder)
    {
        builder.HasKey(f => f.Id);

        builder.Property(f => f.Title)
            .IsRequired();

        builder.Property(f => f.Description)
            .HasMaxLength(500);

        builder.Property(f => f.Created)
            .IsRequired();

        builder.HasOne<User>(f => f.Author)
            .WithMany(u => u.Fanfics)
            .HasForeignKey(f => f.AuthorId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany<Tag>(f => f.Tags)
            .WithMany(t => t.Fanfics);

        builder.HasMany<Chapter>(f => f.Chapters)
            .WithOne(c => c.Fanfic)
            .OnDelete(DeleteBehavior.Cascade);
    }
}