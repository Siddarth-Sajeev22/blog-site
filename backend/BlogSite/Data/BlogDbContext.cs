using BlogSite.Models;
using Microsoft.EntityFrameworkCore;

namespace BlogSite.Data;

public class BlogDbContext : DbContext
{
    public BlogDbContext(DbContextOptions<BlogDbContext> options) : base(options)
    {
    }

    public DbSet<BlogPost> BlogPosts { get; set; } = null!;
}
