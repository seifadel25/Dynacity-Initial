namespace DynacityFront.DTO
{
    public class UserUpdateDTO
    {
        public string First_Name { get; set; }
        public string Last_Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string NationalIdImage { get; set; }
        public string ProfilePicture { get; set; }
        public string StreetAddress { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public int? CompanyId { get; set; }
    }
}
