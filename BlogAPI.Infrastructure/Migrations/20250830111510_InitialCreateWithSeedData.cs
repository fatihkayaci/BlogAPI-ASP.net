using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BlogAPI.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreateWithSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Username = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    PasswordHash = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    Content = table.Column<string>(type: "text", nullable: false),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Posts_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Content = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    PostId = table.Column<int>(type: "integer", nullable: false),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comments_Posts_PostId",
                        column: x => x.PostId,
                        principalTable: "Posts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Comments_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedAt", "Email", "PasswordHash", "UpdatedAt", "Username" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 1, 1, 12, 0, 0, 0, DateTimeKind.Utc), "admin@blogapi.com", "admin123", new DateTime(2024, 1, 1, 12, 0, 0, 0, DateTimeKind.Utc), "admin" },
                    { 2, new DateTime(2024, 1, 10, 12, 0, 0, 0, DateTimeKind.Utc), "john@example.com", "password123", new DateTime(2024, 1, 10, 12, 0, 0, 0, DateTimeKind.Utc), "johndoe" },
                    { 3, new DateTime(2024, 1, 15, 12, 0, 0, 0, DateTimeKind.Utc), "jane@example.com", "password123", new DateTime(2024, 1, 15, 12, 0, 0, 0, DateTimeKind.Utc), "janedoe" },
                    { 4, new DateTime(2024, 1, 25, 12, 0, 0, 0, DateTimeKind.Utc), "writer@blog.com", "writer123", new DateTime(2024, 1, 25, 12, 0, 0, 0, DateTimeKind.Utc), "blogwriter" }
                });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "Content", "CreatedAt", "Title", "UpdatedAt", "UserId" },
                values: new object[,]
                {
                    { 1, "This is the first post in our blog system. Here you can share your thoughts, ideas, and experiences with the community. We're excited to see what amazing content you'll create!", new DateTime(2024, 1, 10, 12, 0, 0, 0, DateTimeKind.Utc), "Welcome to Our Blog API", new DateTime(2024, 1, 10, 12, 0, 0, 0, DateTimeKind.Utc), 1 },
                    { 2, "ASP.NET Core is a powerful framework for building modern web applications. In this post, I'll share some tips and best practices that I've learned during my development journey.", new DateTime(2024, 1, 10, 12, 0, 0, 0, DateTimeKind.Utc), "Getting Started with ASP.NET Core", new DateTime(2024, 1, 10, 12, 0, 0, 0, DateTimeKind.Utc), 2 },
                    { 3, "Technology is constantly evolving, and web development is no exception. From AI integration to new frameworks, let's explore what the future holds for developers.", new DateTime(2024, 1, 15, 12, 0, 0, 0, DateTimeKind.Utc), "The Future of Web Development", new DateTime(2024, 1, 15, 12, 0, 0, 0, DateTimeKind.Utc), 3 },
                    { 4, "Good database design is crucial for application performance. Here are some key principles: normalization, indexing, and choosing the right data types for your use case.", new DateTime(2024, 1, 25, 12, 0, 0, 0, DateTimeKind.Utc), "Database Design Best Practices", new DateTime(2024, 1, 25, 12, 0, 0, 0, DateTimeKind.Utc), 4 },
                    { 5, "Starting as a beginner can be overwhelming, but with persistence and practice, anyone can become a skilled developer. Here's my story and some advice for newcomers.", new DateTime(2024, 1, 25, 12, 0, 0, 0, DateTimeKind.Utc), "My Coding Journey", new DateTime(2024, 1, 25, 12, 0, 0, 0, DateTimeKind.Utc), 2 }
                });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "Content", "CreatedAt", "PostId", "UpdatedAt", "UserId" },
                values: new object[,]
                {
                    { 1, "Great introduction! Looking forward to more content.", new DateTime(2024, 1, 10, 12, 0, 0, 0, DateTimeKind.Utc), 1, new DateTime(2024, 1, 10, 12, 0, 0, 0, DateTimeKind.Utc), 2 },
                    { 2, "Welcome to the community! This platform looks promising.", new DateTime(2024, 1, 10, 12, 0, 0, 0, DateTimeKind.Utc), 1, new DateTime(2024, 1, 10, 12, 0, 0, 0, DateTimeKind.Utc), 3 },
                    { 3, "ASP.NET Core is indeed powerful. Thanks for sharing your insights!", new DateTime(2024, 1, 10, 12, 0, 0, 0, DateTimeKind.Utc), 2, new DateTime(2024, 1, 10, 12, 0, 0, 0, DateTimeKind.Utc), 1 },
                    { 4, "Very helpful post! Could you write about Entity Framework next?", new DateTime(2024, 1, 10, 12, 0, 0, 0, DateTimeKind.Utc), 2, new DateTime(2024, 1, 10, 12, 0, 0, 0, DateTimeKind.Utc), 4 },
                    { 5, "Interesting perspective on the future of web development.", new DateTime(2024, 1, 15, 12, 0, 0, 0, DateTimeKind.Utc), 3, new DateTime(2024, 1, 15, 12, 0, 0, 0, DateTimeKind.Utc), 2 },
                    { 6, "AI integration is definitely game-changing. Excited to see where this goes!", new DateTime(2024, 1, 15, 12, 0, 0, 0, DateTimeKind.Utc), 3, new DateTime(2024, 1, 15, 12, 0, 0, 0, DateTimeKind.Utc), 4 },
                    { 7, "Database design is often overlooked. Thanks for highlighting its importance!", new DateTime(2024, 1, 25, 12, 0, 0, 0, DateTimeKind.Utc), 4, new DateTime(2024, 1, 25, 12, 0, 0, 0, DateTimeKind.Utc), 3 },
                    { 8, "Could you elaborate more on indexing strategies?", new DateTime(2024, 1, 25, 12, 0, 0, 0, DateTimeKind.Utc), 4, new DateTime(2024, 1, 25, 12, 0, 0, 0, DateTimeKind.Utc), 1 },
                    { 9, "Inspiring story! I'm just starting my coding journey too.", new DateTime(2024, 1, 25, 12, 0, 0, 0, DateTimeKind.Utc), 5, new DateTime(2024, 1, 25, 12, 0, 0, 0, DateTimeKind.Utc), 3 },
                    { 10, "Great advice for beginners. Persistence is key!", new DateTime(2024, 1, 25, 12, 0, 0, 0, DateTimeKind.Utc), 5, new DateTime(2024, 1, 25, 12, 0, 0, 0, DateTimeKind.Utc), 4 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comments_CreatedAt",
                table: "Comments",
                column: "CreatedAt");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_PostId",
                table: "Comments",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_PostId_CreatedAt",
                table: "Comments",
                columns: new[] { "PostId", "CreatedAt" });

            migrationBuilder.CreateIndex(
                name: "IX_Comments_UserId",
                table: "Comments",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_CreatedAt",
                table: "Posts",
                column: "CreatedAt");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_Title",
                table: "Posts",
                column: "Title");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_UserId",
                table: "Posts",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_UserId_CreatedAt",
                table: "Posts",
                columns: new[] { "UserId", "CreatedAt" });

            migrationBuilder.CreateIndex(
                name: "IX_Users_CreatedAt",
                table: "Users",
                column: "CreatedAt");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email",
                table: "Users",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_Username",
                table: "Users",
                column: "Username");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "Posts");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
