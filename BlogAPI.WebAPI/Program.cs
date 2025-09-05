using BlogAPI.Infrastructure.Data;
using BlogAPI.Application.Interfaces;
using BlogAPI.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using BlogAPI.Application.Services;
using FluentValidation;
using BlogAPI.Application.Validators.UserValidators;

var builder = WebApplication.CreateBuilder(args);

// Railway DATABASE_URL'yi PostgreSQL connection string'e çevir
string connectionString;
var databaseUrl = Environment.GetEnvironmentVariable("DATABASE_URL");
Console.WriteLine($"DATABASE_URL: {databaseUrl ?? "NULL/BOŞ"}");
if (!string.IsNullOrEmpty(databaseUrl))
{
    // Railway DATABASE_URL format: postgresql://user:password@host:port/database
    // .NET format: Host=host;Port=port;Database=database;Username=user;Password=password
    var uri = new Uri(databaseUrl);
    var userInfo = uri.UserInfo.Split(':');
    
    connectionString = $"Host={uri.Host};Port={uri.Port};Database={uri.AbsolutePath.Trim('/')};Username={userInfo[0]};Password={userInfo[1]};SSL Mode=Require;Trust Server Certificate=true";
}
else
{
    // Local development için appsettings.json'dan al
    connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
}
Console.WriteLine($"connectionString: {connectionString ?? "NULL/BOŞ"}");
// DbContext ekle - Dönüştürülmüş connection string'i kullan
builder.Services.AddDbContext<BlogDbContext>(options =>
    options.UseNpgsql(connectionString));

// Repository'leri ekle
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IPostRepository, PostRepository>();
builder.Services.AddScoped<ICommentRepository, CommentRepository>();

// Serviceleri ekle
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IPostService, PostService>();
builder.Services.AddScoped<ICommentService, CommentService>();

// Controller'ları ekle
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// JSON gönderilecek veriyi case duyarsızlığı yapıyor
/* 
builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.PropertyNameCaseInsensitive = false; // ❌ Sıkı mod
});
*/

// AutoMapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

// FluentValidation'ı register et
builder.Services.AddValidatorsFromAssemblyContaining<CreateUserValidator>();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<BlogDbContext>();
    try
    {
        context.Database.Migrate(); // Otomatik migration
        Console.WriteLine("Database migration başarılı!");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Migration hatası: {ex.Message}");
    }
}
// SQL test kodunu kaldırdık - Railway'de hata veriyordu
// Railway'de database hazır olana kadar bu kodu çalıştırmıyoruz
/*
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<BlogDbContext>();
    var query = context.Posts.Where(p => p.UserId == 5);
    Console.WriteLine("SQL: " + query.ToQueryString());
}
*/

// Configure pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Production'da da Swagger'ı aç (Railway için)
app.UseSwagger();
app.UseSwaggerUI();

// HTTPS redirection'ı kaldırdık - Railway'de sorun çıkarıyor
// app.UseHttpsRedirection();

app.MapControllers();

app.Run();