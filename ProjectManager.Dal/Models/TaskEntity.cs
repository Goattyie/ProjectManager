using ProjectManager.Abstractions.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project.Dal.Models
{
    public class TaskEntity : ITask
    {
        public Guid Id { get; set; }
        public string TaskName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime CancelDate { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public Guid ProjectId { get; set; }
        [ForeignKey(nameof(ProjectId))]
        public virtual ProjectEntity ProjectModel { get; set; }
        public IEnumerable<TaskCommentEntity> TaskComments { get; set; }
        [NotMapped]
        public IProject Project { 
            get { return ProjectModel; } set { ProjectModel = new ProjectEntity(value); } }
        //[NotMapped]
        IEnumerable<IComment> ITask.TaskCommentsModel { get => TaskComments; 
            set { TaskComments = value as IEnumerable<TaskCommentEntity>; } }

        public TaskEntity() { }
        public TaskEntity(ITask obj)
        {
            Id = obj.Id;
            TaskName = obj.TaskName;
            StartDate = obj.StartDate;
            CancelDate = obj.CancelDate;
            CreateDate = StartDate;
            UpdateDate = StartDate;
            ProjectId = obj.Project.Id; 
        }
    }
}
