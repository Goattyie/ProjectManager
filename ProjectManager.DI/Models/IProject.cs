namespace ProjectManager.Abstractions.Models
{
    public interface IProject
    {
        public Guid Id { get; set; }
        public string ProjectName { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime UpdateTime { get; set; }
        public IEnumerable<ITask> Tasks { get; set; }
    }
}
