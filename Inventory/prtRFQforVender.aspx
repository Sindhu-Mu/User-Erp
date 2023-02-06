<%@ Page Language="C#" AutoEventWireup="true" CodeFile="prtRFQforVender.aspx.cs" Inherits="Inventory_prtRFQforVender" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Untitled Page</title>
</head>

<body onload="window.print();window.close();" oncontextmenu="return false" ondragstart="return false"
    onselectstart="return false">
    <form id="form2" runat="server">
        <asp:Repeater ID="Repeater1" runat="server" OnItemDataBound="Repeater1_ItemDataBound" OnItemCommand="Repeater1_ItemCommand">
            <ItemTemplate>
                <table cellspacing="0" cellpadding="0" style="font-family: Times New Roman; font-size: 14px; width: 700px">
                    <tr>
                        <td>
                            <table cellpadding="0" cellspacing="0" border="0" width="100%">
                                <tr>
                                    <td align="left" style="width: 50%" valign="top">
                                        <img src="../Siteimages/logo-1.png" alt="" style="width: 270px; height: 127px" />
                                    </td>
                                    <td style="width: 45%; font-family: Tahoma" align="right">
                                        <br />
                                        <br />
                                        <br />
                                        Extended NCR, Aligarh-Mathura Highway<br />
                                        Beswan, Aligarh-202145, India<br />
                                        Tel: 0571-3258592-93 Fax: 05722-254220<br />
                                        Website: www.mangalayatan.in</td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td align="center">
                            <span style="font-size: 14pt; text-decoration: underline;">REQUEST FOR QUOTATION</span></td>
                    </tr>
                    <tr>
                        <td align="center">&nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
                                <tr>
                                    <td>RFQ NO :  <%# Eval("PUR_RFQ_NO") %></td>
                                    <td style="text-align: right">Date :<%# Eval("DT")%></td>
                                </tr>
                            </table>
                        </td>
                    </tr>

                    <tr>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td>To,
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <%# Eval("NAME") %></td>
                    </tr>
                    <tr>
                        <td>
                            <%# Eval("ADDRESS") %></td>
                    </tr>
                    <tr>
                        <td>
                            <%# Eval("CITY") %></td>
                    </tr>
                    <tr>
                        <td>
                            <%# Eval("STATE") %></td>
                    </tr>
                    <tr>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td style="height: 350px" valign="top">
                            <asp:GridView ID="gvItemDetail" runat="server" AutoGenerateColumns="False" ShowFooter="True"
                                CellPadding="3" Width="650px">
                                <Columns>
                                    <asp:TemplateField HeaderText="S.No.">
                                        <ItemTemplate>
                                            <%# ((GridViewRow)Container).RowIndex + 1%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="ITEM_NAME" HeaderText="Item Name" />
                                    <asp:BoundField DataField="QTY" HeaderText="Quantity">
                                        <ItemStyle HorizontalAlign="Right" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="UNIT" HeaderText="Unit" />
                                    <%--<asp:BoundField HeaderText="Specification" DataField="REQ_JUSTIFICATION" HtmlEncode="False">--%>
                                    <%--<ItemStyle HorizontalAlign="Right" />--%>
                                    <%--</asp:BoundField>--%>
                                </Columns>
                                <FooterStyle Font-Bold="True" HorizontalAlign="Right" />
                            </asp:GridView>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <%# Eval("PUR_RFQ_REMARK") %></td>
                    </tr>
                    <tr>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td>Thanking You,</td>
                    </tr>
                    <tr>
                        <td style="height: 18px">For Mangalayatan University,</td>
                    </tr>
                    <tr>
                        <td style="height: 18px">&nbsp;</td>
                    </tr>
                    <tr>
                        <td style="height: 18px"></td>
                    </tr>
                    <tr>
                        <td style="height: 18px">Authorized Signatory</td>
                    </tr>
                    <tr>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td>&nbsp;</td>
                    </tr>

                </table>
            </ItemTemplate>
        </asp:Repeater>
    </form>
</body>

</html>
