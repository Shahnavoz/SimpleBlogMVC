using SimpleBlogMVCApplication.Models.Entities;
using SimpleBlogMVCApplication.Models.ViewModels.PostViewModel;

namespace SimpleBlogMVCApplication.Services.Interfaces;

public interface IPostService
{
    Task<List<Post>> GetAllPosts();
    Task<Post?> GetPostById(long id);
    Task<PostUpdateViewModel> GetPostByIdAsync(long id);
    Task<Post> AddPostAsync(PostAddViewModel post);
    Task UpdatePostAsync(Post post);
    Task DeletePostAsync(long id);
}