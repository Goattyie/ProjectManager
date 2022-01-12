using ProjectManager.Abstractions.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project.Dal.Models
{
    public class TaskCommentEntity : IComment
    {
        public Guid Id { get; set; }
        public Guid TaskId { get; set; }
        public byte CommentType { get; set; }
        public byte[] Content { get; set; }
        [ForeignKey(nameof(TaskId))]
        public TaskEntity TaskModel { get; set; }
        [NotMapped]
        ITask IComment.Task { get => TaskModel; set { TaskModel = new TaskEntity(value); } }

        public TaskCommentEntity() { }
        public TaskCommentEntity(IComment obj)
        {
            Id = obj.Id;
            TaskId = obj.Task.Id;
            CommentType = obj.CommentType;
            Content = obj.Content;
        }
    }
}
