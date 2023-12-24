namespace DynacityFront.DTO
{
    public class RentShowDTO
    {
        public int RentId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime DatePosted { get; set; }
        public double RentPrice { get; set; }
        public bool IsActive { get; set; }
        public string RentDiscription { get; set; }
        //  public ICollection<PropertyTradeGETDTO> Property { get; set; }
        public PropertyTradeGETDTO Property { get; set; }

    }
}
