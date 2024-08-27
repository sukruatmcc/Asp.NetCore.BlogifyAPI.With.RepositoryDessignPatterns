namespace Asp.NetCore.BlogifyAPI.With.RepositoryDessignPatterns.Dtos.Post
{
    public class CreatePostRequestDto
    {
        public string Title { get; set; }
        public string Content { get; set; } = string.Empty;
    }
}
