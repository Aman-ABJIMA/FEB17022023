using Data;
using DataInterfaces;
#nullable disable
namespace FormatAPI
{
    public static class ServiceExtension
    {
       public static IServiceCollection AddCustomDatabase(this IServiceCollection services,IConfiguration configuration) 
       {
            services.AddScoped<IDatabaseFactory>(sp =>
            {
                return new DatabaseFactory(sp.GetRequiredService<ILogger<IDatabaseFactory>>(), configuration.GetConnectionString("DefaultConnection"));
            });
            return services;
        }
    }
}
