<%@ Page Language="C#" AutoEventWireup="true" CodeFile="prtMajorMarks.aspx.cs" Inherits="Academic_prtMajorMarks" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>::Award List::</title>
</head>
<body onload="window.print();">
    <form id="form1" runat="server">
        <table style="font-family: Book Antiqua; margin-left: 10px; font-size: 15px; width: 680px">
            <tr>
                <td align="center" valign="top" style="text-align: justify;">

                    <table border="0" width="100%" cellpadding="0" cellspacing="0">
                        <tr>
                            <td>
                                <img src="../Siteimages/mu_logo.jpg" style="height: 99px; width: 81px;" alt="" /></td>
                            <td style="text-align: center">
                                <span style="font-size: 22pt"><span style="text-decoration: underline">
                                    <strong>MANGALAYATAN UNIVERSITY</strong></span><br />

                                </span>
                                <span style="text-decoration: underline;"><span style="font-size: 16pt"><strong>Award List
                                    <asp:Label ID="lblType" runat="server"></asp:Label>
                                </strong>
                                    <br />
                                </span>
                                </span>
                                <asp:Label ID="lblIns" runat="server" Font-Bold="True" Font-Size="16px"></asp:Label>
                            </td>
                        </tr>
                    </table>
                    <hr style="color: Black" noshade="noshade" size="1" />
                </td>
            </tr>
            <tr>
                <td>
                    <table border="0" width="100%" cellpadding="0" cellspacing="0">
                        <tr>
                            <td>Semester:</td>
                            <td>&nbsp;</td>
                            <td>
                                <asp:Label ID="lblSem" runat="server"></asp:Label>

                            </td>
                            <td>Subject:</td>
                           
                            <td>
                                <asp:Label ID="lblSubject" runat="server"></asp:Label></td>
                            <td>Paper Code</td>
                            <td>&nbsp;</td>
                            <td>
                                <asp:Label ID="lblCode" runat="server"></asp:Label></td>
                        </tr>
                        <tr>
                            <td>Max Marks</td>
                            <td>&nbsp;</td>
                            <td>
                                <asp:Label ID="lblMaxMarks" runat="server" Font-Bold="True"></asp:Label>
                                
                            </td>
                            <td>
                                Weightage: &nbsp;
                            </td>
                            <td>
                                <asp:Label ID="lblWeightage" runat="server" Font-Bold="True"></asp:Label>
                            </td>
                            <td>
                                 Award No.:
                            </td>
                            <td>
                                <asp:Label id="lblAward" runat="server"></asp:Label>
                            </td>
                        </tr>

                        <tr>
                            <td colspan="6">
                                <hr style="color: Black" noshade="noshade" size="1" />
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:GridView ID="gvDetail" runat="server" AutoGenerateColumns="False" Width="97%">
                        <Columns>
                            <asp:BoundField HeaderText="S.NO." />
                            <asp:BoundField DataField="ENROLLMENT_NO" HeaderText="Enrollment No." />
                             <asp:BoundField DataField="PGM_BRNCH" HeaderText="Program(Branch)" />
                            <asp:BoundField DataField="MARKS" HeaderText="Marks" />
                            <asp:BoundField DataField="MEM_W_MARKS" HeaderText="W. Marks" />
                            <asp:BoundField HeaderText="Mark In Word" />
                        </Columns>
                    </asp:GridView>
                </td>
            </tr>
            <tr>
                <td>
                    <hr style="color: Black" noshade="noshade" size="1" />
                </td>
            </tr>
            <tr>
                <td>
                    <table border="0" width="100%" cellpadding="4" cellspacing="0">
                        <tr>
                            <td>Examiner Name:</td>
                            <td>
                                <asp:Label ID="lblExaminer" runat="server" Font-Bold="True"></asp:Label></td>
                            <td>&nbsp;</td>
                            <td>Scrutinizer Name:</td>
                            <td>
                                <asp:Label ID="lblScrutinizer" runat="server" Font-Bold="True"></asp:Label></td>
                        </tr>
                        <tr>
                            <td>Signature:</td>
                            <td></td>
                            <td>&nbsp;
                            </td>
                            <td>Signature:</td>
                            <td></td>
                        </tr>
                        <tr>
                            <td>Date:</td>
                            <td></td>
                            <td>&nbsp;
                            </td>
                            <td>Date:</td>
                            <td></td>
                        </tr>
                        <tr>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;
                            </td>
                            <td></td>
                            <td></td>
                        </tr>
                        <tr>
                            <td>Verified By:</td>
                            <td>
                                <asp:Label ID="lblVName" runat="server"></asp:Label></td>
                            <td></td>
                            <td>Signature</td>
                            <td></td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
        &nbsp;&nbsp;
    </form>
</body>
</html>
