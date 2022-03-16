using CommandsService.Data;

namespace CommandsService
{
    public static class Startup
    {
        public static IServiceCollection AddConfiguration(this IServiceCollection services)
        {
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            #region Add app service
            services.AddScoped<ICommandRepo,CommandRepo>();
            #endregion
            return services;
        }
    }
}
