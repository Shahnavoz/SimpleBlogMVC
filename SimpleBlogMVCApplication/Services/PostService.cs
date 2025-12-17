using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SimpleBlogMVCApplication.Models.Entities;
using SimpleBlogMVCApplication.Models.ViewModels.PostViewModel;
using SimpleBlogMVCApplication.Services.Interfaces;

namespace SimpleBlogMVCApplication.Services;

public class PostService(ApplicationDbContext context,IMapper mapper):IPostService
{
    public async Task<List<Post>> GetAllPosts()
    {
        var query=context.Posts.AsQueryable();
        return await query.ToListAsync();
    }

    public async Task<Post?> GetPostById(long id)
    {
        var post=await context.Posts.FindAsync(id);
        if (post == null) return null;
        return post;
    }

    public async Task<PostUpdateViewModel> GetPostByIdAsync(long id)
    {
        var post=await context.Posts.FirstOrDefaultAsync(p=>p.Id == id);
        if (post == null) return null;

        return new PostUpdateViewModel
        {
            Id = post.Id,
            Name = post.Title,
            Content = post.Content,
        };
    }

    public async Task<Post> AddPostAsync(PostAddViewModel model)
    {
        var post = mapper.Map<Post>(model);
        context.Posts.Add(post);
        await context.SaveChangesAsync();
        return post;
    }

    public async Task UpdatePostAsync(Post post)
    {
        var postToUpdate = await context.Posts.FirstOrDefaultAsync(p => p.Id == post.Id);
        if (postToUpdate == null)  return;
        postToUpdate.Title = post.Title;
        postToUpdate.Content = post.Content;
        context.Posts.Update(postToUpdate);
        await context.SaveChangesAsync();
    }

    public async Task DeletePostAsync(long id)
    {
        var post=await context.Posts.FirstOrDefaultAsync(p => p.Id == id);
        if (post == null) return;
        context.Posts.Remove(post);
        await context.SaveChangesAsync();
    }
}