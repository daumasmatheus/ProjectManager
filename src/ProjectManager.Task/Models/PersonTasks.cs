using System;

namespace ProjectManager.Task.Models
{
    public class PersonTasks
    {
        public Guid Id { get; set; }
        public int PersonId { get; set; }
        public Guid TaskId { get; set; }

        public Person Person { get; set; }
        public Task Task { get; set; }    
    }
}
