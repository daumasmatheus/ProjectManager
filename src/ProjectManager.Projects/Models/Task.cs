using System;

namespace ProjectManager.Project.Models
{
    public class Task
    {
        public Guid TaskId { get; set; }
        public int StatusId { get; set; }
        public int PriorityId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public DateTime? ConclusionDate { get; set; }
        public DateTime? CompletedDate { get; set; }
    }
}
