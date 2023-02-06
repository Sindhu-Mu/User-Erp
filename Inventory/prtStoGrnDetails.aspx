<%@ Page Language="C#" AutoEventWireup="true" CodeFile="prtStoGrnDetails.aspx.cs" Inherits="Inventory_prtStoGrnDetails" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>GRN</title>
</head>
<body>
    <form id="form1" runat="server">
        <table style="width: 700px; border-collapse: collapse; border-spacing: 0px">
            <tr>
                <td>
                    <asp:Repeater ID="repStoreIssueVoucher" runat="server" EnableViewState="false">
                        <ItemTemplate>
                            <table style="width: 100%; border-collapse: collapse; border-spacing: 0px;">
                                <tr>
                                    <td>
                                        <table style="width: 100%; text-align: center; border-collapse: collapse; border-spacing: 0px;
                                            font-family: Arial">
                                            <tr>
                                                <th>
                                                    <span style="font-size: 16pt">Mangalayatan University</span>
                                                </th>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <span style="font-size: 10pt">Extended NCR, Aligarh-Mathura Highway</span>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <span style="font-size: 10pt">Beswan, Aligarh-202145, India</span>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr style="padding-top: 10px">
                                    <td>
                                        <table style="width: 100%; text-align: center; border-collapse: collapse; border-spacing: 0px">
                                            <tr>
                                                <th style="font-size: 14pt">
                                                    Good Received Note for
                                                    <%#Eval("STO_NAME")%>
                                                </th>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <hr style="color: #ff8c00; width: 100%; height: 0px; border-bottom-color: black;
                                                        border-bottom-width: 1px; border-collapse: collapse; border-spacing: 0px;" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <table style="margin: auto" class="space">
                                            <tr>
                                                <th>
                                                    Grn Id.:
                                                </th>
                                                <td>
                                                    <%#Eval("GRN_NO")%>&nbsp;
                                                </td>
                                                <th>
                                                    Date:
                                                </th>
                                                <td>
                                                    <%#Eval("GRN_DATE")%>&nbsp;
                                                </td>
                                                <th>
                                                    Po Id.:
                                                </th>
                                                <td>
                                                    <%#Eval("PO_CAL_ID")%>&nbsp;
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <table style="margin: auto" class="space">
                                            <tr>
                                                <th style="vertical-align: top; word-wrap: normal; text-wrap: normal">
                                                    Supplier:
                                                </th>
                                                <td>
                                                    <%#Eval("SUPPLIER")%>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <table style="margin: auto" class="space">
                                            <tr>
                                                <th>
                                                    Bill No.
                                                </th>
                                                <td>
                                                    <%#Eval("BILL_NO")%>&nbsp;
                                                </td>
                                                <th>
                                                    Challan No.
                                                </th>
                                                <td>
                                                    <%#Eval("CLN_NO")%>&nbsp;
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <hr style="width: 100%; height: 0px; border-bottom-color: gray; border-bottom-width: 1px;
                                            border-collapse: collapse; border-spacing: 0px;" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <table style="width: 100%; text-align: center; border-collapse: collapse; border-spacing: 0px;
                                            margin: auto">
                                            <tr>
                                                <th>
                                                    Item Details
                                                </th>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:GridView ID="gridItem" runat="server" AutoGenerateColumns="false" EnableViewState="false"
                                                        Width="97%" ShowFooter="true">
                                                        <FooterStyle BorderColor="White" Font-Bold="true" />
                                                        <Columns>
                                                            <asp:TemplateField HeaderText="S#">
                                                                <ItemTemplate>
                                                                    <%# ((GridViewRow)Container).RowIndex + 1%>
                                                                    .
                                                                </ItemTemplate>
                                                                <ItemStyle Width="10px" />
                                                            </asp:TemplateField>
                                                            <asp:BoundField DataField="ITEM_NAME" HeaderText="Item">
                                                              <HeaderStyle HorizontalAlign="left" />
                                                                <ItemStyle Wrap="true" HorizontalAlign="left" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="QTY" HeaderText="Qty.">
                                                                <ItemStyle Width="60px" HorizontalAlign="Right" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="RATE" HeaderText="Rate">
                                                                <ItemStyle Width="60px" HorizontalAlign="Right"/>
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="AMT" HeaderText="Amt">
                                                                <ItemStyle Width="60px" HorizontalAlign="Right"/>
                                                            </asp:BoundField>
                                                            
                                                        </Columns>
                                                        
                                                    </asp:GridView>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <pre>


                                        </pre>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="padding-left: 70px;text-align:right">
                                        <table style="border-collapse: collapse; border-spacing: 0px;">
                                            <thead style="display: none">
                                                <tr>
                                                    <th style="">
                                                    </th>
                                                </tr>
                                            </thead>
                                            <tr>
                                                <th>
                                                    --------------------------
                                                </th>
                                            </tr>
                                            <tr>
                                                <th>
                                                    Received By
                                                </th>
                                            </tr>
                                            <tr>
                                                <th>
                                                    (<%#Eval("RCV_BY_VALUE")%>)
                                                </th>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </ItemTemplate>
                    </asp:Repeater>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblGrnID" runat="server" CssClass="heading" /></td>
            </tr>
        </table>
    </form>
</body>
</html>
