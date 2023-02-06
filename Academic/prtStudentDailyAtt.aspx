<%@ Page Language="C#" AutoEventWireup="true" CodeFile="prtStudentDailyAtt.aspx.cs" Inherits="Academic_prtStudentDailyAtt" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Student Attendance</title>
</head>
<body>
    <form id="form1" runat="server">
        <table style="width: 700px; font-family: Book Antiqua; font-size: 10pt; margin-top: 0px;"
            cellpadding="3px">
            <tr>
                <td style="height: 40px; text-align: center">
                    <span style="font-size: 16px"><span style="text-decoration: underline">STUDENT
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
                            <asp:BoundField DataField="ENROLLMENT_NO" HeaderText="Enrollment no.">
                                <ItemStyle Width="80px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="STU_FULL_NAME" HeaderText="Student Name">
                                <ItemStyle Width="150px" />
                            </asp:BoundField>                            
                            <asp:BoundField DataField="CLS_VALUE" HeaderText="Class Name">
                                <ItemStyle Width="80px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="ACA_SEM_ID" HeaderText="Semester">
                                <ItemStyle Width="10px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="PAPER" HeaderText="Paper Code(s)">
                                <ItemStyle Width="150px" />
                            </asp:BoundField>
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
                            <asp:TemplateField HeaderText="Date">
                                <ItemTemplate>
                                    <asp:Label ID="lblColor" ForeColor='<%#System.Drawing.Color.FromName(Eval("COLOR").ToString()) %>'
                                        runat="server" Text='<%#Eval("CLS_DATE")%>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Status">
                                <ItemTemplate>
                                    <asp:Label ID="lblColor" ForeColor='<%#System.Drawing.Color.FromName(Eval("COLOR").ToString()) %>'
                                        runat="server" Text='<%#Eval("STATUS")%>'></asp:Label>
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
