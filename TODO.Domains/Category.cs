﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TODO.Domains
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MinLength(3)]
        public string Name { get; set; }
    }
}
