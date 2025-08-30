using BlogAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BlogAPI.Infrastructure.Data.Seeders
{
    public static class PostSeeder
    {
        public static void SeedPosts(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Post>().HasData(
                new Post
                {
                    Id = 1,
                    Title = "Welcome to Our Blog API",
                    Content = "This is the first post in our blog system. Here you can share your thoughts, ideas, and experiences with the community. We're excited to see what amazing content you'll create!",
                    UserId = 1, // Admin
                    CreatedAt = new DateTime(2024, 1, 10, 12, 0, 0, DateTimeKind.Utc),
                    UpdatedAt = new DateTime(2024, 1, 10, 12, 0, 0, DateTimeKind.Utc)
                },
                new Post
                {
                    Id = 2,
                    Title = "Getting Started with ASP.NET Core",
                    Content = "ASP.NET Core is a powerful framework for building modern web applications. In this post, I'll share some tips and best practices that I've learned during my development journey.",
                    UserId = 2, // johndoe
                    CreatedAt = new DateTime(2024, 1, 10, 12, 0, 0, DateTimeKind.Utc),
                    UpdatedAt = new DateTime(2024, 1, 10, 12, 0, 0, DateTimeKind.Utc)
                },
                new Post
                {
                    Id = 3,
                    Title = "The Future of Web Development",
                    Content = "Technology is constantly evolving, and web development is no exception. From AI integration to new frameworks, let's explore what the future holds for developers.",
                    UserId = 3, // janedoe
                    CreatedAt = new DateTime(2024, 1, 15, 12, 0, 0, DateTimeKind.Utc),
                    UpdatedAt = new DateTime(2024, 1, 15, 12, 0, 0, DateTimeKind.Utc)
                },
                new Post
                {
                    Id = 4,
                    Title = "Database Design Best Practices",
                    Content = "Good database design is crucial for application performance. Here are some key principles: normalization, indexing, and choosing the right data types for your use case.",
                    UserId = 4, // blogwriter
                    CreatedAt = new DateTime(2024, 1, 25, 12, 0, 0, DateTimeKind.Utc),
                    UpdatedAt = new DateTime(2024, 1, 25, 12, 0, 0, DateTimeKind.Utc)
                },
                new Post
                {
                    Id = 5,
                    Title = "My Coding Journey",
                    Content = "Starting as a beginner can be overwhelming, but with persistence and practice, anyone can become a skilled developer. Here's my story and some advice for newcomers.",
                    UserId = 2, // johndoe - ikinci postu
                    CreatedAt = new DateTime(2024, 1, 25, 12, 0, 0, DateTimeKind.Utc),
                    UpdatedAt = new DateTime(2024, 1, 25, 12, 0, 0, DateTimeKind.Utc)
                }
            );
        }
    }
}