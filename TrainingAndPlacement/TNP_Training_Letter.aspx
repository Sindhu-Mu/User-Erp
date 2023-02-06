<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/FullLength.master" AutoEventWireup="true" CodeFile="TNP_Training_Letter.aspx.cs" Inherits="TrainingAndPlacement_TNP_Training_Letter" %>

<%@ Register Src="~/Control/Student.ascx" TagPrefix="uc1" TagName="Student" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="container">
        <div class="heading">
            <h2>Training Letter</h2>
        </div>
        <div>
            <table>
                <tr>
                    <td style="text-align: right;">
                        <table>
                            <tr>

                                <th>Enrollment<span class="required">*</span></th>
                                <td>
                                    <asp:TextBox ID="txtEnrollment" runat="server" Width="250px"></asp:TextBox>
                                   
                                </td>
                                <td> <asp:Button ID="btnShow" runat="server" Text="Show" OnClick="btnShow_Click" /></td>
                            </tr>

                        </table>
                    </td>
                </tr>
                <tr>
                    <td>
                        <uc1:Student runat="server" ID="Student" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <table>
                            <tr>
                                <th>Training Letter</th>
                                <td></td>
                                <td>
                                    <asp:Button ID="btnPrint" Text="Print" runat="server" Width="60px" OnClick="btnPrint_Click" /></td>
                            </tr>
                            <tr>
                                <th>Upload Resume</th>
                                <td>
                                    <asp:FileUpload ID="upd1" runat="server" />
                                </td><td><asp:Button ID="btnupload" Text="Upload" runat="server" OnClick="btnupload_Click" /></td>
                            </tr>
                            <tr>
                                <th>Download Resume</th>
                                <td><a id="A1" runat="server">Download Resume(.doc)</a>
                            </td>
                                <td>
                                   <a id="A2" runat="server">Download Resume(.docx)</a>
                            
                            </tr>
                        </table>
                    </td>
                </tr>

                <tr>
                    <td>

                        <ajaxToolkit:AutoCompleteExtender ID="AutoCompleteExtender2" runat="server" CompletionSetCount="12"
                            EnableCaching="true" MinimumPrefixLength="1" ServiceMethod="GetStudentList"
                            ServicePath="~\AutoComplete.asmx" TargetControlID="txtEnrollment" ContextKey="1">
                        </ajaxToolkit:AutoCompleteExtender>
                    </td>
                </tr>
            </table>
        </div>

    </div>
</asp:Content>

