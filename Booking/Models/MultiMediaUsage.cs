
using System.ComponentModel.DataAnnotations.Schema;



namespace Booking.Models
{
    [Table(name: "MultiMedia_Usage")]
    public class MultiMediaUsage : BaseModel
    {
        public int Id { get; set; }
        public int TableId { get; set; }
        public string TableName { get; set; }
        public virtual MultiMedia MultiMedia { get; set; }
      
    }
}
