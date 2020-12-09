using System;
using System.Collections.Generic;

namespace ProjectManager.Project.Models
{
    public class Project
    {
        public int ProjectId { get; set; }
        public int PersonId { get; set; }
        public int StatusId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? ConclusionDate { get; set; }
        public DateTime? CompletedDate { get; set; }
        public DateTime? UpdatedDate  { get; set; }
        public bool InProgress { get; set; }

        public List<Task> Tasks { get; set; }        
    }    
}
