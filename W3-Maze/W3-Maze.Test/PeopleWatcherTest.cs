using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace W3_Maze.Test
{
    [TestFixture]
    class PeopleWatcherTest
    {
        [Test]
        public void PeopleWatcher_CreatesCorrectNumberOfLocations()
        {
            PeopleWatcher pw = new PeopleWatcher(10);
            Assert.AreEqual(10, pw.Locations);
        }

        [Test]
        public void PeopleWatcher_NoPeopleThenOnePersonAtLocation()
        {
            PeopleWatcher pw = new PeopleWatcher(10);
            Assert.AreEqual(0, pw.NumberOfPeopleAtLocation(5));
            pw.AppearAtLocation(5);
            Assert.AreEqual(1, pw.NumberOfPeopleAtLocation(5));
        }

        [Test]
        public void PeopleWatcher_CorrectNumberOfPeoppleWhenMoveFromOneLocationToAnother()
        {
            PeopleWatcher pw = new PeopleWatcher(10);
            pw.AppearAtLocation(5);
            pw.GoToLocationFromAnother(5, 6);
            Assert.AreEqual(0, pw.NumberOfPeopleAtLocation(5));
            Assert.AreEqual(1, pw.NumberOfPeopleAtLocation(6));
        }

        [Test]
        public void PeopleWatcher_ToStringIsCorrect()
        {
            PeopleWatcher pw = new PeopleWatcher(3);
            Assert.AreEqual("0,0,0", pw.ToString());
        }
    
    }
}
