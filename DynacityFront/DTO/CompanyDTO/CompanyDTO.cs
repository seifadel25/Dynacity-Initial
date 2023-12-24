



using System.ComponentModel.DataAnnotations;
namespace DynacityFront.DTO
{
    public class CompanyDTO
    {
        [Key]
        public int CompanyId { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }
        public string ProfilePicture { get; set; }

        public string Description { get; set; }

        public string TaxRegistrationNumber { get; set; }
        public int NumberOfBranches { get; set; }

        public CompanyType Type { get; set; }

        public int BrokerId { get; set; }
        public int EventId { get; set; }
        public int AddressId { get; set; }

        public int RentId { get; set; }


        public int BidId { get; set; }

        public int PropertyId { get; set; }

        public int ReviewId { get; set; }
        public int ContractId { get; set; }

    }
    public enum CompanyType
    {
        RealEstateAgency,
        PropertyManagement,
        InvestmentFirm,
        Developer,
        Builder,
        LegalServices
    }


}
