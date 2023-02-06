<%@ Page Language="C#" AutoEventWireup="true" CodeFile="prtEmployeeDetail.aspx.cs" Inherits="HR_prtEmployeeDetail" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Employee Detail</title>
</head>
<body>
    <form id="form1" runat="server">
    <table border="0" cellpadding="0" cellspacing="0" style="width: 100%; font-size: 13px;">
            <tr>
                <td style="font-size: 16pt; text-align: center; text-decoration: underline;">
                    Mangalayatan University<br />
                    EMPLOYEE DETAIL</td>
            </tr>
            <tr>
                <td>
                    <hr color="Black" noshade="noshade" size="1" />
                    <asp:Button ID="btnExport" runat="server" Text="Export To Excel" OnClick="btnExport_Click"  />
                    &nbsp;HEADING&nbsp;
                    <asp:TextBox ID="txtHeading" runat="server"></asp:TextBox>
                    <asp:Button ID="btnPrint" runat="server" Text="Print Report" OnClick="btnPrint_Click"  /></td>
            </tr>
            <tr>
                <td valign="top" align="center" style="padding-left: 5px; padding-right: 5px">
                    <div style="overflow: auto; height: 600px; width: 800px" id="divPrint" runat="server">
                        <asp:GridView ID="gvDetail" runat="server">
                            <Columns>
                                <asp:TemplateField HeaderText="S.No.">
                                    <ItemTemplate>
                                        <%# ((GridViewRow)Container).RowIndex + 1%>
                                        .
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
