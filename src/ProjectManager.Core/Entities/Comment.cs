using System;

namespace ProjectManager.Core.Entities
{
    public class Comment
    {
        public Guid CommentId { get; set; }
        public string Content { get; set; }
        public DateTime CreatedDate { get; set; }

        public Person Person { get; set; }
        public Task Task { get; set; }
    }
}
