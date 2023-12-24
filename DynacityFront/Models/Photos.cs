using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace DynacityFront.Models
{
    public class Photo
    {
        public int Id { get; set; }
        public string ImageCaption { get; set; }
        public Uri Data { get; set; }

        //relation

        public int PropertyId { get; set; }
        public Property Property { get; set; }
    }
}
