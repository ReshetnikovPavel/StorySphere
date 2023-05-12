using FanfictionBackend.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FanfictionBackend.Configurations;

public class LikeConfiguration : IEntityTypeConfiguration<Like>
{
    public void Configure(EntityTypeBuilder<Like> builder)
    {
        builder.HasKey(l => new { l.UserId, l.FanficId });

        builder.HasOne(l => l.User)
            .WithMany(u => u.Likes)
            .HasForeignKey(l => l.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(l => l.Fanfic)
            .WithMany(f => f.Likes)
            .HasForeignKey(l => l.FanficId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}