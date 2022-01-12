using ProjectManager.Bll.Models;

namespace ProjectManager.Bll.Interfaces
{
    public interface IProjectService
    {
        public IEnumerable<ProjectDTO> GetAll();
    }
}
