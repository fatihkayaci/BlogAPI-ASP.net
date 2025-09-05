# 📝 Blog API - Clean Architecture

[![.NET](https://img.shields.io/badge/.NET-9.0-purple.svg)](https://dotnet.microsoft.com/)
[![PostgreSQL](https://img.shields.io/badge/PostgreSQL-13+-blue.svg)](https://www.postgresql.org/)
[![Railway](https://img.shields.io/badge/Deployed%20on-Railway-success.svg)](https://railway.app/)
[![License](https://img.shields.io/badge/License-MIT-green.svg)](LICENSE)

A **RESTful Blog API** built with **.NET 9** following **Clean Architecture** principles. This project demonstrates modern backend development practices including Repository Pattern, Dependency Injection, and cloud deployment.

## 🚀 Live Demo

- **🌐 API Base URL:** https://blogapi-aspnet-production.up.railway.app
- **📚 Swagger Documentation:** https://blogapi-aspnet-production.up.railway.app/swagger

## ✨ Features

- ✅ **Clean Architecture** - Separation of concerns with layered design
- ✅ **Repository Pattern** - Data access abstraction
- ✅ **CRUD Operations** - Users, Posts, Comments management
- ✅ **Entity Framework Core** - ORM with PostgreSQL
- ✅ **FluentValidation** - Input validation
- ✅ **AutoMapper** - Object-to-object mapping
- ✅ **Swagger/OpenAPI** - Interactive API documentation
- ✅ **Cloud Deployment** - Deployed on Railway with CI/CD

## 🏗️ Architecture

```
📁 BlogAPI.Domain/          # Entities, Interfaces
📁 BlogAPI.Application/     # DTOs, Services, Validators
📁 BlogAPI.Infrastructure/  # Repositories, DbContext
📁 BlogAPI.WebAPI/         # Controllers, Program.cs
```

## 🛠️ Tech Stack

- **Backend:** .NET 9, ASP.NET Core
- **Database:** PostgreSQL
- **ORM:** Entity Framework Core
- **Validation:** FluentValidation
- **Mapping:** AutoMapper
- **Documentation:** Swagger/OpenAPI
- **Deployment:** Railway
- **Architecture:** Clean Architecture, Repository Pattern

## 📋 API Endpoints

### Users
- `GET /api/user` - Get all users
- `GET /api/user/{id}` - Get user by ID
- `POST /api/user` - Create new user
- `PUT /api/user/{id}` - Update user
- `DELETE /api/user/{id}` - Delete user

### Posts
- `GET /api/post` - Get all posts
- `GET /api/post/{id}` - Get post by ID
- `POST /api/post` - Create new post
- `PUT /api/post/{id}` - Update post
- `DELETE /api/post/{id}` - Delete post

### Comments
- `GET /api/comment` - Get all comments
- `GET /api/comment/{id}` - Get comment by ID
- `POST /api/comment` - Create new comment
- `PUT /api/comment/{id}` - Update comment
- `DELETE /api/comment/{id}` - Delete comment

## 🚦 Getting Started

### Prerequisites
- .NET 9 SDK
- PostgreSQL (or use Docker)
- Git

### Installation

1. **Clone the repository**
   ```bash
   git clone https://github.com/fatihkayaci/BlogAPI-ASP.net
   cd blog-api
   ```

2. **Set up Database**
   ```bash
   # Update connection string in appsettings.json
   # Run migrations
   dotnet ef database update --startup-project BlogAPI.WebAPI --project BlogAPI.Infrastructure
   ```

3. **Run the application**
   ```bash
   cd BlogAPI.WebAPI
   dotnet run
   ```

4. **Visit Swagger UI**
   ```
   https://localhost:5001/swagger
   ```

## 🔧 Configuration

Update `appsettings.json` with your database connection:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Host=localhost;Database=blogapi;Username=postgres;Password=yourpassword"
  }
}
```

## 🚀 Deployment

This project is configured for Railway deployment:

1. **Environment Variables** - Railway PostgreSQL integration
2. **Automatic Migrations** - Database setup on deployment
3. **CI/CD Pipeline** - Automatic deployment on push

## 🤝 Contributing

Feel free to use this project as a learning resource or boilerplate! Contributions, issues, and feature requests are welcome.

1. Fork the project
2. Create your feature branch (`git checkout -b feature/AmazingFeature`)
3. Commit your changes (`git commit -m 'Add some AmazingFeature'`)
4. Push to the branch (`git push origin feature/AmazingFeature`)
5. Open a Pull Request

## 🎯 Roadmap

- [ ] JWT Authentication & Authorization
- [ ] Pagination & Filtering
- [ ] Search functionality
- [ ] File upload for post images
- [ ] Email notifications
- [ ] Unit & Integration Tests
- [ ] Docker containerization
- [ ] API versioning

## 👨‍💻 Author

**Fatih KAYACI**
- Email: info@fatihkayaci.com
- LinkedIn: [fatihkayacı](https://linkedin.com/in/fatihkayaci)
- GitHub: [fatihkayacı](https://github.com/fatihkayaci)

## 📄 License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

## ⭐ Show your support

Give a ⭐️ if this project helped you learn something new!

---

**Built with ❤️ using Clean Architecture principles**