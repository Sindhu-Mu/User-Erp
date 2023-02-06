<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Short.master" AutoEventWireup="true" CodeFile="EmpDeptCng.aspx.cs" Inherits="HR_EmpDepartmentCng" %>

<%@ Register Src="~/Control/Employee.ascx" TagPrefix="uc1" TagName="Employee" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentHolder1" runat="server">
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
        function validat() {
            var flag = true;
            var msg = "", ctrl = "";
            if (!CheckAutoComplete("<%=txtName.ClientID%>")) {
                msg += " * Enter Name with Code. \n";
                if (ctrl == "")
                    ctrl = "<%=txtName.ClientID%>";
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
            if (!CheckAutoComplete("<%=txtName.ClientID%>")) {
                msg += " * Enter Name with Code. \n";
                if (ctrl == "")
                    ctrl = "<%=txtName.ClientID%>";
                flag = false;
            }
            if (!CheckControl("<%=ddlDeptName.ClientID%>")) {
                msg += " * Select Department from list. \n";
                if (ctrl == "")
                    ctrl = "<%=ddlDeptName.ClientID%>";
                flag = false;
            }

            if (CheckControl("<%=txtDate.ClientID%>")) {
                if (!CheckDate("<%=txtDate.ClientID%>")) {
                    msg += "* Enter date in currect format.[dd/MM/yyyy]\n";
                    if (ctrl == "")
                        ctrl = "<%=txtDate.ClientID%>";
                    flag = false;
                }
            }
            else {
                msg += "* Enter effective from date\n";
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
            <h2>Department Transfer</h2>
        </div>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <table>
                    <tr>
                        <td align="right">
                            <table style="text-align: left;">

                                <tr>
                                    <td>
                                        <asp:TextBox ID="txtName" runat="server" CssClass="textBox" Width="228px" placeholder="Employee Name or Code"></asp:TextBox>
                                        <ajaxToolkit:AutoCompleteExtender ID="autoComplete1" runat="server" CompletionInterval="500"
                                            CompletionSetCount="12" ContextKey="1" EnableCaching="true" MinimumPrefixLength="1"
                                            ServiceMethod="GetEmployeeList" ServicePath="~\AutoComplete.asmx" TargetControlID="txtName">
                                        </ajaxToolkit:AutoCompleteExtender>
                                    </td>
                                    <td>
                                        <asp:Button ID="btnShow" runat="server" Text="Show" OnClick="btnShow_Click" />
                                    </td>
                                </tr>

                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <uc1:Employee ID="Employee" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: right;">
                            <table style="text-align: left;">
                                <tr>
                                    <th>Department<span class="required">*</span></th>
                                    <td>&nbsp;</td>
                                    <th>Effective From<span class="required">*</span></th>
                                    <td>&nbsp;</td>
                                    <th>Remark</th>
                                    <td>&nbsp;</td>
                                    <td></td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:DropDownList ID="ddlDeptName" runat="server" Width="170px">
                                        </asp:DropDownList>
                                    </td>
                                    <td>&nbsp;</td>
                                    <td>
                                        <asp:TextBox ID="txtDate" runat="server" CssClass="textBox" Width="98px"></asp:TextBox></td>
                                    <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd/MM/yyyy"
                                        TargetControlID="txtDate">
                                    </ajaxToolkit:CalendarExtender>
                                    <td>&nbsp;</td>
                                    <td>
                                        <asp:TextBox ID="txtRemark" runat="server" Width="318px"></asp:TextBox></td>
                                    <td>&nbsp;</td>
                                    <td>
                                        <asp:Button ID="btnSave" runat="server" OnClick="btnSave_Click" Text="Save" /></td>
                                </tr>

                            </table>

                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:GridView ID="GVTransfer" runat="server" AutoGenerateColumns="False" DataKeyNames="DEPT_CNG_ID"
                                EmptyDataText="No Record Found" Width="100%" CssClass="gridDynamic">
                                <Columns>
                                    <asp:TemplateField HeaderText="S.No.">
                                        <ItemTemplate>
                                            <%# ((GridViewRow)Container).RowIndex + 1%>                                .
                                        </ItemTemplate>
                                        <ItemStyle Width="10px" />
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="Emp_Id" HeaderText="Emp.Code" />
                                    <asp:BoundField DataField="EMP_NAME" HeaderText="Employee Name" ReadOnly="True" />
                                    <asp:BoundField DataField="DEPT_VALUE" HeaderText="Department" />
                                    <asp:BoundField DataField="FRM_DATE" HeaderText="From" DataFormatString="{0:dd/MM/yyyy}" />
                                    <asp:BoundField DataField="TO_DATE" HeaderText="To" DataFormatString="{0:dd/MM/yyyy}" />
                                    <asp:BoundField DataField="CNG_BY" HeaderText="Insert By" />
                                </Columns>
                            </asp:GridView>
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</asp:Content>

