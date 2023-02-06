<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Prt_Re_reg.aspx.cs" Inherits="Academic_Prt_Re_reg" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Student Re-Addmission</title>
</head>
<body onload="window.print();">
    <form id="form1" runat="server">
        <asp:Repeater ID="Repeater1" runat="server" OnItemDataBound="Repeater1_ItemDataBound">
            <ItemTemplate>
                <table cellpadding="0" cellspacing="0" border="0" width="600px">
                    <tr>
                        <td style="text-align: center">
                            <span style="font-size: 20px; font-family: Trebuchet MS; text-decoration: underline;">
                                <strong>MANGALAYATAN UNIVERSITY</strong></span></td>
                    </tr>
                    <tr>
                        <td style="text-align: center">
                            <strong><span style="font-family: Trebuchet MS">33<sup>rd</sup>MILESTONE ALIGARH MATHURA
                                HIGHWAY ,P.O. BESWAN .U.P.</span></strong></td>
                    </tr>
                    <tr>
                        <td style="text-align: center">
                            Registration Acknowledgment for A.Y.
                            <%#DataBinder.Eval(Container.DataItem, "CON_REG_NAME")%>
                            <hr noshade="noshade" size="1" style="color: black; font-weight: bold; text-decoration: underline;" />
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: left">
                            <table cellpadding="0" cellspacing="0" border="0">
                                <tr>
                                    <td>
                                    </td>
                                    <td>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Name</td>
                                    <td>
                                        <%#DataBinder.Eval(Container.DataItem, "stu_full_name")%>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Enrollment No.</td>
                                    <td>
                                        <%#DataBinder.Eval(Container.DataItem, "ENROLLMENT_NO")%>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Institute</td>
                                    <td>
                                        <%#DataBinder.Eval(Container.DataItem, "INS_VALUE")%>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Course</td>
                                    <td>
                                        <%#DataBinder.Eval(Container.DataItem, "PGM_FULL_NAME")%>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Branch</td>
                                    <td>
                                        <%#DataBinder.Eval(Container.DataItem, "BRN_FULL_NAME")%>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Semester</td>
                                    <td>
                                        <%#DataBinder.Eval(Container.DataItem, "ACA_SEM_NO")%>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Date of Registration &nbsp;&nbsp;</td>
                                    <td>
                                        <strong>
                                            <%#DataBinder.Eval(Container.DataItem, "REG_DATE")%>
                                        </strong>
                                    </td>
                                    <td style="font-weight: bold; text-decoration: underline">
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;</td>
                    </tr>
                   
                    <tr>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            <strong><span style="text-decoration: underline;">Note :Please ensure your details in
                                class attandance register.<br />
                                <asp:Label ID="lblNote" runat="server" Text="2.Provisionally registered candidates will not permitted to appear for minor & Major Exams."
                                    Visible="False"></asp:Label></span></strong></td>
                    </tr>
                    <tr style="font-weight: bold; text-decoration: underline">
                        <td style="text-align: right">
                            <br />
                            Authorized Signatory &nbsp; &nbsp; &nbsp;&nbsp;<br />
                            <br />
                            Date:________________</td>
                    </tr>
                </table>
            </ItemTemplate>
        </asp:Repeater>
    </form>
</body>
</html>
