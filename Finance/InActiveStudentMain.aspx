<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Short.master" AutoEventWireup="true" CodeFile="InActiveStudentMain.aspx.cs" Inherits="Finance_InActiveStudentMain" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentHolder1" Runat="Server">
    <div class="container">
        <div class="heading">
            <h2>InActive Students</h2>
            </div>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <table>
                    <tr>
                        <td>
                            <table>
                                <tr>
                                    <th>Enrollment
                            <span class="required">*</span></th>
                                    <td>&nbsp;</td>
                                    
                                </tr>
                                <tr>
                                    <td>
                                        <asp:TextBox ID="txtEnroll" runat="server" CssClass="textBox" Width="300px"></asp:TextBox></td>
                                    <td>&nbsp;</td>
                                    
                                    <td>
                                        <asp:Button ID="btnSave" runat="server" Text="Save" Width="70px" OnClick="btnSave_Click" /></td>
                                </tr>
                                <tr>
                    <td>

                        <ajaxToolkit:AutoCompleteExtender ID="AutoCompleteExtender2" runat="server" CompletionSetCount="12"
                            EnableCaching="true" MinimumPrefixLength="1" ServiceMethod="GetStudentList"
                            ServicePath="~\AutoComplete.asmx" TargetControlID="txtEnroll" ContextKey="1">
                        </ajaxToolkit:AutoCompleteExtender>
                    </td>
                </tr>


                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:GridView ID="gvShow" runat="server" AutoGenerateColumns="False" DataKeyNames="stu_main_id" CssClass="gridDynamic" OnRowCommand="gvShow_RowCommand" EmptyDataText="No Record Avaliable">
                                <Columns>
                                    <asp:TemplateField HeaderText="S.No.">
                                        <ItemTemplate>
                                            <%# ((GridViewRow)Container).RowIndex + 1%>                                .
                                        </ItemTemplate>
                                        <ItemStyle Width="20px" />
                                    </asp:TemplateField>
                                    <asp:BoundField HeaderText="ENROLLMENT" DataField="ENROLLMENT_NO" />
                                    <asp:BoundField HeaderText="NAME" DataField="STU_FULL_NAME" />
                                   
                                    <asp:TemplateField ShowHeader="False" HeaderText="Status">
                                        <ItemStyle Width="20px" HorizontalAlign="Right" />
                                        <ItemTemplate>
                                            <asp:ImageButton ID="ImageButton1" runat="server" CausesValidation="false" CommandArgument='<%# Bind("stu_main_id") %>'
                                                ImageUrl='<%# Bind("STS_IMG") %>' CommandName='<%# Bind("STS_CMD") %>' ToolTip='<%# Bind("STS_TOOLTIP")%>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
        </asp:UpdatePanel>
        
        </div>
</asp:Content>

