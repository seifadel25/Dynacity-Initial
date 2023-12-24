using Microsoft.EntityFrameworkCore;

namespace DynacityFront.DTO
{
    [Keyless]

    public class UserCreateDTO
    {
        public string First_Name { get; set; }
        public string Last_Name { get; set; }
        public string PhoneNumber { get; set; }
        public string NationalId { get; set; }
        public string Email { get; set; }
        public string NationalIdImage { get; set; }
        public string ProfilePicture { get; set; }
        public string StreetAddress { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
    }
}
