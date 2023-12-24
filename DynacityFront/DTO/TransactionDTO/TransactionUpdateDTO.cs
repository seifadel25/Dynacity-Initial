
namespace DynacityFront.DTO
{
    public class TransactionUpdateDTO
    {
        public int Amount { get; set; }
        public string ContractLink { get; set; }
        public TransactionType Type { get; set; }
        public TransactionStatus Status { get; set; }
        public int PropertyId { get; set; }
        public string UserId { get; set; }
        public int TransactionId { get; set; }
    }
}
