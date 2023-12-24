namespace DynacityFront.DTO
{
    public class BidsUpdateDTO
    {
        public int BidId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Description { get; set; }
        public double BidAmount { get; set; }
        public double StartingPrice { get; set; }
        public bool IsAccepted { get; set; }
        public PropertyTradeGETDTO PropertyUpdate { get; set; }

    }
}
