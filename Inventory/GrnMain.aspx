<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/FullLength.master" AutoEventWireup="true" CodeFile="GrnMain.aspx.cs" Inherits="Inventory_GrnMain" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script lang="javascript" type="text/javascript">
        function CheckDate(ctrl) {
            var dt = document.getElementById(ctrl).value;
            if (isDatecheck(dt, "dd/MM/yyyy") == false) {
                document.getElementById(ctrl).style.backgroundColor = "#fc6";
                return false;
            }
            else
                document.getElementById(ctrl).style.backgroundColor = "#fff";
            return true;
        }
        function CheckControl(ctrl) {
            if (bTrim(document.getElementById(ctrl).value) == "" || bTrim(document.getElementById(ctrl).value) == "." || bTrim(document.getElementById(ctrl).value) == "Select") {
                document.getElementById(ctrl).style.backgroundColor = "#fc6";
                return false;
            }
            else
                document.getElementById(ctrl).style.backgroundColor = "#fff";
            return true;
        }
        function validate() {
            var flag = true;
            var msg = "", ctrl = "";
            if (!CheckControl("<%=ddlPurchaseOrder.ClientID%>")) {
                msg += "- Select Purchase Order from List\n";
                if (ctrl == "")
                    ctrl = "<%=ddlPurchaseOrder.ClientID%>";
                flag = false;
            }
            if (!CheckControl("<%=ddlReceivedBy.ClientID%>")) {
                msg += "- Select Received By from List\n";
                if (ctrl == "")
                    ctrl = "<%=ddlReceivedBy.ClientID%>";
                flag = false;
            }
            if (!CheckControl("<%=txtBillNo.ClientID%>")) {
                msg += "- Enter Bill No. \n";
                if (ctrl == "")
                    ctrl = "<%=txtBillNo.ClientID%>";
                flag = false;
            }
            if (!CheckControl("<%=txtChallanNo.ClientID%>")) {
                msg += "- Enter Challan No. \n";
                if (ctrl == "")
                    ctrl = "<%=txtChallanNo.ClientID%>";
                flag = false;
            }
            if (!CheckControl("<%=txtDate.ClientID%>")) {
                msg += "- Enter Date \n";
                if (ctrl == "")
                    ctrl = "<%=txtDate.ClientID%>";
                flag = false;
            }
            if (!CheckControl("<%=txtExtraCharges.ClientID%>")) {
                msg += "- Enter Extra Charges \n";
                if (ctrl == "")
                    ctrl = "<%=txtExtraCharges.ClientID%>";
                flag = false;
            }
            if (!CheckControl("<%=txtGrnDetails.ClientID%>")) {
                msg += "- Enter Details \n";
                if (ctrl == "")
                    ctrl = "<%=txtExtraCharges.ClientID%>";
                flag = false;
            }
            if (msg != "") alert(msg);
            if (ctrl != "")
                document.getElementById(ctrl).focus();
            return flag;
        }
    </script>
    <div class="container">
        <div class="heading">
            <h2>GRN Main</h2>
        </div>
        <div>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <table>
                        <tr>
                            <td>
                                <table>
                                    <tr>
                                        <th>Purchase Order<span class="required">*</span>
                                        </th>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:DropDownList ID="ddlPurchaseOrder" runat="server" required="required" AutoPostBack="True" Width="150px" OnSelectedIndexChanged="ddlPurchaseOrder_SelectedIndexChanged"></asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>

                                            <div style="border-collapse: collapse; border-spacing: 0px; overflow: auto; width: 100%">
                                                <asp:GridView ID="gridPurchaseDetails" runat="server" AutoGenerateColumns="false" DataKeyNames="ITEM_CODE" CssClass="gridDynamic" AlternatingRowStyle-CssClass="alt" Width="100%" EmptyDataText="No record found">
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="S#">
                                                            <ItemTemplate>
                                                                <%# ((GridViewRow)Container).RowIndex + 1%>.
                                                            </ItemTemplate>
                                                            <ItemStyle Width="10px" />
                                                        </asp:TemplateField>
                                                        <asp:BoundField HeaderText="Item Name" DataField="ITEM_NAME">
                                                            <ItemStyle HorizontalAlign="Right" />
                                                            <HeaderStyle HorizontalAlign="Right" />
                                                        </asp:BoundField>

                                                        <asp:BoundField HeaderText="Ordered Quantity" DataField="ODR_QTY">
                                                            <ItemStyle Width="40px" />
                                                        </asp:BoundField>
                                                        <asp:BoundField HeaderText="Balance Quantity" DataField="QTY">
                                                            <ItemStyle Width="40px" />
                                                        </asp:BoundField>
                                                        <asp:TemplateField HeaderText="Received Quantity">
                                                            <ItemTemplate>
                                                                <cc1:NumericTextBox ID="txtQuantity" runat="server" Width="50px" placeholder="Quantity" Text='<%#Eval("QTY") %>' required="required" Style="text-align: center">
                                                                </cc1:NumericTextBox>
                                                            </ItemTemplate>
                                                            <ItemStyle Width="10px" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Rate">
                                                            <ItemTemplate>
                                                                <cc1:NumericTextBox ID="txtRate" runat="server" Width="50px" placeholder="Rate" Text='<%#Eval("RATE") %>' required="required" Style="text-align: center">
                                                                </cc1:NumericTextBox>
                                                            </ItemTemplate>
                                                            <ItemStyle Width="10px" />
                                                        </asp:TemplateField>
                                                    </Columns>
                                                </asp:GridView>
                                            </div>

                                        </td>
                                    </tr>

                                </table>
                            </td>
                            <td style="width: 1px; height: 100%; border-left: 1px solid red"></td>
                            <td style="width: 50%; vertical-align: top">
                                <table>
                                    <tr>
                                        <td>
                                            <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                                <ContentTemplate>
                                                    <table>
                                                        <tr>
                                                            <td>
                                                                <table>
                                                                    <tr>
                                                                        <th>Details<span class="expected">*</span>
                                                                        </th>
                                                                        <th>Date<span class="required">*</span>
                                                                        </th>
                                                                        <th>Received By<span class="required">*</span>
                                                                        </th>
                                                                        <th>Extra Charges<span class="expected">*</span>
                                                                        </th>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                            <asp:TextBox ID="txtGrnDetails" runat="server" MaxLength="50" Width="200px" placeholder="Details" CssClass="textbox"></asp:TextBox>
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="txtDate" runat="server" Width="85px" required="required" CssClass="textbox"></asp:TextBox>
                                                                            <ajaxToolkit:CalendarExtender ID="cal1" runat="server" TargetControlID="txtDate" Format="dd/MM/yyyy" PopupPosition="TopLeft">
                                                                            </ajaxToolkit:CalendarExtender>
                                                                            <ajaxToolkit:MaskedEditExtender ID="me1" runat="server" Mask="99/99/9999" MaskType="Date"
                                                                                TargetControlID="txtDate">
                                                                            </ajaxToolkit:MaskedEditExtender>

                                                                        </td>
                                                                        <td>
                                                                            <asp:DropDownList ID="ddlReceivedBy" runat="server" required="required" CssClass="textbox" Width="200px"></asp:DropDownList>
                                                                        </td>
                                                                        <td>
                                                                            <cc1:NumericTextBox ID="txtExtraCharges" runat="server" CssClass="textbox" MaxLength="4" Width="80px" Text="0" placeholder="Charges" required="required"></cc1:NumericTextBox>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <table>
                                                                    <tr>
                                                                        <th>Bill No.<span class="expected">*</span>
                                                                        </th>
                                                                        <th>Challan No.<span class="required">*</span>
                                                                        </th>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                            <asp:TextBox ID="txtBillNo" placeholder="Bill" runat="server" CssClass="textbox"></asp:TextBox>
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="txtChallanNo" placeholder="Challan" runat="server" CssClass="textbox" required="required"></asp:TextBox>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </td>
                                    </tr>

                                    <tr>
                                        <td>
                                            <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" />
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

