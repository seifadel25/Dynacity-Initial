using DynacityFront.DTO;

namespace DynacityFront.ViewModel
{
    public class PropertyBidCreateVM
    {
        public PropertyBidCreateVM()
        {
            Property = new PropertyCreateDTO();
        }
        public PropertyCreateDTO Property { get; set; }
        public BidsCreateDTO Bid { get; set; }

    }
}
