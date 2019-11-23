using App.Queue.Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Shared.Contracts;
using Shared.Services.Extensions;

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
                .RegisterDefaultEntityProvider<Domains.Queue>()
                .RegisterDefaultEntityProvider<Domains.QueueItem>();
        }
    }
}
