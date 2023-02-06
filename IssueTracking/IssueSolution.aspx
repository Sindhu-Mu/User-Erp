<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Short.master" AutoEventWireup="true" CodeFile="IssueSolution.aspx.cs" Inherits="IssueTracking_IssueSolution" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentHolder1" Runat="Server">
    <div class="container">
        <div class="heading">
            <h2>Issue Solution</h2>
        </div>
        <table>
            <tr>
                <td>
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                            <table>
                                <tr>
                                    <th>Pending Issues</th>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:GridView ID="gvPending" runat="server" AutoGenerateColumns="false" DataKeyNames="ISSUE_ID" CssClass="gridDynamic" OnRowCommand="gvPending_RowCommand">
                                            <Columns>
                                                 <asp:TemplateField HeaderText="S.No.">
                                                            <ItemTemplate>
                                                                <%# ((GridViewRow)Container).RowIndex + 1%>
                                                            </ItemTemplate>
                                                            <ItemStyle Width="20px" />
                                                        </asp:TemplateField>
                                                <asp:BoundField HeaderText="Student Name" DataField="STU_FULL_NAME" />
                                                 <asp:BoundField HeaderText="Issue Area" DataField="SUB_HEAD_VALUE" />
                                                <asp:BoundField HeaderText="Issue" DataField="ISSUE_TOKEN_NO" />
                                                <asp:BoundField HeaderText="Issue Raised On" DataField="RAISED_ON" />
                                                <asp:BoundField HeaderText="Issue As A" DataField="ISSUE_TYPE_VALUE" />
                                                <asp:CommandField SelectText="Detail" ShowSelectButton="True" ButtonType="Button" HeaderText="DETAIL"></asp:CommandField>
                                            </Columns>
                                        </asp:GridView>
                                    </td>
                                </tr>
                            </table>
                            <table>
                                <tr>
                                    <th>Issue Detail</th></tr>
                                <tr>
                                    <td>
                                        <asp:GridView ID="gvDetail" runat="server" AutoGenerateColumns="false" CssClass="gridDynamic" DataKeyNames="ISSUE_ID" OnRowCommand="gvDetail_RowCommand">
                                            <Columns>
                                                <asp:TemplateField HeaderText="S.NO">
                                                    <ItemTemplate>
                                                        <%#((GridViewRow)Container).RowIndex+1 %>
                                                    </ItemTemplate>
                                                    <ItemStyle Width="20px" />
                                                </asp:TemplateField>
                                                <asp:BoundField HeaderText="Issue Related To" DataField="HEAD_VALUE" />
                                                <asp:BoundField HeaderText="Issue Area" DataField="SUB_HEAD_VALUE" />
                                                 <asp:BoundField HeaderText="Issue Detail" DataField="ISSUE_DETAIL" />
                                                <asp:BoundField HeaderText="Student Department" DataField="INS_VALUE" />
                                                <asp:BoundField HeaderText="Course" DataField="PGM_FULL_NAME" />
                                                <asp:BoundField HeaderText="Issue Status" DataField="ISSUE_STS_VALUE" />
                                                <asp:CommandField ButtonType="Button" SelectText="Provide Solution" ShowSelectButton="true" />
                                              </Columns>
                                        </asp:GridView>
                                    </td>
                                </tr>
                            </table>
                            <table>
                                <tr>
                                    <th>Solution</th>
                                    <td><asp:TextBox ID="txtRemark" runat="server" TextMode="MultiLine" Visible="false"></asp:TextBox></td>
                                </tr>
                                <tr>
                                   <td><asp:Button ID="btnSolved" runat="server" Text="Solve" OnClick="btnSolved_Click" Visible="false" /></td>
                                    <td><asp:Button ID="btnTransfer" runat="server" Text="Transfer" OnClick="btnTransfer_Click" Visible="false" /></td>
                                </tr>
                            </table>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>

