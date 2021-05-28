using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Booking.Utilities.Enums;

namespace Booking.Models
{
    [Table(name: "Booking_Event")]
    public class Event : BaseModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public Host EventHost { get; set; }
        public EventType Type { get; set; }
        public int StartTime { get; set; }
        public int EndTime { get; set; }
        public ICollection<ClosedDates> EventClosedDates { get; set; }
        public int WorkingShifts { get; set; }
        public int WorkingTimes { get; set; }
        public int Capacity { get; set; }
        public int MultiReserveLimit { get; set; }
        public int TemporaryReserve { get; set; }
        //public virtual EventExtension EventExtension { get; set; }
    }
}
