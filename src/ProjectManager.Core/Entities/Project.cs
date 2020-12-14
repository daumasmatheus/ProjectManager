using System;
using System.Collections.Generic;

namespace ProjectManager.Core.Entities
{
    public class Project
    {
        public Guid ProjectId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ConclusionDate { get; set; }
        public DateTime? ConcludedDate { get; set; }

        public List<Task> Tasks { get; set; }
        public Person Author { get; set; }
    }
}
