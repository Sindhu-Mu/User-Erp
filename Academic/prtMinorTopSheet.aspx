<%@ Page Language="C#" AutoEventWireup="true" CodeFile="prtMinorTopSheet.aspx.cs" Inherits="Acedamic_prtMinorTopSheet" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Admit Card Top Sheet</title>
    <style type="text/css">
        .style4 {
            font-size: 16px;
            font-style: italic;
            font-family: "Century Gothic";
            font-weight: bold;
        }

        .style5 {
            font-size: medium;
            font-weight: bold;
        }
    </style>
</head>
<body onload="window.print();">
    <form id="form1" runat="server">
        <table style="width: 700px; font-family: Book Antiqua; font-size: 14px;">
            <tr>
                <td>
                    <table style="width: 100%; border-collapse: collapse; font-size: 18px;">
                        <tr>
                            <td style="font-weight: bold; text-align: center;">
                                <img src='../Siteimages/mu_logo.png' style="height:85px; width: 252px" /><br />
                                Examination Cell</td>
                            <td style="font-weight: bold; text-align: center;">
                                <asp:Label ID="lblIns" runat="server" Font-Underline="true"></asp:Label>
                                <span style="font-size: 14pt">
                                    <br />
                                    &nbsp;Admit Card Top Sheet</span><br />
                                <asp:Label ID="lblSesstion" runat="server"></asp:Label>
                                <br />
                            </td>
                        </tr>
                    </table>
                    <hr style="color:black;" size="1px" />
                </td>
            </tr>
            <tr>
                <td id="tdMain" runat="server"></td>
            </tr>
            <tr>
                <td>&nbsp;</td>
            </tr>

            <tr>
                <td colspan="2" style="text-align: center">
                    <table style="width: 100%; border-collapse: collapse;">
                        <tr>
                            <th>Date:-_________________</th>
                            <th></th>
                            <th>( Controller of Examination)</th>
                        </tr>
                    </table>
                </td>
            </tr>



        </table>
    </form>
</body>
</html>
