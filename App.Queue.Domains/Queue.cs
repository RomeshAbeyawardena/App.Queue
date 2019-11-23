using System.ComponentModel.DataAnnotations;

namespace App.Queue.Domains
{
    public class Queue
    {
        [Key]
        public int Id { get; set; }
    }
}
