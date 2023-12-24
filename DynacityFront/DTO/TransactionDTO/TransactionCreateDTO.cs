
namespace DynacityFront.DTO
{
    public class TransactionCreateDTO
    {
        public int Amount { get; set; }
        public string ContractLink { get; set; }
        public TransactionType Type { get; set; }
        public int PropertyId { get; set; }
        public string UserId { get; set; }
    }
}

