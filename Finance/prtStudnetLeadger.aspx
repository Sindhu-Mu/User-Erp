<%@ Page Language="C#" AutoEventWireup="true" CodeFile="prtStudnetLeadger.aspx.cs" Inherits="Finance_prtStudnetLeadger" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
  
        <table style='font-family: Arial; font-size: 13px;width: 700px' >
             
            <tr>
                <td style="height: 50px ;font-size: 16px;font-weight:bold;text-align:center;"  colspan="2">
                    MANGALAYATAN UNIVERSITY<br />
                    P.O.-Beswan,Aligrah-202145(INDIA)</td>
            </tr>
              <tr>
                <td colspan="2">
                    <br />
                </td>
            </tr>
             <tr >
                <td  colspan="2">
                    <span style="font-size: 14pt; text-decoration: underline;">STUDENT FEE LEADGER</span></td>
            </tr>
              <tr>
                <td colspan="2">
                    <br />
                </td>
            </tr>
            <tr>
                <td >
                    <table style="width:100%">
                        <tr>
                            <td>
                                <asp:Label ID="lblAdmNo" runat="server" Font-Bold="True" /></td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblSName" runat="server" />
                                <br />
                                S/O
                                <asp:Label ID="lblFName" runat="server" /></td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblAddress" runat="server" Width="200px"></asp:Label>,<br />
                                <asp:Label ID="lblCity" runat="server"></asp:Label></td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblDate" runat="server"></asp:Label></td>
                        </tr>
                    </table>
                </td>
                <td >
                    <table>
                        <tr>
                            <td>
                                Enrollment No.:
                            </td>
                            <td>
                                <asp:Label ID="lblEnrollmentNo" runat="server"></asp:Label></td>
                        </tr>
                        <tr>
                            <td>
                                Institute:
                            </td>
                            <td>
                                <asp:Label ID="lblIns" runat="server"></asp:Label></td>
                        </tr>
                        <tr>
                            <td>
                                Course:
                            </td>
                            <td>
                                <asp:Label ID="lblCourse" runat="server" /></td>
                        </tr>
                        <tr>
                            <td>
                                Branch:
                            </td>
                            <td>
                                <asp:Label ID="lblBranch" runat="server" /></td>
                        </tr>
                      <%--  <tr>
                            <td>
                                Session:
                            </td>
                            <td>
                                <asp:Label ID="lblSession" runat="server"></asp:Label></td>
                        </tr>--%>
                        <tr>
                            <td>
                               Current Semester:
                            </td>
                            <td>
                                <asp:Label ID="lblSem" runat="server"></asp:Label></td>
                        </tr>
                        <%--<tr>
                            <td>
                                Section:
                            </td>
                            <td>
                                <asp:Label ID="lblSec" runat="server"></asp:Label></td>
                        </tr>--%>
                        
                    </table>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <br />
                </td>
            </tr>
            <tr>
                <td id="tdMain" runat="server" colspan="2">
                </td>
            </tr>
        </table>

    </form>
</body>
</html>
