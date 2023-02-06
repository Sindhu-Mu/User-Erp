<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/FullLength.master" AutoEventWireup="true" CodeFile="StudentAcheiveAndMisBehav.aspx.cs" Inherits="Academic_StudentAcheiveAndMisBehav" %>

<%@ Register Src="~/Control/Student.ascx" TagPrefix="uc1" TagName="Student" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="container">
        <div class="heading">
            <h2>Student Achievements & MisBehave</h2>
        </div>
        <div>
            <table>
                    <tr>
                        <td>
                            <table>
                                <tr>
                                    <th>Enrollment No<span class="required">*</span></th>
                                    <td>
                                        <asp:TextBox ID="txtEnroll" runat="server" Width="250px"></asp:TextBox></td>
                                    <td>
                                        <asp:Button ID="btnShow" runat="server" Text="Show" OnClick="btnShow_Click" /></td>
                                </tr>
                            </table>
                            <table>
                                <tr>
                                    <td>
                                        <uc1:Student runat="server" ID="Student" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <ajaxToolkit:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" CompletionInterval="500"
                                            CompletionSetCount="12" ContextKey="1" EnableCaching="true" MinimumPrefixLength="1"
                                            ServiceMethod="GetStudentList" ServicePath="~\AutoComplete.asmx" TargetControlID="txtEnroll">
                                        </ajaxToolkit:AutoCompleteExtender>

                                    </td>
                                </tr>
                            </table>
                            <table>
                                  <tr>
                                    <th>Session</th>
                                    <td>
                                        <asp:DropDownList ID="ddlSession" runat="server" ></asp:DropDownList>
                                    </td>
                                </tr>

                                <tr>
                                    <th>Type</th>
                                    <td>
                                        <asp:DropDownList ID="ddType" runat="server">

                                            <asp:ListItem Value="0" Text="Select"></asp:ListItem>
                                            <asp:ListItem Value="1" Text="Achievements"></asp:ListItem>
                                            <asp:ListItem Value="2" Text="MisBehaviour"></asp:ListItem>

                                        </asp:DropDownList></td>
                                    </tr>
                                <tr>
                                    <th>Remark</th>
                                   
                                    <td>
                                        <asp:TextBox ID="txtRmk" TextMode="MultiLine" runat="server"></asp:TextBox></td>
                                       </tr>
                              
                                <tr>
                                    <td>
                                        <asp:Button ID="btnSave" runat="server"  Text="Save"  OnClick="btnSave_Click"/>
                                    </td>
                                </tr>

                                
                            </table>
                        </td>
                </table>
        </div>
    </div>
</asp:Content>

