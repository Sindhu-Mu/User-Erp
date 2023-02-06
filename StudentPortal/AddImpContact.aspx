<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Short.master" AutoEventWireup="true" CodeFile="AddImpContact.aspx.cs" Inherits="StudentPortal_AddImpContact" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentHolder1" Runat="Server">
    <div class="container">
        <div class="heading">
            <h2>Important Contacts</h2>
        </div>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <table>
                    <tr>
                        <th>Department</th>
                        <th>Employee</th>
                    </tr>
                    <tr>
                        <td><asp:TextBox ID="txtDept" runat="server"></asp:TextBox></td>
                        <td><asp:TextBox ID="txtEmp" runat="server"></asp:TextBox></td>
                        <td><ajaxToolkit:AutoCompleteExtender ID="AutoComplete1" runat="server" EnableCaching="true" TargetControlID="txtEmp" ServicePath="~/AutoComplete.asmx" ServiceMethod="GetEmployeeList"
                         MinimumPrefixLength="1" ContextKey="1" CompletionSetCount="12" CompletionInterval="500">
                         </ajaxToolkit:AutoCompleteExtender>
                        </td>
                    </tr>
                    <tr>
                        <th>Mail Value</th>
                        <th>Mail Domain</th>
                        <th>Mobile No</th>
                    </tr>
                    <tr>
                         <td><asp:TextBox ID="txtMail" runat="server"></asp:TextBox></td>
                        <td><asp:DropDownList ID="ddlMail" runat="server"></asp:DropDownList></td>
                        <td><cc1:NumericTextBox ID="txtPhn" runat="server"></cc1:NumericTextBox></td>
                        <td><asp:Button ID="btnAdd" runat="server" Text="ADD" OnClick="btnAdd_Click" /></td>
                    </tr>
                </table>
                <table>
                    <tr>
                        <td>
                            <asp:GridView ID="gvContacts" runat="server" CssClass="gridDynamic" AutoGenerateColumns="false">
                                <Columns>
                                     <asp:TemplateField HeaderText="S.No.">
                                      <ItemTemplate>
                                       <%# ((GridViewRow)Container).RowIndex + 1%>
                                .      </ItemTemplate>
                                       </asp:TemplateField>
                                    <asp:BoundField HeaderText="Department" DataField="DEPT" />
                                    <asp:BoundField HeaderText="Employee Name" DataField="EMP_NAME" />
                                    <asp:BoundField HeaderText="Mail Id" DataField="Email" />
                                    <asp:BoundField HeaderText="Phone No" DataField="PHN_NO" />
                                </Columns>
                            </asp:GridView>
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</asp:Content>

