using Asp.NetCore.BlogifyAPI.With.RepositoryDessignPatterns.data;
using Asp.NetCore.BlogifyAPI.With.RepositoryDessignPatterns.Interfaces;
using Asp.NetCore.BlogifyAPI.With.RepositoryDessignPatterns.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace Asp.NetCore.BlogifyAPI.With.RepositoryDessignPatterns.Repository
{
    public class CommentRepository : ICommentRepository
    {
        private readonly ApplicationDBContext _context;
        public CommentRepository(ApplicationDBContext context)
        {
            _context = context;
        }
        public async Task<List<Comment>> GetAllAsync()
        {
            return await _context.Comments.ToListAsync();
        }
        public async Task<Comment?> GetByIdAsync(int id)
        {
            return await _context.Comments.FirstOrDefaultAsync(c => c.Id == id);
        }
        public async Task<Comment> CreateAsync(Comment comment)
        {
            await _context.AddAsync(comment);
            await _context.SaveChangesAsync();

            return comment;
        }
        public async Task<Comment> UpdateAsync(int id, Comment comment)
        {
            var commentModel = await _context.Comments.FirstOrDefaultAsync(c => c.Id == id);

            if(commentModel == null)
            {
                return null;
            }
            commentModel.Content = comment.Content;
            await _context.SaveChangesAsync();

            return commentModel;
        }
        public async Task<Comment> DeleteAsync(int id)
        {
            var comment = await _context.Comments.FirstOrDefaultAsync(c => c.Id == id);

            if(comment == null)
            {
                return null;
            }
            _context.Comments.Remove(comment);
            await _context.SaveChangesAsync();

            return comment;
        }
    }
}
