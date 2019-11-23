using App.Queue.Contracts;
using App.Queue.Domains;
using App.Queue.Domains.Enumerations;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace App.Queue.Services
{
    public class QueueItemService : IQueueItemService
    {
        public Task<QueueItem> GetQueueItem(int queueItemId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<QueueItem>> GetQueueItems(int queueId, QueueItemStatusType? queueItemStatusType = null)
        {
            throw new NotImplementedException();
        }

        public Task<QueueItem> SaveQueueItem(QueueItem result)
        {
            throw new NotImplementedException();
        }
    }
}
