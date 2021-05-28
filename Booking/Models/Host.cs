
using System.ComponentModel.DataAnnotations.Schema;
using NetTopologySuite.Geometries;

namespace Booking.Models
{
    [Table(name: "Booking_Host")]
    public class Host : BaseModel
    {
        public int Id { get; set; }
        public int RegionId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string LocationLink { get; set; }
        public Point Location { get; set; }
        public string PostalCode { get; set; }
        public string PhoneNumber { get; set; }
        //public virtual HostExtension HostExtension { get; set; }
        //[NotMapped]
        //public List<long> PhoneNumbersList
        //{
        //    get
        //    {
        //        List<long> phoneNumbers = new List<long>();
        //        foreach(string phoneNumber in (PhoneNumbers.Split(',').ToList<string>()))
        //        {
        //            phoneNumbers.Add(long.Parse(phoneNumber));
        //        }
        //        return phoneNumbers;
        //    }
        //    set
        //    {
        //        List<string> phoneNumbers = new List<string>();
        //        foreach(long phoneNumber in value)
        //        {
        //            phoneNumbers.Add(phoneNumber.ToString());
        //        }
        //        PhoneNumbers = string.Join(",", phoneNumbers);
        //    }
        //}
    }
}
