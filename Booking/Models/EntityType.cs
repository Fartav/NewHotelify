
using System.ComponentModel.DataAnnotations.Schema;

namespace Booking.Models
{
    [Table(name: "Booking_EntityType")]
    public class EntityType : BaseModel
    {
        public int Id { get; set; }
        public string TypeName { get; set; }

    }
}
