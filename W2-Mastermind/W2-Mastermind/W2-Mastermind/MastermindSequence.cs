using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace W2_Mastermind
{
    public class MastermindSequence
    {
        // These are the only valid colour codes -- red, orange, yellow, green, blue and purple
        public const string VALID_COLOUR_CODES = "ROYGBP";

        // Only valid result codes:
        //
        // W - You've done it! Well done.
        // X - Right Colour Right Place
        // - - Right Colour Wrong Place
        public const string VALID_RESULT_CODES = "WX-";
        public const string RIGHT_COLOUR_RIGHT_PLACE = "X";
        public const string RIGHT_COLOUR_WRONG_PLACE = "-";
        public const string WIN = "W";

        // Used to ignore colour codes when checking
        private const char BLANK_CODE = 'U';

        /// <summary>
        /// Build a colour sequence of size 'number'.
        /// </summary>
        /// <param name="number"></param>
        public MastermindSequence(int number)
        {
            this.Sequence = GetRandomSequence(number);
        }

        /// <summary>
        /// Set the colour sequence to be 'sequence'.
        /// </summary>
        /// <param name="sequence"></param>
        public MastermindSequence(string sequence)
        {
            this.Sequence = sequence;
        }

        /// <summary>
        /// Property for the colour sequence.
        /// </summary>
        public string Sequence { get; set; }

        /// <summary>
        /// Given a guess and an existing sequence of colours, score that guess by
        /// returning an string of X (Right Colour, Right Place), - (Right Colour, Wrong Place) or blank (Miss).
        /// </summary>
        /// <param name="guess"></param>
        /// <returns></returns>
        public string ScoreGuess(string guess)
        {
            string result = "";

            // Null reference
            if (guess == null)
            {
                throw new ArgumentException("ScoreGuess: null parameter passed");
            }

            // Guess must be the same length as the code or there is something awry
            if (guess.Length != this.Sequence.Length)
            {
                throw new ArgumentException("ScoreGuess: Length of parameter doesn't match sequence stored");
            }

            // Turn these strings into arrays - we will need to remove elements
            char[] sequenceCopy = this.Sequence.ToCharArray();
            char[] guessCopy = guess.ToCharArray();

            // Match against all the RightColourRightPlace ones first
            for (int i = 0; i < guessCopy.Length; i++)
            {
                if (guessCopy[i] == sequenceCopy[i])
                {
                    // We need to blank out the ones we have matched so we don't double count
                    sequenceCopy[i] = BLANK_CODE;
                    guessCopy[i] = BLANK_CODE;

                    // Label this as a Right Colour Right Place in the results
                    result += RIGHT_COLOUR_RIGHT_PLACE;
                }
            }

            // what should be left are right colour, wrong place, and just plain old wrong!
            for (int i = 0; i < guessCopy.Length; i++)
            {
                if (guessCopy[i] != BLANK_CODE)
                {
                    for (int j = 0; j < sequenceCopy.Length; j++)
                    {
                        if (guessCopy[i] == sequenceCopy[j])
                        {
                            guessCopy[i] = BLANK_CODE;
                            sequenceCopy[j] = BLANK_CODE;

                            result += RIGHT_COLOUR_WRONG_PLACE;

                            // get out of inner for loop
                            break;
                        }
                    }
                }
            }

            return result;
        }

        /// <summary>
        /// Pretty print the object
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.Sequence;
        }

        /// <summary>
        /// Using just valid colour codes and a number of codes to return, create a new sequence for Mastermind
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        private string GetRandomSequence(int number)
        {
            Random random = new Random(DateTime.Now.Millisecond);
            string result = "";

            for (int i = 0; i < number; i++)
            {
                result += VALID_COLOUR_CODES[random.Next(0, number)];
            }
            return result;
        }
    }
}