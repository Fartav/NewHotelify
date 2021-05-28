
using System.ComponentModel.DataAnnotations.Schema;

namespace Booking.Models
{
    [Table(name: "Booking_Host_Extention")]
    public class HostExtension : BaseModel
    {
        public int Id { get; set; }
        public string Adress { get; set; }
        public virtual Host Host { get; set; }
    }
}
