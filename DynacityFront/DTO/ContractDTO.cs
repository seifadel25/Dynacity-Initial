namespace DynacityFront.DTO
{
    public class ContractDTO
    {
        public int ContractId { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateSigned { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        public string GoogleDocLink { get; set; }
        public int TransactionId { get; set; }
        public int PropertyId { get; set; }
        public int UserId { get; set; }
        public int CompanyId { get; set; }

    }
}
