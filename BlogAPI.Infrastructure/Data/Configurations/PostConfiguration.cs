using BlogAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlogAPI.Infrastructure.Data.Configurations
{
    public class PostConfiguration : IEntityTypeConfiguration<Post>
    {
        public void Configure(EntityTypeBuilder<Post> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Title).IsRequired().HasMaxLength(200);
            builder.Property(p => p.Content).IsRequired();
            
            // Post -> User relationship
            builder.HasOne<User>()
                .WithMany()
                .HasForeignKey(p => p.UserId);

            // INDEXES - YENİ KISIM
            builder.HasIndex(p => p.UserId);                  // "Kullanıcının postları" sorgusu için
            builder.HasIndex(p => p.CreatedAt);             // En yeni postlar sıralama için
            builder.HasIndex(p => p.Title);                   // Post başlığında arama için
            builder.HasIndex(p => new { p.UserId, p.CreatedAt }); // Composite index - kullanıcının son postları
        }
    }
}