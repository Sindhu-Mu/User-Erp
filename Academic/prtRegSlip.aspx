<%@ Page Language="C#" AutoEventWireup="true" CodeFile="prtRegSlip.aspx.cs" Inherits="Academic_prtRegSlip" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Student Registration Slip</title>
    <style lang="en-us" type="text/css">
        table {
            border-collapse: collapse;
            border-spacing: 0px;
            margin: 0px;
        }

        .space {
            border-collapse: collapse;
            border-spacing: 0px;
        }

            .space th {
                padding-right: 2px;
            }

            .space td {
                padding-right: 5px;
            }

        .border {
            border: solid 1px black;
        }

            .border th {
                border: solid 1px black;
            }

            .border td {
                border: solid 1px black;
            }
    </style>
</head>
<body style="margin: 0;" onload="window.print();">
    <form id="form1" runat="server" style="margin: 0;">
        <table>
            <tr>
                <td>
                    <asp:Repeater ID="RptrStu" runat="server" EnableViewState="false">
                        <HeaderTemplate>
                            <table style="width: 740px; border-collapse: collapse; border-spacing: 0px; margin: 0; text-align: left; font-size: 14px;">
                        </HeaderTemplate>
                        <ItemTemplate>
                            <tr style="height: 340px;">
                                <td style="padding-left: 10px; width: 360px;">
                                    <table style="width: 100%; border-collapse: collapse; border-spacing: 0px;">
                                        <tr>
                                            <td>
                                                <table>
                                                    <tr>
                                                        <td style="text-align: left; vertical-align: bottom">
                                                            <img src="../Siteimages/logo-1.png" alt="" style="width: 150px; height: 80px" />
                                                        </td>
                                                        <td style="vertical-align: bottom; text-align: center; font-weight: bold">2016-17(Even Sem)<br />
                                                            Semester Registration Slip
                                                            <br />
                                                            (Institute Copy)
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <table>
                                                    <tr>
                                                        <td>Enrollment:<%#Eval("ENROLLMENT_NO")%>
                                                        </td>
                                                        <td>Name:<%#Eval("STU_FULL_NAME")%></td>
                                                    </tr>
                                                    <tr>
                                                        <td>Semester:<%#Eval("ACA_SEM_ID")%>
                                                        </td>
                                                        <td colspan="2">Program:<%#Eval("PROGRAMME")%></td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="3">CGPA/Per(%):<%#Eval("EXAM_DETAIL")%> </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="3">Doc Status:<%#Eval("DOC")%></td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="3">Fee Status-<%#Eval("STATUS")%>
                                                        </td>
                                                    </tr>
                                                    <tr id="trDuee" runat="server">
                                                        <td>Academic:<%#Eval("ACADEMIC")%>
                                                        </td>
                                                        <td>Facility:<%#Eval("[HOSTEL/TRANSPORT]")%>
                                                        </td>
                                                        <td>Fine:<%#Eval("FINE")%>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>&nbsp;</td>
                                                    </tr>
                                                    <tr>
                                                        <td>Student Signature</td>
                                                        <td colspan="2">Coordinator Signature</td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                    </table>
                                    <%--<hr style='color: White; page-break-after: always;' />--%>
                                </td>
                                <td style="padding-left: 10px; width: 360px;">
                                    <table style="width: 100%; border-collapse: collapse; border-spacing: 0px;">
                                        <tr>
                                            <td>
                                                <table>
                                                    <tr>
                                                        <td style="text-align: left; vertical-align: bottom">
                                                            <img src="../Siteimages/logo-1.png" alt="" style="width: 150px; height: 80px" />
                                                        </td>
                                                        <td style="vertical-align: bottom; text-align: center; font-weight: bold">2016-17(Even Sem)<br />
                                                            Semester Registration Slip
                                                            <br />
                                                            (Student Copy)
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <table>
                                                    <tr>
                                                        <td>Enrollment:<%#Eval("ENROLLMENT_NO")%>
                                                        </td>
                                                        <td>Name:<%#Eval("STU_FULL_NAME")%></td>
                                                    </tr>
                                                    <tr>
                                                        <td>Semester:<%#Eval("ACA_SEM_ID")%>
                                                        </td>
                                                        <td colspan="2">Program:<%#Eval("PROGRAMME")%></td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="3">CGPA/Per(%):<%#Eval("EXAM_DETAIL")%> 
                                                        </td>

                                                    </tr>
                                                    <tr>
                                                        <td colspan="3">Doc Status:<%#Eval("DOC")%></td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="3">Fee Status-<%#Eval("STATUS")%>
                                                        </td>
                                                    </tr>
                                                    <tr id="trDue" runat="server">
                                                        <td>Academic:<%#Eval("ACADEMIC")%>
                                                        </td>
                                                        <td>Facility:<%#Eval("[HOSTEL/TRANSPORT]")%>
                                                        </td>
                                                        <td>Fine:<%#Eval("FINE")%>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>&nbsp;</td>
                                                    </tr>
                                                    <tr>
                                                        <td>Student Signature</td>

                                                        <td colspan="2">Coordinator Signature</td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </ItemTemplate>
                        <FooterTemplate>
                            </table>
                        </FooterTemplate>
                    </asp:Repeater>
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
