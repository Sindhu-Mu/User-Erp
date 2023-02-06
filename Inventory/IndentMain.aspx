<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/FullLength.master" AutoEventWireup="true" CodeFile="IndentMain.aspx.cs" Inherits="Inventory_IndentMain" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script lang="javascript" type="text/javascript">
        function CheckControl(ctrl) {
            if (bTrim(document.getElementById(ctrl).value) == "" || bTrim(document.getElementById(ctrl).value) == "." || bTrim(document.getElementById(ctrl).value) == "Select") {
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

        function validateBtnAdd() {

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

            if (!CheckControl("<%=ddlItem.ClientID%>")) {
                msg += "- Select Item Name\n";
                if (ctrl == "") {
                    ctrl = "<%=ddlItem.ClientID%>";
                }
                flag = false;
            }

            if (!CheckControl("<%=txtQuantity.ClientID%>")) {
                msg += "- Enter Requested Quantity \n";
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
            <h2>Store Indent/Progress</h2>
        </div>
        <div>
            <asp:UpdatePanel ID="UpdatePanel4" runat="server">

                <ContentTemplate>
                    <ajaxToolkit:TabContainer ID="step1" runat="server" ActiveTabIndex="0" AutoPostBack="true" OnActiveTabChanged="step1_ActiveTabChanged">
                        <ajaxToolkit:TabPanel runat="server" HeaderText="Store Indent" ID="TabPanel2">
                            <ContentTemplate>
                                <table>
                                    <tr>
                                        <td style="vertical-align: top">
                                            <asp:UpdatePanel ID="up1" runat="server">
                                                <ContentTemplate>
                                                    <table>
                                                        <tr>
                                                            <th>Receiving As<span class="required">*</span>
                                                            </th>
                                                            <th>Location<span class="required">*</span>
                                                            </th>
                                                        </tr>
                                                        <tr>
                                                            <td style="text-align: left">
                                                                <asp:DropDownList ID="ddlReceivingAs" runat="server" required="required" AutoPostBack="True" Width="150px" OnSelectedIndexChanged="ddlReceivingAs_SelectedIndexChanged"></asp:DropDownList>
                                                            </td>
                                                            <td style="text-align: left">
                                                                <asp:DropDownList ID="ddlLocation" runat="server" required="required" Width="150px"></asp:DropDownList>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <table>
                                                <tr>
                                                    <td>
                                                        <asp:UpdatePanel ID="UpdatePanel1" runat="server" >
                                                            <ContentTemplate>
                                                                <table style="border-collapse: separate; border-spacing: 2px;">
                                                                    <tr>
                                                                        <th>Store Type<span class="required">*</span>
                                                                        </th>
                                                                        <th>Item<span class="required">*</span>
                                                                        </th>
                                                                        <th>Req. Quantity<span class="required">*</span>
                                                                        </th>
                                                                        <td></td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                            <asp:DropDownList ID="ddlStore" runat="server" required="required" AutoPostBack="True" Width="150px" OnSelectedIndexChanged="ddlStore_SelectedIndexChanged"></asp:DropDownList>
                                                                        </td>
                                                                        <td>
                                                                            <asp:DropDownList ID="ddlItem" runat="server" required="required" AutoCompleteMode="SuggestAppend" DropDownStyle="DropDownList" Width="500px"></asp:DropDownList>

                                                                        </td>
                                                                        <td>
                                                                            <cc1:NumericTextBox ID="txtQuantity" runat="server" AllowDecimal="false" AllowNegative="false" AutoCompleteType="None" Width="60px" placeholder="Quantity"></cc1:NumericTextBox>
                                                                        </td>
                                                                        <td>
                                                                            <asp:Button ID="btnAdd" runat="server" Text="Add" OnClick="btnAdd_Click" /></td>
                                                                    </tr>
                                                                </table>
                                                            </ContentTemplate>
                                                        </asp:UpdatePanel>
                                                    </td>
                                                </tr>

                                                <tr>
                                                    <td>
                                                        <asp:UpdatePanel ID="UpdatePanel3" runat="server" >
                                                            <ContentTemplate>
                                                                <table>
                                                                    <tr>
                                                                        <td>
                                                                            <asp:GridView ID="gridItems" CssClass="gridDynamic" AlternatingRowStyle-CssClass="alt" runat="server" AutoGenerateColumns="false" DataKeyNames="ITEM_ID" Width="97%" EnableViewState="false" OnRowDeleting="gridItems_RowDeleting">
                                                                                <Columns>
                                                                                    <asp:TemplateField HeaderText="S#">
                                                                                        <ItemTemplate>
                                                                                            <%# ((GridViewRow)Container).RowIndex + 1%>.
                                                                                        </ItemTemplate>
                                                                                        <ItemStyle Width="10px" />
                                                                                    </asp:TemplateField>
                                                                                    <asp:BoundField HeaderText="Item" DataField="ITEM_VALUE" />
                                                                                    <asp:BoundField HeaderText="Req. Quantity" DataField="REQ_QTY">
                                                                                        <ItemStyle Width="60px" />
                                                                                    </asp:BoundField>
                                                                                    <asp:CommandField ShowDeleteButton="true" ItemStyle-Width="20px" />

                                                                                </Columns>
                                                                            </asp:GridView>

                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                            <asp:TextBox ID="txtData" runat="server" Visible="false"></asp:TextBox>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </ContentTemplate>
                                                        </asp:UpdatePanel>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <table>
                                                            <tr>
                                                                <th>Remark</th>

                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <asp:TextBox ID="txtRemark" runat="server" MaxLength="50" Width="336px" CssClass="textbox"></asp:TextBox>
                                                                </td>

                                                                <td>
                                                                    <asp:Button ID="btnSave" runat="server" Text="Save" Enabled="False" OnClick="btnSave_Click" />
                                                                </td>
                                                            </tr>
                                                        </table>

                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                            </ContentTemplate>
                        </ajaxToolkit:TabPanel>
                        <ajaxToolkit:TabPanel runat="server" HeaderText="Indent Progress" ID="TabPanel3">
                            <ContentTemplate>
                                <table>
                                    <tr>
                                        <td style="vertical-align: top">
                                            <fieldset style="border-collapse: collapse; border-spacing: 0px; margin: 0px; padding: 0px; border: none">
                                                <legend>Applied Indents</legend>
                                                <div style="height: 600px; width: 100%; overflow: auto">
                                                    <asp:DropDownList ID="ddlStatus" runat="server" OnSelectedIndexChanged="ddlStatus_SelectedIndexChanged" AutoPostBack="True">
                                                    </asp:DropDownList>
                                                    <asp:GridView ID="gvIndent" CssClass="gridDynamic" Width="97%" runat="server" AutoGenerateColumns="False" DataKeyNames="IND_ID" EmptyDataText="No records found" OnRowCommand="gvIndent_RowCommand">
                                                        <AlternatingRowStyle CssClass="alt" />
                                                        <Columns>
                                                            <asp:TemplateField HeaderText="S.No.">
                                                                <ItemTemplate>
                                                                    <%# ((GridViewRow)Container).RowIndex + 1%>.
                                                                </ItemTemplate>
                                                                <ItemStyle Width="15px" />
                                                            </asp:TemplateField>
                                                            <asp:BoundField DataField="IND_CAL_ID" HeaderText="Indent No.">
                                                                <ItemStyle Width="150px" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="STO_NAME" HeaderText="Store">
                                                                <ItemStyle Width="100px" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="INS_DATE" HeaderText="Date">
                                                                <ItemStyle Width="100px" />
                                                            </asp:BoundField>
                                                            <asp:TemplateField>
                                                                <ItemTemplate>
                                                                    <asp:LinkButton ID="lnkIndentDetails" Text="Details" runat="server" CommandName="Details" CommandArgument="<%# ((GridViewRow)Container).RowIndex%>"></asp:LinkButton>
                                                                </ItemTemplate>
                                                                <ItemStyle Width="50px" />
                                                            </asp:TemplateField>
                                                        </Columns>
                                                    </asp:GridView>
                                                </div>
                                            </fieldset>
                                        </td>
                                        <td style="width: 3%; height: 100%; border-left: 1px solid red; margin-left: 5px"></td>
                                        <td style="vertical-align: top">
                                            <table>
                                                <tr>
                                                    <td>
                                                        <details open="open">
                                                            <summary style="text-align: left">Item Details</summary>
                                                            <asp:GridView ID="gvIndentDetails" runat="server" Width="97%" AutoGenerateColumns="False" CssClass="gridDynamic">
                                                                <Columns>
                                                                    <asp:TemplateField HeaderText="S.N0.">
                                                                        <ItemTemplate>
                                                                            <%# ((GridViewRow)Container).RowIndex + 1%>.
                                                                        </ItemTemplate>
                                                                        <ItemStyle Width="15px" />
                                                                    </asp:TemplateField>
                                                                    <asp:BoundField HeaderText="Item" DataField="ITEM_VALUE" HtmlEncode="False"></asp:BoundField>
                                                                    <asp:BoundField HeaderText="Req. Qty" DataField="REQ_QTY">
                                                                        <ItemStyle Width="60px" />
                                                                    </asp:BoundField>
                                                                    <asp:BoundField HeaderText="Apr. Qty" DataField="APR_QTY">
                                                                        <ItemStyle Width="60px" />
                                                                    </asp:BoundField>
                                                                    <asp:BoundField HeaderText="Isd. Qty" DataField="ISD_QTY">
                                                                        <ItemStyle Width="60px" />
                                                                    </asp:BoundField>
                                                                </Columns>
                                                            </asp:GridView>
                                                        </details>
                                                    </td>
                                                </tr>

                                                <tr>
                                                    <td>
                                                        <details open="open">
                                                            <summary style="text-align: left">Transaction Details</summary>
                                                            <asp:GridView ID="gvTransactionDetails" runat="server" Width="97%" AutoGenerateColumns="False" CssClass="gridDynamic">
                                                                <Columns>
                                                                    <asp:TemplateField HeaderText="S.NO.">
                                                                        <ItemTemplate>
                                                                            <%# ((GridViewRow)Container).RowIndex + 1%>.
                                                                        </ItemTemplate>
                                                                        <ItemStyle Width="15px" />
                                                                    </asp:TemplateField>
                                                                    <asp:BoundField HeaderText="Step By" DataField="IND_NAME">
                                                                        <ItemStyle Width="160px" />
                                                                    </asp:BoundField>
                                                                    <asp:BoundField HeaderText="Step Type" DataField="IND_STEP_VALUE"></asp:BoundField>
                                                                    <asp:BoundField HeaderText="Response Type" DataField="IND_DONE_VALUE"></asp:BoundField>
                                                                    <asp:BoundField HeaderText="Remark" DataField="IND_REM"></asp:BoundField>
                                                                </Columns>
                                                            </asp:GridView>
                                                        </details>
                                                    </td>
                                                </tr>

                                                <tr>
                                                    <td>
                                                        <details open="open">
                                                            <summary style="text-align: left">Receiving Details</summary>
                                                            <asp:GridView ID="gvReceiving" runat="server" Width="97%" AutoGenerateColumns="False" CssClass="gridDynamic">
                                                                <Columns>
                                                                    <asp:TemplateField HeaderText="S.NO.">
                                                                        <ItemTemplate>
                                                                            <%# ((GridViewRow)Container).RowIndex + 1%>.
                                                                        </ItemTemplate>
                                                                        <ItemStyle Width="15px" />
                                                                    </asp:TemplateField>
                                                                    <asp:BoundField HeaderText="Indent Type" DataField="IND_BY_TYPE_VALUE"></asp:BoundField>
                                                                    <asp:BoundField HeaderText="Location" DataField="LOCATION"></asp:BoundField>
                                                                </Columns>
                                                            </asp:GridView>
                                                        </details>
                                                    </td>
                                                </tr>

                                                <tr>
                                                    <td>
                                                        <details>
                                                            <summary style="text-align: left">Issue Details</summary>
                                                            <asp:GridView ID="gvIssue" runat="server" AutoGenerateColumns="False" Width="97%" CssClass="gridDynamic">
                                                                <Columns>
                                                                    <asp:TemplateField HeaderText="S.NO.">
                                                                        <ItemTemplate>
                                                                            <%# ((GridViewRow)Container).RowIndex + 1%>.
                                                                        </ItemTemplate>
                                                                        <ItemStyle Width="15px" />
                                                                    </asp:TemplateField>
                                                                    <asp:BoundField HeaderText="Item" DataField="ITEM_NAME" HtmlEncode="False">
                                                                        <ItemStyle HorizontalAlign="Right" />
                                                                        <HeaderStyle HorizontalAlign="Right" />
                                                                    </asp:BoundField>
                                                                    <asp:BoundField HeaderText="Isd. Date" DataField="INS_DATE">
                                                                        <ItemStyle Width="80px" />
                                                                    </asp:BoundField>
                                                                    <asp:BoundField HeaderText="Isd. Qty" DataField="QTY">
                                                                        <ItemStyle Width="60px" />
                                                                    </asp:BoundField>
                                                                </Columns>
                                                            </asp:GridView>
                                                        </details>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                            </ContentTemplate>
                        </ajaxToolkit:TabPanel>
                    </ajaxToolkit:TabContainer>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
</asp:Content>

