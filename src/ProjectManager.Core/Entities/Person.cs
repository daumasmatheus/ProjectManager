using ProjectManager.Core.Extensions;
using System;
using System.Collections.Generic;

namespace ProjectManager.Core.Entities
{
    public class Person
    {
        public Guid PersonId { get; set; }
        public string Role { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsActive { get; set; }

        public ApplicationUser User { get; set; }
        public ICollection<Task> Tasks { get; set; }
        public ICollection<Project> Projects { get; set; }
        public ICollection<Comment> Comments { get; set; }
    }
}
