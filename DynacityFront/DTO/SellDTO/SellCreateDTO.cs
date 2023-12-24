namespace DynacityFront.DTO
{
    public class SellCreateDTO
    {
        public int SellId { get; set; }
        public double SellPrice { get; set; }
        public DateTime DatePosted { get; set; }

        public string SellDiscription { get; set; }

        public bool IsActive { get; set; }
    }
}
