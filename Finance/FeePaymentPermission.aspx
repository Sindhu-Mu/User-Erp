<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/FullLength.master" AutoEventWireup="true" CodeFile="FeePaymentPermission.aspx.cs" Inherits="Finance_FeePaymentPermission" %>

<%@ Register Src="~/Control/Student.ascx" TagPrefix="uc1" TagName="Student" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script lang="javascript" type="text/javascript">
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

            if (!CheckControl("<%=ddlGroupHead.ClientID%>")) {
                msg += "- Please Select Group Head\n";
                if (ctrl == "")
                    ctrl = "<%=ddlGroupHead.ClientID%>";
                flag = false;
            }

            if (!CheckControl("<%=ddlHead.ClientID%>")) {
                msg += "- Please Select Head \n";
                if (ctrl == "")
                    ctrl = "<%=ddlHead.ClientID%>";
                flag = false;
            }

            if (!CheckControl("<%=txtValue.ClientID%>")) {
                msg += "- Please Enter Deduction Amount \n";
                if (ctrl == "")
                    ctrl = "<%=txtValue.ClientID%>";
                flag = false;
            }

            if (!CheckControl("<%=txtApproveBy.ClientID%>")) {
                msg += "- Please Enter Approve By \n";
                if (ctrl == "")
                    ctrl = "<%=txtApproveBy.ClientID%>";
                flag = false;
            }

            if (!CheckControl("<%=txtRemark.ClientID%>")) {
                msg += "- Please Enter Remark \n";
                if (ctrl == "")
                    ctrl = "<%=txtRemark.ClientID%>";
                flag = false;
            }


            if (CheckControl("<%=txtDepositDate.ClientID%>")) {
                if (!CheckDate("<%=txtDepositDate.ClientID%>")) {
                    msg += "- Invalid Format of Date.Please Enter in this[dd/MM/yyyy]\n";
                    if (ctrl == "")
                        ctrl = "<%=txtDepositDate.ClientID%>";
                    flag = false;
                }
            }
            else {
                msg += "- Enter Date\n";
                if (ctrl == "")
                    ctrl = "<%=txtDepositDate.ClientID%>";
                flag = false;
            }
            if (msg != "") alert(msg);
            if (ctrl != "")
                document.getElementById(ctrl).focus();
            return flag;
        }

        function validation1() {

            var flag = true;
            var msg = "", ctrl = "";

            if (!CheckControl("<%=ddlSem.ClientID%>")) {
                msg += "- Please Select Sem \n";
                if (ctrl == "")
                    ctrl = "<%=ddlSem.ClientID%>";
                flag = false;
            }

            if (!CheckControl("<%=txtEnrollment.ClientID%>")) {
                msg += "- Please Enter Enrollment \n";
                if (ctrl == "")
                    ctrl = "<%=txtEnrollment.ClientID%>";
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
            <h2>
                <!-- Page Heading-->
                Fee Permission
            </h2>

        </div>

        <div id="cBody">
            <div id="cHead">
                <table style="float: right;">
                    <tr>
                        <td>Branch</td>
                        <td>Semester</td>
                        <td>Enrollment</td>
                    </tr>
                    <!-- Content  Header ex: Filters-->
                    <tr>
                        <td>
                            <asp:DropDownList ID="ddlBranch" runat="server"></asp:DropDownList></td>
                        <td>
                            <asp:DropDownList ID="ddlSem" runat="server"></asp:DropDownList></td>
                        <td>
                            <asp:TextBox ID="txtEnrollment" runat="server" Width="250px"></asp:TextBox></td>
                        <td>
                            <asp:Button ID="btnShow" runat="server" Text="Show" OnClick="btnShow_Click" /></td>
                    </tr>
                </table>
                <div class="cleaner"></div>
            </div>
            <div id="cCenter">
                <!-- Content Header ex: Grids-->

                <uc1:Student runat="server" ID="Student" />
                <br />
                <asp:GridView ID="gvData" runat="server" AutoGenerateColumns="False" Width="100%"
                    DataKeyNames="FEE_MAIN_HEAD_ID" ShowFooter="True" CssClass="gridDynamic">
                    <Columns>

                        <asp:TemplateField HeaderText="S.No." ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <%#Container.DataItemIndex+1%>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField HeaderText="Head Name" DataField="FEE_MAIN_HEAD_NAME" />
                        <asp:BoundField HeaderText="Demand Amount" DataField="FD_FEE_AMT" />
                        <asp:BoundField HeaderText="Balance Amount" DataField="FD_BALANCE_AMT" />

                    </Columns>
                    <HeaderStyle ForeColor="#CC0000" />
                </asp:GridView>
                <table>
                    <tr>
                        <td>Group Head</td>
                        <td>Head</td>
                        <td>Permitted Amount</td>
                    </tr>
                    <tr>
                        <td>
                            <asp:DropDownList ID="ddlGroupHead" runat="server" OnSelectedIndexChanged="ddlGroupHead_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList></td>
                        <td>
                            <asp:DropDownList runat="server" ID="ddlHead" OnSelectedIndexChanged="ddlHead_SelectedIndexChanged"></asp:DropDownList></td>
                        <td>
                            <asp:TextBox runat="server" ID="txtValue"></asp:TextBox></td>
                        <td>
                            <asp:DropDownList ID="ddlType" runat="server" OnSelectedIndexChanged="ddlHead_SelectedIndexChanged" AutoPostBack="true">
                                <asp:ListItem Value="-1">Select</asp:ListItem>
                                <asp:ListItem Value="0">Value</asp:ListItem>
                                <asp:ListItem Value="1">Percentage</asp:ListItem>
                            </asp:DropDownList></td>
                        <td>
                            <asp:TextBox runat="server" ID="txtAmount" Enabled="false"></asp:TextBox></td>

                    </tr>

                </table>
                <hr />
            </div>
            <div id="cFooter">
                <!-- Content Header ex:Buttons-->
                <br />
                <table>
                    <tr>
                        <td>Approve By</td>
                        <td>Deposit Date</td>
                        <td>Remark</td>

                    </tr>
                    <tr>
                        <td>
                            <asp:TextBox ID="txtDepositDate" runat="server"></asp:TextBox>
                            <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtDepositDate" Format="MM/dd/yyyy">
                            </ajaxToolkit:CalendarExtender>
                        </td>
                        <td>
                            <asp:TextBox ID="txtApproveBy" runat="server"></asp:TextBox></td>
                        <td>
                            <asp:TextBox ID="txtRemark" runat="server"></asp:TextBox></td>
                        <td>
                            <asp:Button ID="btnInsert" runat="server" Text="INSERT" OnClick="btnInsert_Click" /><br />
                        </td>
                    </tr>
                </table>

            </div>
        </div>
    </div>
</asp:Content>

