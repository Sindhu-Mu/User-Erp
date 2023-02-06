<%@ Page Language="C#" AutoEventWireup="true" CodeFile="rptBankDetail.aspx.cs" Inherits="PayRoll_rptBankDetail" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>Payroll Detail</title>
<link href="../css/erp.css" rel="stylesheet" type="text/css" />

    <script language="javascript" type="text/javascript">

        function doPrint() {
            var prtContent = document.getElementById('<%= divPrint.ClientID %>');
            prtContent.border = 1; //set no border here   
            var WinPrint = window.open('', '', 'left=100,top=100,width=1000,height=1000,toolbar=0,scrollbars=1,status=0,resizable=1');
            WinPrint.document.write(prtContent.outerHTML);
            WinPrint.document.close();
            WinPrint.focus();
            WinPrint.print();
            WinPrint.close();
        }
    </script>

</head>
<body>
    <form id="form1" runat="server">
        <table border="0" cellpadding="0" cellspacing="0" style="width: 100%; font-size: small;">
            <tr>
                <td align="center">
                    <span style="font-size: 16pt; font-family: Arial"><span style="text-decoration: underline">Mangalayatan University<br />
                    </span><span style="font-size: 10pt"></span><span style="font-size: 10pt"><span style="font-size: 14pt">
                        BANK TRANSFER DETAIL</span></span></span></td>
            </tr>
            <tr>
                <td>
                    <hr color="Black" noshade="noshade" size="1" />
                    <asp:Button ID="btnExport" runat="server" Text="Export To Excel" OnClick="btnExport_Click" />
                    &nbsp;HEADING&nbsp;
                    <asp:TextBox ID="txtHeading" runat="server"></asp:TextBox>
                    <asp:Button ID="btnPrint" runat="server" Text="Print Report" OnClick="btnPrint_Click" /></td>
            </tr>
            <tr>
                <td valign="top" align="center" style="padding-left: 5px; padding-right: 5px">
                    <div style="overflow:scroll; height: 500px; width: 800px" id="divPrint" runat="server">
                        <asp:GridView ID="gvDetail" runat="server" EmptyDataText="No Record found">
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
