namespace ProjectManager.Core.Entities
{
    public class Priority
    {
        public int PriorityId { get; set; }
        public string Name { get; set; }

        public Task Task { get; set; }
    }
}
