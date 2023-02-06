<%@ Page Language="C#" AutoEventWireup="true" CodeFile="prtEmpRoomAlmt.aspx.cs" Inherits="Facility_prtEmpRoomAlmt" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Room Allotment</title>
</head>
<body onload="window.print();">
    <form id="form1" runat="server">
        <table style="width: 800px">
            <tr>
                <td colspan="3" style="height: 39px; text-align: center">
                    <strong><span style="font-size: 22pt; font-family: Trebuchet MS">MANGALAYATAN UNIVERSITY</span></strong></td>
            </tr>
            <tr>
                <td colspan="3" align="center">
                    Extended NCR, Mathura-Aligarh Highway,<br />
                    33rd Milestone, Aligarh - 202145 (U.P)<br />
                    Fax: 05722 - 254 220
                    <br />
                    Toll Free #1800-102-8686</td>
            </tr>
            <tr>
                <td colspan="3" style="text-align: center">
                    <strong><u>ROOM ALLOTMENT</u></strong>
                </td>
            </tr>
            <tr>
                <td colspan="3">
                    <table style="width: 100%">
                        <tr>
                            <td>
                                <span style="font-family: Trebuchet MS">Employee Name</span></td>
                            <td>
                                <strong>:</strong></td>
                            <td>
                                <asp:Label ID="lblempname" runat="server" Font-Bold="True" Font-Names="Trebuchet MS"
                                    Text="Label"></asp:Label></td>
                        </tr>
                        <tr>
                            <td>
                                <span style="font-family: Trebuchet MS">Employee ID</span></td>
                            <td>
                                <strong>:</strong></td>
                            <td>
                                <asp:Label ID="lblempid" runat="server" Font-Bold="True" Font-Names="Trebuchet MS"
                                    Text="Label"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <span style="font-family: Trebuchet MS">Complex Name</span>
                            </td>
                            <td>
                                <strong>:</strong></td>
                            <td>
                                <asp:Label ID="lblcomplexname" runat="server" Font-Bold="True" Text="Label"></asp:Label></td>
                        </tr>
                        <tr>
                            <td>
                                <span style="font-family: Trebuchet MS">Room No.</span>
                            </td>
                            <td>
                                <strong>:</strong></td>
                            <td>
                                <asp:Label ID="lblroomno" runat="server" Font-Bold="True" Text="Label"></asp:Label></td>
                        </tr>
                        <tr>
                            <td>
                                <span style="font-family: Trebuchet MS">From Date</span>
                            </td>
                            <td>
                                <strong>:</strong></td>
                            <td>
                                <asp:Label ID="lblfromdate" runat="server" Font-Bold="True" Text="Label"></asp:Label></td>
                        </tr>
                        <tr>
                            <td>
                                <span style="font-family: Trebuchet MS">Insert Date</span>
                            </td>
                            <td>
                                <strong>:</strong></td>
                            <td>
                                <asp:Label ID="lblinsertdate" runat="server" Font-Bold="True" Text="Label"></asp:Label></td>
                        </tr>
                        <tr>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td>
                </td>
                <td style="text-align: center" valign="bottom">
                    Alloted By:
                    <asp:Label ID="lblinsertby" runat="server" Font-Bold="True" Text="Label"></asp:Label><br />
                    <br />
                    <br />
                   
                    <strong>Authorized Signature__________________________</strong></td>
            </tr>
            <tr>
                <td valign="bottom">
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
