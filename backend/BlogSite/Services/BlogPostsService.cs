using BlogSite.Interfaces;
using BlogSite.Models;

namespace BlogSite.Services
{
    public class BlogPostsService : IBlogPostsService
    {
        private readonly IBlogPostsRepository _repository;

        public BlogPostsService(IBlogPostsRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<BlogPost>> GetAllAsync()
        => await _repository.GetAllBlogPosts();

        public async Task<BlogPost?> GetByIdAsync(int id)
        => await _repository.GetBlogPostByIdAsync(id);

        public async Task<BlogPost> CreateAsync(BlogPost post)
        {
            await _repository.AddAsync(post);
            await _repository.SaveAsync();
            return post;
        }

        public async Task<bool> UpdateAsync(int id, BlogPost updatedPost)
        {
            var existing = await _repository.GetBlogPostByIdAsync(id);
            if (existing == null) return false;

            existing.Title = updatedPost.Title;
            existing.Content = updatedPost.Content;

            _repository.Update(existing);
            await _repository.SaveAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var existing = await _repository.GetBlogPostByIdAsync(id);
            if (existing == null) return false;

            _repository.Delete(existing);
            await _repository.SaveAsync();
            return true;
        }
    }
}
