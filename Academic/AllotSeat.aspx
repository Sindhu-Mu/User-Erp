<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/MainPage.master" AutoEventWireup="true" CodeFile="AllotSeat.aspx.cs" Inherits="Academic_AllotSeat" %>

<%@ Register Src="~/Control/Student.ascx" TagPrefix="uc1" TagName="Student" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script language="javascript" type="text/javascript">
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
            if (!CheckControl("<%=txtEnroll.ClientID%>")) {
                msg += " * Enter Enrollment No.\n";
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
            <h2>Allot Seat & Print Admit Card
            </h2>
        </div>
        <div>
            <table>
                <tr>
                    <td style="text-align: right;">
                        <asp:TextBox ID="txtEnroll" runat="server" Width="137px"></asp:TextBox>
                        &nbsp;<asp:Button ID="btnShow" runat="server" Text="Show" OnClick="btnShow_Click" />
                        &nbsp;<asp:Button ID="btnAllot" runat="server" Text="Allot & Print" OnClick="btnAllot_Click" />
                    </td>
                </tr>
                <tr>
                    <td colspan="3">
                        <uc1:Student runat="server" ID="Student" />
                    </td>
                </tr>
                <tr><td>
                    <asp:Label ID="lblMsg" runat="server" ForeColor="Red"></asp:Label></td></tr>
            </table>
        </div>
    </div>
</asp:Content>

