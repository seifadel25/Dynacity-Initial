using DynacityFront.DTO;

namespace DynacityFront.ViewModel
{
    public class PropertyRentDeleteVM
    {
        public PropertyRentDeleteVM()
        {
            Property = new PropertyCreateDTO();
        }
        public PropertyCreateDTO Property { get; set; }
        public RentCreateDTO Rent { get; set; }

    }
}
