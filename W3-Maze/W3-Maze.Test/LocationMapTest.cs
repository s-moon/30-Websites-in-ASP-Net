using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace W3_Maze.Test
{
    [TestFixture]
    class LocationMapTest
    {
        [Test]
        public void LocationMap_CorrectNumberOfRooms()
        {
            LocationMap m = new LocationMap();
            Assert.IsTrue(m.LocationCount == 12);
        }

        [Test]
        public void LocationMap_CanGoNorth()
        {
            LocationMap m = new LocationMap();
            PlayerLocation pl = new PlayerLocation();
            pl.CurrentLocation = 1;
            m.Player = pl;
            Assert.IsTrue(m.CanGo(Direction.North));
        }

        [Test]
        public void LocationMap_CantGoNorth()
        {
            LocationMap m = new LocationMap();
            PlayerLocation pl = new PlayerLocation();
            pl.CurrentLocation = 0;
            m.Player = pl;
            Assert.IsFalse(m.CanGo(Direction.North));
        }

        [Test]
        public void LocationMap_CanGoEast()
        {
            LocationMap m = new LocationMap();
            PlayerLocation pl = new PlayerLocation();
            pl.CurrentLocation = 3;
            m.Player = pl;
            Assert.IsTrue(m.CanGo(Direction.East));
        }

        [Test]
        public void LocationMap_CantGoEast()
        {
            LocationMap m = new LocationMap();
            PlayerLocation pl = new PlayerLocation();
            pl.CurrentLocation = 0; 
            m.Player = pl; 
            Assert.IsFalse(m.CanGo(Direction.East));
        }

        [Test]
        public void LocationMap_CanGoSouth()
        {
            LocationMap m = new LocationMap();
            PlayerLocation pl = new PlayerLocation();
            pl.CurrentLocation = 0;
            m.Player = pl;
            Assert.IsTrue(m.CanGo(Direction.South));
        }

        [Test]
        public void LocationMap_CantGoSouth()
        {
            LocationMap m = new LocationMap();
            PlayerLocation pl = new PlayerLocation();
            pl.CurrentLocation = 4;
            m.Player = pl;
            Assert.IsFalse(m.CanGo(Direction.South));
        }

        [Test]
        public void LocationMap_CanGoWest()
        {
            LocationMap m = new LocationMap();
            PlayerLocation pl = new PlayerLocation();
            pl.CurrentLocation = 5;
            m.Player = pl;
            Assert.IsTrue(m.CanGo(Direction.West));
        }

        [Test]
        public void LocationMap_CantGoWest()
        {
            LocationMap m = new LocationMap();
            PlayerLocation pl = new PlayerLocation();
            pl.CurrentLocation = 4;
            m.Player = pl;
            Assert.IsFalse(m.CanGo(Direction.West));
        }
    }
}
