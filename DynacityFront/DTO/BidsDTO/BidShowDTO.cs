namespace DynacityFront.DTO
{
    public class BidShowDTO
    {
        public int BidId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Description { get; set; }
        public double UserBidAmount { get; set; }
        public double CurrentBidAmount { get; set; }
        public bool IsAccepted { get; set; }
        public int UserId { get; set; } // Add UserId property
        public int CompanyId { get; set; } // Add CompanyId property
        public PropertyTradeGETDTO Property { get; set; }

    }
}
