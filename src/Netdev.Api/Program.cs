using Netdev.Api.Common.Configurations;
using Netdev.Api.Configurations.LayerConfigurations;
using Netdev.Api.Controllers;
using Netdev.Service.Interfaces;
using Netdev.Service.Security;
using Netdev.Service.Services;

// -> Services
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.ConfigureDataAccess();
builder.Services.AddScoped<IDocsService, DocService>();
builder.Services.AddScoped<IInterviewService, InterviewService>();
builder.Services.AddScoped<IAccountService, AccountService>();
builder.Services.AddScoped<IFileService, FileService>();
builder.Services.AddScoped<IAuthManager, AuthManager>();
builder.Services.AddScoped<IUserService, UserService>();

builder.ConfigureAuth();
builder.Services.ConfigureSwaggerAuthorize();

// -> Middlewars
var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();




