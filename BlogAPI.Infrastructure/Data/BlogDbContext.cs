using System.Reflection;
using BlogAPI.Domain.Entities;
using BlogAPI.Infrastructure.Data.Seeders;
using Microsoft.EntityFrameworkCore;
namespace BlogAPI.Infrastructure.Data
{
    public class BlogDbContext : DbContext
    {
        public BlogDbContext(DbContextOptions<BlogDbContext> options) : base(options)
        {
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Comment> Comments { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            BlogSeeder.SeedAllData(modelBuilder);
        }
    }
}