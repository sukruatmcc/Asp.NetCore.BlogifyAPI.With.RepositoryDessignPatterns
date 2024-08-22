using System.ComponentModel.DataAnnotations.Schema;

namespace Asp.NetCore.BlogifyAPI.With.RepositoryDessignPatterns.Models
{
    [Table("Comments")]
    public class Comment
    {
        public int Id { get; set; }
        public int PostId { get; set; }//Foreign key for PostId
        public string Content { get; set; }
        public DateTime CreatedAt {get; set;}
        public DateTime UpdatedAt {get; set;}
        public Post Post {get;set;}
    }
}
