using Microsoft.AspNetCore.Mvc;
using SimpleBlogMVCApplication.Models.Entities;
using SimpleBlogMVCApplication.Models.ViewModels.TagViewModel;
using SimpleBlogMVCApplication.Services.Interfaces;

namespace SimpleBlogMVCApplication.Controllers;

public class TagController(ITagService tagService):Controller
{
    public async Task<IActionResult> Index()
    {
        ViewBag.Tags = await tagService.GetAllTagsAsync();
        return View(ViewBag.Tags );
    }

    public IActionResult Create()
    {
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> Create([FromForm] TagAddViewModel model)
    {
        var category = await tagService.AddTagAsync(model);
        return RedirectToAction("Index");
    }
    [HttpGet]
    public async Task<IActionResult> Update(int id)
    {
        
        var tag = await tagService.GetTagByIdAsync(id); 
        if (tag == null) return NotFound();

        return View(tag); 
    }
    
    [HttpPost]
    public async Task<IActionResult> Update(TagUpdateViewModel model)
    {
        if (!ModelState.IsValid)
            return View(model);

        await tagService.UpdateTagAsync(new Tag
        {
            Id = model.Id,
            Name = model.Name
            
            
        });

        return RedirectToAction("Index");
    }
    
    
    [HttpDelete]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        await tagService.DeleteTagAsync(id);
        return RedirectToAction("Index");
    }

    
}