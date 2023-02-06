<%@ Page Language="C#" AutoEventWireup="true" CodeFile="prntSto_SIV.aspx.cs" Inherits="Inventory_prntSto_SIV" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Store Issue Voucher</title>
</head>
<body style="font-family: Book Antiqua; font-size: 13px">
    <form id="Form2" runat="server">
        <table width="680px" >
            <tr>
                <td align="center">
                    <span style="font-size: 16pt;">Mangalayatan University</span><br />
                        <span style="font-size: 10pt">Extended NCR, Aligarh-Mathura Highway<br />
                            Beswan, Aligarh-202145, India</span><br />                       
                            <span style="font-size: 14pt">STORE ISSUE VOUCHER</span></td>
            </tr>
            <tr>
                <td >
                    <hr style="color: Black" size="1px" />
                    &nbsp;&nbsp;</td>
            </tr>
            <tr>
                <td>
                    <table cellpadding="0" cellspacing="0"  width="100%">
                        <tr>
                            <td>SIV ID</td>
                            <td style="width: 10px">:</td>
                            <td>
                                <asp:Label ID="lblsiv" runat="server" /></td>

                            <td>DATE</td>
                            <td >:</td>
                            <td>
                                <asp:Label ID="lbldate" runat="server" /></td>
                        </tr>
                        <tr>
                            <td>INDENT ID</td>
                            <td>:</td>
                            <td>
                                <asp:Label ID="lblIndent" runat="server" /></td>

                            <td>DEPARTMENT</td>
                            <td>:</td>
                            <td>
                                <asp:Label ID="lblDept" runat="server" /></td>
                        </tr>
                        <tr>
                            <td>RECEIVE AS</td>
                            <td>:</td>
                            <td colspan="4">
                                <asp:Label ID="lblReceiveAs" runat="server"></asp:Label></td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td >
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="2" Width="97%" DataKeyNames="ITEM_ID">
                        <Columns>
                            <asp:TemplateField HeaderText="S#">
                                <ItemTemplate>
                                    <%# ((GridViewRow)Container).RowIndex + 1%>.
                                </ItemTemplate>
                                <ItemStyle Width="10px" />
                            </asp:TemplateField>
                            <asp:BoundField HeaderText="Item Name" DataField="ITEM_NAME">
                                <ItemStyle HorizontalAlign="Left" />
                            </asp:BoundField>
                            <asp:BoundField HeaderText="Qty" DataField="QTY">
                                <ItemStyle HorizontalAlign="Right" />
                            </asp:BoundField>
                             <asp:BoundField HeaderText="Remark" DataField="REMARK">
                                <ItemStyle HorizontalAlign="Right" />
                            </asp:BoundField>
                        </Columns>                      
                    </asp:GridView>
                </td>
            </tr>
            <tr>
                <td>&nbsp;</td>
            </tr>
            <%--<tr>
                <td>Remark:
                    <asp:Label ID="lblRemark" runat="server" Style="overflow:hidden" Width="650px" />
                </td>
            </tr>--%>
            <tr>
                <td>&nbsp;</td>
            </tr>
         
            <tr>
                <td>
                    <table cellpadding="0" cellspacing="0" width="100%">
                        <tr>
                            <td>Issued by<br />
                                <asp:Label ID="lblIssuedBy" runat="server" /></td>
                            <td align="right">Received by<br />
                                <asp:Label ID="lblReceiveBy" runat="server" /></td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
