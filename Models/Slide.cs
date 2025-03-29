using System.ComponentModel.DataAnnotations;

namespace GraduationProject.Models
{
    public class Slide
    {
        [Key]
        public int Slide_Id { get; set; }

        [Required]
        [MaxLength(255)]
        public string Image_Url { get; set; }

        [Required]
        [MaxLength(100)]
        public string Title { get; set; }

        [MaxLength(500)]
        public string Description { get; set; }

        [MaxLength(50)]
        public string Button_Text { get; set; }

        [MaxLength(255)]
        public string Button_Url { get; set; }
    }


}
