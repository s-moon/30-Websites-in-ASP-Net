<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="W4_JonSkeetQuote.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
  <title>W4 - Jon Skeet Quote - logicalmoon.com</title>
  <link rel="stylesheet" href="CSS/StyleSheet.css" />
</head>
<body>
  <script src="Scripts/jquery-2.1.3.min.js" type="text/javascript"></script>
  <script src="Scripts/page-modify.js" type="text/javascript"></script>
  <h1><a href ="http://stackoverflow.com/users/22656/jon-skeet">Jon Skeet</a> Quote</h1>
  <form id="form1" runat="server">
    <div class="quote">
      <asp:Label ID="theQuoteLabel" runat="server" Text=""></asp:Label>
    </div>
    <div class="button">
      <asp:Button ID="nextQuoteButton" runat="server" Text="Next..." />
    </div>
  </form>
  <footer class="credits">
    <p><small>Created by <a href="http://www.logicalmoon.com/">Stephen Moon</a></small></p>
  </footer>
</body>
</html>
