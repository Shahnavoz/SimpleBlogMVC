using SimpleBlogMVCApplication.Models.Entities;
using SimpleBlogMVCApplication.Models.ViewModels.TagViewModel;

namespace SimpleBlogMVCApplication.Services.Interfaces;

public interface ITagService
{
    Task<List<Tag>> GetAllTagsAsync();
    Task<Tag> GetTagById(long id);
    Task<TagUpdateViewModel> GetTagByIdAsync(long id);
    Task<Tag> AddTagAsync(TagAddViewModel model);
    Task UpdateTagAsync(Tag model);
    Task DeleteTagAsync(long id);
    
}