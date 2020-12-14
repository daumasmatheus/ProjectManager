using ProjectManager.Core.Entities.Enums;
using System;
using System.Collections.Generic;

namespace ProjectManager.Core.Entities
{
    public class Task
    {
        public Guid TaskId { get; set; }
        public Guid? ProjectId { get; set; }
        public int StatusId { get; set; }
        public int PriorityId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public DateTime? ConclusionDate { get; set; }
        public DateTime? ConcludedDate { get; set; }

        public Person Person { get; set; }
        public Project Project { get; set; }
        public Status Status { get; set; }
        public Priority Priority { get; set; }
        public ICollection<Comment> Comments { get; set; }
    }
}
