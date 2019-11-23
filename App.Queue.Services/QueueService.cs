using App.Queue.Contracts;
using App.Queue.Domains;
using System;
using System.Threading.Tasks;

namespace App.Queue.Services
{
    public class QueueService : IQueueService
    {
        public Task<Domains.Queue> GetQueue(int queueId)
        {
            throw new NotImplementedException();
        }

        public Task<Domains.Queue> SaveQueue(Domains.Queue queue, bool saveChanges = true)
        {
            throw new NotImplementedException();
        }
    }
}
