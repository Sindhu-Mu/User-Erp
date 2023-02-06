<%@ Page Language="C#" AutoEventWireup="true" CodeFile="prtFacility.aspx.cs" Inherits="Facility_prtHostel_Main" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body onload="window.print();" >
    <form id="form1" runat="server">
        <div>
            <table>
                <tr>
                    <td style="text-align: center; font-size: 18px; text-decoration: underline;">Mangalayatan University<br />
                        <asp:Label ID="lblHeading" runat="server"></asp:Label>

                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:GridView ID="gvDetail" runat="server">
                            <Columns>
                                <asp:BoundField HeaderText="S.No.">
                                    <ItemStyle Width="15px" />
                                </asp:BoundField>
                            </Columns>
                        </asp:GridView>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
