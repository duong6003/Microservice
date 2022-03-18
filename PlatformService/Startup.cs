using PlatformService.Data;
using PlatformService.SyncDataServices.Http;

namespace PlatformService
{
    public static class Startup
    {
        public static IServiceCollection AddConfiguration(this IServiceCollection services)
        {
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddHttpClient<ICommandDataClient, HttpCommandDataClient>();
            #region Add app service
            services.AddScoped<IPlatformRepo,PlatformRepo>();
            #endregion
            return services;
        }
    }
}
