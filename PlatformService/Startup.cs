using PlatformService.Data;
namespace PlatformService
{
    public static class Startup
    {
        public static IServiceCollection AddConfiguration(this IServiceCollection services)
        {
            services.AddDbContext<AppDbContext>();
            return services;
        }
    }
}
