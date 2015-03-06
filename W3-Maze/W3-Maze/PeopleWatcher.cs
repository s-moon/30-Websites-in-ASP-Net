using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace W3_Maze
{
    /// <summary>
    /// Keep track of which users are in the same location as player is.
    /// </summary>
    public class PeopleWatcher
    {
        // Each element represents the number of people in that room
        private int[] peopleInLocation = null;

        /// <summary>
        /// Creating a set of locations of size "locations".
        /// </summary>
        /// <param name="locations"></param>
        public PeopleWatcher(int locations)
        {
            if (locations < 1)
            {
                throw new ArgumentException("Argument must be 1 or greater.");
            }

            Locations = locations;
            peopleInLocation = new int[locations];
        }

        /// <summary>
        /// Total number of locations within the map.
        /// </summary>
        public int Locations { get; private set; }

        /// <summary>
        /// Used when a new entrant joins the map to register their presence.
        /// </summary>
        /// <param name="loc"></param>
        public void AppearAtLocation(int loc)
        {
            if (loc < 0 || loc >= Locations)
            {
                throw new ArgumentOutOfRangeException("Location must be between 0 and " + (Locations - 1));
            }

            peopleInLocation[loc] += 1;
        }

        /// <summary>
        /// Moving from one location to another within the map.
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        public void GoToLocationFromAnother(int from, int to)
        {
            if (Math.Min(from, to) < 0 || Math.Max(from, to) > Locations - 1)
            {
                throw new ArgumentOutOfRangeException("Location must be between 0 and " + (Locations - 1));
            }

            if (from != to)
            {
                peopleInLocation[from] -= 1;
                peopleInLocation[to] += 1;
            }
        }

        /// <summary>
        /// The number of people at a given location.
        /// </summary>
        /// <param name="location"></param>
        /// <returns></returns>
        public int NumberOfPeopleAtLocation(int loc)
        {
            if (loc < 0 || loc >= Locations)
            {
                throw new ArgumentOutOfRangeException("Location must be between 0 and " + (Locations - 1));
            }
            return peopleInLocation[loc];
        }

        /// <summary>
        /// Viewable version of the people in locations.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return String.Join(",", peopleInLocation);
        }
    }
}