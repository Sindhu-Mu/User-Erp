<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/FullLength.master" AutoEventWireup="true" CodeFile="rptStuProfile.aspx.cs" Inherits="Academic_rptStuProfile" %>

<%@ Register Src="~/Control/StuFullProfileD.ascx" TagPrefix="uc1" TagName="StuFullProfile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="container">
        <div class="heading">
            <h2>Student Full Profile
            </h2>
        </div>
        <div>
            <table>
                <tr>
                    <td style="padding-left: 400px;">
                        <table>
                            <tr>

                                <td>
                                    <asp:TextBox ID="txtAdmit" runat="server" Width="264px" placeholder="Enter Enrollment No or Roll No or Name">
                                    </asp:TextBox></td>
                                <td>
                                    <asp:Button ID="btnShow" runat="server" Text="Show" Width="60px" OnClick="btnShow_Click"></asp:Button>
                                </td>
                            </tr>

                        </table>
                    </td>
                </tr>
                <tr>
                    <td>
                        <uc1:StuFullProfile runat="server" ID="StuFullProfile" ClientIDMode="Static" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <ajaxToolkit:AutoCompleteExtender ID="AutoCompleteExtender2" runat="server" CompletionSetCount="12"
                            EnableCaching="true" MinimumPrefixLength="1" ServiceMethod="GetStudentList"
                            ServicePath="~/AutoComplete.asmx" TargetControlID="txtAdmit" ContextKey="1,2,3,4,5,6">
                        </ajaxToolkit:AutoCompleteExtender>

                    </td>
                </tr>
            </table>
        </div>
    </div>
</asp:Content>

