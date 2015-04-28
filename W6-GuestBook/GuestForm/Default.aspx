<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="GuestForm.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>W6 - Guest Book - logicalmoon.com</title>
    <link href="Stylesheets/style.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <h1>Guest Comments</h1>
        <div class="instructions">Add your name and a comment, before clicking the <em>Add Comment</em> button:</div>
        <br />
        <div class="main">
            <label>Name</label>
            <asp:TextBox ID="nameTextbox" runat="server" Font-Names="Verdana"></asp:TextBox>
            <br />
            <label>Comment</label>
            <asp:TextBox ID="commentTextbox" runat="server" Font-Names="Verdana" Height="114px" Width="368px" MaxLength="1000" Rows="10" TextMode="MultiLine"></asp:TextBox>
            <br />
        </div>
        <div class="data">
            <div class="buttons"><asp:Button ID="buttonAdd" runat="server" Text="Add Comment" OnClick="buttonAdd_Click" /></div>
            <br />
        </div>
            <asp:GridView ID="gridView" runat="server" AllowPaging="True" AutoGenerateColumns="False" CellPadding="4" DataSourceID="objDS" ForeColor="#333333" GridLines="None" AllowSorting="True" HorizontalAlign="Center" Width="80%">
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
                    <asp:BoundField DataField="Added" HeaderText="Added" SortExpression="Added" />
                    <asp:BoundField DataField="Comment" HeaderText="Comment" SortExpression="Comment" />
                </Columns>
                <EditRowStyle BackColor="#2461BF" />
                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="#EFF3FB" />
                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                <SortedAscendingCellStyle BackColor="#F5F7FB" />
                <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                <SortedDescendingCellStyle BackColor="#E9EBEF" />
                <SortedDescendingHeaderStyle BackColor="#4870BE" />
            </asp:GridView>
        <asp:ObjectDataSource ID="objDS" runat="server" SortParameterName="sortColumn" SelectMethod="GetGuestComments" TypeName="GuestForm.GuestCommentRepository"></asp:ObjectDataSource>
    </form>
</body>
</html>
