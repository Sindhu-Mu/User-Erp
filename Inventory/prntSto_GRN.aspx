<%@ Page Language="C#" AutoEventWireup="true" CodeFile="prntSto_GRN.aspx.cs" Inherits="Inventory_prntSto_GRN" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<html>
<head>
    <title>Goods Receive Note</title>
    <meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR" />
    <meta content="C#" name="CODE_LANGUAGE" />
    <meta content="JavaScript" name="vs_defaultClientScript" />
    <meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema" />
    <link href="../css/StyleSheet.css" type="text/css" rel="stylesheet" />
</head>
<body>
    <form id="Form1" method="post" runat="server">
        <table id="Table1" width="650px" style="font-size: 10pt; font-family: Tahoma">
            <tr>
                <td align="center" colspan="4">
                    <asp:Label ID="lblInstitution" runat="server" Font-Names="Arial" Font-Size="Medium" /><br />
                    <span style="font-family: Arial;">Extended NCR, Aligarh-Mathura Highway<br />
                        Beswan, Aligarh-202145, India</span></td>
            </tr>
            <tr>
                <td colspan="4"></td>
            </tr>
            <tr>
                <td align="center" colspan="4">
                    <span style="font-family: Arial;"><strong>GOODS RECEIVED NOTE</strong></span></td>
            </tr>
            <tr>
                <td colspan="4">&nbsp;</td>
            </tr>
            <tr>
                <td class="lblbig">GRN No:</td>
                <td>
                    <asp:Label ID="lblGRN" runat="server" Font-Bold="True" /></td>
                <td class="lblbig">Date:</td>
                <td>
                    <asp:Label ID="lblGrnDate" runat="server" Font-Bold="True" /></td>
            </tr>
            <tr>
                <td class="lblbig">Store Name:</td>
                <td>
                    <asp:Label ID="lblStore" runat="server" Font-Bold="True" /></td>
                <td class="lblbig">P.O. No:</td>
                <td>
                    <asp:Label ID="lblPO" runat="server" Font-Bold="True" /></td>
            </tr>
            <tr>
                <td class="lblbig">Supplier:</td>
                <td colspan="3">
                    <asp:Label ID="lblSupp" runat="server" Font-Bold="True" /></td>
            </tr>
            <tr>
                <td class="lblbig" style="height: 20px">Bill No:</td>
                <td style="height: 20px">
                    <asp:Label ID="lblBill" runat="server" Font-Bold="True" /></td>
                <td class="lblbig" style="height: 20px">Challan No:</td>
                <td style="height: 20px">
                    <asp:Label ID="lblChall" runat="server" Font-Bold="True" /></td>
            </tr>
            <tr>
                <td class="lblbig">Ledger/Folio No:</td>
                <td>
                    <asp:Label ID="lblLedger" runat="server" Font-Bold="True" /></td>
                <td class="lblbig">F. A. No:</td>
                <td>
                    <asp:Label ID="lblFAN" runat="server" Font-Bold="True" /></td>
            </tr>
            <tr>
                <td valign="middle" align="center" colspan="4">
                    <hr style="color:#000;" size="1px" />
                    LIST OF ITEM(S)<style="color:#000;" size="1px" />
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" BorderStyle="None"
                        Font-Size="X-Small"
                        ShowFooter="True" BackColor="White" BorderColor="#CCCCCC" BorderWidth="1px" CellPadding="3" DataKeyNames="ITEM_ID" OnDataBound="GridView1_DataBound">
                        <FooterStyle HorizontalAlign="Right" BackColor="White" ForeColor="#000066" />
                        <Columns>
                            <asp:TemplateField HeaderText="S#">
                                <ItemTemplate>
                                    <%# ((GridViewRow)Container).RowIndex + 1%>.
                                </ItemTemplate>
                                <ItemStyle Width="10px" />
                            </asp:TemplateField>
                            <asp:BoundField DataField="ITEM_NAME" HeaderText="Item Name" HtmlEncode="False" />
                            <asp:BoundField DataField="UNIT_NAME" HeaderText="Unit" />
                            <asp:BoundField DataField="QTY" HeaderText="Qty">
                                <ItemStyle HorizontalAlign="Right" />
                            </asp:BoundField>
                            <asp:BoundField HeaderText="ID No." />
                            <asp:BoundField HeaderText="Batch" />
                            <asp:BoundField HeaderText="ExpDate">
                                <ItemStyle HorizontalAlign="Right" />
                            </asp:BoundField>
                            <asp:BoundField DataField="DISCOUNT" HeaderText="Disc(%)" DataFormatString="{0:N2}" HtmlEncode="False">
                                <ItemStyle HorizontalAlign="Right" />
                            </asp:BoundField>
                            <asp:BoundField DataField="TAX" HeaderText="Tax(%)" DataFormatString="{0:N2}" HtmlEncode="False">
                                <ItemStyle HorizontalAlign="Right" />
                            </asp:BoundField>
                            <asp:BoundField DataField="RATE" HeaderText="Price" DataFormatString="{0:N2}" HtmlEncode="False">
                                <ItemStyle HorizontalAlign="Right" />
                            </asp:BoundField>
                            <asp:BoundField DataField="total" HeaderText="Total" DataFormatString="{0:N2}" HtmlEncode="False">
                                <ItemStyle HorizontalAlign="Right" />
                            </asp:BoundField>
                            <asp:BoundField DataField="SPECIFICATION" HeaderText="Specification" />
                        </Columns>
                        <RowStyle ForeColor="#000066" />
                        <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                        <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                    </asp:GridView>
                </td>
            </tr>
            <tr id="trOtherCharges" runat="server">
                <td colspan="3" align="right">Others Charges (Transportation etc.)<hr />
                    Net Amount (Rs)</td>
                <td>
                    <asp:Label ID="lblOtherCharges" runat="server" /><hr />
                    <asp:Label ID="lblNetAmount" runat="server" /></td>
            </tr>
            <tr>
                <td colspan="4" valign="middle">
                    <asp:Label ID="lblWord" runat="server" Font-Bold="True" /></td>
            </tr>
            <tr>
                <td valign="middle" colspan="4">&nbsp;</td>
            </tr>
            <tr>
                <td align="center" colspan="4" valign="middle">&nbsp;</td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblClerkName" runat="server" Font-Bold="True" /></td>
                <td align="right">
                    <span style="font-size: 12pt; font-family: Times New Roman">
                        <p class="MsoNormal" style="margin: 0in 0in 0pt">
                            <span style="font-size: 10pt; font-family: Arial"></span>
                        </p>
                    </span>
                </td>
                <td align="right"></td>
                <td class="lblbig">Store Manager</td>

            </tr>
        </table>
    </form>
</body>
</html>
