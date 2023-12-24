namespace DynacityFront.DTO
{
    public class BidsCreateDTO
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Description { get; set; }
        public double UserBidAmount { get; set; }
        public double CurrentBidAmount { get; set; }
        public double StartingPrice { get; set; }
        public int PropertyId { get; set; }
        public bool IsAccepted { get; set; }
    }
}
