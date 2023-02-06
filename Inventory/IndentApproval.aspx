<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/FullLength.master" AutoEventWireup="true" CodeFile="IndentApproval.aspx.cs" Inherits="Inventory_IndentApproval" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="container">
        <div class="heading">
            <h2>Store Indent Approval</h2>
        </div>
        <div>
            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                <ContentTemplate>
                    <table>
                        <tr>
                            <td>
                                <table style="vertical-align: top;">
                                    <tr>
                                        <td style="vertical-align: top">
                                            <p>Pending Indents</p>
                                            <table>
                                                <tr>
                                                    <td style="vertical-align: top">
                                                        <asp:GridView ID="gvIndent" CssClass="gridDynamic" AlternatingRowStyle-CssClass="alt" runat="server" AutoGenerateColumns="False" DataKeyNames="IND_ID" EmptyDataText="No records found" OnRowCommand="gvIndent_RowCommand">
                                                            <AlternatingRowStyle CssClass="alt"></AlternatingRowStyle>
                                                            <Columns>
                                                                <asp:TemplateField HeaderText="S#">
                                                                    <ItemTemplate>
                                                                        <%# ((GridViewRow)Container).RowIndex + 1%>.
                                                                    </ItemTemplate>
                                                                    <ItemStyle Width="10px" />
                                                                </asp:TemplateField>
                                                                <asp:BoundField DataField="IND_CAL_ID" HeaderText="Indent No.">
                                                                    <ItemStyle Width="150px" />
                                                                </asp:BoundField>
                                                              <asp:BoundField DataField="INS_DATE" HeaderText="Indent Date" DataFormatString="{0:dd/MM/yyyy}" />
                                                                <asp:BoundField DataField="EMP_NAME" HeaderText="Indentor" />
                                                                <asp:BoundField DataField="DEPT_VALUE" HeaderText="Department" />
                                                                <asp:TemplateField>
                                                                    <ItemTemplate>

                                                                        <asp:LinkButton ID="lnkIndentDetails" Text="Details" runat="server" CommandName="Details" CommandArgument="<%# ((GridViewRow)Container).RowIndex%>"></asp:LinkButton>

                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                            </Columns>
                                                        </asp:GridView>
                                                    </td>
                                                </tr>
                                            </table>

                                        </td>
                                        <td style="width: 1px; height: 100%; border-left: 1px solid red; margin-left: 5px"></td>
                                        <td style="vertical-align: top; text-align: left">
                                            <table id="tblDtl" runat="server">
                                                <tr>
                                                    <td>
                                                        <table>
                                                            <tr>
                                                                <th style="vertical-align: middle">Remark:
                                                                </th>
                                                                <td>
                                                                    <asp:TextBox ID="txtRemark" runat="server" MaxLength="50" Width="200px">
                                                                    </asp:TextBox>
                                                                </td>
                                                                <td>
                                                                    <asp:GridView ID="gvApproval" runat="server" AutoGenerateColumns="false" ShowHeader="false" GridLines="None" EmptyDataText="No records found" OnRowCommand="gvApproval_RowCommand" DataKeyNames="IND_STEP_ID">
                                                                        <RowStyle BorderStyle="None" />
                                                                        <Columns>
                                                                            <asp:TemplateField>
                                                                                <ItemTemplate>
                                                                                    <table style="border-collapse: collapse; border-spacing: 0px">
                                                                                        <tr>
                                                                                            <td>
                                                                                                <asp:Button ID="btnApprove" runat="server" Text='<%#Eval("APR_TEXT")%>' CommandName="1" CommandArgument='<%#Eval("IND_ID")%>' />
                                                                                            </td>
                                                                                            <td>
                                                                                                <asp:Button ID="btnReject" runat="server" Text="Reject" Enabled='<%#Eval("IS_RJT_ALWD")%>' CommandName="2" CommandArgument='<%#Eval("IND_ID")%>' />
                                                                                            </td>
                                                                                        </tr>
                                                                                    </table>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                        </Columns>
                                                                    </asp:GridView>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <hr style="color: #ff8c00; width: 100%; height: 0px; border-bottom-color: red; border-bottom-width: 1px; border-collapse: collapse; border-spacing: 0px;" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <details open="open">
                                                            <summary>Indent Details</summary>
                                                            <asp:GridView ID="gvIndentDetails" CssClass="gridDynamic" runat="server" AutoGenerateColumns="false" DataKeyNames="IS_CNG_ALWD, ITEM_ID,IS_RJT_ALWD" Width="97%" EmptyDataText="No records found" OnRowCommand="gvIndentDetails_RowCommand">
                                                                <Columns>
                                                                    <asp:TemplateField HeaderText="S#">
                                                                        <ItemTemplate>
                                                                            <%# ((GridViewRow)Container).RowIndex + 1%>.
                                                                        </ItemTemplate>
                                                                        <ItemStyle Width="10px" />
                                                                    </asp:TemplateField>
                                                                    <asp:BoundField HeaderText="Item" DataField="ITEM_NAME"></asp:BoundField>
                                                                    <%-- <asp:TemplateField>

                                                                <ItemTemplate>
                                                                    <asp:Label ID="lb1" Visible='<%#Eval("IS_AVL_ALWD")%>' Text='<%#Eval("QTY")%>' runat="server"></asp:Label>
                                                                </ItemTemplate>
                                                                <ItemStyle Width="60px" />
                                                            </asp:TemplateField>--%>

                                                                    <asp:BoundField HeaderText="Avlbl. Qty" DataField="QTY" Visible="false">
                                                                        <ItemStyle Width="60px" />
                                                                    </asp:BoundField>
                                                                    <asp:BoundField HeaderText="Req. Qty" DataField="REQ_QTY">
                                                                        <ItemStyle Width="60px" />
                                                                    </asp:BoundField>
                                                                    <asp:TemplateField HeaderText="Apr. Qty">
                                                                        <ItemTemplate>
                                                                            <cc1:NumericTextBox ID="txtQuantity"  Text='<%#Eval("APR_QTY") %>'  runat="server" Enabled='<%#Eval("IS_CNG_ALWD")%>' Width="55px"></cc1:NumericTextBox>
                                                                        </ItemTemplate>
                                                                        <ItemStyle Width="60px" />
                                                                    </asp:TemplateField>

                                                                    <asp:TemplateField>
                                                                        <ItemTemplate>

                                                                            <asp:LinkButton ID="lnkIndentDetails" Text="Previous" runat="server" CommandName="Details" CommandArgument="<%# ((GridViewRow)Container).RowIndex%>"></asp:LinkButton>

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
                                                            <summary>Transaction Details</summary>
                                                            <asp:GridView ID="gvTransactionDetails" CssClass="gridDynamic" runat="server" AutoGenerateColumns="false" Width="97%" EmptyDataText="No records found">
                                                                <Columns>
                                                                    <asp:TemplateField HeaderText="S#">
                                                                        <ItemTemplate>
                                                                            <%# ((GridViewRow)Container).RowIndex + 1%>.
                                                                        </ItemTemplate>
                                                                        <ItemStyle Width="10px" />
                                                                    </asp:TemplateField>
                                                                    <asp:BoundField HeaderText="Step By" DataField="IND_NAME"></asp:BoundField>
                                                                    <%-- <asp:BoundField HeaderText="Step Type" DataField="IND_STEP_VALUE"></asp:BoundField>--%>
                                                                    <asp:BoundField HeaderText="Approved Date" DataField="INS_DATE" DataFormatString="{0:dd/MM/yyyy}" />
                                                                    <asp:BoundField HeaderText="Status" DataField="IND_DONE_VALUE"></asp:BoundField>
                                                                    <asp:BoundField HeaderText="Remark" DataField="IND_REM"></asp:BoundField>
                                                                </Columns>
                                                            </asp:GridView>
                                                        </details>
                                                    </td>
                                                </tr>

                                                <tr>
                                                    <td>
                                                        <details open="open">
                                                            <summary>Previous Details</summary>
                                                            <asp:GridView ID="gvPrevious" runat="server" AutoGenerateColumns="False" Width="99%" EmptyDataText="No Record Found" CssClass="gridDynamic">
                                                                <Columns>
                                                                    <asp:TemplateField HeaderText="S#">
                                                                        <ItemTemplate>
                                                                            <%# ((GridViewRow)Container).RowIndex + 1%>.
                                                                        </ItemTemplate>
                                                                        <ItemStyle Width="10px" />
                                                                    </asp:TemplateField>
                                                                    <asp:BoundField DataField="IND_CAL_ID" HeaderText="Indent Id">
                                                                        <ItemStyle Width="150px" />
                                                                    </asp:BoundField>
                                                                    <asp:BoundField DataField="SIV_CAL_ID" HeaderText="SIV Id">
                                                                        <ItemStyle Width="150px" />
                                                                    </asp:BoundField>
                                                                    <asp:BoundField DataField="SIV_DATE" HeaderText="Issued Date" DataFormatString="{0:dd/MM/yyyy}" />
                                                                    <asp:BoundField DataField="ISD_QTY" HeaderText="Issued Qty" />
                                                                </Columns>

                                                            </asp:GridView>
                                                        </details>
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
            </asp:UpdatePanel>
        </div>
    </div>
</asp:Content>

