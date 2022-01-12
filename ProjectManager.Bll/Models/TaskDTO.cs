using ProjectManager.Abstractions.Models;

namespace ProjectManager.Bll.Models
{
    public class TaskDTO : ITask
    {
        public Guid Id { get; set; }
        public string TaskName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime CancelDate { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public IProject Project { get; set; }
        public IEnumerable<IComment> TaskCommentsModel { get; set; }
        public TaskDTO() { }
        public TaskDTO(ITask obj)
        {
            Id = obj.Id;
            TaskName = obj.TaskName;
            StartDate = obj.StartDate;
            CancelDate = obj.CancelDate;
            CreateDate = obj.CreateDate;
            UpdateDate = obj.UpdateDate;
            Project = obj.Project;
            TaskCommentsModel = obj.TaskCommentsModel;
        }
    }
}
