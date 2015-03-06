using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace W3_Maze
{
    [Serializable]
    public class PlayerLocation
    {
        // First array location, representing the start of the map
        private const int START_LOCATION = 0;

        public PlayerLocation()
        {
            CurrentLocation = START_LOCATION;
            LastLocation = START_LOCATION;
        }
        public int CurrentLocation { get; set; }
        public int LastLocation { get; set; }
    }
}