using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Village
{
    [Key]
    public int Village_ID { get; set; }

    [Required(ErrorMessage = "اسم القرية مطلوب")]
    [StringLength(100, ErrorMessage = "اسم القرية يجب ألا يتجاوز 100 حرف")]
    [Display(Name = "اسم القرية")]
    public string Village_Name { get; set; }

    [Required(ErrorMessage = "وصف القرية مطلوب")]
    [StringLength(500, ErrorMessage = "الوصف يجب ألا يتجاوز 500 حرف")]
    [Display(Name = "وصف القرية")]
    public string Village_Description { get; set; }

    [StringLength(300, ErrorMessage = "أبرز المعالم يجب ألا تتجاوز 300 حرف")]
    [Display(Name = "أبرز المعالم")]
    public string Village_Highlights { get; set; }

    [Required(ErrorMessage = "رابط صورة القرية مطلوب")]
    [Url(ErrorMessage = "يجب إدخال رابط صالح")]
    [Display(Name = "رابط الصورة")]
    public string Village_ImageUrl { get; set; }

    [Url(ErrorMessage = "يجب إدخال رابط صالح")]
    [Display(Name = "رابط الصفحة")]
    public string Village_PageUrl { get; set; }

    [ForeignKey("City")]
    [Required(ErrorMessage = "يجب تحديد المدينة")]
    [Display(Name = "معرف المدينة")]
    public int City_ID { get; set; }
}
