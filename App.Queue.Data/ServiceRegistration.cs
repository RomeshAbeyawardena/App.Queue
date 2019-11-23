using App.Queue.Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Shared.Contracts;
using Shared.Contracts.Providers;
using Shared.Services.Extensions;
using System;

namespace App.Queue.Data
{
    public class ServiceRegistration : IServiceRegistration
    {
        public void RegisterServices(IServiceCollection services)
        {
            services
                .AddDbContextPool<AppQueueDbContext>((serviceProvider, options) =>
                {
                    var applicationSettings = serviceProvider
                        .GetService<IApplicationSettings>();
                    options
                        .UseSqlServer(applicationSettings.DefaultConnectionString);
                })
                .RegisterDefaultEntityProvider<Domains.Queue>(queueOptions => {
                    queueOptions
                    .AddDefaults(EntityState.Added, (serviceProvider, queue) => {
                        var clockProvider = GetClockProvider(serviceProvider);
                        queue.UniqueId = Guid.NewGuid();
                        queue.Created = clockProvider.Now;
                        queue.Modified = clockProvider.Now;
                    })
                    .AddDefaults(EntityState.Modified, (serviceProvider, queue) => {
                        var clockProvider = GetClockProvider(serviceProvider);
                        queue.Modified = clockProvider.Now;
                    });
                })
                .RegisterDefaultEntityProvider<Domains.QueueItem>(queueItemOptions => {
                    queueItemOptions
                    .AddDefaults(EntityState.Added, (serviceProvider, queueItem) => {
                        var clockProvider = GetClockProvider(serviceProvider);
                        queueItem.Created = clockProvider.Now;
                        queueItem.Modified = clockProvider.Now;
                    })
                    .AddDefaults(EntityState.Modified, (serviceProvider, queueItem) => {
                        var clockProvider = GetClockProvider(serviceProvider);
                        queueItem.Modified = clockProvider.Now;
                    });
                })
                .RegisterDefaultEntityProvider<Domains.QueueItem>();
        }

        private static IClockProvider GetClockProvider(IServiceProvider serviceProvider)
        {
            return serviceProvider.GetRequiredService<IClockProvider>();
        }
    }
}
