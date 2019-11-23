using System.Threading.Tasks;

namespace App.Queue.Contracts
{
    public interface IQueueService
    {
        Task<Domains.Queue> GetQueue(int queueId);
        Task<Domains.Queue> SaveQueue(Domains.Queue queue, bool saveChanges = true);
    }
}
