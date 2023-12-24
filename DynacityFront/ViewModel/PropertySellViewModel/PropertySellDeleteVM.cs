using DynacityFront.DTO;

namespace DynacityFront.ViewModel
{
    public class PropertySellDeleteVM
    {
        public PropertySellDeleteVM()
        {
            Property = new PropertyCreateDTO();
        }
        public PropertyCreateDTO Property { get; set; }
        public SellCreateDTO Sell { get; set; }

    }
}
