using System.ComponentModel.DataAnnotations;

namespace GraduationProject.Models
{
    public class MediaArchive
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        public string Description { get; set; }

        [Required]
        public int MediaType { get; set; }

        public int CityId { get; set; }

        public int Year { get; set; }

        public string MediaUrl { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public City City { get; set; }
    }
    // Models/Category.cs
    public class Category
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }

        // Navigation property
        public ICollection<MediaArchive> ArchiveMedias { get; set; }
    }

}
