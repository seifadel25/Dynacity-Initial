namespace DynacityFront.DTO
{
    public class SellDTO
    {
        public int SellId { get; set; }
        public double SellPrice { get; set; }
        public string SellDiscription { get; set; }
        public DateTime DatePosted { get; set; }
        public bool IsActive { get; set; }
        public ICollection<PropertyDTO> Properties { get; set; }
    }
}
