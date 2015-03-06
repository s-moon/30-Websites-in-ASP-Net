using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace W3_Maze.Test
{
    [TestFixture]
    class LocationTest
    {
        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Location_DoNotAllowNullDescriptions()
        {
            Location loc = new Location(0, null, 0, 0, 0, 0);
        }
    }
}
