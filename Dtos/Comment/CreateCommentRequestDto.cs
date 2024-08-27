using System.ComponentModel.DataAnnotations;

namespace Asp.NetCore.BlogifyAPI.With.RepositoryDessignPatterns.Dtos.Comment
{
    public class CreateCommentRequestDto
    {
        [Required]
        [MinLength(5, ErrorMessage = "Title must be 5 characters")]
        [MaxLength(280, ErrorMessage = "Title cannot be over 280 charachters")]
        public string Content {get; set;} = string.Empty;
    }
}
