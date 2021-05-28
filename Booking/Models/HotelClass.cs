
using System.ComponentModel.DataAnnotations.Schema;


namespace Booking.Models
{
    [Table(name: "Hotel_Class")]
    public class HotelClass : BaseModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int StartNumber { get; set; }
        // Removing virtual to bypass scaffolding
        //public virtual Residence Residence { get; set; }
        public Residence Residence { get; set; }

    }
}
