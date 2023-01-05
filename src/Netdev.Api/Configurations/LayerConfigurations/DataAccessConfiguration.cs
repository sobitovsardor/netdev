namespace Netdev.Api.Configurations.LayerConfigurations
{
    public class DataAccessConfiguration
    {
        public static void ConfigureDataAccess(this WebApplicationBuilder builder)
        {
            string connectionString = builder.Configuration.GetConnectionString("DatabaseConnection");
            //builder.Services.AddDbContext<AppDbContext>(options => options.UseNpgsql(connectionString));
            //builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}
