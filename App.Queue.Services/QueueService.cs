﻿using App.Queue.Contracts;
using App.Queue.Data;
using App.Queue.Domains;
using Microsoft.EntityFrameworkCore;
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

        public async Task<Domains.Queue> GetQueue(Guid queueId)
        {
            return await _queueRepository.Where(queue => queue.UniqueId == queueId).SingleOrDefaultAsync();
        }

        public QueueService(IRepositoryFactory repositoryFactory)
        {
            _queueRepository = repositoryFactory.GetRepository<AppQueueDbContext, Domains.Queue>();
        }
    }
}
