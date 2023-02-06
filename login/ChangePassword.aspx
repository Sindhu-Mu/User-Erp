<%@ Page Language="C#" MasterPageFile="~/MasterPages/FullLength.master" AutoEventWireup="true" Title="Employee Portal |Change Password" CodeFile="ChangePassword.aspx.cs" Inherits="login_ChangePassword" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script lang="javascript" type="text/javascript">
        function CheckControl(ctrl) {
            if (bTrim(document.getElementById(ctrl).value) == "" || bTrim(document.getElementById(ctrl).value) == "." || bTrim(document.getElementById(ctrl).value) == "Select") {
                document.getElementById(ctrl).style.backgroundColor = "#fc6";
                return false;
            }
            else
                document.getElementById(ctrl).style.backgroundColor = "#fff";
            return true;
        }

        function Passvalidate() {
            var flag = true;
            var msg = "", ctrl = "";
            if (!CheckControl("<%=txtOldPassword.ClientID%>")) {
                msg += "- Enter Old Password \n";
                if (ctrl == "")
                    ctrl = "<%=txtOldPassword.ClientID%>";
                flag = false;
            }
            if (!CheckControl("<%=txtNewPassword.ClientID%>")) {
                msg += "- Enter new password. \n";
                if (ctrl == "")
                    ctrl = "<%=txtNewPassword.ClientID%>";
                flag = false;
            }
            if (!CheckControl("<%=txtConPwd.ClientID%>")) {
                msg += "- Enter confirm password.\n";
                if (ctrl == "")
                    ctrl = "<%=txtConPwd.ClientID%>";
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
            <h2>Change Password</h2>
        </div>
        <asp:UpdatePanel ID="UpdatePanel11" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <table style="width:70%;">
                
                    <tr>
                        <th>Current Password</th>
                        <td>:</td>
                        <td>
                            <asp:TextBox ID="txtOldPassword" CssClass="form-control" runat="server" TextMode="Password"></asp:TextBox></td>
                    </tr>

                    <tr>
                        <th>New Password</th>
                        <td>:</td>
                        <td>
                            <asp:TextBox ID="txtNewPassword" CssClass="form-control" runat="server" TextMode="Password"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <th>Confirm Password</th>
                        <td>:</td>
                        <td>
                            <asp:TextBox ID="txtConPwd" runat="server" CssClass="form-control"></asp:TextBox></td>
                    </tr>
                    <tr> <td>&nbsp;</td></tr>
                    <tr> <td>&nbsp;</td>
                        <td>&nbsp;</td>
                        <td>
                            <asp:Button ID="btnChange" runat="server" Text="Change"  OnClick="btnChange_Click"/>
                             <asp:Button ID="btnRefresh" runat="server" Text="Refresh"  OnClick="btnRefresh_Click"/>
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>

</asp:Content>
