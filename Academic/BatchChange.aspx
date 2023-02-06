<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/FullLength.master" AutoEventWireup="true" CodeFile="BatchChange.aspx.cs" Inherits="Academic_BatchChange" %>

<%@ Register Src="~/Control/Student.ascx" TagPrefix="uc1" TagName="Student" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script type="text/javascript" lang="javascript">
        function CheckControl(ctrl) {
            if (bTrim(document.getElementById(ctrl).value) == "" || bTrim(document.getElementById(ctrl).value) == "." || bTrim(document.getElementById(ctrl).value) == "Select") {
                document.getElementById(ctrl).style.backgroundColor = "#fc6";
                return false;
            }
            else
                document.getElementById(ctrl).style.backgroundColor = "#fff";
            return true;
        }
        function validateShow() {
            var flag = true;
            var msg = "", ctrl = "";

            if (!CheckControl("<%=txtStudent.ClientID%>")) {
                msg += " * Enter Enrollment \n";
                if (ctrl == "")
                    ctrl = "<%=txtStudent.ClientID%>";
                flag = false;
            }
            if (msg != "") alert(msg);
            if (ctrl != "")
                document.getElementById(ctrl).focus();
            return flag;
        }
        function validateChange() {
            var flag = true;
            var msg = "", ctrl = "";
            if (!CheckControl("<%=ddlBatch.ClientID%>")) {
                msg += " * Select Institution. \n";
                if (ctrl == "")
                    ctrl = "<%=ddlBatch.ClientID%>";
                flag = false;
            }
            if (!CheckControl("<%=txtRemark.ClientID%>")) {
                msg += " * Enter Remark \n";
                if (ctrl == "")
                    ctrl = "<%=txtRemark.ClientID%>";
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
            <h2>Batch Change</h2>
        </div>

        <table>
            <tr>
                <td>
                    <table>
                        <tr>

                            <td>
                                <asp:TextBox ID="txtStudent" Width="230px" runat="server">
                                </asp:TextBox></td>
                            <td><asp:Button ID="btnShow" runat="server" Text="Show" Width="80px" OnClick="btnShow_Click"></asp:Button>
                                
                            </td>
                            <td>
                                <ajaxToolkit:AutoCompleteExtender ID="AutoCompleteExtender2" runat="server" CompletionSetCount="12"
                                    EnableCaching="true" MinimumPrefixLength="1" ServiceMethod="GetStudentList"
                                    ServicePath="~\AutoComplete.asmx" TargetControlID="txtStudent" ContextKey="1,2,3,4,5,6">
                                </ajaxToolkit:AutoCompleteExtender>
                            </td>
                        </tr>
                     
                    </table>
                </td>
            </tr>
            <tr>
                <td>
                    <uc1:Student runat="server" ID="Student" />
                </td>
            </tr>
        </table>

        <table>
            <tr>

                <th>Batch<span style="color: red">*</span></th>
                <th>Remark<span style="color: red">*</span></th>

            </tr>
            <tr>

                <td>
                    <asp:DropDownList ID="ddlBatch" runat="server" Width="100px"></asp:DropDownList>
                </td>
                <td>
                    <asp:TextBox ID="txtRemark" runat="server">
                    </asp:TextBox>
                </td>
                <td>
                    <asp:Button ID="btnChange" runat="server" Text="Change" Width="60px" OnClick="btnChange_Click" ></asp:Button>
                </td>

            </tr>
        </table>
    </div>
</asp:Content>

