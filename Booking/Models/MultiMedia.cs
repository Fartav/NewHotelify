
using System.ComponentModel.DataAnnotations.Schema;



namespace Booking.Models
{
    [Table(name: "MultiMedia")]
    public class MultiMedia : BaseModel
    {
        public int Id { get; set; }
        public string Path { get; set; }
        public virtual MultiMediaType MultiMediaType { get; set; }
      
    }
}
