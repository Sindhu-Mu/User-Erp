<%@ Page Language="C#" AutoEventWireup="true" CodeFile="rptFees.aspx.cs" Inherits="Finance_rptFees" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <table style="width: 100%; font-size: 13px;">
            <tr>
                <td style="font-size: 16pt; text-align: center; text-decoration: underline;">Mangalayatan University<br />
                    FEES DETAIL</td>
            </tr>
            <tr>
                <td>
                    <hr />
                    <asp:Button ID="btnExport" runat="server" Text="Export To Excel" OnClick="btnExport_Click1" />   &nbsp;
                     <asp:Label ID="lblError" runat="server" Text="No Record Found" Font-Bold="true" Font-Size="Large" Visible="false" ForeColor="#ff5050"></asp:Label>
                 </td>
            </tr>
          
           
            <tr>
                <td>
                    <div style="overflow: auto; height: 600px; width: 800px">
                        <asp:GridView ID="gvDetail" runat="server" EmptyDataText="No Record Found">
                            <Columns>
                                <asp:TemplateField HeaderText="S.No.">
                                    <ItemTemplate>
                                        <%# ((GridViewRow)Container).RowIndex + 1%>
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
