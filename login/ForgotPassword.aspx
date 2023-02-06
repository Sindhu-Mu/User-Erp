<%@ Page Language="C#" AutoEventWireup="true" Title="Employee Portal | Forget Password" CodeFile="ForgotPassword.aspx.cs" Inherits="Common_ForgotPassword" MasterPageFile="~/MasterPages/Login.master" %>


<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <script lang="javascript" type="text/javascript">
        function CheckControl(ctrl) {
            if (bTrim(document.getElementById(ctrl).value) == "" || bTrim(document.getElementById(ctrl).value) == "." || bTrim(document.getElementById(ctrl).value) == "Select") {
                document.getElementById(ctrl).style.backgroundColor = "skyblue";
                return false;
            }

            return true;
        }

        function Passvalidate() {
            var flag = true;
            var msg = "", ctrl = "";
            if (!CheckControl("<%=txtEmployee.ClientID%>")) {
                msg += "- Enter login id \n";
                if (ctrl == "")
                    ctrl = "<%=txtEmployee.ClientID%>";
                flag = false;
            }
            if (!CheckControl("<%=txtMobileNo.ClientID%>")) {
                msg += "- Enter Mobile no. \n";
                if (ctrl == "")
                    ctrl = "<%=txtMobileNo.ClientID%>";
                flag = false;
            }
            if (!CheckControl("<%=txtEmail.ClientID%>")) {
                msg += "- Enter Official mail-id.\n";
                if (ctrl == "")
                    ctrl = "<%=txtEmail.ClientID%>";
                flag = false;
            }
            if (msg != "") alert(msg);
            if (ctrl != "")
                document.getElementById(ctrl).focus();
            return flag;
        }
    </script>
    <div id="login">

        <div>
            <h1>Reset your password</h1>
        </div>
        <div class="field-wrap">
            <label for="txtEmployee">
                Login Id<span class="req">*</span>
            </label>
            <asp:TextBox ID="txtEmployee" runat="server"></asp:TextBox>
        </div>
        <div class="field-wrap">
            <label>
                Mobile No<span class="req">*</span>
            </label>
            <asp:TextBox ID="txtMobileNo" runat="server"></asp:TextBox>
        </div>
        <div class="field-wrap">
            <label>
                Official Email-Id<span class="req">*</span>
            </label>
            <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
        </div>
        <p class="forgot"><a href="Default.aspx">Click here for sign-in again!!</a></p>
        <div>
            <asp:Button ID="btnVerify" runat="server" Text="Reset Password" OnClick="btnVerify_Click" CssClass="button button-block" />
        </div>


    </div>

</asp:Content>
