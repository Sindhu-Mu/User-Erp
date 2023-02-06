<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/FullLength.master" AutoEventWireup="true" CodeFile="StuFeeChalan.aspx.cs" Inherits="Academic_StuFeeChalan" %>

<%@ Register Src="~/Control/Student.ascx" TagPrefix="uc1" TagName="Student" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
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
        function validation() {
            var flag = true;
            var msg = "", ctrl = "";
            if (!CheckAutoComplete("<%=txtEnroll.ClientID%>")) {
                msg += " * Enter Name with Enrollment. \n";
                if (ctrl == "")
                    ctrl = "<%=txtEnroll.ClientID%>";
                flag = false;
            }
            if (!CheckControl("<%=ddlType.ClientID%>")) {
                 msg += "- Select print document.\n";
                 if (ctrl == "")
                     ctrl = "<%=ddlType.ClientID%>";
                    flag = false;
                }
                if (!CheckControl("<%=ddlSem.ClientID%>")) {
                msg += "- Select semester .\n";
                if (ctrl == "")
                    ctrl = "<%=ddlSem.ClientID%>";
                    flag = false;
                }
                if (!CheckControl("<%=ddlFeeAccount.ClientID%>")) {
                msg += "- Select Account Name.\n";
                if (ctrl == "")
                    ctrl = "<%=ddlFeeAccount.ClientID%>";
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
            <h2>Print Challan</h2>
        </div>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <table>
                    <tr>
                        <td>
                            <table>
                                <tr>
                                    <th>Enrollment No<span class="required">*</span></th>
                                    <td><asp:TextBox ID="txtEnroll" runat="server" Width="250px"></asp:TextBox></td>
                                    <td>
                                        <asp:Button ID="btnShow" runat="server" Text="Show" OnClick="btnShow_Click" /></td>
                                </tr>
                                </table>
                            <table>
                                <tr>
                                    <td>
                                         <uc1:Student ID="Student" runat="server" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <ajaxToolkit:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" CompletionInterval="500"
        CompletionSetCount="12" ContextKey="1" EnableCaching="true" MinimumPrefixLength="1"
        ServiceMethod="GetStudentList" ServicePath="~\AutoComplete.asmx" TargetControlID="txtEnroll">
    </ajaxToolkit:AutoCompleteExtender>
                                    </td>
                                </tr>
                            </table>
                            <table>
                                <tr>
                                  <th>Print type <span class="required">*</span></th>
                            <th>Semester <span class="required">*</span></th>
                            <th>Transferred to Account<span class="required">*</span></th>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:DropDownList ID="ddlType" runat="server">
                                            <asp:ListItem Value=".">Select</asp:ListItem>
                                            <asp:ListItem Value="1">Fee Challan</asp:ListItem>
                                            <asp:ListItem Value="2">Transport Challan</asp:ListItem>
                                            <asp:ListItem Value="3">Demand Letter</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                    <td><asp:DropDownList ID="ddlSem" runat="server"></asp:DropDownList></td>
                                
                                     <td>
                                <asp:DropDownList ID="ddlFeeAccount" runat="server">
                                      <asp:ListItem Text="Select" Value="."></asp:ListItem>
                                    <asp:ListItem Value="1" >F.O. MANGALAYATAN UNIVERSITY</asp:ListItem>
                                    <asp:ListItem Value="5" >HDFC MANGALAYATAN UNIVERSITY </asp:ListItem>
                                    <asp:ListItem Value="6" >YES MANGALAYATAN UNIVERSITY </asp:ListItem>
                                </asp:DropDownList>
                            </td>
                                        <td><asp:Button ID="btnPrint" runat="server" Text="Print Challan" OnClick="btnPrint_Click" /></td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</asp:Content>

