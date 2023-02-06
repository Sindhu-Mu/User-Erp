<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Login.master" AutoEventWireup="true" CodeFile="GuestUserMain.aspx.cs" Inherits="login_GuestUserMain" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script language="javascript" type="text/javascript">

        function RestrictChar(e) {
            //get the keycode when the user pressed any key in application 
            var exp = String.fromCharCode(window.event.keyCode)
            //Below line will have the special characters that is not allowed you can add if you want more for some characters you need to add escape sequence 
            var r = new RegExp("[-_,/'().0-9a-zA-Z \r]", "g");
            if (exp.match(r) == null) {
                window.event.keyCode = 0
                return false;
            }
            var keynum;
            var keychar
            if (window.event) {
                keynum = e.keyCode
            }
            else if (e.which) {
                keynum = e.which
            }
            keychar = String.fromCharCode(keynum)
            //List of special characters you want to restrict   
            if (keychar == "'" || keychar == "(" || keychar == ")" || keychar == "-" || keychar == "," || keychar == "." || keychar == "/") {
                return false;
            }
            else {
                return true;
            }
            //            else {
            //                return isAlphaNumeric(window.event.keyCode);
            //            }
        }
        function isAlphaNumeric(keyCode) {
            return (((keyCode >= 48 && keyCode <= 57) && isShift == false) ||
               (keyCode >= 65 && keyCode <= 90) || keyCode == 8 ||
               (keyCode >= 96 && keyCode <= 105) || keychar == "'")
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
        function validation() {
            var flag = true;
            var msg = "", ctrl = "";

            if (!CheckControl("<%=txtName.ClientID%>")) {
                msg += " * Enter Name \n";
                if (ctrl == "")
                    ctrl = "<%=txtName.ClientID%>";
                flag = false;
            }
            if (!CheckControl("<%=txtContact.ClientID%>")) {
                msg += " * Enter Contact  \n";
                if (ctrl == "")
                    ctrl = "<%=txtContact.ClientID%>";
                flag = false;
            }
            if (!CheckControl("<%=txtPurpose.ClientID%>")) {
                msg += " * Enter Purpose \n";
                if (ctrl == "")
                    ctrl = "<%=txtPurpose.ClientID%>";
                flag = false;
            }
            if (!CheckControl("<%=ddlDept.ClientID%>")) {
                msg += " * Select Department \n";
                if (ctrl == "")
                    ctrl = "<%=ddlDept.ClientID%>";
                flag = false;
            }
            if (msg != "") alert(msg);
            if (ctrl != "")
                document.getElementById(ctrl).focus();
            return flag;
        }
    </script>
    <div>
        <div class="heading">
            <h2>GUEST VISIT INFORMATION</h2>
        </div>
        <table>
            <tr>
                <th>Name</th>
                <th>Mail ID</th>
                <th>Mail Domain</th>
                <th>Contact No</th>
                <th>Purpose</th>
            </tr>
            <tr>
                <td>
                    <asp:TextBox ID="txtName" runat="server"></asp:TextBox></td>
                <td>
                    <asp:TextBox ID="txtMail" runat="server" onkeypress="return RestrictChar(event);"></asp:TextBox></td>
                <td>
                    <asp:DropDownList ID="ddlDomain" runat="server" AutoPostBack="true"></asp:DropDownList></td>
                <td>
                    <cc1:NumericTextBox ID="txtContact" runat="server" MaxLength="10"></cc1:NumericTextBox>
                </td>
                <td>
                    <asp:TextBox ID="txtPurpose" runat="server"></asp:TextBox></td>
                <td>
                    <asp:DropDownList ID="ddlDept" runat="server" AutoPostBack="true"></asp:DropDownList></td>
                <td>
                    <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" /></td>
            </tr>
        </table>
    </div>
</asp:Content>

