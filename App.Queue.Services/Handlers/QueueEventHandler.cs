using System;
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

        public QueueEventHandler(IQueueService queueService)
        {
            this.queueService = queueService;

            CommandSwitch.CaseWhen(Constants.GetQueue, GetQueue);
        }

        private async Task<IEvent<Domains.Queue>> GetQueue(ICommand command)
        {
            if(!command.Parameters.TryGetValue(Constants.QueueUniqueId, out var queueIdentifier))
                throw new MethodAccessException();

            if (queueIdentifier is Guid queueIdentifierGuid)
                return DefaultEvent.Create(await queueService.GetQueue(queueIdentifierGuid));

            if(queueIdentifier is int queueIdentifierInt)
                return DefaultEvent.Create(await queueService.GetQueue(queueIdentifierInt));
            
            throw new NotSupportedException();
        }
    }
}
