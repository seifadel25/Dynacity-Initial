using DynacityFront.Models;

public class PropertyShowDTO
{
    public int PropertyId { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public int Bedrooms { get; set; }
    public int Bathrooms { get; set; }
    public int Area { get; set; }
    public string StreetAddress { get; set; }
    public string City { get; set; }
    public string Country { get; set; }
    public double Price { get; set; }
    public string UserID { get; set; }
    public bool IsForSale { get; set; }
    public bool IsForRent { get; set; }
    public bool HasBids { get; set; }
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
    //public PropertySellDTO Sell { get; set; }
    //public RentShowDTO Rent { get; set; }
    //public BidsDTO Bid { get; set; }
    // public List<Photo> Photos { get; set; }
    //public ResidentialSubType ResidentialSubType { get; set; }
    //public CommercialSubType CommercialSubType { get; set; }
    //public IndustrialSubType IndustrialSubType { get; set; }
    //public LandSubType LandSubType { get; set; }
    //public PropertyType PropertyType { get; set; }
    //public PropertyStat PropertyStat { get; set; }
}
