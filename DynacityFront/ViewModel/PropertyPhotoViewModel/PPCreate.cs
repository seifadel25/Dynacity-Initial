using DynacityFront.DTO;

namespace DynacityFront.ViewModel.PropertyPhotoViewModel
{

    public class PPCreate
    {
        public PPCreate()
        {

            Property = new PropertyCreateDTO();
        }
        public PropertyCreateDTO Property { get; set; }
        public List<PhotoCreateDTO> PhotoVM { get; set; }
    }
}

