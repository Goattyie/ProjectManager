using Project.Dal.Models;
using ProjectManager.Abstractions.Models;
using ProjectManager.Abstractions.Repositories;

namespace ProjectManager.Dal.Repositories
{
    public class SqlCommentRepository : ICommentRepository
    {
        private readonly SqlContext _db;

        public SqlCommentRepository(SqlContext db)
        {
            _db = db;
        }
        public async Task Create(IComment obj)
        {
            var comment = new TaskCommentEntity(obj);
            await _db.TaskComments.AddAsync(comment);
        }

        public Task Delete(Guid id)
        {
            _db.TaskComments.Remove(new TaskCommentEntity() { Id = id });
            return Task.CompletedTask;
        }

        public IEnumerable<IComment> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
