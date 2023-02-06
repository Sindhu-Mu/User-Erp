<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ItemMain.aspx.cs" Inherits="Inventory_ItemMain" MasterPageFile="~/MasterPages/FullLength.master" Title="ERP|Item Main" %>

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
        function validateCategory() {
            var flag = true;
            var msg = "", ctrl = "";
            if (!CheckControl("<%=txtCatName.ClientID%>")) {
                msg += "- Enter Category Name\n";
                if (ctrl == "") {
                    ctrl = "<%=txtCatName.ClientID%>";
                }
                flag = false;
            }
            if (msg != "")
                alert(msg);
            if (ctrl != "")
                document.getElementById(ctrl).focus();
            return flag;
        }
        function validateSubCat() {
            var flag = true;
            var msg = "", ctrl = "";
            if (!CheckControl("<%=ddlCategory.ClientID%>")) {
                msg += "- Select Category Name\n";
                if (ctrl == "") {
                    ctrl = "<%=ddlCategory.ClientID%>";
                }
                flag = false;
            }
            if (!CheckControl("<%=txtSubCatName.ClientID%>")) {
                msg += "- Enter Subcategory Name\n";
                if (ctrl == "") {
                    ctrl = "<%=txtSubCatName.ClientID%>";
                }
                flag = false;
            }

            if (msg != "")
                alert(msg);
            if (ctrl != "")
                document.getElementById(ctrl).focus();
            return flag;
        }
        function validateItem() {
            var flag = true;
            var msg = "", ctrl = "";
            if (!CheckControl("<%=ddlItemStore.ClientID%>")) {
                msg += "- Select Store Name\n";
                if (ctrl == "") {
                    ctrl = "<%=ddlItemStore.ClientID%>";
                }
                flag = false;
            }
            if (!CheckControl("<%=ddlItemCat.ClientID%>")) {
                msg += "- Select Category Name\n";
                if (ctrl == "") {
                    ctrl = "<%=ddlItemCat.ClientID%>";
                }
                flag = false;
            }
            if (!CheckControl("<%=ddlSubCat.ClientID%>")) {
                msg += "- Select SubCategory Name\n";
                if (ctrl == "") {
                    ctrl = "<%=ddlSubCat.ClientID%>";
                }
                flag = false;
            }
            if (!CheckControl("<%=txtItemName.ClientID%>")) {
                msg += "- Enter Item Name\n";
                if (ctrl == "") {
                    ctrl = "<%=txtItemName.ClientID%>";
                }
                flag = false;
            }
            if (!CheckControl("<%=ddlUnit.ClientID%>")) {
                msg += "- Select Unit From List\n";
                if (ctrl == "") {
                    ctrl = "<%=ddlUnit.ClientID%>";
                }
                flag = false;
            }
            if (!CheckControl("<%=txtReorderLevel.ClientID%>")) {
                msg += "- Enter Reorder Level\n";
                if (ctrl == "") {
                    ctrl = "<%=txtReorderLevel.ClientID%>";
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

            if (msg != "")
                alert(msg);
            if (ctrl != "")
                document.getElementById(ctrl).focus();
            return flag;
        }

    </script>
    <div class="container">
        <div class="heading">
            <h2>Item Main</h2>
        </div>
        <div>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <ajaxToolkit:TabContainer ID="step1" runat="server" ActiveTabIndex="2" AutoPostBack="true" OnActiveTabChanged="step1_ActiveTabChanged">
                        <ajaxToolkit:TabPanel runat="server" HeaderText="Category" ID="TabPanel2">
                            <ContentTemplate>
                                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                    <ContentTemplate>
                                        <table>
                                            <tr>
                                                <td>
                                                    <table>
                                                        <tr>
                                                            <th>Category Name   <span class="required">*</span></th>
                                                            <td>&nbsp;</td>
                                                            <td>&nbsp;</td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:TextBox ID="txtCatName" Width="300px" runat="server"></asp:TextBox>

                                                            </td>
                                                            <td>&nbsp;</td>

                                                            <td>
                                                                <asp:Button ID="btnSaveCat" runat="server" Text="Save" OnClick="btnSaveCat_Click" Width="60px" />

                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <div style="height: 400px; overflow: auto; width: 97%">
                                                        <asp:GridView ID="gridCategory" runat="server" AutoGenerateColumns="False" CssClass="gridDynamic"
                                                            DataKeyNames="Cat_Id" OnRowCommand="gridCategory_RowCommand">
                                                            <Columns>
                                                                <asp:TemplateField HeaderText="S.No.">
                                                                    <ItemTemplate>
                                                                        <%# ((GridViewRow)Container).RowIndex + 1%>.
                                                                    </ItemTemplate>
                                                                    <ItemStyle Width="20px" />
                                                                </asp:TemplateField>
                                                                <asp:BoundField HeaderText="Category Name" DataField="Cat_Name" />
                                                                <asp:CommandField ButtonType="Image" HeaderText="Edit" SelectImageUrl="~/Siteimages/edit.gif"
                                                                    ShowSelectButton="True">
                                                                    <ItemStyle Width="40px" />
                                                                </asp:CommandField>
                                                            </Columns>
                                                        </asp:GridView>
                                                    </div>
                                                </td>
                                            </tr>
                                        </table>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </ContentTemplate>
                        </ajaxToolkit:TabPanel>
                        <ajaxToolkit:TabPanel runat="server" HeaderText="Sub-Category" ID="TabPanel3">
                            <ContentTemplate>
                                <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                    <ContentTemplate>
                                        <table>
                                            <tr>
                                                <td>
                                                    <table>
                                                        <tr>
                                                            <th>Category<span class="required">*</span></th>
                                                            <td>&nbsp;</td>
                                                            <th>Sub-Category<span class="required">*</span></th>
                                                            <td>&nbsp;</td>
                                                            <th>Description</th>
                                                            <td>&nbsp;</td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:DropDownList ID="ddlCategory" runat="server" AutoPostBack="True"
                                                                    Width="250px" OnSelectedIndexChanged="ddlCategory_SelectedIndexChanged">
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td>&nbsp;</td>
                                                            <td>
                                                                <asp:TextBox ID="txtSubCatName" runat="server" CssClass="textbox" Width="400px"></asp:TextBox>
                                                            </td>
                                                            <td>&nbsp;</td>
                                                            <td>
                                                                <asp:TextBox ID="txtSubCatDesc" runat="server"></asp:TextBox>
                                                            </td>

                                                            <td>
                                                                <asp:Button ID="btnSaveSubCat" runat="server" OnClick="btnSaveSubCat_Click" Text="Save" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <div style="height: 400px; overflow: auto; width: 97%">
                                                        <asp:GridView ID="gridSubCat" runat="server" AutoGenerateColumns="False" CssClass="gridDynamic"
                                                            DataKeyNames="SUB_CAT_ID" OnRowCommand="gridSubCat_RowCommand" EmptyDataText="No Record Found">
                                                            <Columns>
                                                                <asp:TemplateField HeaderText="S.No.">
                                                                    <ItemTemplate>
                                                                        <%# ((GridViewRow)Container).RowIndex + 1%>.
                                                                    </ItemTemplate>
                                                                    <ItemStyle Width="20px" />
                                                                </asp:TemplateField>
                                                                <asp:BoundField HeaderText="Category" DataField="CAT_NAME" />
                                                                <asp:BoundField HeaderText="SubCategory Name" DataField="SUB_CAT_NAME" />
                                                                <asp:CommandField ButtonType="Image" HeaderText="Edit" SelectImageUrl="~/Siteimages/edit.gif"
                                                                    ShowSelectButton="True">
                                                                    <ItemStyle Width="40px" />
                                                                </asp:CommandField>
                                                            </Columns>
                                                        </asp:GridView>
                                                    </div>
                                                </td>
                                            </tr>
                                        </table>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </ContentTemplate>
                        </ajaxToolkit:TabPanel>
                        <ajaxToolkit:TabPanel runat="server" HeaderText="Store Item" ID="TabPanel4">
                            <ContentTemplate>
                                <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                                    <ContentTemplate>
                                        <table>
                                            <tr>
                                                <td>
                                                    <table>
                                                        <tr>
                                                            <th>Store <span class="required">*</span></th>

                                                            <th>Category<span class="required">*</span></th>

                                                            <th>Sub Category<span class="required">*</span></th>

                                                            <th colspan="2">Item Name<span class="required">*</span></th>
                                                            <th></th>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:DropDownList ID="ddlItemStore" runat="server"
                                                                    Width="120px" AutoPostBack="True" OnSelectedIndexChanged="ddlItemStore_SelectedIndexChanged">
                                                                </asp:DropDownList></td>
                                                            <td>
                                                                <asp:DropDownList ID="ddlItemCat" runat="server"
                                                                    Width="120px" AutoPostBack="True" OnSelectedIndexChanged="ddlItemCat_SelectedIndexChanged">
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td>
                                                                <asp:DropDownList ID="ddlSubCat" runat="server" OnSelectedIndexChanged="ddlSubCat_SelectedIndexChanged" Width="180px" AutoPostBack="true">
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td colspan="2">&nbsp;<asp:TextBox ID="txtItemName" runat="server" CssClass="textbox" Width="270px"></asp:TextBox>
                                                            </td>
                                                            <td></td>

                                                        </tr>
                                                        <tr>
                                                            <th>Unit <span class="required">*</span>
                                                            </th>
                                                            <th>Reorder Level <span class="required">*</span></th>
                                                            <th>Initial Quantity <span class="required">*</span>
                                                            </th>
                                                            <th>Is Return <span class="required">*</span>
                                                            </th>
                                                            <th>Description
                                                            </th>

                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:DropDownList ID="ddlUnit" runat="server"></asp:DropDownList></td>
                                                            <td>
                                                                <cc1:NumericTextBox ID="txtReorderLevel" runat="server" AllowDecimal="False" AllowNegative="False" Width="140px"></cc1:NumericTextBox></td>
                                                        
                                                            <td>
                                                                <cc1:NumericTextBox ID="txtQuantity" runat="server" AllowDecimal="False" AllowNegative="False" Width="120px"></cc1:NumericTextBox>

                                                            </td>

                                                            <td>
                                                                <asp:RadioButtonList ID="Rlist" runat="server" CellPadding="0" CellSpacing="0" RepeatDirection="Horizontal" Width="80px">
                                                                    <asp:ListItem Value="0">No</asp:ListItem>
                                                                    <asp:ListItem Selected="True" Value="1">Yes</asp:ListItem>
                                                                </asp:RadioButtonList></td>
                                                      
                                                            <td>
                                                                <asp:TextBox ID="txtDescription" runat="server" Width="200px"></asp:TextBox>
                                                            </td>

                                                            <td>
                                                                <asp:Button ID="btnSaveItem" runat="server" Text="Save" CssClass="btnBrown" OnClick="btnSaveItem_Click" />&nbsp;
                                                                 <asp:Button ID="btnCancelItem" runat="server" CssClass="btnBrown" Text="Cancel" OnClick="btnCancelItem_Click" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <div style="height: 400px; overflow: auto; width: 97%">
                                                        <asp:GridView ID="gridItem" runat="server" AutoGenerateColumns="False" CssClass="gridDynamic" DataKeyNames="Item_Id" OnRowCommand="gridItem_RowCommand" EmptyDataText="No Record Found">
                                                            <Columns>
                                                                <asp:TemplateField HeaderText="S.No.">
                                                                    <ItemTemplate>
                                                                        <%# ((GridViewRow)Container).RowIndex + 1%>.
                                                                    </ItemTemplate>
                                                                    <ItemStyle Width="20px" />
                                                                </asp:TemplateField>
                                                                <asp:BoundField DataField="SUB_CAT_NAME" HeaderText="Sub-Category" />
                                                                <asp:BoundField DataField="ITEM_NAME" HeaderText="Item Name" />
                                                                <asp:BoundField DataField="RDR_LVL" HeaderText="Reorder Level" />
                                                                <asp:BoundField DataField="QTY" HeaderText="Quantity" />
                                                                <asp:BoundField DataField="UNIT_NAME" HeaderText="Unit" />
                                                                <asp:BoundField DataField="ITEM_DESC" HeaderText="Description" />
                                                                <asp:CommandField ButtonType="Image" HeaderText="Edit" SelectImageUrl="~/Siteimages/edit.gif" ShowSelectButton="True">
                                                                    <ItemStyle Width="40px" />
                                                                </asp:CommandField>
                                                            </Columns>
                                                        </asp:GridView>
                                                    </div>
                                                </td>
                                            </tr>
                                        </table>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </ContentTemplate>
                        </ajaxToolkit:TabPanel>
                    </ajaxToolkit:TabContainer>
                </ContentTemplate>
            </asp:UpdatePanel>

        </div>
    </div>
</asp:Content>
