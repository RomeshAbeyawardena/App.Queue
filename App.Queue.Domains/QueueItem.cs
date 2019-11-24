using System;
using System.Collections;
using System.ComponentModel.DataAnnotations;

namespace App.Queue.Domains
{
    public class QueueItem
    {
        [Key]
        public int Id { get; set; }
        public int QueueId { get; set; }
        public byte[] Key { get; set; }
        public byte[] Data { get; set; }
        public DateTimeOffset Created { get; set; }
        public DateTimeOffset Modified { get; set; }
        public DateTimeOffset? Completed { get; set; }
        public DateTimeOffset? LastAttempted { get; set; }

        public virtual Queue Queue { get; set; }
    }
}
