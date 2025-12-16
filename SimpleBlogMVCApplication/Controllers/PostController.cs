using Microsoft.AspNetCore.Mvc;
using SimpleBlogMVCApplication.Models.Entities;
using SimpleBlogMVCApplication.Models.ViewModels.PostViewModel;
using SimpleBlogMVCApplication.Services.Interfaces;

namespace SimpleBlogMVCApplication.Controllers;

public class PostController(IPostService postService):Controller
{
    public async Task<IActionResult> Index()
    {
        ViewBag.Categories = await postService.GetAllPosts();
        return View(ViewBag.Categories);
    }
    
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromForm] PostAddViewModel model)
    {
        var category = await postService.AddPostAsync(model);
        return RedirectToAction("Index");
    }

    [HttpGet]
    public async Task<IActionResult> Update(int id)
    {
        
        var post = await postService.GetPostByIdAsync(id); 
        if (post == null) return NotFound();

        return View(post); 
    }

    [HttpPost]
    public async Task<IActionResult> Update(PostUpdateViewModel model)
    {
        if (!ModelState.IsValid)
            return View(model);

        await postService.UpdatePostAsync(new Post
        {
            Id = model.Id,
            Title = model.Name
        });

        return RedirectToAction("Index");
    }
    
    [HttpDelete]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        await postService.DeletePostAsync(id);
        return RedirectToAction("Index");
    }
}