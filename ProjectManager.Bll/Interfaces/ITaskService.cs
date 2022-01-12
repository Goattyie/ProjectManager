using ProjectManager.Abstractions.Models;
using ProjectManager.Bll.Models;
using ProjectManager.Bll.Utils;

namespace ProjectManager.Bll.Interfaces
{
    public interface ITaskService
    {
        public Task Update(Guid id, TaskDTO obj);
        public Task Create(TaskDTO obj);
        public IEnumerable<TaskDTO> GetAll();
        public IEnumerable<TaskDTO> GetAllFiltered(TaskFilter filter);

        public Task<TaskDTO> GetById(Guid id);
    }
}
