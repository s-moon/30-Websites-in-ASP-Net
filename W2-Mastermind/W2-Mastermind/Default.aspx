<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="W2_Mastermind.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
  <title>W2 - Mastermind  - logicalmoon.com</title>
  <link rel="stylesheet" type="text/css" href="StyleSheet.css" />
</head>
<body>
  <form id="form1" runat="server">
    <h1>Mastermind</h1>
    <section class="control-buttons">
      <asp:Button ID="guessButton" runat="server" Text="Make A Guess" OnClick="guessButton_Click" />
      <asp:Button ID="startAgainButton" Style="float: right" runat="server" Text="Start Again" OnClick="startAgainButton_Click" />
    </section>
    <section class="buttons">
      <fieldset>
        <legend>1st Colour</legend>
        <asp:RadioButtonList ID="Colour1" runat="server" RepeatDirection="Horizontal">
          <asp:ListItem Selected="True" Value="R">Red</asp:ListItem>
          <asp:ListItem Value="O">Orange</asp:ListItem>
          <asp:ListItem Value="Y">Yellow</asp:ListItem>
          <asp:ListItem Value="G">Green</asp:ListItem>
          <asp:ListItem Value="B">Blue</asp:ListItem>
          <asp:ListItem Value="P">Purple</asp:ListItem>
        </asp:RadioButtonList>
      </fieldset>
    </section>
    <section class="buttons">
      <fieldset>
        <legend>2nd Colour</legend>
        <asp:RadioButtonList ID="Colour2" runat="server" RepeatDirection="Horizontal">
          <asp:ListItem Selected="True" Value="R">Red</asp:ListItem>
          <asp:ListItem Value="O">Orange</asp:ListItem>
          <asp:ListItem Value="Y">Yellow</asp:ListItem>
          <asp:ListItem Value="G">Green</asp:ListItem>
          <asp:ListItem Value="B">Blue</asp:ListItem>
          <asp:ListItem Value="P">Purple</asp:ListItem>
        </asp:RadioButtonList>
      </fieldset>
    </section>
    <section class="buttons">
      <fieldset>
        <legend>3rd Colour</legend>
        <asp:RadioButtonList ID="Colour3" runat="server" RepeatDirection="Horizontal">
          <asp:ListItem Selected="True" Value="R">Red</asp:ListItem>
          <asp:ListItem Value="O">Orange</asp:ListItem>
          <asp:ListItem Value="Y">Yellow</asp:ListItem>
          <asp:ListItem Value="G">Green</asp:ListItem>
          <asp:ListItem Value="B">Blue</asp:ListItem>
          <asp:ListItem Value="P">Purple</asp:ListItem>
        </asp:RadioButtonList>
      </fieldset>
    </section>
    <section class="buttons">
      <fieldset>
        <legend>4th Colour</legend>
        <asp:RadioButtonList ID="Colour4" runat="server" RepeatDirection="Horizontal">
          <asp:ListItem Selected="True" Value="R">Red</asp:ListItem>
          <asp:ListItem Value="O">Orange</asp:ListItem>
          <asp:ListItem Value="Y">Yellow</asp:ListItem>
          <asp:ListItem Value="G">Green</asp:ListItem>
          <asp:ListItem Value="B">Blue</asp:ListItem>
          <asp:ListItem Value="P">Purple</asp:ListItem>
        </asp:RadioButtonList>
      </fieldset>
    </section>
    <section>
      <asp:Label ID="sequenceLabel" runat="server" Text="Sequence" ForeColor="White"></asp:Label><br />
      <a href="http://en.wikipedia.org/wiki/Mastermind_%28board_game%29#Gameplay_and_rules">Rules</a><br />
      <p><strong>KEY:-</strong></p>
      <img style="vertical-align: middle" src="Assets/X.png" />...Right Colour, Right Place<br />
      <img style="vertical-align: middle" src="Assets/-.png" />...Right Colour, Wrong Place<br />
      <br />
    </section>
    <section class="results">
      <asp:Table ID="resultTable" runat="server" HorizontalAlign="Center" Width="450px">
        <asp:TableRow>
          <asp:TableHeaderCell>Guess #</asp:TableHeaderCell>
          <asp:TableHeaderCell>G1</asp:TableHeaderCell>
          <asp:TableHeaderCell>G2</asp:TableHeaderCell>
          <asp:TableHeaderCell>G3</asp:TableHeaderCell>
          <asp:TableHeaderCell>G4</asp:TableHeaderCell>
          <asp:TableHeaderCell>Result</asp:TableHeaderCell>
        </asp:TableRow>
      </asp:Table>
    </section>
  </form>
  <footer class="credits">
    <p><small>Created by <a href="http://www.logicalmoon.com/">Stephen Moon</a></small></p>
  </footer>
</body>
</html>
