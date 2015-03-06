using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace W3_Maze
{
    [Serializable]
    public class Location
    {
        public String Description { get; set; }
        public int LocationNumber { get; set; }
        public int LocationNorth { get; set; }
        public int LocationEast { get; set; }
        public int LocationSouth { get; set; }
        public int LocationWest { get; set; }

        private Location()
        {
            // Force other constructor to be used.
        }

        public Location(int num, String desc, int north, int east, int south, int west)
        {
            if (desc == null)
            {
                throw new ArgumentNullException("Must provide a valid location description.");
            }

            LocationNumber = num;
            Description = desc;
            LocationNorth = north;
            LocationEast = east;
            LocationSouth = south;
            LocationWest = west;
        }

        public override string ToString()
        {
            return "(" + LocationNumber + "): " + Description + "[" + LocationNorth + ","
                + LocationEast + "," + LocationWest + "," + LocationSouth + "]";
        }
    }
}