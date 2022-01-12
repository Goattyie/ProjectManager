using ProjectManager.Abstractions.Models;
using ProjectManager.Bll.Models;

namespace ProjectManager.Web.Models
{
    public class ProjectViewModel
    {
        public Guid Id { get; set; }
        public string ProjectName { get; set; }
        public ProjectViewModel(ProjectDTO obj)
        {
            Id = obj.Id;
            ProjectName = obj.ProjectName;
        }
    }
}
