using BlogSite.Models;

namespace BlogSite.Interfaces;

public interface IBlogPostsRepository {
    Task<BlogPost?> GetBlogPostByIdAsync(int id);
    Task<IEnumerable<BlogPost>> GetAllBlogPosts();

    Task AddAsync(BlogPost blog);
    void Delete(BlogPost blog);
    void Update(BlogPost blog);

    Task SaveAsync(); 


}