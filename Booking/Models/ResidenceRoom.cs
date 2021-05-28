using System;
using System.ComponentModel.DataAnnotations.Schema;



namespace Booking.Models
{
    [Table(name: "Residence_Room")]
    public class ResidenceRoom : BaseModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual Residence Residence { get; set; }
        public int Capacity { get; set; }
        public bool HasDinner { get; set; }
        public bool HasBreakfast { get; set; }
        public bool HasLunch { get; set; }
        public virtual MultiMedia MultiMedia { get; set; }

    }
}
