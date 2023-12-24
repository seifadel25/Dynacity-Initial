using System.ComponentModel.DataAnnotations;

namespace DynacityFront.DTO
{
    public class ReviewDTO
    {
        [Key]
        public int Id { get; set; }

        public int Rating { get; set; }

        public string Description { get; set; }

        public int CompanyId { get; set; }

        public int UserId { get; set; }


    }
}
