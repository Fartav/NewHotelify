using System;
using Booking.Utilities.Enums;

namespace Booking.Models
{
    class EventTimeSlice : BaseModel
    {
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDateTime { get; set; }
        public DateType Type { get; set; }
        public Event Event { get; set; }
    }
}
