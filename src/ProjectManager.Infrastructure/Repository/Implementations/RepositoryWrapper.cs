using ProjectManager.Infrastructure.Data.DatabaseContext;
using ProjectManager.Infrastructure.Repository.Interfaces;

namespace ProjectManager.Infrastructure.Repository.Implementations
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private ApplicationDbContext applicationDbContext;
        public RepositoryWrapper(ApplicationDbContext _applicationDbContext)
        {
            applicationDbContext = _applicationDbContext;
        }

        private ITaskRepository _taskRepository;
        public ITaskRepository taskRepository
        {
            get
            {
                if (_taskRepository == null) _taskRepository = new TaskRepository(applicationDbContext);
                return _taskRepository;
            }
        }        

        public bool Save() => applicationDbContext.SaveChanges() > 0;
    }
}
