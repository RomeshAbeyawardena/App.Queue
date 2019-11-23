using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using App.Queue.Contracts;
using App.Queue.Domains;
using Shared.Contracts;
using Shared.Domains;
using Shared.Library;
using Shared.Library.Exceptions;
using Shared.Services;

namespace App.Queue.Services.Handlers
{
    public class QueueEventHandler : DefaultEventHandler<IEvent<Domains.Queue>>
    {
        private readonly IQueueService queueService;

        public override async Task<IEvent<Domains.Queue>> Push(IEvent<Domains.Queue> @event)
        {
            return await ExceptionHandler.TryAsync(async () =>
            {
                if (!@event.IsSuccessful)
                    throw new EventException(@event, "Save unsuccessful", @event.Exception);

                var queue = await queueService.SaveQueue(@event.Result);

                return DefaultEvent.Create(queue);
            }, ex => { });

        }

        public override async Task<IEvent<Domains.Queue>> Send<TCommand>(TCommand command)
        {
            return await ExceptionHandler.TryAsync(async () =>
            {
                var commandArg = command.Parameters.TryGetValue("QueueId", out var arg);

                return DefaultEvent.Create(await queueService.GetQueue(Convert.ToInt32(arg)));
            }, ex => { });
        }

        public QueueEventHandler(IQueueService queueService)
        {
            this.queueService = queueService;
        }
    }
}
