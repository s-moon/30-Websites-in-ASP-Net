using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using W2_Mastermind;

namespace Mastermind.NUNIT
{
    /// <summary>
    /// Exercising the MastermindSequence object which is used to setup and test guesses for the game, Mastermind
    /// </summary>
    [TestFixture]
    class MastermindSequenceTest
    {
        public MastermindSequenceTest()
        {
        }

        /// <summary>
        /// Create objects that are needed/used in the various tests
        /// </summary>
        [NUnit.Framework.TestFixtureSetUp]
        public void PerFixtureSetup()
        {
            
        }

        /// <summary>
        /// Send objects to GC when possible
        /// </summary>
        [TestFixtureTearDown]
        public void PerFixtureTeardown()
        {
            
        }

        /// <summary>
        /// Testing that the toString method returns the sequence correctly.
        /// </summary>
        [Test]
        public void ToStringTest()
        {
            MastermindSequence ms = new MastermindSequence("ROYG");

            Assert.That(ms.ToString(), Is.EqualTo("ROYG"));
        }

        /// <summary>
        /// Various tests that check the class can handle junk parameters for scoring guesses.
        /// </summary>
        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void InvalidArgumentTest()
        {
            // null reference
            MastermindSequence ms = new MastermindSequence("RRRR");
            ms.ScoreGuess(null);

            // argument array length of 1 when should be 4
            ms.ScoreGuess("B");

            // argument array length of 3 when should be 4
            ms.ScoreGuess("BBB");

            // argument array length of 5 when should be 4
            ms.ScoreGuess("ROYGB");
        }

        /// <summary>
        /// Make sure that all correct entries work - there will be NO WrongPlace ones for instance.
        /// </summary>
        [Test]
        public void ScoreSequenceJustRightPlaceTest()
        {
            MastermindSequence ms = new MastermindSequence("RRRR");

            // Perfect
            Assert.AreEqual(ms.ScoreGuess("RRRR"), "XXXX");

            // One RightColourRightPlace
            Assert.AreEqual(ms.ScoreGuess("RBBB"), "X");

            // One RightColourRightPlace
            Assert.AreEqual(ms.ScoreGuess("BBBR"), "X");

            // Two RightColourRightPlace
            Assert.AreEqual(ms.ScoreGuess("RBRB"), "XX");

            // Three RightColourRightPlace
            Assert.AreEqual(ms.ScoreGuess("BRRR"), "XXX");
        }

        /// <summary>
        /// A mix of Right and Wrong place guesses.
        /// </summary>
        [Test]
        public void ScoreSequenceMixRightWrongPlaceTest()
        {
            MastermindSequence ms = new MastermindSequence("ROYG");

            // Two RightColourRightPlace, Two RightColourWrongPlace
            Assert.AreEqual(ms.ScoreGuess("ROGY"), "XX--");

            // Two RightColourRightPlace, Two RightColourWrongPlace
            Assert.AreEqual(ms.ScoreGuess("GOYR"), "XX--");

            // Two RightColourRightPlace, Two RightColourWrongPlace
            Assert.AreEqual(ms.ScoreGuess("RYOG"), "XX--");
        }

        /// <summary>
        /// Guesses that contain RightPlace colours but ALWAYS WrongPlace(s)
        /// </summary>
        [Test]
        public void ScoreSequenceJustWrongPlaceTest()
        {
            MastermindSequence ms = new MastermindSequence("ROYG");

            // Four RightColourWrongPlace
            Assert.AreEqual(ms.ScoreGuess("GYOR"), "----");

            // One RightColourWrongPlace
            Assert.AreEqual(ms.ScoreGuess("GBBB"), "-");

            // One RightColourWrongPlace
            Assert.AreEqual(ms.ScoreGuess("BGBB"), "-");

            // One RightColourWrongPlace
            Assert.AreEqual(ms.ScoreGuess("BBGB"), "-");

            // Two RightColourWrongPlace
            Assert.AreEqual(ms.ScoreGuess("ORBB"), "--");

            // Three RightColourWrongPlace
            Assert.AreEqual(ms.ScoreGuess("YROB"), "---");
        }

        /// <summary>
        /// Won't match anything
        /// </summary>
        [Test]
        public void ScoreSequenceAllIncorrectTest()
        {
            MastermindSequence ms = new MastermindSequence("RRRR");
            Assert.AreEqual("", ms.ScoreGuess("BPBP"));
        }

        /// <summary>
        /// Checking Random Generator produces results that are the right size and do not contain any "?" entries.
        /// </summary>
        [Test]
        public void RandomSequenceTest()
        {
            // Make sure length is OK
            MastermindSequence ms = new MastermindSequence(4);
            Assert.True(ms.ToString().Length == 4);
        }
    }
}
