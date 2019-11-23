using App.Queue.Domains;
using App.Queue.Domains.Enumerations;
using Shared.Contracts;
using Shared.Domains;
using Shared.Services;
using Shared.Services.Builders;
using System.Threading.Tasks;

namespace App.Queue.App
{
    internal class Startup
    {
        private readonly IMediator mediator;

        public async Task<int> Begin()
        {
            await mediator
                .Send<IEvent<Domains.QueueItem>>(DefaultCommand
                .Create<Domains.QueueItem>(Constants.GetQueueItems, DictionaryBuilder
                .Create<string, object>()
                    .Add(Constants.QueueId, 1)
                    .Add(Constants.QueueItemStatusType, QueueItemStatusType.Pending)));

            await mediator
                .Send<IEvent<Domains.Queue>>(DefaultCommand
                    .Create<Domains.Queue>("Get", DictionaryBuilder
                        .Create<string, object>()
                            .Add("QueueId", 1)));

            await mediator.Push(DefaultEvent.Create(new Domains.Queue {
                
                }));


            return await Task.FromResult(1210);
        }

        public Startup(IMediator mediator)
        {
            this.mediator = mediator;
        }
    }
}
