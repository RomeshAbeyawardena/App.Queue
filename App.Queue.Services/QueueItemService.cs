using App.Queue.Contracts;
using App.Queue.Data;
using App.Queue.Domains;
using App.Queue.Domains.Enumerations;
using Microsoft.EntityFrameworkCore;
using Shared.Contracts;
using Shared.Contracts.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Queue.Services
{
    public class QueueItemService : IQueueItemService
    {
        private readonly IRepository<QueueItem> queueItemRepository;
        private readonly IQueryBuilderFactory _queryBuilderFactory;

        public Task<QueueItem> GetQueueItem(int queueItemId)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<QueueItem>> GetQueueItems(int queueId, QueueItemStatusType? queueItemStatusType = null)
        {
            var queueItemStatusExpression = _queryBuilderFactory
                .GetExpression<QueueItem, QueueItemStatusType>(queueItemStatusType);
            return await queueItemRepository
                .Where(queueItem => queueItem.QueueId == queueId)
                .Where(queueItemStatusExpression)
                .ToArrayAsync();
        }

        public async Task<QueueItem> SaveQueueItem(QueueItem result, bool saveChanges = true)
        {
            return await queueItemRepository.SaveChangesAsync(result, saveChanges);
        }

        public QueueItemService(IRepositoryFactory repositoryFactory, 
            IQueryBuilderFactory queryBuilderFactory)
        {
            queueItemRepository = repositoryFactory.GetRepository<AppQueueDbContext, QueueItem>();
            _queryBuilderFactory = queryBuilderFactory;
        }
    }
}
