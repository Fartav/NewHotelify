using System;

namespace Booking.Models
{
    public class BaseModel
    {
        public DateTime? CreateDate { get; set; }
        public DateTime? ModifyDate { get; set; }
        public DateTime? DeleteDate { get; set; }
        public long? CreateDateTicks { get; set; }
        public long? ModifyDateTicks { get; set; }
        public long? DeleteDateTicks { get; set; }
        public bool IsDeleted { get; set; }
    }
}
