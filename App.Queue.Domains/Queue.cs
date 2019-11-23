using System;
using System.ComponentModel.DataAnnotations;

namespace App.Queue.Domains
{
    public class Queue
    {
        [Key]
        public int Id { get; set; }
        public Guid UniqueId { get; set; }
        public DateTimeOffset Created { get; set; }
        public DateTimeOffset Modified { get; set; }
    }
}
