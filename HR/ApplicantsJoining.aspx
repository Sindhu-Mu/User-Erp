<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/FullLength.master" AutoEventWireup="true" CodeFile="ApplicantsJoining.aspx.cs" Inherits="HR_ApplicantsJoining" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="container">
        <div class="heading">
            <h2>Applicants Joining
            </h2>
        </div>
        <div>
            <table>
                <tr>
                    <td>
                        <table>
                            <tr>
                                <th>Job No.
                                </th>
                                <td>
                                    <asp:DropDownList ID="ddlJob" runat="server" OnSelectedIndexChanged="ddlJob_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:GridView ID="gvApplicants" runat="server" AutoGenerateColumns="false" CssClass="gridDynamic" DataKeyNames="INT_CAN_ID" OnRowCancelingEdit="gvApplicants_RowCancelingEdit" OnRowEditing="gvApplicants_RowEditing" OnRowUpdating="gvApplicants_RowUpdating">
                            <Columns>
                                <asp:TemplateField HeaderText="S#">
                                    <ItemTemplate>
                                        <%# ((GridViewRow )Container).RowIndex+1 %>.
                                    </ItemTemplate>
                                    <ItemStyle Width="15px" />
                                </asp:TemplateField>
                                <asp:BoundField HeaderText="Name" DataField="Name" ReadOnly="true"/>
                                <asp:TemplateField HeaderText="Interview Date">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txtDate" runat="server" Text='<%#Eval("DATE") %>'></asp:TextBox>
                                        <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtDate" Format="dd/MM/yyyy">
                                    </ajaxToolkit:CalendarExtender>
                                    <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender1" runat="server" Mask="99/99/9999" MaskType="Date"
                                        TargetControlID="txtDate">
                                    </ajaxToolkit:MaskedEditExtender>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblDate" runat="server" Text='<%#Eval("DATE") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Joined">
                                    <ItemTemplate>
                                        <asp:RadioButtonList ID="rbJoined" runat="server" RepeatDirection="Horizontal">
                                            <asp:ListItem Text="Yes" Value="11"></asp:ListItem>
                                            <asp:ListItem Text="No" Value="7" Selected="True"></asp:ListItem>
                                        </asp:RadioButtonList>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:CommandField ShowEditButton="True" ButtonType="Button" HeaderText="Update">
                                        <ControlStyle CssClass="btnblue" />
                                    </asp:CommandField>
                            </Columns>
                        </asp:GridView>
                    </td>
                </tr>
                
            </table>
        </div>
    </div>
</asp:Content>

