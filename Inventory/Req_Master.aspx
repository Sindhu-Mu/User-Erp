<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Req_Master.aspx.cs" Inherits="Purchase_Req_Master" MasterPageFile="~/MasterPages/FullLength.master" Title="ERP|Purchase Requisition" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script lang="javascript" type="text/javascript">
        function CheckControl(ctrl) {
            if (bTrim(document.getElementById(ctrl).value) == "" || bTrim(document.getElementById(ctrl).value) == "Select" || bTrim(document.getElementById(ctrl).value) == ".") {
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
        function CheckDate(ctrl) {
            var dt = document.getElementById(ctrl).value;
            if (!isDatecheck(dt, "dd/MM/yyyy")) {
                document.getElementById(ctrl).style.backgroundColor = "#fc6";
                return false;
            }
            else {
                document.getElementById(ctrl).style.backgroundColor = "#fff";
                return true;
            }
        }


        function validateAdd() {
            var flag = true;
            var msg = "", ctrl = "";
            if (!CheckControl("<%=ddl_Store.ClientID%>")) {
                msg += "- Select Store from List\n";
                if (ctrl == "") {
                    ctrl = "<%=ddl_Store.ClientID%>";
                }
                flag = false;
            }

            if (!CheckControl("<%=ddl_Category.ClientID%>")) {
                msg += "- Select Category from List\n";
                if (ctrl == "") {
                    ctrl = "<%=ddl_Category.ClientID%>";
                }
                flag = false;
            }

            if (!CheckControl("<%=ddl_SubCategory.ClientID%>")) {
                msg += "- Select Category from List\n";
                if (ctrl == "") {
                    ctrl = "<%=ddl_Category.ClientID%>";
                }
                flag = false;
            }

            if (!CheckControl("<%=ddl_Item.ClientID%>")) {
                msg += "- Select Item from List\n";
                if (ctrl == "") {
                    ctrl = "<%=ddl_Item.ClientID%>";
                }
                flag = false;
            }

            if (!CheckControl("<%=ddl_Vendor.ClientID%>")) {
                msg += "- Select Vendor from List\n";
                if (ctrl == "") {
                    ctrl = "<%=ddl_Vendor.ClientID%>";
                }
                flag = false;
            }

            if (!CheckControl("<%=txtQuantity.ClientID%>")) {
                msg += "- Enter Quantity\n";
                if (ctrl == "") {
                    ctrl = "<%=txtQuantity.ClientID%>";
                }
                flag = false;
            }

            if (!CheckControl("<%=txtRate.ClientID%>")) {
                msg += "- Enter Rate\n";
                if (ctrl == "") {
                    ctrl = "<%=txtRate.ClientID%>";
                }
                flag = false;
            }

            if (!CheckControl("<%=txtJst.ClientID%>")) {
                msg += "- Enter Justification\n";
                if (ctrl == "") {
                    ctrl = "<%=txtJst.ClientID%>";
                }
                flag = false;
            }

            if (!CheckControl("<%=txtRemark.ClientID%>")) {
                msg += "- Enter Remark\n";
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
            <h2>Requisition Master</h2>
        </div>
        <table>
            <tr>
                <td>
                    <asp:UpdatePanel ID="UpPanel1" runat="server">
                        <ContentTemplate>
                            <ajaxToolkit:TabContainer ActiveTabIndex="1" runat="server" ID="step1" AutoPostBack="true" OnActiveTabChanged="step1_ActiveTabChanged">
                                <ajaxToolkit:TabPanel ID="TabPanel1" HeaderText="Purchase Requisition" runat="server">
                                    <ContentTemplate>
                                        <table style="width: 100%">
                                            <tr>
                                                <th>Store<span class="required">*</span>
                                                </th>
                                                <td>
                                                    <asp:DropDownList ID="ddl_Store" runat="server" AutoPostBack="True" Width="200px" OnSelectedIndexChanged="ddl_Store_SelectedIndexChanged"></asp:DropDownList>
                                                </td>

                                            </tr>
                                            <tr>
                                                <th>Category<span class="required">*</span>
                                                </th>
                                                <td>
                                                    <asp:DropDownList ID="ddl_Category" runat="server" AutoPostBack="True" Width="200px" OnSelectedIndexChanged="ddl_Category_SelectedIndexChanged"></asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <th>SubCategory<span class="required">*</span>
                                                </th>
                                                <td>
                                                    <asp:DropDownList ID="ddl_SubCategory" runat="server" AutoPostBack="True" Width="200px" OnSelectedIndexChanged="ddl_SubCategory_SelectedIndexChanged"></asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <th>Item<span class="required">*</span>
                                                </th>
                                                <td>
                                                    <asp:DropDownList ID="ddl_Item" runat="server" Width="200px" AutoPostBack="True" OnSelectedIndexChanged="ddl_Item_SelectedIndexChanged"></asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <th style="width: 200px">Vendor Name<span></span>
                                                </th>
                                                <td>
                                                    <asp:DropDownList ID="ddl_Vendor" runat="server" Width="200px" OnSelectedIndexChanged="ddl_Vendor_SelectedIndexChanged"></asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <th>Quantity Required<span class="required">*</span>
                                                </th>
                                                <td>
                                                    <cc1:NumericTextBox ID="txtQuantity" runat="server" Width="60px" AllowDecimal="True" DecimalPlaces="3" AllowNegative="False" ></cc1:NumericTextBox>
                                                </td>
                                            </tr>

                                            <tr>
                                                <th>Rate(Approximate)<span class="required">*</span>
                                                </th>
                                                <td>
                                                    <cc1:NumericTextBox ID="txtRate" runat="server" Width="100px" AllowDecimal="True" DecimalPlaces="3" AllowNegative="False"></cc1:NumericTextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <th>Justification<span class="required">*</span>
                                                </th>
                                                <td>
                                                    <asp:TextBox ID="txtJst" runat="server" TextMode="MultiLine" Width="200px"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <th>Remark<span class="required">*</span>
                                                </th>
                                                <td>
                                                    <asp:TextBox ID="txtRemark" runat="server" Width="200px"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Button ID="btnAdd" runat="server" Text="Add" OnClick="btnAdd_Click1" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2">
                                                    <asp:GridView ID="gvItemDetail" runat="server" Width="97%" AutoGenerateColumns="False" CellPadding="2" CssClass="gridDynamic" OnRowDeleting="gvItemDetail_RowDeleting">
                                                        <Columns>
                                                            <asp:TemplateField HeaderText="S.No.">
                                                                <ItemTemplate>
                                                                    <%# ((GridViewRow)Container).RowIndex + 1%>
                                                                </ItemTemplate>
                                                                <ItemStyle Width="15px" />
                                                            </asp:TemplateField>
                                                            <asp:BoundField DataField="REQ_ITEM_NAME" HeaderText="Item Name"></asp:BoundField>
                                                            <asp:BoundField DataField="REQ_ITEM_QTY" HeaderText="Req.Qty"></asp:BoundField>
                                                            <asp:BoundField DataField="REQ_ITEM_RATE" DataFormatString="{0:N2}" HeaderText="Rate(Rs.)"></asp:BoundField>
                                                            <asp:BoundField DataField="REQ_ITEM_AMOUNT" DataFormatString="{0:N2}" HeaderText="Amount(Rs.)"></asp:BoundField>
                                                            <asp:BoundField DataField="REQ_SUPP_NAME" HeaderText="Vendor Name"></asp:BoundField>
                                                            <asp:CommandField ShowDeleteButton="True" ButtonType="Button" HeaderText="Delete"></asp:CommandField>
                                                        </Columns>

                                                    </asp:GridView>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Button ID="txtXML" runat="server" Visible="False" />
                                                </td>
                                                <td>
                                                    <asp:Button ID="btnUpdate" Text="Update" runat="server" Visible="False" OnClick="btnUpdate_Click" />
                                                </td>
                                                <td>
                                                    <asp:Button ID="btnSave" Text="Save" runat="server" OnClick="btnSave_Click" />
                                                </td>
                                            </tr>
                                        </table>
                                    </ContentTemplate>
                                </ajaxToolkit:TabPanel>
                                <ajaxToolkit:TabPanel ID="TabPanel2" HeaderText="Modify Requisition" runat="server">
                                    <ContentTemplate>
                                        <table>
                                            <tr>
                                                <td>
                                                    <table>
                                                        <tr>
                                                            <th>Year<span class="required">*</span>
                                                            </th>
                                                            <td>&nbsp;</td>
                                                            <th>Store<span class="required">*</span>
                                                            </th>
                                                            <td>&nbsp;</td>
                                                            <th>Request No.<span class="required">*</span>
                                                            </th>
                                                            <td>&nbsp;</td>
                                                            <th>Status<span class="required">*</span>
                                                            </th>
                                                            <td>
                                                                &nbsp;</td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:DropDownList ID="ddl_Year" runat="server" AutoPostBack="True" Width="150px" OnSelectedIndexChanged="ddl_Year_SelectedIndexChanged">
                                                                    <asp:ListItem Value="0">Select</asp:ListItem>
                                                                    <asp:ListItem Value="2013-14">2013-14</asp:ListItem>
                                                                    <asp:ListItem Value="2012-13">2012-13</asp:ListItem>
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td>&nbsp;</td>
                                                            <td>
                                                                <asp:DropDownList ID="ddlStore" runat="server" AutoPostBack="True" Width="200px" ></asp:DropDownList>
                                                            </td>
                                                            <td>&nbsp;</td>
                                                            <td>
                                                                <asp:DropDownList ID="ddl_RequestNo" runat="server" AutoPostBack="True" Width="150px" OnSelectedIndexChanged="ddl_RequestNo_SelectedIndexChanged"></asp:DropDownList>
                                                            </td>
                                                            <td>&nbsp;</td>
                                                            <td>
                                                                <asp:DropDownList ID="ddl_Status" runat="server" AutoPostBack="True" Width="150px" OnSelectedIndexChanged="ddl_Status_SelectedIndexChanged"></asp:DropDownList>
                                                            </td>
                                                            <td>
                                                                <asp:Button ID="btnView" runat="server" OnClick="btnView_Click" Text="View" />
                                                            </td>
                                                        </tr>
                                                    </table>

                                                    <tr>
                                                        <td>
                                                            <asp:GridView ID="gvRequest" runat="server" AutoGenerateColumns="False" CssClass="gridDynamic" DataKeyNames="PUR_REQ_ID" OnRowCommand="gvRequest_RowCommand">
                                                                <Columns>
                                                                    <asp:TemplateField HeaderText="S.No.">
                                                                        <ItemTemplate>
                                                                            <%# ((GridViewRow)Container).RowIndex + 1%>
                                                                        </ItemTemplate>
                                                                        <ItemStyle Width="5%" />
                                                                    </asp:TemplateField>
                                                                    <asp:BoundField HeaderText="Item" DataField="ITEM_NAME" />
                                                                    <asp:BoundField HeaderText="Vendor" DataField="VENDOR_ORG_NAME" />
                                                                    <asp:BoundField HeaderText="Quantity" DataField="REQ_ITEM_QTY" />
                                                                    <asp:BoundField HeaderText="Rate" DataField="REQ_ITEM_RATE" />
                                                                    <asp:BoundField HeaderText="Justification" DataField="REQ_JUSTIFICATION" />
                                                                    <asp:CommandField ButtonType="Image" HeaderText="Edit" SelectImageUrl="~/Siteimages/edit.gif" ShowSelectButton="True">
                                                                        <ItemStyle Width="40px" />
                                                                    </asp:CommandField>
                                                                </Columns>
                                                            </asp:GridView>
                                                        </td>
                                                    </tr>
                                        </table>

                                    </ContentTemplate>
                                </ajaxToolkit:TabPanel>
                            </ajaxToolkit:TabContainer>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
            </tr>

        </table>

    </div>


</asp:Content>

