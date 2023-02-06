<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Short.master" AutoEventWireup="true" CodeFile="Stu_Pass_Reset.aspx.cs" Inherits="StudentPortal_Stu_Pass_Reset" %>

<%@ Register Src="~/Control/Student.ascx" TagPrefix="uc1" TagName="Student" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentHolder1" Runat="Server">
    <div class="container">
        <div class="heading">
            <h2>Student Portal Password Reset</h2>
        </div>
        <asp:UpdatePanel ID="Updatepanel1" runat="server">
            <ContentTemplate>
                <table>
                    <tr>
                        <td>
                            <table>
                              <tr>
                                  <th>Enrollment No</th>
                                  <td><asp:TextBox ID="txtEnroll" runat="server" Width="200px"></asp:TextBox></td>
                                  <td><asp:Button ID="btnShow" runat="server" Text="Show" OnClick="btnShow_Click" /></td>
                             </tr>
                           </table>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <table>
                    <tr>
                        <td>
                            <uc1:Student runat="server" ID="Student1" />
                        </td>
                    </tr>
                    <tr>
                        <td><asp:Button ID="Pass_reset" runat="server" Text="Reset Password" OnClick="Pass_reset_Click" /></td>
                    </tr>
                </table>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <ajaxToolkit:AutoCompleteExtender ID="autoComplete2" runat="server" TargetControlID="txtEnroll" ServicePath="~/AutoComplete.asmx" ServiceMethod="GetStudentList" 
                                MinimumPrefixLength="1" ContextKey="1,2,3,4,5,6" CompletionSetCount="12" CompletionInterval="500" DelimiterCharacters="" Enabled="True" UseContextKey="True">
                             </ajaxToolkit:AutoCompleteExtender>
                        </td>
                    </tr>
                </table>
                
                
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</asp:Content>

