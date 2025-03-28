# Market Project

A .NET 8.0 Web API project with Clean Architecture.

## Project Structure

- `Market.Api`: Web API project
- `Market.Service`: Business logic layer
- `Market.DataAccess`: Data access layer
- `Market.Domain`: Domain models layer

## Prerequisites

- .NET 8.0 SDK
- PostgreSQL Database

## Getting Started

1. Clone the repository
2. Update the connection string in `appsettings.json`
3. Run the following commands:
   ```bash
   dotnet restore
   dotnet build
   dotnet run --project src/Market.Api
   ```

## API Documentation

Once the application is running, you can access the Swagger documentation at:
- https://localhost:7065/swagger
- http://localhost:5138/swagger
