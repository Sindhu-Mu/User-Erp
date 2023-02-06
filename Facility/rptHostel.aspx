<%@ Page Language="C#" AutoEventWireup="true" CodeFile="rptHostel.aspx.cs" Inherits="Facility_rptHostel" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server" id="Head1">
    <title>Student Deatil</title>
</head>
<body>
    <form id="form1" runat="server">
        <table>
            <tr>
                <td style="font-size: 16pt; text-align: center; text-decoration: underline;">Mangalayatan University<br />
                    HOSTEL DEATIL
                </td>
            </tr>
            <tr>
                <td>
                    <hr />
                    <asp:Button ID="btnExport" runat="server" Text="Export to Excel" OnClick="btnExport_Click" />
                    &nbsp;HEADING&nbsp;
                <asp:TextBox ID="txtHeading" runat="server"></asp:TextBox>
                    <asp:Button ID="btnPrint" runat="server" Text="Print Report" OnClick="btnPrint_Click" />
                </td>
            </tr>
            <tr>
                <td>&nbsp
                </td>
            </tr>
            <tr>
                <td style="text-align: center; display: none" id="tderror" runat="server">
                    <asp:Label ID="lblError" runat="server" Text="No Record Found" Font-Bold="true" Font-Size="Large" ForeColor="#ff5050"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <div style="overflow: auto; height: 600px; width: 800px" id="divPrint" runat="server">
                        <asp:GridView ID="gvDetail" runat="server" EmptyDataText="No Record Found" OnRowDataBound="gvDetail_RowDataBound">
                            <Columns>
                                <asp:TemplateField HeaderText="S.No">
                                    <ItemTemplate>
                                        <%# ((GridViewRow)Container).RowIndex + 1 %>
                                    </ItemTemplate>
                                    <ItemStyle Width="20px" />
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </div>
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
