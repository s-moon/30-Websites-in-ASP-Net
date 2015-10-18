using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NUnit.Framework;

namespace HowLongSanta.Models.Test
{
    [TestFixture]
    public class DurationTest
    {
        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void DatesTooFarApart()
        {
            Duration d = new Duration();
            d.StartDate = new DateTime(2015, 1, 1);
            d.EndDate = new DateTime(2016, 1, 3);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void StartDateNotSetForDaysToWait()
        {
            Duration d = new Duration();
            d.EndDate = new DateTime(2016, 1, 3);
            Console.WriteLine(d.DaysToWait);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void EndDateNotSetForDaysToWait()
        {
            Duration d = new Duration();
            d.StartDate = new DateTime(2016, 1, 3);
            Console.WriteLine(d.DaysToWait);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void EndDateNotSetForTotalDaysSinceAnniversaryOneYearAgo()
        {
            Duration d = new Duration();
            d.StartDate = new DateTime(2016, 1, 3);
            Console.WriteLine(d.TotalDaysSinceAnniversaryOneYearAgo);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void StartDateNotSetForTotalDaysSinceAnniversaryOneYearAgo()
        {
            Duration d = new Duration();
            d.EndDate = new DateTime(2016, 1, 3);
            Console.WriteLine(d.TotalDaysSinceAnniversaryOneYearAgo);
        }

        [Test]
        public void DaysToWaitTwoDays()
        {
            Duration d = new Duration();
            d.StartDate = new DateTime(2016, 1, 1);
            d.EndDate = new DateTime(2016, 1, 3);
            Assert.AreEqual(2, d.DaysToWait);
        }

        [Test]
        public void DaysToWaitUsingLeapYear()
        {
            Duration d = new Duration();
            d.StartDate = new DateTime(2000, 1, 1);
            d.EndDate = new DateTime(2001, 1, 1);
            Assert.AreEqual(366, d.DaysToWait);
        }

        [Test]
        public void DaysPassedSinceJan01ToDec31()
        {
            Duration d = new Duration();
            d.StartDate = new DateTime(2015, 1, 1);
            d.EndDate = new DateTime(2015, 12, 31);
            Assert.AreEqual(1, d.DaysPassed);
        }
    }
}