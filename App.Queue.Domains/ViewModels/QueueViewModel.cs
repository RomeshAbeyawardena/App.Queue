using System;
using System.ComponentModel.DataAnnotations;

namespace App.Queue.Domains.ViewModels
{
    public class QueueViewModel
    {
        public int Id { get; set; }
        [Required]
        public Guid UniqueId { get; set; }
        public DateTimeOffset Created { get; set; }
        public DateTimeOffset Modified { get; set; }
    }
}