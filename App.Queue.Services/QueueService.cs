using App.Queue.Contracts;
using App.Queue.Data;
using App.Queue.Domains;
using Shared.Contracts;
using Shared.Contracts.Factories;
using System;
using System.Threading.Tasks;

namespace App.Queue.Services
{
    public class QueueService : IQueueService
    {
        private readonly IRepository<Domains.Queue> _queueRepository;

        public async Task<Domains.Queue> GetQueue(int queueId)
        {
            return await _queueRepository.FindAsync(queueId);
        }

        public async Task<Domains.Queue> SaveQueue(Domains.Queue queue, bool saveChanges = true)
        {
            return await _queueRepository.SaveChangesAsync(queue, saveChanges);
        }

        public Task<Domains.Queue> GetQueue(Guid queueId)
        {
            throw new NotImplementedException();
        }

        public QueueService(IRepositoryFactory repositoryFactory)
        {
            _queueRepository = repositoryFactory.GetRepository<AppQueueDbContext, Domains.Queue>();
        }
    }
}
