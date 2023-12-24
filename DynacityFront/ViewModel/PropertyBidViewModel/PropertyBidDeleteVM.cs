using DynacityFront.DTO;

namespace DynacityFront.ViewModel
{
    public class PropertyBidDeleteVM
    {
        public PropertyBidDeleteVM()
        {
            Property = new PropertyCreateDTO();
        }
        public PropertyCreateDTO Property { get; set; }
        public BidsCreateDTO Bid { get; set; }

    }
}
