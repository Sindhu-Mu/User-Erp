<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/FullLength.master" AutoEventWireup="true" CodeFile="rptSto_Item.aspx.cs" Inherits="Inventory_rptSto_Item" %>

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
            if (bTrim(document.getElementById(ctrl).value) == "" || bTrim(document.getElementById(ctrl).value) == "Select" || bTrim(document.getElementById(ctrl).value) == ".") {
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
            if (!CheckControl("<%=ddlStore.ClientID%>")) {
                msg += "- Select Store from List\n";
                if (ctrl == "")
                    ctrl = "<%=ddlStore.ClientID%>";
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
            <h2>Store Stock</h2>
        </div>
        <div>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <table id="tblColumns">
                        <tr>
                            <td>
                                <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
                                    <ContentTemplate>
                                        <table class="space">
                                            <tr>
                                                <th>Store<span class="required">*</span></th>
                                                <th>Category</th>
                                                <th>Sub Category</th>
                                                <th title="will produce slow results">Contains
                                                </th>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:DropDownList ID="ddlStore" runat="server" Width="120px" AutoPostBack="true" required="required" OnSelectedIndexChanged="ddlStore_SelectedIndexChanged"></asp:DropDownList>
                                                </td>
                                                <td>
                                                    <asp:DropDownList ID="ddlCategory" runat="server" Width="180px" AutoPostBack="true" OnSelectedIndexChanged="ddlCategory_SelectedIndexChanged"></asp:DropDownList>
                                                </td>
                                                <td>
                                                    <asp:DropDownList ID="ddlSubCategory" runat="server" Width="240px"></asp:DropDownList>
                                                </td>
                                                <td>
                                                    <asp:TextBox ToolTip="will produce slow results" ID="txtContains" runat="server" MaxLength="40" Width="180px" CssClass="textBox" placeholder="Contains in name"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <th colspan="4">First Char
                                                </th>
                                                <td></td>
                                            </tr>
                                            <tr>
                                                <th colspan="4" id="cell" runat="server" style="font-size: 16px; font-weight: bold;"></th>
                                                <td>
                                                    <asp:Button ID="btnView" runat="server" Text="View" OnClick="btnView_Click" />
                                                </td>
                                            </tr>
                                        </table>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <div style="overflow: auto; max-height: 350px; width: 100%">
                                    <asp:UpdatePanel ID="UpdatePanel3" runat="server" UpdateMode="Conditional">
                                        <ContentTemplate>
                                            <asp:GridView ID="gvItems" runat="server" AutoGenerateColumns="false" Width="97%" EmptyDataText="No. records available" OnRowCommand="gvItems_RowCommand" DataKeyNames="ITEM_ID">
                                                <Columns>
                                                    <asp:TemplateField HeaderText="S#">
                                                        <ItemTemplate>
                                                            <%# ((GridViewRow)Container).RowIndex + 1%>.
                                                        </ItemTemplate>
                                                        <ItemStyle Width="10px" />
                                                    </asp:TemplateField>
                                                    <asp:BoundField HeaderText="Item Name" DataField="ITEM_NAME" ItemStyle-Width="50px" />
                                                   <%-- <asp:BoundField HeaderText="Rate" DataField="RATE_PER_ITEM" ItemStyle-Width="50px" />--%>
                                                    <asp:BoundField HeaderText="Description" DataField="ITEM_DESC" ItemStyle-Width="60px" />
                                                    <asp:BoundField HeaderText="Received Qty" DataField="RCV_QTY" ItemStyle-Width="8px">
                                                        <ItemStyle HorizontalAlign="Right" />
                                                    </asp:BoundField>
                                                    <asp:BoundField HeaderText="Issued Qty" DataField="ISSD_QTY" ItemStyle-Width="8px">
                                                        <ItemStyle HorizontalAlign="Right" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="QTY" HeaderText="Stock Qty" SortExpression="QTY" ItemStyle-Width="8px">
                                                        <ItemStyle HorizontalAlign="Right" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataFormatString="{0:N2}" HeaderText="Stock Amount (Rs)" DataField="STOCK_AMOUNT" ItemStyle-Width="20px">
                                                        <ItemStyle HorizontalAlign="Right" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataFormatString="{0:N2}" HeaderText="Amount (Rs)" DataField="AMOUNT" ItemStyle-Width="20px">
                                                        <ItemStyle HorizontalAlign="Right" />
                                                    </asp:BoundField>
                                                    <asp:BoundField HeaderText="Unit Value" DataField="UNIT_NAME" ItemStyle-Width="20px" />
                                                    <asp:BoundField HeaderText="Reorder" DataField="RDR_LVL" ItemStyle-Width="8px"></asp:BoundField>
                                                    <asp:CommandField HeaderText="Details" ButtonType="Link" ShowSelectButton="True" SelectText="Transaction" ItemStyle-Width="30px" ItemStyle-ForeColor="Blue" />
                                                </Columns>
                                            </asp:GridView>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <div style="overflow: auto; max-height: 300px; width: 100%">
                                    <asp:UpdatePanel ID="UpdatePanel4" runat="server" UpdateMode="Conditional">
                                        <ContentTemplate>
                                            <asp:GridView ID="gvGRN_SIV" runat="server" Caption="Transaction Detail" EnableViewState="false" AutoGenerateColumns="false" Width="97%" EmptyDataText="No. records available" DataKeyNames="ID,SIV_NO,GRN_NO">
                                                <Columns>
                                                    <asp:TemplateField HeaderText="S#">
                                                        <ItemTemplate>
                                                            <%# ((GridViewRow)Container).RowIndex + 1%>.
                                                        </ItemTemplate>
                                                        <ItemStyle Width="10px" />
                                                    </asp:TemplateField>
                                                    <asp:HyperLinkField HeaderText="GRN_NO" DataTextField="GRN_NO" SortExpression="GRN_NO" DataNavigateUrlFields="ID" DataNavigateUrlFormatString="../Inventory/prntSto_GRN.aspx?{0}" NavigateUrl="../Inventory/prntSto_GRN.aspx" Target="_blank" ItemStyle-Width="50px">
                                                        <ControlStyle Font-Underline="True" />
                                                        <ItemStyle HorizontalAlign="Left" />
                                                    </asp:HyperLinkField>
                                                    <asp:HyperLinkField HeaderText="SIV_NO" DataTextField="SIV_NO" SortExpression="SIV_NO" DataNavigateUrlFields="ID" DataNavigateUrlFormatString="../Inventory/prntSto_SIV.aspx?{0}" NavigateUrl="../Inventory/prntSto_SIV.aspx" Target="_blank" ItemStyle-Width="50px">
                                                        <ControlStyle Font-Underline="True" />
                                                        <ItemStyle HorizontalAlign="Left" />
                                                    </asp:HyperLinkField>
                                                    <asp:BoundField HeaderText="Stock" ItemStyle-Width="20px" />
                                                    <asp:BoundField HeaderText="Credit" DataField="Rcvd_Qty" ItemStyle-Width="20px" />
                                                    <asp:BoundField HeaderText="Debit" DataField="Issd_QTY" ItemStyle-Width="20px" />
                                                    <asp:BoundField HeaderText="Date" DataField="date" ItemStyle-Width="50px" />
                                                </Columns>
                                            </asp:GridView>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </div>
                            </td>
                        </tr>
                    </table>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
</asp:Content>

