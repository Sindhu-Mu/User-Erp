<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/FullLength.master" AutoEventWireup="true" CodeFile="StuSemReReg.aspx.cs" Inherits="Academic_StuSemReReg" %>

<%@ Register Src="~/Control/Student.ascx" TagPrefix="uc1" TagName="Student" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script lang="javascript" type="text/javascript">
        function CheckControl(ctrl) {
            if (bTrim(document.getElementById(ctrl).value) == "" || bTrim(document.getElementById(ctrl).value) == "Select" || bTrim(document.getElementById(ctrl).value) == ".") {
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
            if (!CheckControl("<%=txtDate.ClientID%>")) {
                msg += "- Enter payment date\n";
                if (ctrl == "")
                    ctrl = "<%=txtDate.ClientID%>";
                 flag = false;
             }
             if (!CheckControl("<%=ddlAuth.ClientID%>")) {
                msg += "- Select Sanction Authority from list.\n";
                if (ctrl == "")
                    ctrl = "<%=txtDate.ClientID%>";
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
            <h2>Student Semester Re-Registration</h2>
        </div>
        <div>
            <table>
                <tr>
                    <td style="padding-left: 400px">
                        <table>
                            <tr>

                                <td>
                                    <asp:TextBox ID="txtEnroll" runat="server" Width="264px" placeholder="Enter Enrollment No or Roll No or Name"> </asp:TextBox>
                                </td>
                                <td>
                                    <asp:Button ID="btnShow" runat="server" Text="Show" Width="60px" OnClick="btnShow_Click"></asp:Button>
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
                <tr>
                    <td>
                        <table>
                            <tr>
                                <th>Due Amount</th>
                                <th>Account Remarks</th>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblDue" runat="server" Style="font-weight: 700"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblRemark" runat="server" Style="font-weight: 700"></asp:Label></td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr id="trDue" runat="server">
                    <td>
                        <table>
                            <tr>
                                <th>Payment&nbsp; Date <span class="required">*</span>
                                </th>
                                <td>
                                    <asp:TextBox ID="txtDate" runat="server"></asp:TextBox>
                                    <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtDate" Format="dd/MM/yyyy">
                                    </ajaxToolkit:CalendarExtender>
                                    <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender1" runat="server" Mask="99/99/9999" MaskType="Date"
                                        TargetControlID="txtDate">
                                    </ajaxToolkit:MaskedEditExtender>
                                </td>
                            </tr>
                            <tr>
                                <th>Authorized By</th>
                                <td>
                                    <asp:DropDownList ID="ddlAuth" runat="server">
                                        <asp:ListItem>Select</asp:ListItem>
                                         <asp:ListItem>Clear from Account Section</asp:ListItem>
                                        <asp:ListItem>VC</asp:ListItem>
                                        <asp:ListItem>Registrar</asp:ListItem>
                                        <asp:ListItem>PVC</asp:ListItem>
                                        <asp:ListItem>COE</asp:ListItem>
                                        <asp:ListItem>HOI</asp:ListItem>
                                        <asp:ListItem>HOD</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <th>Remark:</th>
                                <td>
                                    <asp:TextBox ID="txtRemark" runat="server"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <th>Application Copy:</th>
                                <td>
                                    <input type="file" id="flApp" runat="server" />
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td>
                        <table>

                            <tr>
                                <td>
                                    <asp:TextBox ID="TextBox1" Visible="false" runat="server"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:Button ID="btnRegister" runat="server" Text="Register" OnClick="btnRegister_Click" />
                                    <asp:Button ID="btnTempReg" runat="server" Text="Temporory Register" OnClick="btnTempReg_Click" />
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </div>
    </div>
</asp:Content>

