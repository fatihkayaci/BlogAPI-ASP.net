FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

# Copy project files
COPY ["BlogAPI.WebAPI/BlogAPI.WebAPI.csproj", "BlogAPI.WebAPI/"]
COPY ["BlogAPI.Application/BlogAPI.Application.csproj", "BlogAPI.Application/"]
COPY ["BlogAPI.Infrastructure/BlogAPI.Infrastructure.csproj", "BlogAPI.Infrastructure/"]
COPY ["BlogAPI.Domain/BlogAPI.Domain.csproj", "BlogAPI.Domain/"]

# Restore dependencies
RUN dotnet restore "BlogAPI.WebAPI/BlogAPI.WebAPI.csproj"

# Copy source code
COPY . .

# Build
WORKDIR "/src/BlogAPI.WebAPI"
RUN dotnet build "BlogAPI.WebAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "BlogAPI.WebAPI.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

ENTRYPOINT ["dotnet", "BlogAPI.WebAPI.dll"]