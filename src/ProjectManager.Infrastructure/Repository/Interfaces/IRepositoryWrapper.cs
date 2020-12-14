namespace ProjectManager.Infrastructure.Repository.Interfaces
{
    public interface IRepositoryWrapper
    {
        ITaskRepository taskRepository { get; }
        int Save();
    }
}
