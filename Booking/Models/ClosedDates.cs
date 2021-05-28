using System;
using System.ComponentModel.DataAnnotations.Schema;
using Booking.Utilities.Enums;

namespace Booking.Models
{
    [Table(name: "Booking_ClosedDates")]
    public class ClosedDates : BaseModel
    {
        public int Id { get; set; }
        public string Label { get; set; }
        public virtual Event Event { get; set; }
        public DateType Type { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public long? StartDateTicks { get; set; }
        public long? EndDateTicks { get; set; }
    }
}
