<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/FullLength.master" AutoEventWireup="true" CodeFile="BookRequisitionApproval.aspx.cs" Inherits="Facility_BookRequisitionApproval" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="container">
        <div class="heading">
            <h2>Book Requisition Approval</h2>
        </div>
        <div>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <div>
                        <table style="width: 100%;">
                            <tr>
                                <th>Applied Book(s) Requisition</th>
                            </tr>
                            <tr>
                                <td>
                                    <asp:GridView ID="gvAppBookReq" Width="99%" runat="server" CssClass="gridDynamic" AutoGenerateColumns="false" DataKeyNames="BOOK_REQ_ID" EmptyDataText="No Record(s) Found" OnRowCommand="gvAppBookReq_RowCommand">
                                        <Columns>
                                            <asp:TemplateField HeaderText="S.No.">
                                                <ItemTemplate>
                                                    <%# ((GridViewRow)Container).RowIndex + 1%>
                                                </ItemTemplate>
                                                <ItemStyle Width="20px" />
                                            </asp:TemplateField>
                                            <asp:BoundField HeaderText="Employee Name" DataField="EMP_NAME" />
                                            <asp:BoundField HeaderText="Department" DataField="DEPT_VALUE" />
                                            <asp:BoundField HeaderText="Designation" DataField="DES_VALUE" />
                                            <asp:BoundField HeaderText="Registration Date" DataField="REQ_DT" />
                                            <asp:BoundField HeaderText="Book Title" DataField="BOOK_TITLE" />
                                            <asp:BoundField HeaderText="No Of Student" DataField="BOOK_NOS" />
                                            <asp:CommandField SelectText="Detail" ShowSelectButton="True" ButtonType="Button" HeaderText="DETAIL"></asp:CommandField>
                                        </Columns>
                                    </asp:GridView>
                                </td>
                            </tr>
                        </table>
                    </div>
                    <div>

                        <asp:GridView ID="gvBookDetail" Width="99%" Caption="Book Details" AutoGenerateColumns="false" runat="server" DataKeyNames="BOOK_REQ_ID" CssClass="gridDynamic" OnRowCancelingEdit="gvBookDetail_RowCancelingEdit" OnRowCommand="gvBookDetail_RowCommand" OnRowEditing="gvBookDetail_RowEditing" OnRowUpdating="gvBookDetail_RowUpdating">
                            <Columns>
                                <asp:TemplateField HeaderText="S.No">
                                    <ItemTemplate>
                                        <%# ((GridViewRow)Container).RowIndex + 1 %>
                                    </ItemTemplate>
                                    <ItemStyle Width="20px" />
                                </asp:TemplateField>
                                <asp:BoundField HeaderText="Book Edition" DataField="BOOK_EDITION" ReadOnly="true" />
                                <asp:BoundField HeaderText="Author" DataField="BOOK_AUTHOR_NAME" ReadOnly="true" />
                                <asp:BoundField HeaderText="Publisher" DataField="BOOK_PUBLISHER" ReadOnly="true" />
                                <asp:BoundField HeaderText="Price" DataField="BOOK_PRICE" ControlStyle-Width="100px" ReadOnly="false" />
                                <asp:BoundField HeaderText="Quantity" DataField="BOOK_NOC" ControlStyle-Width="100px" ReadOnly="false" />
                                <asp:BoundField HeaderText="I.S.B.N" DataField="BOOK_ISBN_NO" ControlStyle-Width="100px" ReadOnly="false" />
                                <asp:BoundField HeaderText="Remark" DataField="BOOK_TRAN_REMARK" ReadOnly="true" />
                                <asp:CommandField HeaderText="Edit" ShowEditButton="true" />
                            </Columns>
                        </asp:GridView>

                    </div>
                    <div>&nbsp;</div>
                    <div id="DivSubmit" runat="server" visible="false">
                        <table style="width: 100%;">
                            <tr>
                                <th style="Width: 20%;">Remark(If Any)</th>
                                <td style="Width: 70%;">
                                    <asp:TextBox ID="txtRemark" runat="server" Width="100%"></asp:TextBox></td>
                                <td>
                                    <asp:Button ID="btnApprove" runat="server" Visible="false" Text="Approve" OnClick="btnApprove_Click" /></td>
                                <td>
                                    <asp:Button ID="btnRecommend" runat="server" Visible="false" Text="Recommend" OnClick="btnRecommend_Click" /></td>
                                <td>
                                    <asp:Button ID="btnCancel" runat="server" Visible="false" Text="Cancel" OnClick="btnCancel_Click" /></td>
                            </tr>
                        </table>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
</asp:Content>

