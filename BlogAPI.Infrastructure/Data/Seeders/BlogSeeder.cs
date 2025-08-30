using Microsoft.EntityFrameworkCore;

namespace BlogAPI.Infrastructure.Data.Seeders
{
    public static class BlogSeeder
    {
        public static void SeedAllData(ModelBuilder modelBuilder)
        {
            UserSeeder.SeedUsers(modelBuilder);
            PostSeeder.SeedPosts(modelBuilder);
            CommentSeeder.SeedComments(modelBuilder);
        }
    }
}