﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="prtDetainList.aspx.cs" Inherits="Academic_prtDetainList" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Untitled Page</title>
</head>
<body onload="window.print();" oncontextmenu="return false" ondragstart="return false" onselectstart="return false">
    <form id="form1" runat="server">
        <div>
            <table style="width: 670px; font-family: Tahoma; padding-top: 50px; font-size: 13px; border-style: solid; border-width: 1px; border-color: Black" cellpadding="3" cellspacing="0">
                <tr>
                    <td align="center">
                        <span style="font-size: 16pt; font-family: Arial"><span style="text-decoration: underline">Mangalayatan University<br />
                        </span>
                            <span style="font-size: 10pt">
                                <span style="font-size: 14pt">
                                    <asp:Label ID="lblHeading" runat="server" Text="Detain List"></asp:Label></span></span></span>
                        <hr style="color: black;" />
                        <asp:GridView ID="gvDetail" runat="server">
                            <Columns>
                                <asp:BoundField HeaderText="S#">
                                    <ItemStyle Width="20px" />
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