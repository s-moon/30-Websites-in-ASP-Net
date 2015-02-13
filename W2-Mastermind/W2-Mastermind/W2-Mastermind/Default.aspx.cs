using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace W2_Mastermind
{
    public partial class Default : System.Web.UI.Page
    {
        private MastermindSequence ms;
        ArrayList guessesMade;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Store the computer's colour sequence
                if (ViewState["Code"] == null)
                {
                    ms = new MastermindSequence(4);
                    ViewState["Code"] = ms.ToString();
                }
                sequenceLabel.Text = ViewState["Code"].ToString();

                // Keep track of all the guesses made by the user
                if (ViewState["GuessesMade"] == null)
                {
                    ViewState["GuessesMade"] = new ArrayList();
                }
            }
            else
            {
                // We have come back to the page after a guess has been made - restore key variables
                ms = new MastermindSequence(ViewState["Code"].ToString());
                guessesMade = (ArrayList)ViewState["GuessesMade"];
            }
        }

        /// <summary>
        /// Make a guess at what the colour sequence could be and update the display with the results
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void guessButton_Click(object sender, EventArgs e)
        {
            string lastGuess = Colour1.SelectedValue +
                Colour2.SelectedValue +
                Colour3.SelectedValue +
                Colour4.SelectedValue;
            int numberOfGuesses = guessesMade.Count + 1;

            // Get results and add to table
            //MastermindSequence.ColourItem[] ci = ms.MapStringsToColourItems(lastGuess);
            //String result = ms.MapResultItemsToStrings(ms.ScoreGuess(ci));
            String result = ms.ScoreGuess(lastGuess);
            guessesMade.Add(new MastermindGuess(lastGuess, result));
            ViewState["GuessesMade"] = guessesMade;

            BuildGuessListTable(guessesMade);
        }

        /// <summary>
        /// Reset all the variables for a new colour sequence
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void startAgainButton_Click(object sender, EventArgs e)
        {
            SetupGame();
        }

        private void SetupGame()
        {
            // Generate a new code
            ms = new MastermindSequence(4);
            ViewState["Code"] = ms.ToString();
            sequenceLabel.Text = ViewState["Code"].ToString();

            // Reset the guesses made
            guessesMade.Clear();
        }

        /// <summary>
        /// Generate the table of results dynamically based on guesses made. Note that it needs to keep
        /// recreating the table on each post back.
        /// </summary>
        /// <param name="guessesMade"></param>
        private void BuildGuessListTable(ArrayList guessesMade)
        {
            int lastGuess = guessesMade.Count;

            if (lastGuess == 0)
                return;

            for (int j = guessesMade.Count - 1; j >= 0; j--)
            {
                MastermindGuess mg = (MastermindGuess)guessesMade[j];
                TableRow tr = new TableRow();

                // Guess #
                lastGuess--;
                tr.Cells.Add(MakeTableCell(lastGuess.ToString()));

                // Fill in the guess colours
                for (int i = 0; i < 4; i++)
                {
                     tr.Cells.Add(MakeTableCell("<img src=\"" + CodeToAssetImageMap(mg.Guess[i]) + "\">"));
                }

                // Was it a winner?
                if (mg.Result == "XXXX")
                {
                    tr.Cells.Add(MakeTableCell("<img src=\"" + CodeToAssetImageMap('W') + "\">"));
                }
                // No, so just score it.
                else
                {
                    string text = "";
                    for (int i = 0; (mg.Result != "") && i < mg.Result.Length; i++)
                    {
                        text += "<img src=\"" + CodeToAssetImageMap(mg.Result[i]) + "\">"; 
                    }
                    tr.Cells.Add(MakeTableCell(text));
                }

                resultTable.Rows.Add(tr);
            }
        }

        /// <summary>
        /// Create a TableCell, fill in it's text and then return it.
        /// </summary>
        /// <param name="content"></param>
        /// <returns></returns>
        private TableCell MakeTableCell(string content)
        {
            TableCell tc = new TableCell();
            tc.Text = content;
            return tc;
        }

        /// <summary>
        /// Taking advantage of how assets have been named, build a reference to that graphical asset
        /// </summary>
        /// <param name="assetCode"></param>
        /// <returns></returns>
        private string CodeToAssetImageMap(char assetCode)
        {
            string prefix = "Assets/";

            if (!(MastermindSequence.VALID_COLOUR_CODES + MastermindSequence.VALID_RESULT_CODES).Contains(assetCode.ToString().ToUpper()))
            {
                throw new ArgumentException("CodeToAssetImageMap: invalid code passed: " + assetCode);
            }

            return prefix + assetCode + ".png";
        }
    }
}