using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace GraduationProject.Models
{
    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<City> Cities { get; set; }
        public DbSet<Video> Videos { get; set; }
        public DbSet<Slide> Slides { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Village> Villages { get; set; }
        public DbSet<MediaArchive> MediaArchive { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Landmark> Landmarks { get; set; }



    }
}
