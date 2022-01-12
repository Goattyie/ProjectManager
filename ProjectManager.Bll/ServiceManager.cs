using ProjectManager.Bll.DI;
using ProjectManager.Bll.Interfaces;
using ProjectManager.Dal;

namespace ProjectManager.Bll
{
    public class ServiceManager
    {
        private readonly SqlContext _db;

        public ServiceManager(SqlContext db, ICommentService commentService, ITaskService taskService, IProjectService projectService)
        {
            _db = db;
            CommentService = commentService;
            TaskService = taskService;
            ProjectService = projectService;
        }
        public ICommentService CommentService { get; private set; }
        public ITaskService TaskService { get; private set; }
        public IProjectService ProjectService { get; private set; }
        public async Task Save()
        {
            await _db.SaveChangesAsync();
        }
    }
}
