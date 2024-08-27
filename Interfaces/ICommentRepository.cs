using Asp.NetCore.BlogifyAPI.With.RepositoryDessignPatterns.Dtos.Post;
using Asp.NetCore.BlogifyAPI.With.RepositoryDessignPatterns.Models;

namespace Asp.NetCore.BlogifyAPI.With.RepositoryDessignPatterns.Interfaces
{
    public interface ICommentRepository
    {
        Task<List<Comment>> GetAllAsync();
        Task<Comment?> GetByIdAsync(int id);
        Task<Comment> CreateAsync(Comment comment);
        Task<Comment> UpdateAsync(int id, Comment comment);
        Task<Comment> DeleteAsync(int id);
    }
}
