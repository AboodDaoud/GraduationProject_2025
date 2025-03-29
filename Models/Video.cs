using System.ComponentModel.DataAnnotations;

namespace GraduationProject.Models
{
    public class Video
    {
        [Key]
        public int Video_Id { get; set; }
        [Required]
        [MaxLength(255)]
        public string Video_Title { get; set; }
        public string Video_Description { get; set; }
        [MaxLength(500)]
        public string Video_Url { get; set; }
    }
}