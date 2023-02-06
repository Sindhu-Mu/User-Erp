<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/FullLength.master" AutoEventWireup="true" CodeFile="RegisterationBlock.aspx.cs" Inherits="Academic_Default" %>

<%@ Register Src="~/Control/Student.ascx" TagPrefix="uc1" TagName="Student" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="container">
        <div class="heading">
            <h2>Registeration Block</h2>
        </div>
    <div>
        <table>
            <tr>
                <th>Enrollment No</th>
            </tr>
            <tr>
                <td>
                    <asp:TextBox ID="txtEnroll" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:Button ID="btnshow" runat="server" TEXT="SHOW" OnClick="btnshow_Click"/>
                </td>
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
        <table>
            <tr>
             <td>
                 <uc1:Student runat="server" ID="Student" />
             </td>
             </tr>
        </table>
    </div>
        <div>
            <asp:GridView ID="gvregblock" runat="server" Width="60%" EmptyDataText="No record found"
                                    CellPadding="3" AutoGenerateColumns="False" datakeynames="stu_main_id" OnRowCommand="gvGroupHeads_RowCommand">
                                    <Columns>
                                        <asp:BoundField HeaderText="S#">
                                            <ItemStyle Width="15px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="ENROLLMENT_NO" HeaderText="ENROLLMENT NO">
                                            <ItemStyle Width="90px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="STU_FULL_NAME" HeaderText="STUDENT NAME">
                                            <ItemStyle Width="90px" />
                                        </asp:BoundField>
                                       <asp:BoundField DataField="REG_BLOCK_BY" HeaderText="INSERT BY" >
                                        <ItemStyle Width="90px" />
                                       </asp:BoundField>
                                        <asp:BoundField DataField="REG_BLOCK_DATE" HeaderText="INSERT DATE" >
                                     <ItemStyle Width="90px" />
                                       </asp:BoundField>
                                        
                                        <asp:TemplateField ShowHeader="False" HeaderText="Status">
                                            <ItemStyle Width="20px" HorizontalAlign="Right" />
                                            <ItemTemplate>
                                                <asp:ImageButton ID="imgAct" runat="server" CausesValidation="false" CommandArgument='<%# Bind("STU_MAIN_ID") %>'
                                                    CommandName="Delete" ImageUrl="~/images/deactivate.gif" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <SelectedRowStyle BackColor="#99FF33" />
                                </asp:GridView>
        </div>
        <div>
            <table>
                <tr>
                    <th>REMARK<span style="color:red">*</span></th>
                    <td>
                        <asp:TextBox ID="TXTREMARK" runat="server" ></asp:TextBox>
                    </td>
                </tr>
            </table>
        </div>
        <asp:Button ID="btnsave" runat="server" Text="Save" OnClick="btnsave_Click"/>
        </div>
</asp:Content>

