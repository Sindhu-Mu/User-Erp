<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/FullLength.master" AutoEventWireup="true" CodeFile="rptPurOrder.aspx.cs" Inherits="Inventory_rptPurOrder" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="container">
        <div class="heading">
            <h2>Purchase Order Detail
            </h2>
        </div>
        <div>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>

                    <table>
                        <tr>
                            <td style="margin-left: 10px;">
                                <table>
                                    <tr>
                                        <th>BY YEAR</th>
                                        <th>BY PUR.NO.</th>
                                        <th>BY FAN</th>
                                        <th>BY PUR.REQ.</th>
                                        <th>BY SORT</th>

                                    </tr>
                                    <tr>

                                        <td>
                                            <asp:DropDownList ID="ddlYear" runat="server" Width="100px" AutoPostBack="true" OnSelectedIndexChanged="ddlYear_SelectedIndexChanged">
                                               
                                             
                                            </asp:DropDownList>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlPOID" runat="server" Width="150px">
                                            </asp:DropDownList>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlFAN" runat="server" Width="120px">
                                            </asp:DropDownList>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlPurReq" runat="server" Width="150px">
                                            </asp:DropDownList></td>
                                        <td>
                                            <asp:DropDownList ID="ddlSort" runat="server" Width="85px">
                                                <asp:ListItem>All</asp:ListItem>
                                                <asp:ListItem Value="PO_ID">PO.ID</asp:ListItem>
                                                <asp:ListItem Value="FAN_ID">FAN</asp:ListItem>
                                                <asp:ListItem Value="PUR_REQ_ID">PUR.REQ.ID</asp:ListItem>
                                                <asp:ListItem Value="SUPP_NAME">SUPPLIER</asp:ListItem>
                                                <asp:ListItem Value="PO_STATUS">STATUS</asp:ListItem>
                                                <asp:ListItem Value="PO_DATE">DATE</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>

                                    </tr>
                                    <tr>
                                        <th colspan="2">BY SUPPLIER</th>
                                        <th colspan="3">BY DATE</th>

                                    </tr>
                                    <tr>
                                        <td colspan="2">
                                            <asp:DropDownList ID="ddlSupplier" runat="server" Width="250px">
                                            </asp:DropDownList>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlDate" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DateType_Change">
                                                <asp:ListItem Value="0">All</asp:ListItem>
                                                <asp:ListItem Value="1">Less Than</asp:ListItem>
                                                <asp:ListItem Value="2">Greater Than</asp:ListItem>
                                                <asp:ListItem Value="3">Between</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtFromDT" runat="server" Width="90px"></asp:TextBox></td>
                                        <td>
                                            <asp:TextBox ID="txtToDT" runat="server" Width="90px"></asp:TextBox>
                                        </td>

                                        <td>
                                            <asp:Button ID="btnView" runat="server" Text="View" OnClick="btnView_Click"></asp:Button>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <ajaxToolkit:MaskedEditExtender ID="ME1" runat="server" Enabled="True" TargetControlID="txtFromDT"
                                    MaskType="Date" Mask="99/99/9999">
                                </ajaxToolkit:MaskedEditExtender>
                                <ajaxToolkit:MaskedEditExtender ID="ME2" runat="server" TargetControlID="txtToDT"
                                    MaskType="Date" Mask="99/99/9999">
                                </ajaxToolkit:MaskedEditExtender>
                                <ajaxToolkit:CalendarExtender ID="CE1" runat="server" TargetControlID="txtFromDT"
                                    Format="dd/MM/yyyy">
                                </ajaxToolkit:CalendarExtender>
                                <ajaxToolkit:CalendarExtender ID="CalEx2" runat="server" TargetControlID="txtToDT"
                                    Format="dd/MM/yyyy">
                                </ajaxToolkit:CalendarExtender>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <div style="overflow: auto; width: 100%; height: 380px">
                                    <asp:GridView ID="gvPurchase" runat="server" Width="98%" DataKeyNames="PO_ID" ShowFooter="True" ShowHeader="True" AutoGenerateColumns="False"
                                        CssClass="gridDynamic" CellPadding="4" OnRowCommand="gvPurchase_RowCommand">
                                        <Columns>
                                            <asp:TemplateField HeaderText="S.No.">
                                                <ItemTemplate>
                                                    <%# ((GridViewRow)Container).RowIndex + 1%>
                                                </ItemTemplate>
                                                <ItemStyle Width="15px"></ItemStyle>
                                            </asp:TemplateField>
                                            <asp:HyperLinkField DataNavigateUrlFields="PO_ID" DataNavigateUrlFormatString="prntPurOrder.aspx?id={0}"
                                                DataTextField="PO_NO" NavigateUrl="prntPurOrder.aspx" Target="_blank" HeaderText="PO.NO.">
                                                <ControlStyle Font-Bold="True" Font-Underline="True" ForeColor="Blue"></ControlStyle>
                                                <ItemStyle Width="150px"></ItemStyle>
                                            </asp:HyperLinkField>
                                            <asp:BoundField DataField="FAN_NO" HeaderText="FAN NO.">
                                                <ItemStyle Width="80px"></ItemStyle>
                                            </asp:BoundField>
                                            <asp:BoundField DataField="PUR_REQ_NO" HeaderText="PUR.REQ.ID">
                                                <ItemStyle Width="80px"></ItemStyle>
                                            </asp:BoundField>
                                            <asp:BoundField DataField="PO_DATE" DataFormatString="{0:dd/MM/yyyy}" HeaderText="PO DATE">
                                                <ItemStyle Width="80px"></ItemStyle>
                                            </asp:BoundField>
                                            <asp:BoundField DataField="EMP_NAME" HeaderText="CREATED  BY">
                                                <ItemStyle Width="170px"></ItemStyle>
                                            </asp:BoundField>
                                            <asp:BoundField DataField="ORG_NAME" HeaderText="SUPPLIER ">
                                                <ItemStyle Width="200px"></ItemStyle>
                                            </asp:BoundField>
                                            <asp:BoundField DataField="PO_AMOUNT" DataFormatString="{0:N2}" HeaderText="AMOUNT">
                                                <ItemStyle HorizontalAlign="Right" Font-Bold="True" Width="100px"></ItemStyle>
                                            </asp:BoundField>
                                            <asp:CommandField SelectText="DETAIL" ShowSelectButton="True" ButtonType="Button"
                                                HeaderText="DETAIL">
                                                <ControlStyle CssClass="btnblue"></ControlStyle>
                                                <ItemStyle Width="50px"></ItemStyle>
                                            </asp:CommandField>

                                        </Columns>
                                    </asp:GridView>
                                </div>
                            </td>
                        </tr>
                        <tr id="trDetail" runat="server" visible="false">
                            <td>
                                <table>
                                    <tr>
                                        <th>Item Detail</th>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:GridView ID="gvItemDetail" runat="server" Width="97%"
                                                AutoGenerateColumns="False" CellPadding="2" CssClass="gridDynamic">
                                                <Columns>
                                                    <asp:TemplateField HeaderText="S.No.">
                                                        <ItemTemplate>
                                                            <%# ((GridViewRow)Container).RowIndex + 1%>
                                                        </ItemTemplate>
                                                        <ItemStyle Width="50px" />
                                                    </asp:TemplateField>
                                                    <asp:BoundField DataField="ITEM_NAME" HeaderText="ITEM NAME" />
                                                    <asp:BoundField DataField="QTY" HeaderText="QUANTITY" />
                                                    <asp:BoundField DataField="RATE" HeaderText="RATE" DataFormatString="{0:N2}" />
                                                    <asp:BoundField DataField="UNIT_NAME" HeaderText="UNIT" />
                                                    <asp:BoundField HeaderText="TAX" DataField="TAX" />
                                                    <asp:BoundField HeaderText="DISCOUNT" DataField="DISCOUNT" />
                                                    <asp:BoundField HeaderText="AMOUNT" DataField="AMOUNT" DataFormatString="{0:N2}" />
                                                    <asp:BoundField HeaderText="SPECIFICATION" DataField="SPECIFICATION" />
                                                </Columns>

                                            </asp:GridView>
                                        </td>
                                    </tr>
                                    <tr id="trPay" runat="server" visible="false">
                                        <th>Payment Condition</th>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:GridView ID="gvPayment" runat="server" AutoGenerateColumns="False" CssClass="gridDynamic" EmptyDataText="No Record Found">
                                                <Columns>
                                                    <asp:TemplateField HeaderText="S.No.">
                                                        <ItemTemplate>
                                                            <%# ((GridViewRow)Container).RowIndex + 1%>
                                                        </ItemTemplate>
                                                        <ItemStyle Width="50px" />
                                                    </asp:TemplateField>
                                                    <asp:BoundField DataField="PO_PAY_AT" HeaderText="Payment Option" />
                                                    <asp:BoundField DataField="PO_PAY_PER" HeaderText="Pay (%)" />
                                                    <asp:BoundField DataField="PO_PAY_DAY" HeaderText="Payment Duration" />
                                                </Columns>

                                            </asp:GridView>
                                        </td>
                                    </tr>
                                    <tr id="trTerm" runat="server" visible="false">
                                        <th>Term Condition Detail
                                        </th>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:GridView ID="gvTermCondition" runat="server" AutoGenerateColumns="False" CssClass="gridDynamic">
                                                <Columns>
                                                    <asp:TemplateField HeaderText="S.No.">
                                                        <ItemTemplate>
                                                            <%# ((GridViewRow)Container).RowIndex + 1%>
                                                        </ItemTemplate>
                                                        <ItemStyle Width="50px" />
                                                    </asp:TemplateField>
                                                    <asp:BoundField DataField="PUR_TERM" HeaderText="Term" />
                                                    <asp:BoundField DataField="PUR_TERM_CONDITION" HeaderText="Condition" />
                                                </Columns>
                                                <HeaderStyle ForeColor="Crimson" />
                                            </asp:GridView>
                                        </td>
                                    </tr>

                                </table>
                            </td>
                        </tr>

                    </table>

                </ContentTemplate>
            </asp:UpdatePanel>

        </div>
    </div>
</asp:Content>

