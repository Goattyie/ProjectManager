namespace ProjectManager.Abstractions.Models
{
    public interface IComment
    {
        public Guid Id { get; set; }
        public ITask Task { get; set; }
        public byte CommentType { get; set; }
        public byte[] Content { get; set; }
    }
}
