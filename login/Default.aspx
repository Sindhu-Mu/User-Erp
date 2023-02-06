<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Login_Default" Title="Welcome To University Portal" MasterPageFile="~/MasterPages/Login.master" %>

<asp:Content runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <script lang="javascript" type="text/javascript">
        function CheckControl(ctrl) {
            if (bTrim(document.getElementById(ctrl).value) == "" || bTrim(document.getElementById(ctrl).value) == ".") {
                document.getElementById(ctrl).style.backgroundColor = "skyblue";
                return false;
            }

            return true;
        }
        function validation() {

            var flag = true;
            var msg = "", ctrl = "";
            if (!CheckControl("<%=txtLoginId.ClientID%>")) {
                msg += " * Enter your Login id.\n";
                if (ctrl == "")
                    ctrl = "<%=txtLoginId.ClientID%>";
                flag = false;
            }
            if (!CheckControl("<%=txtPassword.ClientID%>")) {
                msg += " * Enter your password.\n";
                if (ctrl == "")
                    ctrl = "<%=txtPassword.ClientID%>";
                flag = false;
            }
            if (msg != "") alert(msg);
            if (ctrl != "")
                document.getElementById(ctrl).focus();
            return flag;
        }
    </script>



    <div id="login">
        <h1>Welcome!</h1>

        <div class="field-wrap">
            <label>
                Login Id<span class="req">*</span>
            </label>
            <asp:TextBox ID="txtLoginId" runat="server"></asp:TextBox>
        </div>
        <div class="field-wrap">
            <label>
                Password<span class="req">*</span>
            </label>
            <asp:TextBox ID="txtPassword" TextMode="Password" runat="server"></asp:TextBox>

        </div>
        <p class="forgot"><a href="ForgotPassword.aspx">Can't access your portal account?</a></p>
        <div id="TD1" runat="server" visible="false" style="min-height: 20px; color: #f00;">
            Invalid Login-Id or Password                           
        </div>

        <div>&nbsp;</div>
       
        <div>
            <asp:Button ID="btnLogin" runat="server" CssClass="button button-block" Text="Sign In" OnClick="btnLogin_Click" />
        </div>
          <div>&nbsp;</div>
          <div>
           <u><a href="../../GrievancePortal/EmployeeGrievance.aspx">Employee Grievance Portal</a><img src="../siteimages/new-gif-image-6.gif" width="50" height="20" alt="" /></u>
        </div>


    </div>

</asp:Content>
