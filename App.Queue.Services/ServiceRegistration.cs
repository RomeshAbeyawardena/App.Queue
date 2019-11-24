using App.Queue.Contracts;
using App.Queue.Domains.Enumerations;
using App.Queue.Services.Providers;
using App.Queue.Services.QueryBuilder;
using App.Queue.Shared;
using Microsoft.Extensions.DependencyInjection;
using Shared.Contracts;
using Shared.Contracts.Builders;

namespace App.Queue.Services
{
    public class ServiceRegistration : IServiceRegistration
    {
        public void RegisterServices(IServiceCollection services)
        {
            services
                .AddSingleton<ICryptographicDataProvider, CryptographicDataProvider>()
                .AddSingleton<IApplicationSettings, DefaultApplicationSettings>()
                .AddSingleton<IQueryBuilder<Domains.QueueItem, QueueItemStatusType>, QueueItemStatusQueryBuilder>()
                .AddScoped<IQueueService, QueueService>()
                .AddScoped<IQueueItemService, QueueItemService>();

        }
    }
}
