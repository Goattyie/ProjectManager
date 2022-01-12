using ProjectManager.Abstractions.Infrastructure;
using ProjectManager.Abstractions.Repositories;
using ProjectManager.Dal.Repositories;

namespace ProjectManager.Dal
{
    public class SqlRepositoryCollection : IRepositoryCollection
    {
        private readonly SqlContext _db;
        private SqlProjectRepository _projectRepository;
        private SqlTaskRepository _taskRepository;
        private SqlCommentRepository _commentRepository;


        public SqlRepositoryCollection(SqlContext db)
        {
            _db = db;
        }
        public IProjectRepository ProjectRepository { get { if (_projectRepository == null) { _projectRepository = new SqlProjectRepository(_db); } return _projectRepository; } }
        public ITaskRepository TaskRepository { get { if (_projectRepository == null) { _taskRepository = new SqlTaskRepository(_db); } return _taskRepository; } }
        public ICommentRepository CommentRepository { get { if(_commentRepository == null) { _commentRepository = new(_db); } return _commentRepository; } }

        public async ValueTask DisposeAsync()
        {
            await _db.DisposeAsync();
        }

        public async Task Save()
        {
            await _db.SaveChangesAsync();
        }
    }
}
