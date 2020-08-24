using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TODO.Domains
{
    public class Task
    {
        public Task()
        {
            IsFinished = false;
            CreatedOn = DateTime.UtcNow;
            Items = new List<Item>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }

        [Required]
        public bool IsFinished { get; set; }

        public DateTime CreatedOn { get; set; }
        [Required]

        public DateTime EndDate { get; set; }

        ICollection<Item> Items { get; set; }
       
    }
}
