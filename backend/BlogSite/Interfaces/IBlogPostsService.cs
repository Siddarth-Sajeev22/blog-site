using BlogSite.Models;

namespace BlogSite.Interfaces
{
    public interface IBlogPostsService
    {
        Task<IEnumerable<BlogPost>> GetAllAsync();
        Task<BlogPost?> GetByIdAsync(int id);
        Task<BlogPost> CreateAsync(BlogPost post);
        Task<bool> UpdateAsync(int id, BlogPost updatedPost);
        Task<bool> DeleteAsync(int id);
    }
}
