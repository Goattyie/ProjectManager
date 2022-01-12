using ProjectManager.Abstractions.Models;
using System.ComponentModel.DataAnnotations;

namespace Project.Dal.Models
{
    public class ProjectEntity : IProject
    {
        public Guid Id { get; set; }
        public string ProjectName { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime UpdateTime { get; set; }
        public virtual ICollection<TaskEntity> Tasks { get; set; }
        IEnumerable<ITask> IProject.Tasks { get => Tasks; set => Tasks = value as ICollection<TaskEntity>; }

        public ProjectEntity() { }
        public ProjectEntity(IProject obj)
        {
            Id = obj.Id;
            ProjectName = obj.ProjectName;
            CreateTime = obj.CreateTime;
            UpdateTime = obj.UpdateTime;
        }
    }
}
