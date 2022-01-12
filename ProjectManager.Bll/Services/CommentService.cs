using ProjectManager.Abstractions.Infrastructure;
using ProjectManager.Bll.Interfaces;
using ProjectManager.Bll.Models;

namespace ProjectManager.Bll.Services
{
    public class CommentService : ICommentService
    {
        private readonly IRepositoryCollection _db;

        public CommentService(IRepositoryCollection db)
        {
            _db = db;
        }
        public async Task Create(CommentDTO obj)
        {
            await _db.CommentRepository.Create(obj);
        }

        public async Task Delete(Guid id)
        {
            await _db.CommentRepository.Delete(id);
        }

        public IEnumerable<CommentDTO> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
