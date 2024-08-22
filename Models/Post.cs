using System.ComponentModel.DataAnnotations.Schema;

namespace Asp.NetCore.BlogifyAPI.With.RepositoryDessignPatterns.Models
{
    [Table("Posts")]
    public class Post
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime CreatedAt {get; set;}
        public DateTime UpdatedAt {get; set;}
        public List<Comment> Comments { get; set; } = new List<Comment>();// Navigation property
    }
}
