namespace DynacityFront.DTO
{
    public class SellShow
    {
        public int SellId { get; set; }
        public double SellPrice { get; set; }
        public string SellDiscription { get; set; }
        public DateTime DatePosted { get; set; }
        public bool IsActive { get; set; }
        public PropertyTradeGETDTO Property { get; set; }
    }
}
