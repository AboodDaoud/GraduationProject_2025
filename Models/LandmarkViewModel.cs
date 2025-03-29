namespace GraduationProject.Models
{
    public class LandmarkViewModel
    {
        public int Landmark_Id { get; set; }
        public string Landmark_Name { get; set; }
        public string Landmark_Description { get; set; }
        public int? Year_Built { get; set; }
        public string Importance { get; set; }
        public string Image_Path { get; set; }
    }
}
