namespace DynacityFront.DTO
{
    public class ReservationDTO
    {

        public int ReservationId { get; set; }
        public bool IsConfirmed { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int NumberOfGuests { get; set; }
        public int EventId { get; set; }
        public int UserId { get; set; }
        public int BrokerId { get; set; }
        public int PropertyId { get; set; }


    }
}

