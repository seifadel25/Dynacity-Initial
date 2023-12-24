
using Microsoft.Build.Framework;
namespace DynacityFront.DTO
{
    public class EventCompanyDTO
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public int EventId { get; set; }
        [Required]
        public int CompanyId { get; set; }
    }
}
