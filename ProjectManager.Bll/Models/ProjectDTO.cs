using ProjectManager.Abstractions.Models;

namespace ProjectManager.Bll.Models
{
    public class ProjectDTO : IProject
    {
        public Guid Id { get; set; }
        public string ProjectName { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime UpdateTime { get; set; }
        public IEnumerable<ITask> Tasks { get; set; }
        public ProjectDTO() { }
        public ProjectDTO(IProject obj)
        {
            Id = obj.Id;
            ProjectName = obj.ProjectName;
            CreateTime = obj.CreateTime;
            UpdateTime = obj.UpdateTime;
            Tasks = obj.Tasks;
        }
    }
}
