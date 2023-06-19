using FanfictionBackend.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FanfictionBackend.Configurations;

public class FanficConfiguration : IEntityTypeConfiguration<Fanfic>
{
    public void Configure(EntityTypeBuilder<Fanfic> builder)
    {
        
    }
}