using System.ComponentModel.DataAnnotations;

namespace GraduationProject.Models
{
    public class HomeViewModel
    {
        public List<City> Cities { get; set; }
        public List<Video> Videos { get; set; }
        public List<Slide> Slides { get; set; }
        public List<Blog> Blogs { get; set; }


    }
}
