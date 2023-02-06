<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Short.master" AutoEventWireup="true" CodeFile="Pwd_Reset.aspx.cs" Inherits="HR_Pwd_Reset" %>

<%@ Register Src="~/Control/Employee.ascx" TagPrefix="uc1" TagName="Employee" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentHolder1" runat="Server">
    <script language="javascript" type="text/javascript">
       
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
        function validat() {

            var flag = true;
            var msg = "", ctrl = "";
            if (!CheckAutoComplete("<%=txtEmp.ClientID%>")) {
                msg += "- Enter Employee Name & Code\n";
                if (ctrl == "")
                    ctrl = "<%=txtEmp.ClientID%>";
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
            <h2>Reset Password</h2>
        </div>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <div style="float: right;">
                    <table>
                        <tr>
                            <th >Employee</th>
                            <td >
                                <asp:TextBox ID="txtEmp" runat="server" Width="200px"></asp:TextBox>
                                <ajaxToolkit:AutoCompleteExtender ID="AutoCompleteExtender2" runat="server" CompletionInterval="500"
                                    CompletionSetCount="12" ContextKey="1" EnableCaching="true" MinimumPrefixLength="1"
                                    ServiceMethod="GetEmployeeList" ServicePath="~\AutoComplete.asmx" TargetControlID="txtEmp">
                                </ajaxToolkit:AutoCompleteExtender>
                            </td>
                            <td >
                                <asp:Button ID="btnShow" runat="server" Text="Show" OnClick="btnShow_Click" /></td>
                        </tr>
                    </table>
                </div>
                <div class="cleaner"></div>
                <div>
                    <uc1:Employee runat="server" ID="Employee" />
                </div>
                   <div class="cleaner">&nbsp;</div>
                
                <div  style="float: right;">
                    <asp:Button ID="btnReset" runat="server" Text="Reset Password" OnClick="btnReset_Click" />
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</asp:Content>

