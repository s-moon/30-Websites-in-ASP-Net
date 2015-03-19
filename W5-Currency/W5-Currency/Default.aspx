<%@ Page Title="" Language="C#" MasterPageFile="~/Currency.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="W5_Currency.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph" runat="server">
  Amount: <asp:TextBox ID="currencyAmount" runat="server" ViewStateMode="Inherit" CausesValidation="True" ValidationGroup="DigitsOnly" Width="70px">1</asp:TextBox>
  <asp:DropDownList ID="currencyA" runat="server"></asp:DropDownList>
  <asp:DropDownList ID="currencyB" runat="server"></asp:DropDownList>
  &nbsp;<asp:Button ID="buttonConvert" runat="server" OnClick="buttonConvert_Click" Text="Convert Currency" />
  <asp:RangeValidator ID="amountValidator" runat="server" ControlToValidate="currencyAmount" ErrorMessage="Integers greater than zero please." MaximumValue="1000000" MinimumValue="1" Type="Integer" ForeColor="Red">*</asp:RangeValidator>
  <asp:RequiredFieldValidator ID="requiredValidator" runat="server" ControlToValidate="currencyAmount" ErrorMessage="You must enter a value for the amount." ForeColor="Red">*</asp:RequiredFieldValidator>
  <asp:Label ID="resultAmount" runat="server"></asp:Label>
  <br />
<br />
<asp:ValidationSummary ID="validationSummary"  runat="server" />
</asp:Content>
