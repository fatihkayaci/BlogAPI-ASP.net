using BlogAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlogAPI.Infrastructure.Data.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(u => u.Id);
            builder.Property(u => u.Username).IsRequired().HasMaxLength(50);
            builder.Property(u => u.Email).IsRequired().HasMaxLength(100);
            
            // INDEXES
            builder.HasIndex(u => u.Email).IsUnique();        // Zaten vardı
            builder.HasIndex(u => u.Username);                // YENİ - Username araması için
            builder.HasIndex(u => u.CreatedAt);             // YENİ - Tarihe göre sıralama için
        }
    }
}