<%@ Page Language="C#" AutoEventWireup="true" CodeFile="prtCommulativeAttendance.aspx.cs" Inherits="Academic_prtAttendanceCommulativeDetail" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table style="width: 700px; border-collapse: collapse; border-spacing: 0px">
                <tr>
                    <td>
                        <table style="width: 100%; text-align: center">
                            <tr>
                                <td>
                                    <span style="font-size: 18px"><span style="text-decoration: underline">Student
                        Commulative Attendance Detail</span></span>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td>
                        <table style="width: 100%">
                            <tr>
                                <td>
                                    <asp:Repeater ID="Repeater1" runat="server">
                                        <HeaderTemplate>
                                            <table style="width: 100%; border-collapse: collapse; border-spacing: 0px">
                                                <tr>
                                                    <td>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <table style="border-collapse: separate; border-spacing: 5px; width: 100%; text-align: center">
                                                <tr>
                                                    <td>
                                                        <table style="text-align: center; margin: auto; text-decoration: underline">
                                                            <tr>
                                                                <th>Institution:
                                                                </th>
                                                                <td><%#Eval("INS_VALUE")%>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <table style="border-collapse: separate; border-spacing: 0px; text-align: center; margin: auto">
                                                            <tr>
                                                                <th>Class Name:
                                                                </th>
                                                                <td>
                                                                    <%#Eval("CLS_VALUE")%>
                                                                </td>
                                                                <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>
                                                                <th>Batch:
                                                                </th>
                                                                <td>
                                                                    <%#Eval("ACA_BATCH_NAME")%>
                                                                </td>
                                                                <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>
                                                                <th>Semester:
                                                                </th>
                                                                <td>
                                                                    <%#Eval("ACA_SEM_ID")%>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <table style="border-collapse: separate; border-spacing: 0px; text-align: center; margin: auto">
                                                            <tr>
                                                                <th>Section:
                                                                </th>
                                                                <td>
                                                                    <%#Eval("ACA_SEC_NAME")%>
                                                                </td>

                                                                <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>
                                                                <th>Group:
                                                                </th>
                                                                <td>
                                                                    <%#Eval("GRP_VALUE")%>
                                                                </td>
                                                                <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>
                                                                <th>Class Type:
                                                                </th>
                                                                <td>
                                                                    <%#Eval("CLS_TYPE_VALUE")%>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <table style="border-collapse: separate; border-spacing: 0px; text-align: center; margin: auto">
                                                            <tr>
                                                                <th>Paper Code(s):
                                                                </th>
                                                                <td>
                                                                    <%#Eval("PAPER_CODES")%>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                            </table>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            </td></tr></table>
                                        </FooterTemplate>
                                    </asp:Repeater>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td>
                        <table style="width: 100%">
                            <tr>
                                <td>
                                    <asp:GridView ID="gridAttClsNamePerDetail" runat="server" AutoGenerateColumns="false" Width="100%">
                                        <Columns>
                                            <asp:TemplateField HeaderText="S#">
                                                <ItemTemplate>
                                                    <%# ((GridViewRow)Container).RowIndex + 1%>
                                                </ItemTemplate>
                                                <ItemStyle Width="10px" />
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="ENROLLMENT_NO" HeaderText="Enroll" />
                                            <asp:BoundField DataField="SEM_ROLL_NO" HeaderText="Roll" />
                                            <asp:BoundField DataField="STU_FULL_NAME" HeaderText="Name" />
                                            <asp:BoundField DataField="HELD" HeaderText="Held" HtmlEncode="false">
                                                <ItemStyle Width="10px" HorizontalAlign="Center" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="MARKED" HeaderText="Mark" HtmlEncode="false">
                                                <ItemStyle Width="10px" HorizontalAlign="Center" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="PRESENT" HeaderText="Pre" HtmlEncode="false">
                                                <ItemStyle Width="10px" HorizontalAlign="Center" />
                                            </asp:BoundField>
                                            <%--<asp:BoundField DataField="WGHP" HeaderText="Wgh%" HtmlEncode="false">
                                                <ItemStyle Width="10px" HorizontalAlign="Center" />
                                            </asp:BoundField>--%>
                                            <asp:BoundField DataField="ACTP" HeaderText="Act%" HtmlEncode="false">
                                                <ItemStyle Width="10px" HorizontalAlign="Center" />
                                            </asp:BoundField>
                                        </Columns>
                                    </asp:GridView>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
