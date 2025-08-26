using BlogAPI.Infrastructure.Data;
using BlogAPI.Application.Interfaces;
using BlogAPI.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using BlogAPI.Application.Services;
using BlogAPI.Application.Mapping;

var builder = WebApplication.CreateBuilder(args);

// DbContext ekle - Connection string'i appsettings.json'dan al
builder.Services.AddDbContext<BlogDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// Repository'leri ekle
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IPostRepository, PostRepository>();
builder.Services.AddScoped<ICommentRepository, CommentRepository>();

//serviceler ekle
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IPostService, PostService>();
builder.Services.AddScoped<ICommentService, CommentService>();

// Controller'ları ekle
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(typeof(UserProfile), typeof(PostProfile), typeof(CommentProfile));
var app = builder.Build();

// Configure pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();

app.Run();