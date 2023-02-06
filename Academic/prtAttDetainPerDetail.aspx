<%@ Page Language="C#" AutoEventWireup="true" CodeFile="prtAttDetainPerDetail.aspx.cs" Inherits="Academic_prtAttDetainPerDetail" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
            <table style="width:690px; border-collapse: collapse; border-spacing: 0px; text-align: left">
                <tr>
                    <td>
                        <table style="width: 100%">
                            <tr>
                                <td>
                                    <asp:Repeater ID="Repeater1" runat="server">
                                        <ItemTemplate>
                                            <table style="border-collapse: separate; border-spacing: 5px; width: 100%; text-align: center" class="btable">
                                                <tr>
                                                    <td>
                                                        <table style="text-align: center; margin: auto; text-decoration: underline">
                                                            <tr>
                                                                <th style="font-size: 18px; margin-bottom: 10px;">Student Detained List
                                                                </th>
                                                            </tr>
                                                            <tr>
                                                                <th><%#Eval("INS_VALUE")%>
                                                                </th>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <table style="border-collapse: separate; border-spacing: 0px; text-align: center; margin: auto">
                                                            <tr>
                                                                <th>Course:
                                                                </th>
                                                                <td>
                                                                    <%#Eval("PGM_SHORT_NAME")%>
                                                                </td>
                                                                <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>
                                                                <th>Branch:
                                                                </th>
                                                                <td>
                                                                    <%#Eval("BRN_SHORT_NAME")%>
                                                                </td>
                                                                <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>
                                                                <th>Semester:
                                                                </th>
                                                                <td>
                                                                    <%#Eval("SEM")%>
                                                                </td>
                                                                <td>
                                                                    <%#Eval("PERCENTAGE")%>
                                                                </td>
                                                                <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>
                                                                <th>Date:
                                                                </th>
                                                                <td>
                                                                    <%#Eval("MAX_DATE")%>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                            </table>
                                        </ItemTemplate>

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
                                    <asp:GridView ID="gridData" runat="server" AutoGenerateColumns="false" Width="100%" EmptyDataText="No records found" CssClass="btable">
                                        <Columns>
                                            <asp:TemplateField HeaderText="S#">
                                                <ItemTemplate>
                                                    <%# ((GridViewRow)Container).RowIndex + 1%>.
                                                </ItemTemplate>
                                                <ItemStyle Width="10px" />
                                            </asp:TemplateField>
                                            <asp:BoundField HeaderText="Enroll" DataField="ENROLLMENT_NO">
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:BoundField>
                                            <asp:BoundField HeaderText="Roll." DataField="SEM_ROLL_NO">
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:BoundField>
                                            <asp:BoundField HeaderText="Name" DataField="STU_FULL_NAME">
                                                <ItemStyle HorizontalAlign="Left" />
                                            </asp:BoundField>
                                        </Columns>
                                    </asp:GridView>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td>
                        <table style="text-align: left; border-collapse: collapse; border-spacing: 0px; margin-top: 5px">
                            <tr>
                                 <td>
                                    <span style="text-decoration: underline; font-weight: bold">Note: </span>
                                    <ul style="padding-top: 0px; padding-left: 20px">
                                        <li>All attendance percentage are commulative of Medical and Activity credits </li>
                                        <li>Medical credit is calculated to the maximum of 10% of the number of classes held
                                    during the period </li>
                                        <li>Activity credit is calculated to the maximum of 5% of the number of classes held
                                    during the period </li>
                                    </ul>
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
