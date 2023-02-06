<%@ Page Language="C#" AutoEventWireup="true" CodeFile="prtClassStudent.aspx.cs" Inherits="Academic_prtClassStudent"
    EnableEventValidation="false" EnableViewState="false" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Attendance Detail</title>
</head>
<body>
    <form id="form1" runat="server">
        <table style="width: 700px; font-family: Book Antiqua; font-size: 10pt; margin-top: 0px;"
            cellpadding="3px">
            <tr>
                <td style="height: 40px; text-align: center">
                    <span style="font-size: 16px"><span style="text-decoration: underline">CLASS STUDENT
                        ATTENDANCE DETAIL</span></span></td>
            </tr>
            <tr>
                <td style="text-align: center">
                    <asp:GridView ID="gridViewData" runat="server" AutoGenerateColumns="False" Caption="Class Details"
                        Width="95%">
                        <RowStyle HorizontalAlign="Left" />
                        <Columns>
                            <asp:TemplateField HeaderText="S.No.">
                                <ItemTemplate>
                                    <%# ((GridViewRow)Container).RowIndex + 1%>
                                    .
                                </ItemTemplate>
                                <ItemStyle Width="10px" />
                            </asp:TemplateField>
                            <asp:BoundField DataField="CLS_VALUE" HeaderText="Class Name">
                                <ItemStyle Width="150px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="ACA_SEM_ID" HeaderText="Semester">
                                <ItemStyle Width="10px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="PAPER" HeaderText="Paper Code(s)"></asp:BoundField>
                        </Columns>
                    </asp:GridView>
                    <hr style="width: 100%;" />
                </td>
            </tr>
            <tr>
                <td style="text-align: center">
                    <asp:GridView ID="gridDetail" runat="server" AutoGenerateColumns="False" Width="95%"
                        Caption="Student Details">
                         <RowStyle HorizontalAlign="Left" />
                        <Columns>
                            <asp:TemplateField HeaderText="S.No.">
                                <ItemTemplate>
                                    <asp:Label ID="lblColor" ForeColor='<%#System.Drawing.Color.FromName(Eval("COLOR").ToString()) %>'
                                        runat="server" Text='<%# ((GridViewRow)Container).RowIndex + 1%>'></asp:Label>
                                </ItemTemplate>
                                <ItemStyle Width="10px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Enrollment">
                                <ItemTemplate>
                                    <asp:Label ID="lblColor" ForeColor='<%#System.Drawing.Color.FromName(Eval("COLOR").ToString()) %>'
                                        runat="server" Text='<%#Eval("ENROLLMENT_NO")%>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Student Name">
                                <ItemTemplate>
                                    <asp:Label ID="lblColor" ForeColor='<%#System.Drawing.Color.FromName(Eval("COLOR").ToString()) %>'
                                        runat="server" Text='<%#Eval("STU_FULL_NAME")%>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Attendace">
                                <ItemTemplate>
                                    <asp:Label ID="lblColor" ForeColor='<%#System.Drawing.Color.FromName(Eval("COLOR").ToString()) %>'
                                        runat="server" Text='<%#Eval("TT_DET_ATT_STAT")%>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
