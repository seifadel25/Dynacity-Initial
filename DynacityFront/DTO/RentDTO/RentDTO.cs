namespace DynacityFront.DTO
{
    public class RentDTO
    {
        public int RentId { get; set; }
        public int PropertyId { get; set; }
        public string RentPeriod { get; set; }

        public DateTime DatePosted { get; set; }
        public double RentPrice { get; set; }
        public bool IsActive { get; set; }
        public string RentDiscription { get; set; }

    }
}
