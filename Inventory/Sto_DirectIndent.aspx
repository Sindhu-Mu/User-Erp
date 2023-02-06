<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/FullLength.master" AutoEventWireup="true" CodeFile="Sto_DirectIndent.aspx.cs" Inherits="Inventory_Sto_DirectIndent" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">


    <script type="text/javascript">

        function CheckControl(ctrl) {
            if (bTrim(document.getElementById(ctrl).value) == "" || bTrim(document.getElementById(ctrl).value) == "Select") {
                document.getElementById(ctrl).style.backgroundColor = "#fc6";
                return false;
            }
            else {
                document.getElementById(ctrl).style.backgroundColor = "#fff";
                return true;
            }
        }
        function CheckAutoComplete(ctrl) {
            var Value = bTrim(document.getElementById(ctrl).value);
            if (Value.indexOf(":") > 0 && Value.length - 1 != Value.lastIndexOf(":")) {
                document.getElementById(ctrl).style.backgroundColor = "#fff";
                return true;
            }
            else
                document.getElementById(ctrl).style.backgroundColor = "#fc6";
            return false;

        }
        function CheckQty() {

            var sto_qty_feild = document.getElementById("<%=ddlItem.ClientID %>");
            var selValue = sto_qty_feild.options[sto_qty_feild.selectedIndex].innerText;

            var near = selValue.lastIndexOf('(') + 1;
            var far = selValue.length - 1;


            var sto_qty = selValue.substring(near, far);

            var req_qty = document.getElementById("<%=txtReqQuantity.ClientID %>");
             var apr_qty = document.getElementById("<%=txtAprQuantity.ClientID %>");


            if ((parseInt(apr_qty.value) == 0) || (parseInt(req_qty.value) == 0)) {
                alert("Approved quantity or required quantity cannot be equal to 0 (zero)");
                return false;
            }

            else if (parseInt(sto_qty) < parseInt(apr_qty.value)) {
                alert('Approved quantity cannot be greater than store quantity');
                return false;
            }

            else if (parseInt(apr_qty.value) > parseInt(req_qty.value)) {
                alert("Approved quantity cannot be greater than required quantity");
                return false;
            }

            return true;
        }
        function validateBtnAdd() {
            alert("HI");
            var flag = true;
            var msg = "", ctrl = "";

            if (!CheckControl("<%=ddlLocation.ClientID%>")) {
                msg += "- Select Location\n";
                if (ctrl == "") {
                    ctrl = "<%=ddlLocation.ClientID%>";
                }
                flag = false;
            }
            if (!CheckControl("<%=ddlReceivingAs.ClientID%>")) {
                msg += "- Select Receiving As\n";
                if (ctrl == "") {
                    ctrl = "<%=ddlReceivingAs.ClientID%>";
                }
                flag = false;
            }
            if (!CheckControl("<%=ddlStore.ClientID%>")) {
                msg += "- Select Store Name\n";
                if (ctrl == "") {
                    ctrl = "<%=ddlStore.ClientID%>";
                }
                flag = false;
            }
            if (!CheckControl("<%=txtAprQuantity.ClientID%>")) {
                msg += "- Enter Approved Quantity\n";
                if (ctrl == "") {
                    ctrl = "<%=txtAprQuantity.ClientID%>";
                }
                flag = false;
            }
            if (!CheckControl("<%=txtReqQuantity.ClientID%>")) {
                msg += "- Enter Requested Quantity \n";
                if (ctrl == "") {
                    ctrl = "<%=txtReqQuantity.ClientID%>";
                }
                flag = false;
            }
            if (!CheckAutoComplete("<%=txtEmpId.ClientID%>")) {
                msg += "- Enter Employee ID And Name \n";
                if (ctrl == "") {
                    ctrl = "<%=txtEmpId.ClientID%>";
                }
                flag = false;
            }
            if (msg != "")
                alert(msg);
            if (ctrl != "")
                document.getElementById(ctrl).focus();
            return flag;
        }

        function validateBtnSave() {

            var flag = true;
            var msg = "", ctrl = "";


            if (!CheckControl("<%=txtRemark.ClientID%>")) {
                msg += "- Enter Remark \n";
                if (ctrl == "") {
                    ctrl = "<%=txtRemark.ClientID%>";
                }
                flag = false;
            }

            if (msg != "")
                alert(msg);
            if (ctrl != "")
                document.getElementById(ctrl).focus();
            return flag;
        }
    </script>


    <div class="container">
        <div class="heading">
            <h2>Store Direct Indent </h2>
        </div>
        <div>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <table>
                        <tr>
                            <td>
                                <table>
                                    <tr>
                                        <th>Indentor<span class="required">*</span>
                                        </th>
                                        <th>Receiving As<span class="required">*</span>
                                        </th>
                                        <th>Location<span class="required">*</span>
                                        </th>
                                    </tr>
                                    <tr>

                                        <td>
                                            <asp:TextBox ID="txtEmpId" runat="server" Width="180px" CssClass="textbox"></asp:TextBox>
                                            <ajaxToolkit:AutoCompleteExtender ID="autoComplete2" runat="server" EnableCaching="true"
                                                CompletionInterval="500" CompletionSetCount="12" MinimumPrefixLength="1" ServiceMethod="GetEmployeeList"
                                                ServicePath="~\AutoComplete.asmx" ContextKey="1" TargetControlID="txtEmpId">
                                            </ajaxToolkit:AutoCompleteExtender>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlReceivingAs" runat="server" AutoPostBack="True" Width="150px" OnSelectedIndexChanged="ddlReceivingAs_SelectedIndexChanged1"></asp:DropDownList>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlLocation" runat="server" Width="150px"></asp:DropDownList>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <table>
                                    <tr>
                                        <th>Store<span class="required">*</span>
                                        </th>
                                        <th>Item<span class="required">*</span>
                                        </th>
                                        <th>Req. Quantity<span class="required">*</span>
                                        </th>
                                        <th>Apr. Quantity<span class="required">*</span>
                                        </th>
                                        <td></td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:DropDownList ID="ddlStore" runat="server" AutoPostBack="True" Width="150px" OnSelectedIndexChanged="ddlStore_SelectedIndexChanged"></asp:DropDownList>
                                        </td>

                                        <td>
                                            <asp:DropDownList ID="ddlItem" runat="server" Width="500px"></asp:DropDownList>
                                        </td>
                                        <td>
                                            <cc1:NumericTextBox ID="txtReqQuantity" runat="server" AllowDecimal="false" AllowNegative="false" AutoCompleteType="None" Width="60px" CssClass="textbox"></cc1:NumericTextBox>
                                        </td>
                                        <td>
                                            <cc1:NumericTextBox ID="txtAprQuantity" runat="server" AllowDecimal="false" AllowNegative="false" AutoCompleteType="None" Width="60px" CssClass="textbox"></cc1:NumericTextBox>
                                        </td>
                                        <td>
                                            <asp:Button ID="btnAdd" runat="server" Text="Add" CssClass="btnGray" OnClientClick="return CheckQty()" OnClick="btnAdd_Click" /></td>
                                    </tr>
                                </table>
                            </td>
                        </tr>

                        <tr>
                            <td>
                                <asp:GridView ID="gridItems" CssClass="gridDynamic" runat="server" AutoGenerateColumns="false" DataKeyNames="ITEM_ID" OnRowDeleting="gridItems_RowDeleting">
                                    <Columns>
                                        <asp:TemplateField HeaderText="S#">
                                            <ItemTemplate>
                                                <%# ((GridViewRow)Container).RowIndex + 1%>.
                                            </ItemTemplate>
                                            <ItemStyle Width="10px" />
                                        </asp:TemplateField>
                                        <asp:BoundField HeaderText="Item Name" DataField="ITEM_VALUE">
                                            <ItemStyle HorizontalAlign="Right" />
                                            <HeaderStyle HorizontalAlign="Right" />
                                        </asp:BoundField>
                                        <asp:BoundField HeaderText="Req. Quantity" DataField="REQ_QTY">
                                            <ItemStyle Width="60px" />
                                        </asp:BoundField>
                                        <asp:BoundField HeaderText="Apr. Quantity" DataField="APR_QTY">
                                            <ItemStyle Width="60px" />
                                        </asp:BoundField>
                                        <asp:CommandField ShowDeleteButton="true" ItemStyle-Width="20px" />
                                    </Columns>
                                </asp:GridView>
                            </td>
                        </tr>

                        <tr>
                            <th>Remark<asp:TextBox ID="txtData" runat="server" Visible="false"></asp:TextBox></th>
                        </tr>
                        <tr>
                            <td>
                                <asp:TextBox ID="txtRemark" runat="server" MaxLength="50" Width="408px" CssClass="textbox"></asp:TextBox>
                                <asp:Button ID="btnSave" runat="server" Text="Save" Enabled="false" CssClass="btnBrown" OnClick="btnSave_Click" />
                            </td>
                        </tr>
                    </table>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
</asp:Content>

