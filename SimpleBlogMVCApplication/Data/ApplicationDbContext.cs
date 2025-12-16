using Microsoft.EntityFrameworkCore;
using SimpleBlogMVCApplication.Models.Entities;

namespace SimpleBlogMVCApplication;
public class ApplicationDbContext(DbContextOptions<ApplicationDbContext>  options):DbContext(options)
{
    public DbSet<Post>  Posts { get; set; }
    public DbSet<Tag>  Tags { get; set; }
    public DbSet<PostTags> PostTags { get; set; }
}