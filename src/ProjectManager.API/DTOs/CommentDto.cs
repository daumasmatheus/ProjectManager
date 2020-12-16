using System;

namespace ProjectManager.API.DTOs
{
    public class CommentDto
    {
        public Guid CommentId { get; set; }
        public string Content { get; set; }
        public DateTime CreatedDate { get; set; }

        public PersonDto Person { get; set; }
        public TaskDto Task { get; set; }
    }
}
