using Ticket.Models;

namespace TicketUnitTesting
{
    public static class DbContextExtension
    {
        public static void Seed(this FlightDbContext db)
        {
            db.Passengers.Add(new Passenger
            {
                PassengerName = "DEF",
                PassengerAge = 5,
                Meal = "NonVeg",
                Seat = "8B",
                Trip = "Oneway",
                Pnr = "8bff2e6e-a4d2-4a74-a469-e077ab9d6451"
            });

            db.Passengers.Add(new Passenger
            {
                PassengerName = "FEH",
                PassengerAge = 4,
                Meal = "Veg",
                Seat = "9C",
                Trip = "Oneway",
                Pnr = "02078922-a226-43c2-b5d5-a77420f295af"
            });

            db.SaveChanges();
        }

       
    }
}
