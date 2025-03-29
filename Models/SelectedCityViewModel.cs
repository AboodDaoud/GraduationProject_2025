using System.ComponentModel.DataAnnotations;

namespace GraduationProject.Models
{
    public class SelectedCityViewModel
    {
        public int City_Id { get; set; }
        public string City_Name { get; set; }
        public string City_Description { get; set; }
        public string City_Highlights { get; set; }
        public string City_ImageUrl { get; set; }
        public string City_PageUrl { get; set; }
        public double City_Latitude { get; set; }
        public double City_Longitude { get; set; }
        public double City_Area { get; set; }
        public int City_Population { get; set; }
        public string Detailed_Information { get; set; }
        public List<LandmarkViewModel> Landmarks { get; set; }
    }
}
