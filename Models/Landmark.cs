using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace GraduationProject.Models
{
    public class Landmark
    {
        [Key]
        public int Landmark_Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Landmark_Name { get; set; }

        public string? Landmark_Description { get; set; }

        [ForeignKey("City")]
        public int City_Id { get; set; }

        public int? Year_Built { get; set; }

        [StringLength(255)]
        public string? Importance { get; set; }

        public string? Image_Path { get; set; }

        // Navigation property to establish a relationship with the City model
        public virtual City City { get; set; }
    }
}
