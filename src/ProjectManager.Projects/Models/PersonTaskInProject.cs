namespace ProjectManager.Project.Models
{
    public class PersonTaskInProject
    {
        public int Id { get; set; }
        public int ProjectTaskId { get; set; }
        public int PersonId { get; set; }

        public ProjectTasks ProjectTasks { get; set; }
        public Person Person { get; set; }
    }
}
