<%@ Control Language="C#" AutoEventWireup="true" CodeFile="addressType.ascx.cs" Inherits="control_ddladdressType" %>
<asp:DropDownList ID="ddladdressType" runat="server" Width="95px">
    <asp:ListItem Value="." Selected="True">Select</asp:ListItem>
    <asp:ListItem Value=".">Present</asp:ListItem>
    <asp:ListItem Value="1">Permanent</asp:ListItem>
</asp:DropDownList>
