using Asp.NetCore.BlogifyAPI.With.RepositoryDessignPatterns.Dtos.Post;
using Asp.NetCore.BlogifyAPI.With.RepositoryDessignPatterns.Models;

namespace Asp.NetCore.BlogifyAPI.With.RepositoryDessignPatterns.Mappers
{
    public static class PostMappers
    {
        public static PostDto ToPostDto(this Post postModel)
        {
            return new PostDto
            {
                Id = postModel.Id,
                Title = postModel.Title,
                Content = postModel.Content,
                Comments = postModel.Comments.Select(c => c.ToCommentDto()).ToList(),
            };
        }
        
        public static Post ToPostFromCreateDTO(this CreatePostRequestDto postDto)//Post model sınıfından (dosyasından) gelir
        {
            return new Post
            {
                Title = postDto.Title,
                Content = postDto.Content 
            };
        }
    }
}
