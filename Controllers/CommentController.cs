using Asp.NetCore.BlogifyAPI.With.RepositoryDessignPatterns.Dtos.Comment;
using Asp.NetCore.BlogifyAPI.With.RepositoryDessignPatterns.Dtos.Post;
using Asp.NetCore.BlogifyAPI.With.RepositoryDessignPatterns.Interfaces;
using Asp.NetCore.BlogifyAPI.With.RepositoryDessignPatterns.Mappers;
using Asp.NetCore.BlogifyAPI.With.RepositoryDessignPatterns.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Asp.NetCore.BlogifyAPI.With.RepositoryDessignPatterns.Controllers
{
    [Route("api/comment")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly ICommentRepository _commentRepository;
        private readonly IPostRepository _postRepository;
        public CommentController(ICommentRepository commentRepository, IPostRepository postRepository)
        {
            _commentRepository = commentRepository;
            _postRepository = postRepository;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var comments = await _commentRepository.GetAllAsync();

            var commentDto = comments.Select(s => s.ToCommentDto()).ToList();

            return Ok(commentDto);
        }
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var commentModel = await _commentRepository.GetByIdAsync(id);

            if(commentModel == null)
            {
                return NotFound();
            }
            return Ok(commentModel.ToCommentDto());
        }
        [HttpPost("{postId:int}")]
        public async Task<IActionResult> Create([FromRoute] int postId, CreateCommentRequestDto commentDto)
        {
            if(!await _postRepository.PostExists(postId))
            {
                return BadRequest("Post does not exists");
            }

            var commentModel = commentDto.ToCommentFromCreateDTO(postId);
            await _commentRepository.CreateAsync(commentModel);

            return Ok(commentModel.ToCommentDto());
        }
        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateCommentRequestDto commentDto)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            var commentModel = await _commentRepository.UpdateAsync(id,commentDto.ToCommentFromUpdateDTO());

            if(commentModel == null)
            {
                return NotFound();
            }    
            return Ok(commentModel.ToCommentDto());
        }
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var commentModel = await _commentRepository.DeleteAsync(id);

            if(commentModel == null)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
