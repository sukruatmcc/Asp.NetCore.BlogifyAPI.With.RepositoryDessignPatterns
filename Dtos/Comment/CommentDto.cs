namespace Asp.NetCore.BlogifyAPI.With.RepositoryDessignPatterns.Dtos.Comment
{
    public class CommentDto
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public int? PostId { get; set; }
    }
}
