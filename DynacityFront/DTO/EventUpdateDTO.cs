using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;

namespace DynacityFront.DTO
{
    public class EventUpdateDTO
    {
        public int EventId { get; set; }

        public string EventName { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public string Description { get; set; }

        public string Address { get; set; }

        public string EventUrl { get; set; }
        public string EventPhotoURL { get; set; }


        public IFormFile EventPhoto { get; set; }
    }
}