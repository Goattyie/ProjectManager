using Microsoft.AspNetCore.Mvc;
using ProjectManager.Bll;
using ProjectManager.Web.Models;

namespace ProjectManager.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly ServiceManager _manager;

        public CommentController(ServiceManager manager)
        {
            _manager = manager;
        }
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]CreateCommentViewModel obj) 
        {
            try
            {
                Guid guid = Guid.NewGuid();
                var comment = obj.AsCommentDTO();
                comment.Id = guid;
                await _manager.CommentService.Create(comment);
                await _manager.Save();
                return Ok(new { id = guid });
            }
            catch (Exception ex)
            {
                return BadRequest(new {error = ex.Message});
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                await _manager.CommentService.Delete(id);
                await _manager.Save();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new {error = ex.Message});
            }
        }
        
    }
}
