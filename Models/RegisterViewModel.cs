using System.ComponentModel.DataAnnotations;

namespace GraduationProject.Models
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "الاسم الأول مطلوب")]
        [StringLength(50, ErrorMessage = "يجب ألا يزيد الاسم الأول عن 50 حرفًا")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "الاسم الثاني مطلوب")]
        [StringLength(50, ErrorMessage = "يجب ألا يزيد الاسم الثاني عن 50 حرفًا")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "البريد الإلكتروني مطلوب")]
        [EmailAddress(ErrorMessage = "البريد الإلكتروني غير صالح")]
        public string Email { get; set; }

        [Required(ErrorMessage = "رقم الهاتف مطلوب")]
        [Phone(ErrorMessage = "رقم الهاتف غير صالح")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "كلمة المرور مطلوبة")]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "يجب أن تتكون كلمة المرور من 6 إلى 100 حرف")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "يرجى تأكيد كلمة المرور")]
        [Compare("Password", ErrorMessage = "كلمتا المرور غير متطابقتين")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
        public string FullName => $"{FirstName} {LastName}"; // Auto-generate FullName
    }
}
