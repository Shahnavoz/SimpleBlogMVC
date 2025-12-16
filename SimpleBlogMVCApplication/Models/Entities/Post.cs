namespace SimpleBlogMVCApplication.Models.Entities;

public class Post:BaseEntity
{
    public string Title { get; set; }
    public string Content { get; set; }
    public DateTime? DateCreated { get; set; } = new DateTime();
    
    public ICollection<PostTags>? PostTags { get; set; }
    
}