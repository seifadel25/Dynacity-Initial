namespace DynacityFront.DTO
{
    public class RentUpdateDTO
    {
        public int RentId { get; set; }
        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public double RentPrice { get; set; }

        public bool IsActive { get; set; }

        public string RentDiscription { get; set; }
        public PropertyTradeGETDTO PropertyUpdate { get; set; }

    }
}
