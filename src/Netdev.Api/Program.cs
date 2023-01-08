using Netdev.Api.Configurations.LayerConfigurations;
using Netdev.Service.Interfaces;
using Netdev.Service.Services;

// -> Services
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.ConfigureDataAccess();
builder.Services.AddScoped<IDocsService, DocService>();

// -> Middlewars
var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();




