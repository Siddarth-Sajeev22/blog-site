using BlogSite.Data;
using BlogSite.Interfaces;
using BlogSite.Models;
using Microsoft.EntityFrameworkCore;

namespace BlogSite.Repositories;

public class BlogPostsRepository : IBlogPostsRepository
{
    private readonly BlogDbContext _context;

    public BlogPostsRepository(BlogDbContext context)
    { 
        _context = context;
    }
    public async Task<BlogPost?> GetBlogPostByIdAsync(int id)
    {
         return await _context.BlogPosts.FindAsync(id);
    }

    public async Task<IEnumerable<BlogPost>> GetAllBlogPosts()
    {
         return await _context.BlogPosts.ToListAsync(); 
    }

    public async Task AddAsync(BlogPost blog)
    {
        await _context.BlogPosts.AddAsync(blog);  
    }

    public void Delete(BlogPost blog)
    {
        _context.BlogPosts.Remove(blog);
    }

    public void Update(BlogPost blog)
    {
         _context.BlogPosts.Update(blog); 
    }

    public async Task SaveAsync()
    {
        await _context.SaveChangesAsync(); 
    }
}