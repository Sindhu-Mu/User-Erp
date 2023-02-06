<%@ Page Language="C#" AutoEventWireup="true" CodeFile="prntPurOrder.aspx.cs" Inherits="Inventory_prntPurOrder" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Purchase Order</title>
   

  
    

</head>
<body onload="window.print();" oncontextmenu="return false" ondragstart="return false"
    onselectstart="return false">
    <form id="form1" runat="server">
        <table cellspacing="0" style="font-family: Arial; font-size: 10pt; width: 650px">
            <tr>
                <td>
                    <table cellpadding="0" cellspacing="0" border="0" width="100%">
                        <tr>
                            <td align="left" style="width: 50%" valign="top">
                               <img src="../Siteimages/mu_logo.jpg" alt="" style="width: 300px; height: 100px" runat="server" id="ImgLogo" /></td>
                            <td width="45%">
                                <p style="margin-top: 0; margin-bottom: 0">
                                    &nbsp;</p>
                                <p style="margin-top: 0; margin-bottom: 0">
                                    &nbsp;</p>
                                <p style="margin-top: 0; margin-bottom: 0">
                                    &nbsp;</p>
                                <p style="margin-top: 0; margin-bottom: 0" align="right">
                                    <font face="Tahoma" size="2">Extended NCR, Aligarh-Mathura Highway</font></p>
                                <p style="margin-top: 0; margin-bottom: 0" align="right">
                                    <font face="Tahoma" size="2">Beswan, Aligarh-202146, India</font></p>
                                <p style="margin-top: 0; margin-bottom: 0" align="right">
                                    <font face="Tahoma" size="2">Tel: 0571-3258592-93 Fax: 05722-254223</font></p>
                                <p style="margin-top: 0; margin-bottom: 0" align="right">
                                    <font face="Tahoma" size="2">Website: www.mangalayatan.in</font></p>
                                <p style="margin-top: 0; margin-bottom: 0" align="right" >GSTIN -: <asp:Label ID="lblGSTIN" runat="server" Font-Bold="true"></asp:Label></p>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td align="center">
                    <span style="font-size: 14pt; text-decoration: underline;">PURCHASE ORDER/WORK ORDER</span></td>
            </tr>
            <tr>
                <td align="center">
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    PO No :<asp:Label ID="lblPo" runat="server" Font-Bold="True" /></td>
            </tr>
            <tr>
                <td>
                    Date :<asp:Label ID="lblDate" runat="server" Font-Bold="True" /></td>
            </tr>
            <tr>
                <td>
                    To,
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblSuppName" runat="server" Font-Bold="False" /></td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblSuppAddress" runat="server" /></td>
            </tr>
            <tr>
                <td align="center">
                    Ref :
                    <asp:Label ID="lblContent" runat="server" Font-Bold="True" /></td>
            </tr>
            <tr>
                <td>
                    Reference to above we are please to place following order along with Terms and Condition
                    mentioned below.
                </td>
            </tr>
            <tr>
                <td>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:GridView ID="gvItem" runat="server" AutoGenerateColumns="False" 
                        ShowFooter="True" CellPadding="3" CssClass="lblblack" Width="650px" OnDataBound="gvItem_DataBound">
                        <Columns>
                            <asp:TemplateField HeaderText="S.No.">
                                <ItemTemplate>
                                    <%# ((GridViewRow)Container).RowIndex + 1%>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="ITEM_NAME" HeaderText="Item Name" />
                            
                            <asp:BoundField DataField="QTY" HeaderText="Qty">
                                <ItemStyle HorizontalAlign="Right" />
                            </asp:BoundField>
                            <asp:BoundField DataField="RATE" HeaderText="Rate(Rs)" DataFormatString="{0:N2}"
                                HtmlEncode="False">
                                <ItemStyle HorizontalAlign="Right" />
                            </asp:BoundField>
                            <asp:BoundField DataField="TAX" HeaderText="GST(%)" />
                            <asp:BoundField DataField="DISCOUNT" HeaderText="Disc(%)" />
                            <asp:BoundField HeaderText="Total (Rs)" DataFormatString="{0:N2}" HtmlEncode="False"
                                DataField="AMOUNT">
                                <ItemStyle HorizontalAlign="Right" />
                            </asp:BoundField>
                            <asp:BoundField  DataField="SPECIFICATION" HeaderText="Specification"/>
                        </Columns>
                        <FooterStyle Font-Bold="True" HorizontalAlign="Right" />
                    </asp:GridView>
                </td>
            </tr>
            <tr id="trOther" runat="server">
                <td align="center">
                    <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
                        <tr>
                            <td></td>
                        </tr>
                        <%--<tr>
                            <td style="width: 50%">
                                Discount On Total Amount:<asp:Label ID="lblTotalDis" runat="server" Text="0.00"></asp:Label></td>
                            <td style="width: 50%; text-align:right">
                                Other Charges With Total Amount:<asp:Label ID="lblOtherCh" runat="server" Text="0.00"></asp:Label></td>
                        </tr>--%>
                    </table>
                </td>
            </tr>
            <tr>
                <td align="center">
                    <asp:Label ID="lblAmountInWords" runat="server" Font-Bold="true" /></td>
            </tr>
            <tr>
                <td></td>
            </tr>
            <tr>
                <td>
                    <span style="text-decoration: underline">Terms and Condition:</span></td>
            </tr>
            <tr>
                <td>
                    <asp:GridView ID="gvTermCond" runat="server" AutoGenerateColumns="False" CellPadding="3"
                        CssClass="lblblack">
                        <Columns>
                            <asp:TemplateField HeaderText="S.No.">
                                <ItemTemplate>
                                    <%# ((GridViewRow)Container).RowIndex + 1%>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="PUR_TERM" HeaderText="Term">
                                <ItemStyle Width="100px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="PUR_TERM_CONDITION" HeaderText="Condition">
                                <ItemStyle Width="500px" />
                            </asp:BoundField>
                        </Columns>
                    </asp:GridView>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    Thanking You,</td>
            </tr>
            <tr>
                <td style="height: 18px">
                    For Mangalayatan University,</td>
            </tr>
            <tr>
                <td style="height: 18px">
                    &nbsp;</td>
            </tr>
            <tr>
                <td style="height: 18px">
                </td>
            </tr>
            <tr>
                <td style="height: 18px">
                    Authorized Signatory</td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                </td>
            </tr>
            <tr>
                <td>
                </td>
            </tr>
        </table>
    </form>
</body>
</html>

