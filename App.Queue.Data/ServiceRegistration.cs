using App.Queue.Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Shared.Contracts;
using Shared.Library.Extensions;

namespace App.Queue.Data
{
    public class ServiceRegistration : IServiceRegistration
    {
        public void RegisterServices(IServiceCollection services)
        {
            var applicationSettings = services.GetRequiredService<IApplicationSettings>();

            services.AddDbContextPool<AppQueueDbContext>(options =>
            {
                options.UseSqlServer(applicationSettings.DefaultConnectionString);
            });
        }
    }
}
