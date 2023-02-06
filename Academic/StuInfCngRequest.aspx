<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/FullLength.master" AutoEventWireup="true" CodeFile="StuInfCngRequest.aspx.cs" Inherits="Academic_StuInfCngRequest" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="container">
        <div class="heading">
            <h2>Student Change Request</h2>
        </div>
        <asp:UpdatePanel ID="Updtepanel1" runat="server">
            <ContentTemplate>
                <table>
                    <tr>
                        <th>Status</th>
                        <td>
                            <asp:DropDownList ID="ddlsts" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlsts_SelectedIndexChanged"></asp:DropDownList>
                        </td>
                    </tr>
                    </table>
                <table>
                    <tr>
                        <td>
                            <asp:GridView ID="gvStu" runat="server" AutoGenerateColumns="false" CssClass="gridDynamic" DataKeyNames="STU_INF_ID" EmptyDataText="No records found" OnRowCommand="gvStu_RowCommand">
                                <Columns>
                                    <asp:TemplateField HeaderText="S.No">
                                      <ItemTemplate>
                                            <%#((GridViewRow)Container).RowIndex +1 %>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField HeaderText="Enrollment" DataField="ENROLLMENT_NO" />
                                    <asp:BoundField HeaderText="Request By" DataField="STU_FULL_NAME" />
                                    <asp:BoundField HeaderText="Request Date" DataField="INS_DT" DataFormatString="{0:dd/MM/yyyy}" />
                                    <asp:BoundField HeaderText="Change Request" DataField="CNG_INF" />
                                   <asp:TemplateField HeaderText="Action">
                                      <ItemTemplate>
                                          <asp:LinkButton ID="btnClose" runat="server" Text="Close" CommandName="Details" CommandArgument="<%# ((GridViewRow)Container).RowIndex%>"></asp:LinkButton>
                                      </ItemTemplate>
                                       <ItemStyle Width="50px" />
                                   </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </td>
                         <td id="tblIssue" runat="server" style="vertical-align: top;">
                                                    <table>
                                                        <tr>
                                                            <th>Solved:
                                                                <br />
                                                                <asp:Label ID="lblSolved" runat="server" ForeColor="#ff0000"></asp:Label>
                                                            </th>
                                                        </tr>
                                                        <tr>
                                                            <th>Pending:
                                                                <br />
                                                                <asp:Label ID="lblPending" runat="server" ForeColor="#ff0000"></asp:Label></th>
                                                        </tr>
                                                        <tr>
                                                            <th>Reject:
                                                                <br />
                                                                <asp:Label ID="lblReject" runat="server" ForeColor="#ff0000"></asp:Label></th>
                                                        </tr>
                                                        <tr>
                                                            <th>Total:
                                                                <br />
                                                                <asp:Label ID="lblTotal" runat="server" ForeColor="#ff0000"></asp:Label></th>
                                                        </tr>
                                                    </table>
                                                </td>
                    </tr>
                </table>
                <table id="tblAction" runat="server">
                    <tr>
                        <th>Action</th>
                        <td><asp:DropDownList ID="ddlAction" runat="server"></asp:DropDownList></td>
                        <th>Remark</th>
                        <td><asp:TextBox ID="txtRemark" runat="server" Width="200px"></asp:TextBox></td>
                        <td><asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" /></td>

                    </tr>
                </table>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</asp:Content>

