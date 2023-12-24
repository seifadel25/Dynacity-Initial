using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;

namespace DynacityFront.DTO
{
    public class EventCreateDTO
    {
        [Required]
        public string EventName { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }

        [MaxLength(500)]
        public string Description { get; set; }

        public string Address { get; set; }

        public string EventUrl { get; set; }
        public string EventPhotoURL { get; set; }


        public IFormFile EventPhoto { get; set; }
    }
}