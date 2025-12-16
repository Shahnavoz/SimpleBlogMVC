using AutoMapper;
using SimpleBlogMVCApplication.Models.Entities;
using SimpleBlogMVCApplication.Models.ViewModels.PostViewModel;

namespace SimpleBlogMVCApplication.AutoMapper;

public class PostMapperProfile:Profile
{
    public PostMapperProfile()
    {
        CreateMap<PostAddViewModel, Post>();
    }
    
}