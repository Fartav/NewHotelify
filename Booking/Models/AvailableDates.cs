using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Booking.Models
{
    // DateType.Hour
    [Table(name: "Booking_AvailableDates")]
    public class AvailableDates : BaseModel
    {
        public int Id { get; set; }
        public string Label { get; set; }
        public virtual Event Event { get; set; }
        public DateTime ReserveDateStart { get; set; }
        public DateTime ReserveDateEnd { get; set; }
        public long? ReserveDateStartTicks { get; set; }
        public long? ReserveDateEndTicks { get; set; }
    }
}
