using ProjectManager.Core.Entities;
using ProjectManager.Infrastructure.Data.DatabaseContext;
using ProjectManager.Infrastructure.Repository.Abstractions;
using ProjectManager.Infrastructure.Repository.Interfaces;

namespace ProjectManager.Infrastructure.Repository.Implementations
{
    public class TaskRepository : RepositoryBase<Task>, ITaskRepository
    {
        public TaskRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext) { }
    }
}
