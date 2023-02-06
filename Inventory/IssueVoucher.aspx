<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/FullLength.master" AutoEventWireup="true" CodeFile="IssueVoucher.aspx.cs" Inherits="Inventory_IssueVoucher" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="container">
        <div class="heading">
            <h2>Store Issue Voucher </h2>
        </div>
        <div>
            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                <ContentTemplate>
                    <table>
                        <tr>
                            <td style="width: 420px; vertical-align: top">
                                <table>
                                    <tr>
                                        <td>
                                            <table>
                                                <tr>
                                                    <th>Indent No.
                                                    </th>
                                                    <td>
                                                        <asp:TextBox ID="txtIndentNo" runat="server"></asp:TextBox>
                                                    </td>
                                                    <th>Indentor Name :
                                                    </th>
                                                    <th>
                                                        <asp:TextBox ID="txtIndentor" runat="server"></asp:TextBox>
                                                    </th>
                                                    <ajaxToolkit:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" CompletionSetCount="12"
                                                        EnableCaching="true" MinimumPrefixLength="1" ServiceMethod="GetEmployeeList"
                                                        ServicePath="~\AutoComplete.asmx" TargetControlID="txtIndentor" ContextKey="1,2,3,0">
                                                    </ajaxToolkit:AutoCompleteExtender>
                                                    <td>
                                                        <asp:Button ID="btnFilter" runat="server" Text="Filter" OnClick="btnFilter_Click" /></td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="vertical-align: top">
                                            <div style="max-width: 100%; height: 400px; overflow: auto">
                                                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                                    <ContentTemplate>
                                                        <asp:GridView ID="gvIndent" runat="server" CssClass="gridDynamic" SelectedRowStyle-CssClass="custom" AlternatingRowStyle-CssClass="alt" AutoGenerateColumns="false" DataKeyNames="IND_ID" EmptyDataText="No records found" Width="400px" OnRowCommand="gvIndent_RowCommand" OnSelectedIndexChanged="gvIndent_SelectedIndexChanged">
                                                            <SelectedRowStyle Wrap="true" />
                                                            <Columns>
                                                                <asp:TemplateField HeaderText="S#">
                                                                    <ItemTemplate>
                                                                        <%# ((GridViewRow)Container).RowIndex + 1%>.
                                                                    </ItemTemplate>
                                                                    <ItemStyle Width="10px" />
                                                                </asp:TemplateField>
                                                                <asp:BoundField DataField="STO_NAME" HeaderText="Store" />
                                                                <asp:BoundField DataField="IND_CAL_ID" HeaderText="Indent No." />
                                                                <asp:BoundField DataField="INS_DATE" HeaderText="Indent Date" />
                                                                <asp:BoundField DataField="EMP_NAME" HeaderText="Indentor" />
                                                                <asp:BoundField DataField="CNT" HeaderText="No. of Items" />
                                                                <asp:TemplateField>
                                                                    <ItemTemplate>
                                                                        <asp:LinkButton ID="lnkIndentDetails" Text="Details" runat="server" CommandName="Details" CommandArgument="<%# ((GridViewRow)Container).RowIndex%>"></asp:LinkButton>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                            </Columns>
                                                        </asp:GridView>

                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                            </div>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                            <td style="width: 1px; height: 100%; border-left: 1px solid red; margin-left: 5px"></td>
                            <td style="vertical-align: top">

                                <table>
                                    <tr>
                                        <td>
                                            <asp:Button ID="btnIssue" runat="server" Text="Issue" Enabled="false" OnClick="btnIssue_Click"></asp:Button>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <details open="open">
                                                <summary><b>Indent Details</b></summary>
                                                <asp:GridView ID="gvIndentDetails" runat="server" AutoGenerateColumns="false" DataKeyNames="ITEM_ID" Width="97%" EmptyDataText="No records found" CssClass="gridDynamic">
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="S#">
                                                            <ItemTemplate>
                                                                <%# ((GridViewRow)Container).RowIndex + 1%>.
                                                            </ItemTemplate>
                                                            <ItemStyle Width="10px" />
                                                        </asp:TemplateField>
                                                        <asp:BoundField HeaderText="Item" DataField="ITEM_NAME" HtmlEncode="false"></asp:BoundField>
                                                        <asp:BoundField HeaderText="Av. Qty" DataField="QTY">
                                                            <ItemStyle Width="60px" />
                                                        </asp:BoundField>
                                                        <asp:BoundField HeaderText="Apr. Qty" DataField="APR_QTY">
                                                            <ItemStyle Width="60px" />
                                                        </asp:BoundField>
                                                        <asp:TemplateField HeaderText="Issue Qty">
                                                            <ItemTemplate>
                                                                <cc1:NumericTextBox ID="txtQuantity" Text='<%#Eval("ISD_QTY") %>' Enabled='<%#Eval("IS_CNG_ALWD")%>' runat="server" Width="55px"></cc1:NumericTextBox>
                                                            </ItemTemplate>
                                                            <ItemStyle Width="60px" />
                                                        </asp:TemplateField>
                                                    </Columns>
                                                </asp:GridView>
                                            </details>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <details open="open">
                                                <summary>Receiving Details</summary>
                                                <asp:GridView ID="gvReceiving" runat="server" AutoGenerateColumns="false" Width="97%" EmptyDataText="No records found" CssClass="gridDynamic">
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="S#">
                                                            <ItemTemplate>
                                                                <%# ((GridViewRow)Container).RowIndex + 1%>.
                                                            </ItemTemplate>
                                                            <ItemStyle Width="10px" />
                                                        </asp:TemplateField>
                                                        <asp:BoundField HeaderText="Indent Type" DataField="IND_BY_TYPE_VALUE"></asp:BoundField>
                                                        <asp:BoundField HeaderText="Location" DataField="LOCATION"></asp:BoundField>
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
            </asp:UpdatePanel>
        </div>
    </div>

</asp:Content>

