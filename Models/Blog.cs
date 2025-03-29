using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GraduationProject.Models
{
    public class Blog
    {
        [Key]
        public int Blog_Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string Quote { get; set; }
        public string Button_Text { get; set; }
        public string Button_Url { get; set; }
        public bool IsApproved { get; set; } = false;


        [Required]
        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public ApplicationUser User { get; set; }
        [Required]
        public int CategoryID { get; set; }
        [ForeignKey("CategoryID")]
        public Category Category { get; set; }
    }
}
