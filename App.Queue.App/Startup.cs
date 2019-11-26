using App.Queue.Contracts;
using App.Queue.Domains;
using App.Queue.Domains.Enumerations;
using Shared.Contracts;
using Shared.Contracts.Services;
using Shared.Services;
using System;
using System.Threading.Tasks;
using Shared.Services.Extensions;
namespace App.Queue.App
{
    internal class Startup
    {
        private readonly IMediator mediator;
        private readonly IEncryptionService encryptionService;
        private readonly ICryptographicDataProvider cryptographicDataProvider;

        public async Task<int> Begin()
        {
            
            //var newQueueEvent = await mediator
            //    .Push(DefaultEvent.Create(new Domains.Queue {

            //    }));

            //var key = encryptionService.GenerateIv(SymmetricAlgorithmType.Aes);
            //var cryptoData = cryptographicDataProvider.GetCryptographicData(key);
            //var data = await encryptionService
            //    .EncryptString(SymmetricAlgorithmType.Aes,"You're a bad boy", cryptographicDataProvider.GeneratePasswordDerivedKey(cryptoData), key);

            //var newQueueItem = await mediator
            //    .Push(DefaultEvent.Create(new Domains.QueueItem
            //    {
            //        QueueId = newQueueEvent.Result.Id,
            //        Key = key,
            //        Data = data
            //    })); ;
            

            var queueEventResult = await mediator
                .Send<Domains.Queue>(Constants.GetQueue, dictionaryBuilder =>
                            dictionaryBuilder.Add(Constants.QueueUniqueId, new Guid("A1F0DE0C-9F5F-4A6D-B543-FE17D0591795")));

            var queueItemEventResult = await mediator
                .Send<QueueItem>(Constants.GetQueueItems, dictionaryBuilder =>
                            dictionaryBuilder
                                .Add(Constants.QueueId, queueEventResult.Result.Id)
                                .Add(Constants.QueueItemStatusType, QueueItemStatusType.Pending));

            return await Task.FromResult(1210);
        }

        public Startup(IMediator mediator, IEncryptionService encryptionService, ICryptographicDataProvider cryptographicDataProvider)
        {
            this.mediator = mediator;
            this.encryptionService = encryptionService;
            this.cryptographicDataProvider = cryptographicDataProvider;
        }
    }
}
