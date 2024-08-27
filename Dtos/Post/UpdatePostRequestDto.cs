namespace Asp.NetCore.BlogifyAPI.With.RepositoryDessignPatterns.Dtos.Post
{
    public class UpdatePostRequestDto
    {
        public string Title { get; set; }
        public string Content { get; set; } = string.Empty;
    }
}
