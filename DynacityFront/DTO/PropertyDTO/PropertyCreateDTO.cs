using System.ComponentModel.DataAnnotations.Schema;

namespace DynacityFront.DTO
{

    public class PropertyCreateDTO
    {

        public string Title { get; set; }
        public string Description { get; set; }
        public int Bedrooms { get; set; }
        public int Bathrooms { get; set; }
        public int Area { get; set; }

        public string StreetAddress { get; set; }
        public string City { get; set; }
        public string Country { get; set; }

        public string PropertyMainImageURL { get; set; }
        public IFormFile PropertyMainImage { get; set; }
        public string PropertyImageURL1 { get; set; }
        public IFormFile PropertyImage1 { get; set; }
        public string PropertyImageURL2 { get; set; }
        public IFormFile PropertyImage2 { get; set; }
        public string PropertyImageURL3 { get; set; }
        public IFormFile PropertyImage3 { get; set; }
        public string PropertyImageURL4 { get; set; }
        public IFormFile PropertyImage4 { get; set; }
        public string PropertyImageURL5 { get; set; }
        public IFormFile PropertyImage5 { get; set; }

        public double Price { get; set; }

        public string PropertyType { get; set; }
        public string? FurnishString { get; set; }
        public string? Utilities { get; set; }
        public string? PropertyFacilities { get; set; }
        public string? PropertyView { get; set; }
        public string? AvailableServies { get; set; }
        public int? FloorsNumber { get; set; }
        public int? HallsNumber { get; set; }


        //Relations


        public string UserID { get; set; }


    }
}