using ProjectManager.Abstractions.Models;

namespace ProjectManager.Bll.Models
{
    public class CommentDTO : IComment
    {
        public Guid Id { get; set; }
        public ITask Task { get; set; }
        public byte CommentType { get; set; }
        public byte[] Content { get; set; }
    }
}
