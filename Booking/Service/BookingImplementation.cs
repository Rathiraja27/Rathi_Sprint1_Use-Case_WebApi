using Booking.Interfaces;
using Booking.Models;
using Booking.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;

/// <summary>
/// Web Api to add and fetch Booking details from the database
/// </summary>
namespace Booking.Service
{
    public class BookingImplementation : IBookingImplementation
    {
        #region Variable Declaration

        FlightDbContext _db;

        #endregion

        #region Constructor

        /// <summary>Initializes a new instance of the <see cref="BookingImplementation" /> class.</summary>
        /// <param name="db">The database.</param>
        public BookingImplementation(FlightDbContext db)
        {
            _db = db;
        }

        #endregion

        #region Public Methods

        /// <summary>Adds the booking Details.</summary>
        /// <param name="bookingView">The booking Details.</param>
        public void AddBooking(BookingViewModel bookingView)
        {
            Models.Booking booking = new Models.Booking();
            Passenger pass = new Passenger();
            try
            {
                booking.Email = bookingView.Email;
                booking.CustomerName = bookingView.CustomerName;
                booking.FlightId = bookingView.FlightId;
                booking.SeatsToBook = bookingView.SeatsToBook;
                booking.BookedOn = DateTime.Now;
                _db.Bookings.Add(booking);


                for (int i = 0; i < bookingView.passengers.Count; i++)
                {
                    pass.PassengerId = new Int32();
                    pass.PassengerName = bookingView.passengers[i].PassengerName;
                    pass.PassengerAge = bookingView.passengers[i].PassengerAge;
                    pass.BookingId = pass.BookingId = _db.Bookings.OrderBy(x => x.BookingId).Select(x => i == 0 ? x.BookingId + 1 : x.BookingId).LastOrDefault();
                    pass.Meal = bookingView.passengers[i].Meal;
                    pass.Seat = bookingView.passengers[i].Seat;
                    pass.Trip = bookingView.passengers[i].Trip;
                    Random random = new Random();
                    long ran = random.Next(1000000, 9999999);
                    pass.Pnr = ran.ToString();

                    _db.Passengers.Add(pass);
                    _db.SaveChanges();
                }
            }
            catch
            {
                throw;
            }
        }


        /// <summary>Gets the booking by email.</summary>
        /// <param name="email">The email.</param>
        /// <returns>List of Bookings</returns>s
        public List<BookingViewModel> GetBookingByEmail(string email)
        {
            List<BookingViewModel> lstbookingView = new List<BookingViewModel>();
            var book = _db.Bookings.Where(x => x.Email == email).ToList();

            try
            {
                foreach (Models.Booking booking in book)
                {
                    BookingViewModel item = new BookingViewModel();
                    item.CustomerName = booking.CustomerName;
                    item.Email = booking.Email;
                    item.SeatsToBook = Convert.ToInt32(booking.SeatsToBook);
                    item.FlightId = Convert.ToInt32(booking.FlightId);
                    item.BookedOn = Convert.ToDateTime(booking.BookedOn);

                    List<PassengerViewModel> lstpassengerView = GetPassengers(booking.BookingId);
                    item.passengers = lstpassengerView;
                    lstbookingView.Add(item);
                }
            }
            catch
            {
                throw;
            }

            return lstbookingView;
        }


        /// <summary>Gets the passengers.</summary>
        /// <param name="bookingId">The booking identifier.</param>
        /// <returns>List of Passenger details based on the booking Id</returns>
        private List<PassengerViewModel> GetPassengers(int bookingId)
        {
            List<PassengerViewModel> lstpassengerView = new List<PassengerViewModel>();

            foreach (Passenger pass in _db.Passengers)
            {
                if (bookingId == pass.BookingId)
                {
                    PassengerViewModel passen = new PassengerViewModel();
                    passen.BookingId = Convert.ToInt32(pass.BookingId);
                    passen.PassengerAge = Convert.ToInt32(pass.PassengerAge);
                    passen.PassengerName = pass.PassengerName;
                    passen.Meal = pass.Meal;
                    passen.Seat = pass.Seat;
                    passen.Trip = pass.Trip;
                    passen.Pnr = pass.Pnr;
                    lstpassengerView.Add(passen);
                }
            }

            return lstpassengerView;
        }


        /// <summary>Cancels the booking using the PNR.</summary>
        /// <param name="pnr">The PNR.</param>
        public void CancelBooking(string pnr)
        {
            try
            {
                var data = _db.Passengers.Where(x => x.Pnr == pnr).FirstOrDefault();
                _db.Passengers.Remove(data);
                _db.SaveChanges();
            }
            catch
            {
                throw;
            }
           
        }

        #endregion
    }
}
