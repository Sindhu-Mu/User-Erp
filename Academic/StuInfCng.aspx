<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/FullLength.master" AutoEventWireup="true" CodeFile="StuInfCng.aspx.cs" Inherits="Academic_StuPicChange" %>

<%@ Register Src="~/Control/Student.ascx" TagPrefix="uc1" TagName="Student" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script lang="javascript" type="text/javascript">
        function CheckAutoComplete(ctrl) {

            var Value = bTrim(document.getElementById(ctrl).value);
            if (Value.indexOf(":") > 0 && Value.length - 1 != Value.lastIndexOf(":")) {
                document.getElementById(ctrl).style.backgroundColor = "#fff";
                return true;
            }
            else
                document.getElementById(ctrl).style.backgroundColor = "#fc6";
            return false;
        }
        function CheckControl(ctrl) {
            if (bTrim(document.getElementById(ctrl).value) == "" || bTrim(document.getElementById(ctrl).value) == ".") {
                document.getElementById(ctrl).style.backgroundColor = "#fc6";
                return false;
            }
            else
                document.getElementById(ctrl).style.backgroundColor = "#fff";
            return true;
        }
        function Validate() {
            var flag = true;
            var msg = "", ctrl = "";
            if (!CheckAutoComplete("<%=txtEnroll.ClientID%>")) {
                msg += " * Enter Name with Enrollment. \n";
                if (ctrl == "")
                    ctrl = "<%=txtEnroll.ClientID%>";
                flag = false;
            }
            if (msg != "") alert(msg);
            if (ctrl != "")
                document.getElementById(ctrl).focus();
            return flag;
        }
        function Validation() {
            var flag = true;
            var msg = "", ctrl = "";
            if (!CheckAutoComplete("<%=txtEnroll.ClientID%>")) {
                msg += " * Enter name with enrollment. \n";
                if (ctrl == "")
                    ctrl = "<%=txtEnroll.ClientID%>";
                flag = false;
            }
            if (msg != "") alert(msg);
            if (ctrl != "")
                document.getElementById(ctrl).focus();
            return flag;
        }
    </script>
    <div class="container">
        <div class="heading">
            <h2>Student Information Change</h2>
        </div>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <div>
                    <div style="float:right;">
                        <table>
                            <tr>
                                <th>Enrollment No<span class="required">*</span></th>
                                <td>
                                    <asp:TextBox ID="txtEnroll" runat="server" Width="250px"></asp:TextBox></td>
                                <td>
                                    <asp:Button ID="btnShow" runat="server" Text="Show" OnClick="btnShow_Click" /></td>
                            </tr>
                        </table>
                    </div>
                    <div class="cleaner"></div>
                    <div>
                        <uc1:Student runat="server" ID="Student" />
                        <ajaxToolkit:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" CompletionInterval="500"
                            CompletionSetCount="12" ContextKey="1" EnableCaching="true" MinimumPrefixLength="1"
                            ServiceMethod="GetStudentList" ServicePath="~\AutoComplete.asmx" TargetControlID="txtEnroll">
                        </ajaxToolkit:AutoCompleteExtender>
                    </div>
                    <div>
                        <table>
                            <tr>
                                <th>Father Name</th>
                                <td>
                                    <asp:TextBox ID="txtFatherName" runat="server" Width="250px"></asp:TextBox></td>
                                <th>Mother Name</th>
                                <td>
                                    <asp:TextBox ID="txtMotherName" runat="server" Width="250px"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <th>Phone Type</th>
                                <td>
                                    <asp:DropDownList ID="ddlPhnType" runat="server" Width="250px"></asp:DropDownList></td>
                                <th>Student Mobile No</th>
                                <td>
                                    <cc1:NumericTextBox ID="txtStuMobile" runat="server" Width="250px"></cc1:NumericTextBox></td>
                            </tr>
                            <tr>
                                <th>Email Id</th>
                                <td><asp:TextBox ID="txtEmail" runat="server" Width="250px"></asp:TextBox></td>
                                <th>Domain Value</th>
                                <td><asp:DropDownList ID="ddlDomain" runat="server" Width="250px"></asp:DropDownList></td>
                            </tr>
                        </table>
                    </div>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
        <div>
            <table>
                <tr>
                    <th>Picture</th>
                    <td>
                        <input type="file" id="flPhoto" runat="server" Width="250px" />
                    </td>
                </tr>              
            </table>
        </div>
        <div style="float:right;"><asp:Button ID="btnUpload" runat="server" Text="Update" OnClick="btnUpload_Click" /></div>
    </div>
</asp:Content>

