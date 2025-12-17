using AutoMapper;
using SimpleBlogMVCApplication.Models.Entities;
using SimpleBlogMVCApplication.Models.ViewModels.PostViewModel;
using SimpleBlogMVCApplication.Models.ViewModels.TagViewModel;

namespace SimpleBlogMVCApplication.AutoMapper;

public class PostMapperProfile:Profile
{
    public PostMapperProfile()
    {
        CreateMap<PostAddViewModel, Post>();
        CreateMap<TagAddViewModel, Tag>();
    }
    
}