using Search.Models;
using System.Collections.Generic;

namespace Interface.Search
{
    public interface ISearchImplementation
    {

        /// <summary>Finds the schedules.</summary>
        /// <param name="place">The place.</param>
        /// <returns>List of Schedules</returns>
        List<Schedule> FindSchedules(string place);
    }
}
