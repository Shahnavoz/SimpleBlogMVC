using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SimpleBlogMVCApplication.Models.Entities;
using SimpleBlogMVCApplication.Models.ViewModels.TagViewModel;
using SimpleBlogMVCApplication.Services.Interfaces;

namespace SimpleBlogMVCApplication.Services;

public class TagService(ApplicationDbContext context,IMapper mapper):ITagService
{
    public async Task<List<Tag>> GetAllTagsAsync()
    {
        var tags=context.Tags.AsQueryable();
        return await tags.ToListAsync();
    }

    public async Task<Tag> GetTagById(long id)
    {
        var tag=await context.Tags.FindAsync(id);
        if(tag==null) return null;
        return tag;
    }

    public async Task<TagUpdateViewModel> GetTagByIdAsync(long id)
    {
       var tag=await context.Tags.FirstOrDefaultAsync(t=>t.Id==id);
       if(tag==null)
           return null;
       return new TagUpdateViewModel
       {
           Id = tag.Id,
           Name = tag.Name,

       };
    }

    public async Task<Tag> AddTagAsync(TagAddViewModel model)
    {
        var tag=mapper.Map<Tag>(model);
        context.Tags.Add(tag);
        await context.SaveChangesAsync();
        return tag;
    }

    public async Task UpdateTagAsync(Tag model)
    {
        var tag=await context.Tags.FirstOrDefaultAsync(t=>t.Id==model.Id);
        if(tag==null)  return;
       tag.Name = model.Name;
       context.Tags.Update(tag);
       await context.SaveChangesAsync();
       
    }

    public async Task DeleteTagAsync(long id)
    {
        var tag=await context.Tags.FirstOrDefaultAsync(t=>t.Id==id);
        if(tag==null) return;
        context.Tags.Remove(tag);
        await context.SaveChangesAsync();
    }
}