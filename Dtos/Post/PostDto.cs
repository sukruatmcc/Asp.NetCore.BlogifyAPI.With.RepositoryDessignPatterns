using Asp.NetCore.BlogifyAPI.With.RepositoryDessignPatterns.Models;

namespace Asp.NetCore.BlogifyAPI.With.RepositoryDessignPatterns.Dtos.Post
{
    public class PostDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; } = string.Empty;

    }
}
