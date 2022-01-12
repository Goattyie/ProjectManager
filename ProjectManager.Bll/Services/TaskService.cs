using ProjectManager.Abstractions.Infrastructure;
using ProjectManager.Abstractions.Models;
using ProjectManager.Bll.DI;
using ProjectManager.Bll.Interfaces;
using ProjectManager.Bll.Models;
using ProjectManager.Bll.TypeEx;
using ProjectManager.Bll.Utils;

namespace ProjectManager.Bll.Services
{
    public class TaskService : ITaskService
    {
        IRepositoryCollection _db;
        public TaskService(IRepositoryCollection db)
        {
            _db = db;
        }

        public async Task Create(TaskDTO task)
        {
            await _db.TaskRepository.Create(task);
        }

        public IEnumerable<TaskDTO> GetAll()
        {
            //ITask к TaskDTO без автомаппера
            var tasks = _db.TaskRepository.GetAll();
            return tasks.AsTaskDTOEnumerable();
        }

        public IEnumerable<TaskDTO> GetAllFiltered(TaskFilter filter)
        {
            var tasks = _db.TaskRepository.GetAllFiltered(filter.Project, filter.Date);
            return tasks.AsTaskDTOEnumerable();
        }

        public async Task<TaskDTO> GetById(Guid id)
        {
            var task = await _db.TaskRepository.GetById(id);
            return new TaskDTO(task);
        }

        public async Task Update(Guid id, TaskDTO obj)
        {
            await _db.TaskRepository.Update(id, obj);
        }
    }
}
