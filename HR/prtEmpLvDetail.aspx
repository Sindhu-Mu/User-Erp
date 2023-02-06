<%@ Page Language="C#" AutoEventWireup="true" CodeFile="prtEmpLvDetail.aspx.cs" Inherits="HR_prtEmpLvDetail" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Untitled Page</title>
</head>
<body onload="window.print()">
    <form id="form1" runat="server">
        <div>
            <table style="width: 670px; font-family: Tahoma; padding-top: 50px; font-size: 13px; border-style: solid; border-width: 1px; border-color: Black" cellpadding="3" cellspacing="0">
                <tr>
                    <td align="center">
                        <span style="font-size: 16pt; font-family: Arial"><span style="text-decoration: underline">Mangalayatan University<br />
                        </span></span>
                    </td>
                </tr>
                <tr>
                    <td>
                        <table>
                            <tr>
                                <td>
                                    <img id="imgEmp" runat="server" alt="Image" src="~/images/emp_images/empImage.jpg" style="border: 1px solid #000000; height: 110px; width: 100px;" />
                                </td>
                                <td style="vertical-align: top; text-align: center">
                                    <span style="font-size: 10pt">
                                        <span style="font-size: 13pt">Leave Detail of <asp:Label ID="lblInitial" runat="server"></asp:Label><asp:Label ID="lblName" runat="server"></asp:Label> for Year:<asp:Label ID="lblYear" runat="server"></asp:Label> </span></span>

                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
            <table style="width: 670px; font-family: Tahoma; padding-top: 50px; font-size: 13px; border-style: solid; border-width: 1px; border-color: Black" cellpadding="3" cellspacing="0">
                <tr>
                    <td align="center">
                        <asp:GridView ID="gvLvBalance" runat="server">
                            <Columns>
                                <asp:BoundField HeaderText="S#">
                                    <ItemStyle Width="20px" />
                                </asp:BoundField>
                            </Columns>
                        </asp:GridView>
                    </td>
                </tr>
            </table>
            <table style="width: 670px; font-family: Tahoma; padding-top: 50px; font-size: 13px; border-style: solid; border-width: 1px; border-color: Black" cellpadding="3" cellspacing="0">
                <tr>
                    <td align="center">
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
