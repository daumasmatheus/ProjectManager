namespace ProjectManager.Project.Models
{
    public class ProjectTasks
    {
        public int Id { get; set; }
        public int ProjectId { get; set; }
        public int TaskId { get; set; }

        public Project Project { get; set; }
        public Task Task { get; set; }
    }
}
