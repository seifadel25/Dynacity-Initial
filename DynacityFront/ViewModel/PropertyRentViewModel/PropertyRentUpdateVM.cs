using DynacityFront.DTO;

namespace DynacityFront.ViewModel
{
    public class PropertyRentUpdateVM
    {
        public PropertyRentUpdateVM()
        {
            Property = new PropertyCreateDTO();
        }
        public PropertyCreateDTO Property { get; set; }
        public RentCreateDTO Rent { get; set; }

    }
}
