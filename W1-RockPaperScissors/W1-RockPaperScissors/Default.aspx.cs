using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace W1_RockPaperScissors
{
    public enum GameChoice { rock, paper, scissors };

    public partial class Default : System.Web.UI.Page
    {
        protected GameChoice playerOption { get; set; }
        protected GameChoice computerOption { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void rockImageButton_Click(object sender, ImageClickEventArgs e)
        {
            MakeGameChoices(GameChoice.rock);
            DisplayResult();
        }

        protected void paperImageButton_Click(object sender, ImageClickEventArgs e)
        {
            MakeGameChoices(GameChoice.paper);
            DisplayResult();
        }

        protected void scissorsImageButton_Click(object sender, ImageClickEventArgs e)
        {
            MakeGameChoices(GameChoice.scissors);
            DisplayResult();
        }

        private void DisplayResult()
        {
            if (playerOption == computerOption) // two choices the same
            {
                resultLabel.Text = "DRAW!";
            }
            else if ( // options for what will produce a win
                (playerOption == GameChoice.rock && computerOption == GameChoice.scissors)
                ||
                (playerOption == GameChoice.paper && computerOption == GameChoice.rock)
                ||
                (playerOption == GameChoice.scissors && computerOption == GameChoice.paper)
                )
            {
                resultLabel.Text = "WIN!";
            }
            else // everything else must be a draw
            {
                resultLabel.Text = "LOSE!";
            }
        }

        // main steps for playing the game
        // given a player's choice, make the choice for the computer
        private void MakeGameChoices(GameChoice player)
        {
            playerOption = player;
            yourChoiceImage.ImageUrl = GameChoiceToAssetURL(playerOption);

            computerOption = ChooseComputerResponse();
            computerChoiceImage.ImageUrl = GameChoiceToAssetURL(computerOption);
        }

        // method to make a random choice out of 1, 2, 3 for the computer
        // which is then mapped to the enumerated type: GameChoice
        private GameChoice ChooseComputerResponse()
        {
            GameChoice[] choices = { GameChoice.rock, GameChoice.paper, GameChoice.scissors };
            Random rnd = new Random();
            int randomResult = rnd.Next(1, 4);
            return choices[randomResult - 1];
        }

        // mapping GameChoice's to actual images in the assets folder
        private string GameChoiceToAssetURL(GameChoice gc)
        {
            string PREFIX = "Assets/";

            if (gc == GameChoice.rock)
            {
                return PREFIX + "rock.png";
            } 
            else if (gc == GameChoice.paper)
            {
                return PREFIX + "paper.png";
            }
            else
            {
                return PREFIX + "scissors.png";
            }
        }
    }
}