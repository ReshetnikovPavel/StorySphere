using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FanfictionBackend.Models
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(u => u.Id);

            builder.Property(u => u.Username)
                .IsRequired()
                .HasMaxLength(20);

            builder.Property(u => u.FirstName)
                .HasMaxLength(50);

            builder.Property(u => u.LastName)
                .HasMaxLength(50);

            builder.HasMany<Fanfic>(u => u.Fanfics)
                .WithOne(f => f.Author)
                .HasForeignKey(f => f.AuthorId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }

}