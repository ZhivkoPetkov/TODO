﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TODO.Domains
{
    public class Task
    {
        public Task()
        {
            IsFinished = false;
            CreatedOn = DateTime.Now;
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

        [Required]
        public bool IsImportant { get; set; }

        public DateTime CreatedOn { get; set; }
        [Required]

        public DateTime EndDate { get; set; }
       
    }
}
