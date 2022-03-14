using PlatformService.Data;
namespace PlatformService
{
    public static class Startup
    {
        public static IServiceCollection AddConfiguration(this IServiceCollection services)
        {
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            #region Add app service
            services.AddScoped<IPlatformRepo,PlatformRepo>();
            #endregion
            return services;
        }
    }
}
