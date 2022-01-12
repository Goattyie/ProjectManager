using ProjectManager.Abstractions.Models;
using ProjectManager.Bll.Models;
using System.Text;
using System.Text.Json.Serialization;

namespace ProjectManager.Web.Models
{
    public class CreateTaskViewModel
    {
        [JsonIgnore]
        public Guid Id { get; set; }
        public string TaskName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public Guid ProjectId { get; set; }

        public TaskDTO AsTaskDTO()
        {
            return new TaskDTO
            {
                Id = Id,
                TaskName = TaskName,
                StartDate = StartDate,
                CancelDate = EndDate,
                Project = new ProjectDTO() { Id = ProjectId },
            };
        }
    }

    public class CreateCommentViewModel
    {
        [JsonIgnore]
        public Guid Id { get; set; }
        public Guid TaskId { get; set; }
        public byte CommentType { get; set; }
        public string Content { get; set; }
        
        public CommentDTO AsCommentDTO()
        {
            return new CommentDTO()
            {
                Id = Id,
                Task = new TaskDTO() { Id=TaskId, },
                CommentType = CommentType,
                Content = Encoding.UTF8.GetBytes(Content)
            };
        }
    }
    public class TaskCommentViewModel
    {
        public CreateTaskViewModel Task { get; set; }
        public CreateCommentViewModel Comment { get; set; }
    }
}
