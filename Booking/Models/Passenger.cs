using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace Booking.Models
{
    public partial class Passenger
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int PassengerId { get; set; }
        public string PassengerName { get; set; }
        public int? PassengerAge { get; set; }
        public string Meal { get; set; }
        public string Seat { get; set; }
        public string Trip { get; set; }
        public int? BookingId { get; set; }
        public string Pnr { get; set; }

        public virtual Booking Booking { get; set; }
    }
}
