using Microsoft.AspNetCore.Identity;

using System.ComponentModel.DataAnnotations;

namespace GraduationProject.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Required]
        public string FullName { get; set; }
    }
}
