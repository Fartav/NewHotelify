using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Booking.Utilities.Enums;

namespace Booking.Models
{
    [Table(name: "Booking_Reserves")]
    public class ReservedDates : BaseModel
    {
        public int Id { get; set; }
        public virtual Event Event { get; set; }
        public DateType Type { get; set; }
        public DateTime ReserveDateStart { get; set; }
        public DateTime ReserveDateEnd { get; set; }
        public long? ReserveDateStartTicks { get; set; }
        public long? ReserveDateEndTicks { get; set; }
        public int Count { get; set; }
        public int IsCanceled { get; set; }
        public int IsFinal { get; set; }
    }
}
