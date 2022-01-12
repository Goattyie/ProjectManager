using ProjectManager.Bll.Models;

namespace ProjectManager.Web.Models
{
    public class TaskTablePageViewModel
    {
        public TimeSpan SpendTime { get; set; }
        public IEnumerable<TaskViewModel> Tasks { get; set;}
        public IEnumerable<ProjectViewModel> Projects { get; set;}
        public TaskTablePageViewModel(IEnumerable<TaskDTO> tasks, IEnumerable<ProjectDTO> projects)
        {
            Tasks = tasks.Select(x => new TaskViewModel(x));
            Projects = projects.Select(x => new ProjectViewModel(x));
            foreach(var task in Tasks)
            {
                SpendTime += task.SpendTime;
            }
        }
    }
}
