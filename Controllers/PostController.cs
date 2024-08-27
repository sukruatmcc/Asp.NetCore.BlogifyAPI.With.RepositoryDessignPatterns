using Asp.NetCore.BlogifyAPI.With.RepositoryDessignPatterns.Dtos.Post;
using Asp.NetCore.BlogifyAPI.With.RepositoryDessignPatterns.Interfaces;
using Asp.NetCore.BlogifyAPI.With.RepositoryDessignPatterns.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace Asp.NetCore.BlogifyAPI.With.RepositoryDessignPatterns.Controllers
{
    [Route("api/post")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly IPostRepository _postRepository;
        public PostController(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }
        [HttpGet]
        public async Task<IActionResult> GettAll()
        {
            var postModel = await _postRepository.GetAllAsync();

            return Ok(postModel);
        }   
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreatePostRequestDto postDto)
        {
            var postModel = postDto.ToPostFromCreateDTO();
            await _postRepository.CreateAsync(postModel);

            return Ok(postModel);
        }
        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var postModel = await _postRepository.GetByIdAsync(id);

            if(postModel == null)
            {
                 NotFound($"Post with ID {id} not found.");
            }
            return Ok(postModel);
        }
        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdatePostRequestDto postDto)
        {
            var postModel = await _postRepository.UpdateAsync(id,postDto);

            if(postModel == null)
            {
                return NotFound($"Post with ID {id} not found.");
            }

            return Ok(postModel);
        }
        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var postModel = await _postRepository.DeleteAsync(id);
            if(postModel == null)
            {
                return NotFound();
            }

            return NoContent();
        }
        
    }
}
