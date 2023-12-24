using DynacityFront.DTO;

namespace DynacityFront.ViewModel
{
    public class PropertySellUpdateVM
    {
        public PropertySellUpdateVM()
        {
            Property = new PropertyCreateDTO();
        }
        public PropertyCreateDTO Property { get; set; }
        public SellCreateDTO Sell { get; set; }

    }
}
