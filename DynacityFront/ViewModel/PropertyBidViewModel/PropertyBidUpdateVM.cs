using DynacityFront.DTO;

namespace DynacityFront.ViewModel
{
    public class PropertyBidUpdateVM
    {
        public PropertyBidUpdateVM()
        {
            Property = new PropertyCreateDTO();
        }
        public PropertyCreateDTO Property { get; set; }
        public BidsCreateDTO Bid { get; set; }

    }
}
