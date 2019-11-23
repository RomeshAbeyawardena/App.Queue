using System.Collections.Generic;
using System.Threading.Tasks;
using App.Queue.Domains;
using App.Queue.Domains.Enumerations;

namespace App.Queue.Contracts
{
    public interface IQueueItemService
    {
        Task<Domains.QueueItem> GetQueueItem(int queueItemId);
        Task<IEnumerable<Domains.QueueItem>> GetQueueItems(int queueId, QueueItemStatusType? queueItemStatusType = null);
        Task<QueueItem> SaveQueueItem(QueueItem result, bool saveChanges = true);
    }
}
