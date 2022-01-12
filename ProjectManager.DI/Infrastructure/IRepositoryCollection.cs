using ProjectManager.Abstractions.Repositories;

namespace ProjectManager.Abstractions.Infrastructure
{
    public interface IRepositoryCollection : IAsyncDisposable
    {
        public IProjectRepository ProjectRepository { get; }
        public ITaskRepository TaskRepository { get; }
        public ICommentRepository CommentRepository { get; }
        public Task Save();
    }
}
