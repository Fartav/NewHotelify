
using System.ComponentModel.DataAnnotations.Schema;



namespace Booking.Models
{
    [Table(name: "ResidenceType")]
    public class ResidenceType : BaseModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

    }
}
