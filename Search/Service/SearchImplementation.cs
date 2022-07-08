using Interface.Search;
using Search.Models;
using System.Collections.Generic;
using System.Linq;

namespace Search.Service
{
    public class SearchImplementation : ISearchImplementation
    {
        #region Variable Declaration

        FlightDbContext _db;

        #endregion

        #region Constructor

        /// <summary>Initializes a new instance of the <see cref="SearchImplementation" /> class.</summary>
        /// <param name="db">The database.</param>
        public SearchImplementation(FlightDbContext db)
        {
            _db = db;
        }

        #endregion

        #region Public Methods

        /// <summary>Finds the schedules.</summary>
        /// <param name="place">The place.</param>
        /// <returns>List of Schedules</returns>
        public List<Schedule> FindSchedules(string place)
        {
            return  _db.Schedules.Where(x => x.FromPlace == place).ToList();
        }

        #endregion
    }
}
