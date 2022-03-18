using CommandsService.AsyncDataServices;
using CommandsService.Data;
using CommandsService.EventProcessing;

namespace CommandsService
{
    public static class Startup
    {
        public static IServiceCollection AddConfiguration(this IServiceCollection services)
        {
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddHostedService<MessageBusSubsriber>();
            #region Add app service
            services.AddScoped<ICommandRepo,CommandRepo>();
            services.AddSingleton<IEventProcessor,EventProcessor>();
            #endregion
            return services;
        }
    }
}
