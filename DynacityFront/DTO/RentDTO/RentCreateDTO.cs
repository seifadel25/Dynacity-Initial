namespace DynacityFront.DTO
{
    public class RentCreateDTO
    {

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public double RentPrice { get; set; }

        public bool IsActive { get; set; }
        public int PropertyId { get; set; }

        public string RentDiscription { get; set; }

    }
}
