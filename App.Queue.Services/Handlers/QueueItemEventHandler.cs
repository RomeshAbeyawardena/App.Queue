using App.Queue.Contracts;
using App.Queue.Domains;
using Shared.Contracts;
using Shared.Domains;
using Shared.Services;
using System;
using System.Threading.Tasks;
using Shared.Library.Extensions;
using App.Queue.Domains.Enumerations;

namespace App.Queue.Services.Handlers
{
    public class QueueItemEventHandler : DefaultEventHandler<IEvent<QueueItem>>
    {
        private readonly IQueueItemService queueItemService;
        private ISwitch<string, Func<ICommand, Task<IEvent<QueueItem>>>> _queueItemCommandSwitch;
        public override async Task<IEvent<QueueItem>> Push(IEvent<QueueItem> @event)
        {
            var queueItems = await queueItemService.SaveQueueItem(@event.Result);
            return DefaultEvent.Create(queueItems);
        }

        public override async Task<IEvent<QueueItem>> Send<TCommand>(TCommand command)
        {
            var queueItemcommand = _queueItemCommandSwitch.Case(command.Name);

            if(queueItemcommand == null)
                throw new MethodAccessException();

            return await queueItemcommand(command);
        }

        public QueueItemEventHandler(IQueueItemService queueItemService)
        {
            this.queueItemService = queueItemService;

            _queueItemCommandSwitch = DefaultSwitch
                .Create<string, Func<ICommand, Task<IEvent<QueueItem>>>>()
                .CaseWhen(Constants.GetQueueItems, SendQueueItems);
        }

        private async Task<IEvent<QueueItem>> SendQueueItems(ICommand command)
        {
            if(!command.Parameters.TryGetValue(Constants.QueueId, out var queueIdValue))
                throw new ArgumentNullException(nameof(queueIdValue));

            if(!queueIdValue.TryParse<int>(out var queueId))
                throw new ArgumentException(nameof(queueIdValue));

            QueueItemStatusType? queueItemStatusType = null;

            if(command.Parameters.TryGetValue(Constants.QueueItemStatusType, out var queueItemStatus) &&
               !queueItemStatus.TryParse(out queueItemStatusType))
                throw new ArgumentException(nameof(queueItemStatusType));

            return DefaultEvent.Create(results: await queueItemService.GetQueueItems(queueId.Value, queueItemStatusType));
        }
    }
}
