
using System.ComponentModel.DataAnnotations.Schema;

namespace Booking.Models
{
    [Table(name: "Booking_Event_Extension")]
    public class EventExtension : BaseModel
    {
        public int Id { get; set; }
        public int Price { get; set; }
        public virtual Event Event { get; set; }
    }
}
