using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Exceptions
{
    class BookingExceptions : Exception
    {
        public BookingExceptions() { }
        public BookingExceptions(string message) : base(message) { }
        public BookingExceptions(string message, Exception inner) : base(message, inner) { }
    }
}
