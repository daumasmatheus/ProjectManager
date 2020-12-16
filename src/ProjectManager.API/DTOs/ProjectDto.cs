using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjectManager.API.DTOs
{
    public class ProjectDto
    {
        public Guid ProjectId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ConclusionDate { get; set; }
        public DateTime? ConcludedDate { get; set; }

        public List<Task> Tasks { get; set; }
        public PersonDto Author { get; set; }
    }
}
