using Project.Dal.Models;
using ProjectManager.Abstractions.Models;
using ProjectManager.Abstractions.Repositories;

namespace ProjectManager.Dal.Repositories
{
    public class SqlProjectRepository : IProjectRepository
    {
        private readonly SqlContext _db;

        public SqlProjectRepository(SqlContext db)
        {
            _db = db;
        }
        public async Task Create(IProject obj)
        {
            var project = new ProjectEntity(obj);
            await _db.Projects.AddAsync(project);
        }

        public Task Delete(Guid id)
        {
            _db.Projects.Remove(new ProjectEntity() { Id = id });
            return Task.CompletedTask;
        }

        public IEnumerable<IProject> GetAll()
        {
            return _db.Projects;
        }

        public async Task<IProject> GetById(Guid id)
        {
            return await _db.Projects.FindAsync(id);
        }
    }
}
