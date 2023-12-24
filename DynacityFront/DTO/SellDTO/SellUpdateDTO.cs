namespace DynacityFront.DTO
{
    public class SellUpdateDTO
    {
        public int SellId { get; set; }
        public double SellPrice { get; set; }
        public string SellDiscription { get; set; }
        public bool IsActive { get; set; }
        public DateTime DatePosted { get; set; }

        public PropertyTradeGETDTO PropertyUpdate { get; set; }


    }
}
