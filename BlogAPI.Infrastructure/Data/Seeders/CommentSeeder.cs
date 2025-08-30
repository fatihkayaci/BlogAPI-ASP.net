using BlogAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BlogAPI.Infrastructure.Data.Seeders
{
    public static class CommentSeeder
    {
        public static void SeedComments(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Comment>().HasData(
                // Post 1 yorumları
                new Comment
                {
                    Id = 1,
                    Content = "Great introduction! Looking forward to more content.",
                    UserId = 2, // johndoe
                    PostId = 1,
                    CreatedAt = new DateTime(2024, 1, 10, 12, 0, 0, DateTimeKind.Utc),
                    UpdatedAt = new DateTime(2024, 1, 10, 12, 0, 0, DateTimeKind.Utc)
                },
                new Comment
                {
                    Id = 2,
                    Content = "Welcome to the community! This platform looks promising.",
                    UserId = 3, // janedoe
                    PostId = 1,
                    CreatedAt = new DateTime(2024, 1, 10, 12, 0, 0, DateTimeKind.Utc),
                    UpdatedAt = new DateTime(2024, 1, 10, 12, 0, 0, DateTimeKind.Utc)
                },
                
                // Post 2 yorumları
                new Comment
                {
                    Id = 3,
                    Content = "ASP.NET Core is indeed powerful. Thanks for sharing your insights!",
                    UserId = 1, // admin
                    PostId = 2,
                    CreatedAt = new DateTime(2024, 1, 10, 12, 0, 0, DateTimeKind.Utc),
                    UpdatedAt = new DateTime(2024, 1, 10, 12, 0, 0, DateTimeKind.Utc)
                },
                new Comment
                {
                    Id = 4,
                    Content = "Very helpful post! Could you write about Entity Framework next?",
                    UserId = 4, // blogwriter
                    PostId = 2,
                    CreatedAt = new DateTime(2024, 1, 10, 12, 0, 0, DateTimeKind.Utc),
                    UpdatedAt = new DateTime(2024, 1, 10, 12, 0, 0, DateTimeKind.Utc)
                },
                
                // Post 3 yorumları  
                new Comment
                {
                    Id = 5,
                    Content = "Interesting perspective on the future of web development.",
                    UserId = 2, // johndoe
                    PostId = 3,
                    CreatedAt = new DateTime(2024, 1, 15, 12, 0, 0, DateTimeKind.Utc),
                    UpdatedAt = new DateTime(2024, 1, 15, 12, 0, 0, DateTimeKind.Utc)
                },
                new Comment
                {
                    Id = 6,
                    Content = "AI integration is definitely game-changing. Excited to see where this goes!",
                    UserId = 4, // blogwriter
                    PostId = 3,
                    CreatedAt = new DateTime(2024, 1, 15, 12, 0, 0, DateTimeKind.Utc),
                    UpdatedAt = new DateTime(2024, 1, 15, 12, 0, 0, DateTimeKind.Utc)
                },
                
                // Post 4 yorumları
                new Comment
                {
                    Id = 7,
                    Content = "Database design is often overlooked. Thanks for highlighting its importance!",
                    UserId = 3, // janedoe
                    PostId = 4,
                    CreatedAt = new DateTime(2024, 1, 25, 12, 0, 0, DateTimeKind.Utc),
                    UpdatedAt = new DateTime(2024, 1, 25, 12, 0, 0, DateTimeKind.Utc)
                },
                new Comment
                {
                    Id = 8,
                    Content = "Could you elaborate more on indexing strategies?",
                    UserId = 1, // admin
                    PostId = 4,
                    CreatedAt = new DateTime(2024, 1, 25, 12, 0, 0, DateTimeKind.Utc),
                    UpdatedAt = new DateTime(2024, 1, 25, 12, 0, 0, DateTimeKind.Utc)
                },
                
                // Post 5 yorumları
                new Comment
                {
                    Id = 9,
                    Content = "Inspiring story! I'm just starting my coding journey too.",
                    UserId = 3, // janedoe
                    PostId = 5,
                    CreatedAt = new DateTime(2024, 1, 25, 12, 0, 0, DateTimeKind.Utc),
                    UpdatedAt = new DateTime(2024, 1, 25, 12, 0, 0, DateTimeKind.Utc)
                },
                new Comment
                {
                    Id = 10,
                    Content = "Great advice for beginners. Persistence is key!",
                    UserId = 4, // blogwriter
                    PostId = 5,
                    CreatedAt = new DateTime(2024, 1, 25, 12, 0, 0, DateTimeKind.Utc),
                    UpdatedAt = new DateTime(2024, 1, 25, 12, 0, 0, DateTimeKind.Utc)
                }
            );
        }
    }
}