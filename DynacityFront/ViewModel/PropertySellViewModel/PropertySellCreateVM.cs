using DynacityFront.DTO;

namespace DynacityFront.ViewModel
{
    public class PropertySellCreateVM
    {
        public PropertySellCreateVM()
        {
            Property = new PropertyCreateDTO();
        }
        public PropertyCreateDTO Property { get; set; }
        public SellCreateDTO Sell { get; set; }

    }
}
