
using System.ComponentModel.DataAnnotations.Schema;
using Booking.Utilities.Enums;


namespace Booking.Models
{
    [Table(name: "MultiMedia_Type")]
    public class MultiMediaType : BaseModel
    {
        public int Id { get; set; }
        public MultiMediaTypes Type { get; set; }
      
    }
}
