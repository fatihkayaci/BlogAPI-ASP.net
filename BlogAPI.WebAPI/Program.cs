using BlogAPI.Infrastructure.Data;
using BlogAPI.Application.Interfaces;
using BlogAPI.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using BlogAPI.Application.Services;
using FluentValidation;
using BlogAPI.Application.Validators.UserValidators;

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


// burası json gönderilecek veriyi case duyarsızlığı yapıyor
/* 
builder.Services.AddControllers().AddJsonOptions(options =>
{
options.JsonSerializerOptions.PropertyNameCaseInsensitive = false; // ❌ Sıkı mod
});
*/
//auto mapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

// FluentValidation'ı register et
builder.Services.AddValidatorsFromAssemblyContaining<CreateUserValidator>();

var app = builder.Build();
// -------------- for sql test --------------
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<BlogDbContext>();
    var query = context.Posts.Where(p => p.UserId == 5);
    Console.WriteLine("SQL: " + query.ToQueryString());
}
// -------------- for sql test --------------

// Configure pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();

app.Run();