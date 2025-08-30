using BlogAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BlogAPI.Infrastructure.Data.Seeders
{
    public static class UserSeeder
    {
        public static void SeedUsers(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 1,
                    Username = "admin",
                    Email = "admin@blogapi.com",
                    PasswordHash = "admin123", // Gerçekte hash'lenmeli!
                    CreatedAt = new DateTime(2024, 1, 1, 12, 0, 0, DateTimeKind.Utc),
                    UpdatedAt = new DateTime(2024, 1, 1, 12, 0, 0, DateTimeKind.Utc)
                },
                new User
                {
                    Id = 2,
                    Username = "johndoe",
                    Email = "john@example.com",
                    PasswordHash = "password123",
                    CreatedAt = new DateTime(2024, 1, 10, 12, 0, 0, DateTimeKind.Utc),
                    UpdatedAt = new DateTime(2024, 1, 10, 12, 0, 0, DateTimeKind.Utc)
                },
                new User
                {
                    Id = 3,
                    Username = "janedoe",
                    Email = "jane@example.com",
                    PasswordHash = "password123",
                    CreatedAt = new DateTime(2024, 1, 15, 12, 0, 0, DateTimeKind.Utc),
                    UpdatedAt = new DateTime(2024, 1, 15, 12, 0, 0, DateTimeKind.Utc)
                },
                new User
                {
                    Id = 4,
                    Username = "blogwriter",
                    Email = "writer@blog.com",
                    PasswordHash = "writer123",
                    CreatedAt = new DateTime(2024, 1, 25, 12, 0, 0, DateTimeKind.Utc),
                    UpdatedAt = new DateTime(2024, 1, 25, 12, 0, 0, DateTimeKind.Utc)
                }
            );

        }
    }
}