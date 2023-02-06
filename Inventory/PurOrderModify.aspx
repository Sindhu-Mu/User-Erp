<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/FullLength.master" AutoEventWireup="true" CodeFile="PurOrderModify.aspx.cs" Inherits="Inventory_PurOrderModify" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="container">
        <div class="heading">
            <h2>Purchase Order Modification
            </h2>
        </div>
        <div>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <table>
                        <tr>
                            <td>
                                <table>

                                    <tr>

                                        <th>Store</th>
                                        <th>PO ID</th>
                                        <th>&nbsp;Supplier</th>
                                        <th>PO Ref.No.</th>
                                        <th>&nbsp;Purchase Order Date</th>

                                    </tr>
                                    <tr>
                                        <td style="padding-right: 4px">

                                            <asp:DropDownList ID="ddlStore" runat="server" OnSelectedIndexChanged="ddlStore_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlPO" runat="server"
                                                AutoPostBack="True" OnSelectedIndexChanged="ddlPO_SelectedIndexChanged">
                                            </asp:DropDownList></td>
                                        <td colspan="1">
                                            <asp:DropDownList ID="ddlSupplier" runat="server" Width="250px">
                                            </asp:DropDownList></td>
                                        <td colspan="1">
                                            <asp:TextBox ID="txtRefNo" runat="server" CssClass="textbox"></asp:TextBox></td>
                                        <td>
                                            <asp:Label ID="lblDate" runat="server" Font-Bold="True"></asp:Label></td>

                                    </tr>
                                    <tr>
                                        <th>Other Charges</th>
                                        <th>Discount On PO</th>
                                        <th></th>
                                        <th>Fan Id</th>
                                        <th>Pur.Req.No</th>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:TextBox ID="txtOther" runat="server" Width="100px" CssClass="textbox">0</asp:TextBox></td>
                                        <td>
                                            <asp:TextBox ID="txtDiscount" runat="server" Width="63px" CssClass="textbox">0</asp:TextBox>
                                            <asp:DropDownList ID="ddlDis" runat="server" Width="50px" OnSelectedIndexChanged="ddlDis_SelectedIndexChanged" AutoPostBack="true">
                                                <asp:ListItem>--</asp:ListItem>
                                                <asp:ListItem>Rs.</asp:ListItem>
                                                <asp:ListItem>%</asp:ListItem>
                                            </asp:DropDownList></td>
                                        <td></td>
                                        <td>
                                            <asp:Label ID="lblFAN" runat="server" Font-Bold="True"></asp:Label></td>
                                        <td>
                                            <asp:Label ID="lblPUR" runat="server" Font-Bold="True"></asp:Label></td>
                                    </tr>


                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <table>


                                    <tr>
                                        <th colspan="3">Item Name<span class="required">*</span>&nbsp;</th>
                                    </tr>
                                    <tr>
                                        <td colspan="3">
                                            <asp:DropDownList ID="ddlItem" runat="server" Width="600px" AutoPostBack="true" OnSelectedIndexChanged="ddlItem_SelectedIndexChanged">
                                            </asp:DropDownList></td>
                                    </tr>
                                    <tr>
                                        <td colspan="3">
                                            <table>

                                                <tr>
                                                    <th>Quantity<span class="required">*</span></th>
                                                    <th>Rate (Rs)<span class="required">*</span></th>
                                                    <th>Discount (%)<span class="required">*</span></th>
                                                    <th>Tax (%)<span class="required">*</span></th>
                                                    <th>Unit<span class="required">*</span></th>
                                                    <th>Specification</th>

                                                </tr>
                                                <tr>
                                                    <td>
                                                        <cc1:NumericTextBox ID="txtQty" runat="server" Width="45px" AllowDecimal="True" DecimalPlaces="3"></cc1:NumericTextBox></td>
                                                    <td>
                                                        <cc1:NumericTextBox ID="txtrate" runat="server" Width="90px" AllowDecimal="true" DecimalPlaces="3"></cc1:NumericTextBox></td>
                                                    <td>
                                                        <cc1:NumericTextBox ID="txtdisc" runat="server" Width="90px" AllowDecimal="true" DecimalPlaces="2">0</cc1:NumericTextBox>
                                                    </td>
                                                    <td>
                                                        <cc1:NumericTextBox ID="txtTax" runat="server" Width="90px" AllowDecimal="true" DecimalPlaces="3">0</cc1:NumericTextBox>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtUnit" runat="server" Width="45px"></asp:TextBox></td>
                                                    <td>
                                                        <asp:TextBox ID="txtSpecification" runat="server" Width="300px" Height="20px" >
                                                        </asp:TextBox></td>
                                                    <td>
                                                        <asp:Button ID="btnAdd" runat="server" Width="50px" Text="Add" CssClass="btnBrown" OnClick="btnAdd_Click"></asp:Button></td>
                                                </tr>

                                            </table>
                                        </td>
                                    </tr>

                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:GridView ID="gvItemDetail" runat="server" ShowFooter="True" DataKeyNames="PO_DETAIL_ID" AutoGenerateColumns="False" CssClass="gridDynamic" OnRowCancelingEdit="gvItemDetail_RowCancelingEdit" OnRowEditing="gvItemDetail_RowEditing" OnRowUpdating="gvItemDetail_RowUpdating" OnRowDeleting="gvItemDetail_RowDeleting">

                                    <Columns>
                                        <asp:TemplateField HeaderText="S#">
                                            <ItemTemplate>
                                                <%# ((GridViewRow)Container).RowIndex + 1%>
                                            </ItemTemplate>
                                            <ItemStyle Width="10px" />
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="ITEM_NAME" HeaderText="Item Description" ReadOnly="True" />
                                        <asp:TemplateField HeaderText="Qty">
                                            <EditItemTemplate>
                                                <asp:TextBox ID="txtQty" runat="server" CssClass="txtno" MaxLength="10" Text='<%# Bind("QTY") %>'
                                                    Width="70px"></asp:TextBox>
                                            </EditItemTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="lblQty" runat="server" Text='<%# Bind("QTY") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Right" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Price">
                                            <EditItemTemplate>
                                                <asp:TextBox ID="txtPrice" runat="server" CssClass="txtno" MaxLength="10" Text='<%# Bind("RATE") %>'
                                                    Width="70px"></asp:TextBox>
                                            </EditItemTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="lblRate" runat="server" Text='<%# Bind("RATE", "{0:N2}") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Right" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Amount">
                                            <ItemTemplate>
                                                <asp:Label ID="lblAmt" runat="server" Text='<%# Bind("AMOUNT", "{0:N2}") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Right" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Disc (%)">
                                            <EditItemTemplate>
                                                <asp:TextBox ID="txtDis" runat="server" CssClass="txtno" MaxLength="5" Text='<%# Bind("DISCOUNT") %>'
                                                    Width="50px"></asp:TextBox>
                                            </EditItemTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="lblDisc" runat="server" Text='<%# Bind("DISCOUNT", "{0:N2}") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Right" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Tax (%)" FooterText="Total Amount (Rs)">
                                            <EditItemTemplate>
                                                <asp:TextBox ID="txtTax" runat="server" CssClass="txtno" MaxLength="5" Text='<%# Bind("TAX") %>'
                                                    Width="50px"></asp:TextBox>
                                            </EditItemTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="lblTax" runat="server" Text='<%# Bind("TAX") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Right" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Net Amount">
                                            <ItemTemplate>
                                                <asp:Label ID="lblNetAmt" runat="server" Text='<%# Bind("NET_AMOUNT", "{0:N2}") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Right" />
                                             </asp:TemplateField>
                                             <asp:TemplateField HeaderText="Specification">
                                             <ItemTemplate>
                                                <asp:Label ID="lblSpec" runat="server" Text='<%# Bind("SPECIFICATION") %>'></asp:Label>
                                            </ItemTemplate>
                                                 </asp:TemplateField>
                                       
                                        <asp:CommandField ButtonType="Image" CancelImageUrl="~/Siteimages/cancel_icon.gif" EditImageUrl="~/Siteimages/edit.gif"
                                            ShowEditButton="True" UpdateImageUrl="~/Siteimages/update_icon.gif" />
                                        <asp:CommandField ButtonType="Image" DeleteImageUrl="~\Siteimages/delete.jpg" ShowDeleteButton="true" />

                                    </Columns>


                                </asp:GridView>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <table>

                                    <tr>
                                        <th>Net Amount (Rs)</th>
                                        <td>
                                            <asp:Label ID="lblNetAmount" runat="server" ForeColor="Blue">0</asp:Label>
                                        </td>
                                    </tr>

                                </table>
                            </td>
                        </tr>
                        <tr id="trTerm" runat="server">
                            <td>
                                <table>

                                    <tr>
                                        <td colspan="4">
                                            <strong><span style="font-size: 12px; color: #ff8c00">Payment &amp; Conditions</span></strong>
                                            <hr style="color: #ff8c00; height: 1px" />
                                            <asp:Label ID="lblPayMsg" runat="server" ForeColor="Blue" Font-Bold="true"></asp:Label></td>
                                    </tr>
                                    <tr>
                                        <th>Payment Option<span class="required">*</span></th>
                                        <th>Pay Per(%)<span class="required">*</span></th>
                                        <th>Pay Duration<span class="required">*</span></th>
                                        <th>&nbsp;</th>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:DropDownList ID="ddlPayment" runat="server">
                                                <asp:ListItem Value="0">After Delivery</asp:ListItem>
                                                <asp:ListItem Value="1">Advance with PO</asp:ListItem>
                                                <asp:ListItem Value="2">On Delivery</asp:ListItem>
                                                <asp:ListItem Value="4">After Installation </asp:ListItem>
                                            </asp:DropDownList></td>
                                        <td>
                                            <cc1:NumericTextBox ID="txtPayment" runat="server" Width="100px" CssClass="txtno"></cc1:NumericTextBox></td>
                                        <td>
                                            <cc1:NumericTextBox ID="txtPayDay" runat="server" Width="100px" CssClass="txtno"></cc1:NumericTextBox></td>
                                        <td>
                                            <asp:Button ID="btnPayAdd" runat="server" Width="60px"
                                                Text="Add" CssClass="btnBrown" OnClick="btnPayAdd_Click"></asp:Button></td>
                                    </tr>
                                    <tr>
                                        <td colspan="4">
                                            <asp:GridView ID="gvPayment" runat="server" Width="98%" CssClass="gridDynamic"
                                                AutoGenerateColumns="False" GridLines="None" OnRowDeleting="gvPayment_RowDeleting">

                                                <Columns>
                                                    <asp:TemplateField HeaderText="S#">
                                                        <ItemTemplate>
                                                            <%# ((GridViewRow)Container).RowIndex + 1%>
                                                        </ItemTemplate>
                                                        <ItemStyle Width="10px" />
                                                    </asp:TemplateField>
                                                    <asp:BoundField DataField="PO_PAY_AT" HeaderText="Payment Option">
                                                        <ItemStyle Width="200px"></ItemStyle>
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="PO_PAY_PER" HeaderText="Pay Per(%)"></asp:BoundField>
                                                    <asp:BoundField DataField="PO_PAY_DAY" HeaderText="Pay Duration"></asp:BoundField>
                                                    <asp:CommandField DeleteImageUrl="~/Siteimages/delete.jpg" ShowDeleteButton="True" ButtonType="Image"
                                                        HeaderText="Delete">
                                                        <ItemStyle Width="50px"></ItemStyle>
                                                    </asp:CommandField>
                                                </Columns>



                                            </asp:GridView>
                                        </td>
                                    </tr>

                                </table>
                                <table>

                                    <tr>
                                        <td colspan="4">
                                            <strong><span style="font-size: 12px">Term &amp; Conditions</span></strong>
                                            <hr style="color: #ff8c00; height: 1px" />
                                            <asp:Label ID="lblTermMsg" runat="server" ForeColor="Blue" Font-Bold="True"></asp:Label></td>
                                    </tr>
                                    <tr>
                                        <td>Term<span style="color: #ff0000">*</span>&nbsp;</td>
                                        <td></td>
                                        <td>Condition<span style="color: #ff0000">*</span>&nbsp;</td>
                                        <td></td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:DropDownList ID="ddlTerm" runat="server" Width="150px" OnSelectedIndexChanged="ddlTerm_SelectedIndexChanged" AutoPostBack="true">
                                            </asp:DropDownList></td>
                                        <td></td>
                                        <td>
                                            <asp:TextBox ID="txtCondition" runat="server" Width="680px" CssClass="textbox" TextMode="MultiLine"></asp:TextBox></td>
                                        <td>
                                            <asp:Button ID="btnTermAdd" runat="server" Width="60px"
                                                Text="Add " CssClass="btnBrown" OnClick="btnTermAdd_Click"></asp:Button></td>
                                    </tr>
                                    <tr>
                                        <td colspan="4">
                                            <asp:GridView ID="gvTermCondition" runat="server" Width="98%" CssClass="gridDynamic"
                                                AutoGenerateColumns="False" OnRowDeleting="gvTermCondition_RowDeleting">
                                                <Columns>
                                                    <asp:TemplateField HeaderText="S#">
                                                        <ItemTemplate>
                                                            <%# ((GridViewRow)Container).RowIndex + 1%>
                                                        </ItemTemplate>
                                                        <ItemStyle Width="10px" />
                                                    </asp:TemplateField>
                                                    <asp:BoundField DataField="PUR_TERM" HeaderText="Term">
                                                        <ItemStyle Width="200px" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="PUR_TERM_CONDITION" HeaderText="Condition" />
                                                    <asp:CommandField ButtonType="Image" ShowDeleteButton="True" DeleteImageUrl="~/Siteimages/delete.jpg">
                                                        <ItemStyle Width="50px" />
                                                    </asp:CommandField>
                                                </Columns>


                                            </asp:GridView>
                                        </td>
                                    </tr>

                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td>Remark<br />
                                <asp:TextBox ID="txtRemark" runat="server" Width="400px" Height="30px" CssClass="textbox"
                                    TextMode="MultiLine"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Button ID="btnModify" runat="server" Width="60px"
                                    Text="Modify" CssClass="btnBrown" OnClick="btnModify_Click"></asp:Button>
                                <asp:Button ID="btnCancel" runat="server" Width="60px"
                                    Text="Cancel" CssClass="btnBrown" OnClick="btnCancel_Click"></asp:Button></td>
                        </tr>
                        <tr>
                            <asp:TextBox ID="txtXML" runat="server" Visible="false"></asp:TextBox>
                            <asp:TextBox ID="txtPay" runat="server" Visible="false"></asp:TextBox>
                            <asp:TextBox ID="txtTerm" runat="server" Visible="false"></asp:TextBox>
                        </tr>
                        <tr>
                            <td>
                                <ajaxToolkit:AutoCompleteExtender ID="AutoComExt1" runat="server" EnableCaching="true" TargetControlID="txtCondition" ContextKey="1" ServicePath="../AutoComplete.asmx" ServiceMethod="GetConditionList" MinimumPrefixLength="1" CompletionSetCount="12" CompletionInterval="500">
                                </ajaxToolkit:AutoCompleteExtender>
                            </td>
                        </tr>
                    </table>
                </ContentTemplate>
            </asp:UpdatePanel>

        </div>
    </div>
</asp:Content>

