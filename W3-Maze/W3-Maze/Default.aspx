<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="W3_Maze.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
  <title>W3 - Maze - Logicalmoon.com</title>
  <link rel="stylesheet" href="CSS/Style.css" type="text/css" />
  <script src="Scripts/jquery-2.1.3.min.js" type="text/javascript"></script>
  <script src="Scripts/maze.js" type="text/javascript"></script>
</head>
<body>
  <h1>Maze</h1>
  <form id="form1" runat="server">
    <div class="maze">
      <!-- 5x6 grid -->
      <img src="Images/wall.png" /><img src="Images/ground.png" /><img src="Images/wall.png" /><img src="Images/wall.png" /><img src="Images/wall.png" /><br />
      <img src="Images/wall.png" /><img src="Images/ground.png" /><img src="Images/wall.png" /><img src="Images/wall.png" /><img src="Images/wall.png" /><br />
      <img src="Images/ground.png" /><img src="Images/ground.png" /><img src="Images/wall.png" /><img src="Images/ground.png" /><img src="Images/wall.png" /><br />
      <img src="Images/wall.png" /><img src="Images/ground.png" /><img src="Images/ground.png" /><img src="Images/ground.png" /><img src="Images/wall.png" /><br />
      <img src="Images/wall.png" /><img src="Images/wall.png" /><img src="Images/wall.png" /><img src="Images/ground.png" /><img src="Images/wall.png" /><br />
      <img src="Images/wall.png" /><img src="Images/wall.png" /><img src="Images/ground.png" /><img src="Images/ground.png" /><img src="Images/ground.png" /><br />
    </div>
    <div class="buttons">
      <asp:Button ID="northButton" runat="server" Text="North" OnClick="northButton_Click" />
      <asp:Button ID="eastButton" runat="server" Text="East" OnClick="eastButton_Click" />
      <asp:Button ID="southButton" runat="server" Text="South" OnClick="southButton_Click" />
      <asp:Button ID="westButton" runat="server" Text="West" OnClick="westButton_Click" />
    </div>
    <div class="description">
      <asp:Label ID="labelDescription" runat="server" Text=""></asp:Label>
    </div>
    <div class="description">
      <p>Use the buttons to navigate the map. You can see an image of the map by moving the mouse in the empty box. Walls can't be crossed and you start at the top. If another person is in the same place as you, it will say you are not alone. Can you find the exit?</p>
    </div>
</body>
<asp:label id="me" runat="server"></asp:label>
<br />
<asp:label id="lblPeople" runat="server"></asp:label>
<br />
<asp:label id="lblString" runat="server"></asp:label>

</form>
  <footer class="credits">
    <p><small>Created by <a href="http://www.logicalmoon.com/">Stephen Moon</a></small></p>
  </footer>
</html>
