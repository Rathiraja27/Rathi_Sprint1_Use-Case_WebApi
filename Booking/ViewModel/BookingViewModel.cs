using System;
using System.Collections.Generic;

namespace Booking.ViewModel
{
    public class BookingViewModel
    {
        public string CustomerName { get; set; }
        public string Email { get; set; }
        public int SeatsToBook { get; set; }
        public int FlightId { get; set; }
        public DateTime BookedOn { get; set; }
        public List<PassengerViewModel> passengers { get; set; }
    }
}
