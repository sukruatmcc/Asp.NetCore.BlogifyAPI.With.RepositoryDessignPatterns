using Asp.NetCore.BlogifyAPI.With.RepositoryDessignPatterns.Dtos.Comment;
using Asp.NetCore.BlogifyAPI.With.RepositoryDessignPatterns.Models;

namespace Asp.NetCore.BlogifyAPI.With.RepositoryDessignPatterns.Mappers
{
    public static class CommentMappers
    {
        public static CommentDto ToCommentDto(this Comment commentModel)
        {
            if(commentModel == null)
            {
                throw new ArgumentNullException(nameof(commentModel), "Comment model cannot be null");
            }
            
            return new CommentDto
            {
                Id = commentModel.Id,
                Content = commentModel.Content,
                CreatedAt = commentModel.CreatedAt,
                PostId = commentModel.PostId
            };
        }

        public static Comment ToCommentFromCreateDTO(this CreateCommentRequestDto commentDto, int postId)
        {
            return new Comment
            {
                Content = commentDto.Content,
                PostId = postId
            };
        }

        public static Comment ToCommentFromUpdateDTO(this UpdateCommentRequestDto commentDto)
        {
            return new Comment
            {
                Content = commentDto.Content
            };
        }
        
    }
}
