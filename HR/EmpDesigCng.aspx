<%@ Page Title="ERP | Employee Designation Change" Language="C#" MasterPageFile="~/MasterPages/Short.master" AutoEventWireup="true" CodeFile="EmpDesigCng.aspx.cs" Inherits="HR_EmpDesignationCng" %>

<%@ Register Src="~/Control/Employee.ascx" TagPrefix="uc1" TagName="Employee" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentHolder1" runat="Server">

    <script language="javascript" type="text/javascript">
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
        function CheckControl(ctrl) {
            if (bTrim(document.getElementById(ctrl).value) == "" || bTrim(document.getElementById(ctrl).value) == "Select" || bTrim(document.getElementById(ctrl).value) == ".") {
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
            if (!CheckAutoComplete("<%=txtEmployee.ClientID%>")) {
                msg += " * Enter Name with Code. \n";
                if (ctrl == "")
                    ctrl = "<%=txtEmployee.ClientID%>";
                flag = false;
            }
            if (msg != "") alert(msg);
            if (ctrl != "")
                document.getElementById(ctrl).focus();
            return flag;
        }

        function validate() {
            var flag = true;
            var msg = "", ctrl = "";
            if (!CheckAutoComplete("<%=txtEmployee.ClientID%>")) {
                msg += " * Enter Name with Code. \n";
                if (ctrl == "")
                    ctrl = "<%=txtEmployee.ClientID%>";
                flag = false;
            }
            if (!CheckControl("<%=ddlGrade.ClientID%>")) {
                msg += "- Select Category from the List \n";
                if (ctrl == "")
                    ctrl = "<%=ddlGrade.ClientID%>";
                flag = false;
            }
            if (!CheckControl("<%=ddlDesignation.ClientID%>")) {
                msg += "- Select Designation from the List \n";
                if (ctrl == "")
                    ctrl = "<%=ddlDesignation.ClientID%>";
                flag = false;
            }
            if (!CheckControl("<%=txtFromDate.ClientID%>")) {
                msg += "- Enter From Date \n";
                if (ctrl == "")
                    ctrl = "<%=txtFromDate.ClientID%>";
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
            <h2>Designation Change</h2>
        </div>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <table>
                    <tr>
                        <td align="right">
                            <table style="text-align: left;">

                                <tr>
                                    <td>
                                        <asp:TextBox ID="txtEmployee" runat="server" CssClass="textBox" Width="228px" placeholder="Employee Name or Code"></asp:TextBox>
                                        <ajaxToolkit:AutoCompleteExtender ID="autoComplete1" runat="server" CompletionInterval="500"
                                            CompletionSetCount="12" ContextKey="1" EnableCaching="true" MinimumPrefixLength="1"
                                            ServiceMethod="GetEmployeeList" ServicePath="~\AutoComplete.asmx" TargetControlID="txtEmployee">
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
                        <td style="text-align: left; vertical-align: top;">
                            <table>
                                <tr>

                                    <th>&nbsp;Category<span class="required">*</span></th>
                                    <th>&nbsp;Designation<span class="required">*</span></th>
                                    <th>&nbsp;From Date<span class="required">*</span></th>

                                    <td></td>
                                </tr>
                                <tr>

                                    <td>&nbsp;<asp:DropDownList ID="ddlGrade" runat="server" AutoPostBack="true" Width="150px" Height="28px"
                                        OnSelectedIndexChanged="ddlGrade_SelectedIndexChanged">
                                    </asp:DropDownList>
                                    </td>
                                    <td>&nbsp;<asp:DropDownList ID="ddlDesignation" runat="server" AutoPostBack="true" Height="28px" Width="200px">
                                    </asp:DropDownList>
                                    </td>
                                    <td>&nbsp;<asp:TextBox ID="txtFromDate" runat="server" CssClass="textbox" Width="87px"></asp:TextBox>
                                    </td>

                                    <td>
                                        <asp:Button ID="btnSave" runat="server" CssClass="btnBrown" OnClick="btnSave_Click" Text="Save" Width="50px" />
                                    </td>

                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <div style="height: 400PX; overflow: auto">
                                <asp:GridView ID="GridShow" runat="server" AutoGenerateColumns="False" GridLines="None"
                                    EmptyDataText="No Record Found" DataKeyNames="DES_CNG_ID" CssClass="gridDynamic" Width="97%">
                                    <Columns>
                                        <asp:TemplateField HeaderText="S.No.">
                                            <ItemTemplate>
                                                <%# ((GridViewRow)Container).RowIndex + 1%>
                                                    .
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="EMP_ID" HeaderText="Employee ID" />
                                        <asp:BoundField DataField="EMP_NAME" HeaderText="Employee Name" />
                                        <asp:BoundField DataField="DEPT_VALUE" HeaderText="Department Name" />
                                        <asp:BoundField DataField="DES_VALUE" HeaderText="Designation" />
                                        <asp:BoundField DataField="FRM_DATE" HeaderText="From Date" DataFormatString="{0:dd/MM/yyyy}" />
                                    </Columns>
                                </asp:GridView>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <ajaxToolkit:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" CompletionSetCount="12"
                                EnableCaching="true" MinimumPrefixLength="1" ServiceMethod="GetEmployeeList"
                                ServicePath="~\AutoComplete.asmx" TargetControlID="txtEmployee" ContextKey="1,2">
                            </ajaxToolkit:AutoCompleteExtender>
                            <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd/MM/yyyy"
                                TargetControlID="txtFromDate">
                            </ajaxToolkit:CalendarExtender>
                            <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender1" runat="server" Mask="99/99/9999"
                                MaskType="Date" TargetControlID="txtFromDate">
                            </ajaxToolkit:MaskedEditExtender>
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</asp:Content>

