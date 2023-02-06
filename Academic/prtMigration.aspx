<%@ Page Language="C#" AutoEventWireup="true" CodeFile="prtMigration.aspx.cs" Inherits="Academic_prtMigration" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Migration Certificate</title>
    <style type="text/css">
        .style2 {
            font-family: Arial;
            text-align: center;
            font-size: 20px;
            text-decoration: underline;
        }

        .style3 {
            font-size: 25px;
            text-decoration: underline;
        }

        .style4 {
            height: 24px;
        }
    </style>
</head>
<body onload="window.print();">

    <form id="form1" runat="server">
        <table style="width: 600px; font-family: Arial; font-size: 16px; margin-top: 150px; margin-left: 60px; margin-right: 10px;margin-bottom:50px;" cellpadding="3px"">
            <tr>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td style="height: 39px">&nbsp;</td>
            </tr>
            <tr>
                <td class="style2">
                    <strong>MIGRATION CERTIFICATE</strong></td>
            </tr>
            <tr>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>Ref.No.:-<asp:Label ID="lblRefNo" runat="server" Text="Label" Font-Bold="True"></asp:Label></td>
            </tr>
            <tr>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td style="text-align: justify; font-size: 16px;">
                    <asp:Label ID="lblName" runat="server" Font-Underline="True" Font-Bold="True" /></td>
            </tr>
            <tr>
                <td style="text-align: justify; font-size: 20px;">Father's Name:-<asp:Label ID="lblFather" runat="server" Font-Size="16px" Font-Underline="True" Font-Bold="True" /></td>
            </tr>
            <tr>
                <td style="text-align: justify; font-size: 20px;">Enrollment No.:<asp:Label ID="lblNet" runat="server" Font-Size="16px" Font-Underline="True" Font-Bold="True" />
                    &nbsp;is informed that the university has no objection to his/her migration
                    to another University/Board.</td>
            </tr>

            <tr>
                <td class="style4">&nbsp;</td>
            </tr>
            <tr>
                <td class="style4">&nbsp;</td>
            </tr>
            <tr>
                <td class="style4">&nbsp;</td>
            </tr>
            <tr>
                <td class="style4">&nbsp;</td>
            </tr>
            <tr>
                <td style="text-align: left">&nbsp;</td>
            </tr>
            <tr>
                <td>
                    <table style="width: 98%">
                        <tr>
                            <td style="text-align: left;width: 30%">Date:-<asp:Label ID="lblDate1" runat="server" Font-Bold="True"></asp:Label></td>
                            <td style="width:40%"></td>
                            <td colspan="1" style="text-align: center;width: 30%; font-family:Arial">
                                (<asp:Label ID="lblAuthorty"  runat="server" Font-Bold="True" ></asp:Label>)

                               
                                <br />

                                <asp:Label ID="lblDesig" runat="server"  Font-Bold="True"></asp:Label>
                               <br />
                               <span runat="server" font-family="Arial" style="font-size:16px" > Mangalayatan University<br />
                                Beswan, Aligarh, U.P.</span>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td style="height: 30px">&nbsp;</td>
            </tr>
            <tr>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>&nbsp;</td>
            </tr>

            <tr>
                <td style="text-align: center" class="style2">
                    <strong>MIGRATION CERTIFICATE</strong><br />
                    OFFICE COPY</td>
            </tr>
            <tr>
                <td>Student Name:-<asp:Label ID="lblStuName" runat="server" Font-Bold="True"></asp:Label>&nbsp;</td>
            </tr>
            <tr>
                <td valign="top">
                    <table cellpadding="0" cellspacing="0" border="0" width="100%">
                        <tr>
                            <td>Enrollment No:-<asp:Label ID="lblErollment" runat="server" Font-Bold="True"></asp:Label></td>
                            <td></td>
                            <td>Course :-<asp:Label ID="lblCourse" runat="server" Font-Bold="True"></asp:Label></td>
                        </tr>
                        <tr>
                            <td>Application:-Yes/No</td>
                            <td></td>
                            <td>Amount Receive:-Yes/No</td>
                        </tr>
                        <tr>
                            <td style="height: 2px" valign="bottom">
                                <br />
                                PreparedBy:____________________________</td>
                            <td style="height: 2px"></td>
                            <td align="right" valign="bottom" style="height: 2px; text-align: left">ReceivedBy:____________________________</td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
