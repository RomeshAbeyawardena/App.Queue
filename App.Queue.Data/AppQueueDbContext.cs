using Microsoft.EntityFrameworkCore;
using Shared.Services;
using System;

namespace App.Queue.Data
{
    public class AppQueueDbContext : ExtendedDbContext
    {
        public AppQueueDbContext() : base(true)
        {
        }

        public AppQueueDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions, true)
        {
        }
    }
}
