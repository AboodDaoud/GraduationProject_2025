using System.ComponentModel.DataAnnotations;

namespace GraduationProject.Models
{
    public class City
    {
        [Key]
        public int City_Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string City_Name { get; set; }

        [MaxLength(500)]
        public string City_Description { get; set; }

        [MaxLength(500)]
        public string City_Highlights { get; set; }

        [MaxLength(200)]
        public string City_ImageUrl { get; set; }

        [MaxLength(200)]
        public string City_PageUrl { get; set; }
        [Required]
        public double City_Latitude { get; set; }
        [MaxLength(500)]
        public string VirtualTourLink { get; set; }

        [Required]
        public double City_Longitude { get; set; }
        public double City_Area { get; set; }
        public int City_Population { get; set; }
        public string Detailed_Information { get; set; }
        public virtual ICollection<Landmark> Landmarks { get; set; }
        public virtual ICollection<Village> Villages { get; set; }

    }
}
