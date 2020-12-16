using System;
using System.Collections.Generic;
using System.Linq;

namespace ProjectManager.API.DTOs
{
    public class TaskDto
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

        public PersonDto Person { get; set; }
        public ProjectDto Project { get; set; }        
        public ICollection<CommentDto> Comments { get; set; }
    }
}
