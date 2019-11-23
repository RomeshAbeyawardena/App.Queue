using App.Queue.Broker;
using Microsoft.Extensions.DependencyInjection;
using Shared.Library.Extensions;
using Shared.Services;
using System;
using System.Threading.Tasks;

namespace App.Queue.App
{
    internal class Program
    {
        internal static async Task<int> Main(string[] args)
        {
            return await AppHost.CreateBuilder()
                .RegisterServices(RegisterServices)
                .Build<Startup>(serviceProvider: a => a.SubscribeToAllNotifications())
                .RunAsync(async (startup) => await startup.Begin());
        }

        internal static void RegisterServices(IServiceCollection services)
        {
            services
                .RegisterServiceBroker<AppQueueServiceBroker>();
        }
    }
}
