using ProjectManager.Bll.Models;

namespace ProjectManager.Web.Models
{
    public class TaskPageViewModel
    {
        public TaskViewModel Task { get; set; }
        public IEnumerable<ProjectViewModel> Projects { get; set; }
        public TaskPageViewModel(TaskDTO task, IEnumerable<ProjectDTO> projects)
        {
            Task = new TaskViewModel(task);
            Projects = projects.Select(x => new ProjectViewModel(x));
        }
    }
}
