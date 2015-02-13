using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace W2_Mastermind
{
    /// <summary>
    /// Class used to hold guesses and the results for the game. Needs to be serializable because this
    /// class will be added to an array and used in the ViewState
    /// </summary>
    [Serializable]
    public class MastermindGuess
    {
        public MastermindGuess (string aGuess, string aResult)
        {
            this.Guess = aGuess;
            this.Result = aResult;
        }

        public string Guess { get; set; }

        public string Result { get; set; }
    }
}