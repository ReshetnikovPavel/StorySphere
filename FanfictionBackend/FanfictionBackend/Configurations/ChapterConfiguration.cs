using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using FanfictionBackend.Models;

namespace FanfictionBackend.Configurations;

public class ChapterConfiguration : IEntityTypeConfiguration<Chapter>
{
    public void Configure(EntityTypeBuilder<Chapter> builder)
    {
        builder.HasKey(c => c.FanficId);
        
        builder.Property(c => c.Title)
            .IsRequired()
            .HasMaxLength(200);
        
        builder.Property(c => c.Description)
            .HasMaxLength(500);
        
        builder.HasOne(c => c.Fanfic)
            .WithMany(f => f.Chapters)
            .HasForeignKey(c => c.FanficId);
    }
}
