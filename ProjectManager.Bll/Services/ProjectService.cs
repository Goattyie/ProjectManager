using ProjectManager.Abstractions.Infrastructure;
using ProjectManager.Bll.DI;
using ProjectManager.Bll.Interfaces;
using ProjectManager.Bll.Models;
using ProjectManager.Bll.TypeEx;

namespace ProjectManager.Bll.Services
{
    public class ProjectService : IProjectService
    {
        private readonly IRepositoryCollection _db;

        public ProjectService(IRepositoryCollection db)
        {
            _db = db;
        }
        public IEnumerable<ProjectDTO> GetAll()
        {
            var list = _db.ProjectRepository.GetAll();
            return list.AsProjectDTOEnumerable();
        }
    }
}
