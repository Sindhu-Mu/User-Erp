<%@ Control Language="C#" AutoEventWireup="true" CodeFile="maritalStatus.ascx.cs" Inherits="control_maritalStatus" %>
<asp:DropDownList ID="ddlMaritalStatus" runat="server" Width="95px">
    <asp:ListItem Value="." Selected="True">Select</asp:ListItem>
    <asp:ListItem Value="1">Married</asp:ListItem>
    <asp:ListItem Value=".">Un-married</asp:ListItem>
</asp:DropDownList>

