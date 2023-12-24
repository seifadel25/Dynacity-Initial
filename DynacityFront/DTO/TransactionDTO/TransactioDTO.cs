namespace DynacityFront.DTO
{
    public class TransactionDTO
    {
        public int TransactionId { get; set; }
        public DateTime Date { get; set; }
        public int Amount { get; set; }
        public string ContractLink { get; set; }
        public TransactionType Type { get; set; }
        public TransactionStatus Status { get; set; }
        public int PropertyId { get; set; }
        public string UserId { get; set; }
    }
    public enum TransactionType
    {
        Buy,
        reservation,
        Rent
    }

    public enum TransactionStatus
    {
        Pending,
        Complete,
        Cancelled
    }
}
