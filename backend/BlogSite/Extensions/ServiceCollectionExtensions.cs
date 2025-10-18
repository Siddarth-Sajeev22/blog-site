using BlogSite.Interfaces;
using BlogSite.Repositories;
using BlogSite.Services;

namespace BlogSite.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        // Register application services and repositories here
        services.AddScoped<IBlogPostsService, BlogPostsService>();
        services.AddScoped<IBlogPostsRepository, BlogPostsRepository>(); 
        return services;
    }
}
