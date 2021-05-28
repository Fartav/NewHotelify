
using System.ComponentModel.DataAnnotations.Schema;

namespace Booking.Models
{
    [Table(name: "Booking_Entities")]
    public class Entities : BaseModel
    {
        public int Id { get; set; }
        public string EntityName { get; set; }
        public virtual Event Event { get; set; }
        public virtual EntityType EntityType { get; set; }

    }
}
