using System;
using System.Collections.Generic;
using TODO.Domains;

namespace TODO.Utilities.DTOs
{
    public class TaskDto
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public int CategoryId { get; set; }

        public virtual CategoryDto Category { get; set; }

        public bool IsFinished { get; set; }
        public bool IsImportant { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime EndDate { get; set; }

    }
}
