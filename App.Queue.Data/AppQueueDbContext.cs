using Microsoft.EntityFrameworkCore;
using Shared.Services;

namespace App.Queue.Data
{
    public class AppQueueDbContext : ExtendedDbContext
    {
        public AppQueueDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions, true)
        {
        }

        public DbSet<Domains.Queue> Queues { get; set; }
        public DbSet<Domains.QueueItem> QueueItems { get; set; }
    }
}
