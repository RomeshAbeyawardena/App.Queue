using App.Queue.Data;
using App.Queue.Services;
using Shared.Services;
using System;
using System.Reflection;

namespace App.Queue.Broker
{
    public class AppQueueServiceBroker : DefaultServiceBroker
    {
        public override Assembly[] GetAssemblies => new [] { 
            DefaultAssembly, 
            Assembly.GetAssembly(typeof(QueueService)),
            Assembly.GetAssembly(typeof(AppQueueDbContext))};
    }
}
