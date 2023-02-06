<%@ Control Language="C#" AutoEventWireup="true" CodeFile="percentage.ascx.cs" Inherits="control_percentage" %>

<script language="javascript" type="text/javascript">
function OnChange()
{

    var dropdown = document.getElementById("<%=ddlPercentageBef.ClientID %>");
    var dropdown1 = document.getElementById("<%=ddlPercentageAft.ClientID %>");
    var SelValue = dropdown.options[dropdown.selectedIndex].value;
        
    if (SelValue == 100)
        dropdown1.selectedIndex = 1;
}
</script>

<table>
    <tr>
        <td style="text-align: left;">
            <asp:DropDownList ID="ddlPercentageBef" runat="server" onchange='OnChange();'>
            </asp:DropDownList>
        </td>
        <td style="width: 1px !important; text-align: center">
            .</td>
        <td>
            <asp:DropDownList ID="ddlPercentageAft" runat="server" onchange='OnChange();'>
            </asp:DropDownList>
        </td> 
    </tr>
</table>
