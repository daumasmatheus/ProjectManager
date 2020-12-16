using System;
using System.Collections.Generic;

namespace ProjectManager.API.DTOs
{
    public class PersonDto
    {
        public Guid PersonId { get; set; }
        public string Role { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsActive { get; set; }

        public ICollection<TaskDto> Tasks { get; set; }
        public ICollection<ProjectDto> Projects { get; set; }
        public ICollection<CommentDto> Comments { get; set; }
    }
}
