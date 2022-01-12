using ProjectManager.Abstractions.Models;
using ProjectManager.Bll.Models;
using System.Text;

namespace ProjectManager.Web.Models
{
    public class TaskViewModel : ITask
    {
        public Guid Id { get; set; }
        public TimeSpan SpendTime { get; set; }
        public string TaskName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime CancelDate { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public IProject Project { get; set; }
        public IEnumerable<IComment> TaskCommentsModel { get; set; }
        public string SpendTimeString()
        {
            var hours = new StringBuilder(((SpendTime.Days * 24) + SpendTime.Hours).ToString());
            var minutes = new StringBuilder(SpendTime.Minutes.ToString());
            if (hours.Length == 1)
                hours.Insert(0, '0');
            if (minutes.Length == 1)
                minutes.Insert(0, '0');
            return $"{hours}:{minutes}";
        } 

        public TaskViewModel(TaskDTO obj)
        {
            Id = obj.Id;
            TaskName = obj.TaskName;
            StartDate = obj.StartDate;
            CancelDate = obj.CancelDate;
            CreateDate = obj.CreateDate;
            UpdateDate = obj.UpdateDate;
            Project = obj.Project;
            TaskCommentsModel = obj.TaskCommentsModel;
            SpendTime = CancelDate - StartDate;
        }
    }
}
