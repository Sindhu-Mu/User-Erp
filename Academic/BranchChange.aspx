<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/FullLength.master" AutoEventWireup="true" CodeFile="BranchChange.aspx.cs" Inherits="Academic_BranchChange" %>

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

            if (!CheckControl("<%=txtEnroll.ClientID%>")) {
                msg += " * Enter Enrollment \n";
                if (ctrl == "")
                    ctrl = "<%=txtEnroll.ClientID%>";
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
            if (!CheckControl("<%=ddlInstitution.ClientID%>")) {
                msg += " * Select Institution. \n";
                if (ctrl == "")
                    ctrl = "<%=ddlInstitution.ClientID%>";
                flag = false;
            }
            if (!CheckControl("<%=ddlCourse.ClientID%>")) {
                msg += " * Select Course. \n";
                if (ctrl == "")
                    ctrl = "<%=ddlCourse.ClientID%>";
                flag = false;
            }
            if (!CheckControl("<%=ddlBranch.ClientID%>")) {
                msg += " * Select Branch. \n";
                if (ctrl == "")
                    ctrl = "<%=ddlBranch.ClientID%>";
                flag = false;
            }
            if (!CheckControl("<%=ddlSemester.ClientID%>")) {
                msg += "*  Select Semester \n";
                if (ctrl == "")
                    ctrl = "<%=ddlSemester.ClientID%>";
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
            <h2>Branch Change</h2>
        </div>

        <table>
            <tr>
                <td>
                    <table>
                        <tr>

                            <td>
                                <asp:TextBox ID="txtEnroll" runat="server" >
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
                    <uc1:Student runat="server" id="Student" />
                </td>
            </tr>
        </table>

        <table>
            <tr>
                <th>Institution<span style="color: red">*</span></th>
                <th>Course<span style="color: red">*</span></th>
                <th>Branch<span style="color: red">*</span></th>
                <th>Semester<span style="color: red">*</span></th>
                <th>Remark<span style="color:red">*</span></th>

            </tr>
            <tr>
                <td>
                    <asp:DropDownList ID="ddlInstitution" runat="server" Width="80px" OnSelectedIndexChanged="ddlInstitution_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList>
                </td>
                <td>
                    <asp:DropDownList ID="ddlCourse" runat="server" Width="153px" OnSelectedIndexChanged="ddlCourse_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList>
                </td>

                <td>
                    <asp:DropDownList ID="ddlBranch" runat="server" Width="156px" OnSelectedIndexChanged="ddlBranch_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList>
                </td>
                 <td>
                    <asp:DropDownList ID="ddlSemester" runat="server" Width="60px"></asp:DropDownList>
                </td>
                <td>
                    <asp:TextBox ID="txtRemark" runat="server" >
                                </asp:TextBox>
                </td>
                <td>
                    <asp:Button ID="btnChange" runat="server" Text="Change" Width="60px" OnClick="btnChange_Click"></asp:Button>
                </td>
               
            </tr>
        </table>
    </div>
</asp:Content>

