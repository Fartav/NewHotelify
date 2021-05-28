using System;
using System.ComponentModel.DataAnnotations.Schema;



namespace Booking.Models
{
    [Table(name: "Residence")]
    public class Residence : BaseModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
        public string Address { get; set; }
        public virtual MultiMedia MultiMedia { get; set; }
        // Removed to fix relation for now
        //public virtual HotelClass HotelClass { get; set; }
        public virtual ResidenceType ResidenceType { get; set; }

    }
}
