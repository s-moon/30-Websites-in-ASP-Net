<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="W1_RockPaperScissors.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
  <title>W1 - Rock, Paper, Scissors - logicalmoon.com</title>
  <link href="styles.css" rel="stylesheet" type="text/css" />
</head>
<body>
  <form id="form1" runat="server">
    <div>
      <h1>Rock, Paper, Scissors</h1>
      <h2>By Stephen Moon, 2015</h2>
      <section >
        <table class="choices">
          <tr>
            <th>YOU</th>
            <th></th>
            <th>COMPUTER</th>
          </tr>
          <tr>
            <td class="choices-item">
              <asp:Image  ID="yourChoiceImage" runat="server" ImageUrl="~/Assets/question-mark.png" /></td>
            <td class="choices-item">&nbsp;VERSUS&nbsp;</td>
            <td class="choices-item">
              <asp:Image class="choices-image" ID="computerChoiceImage" runat="server" ImageUrl="~/Assets/question-mark.png" /></td>
          </tr>
          
        </table>
      </section>
      <hr />
      <section class="player-buttons">
        <asp:ImageButton class="player-button" ID="rockImageButton" runat="server" ImageUrl="~/Assets/rock.png" OnClick="rockImageButton_Click" />
        <asp:ImageButton class="player-button" ID="paperImageButton" runat="server" ImageUrl="~/Assets/paper.png" OnClick="paperImageButton_Click" />
        <asp:ImageButton class="player-button" ID="scissorsImageButton" runat="server" ImageUrl="~/Assets/scissors.png" OnClick="scissorsImageButton_Click" />
      </section>
      <section class="instructions">
        <p>To play, click one of the three buttons in dotted boxes above. The result of your game will be shown below. Good luck!</p>
      </section>
      <section class="results-text">
        <asp:Label ID="resultLabel" runat="server" Style="font-size: xx-large; text-align: center; color: #FF0000" Text="Result is...."></asp:Label>
      </section>
      <footer class="credits">
        <p><small>Created by <a href="http://www.logicalmoon.com/">Stephen Moon</a></small></p>
      </footer>
    </div>
  </form>
</body>
</html>
