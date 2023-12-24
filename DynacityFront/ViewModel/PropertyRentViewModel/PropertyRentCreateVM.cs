using DynacityFront.DTO;

namespace DynacityFront.ViewModel
{
    public class PropertyRentCreateVM
    {
        public PropertyRentCreateVM()
        {
            Property = new PropertyCreateDTO();
        }
        public PropertyCreateDTO Property { get; set; }
        public RentCreateDTO Rent { get; set; }

    }
}
