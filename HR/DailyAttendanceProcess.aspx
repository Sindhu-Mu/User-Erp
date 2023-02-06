<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Short.master" AutoEventWireup="true" CodeFile="DailyAttendanceProcess.aspx.cs" Inherits="HR_AttendanceProcess" %>

<%@ Register Src="../Control/MonthYear.ascx" TagName="MonthYear" TagPrefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentHolder1" runat="Server">
    <script type="text/ecmascript" language="javascript">

        function CheckControl(ctrl) {
            if (bTrim(document.getElementById(ctrl).value) == "" || bTrim(document.getElementById(ctrl).value) == "Select" || bTrim(document.getElementById(ctrl).value) == ".") {
                document.getElementById(ctrl).style.backgroundColor = "#fc6";
                return false;
            }
            else
                document.getElementById(ctrl).style.backgroundColor = "#fff";
            return true;
        }
        function CheckDate(ctrl) {
            var dt = document.getElementById(ctrl).value;
            if (!isDatecheck(dt, "dd/MM/yyyy")) {
                document.getElementById(ctrl).style.backgroundColor = "#fc6";
                return false;
            }
            else
                document.getElementById(ctrl).style.backgroundColor = "#fff";
            return true;
        }
        function valid() {
            var flag = true;
            var msg = "", ctrl = "";


            if (!CheckControl("<%=txtTodayDate.ClientID%>")) {
                msg += "- Enter date.\n";
                if (ctrl == "")
                    ctrl = "<%=txtTodayDate.ClientID%>";
                flag = false;
            }
            if (!CheckDate("<%=txtTodayDate.ClientID%>")) {
                msg += " * date format is wrong \n";
                if (ctrl == "")
                    ctrl = "<%=txtTodayDate.ClientID%>";
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
            <h2>Daily Attendance Process</h2>
        </div>
        <div>

            <table>
                <tr>
                    <th>Date:
                    </th>
                    <td>
                        <asp:TextBox ID="txtTodayDate" runat="server"></asp:TextBox>
                        <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtTodayDate" Format="dd/MM/yyyy">
                        </ajaxToolkit:CalendarExtender>
                        </td>
                    <td>
                        <asp:Button ID="btnUpload" Text="Upload" runat="server" Visible="true" OnClick="btnUpload_Click" />
                    </td>
                </tr>
            </table>
        </div>
    </div>
</asp:Content>

