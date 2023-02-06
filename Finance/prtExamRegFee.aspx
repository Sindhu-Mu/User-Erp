<%@ Page Language="C#" AutoEventWireup="true" CodeFile="prtExamRegFee.aspx.cs" Inherits="Finance_prtExamRegFee" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Exam Payment Receipt</title>
    <style type="text/css">
        .style2 {
            height: 500px;
            vertical-align: top;
        }

        .style3 {
            font-size: 20px;
            text-decoration: underline;
        }
    </style>
</head>
<body onload="window.print();">
    <form id="form1" runat="server">

        <table style="font-family: 'Book Antiqua'; font-size: 13px; margin: 0px; border-collapse: collapse; vertical-align: top;">
            <tr>
                <td>
                    <table style="height: 800px; width: 480px; border-collapse: collapse" border="1">
                        <tr>
                            <td colspan="2">Receipt &nbsp;No.&nbsp;<asp:Label ID="lblReceiptNo" runat="server" Font-Bold="True" /></td>
                            <td colspan="2" style="text-decoration: underline; font-weight: bold; text-align: right">Candidate Copy</td>
                        </tr>
                        <tr>
                            <td style="height: 50px;text-align:center"  colspan="4">
                                <span class="style3">MANGALAYATAN UNIVERSITY</span><br />

                                P.O.-Beswan,Aligrah-202145(INDIA)<br />
                               <b>  <asp:Label ID="lblExam" runat="server"></asp:Label> </b>

                            </td>
                        </tr>
                        <tr>
                            <td>Enrollment No</td>
                            <td>
                                <asp:Label ID="lblEnrol" runat="server"></asp:Label></td>
                            <td>Date</td>
                            <td>
                                <asp:Label ID="lbldate" runat="server"></asp:Label></td>
                        </tr>
                        <tr>
                            <td>Course</td>
                            <td>
                                <asp:Label ID="lblCourse" runat="server" /></td>
                            <td>Branch</td>
                            <td>
                                <asp:Label ID="lblBranch" runat="server" /></td>
                        </tr>

                        <tr>
                            <td>Name</td>
                            <td colspan="3">
                                <asp:Label ID="lblName" runat="server" Font-Bold="true" />
                            </td>
                        </tr>

                        <tr>
                            <td id="Tdtab" runat="server" colspan="4" class="style2"></td>
                        </tr>

                        <tr>
                            <td>Remark</td>
                            <td colspan="3">
                                <asp:Label ID="lblRemark" runat="server"></asp:Label></td>
                        </tr>
                        <tr>
                            <td>Collected By</td>
                            <td colspan="3">
                                <asp:Label ID="lblBy" runat="server"></asp:Label></td>
                            
                        </tr>

                    </table>
                </td>
                <td style="width: 10px">&nbsp;</td>
                <td>
                    <table style="height: 800px; width: 480px; border-collapse: collapse" border="1">
                        <tr>
                            <td colspan="2">Receipt &nbsp;No.&nbsp;
                                <asp:Label ID="lblReceiptNo1" runat="server" Font-Bold="True" /></td>
                            <td colspan="2" style="text-decoration: underline; font-weight: bold; text-align: right">File Copy</td>
                        </tr>
                        <tr>
                            <td style="height: 50px" align="center" colspan="4">
                                <span class="style3">MANGALAYATAN UNIVERSITY</span><br />

                                P.O.-Beswan,Aligrah-202145(INDIA)<br />
                                 <b> <asp:Label ID="lblExam1" runat="server"></asp:Label> </b>
                            </td>
                        </tr>
                        <tr>
                            <td>Enrollment No</td>
                            <td>
                                <asp:Label ID="lblEnrol1" runat="server"></asp:Label></td>
                            <td>Date</td>
                            <td>
                                <asp:Label ID="lblDate1" runat="server"></asp:Label></td>
                        </tr>

                        <tr>
                            <td>Course</td>
                            <td>
                                <asp:Label ID="lblCourse1" runat="server" /></td>
                            <td>Branch</td>
                            <td>
                                <asp:Label ID="lblBranch1" runat="server" /></td>
                        </tr>

                        <tr>
                            <td>Name</td>
                            <td colspan="3">
                                <asp:Label ID="lblName1" runat="server" Font-Bold="true" />
                            </td>
                        </tr>
                        <tr>
                            <td id="tdtab1" runat="server" colspan="4" class="style2"></td>
                        </tr>



                        <tr>
                            <td>Remark</td>
                            <td colspan="3">
                                <asp:Label ID="lblRemark1" runat="server"></asp:Label></td>
                        </tr>
                        <tr>
                            <td>Collected By</td>
                            <td colspan="3">
                                <asp:Label ID="lblBy1" runat="server"></asp:Label></td>
                        </tr>
                    </table>
                </td>
                <td style="width: 10px">&nbsp;</td>
                <td>
                    <table style="height: 800px; width: 480px; border-collapse: collapse" border="1">
                        <tr>
                            <td colspan="2">Receipt &nbsp;No.&nbsp;
                                <asp:Label ID="lblReceiptNo2" runat="server" Font-Bold="True" /></td>
                            <td colspan="2" style="text-decoration: underline; font-weight: bold; text-align: right">Account Copy</td>
                        </tr>
                        <tr>
                            <td style="height: 50px" align="center" colspan="4">
                                <span class="style3">MANGALAYATAN UNIVERSITY</span><br />

                                P.O.-Beswan,Aligrah-202145(INDIA)<br />
                                 <b> <asp:Label ID="lblExam2" runat="server"></asp:Label> </b>
                            </td>
                        </tr>
                        <tr>
                            <td>&nbsp;Enrollment_No</td>
                            <td>
                                <asp:Label ID="lblEnrol2" runat="server"></asp:Label></td>
                            <td>Date</td>
                            <td>
                                <asp:Label ID="lblDate2" runat="server"></asp:Label></td>
                        </tr>

                        <tr>
                            <td>Course</td>
                            <td>
                                <asp:Label ID="lblCourse2" runat="server" /></td>
                            <td>Branch</td>
                            <td>
                                <asp:Label ID="lblBranch2" runat="server" /></td>
                        </tr>

                        <tr>
                            <td>Name</td>
                            <td colspan="3">
                                <asp:Label ID="lblName2" runat="server" Font-Bold="True" />
                            </td>
                        </tr>
                        <tr>
                            <td id="tdtab2" runat="server" colspan="4" class="style2"></td>
                        </tr>

                        <tr>
                            <td>Remark</td>
                            <td colspan="3">
                                <asp:Label ID="lblRemark2" runat="server"></asp:Label></td>
                        </tr>
                        <tr>
                            <td>Collected By</td>
                            <td colspan="3">
                                <asp:Label ID="lblBy2" runat="server"></asp:Label></td>
                        </tr>
                    </table>

                </td>
            </tr>
        </table>
    </form>
</body>
</html>
