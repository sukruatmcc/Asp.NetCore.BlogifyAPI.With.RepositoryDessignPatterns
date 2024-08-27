using Asp.NetCore.BlogifyAPI.With.RepositoryDessignPatterns.data;
using Asp.NetCore.BlogifyAPI.With.RepositoryDessignPatterns.Dtos.Post;
using Asp.NetCore.BlogifyAPI.With.RepositoryDessignPatterns.Interfaces;
using Asp.NetCore.BlogifyAPI.With.RepositoryDessignPatterns.Models;
using Microsoft.EntityFrameworkCore;

namespace Asp.NetCore.BlogifyAPI.With.RepositoryDessignPatterns.Repository
{
    public class PostRepository : IPostRepository
    {
        private readonly ApplicationDBContext _context;
        public PostRepository(ApplicationDBContext context)
        {
            _context = context;
        }
        public async Task<List<Post>> GetAllAsync()
        {
            var posts = _context.Posts.Include(c => c.Comments).ToListAsync();

            return await posts;
        }

        public async Task<Post> CreateAsync(Post post)
        {
            await _context.Posts.AddAsync(post);
            await _context.SaveChangesAsync();

            return post;
        }
        public async Task<Post?> GetByIdAsync(int id)
        {
            var post = await _context.Posts.Include(c => c.Comments).FirstOrDefaultAsync(p => p.Id == id);
            
            if(post == null)
            {
                return null;
            }
            return post;
        }
        public async Task<Post> UpdateAsync(int id, UpdatePostRequestDto postDto)
        {
            var postModel = await _context.Posts.FirstOrDefaultAsync(p => p.Id == id);

            if(postModel == null)
            {
                return null;
            }
            postModel.Title = postDto.Title;
            postModel.Content = postDto.Content;
            await _context.SaveChangesAsync();

            return postModel;
        }
        public async Task<Post> DeleteAsync(int id)
        {
            var post = await _context.Posts.FirstOrDefaultAsync(p => p.Id == id);

            if(post == null)
            {
                return null;
            }  
            _context.Posts.Remove(post);
            await _context.SaveChangesAsync();

            return post;         
        }
    }
}
