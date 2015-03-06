using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace W3_Maze
{
    public enum Direction { North, East, South, West };

    public class LocationMap
    {
        // Map location elements
        private Location[] gameMap;

        // Where the player is and where they last were
        public PlayerLocation Player { get; set; }

        public LocationMap()
        {   
            /*
             *   0
             *   1
             *  32 7
             *   456
             *     8
             *    A9B
             */
            // Map data. The last four arguments relate to the rooms which you can reach from travelling
            // north, east, south and west.
            // Dead ends are represented by -1, meaning, you can't go that way.
            gameMap = new Location[] {
                //                       
                new Location(0, "You are in a dingy hole. There is a strange smell.",  
                    -1,  -1,  1, -1),
                new Location(1, "You are standing in a large cave. You can see light to the south.",   
                    0,  -1,  2, -1),
                new Location(2, "A vast desert stretches before you.",   
                    1,  -1, 4,  3),
                new Location(3, "This is the Oompah Oasis - home of plentiful Pepsi-Max.",  
                    -1,   2, -1, -1),
                new Location(4, "You are in a dense, green forest. Many birds seem to be singing.",   
                    2,   5, -1, -1),
                new Location(5, "You are on a dusty path. There seems to be a city in the distance.",  
                    -1,   6, -1,  4),
                new Location(6, "You are in the city of MicroSafty. It is tremendous.",   
                    7,  -1,  8,  5),
                new Location(7, "You are in an inn. There is someone singing on a piano in the corner.",  
                    -1,  -1,  6, -1),
                new Location(8, "You are on a cobbled street. It is especially clean.",   
                    6,  -1,  9, -1),
                new Location(9, "You are in a courtyard. Tall buildings stand on all sides.",   
                    8,  11, -1, 10),
                new Location(10, "You have reached your destination. Well done!", 
                    -1,   9, -1, -1),
                new Location(11, "You seem to be getting lost. You aren't sure where you are.", 
                    -1,  -1, -1,  9)
            };
        }

        /// <summary>
        /// Determine whether player can potentially travel in a compass direction.
        /// </summary>
        /// <param name="d"></param>
        /// <returns></returns>
        public bool CanGo(Direction d)
        {
            return (getLocationFromDirection(d) != -1);
        }

        /// <summary>
        /// Actually do go in that direction. Checks for possibility first.
        /// </summary>
        /// <param name="d"></param>
        public void DoGo(Direction d)
        {
            if (CanGo(d))
            {
                Player.LastLocation = Player.CurrentLocation;
                Player.CurrentLocation = getLocationFromDirection(d);
            }
        }

        /// <summary>
        /// Return number of locations in this map.
        /// </summary>
        public int LocationCount
        {
            get { return gameMap.Length; }
        }

        /// <summary>
        /// Describe the current location as a string.
        /// </summary>
        /// <returns></returns>
        public string LocationDescription()
        {
            return gameMap[Player.CurrentLocation].Description;
        }

        /// <summary>
        /// If player went in direction X, which room (or dead end -1) would they find.
        /// </summary>
        /// <param name="d"></param>
        /// <returns></returns>
        private int getLocationFromDirection(Direction d)
        {
            int result = Int32.MinValue;

            switch (d)
            {
                case Direction.North:
                    result = gameMap[Player.CurrentLocation].LocationNorth;
                    break;
                case Direction.East:
                    result = gameMap[Player.CurrentLocation].LocationEast;
                    break;
                case Direction.South:
                    result = gameMap[Player.CurrentLocation].LocationSouth;
                    break;
                case Direction.West:
                    result = gameMap[Player.CurrentLocation].LocationWest;
                    break;
            }
            return result;
        }
    }
}