using App.Queue.Contracts;
using Microsoft.Extensions.DependencyInjection;
using Shared.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Queue.Services
{
    public class ServiceRegistration : IServiceRegistration
    {
        public void RegisterServices(IServiceCollection services)
        {
            services
                .AddScoped<IQueueService, QueueService>()
                .AddScoped<IQueueItemService, QueueItemService>();

        }
    }
}
