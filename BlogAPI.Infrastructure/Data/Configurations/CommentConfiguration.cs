using BlogAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlogAPI.Infrastructure.Data.Configurations
{
    public class CommentConfiguration : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Content).IsRequired().HasMaxLength(500);
            
            // Comment -> Post relationship
            builder.HasOne<Post>()
                .WithMany()
                .HasForeignKey(c => c.PostId);
                
            // Comment -> User relationship  
            builder.HasOne<User>()
                .WithMany()
                .HasForeignKey(c => c.UserId);

            // INDEXES - YENİ KISIM
            builder.HasIndex(c => c.PostId);
            builder.HasIndex(c => c.UserId);
            builder.HasIndex(c => c.CreatedAt);
            builder.HasIndex(c => new { c.PostId, c.CreatedAt });
        }
    }
}