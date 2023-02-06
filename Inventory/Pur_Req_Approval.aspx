<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/FullLength.master" AutoEventWireup="true" CodeFile="Pur_Req_Approval.aspx.cs" Inherits="Inventory_Pur_Req_Approval" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <div class="container">
        <div class="heading">
            <h2>Requisition Approval</h2>
        </div>
        <table style="width: 800px">
            <tr>

                <td>

                    <asp:UpdatePanel ID="up1" runat="server">
                        <ContentTemplate>
                            <table style="width: 800px; border-collapse: collapse; border-spacing: 0px; vertical-align: top; text-align: left">
                                <tr>

                                    <td style="width: 45%; vertical-align: top">
                                        <fieldset style="border-collapse: collapse; border-spacing: 0px; margin: 0px; padding: 0px; border: none">
                                            <legend>Applied Purchase Requisition</legend>
                                            <div style="height: 600px; overflow: auto">
                                                <asp:GridView ID="gv_requisition" CssClass="gridDynamic" runat="server" AutoGenerateColumns="false" DataKeyNames="PUR_REQ_ID" OnRowCommand="gv_requisition_RowCommand" EmptyDataText="No Record Found" Font-Size="Small">
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="S.No.">
                                                            <ItemTemplate>
                                                                <%# ((GridViewRow)Container).RowIndex + 1%>.
                                                            </ItemTemplate>
                                                            <ItemStyle Width="10px" />
                                                        </asp:TemplateField>
                                                        <asp:BoundField HeaderText="Requisition Number" DataField="PUR_REQ_NO" />
                                                        <asp:BoundField HeaderText="Date" DataField="REQ_ON_DT" />
                                                        <asp:BoundField HeaderText="Forwarded By" DataField="EMP_NAME" />
                                                        <%--<asp:BoundField HeaderText="Remarks" DataField="REQ_REMARK" />--%>
                                                        <asp:BoundField HeaderText="Status" DataField="STS_VALUE" />
                                                        <asp:BoundField HeaderText="Total Amount" DataField="AMOUNT" />
                                                        <asp:CommandField SelectText="Detail" ShowSelectButton="True" ButtonType="Button" HeaderText="DETAIL"></asp:CommandField>
                                                    </Columns>
                                                </asp:GridView>
                                            </div>

                                        </fieldset>
                                    </td>
                                    <td style="width: 1%; height: 100%; border-left: 1px solid red; margin-left: 5px"></td>
                                    <td style="vertical-align: top; width: 49%; text-align: left">
                                        <table style="border-collapse: collapse; border-spacing: 0px; text-align: center">
                                            <tr>
                                                <td style="text-align: left">
                                                    <details open="open">
                                                        <summary style="text-align: left">Item Details</summary>
                                                    </details>
                                                    <asp:GridView ID="gv_ItemDetails" CssClass="gridDynamic" EmptyDataText="No Record Found" runat="server" AutoGenerateColumns="False" DataKeyNames="REQ_SUB_ID" OnRowCancelingEdit="gv_ItemDetails_RowCancelingEdit" OnRowEditing="gv_ItemDetails_RowEditing" OnRowDeleting="gv_ItemDetails_RowDeleting" OnRowCommand="gv_ItemDetails_RowCommand" OnRowUpdating="gv_ItemDetails_RowUpdating">
                                                        <Columns>
                                                            <asp:TemplateField HeaderText="S.No.">
                                                                <ItemTemplate>
                                                                    <%# ((GridViewRow)Container).RowIndex + 1%>.
                                                                </ItemTemplate>
                                                                <ItemStyle Width="10px" />
                                                            </asp:TemplateField>
                                                            <asp:BoundField HeaderText="Item Name" DataField="ITEM_NAME" ReadOnly="true" />
                                                            <asp:BoundField HeaderText="Req.Quantity" DataField="REQ_ITEM_QTY" ReadOnly="false" />
                                                            <asp:BoundField HeaderText="Unit" DataField="UNIT_NAME" ReadOnly="true" />
                                                            <asp:BoundField HeaderText="Amount" DataField="AMOUNT" ReadOnly="true" />
                                                            <asp:BoundField HeaderText="Supplier Name" DataField="ORG_NAME" ReadOnly="true" />
                                                            <asp:CommandField HeaderText="Edit" ShowEditButton="true" />
                                                            <asp:CommandField HeaderText="Delete" ShowDeleteButton="true" />
                                                        </Columns>
                                                    </asp:GridView>
                                                </td>

                                            </tr>
                                            <tr>
                                                <td>
                                                    <hr style="color: #ff8c00; width: 100%; height: 0px; border-bottom-color: red; border-bottom-width: 1px; border-collapse: collapse; border-spacing: 0px;" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="text-align: left">
                                                    <details open="open">
                                                        <summary style="text-align: left">Supplier Details</summary>
                                                    </details>
                                                    <asp:GridView ID="gv_SupDetails" runat="server" AutoGenerateColumns="false" CssClass="gridDynamic" OnRowCommand="gv_SupDetails_RowCommand" DataKeyNames="REQ_SUB_ID" EmptyDataText="No Record Found">
                                                        <Columns>
                                                            <asp:TemplateField HeaderText="S.No.">
                                                                <ItemTemplate>
                                                                    <%# ((GridViewRow)Container).RowIndex + 1%>.
                                                                </ItemTemplate>
                                                                <ItemStyle Width="10px" />
                                                            </asp:TemplateField>
                                                            <asp:BoundField HeaderText="Supplier Name" DataField="ORG_NAME" />
                                                            <asp:BoundField HeaderText="Address" DataField="ADDRESS" />
                                                            <asp:BoundField HeaderText="Contact No." DataField="ORG_PHN_NO" />
                                                            <asp:BoundField HeaderText="Email Id" DataField="ORG_MAIL_VALUE" />
                                                            <asp:CommandField ButtonType="Image" HeaderText="Delete" SelectImageUrl="~/Siteimages/delete.jpg" ShowSelectButton="True">
                                                                <ItemStyle Width="40px" />
                                                            </asp:CommandField>
                                                        </Columns>
                                                    </asp:GridView>
                                                </td>
                                            </tr>

                                            <tr>
                                                <td>
                                                    <table>
                                                        <tr id="trRmrk" runat="server" visible="false">
                                                            <th>Remark
                                                            </th>
                                                            <td>
                                                                <asp:TextBox ID="txtRemark" runat="server" Width="300"></asp:TextBox>
                                                            </td>
                                                        </tr>

                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <table>
                                                        <tr>
                                                            <td>
                                                                <asp:Button ID="btnApprove" Text="Approve" runat="server" Visible="false" OnClick="btnApprove_Click" />
                                                            </td>
                                                            <td>
                                                                <asp:Button ID="btnRcmnd" Text="Recommend" runat="server" Visible="false" OnClick="btnRcmnd_Click" />
                                                            </td>
                                                            <td>
                                                                <asp:Button ID="btnCancel" Text="Cancel" runat="server" Visible="false" OnClick="btnCancel_Click" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
            </tr>
        </table>

    </div>
</asp:Content>

