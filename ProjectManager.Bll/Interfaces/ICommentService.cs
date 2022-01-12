using ProjectManager.Abstractions.Models;
using ProjectManager.Bll.Models;

namespace ProjectManager.Bll.Interfaces
{
    public interface ICommentService
    {
        public IEnumerable<CommentDTO> GetAll();
        public Task Create(CommentDTO obj);
        public Task Delete(Guid id);
    }
}
