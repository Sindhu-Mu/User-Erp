<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Short.master" AutoEventWireup="true" CodeFile="EmpShiftCng.aspx.cs" Inherits="HR_AttendanceShiftChange" %>

<%@ Register Src="~/Control/Employee.ascx" TagPrefix="uc1" TagName="Employee" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentHolder1" runat="Server">
    <script language="javascript" type="text/javascript">
        function CheckControl(ctrl) {
            if (bTrim(document.getElementById(ctrl).value) == "" || bTrim(document.getElementById(ctrl).value) == ".") {
                document.getElementById(ctrl).style.backgroundColor = "#fc6";
                return false;
            }
            else
                document.getElementById(ctrl).style.backgroundColor = "#fff";
            return true;
        } function CheckControl(ctrl) {
            if (bTrim(document.getElementById(ctrl).value) == "" || bTrim(document.getElementById(ctrl).value) == "Select" || bTrim(document.getElementById(ctrl).value) == ".") {
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
        function validation() {
            var flag = true;
            var msg = "", ctrl = "";
            if (!CheckAutoComplete("<%=txtEmp.ClientID%>")) {
                msg += " * Enter Name \n";
                if (ctrl == "")
                    ctrl = "<%=txtEmp.ClientID%>";
                flag = false;
            }
            if (!CheckControl("<%=txtFromDt.ClientID%>")) {
                msg += " * Enter Date \n";
                if (ctrl == "")
                    ctrl = "<%=txtFromDt.ClientID%>";
                flag = false;
            }
            if (!CheckControl("<%=ddlShift.ClientID%>")) {
                msg += " * Select Shift \n";
                if (ctrl == "")
                    ctrl = "<%=ddlShift.ClientID%>";
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
            <h2>ATTENDANCE SHIFT</h2>
        </div>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <ajaxToolkit:TabContainer ID="step1" runat="server" ActiveTabIndex="0" AutoPostBack="true" OnActiveTabChanged="step1_ActiveTabChanged">
                    <ajaxToolkit:TabPanel runat="server" HeaderText="Shift Entry" ID="TabPanel1">
                        <ContentTemplate>
                            <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                <ContentTemplate>
                                    <table>
                                        <tr>
                                            <td></td>
                                            <th>Employee<span class="required">*</span></th>
                                            <td>
                                                <asp:TextBox ID="txtEmp" runat="server" Width="250px"></asp:TextBox>
                                                <ajaxToolkit:AutoCompleteExtender ID="autoComplete1" runat="server" CompletionInterval="500"
                                                    CompletionSetCount="12" ContextKey="1" EnableCaching="true" MinimumPrefixLength="1"
                                                    ServiceMethod="GetEmployeeList" ServicePath="~\AutoComplete.asmx" TargetControlID="txtEmp">
                                                </ajaxToolkit:AutoCompleteExtender>
                                            </td>
                                            <td>
                                                <asp:Button ID="btnView" runat="server" Text="View" OnClick="btnView_Click" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="4">
                                                <uc1:Employee ID="Employee" runat="server" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="4">
                                                <table>
                                                    <tr>
                                                        <th>Shift <span class="required">*</span></th>
                                                        <th>From Date<span class="required">*</span></th>
                                                        <th>Remark<span class="required">*</span></th>

                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:DropDownList ID="ddlShift" runat="server" AutoPostBack="true" Width="157px"></asp:DropDownList></td>
                                                        <td>
                                                            <asp:TextBox ID="txtFromDt" runat="server"></asp:TextBox></td>
                                                        <td>
                                                            <asp:TextBox ID="txtRemark" runat="server"></asp:TextBox>
                                                        </td>
                                                        <td>
                                                            <asp:Button ID="btnSave" runat="server" Text="Save " OnClick="btnSave_Click" />

                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>

                                        <tr>
                                            <td colspan="5">
                                                <div style="overflow: auto; width: 100%; height: 430px">
                                                    <asp:GridView ID="gvShow" runat="server" AutoGenerateColumns="False" DataKeyNames="SFT_CNG_ID" CssClass="gridDynamic">
                                                        <Columns>
                                                            <asp:TemplateField HeaderText="S.No.">
                                                                <ItemTemplate>
                                                                    <%# ((GridViewRow)Container).RowIndex + 1%>
                                                                </ItemTemplate>
                                                                <ItemStyle Width="15px" />
                                                            </asp:TemplateField>
                                                            <asp:BoundField HeaderText="Code" DataField="EMP_ID" />
                                                            <asp:BoundField HeaderText="Name" DataField="EMP_NAME" />
                                                            <asp:BoundField HeaderText="Shift" DataField="SHIFT_ID" />
                                                            <asp:BoundField HeaderText="From Date " DataField="FROM_DATE" DataFormatString="{0:dd/MM/yyyy}" />
                                                            <asp:BoundField HeaderText="To Date " DataField="TO_DATE" DataFormatString="{0:dd/MM/yyyy}" />

                                                        </Columns>
                                                    </asp:GridView>
                                                </div>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <ajaxToolkit:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" CompletionSetCount="12"
                                                    EnableCaching="true" MinimumPrefixLength="1" ServiceMethod="GetEmployeeList"
                                                    ServicePath="~\AutoComplete.asmx" TargetControlID="txtEmp" ContextKey="1,2">
                                                </ajaxToolkit:AutoCompleteExtender>
                                                <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" Enabled="True" Format="dd/MM/yyyy" TargetControlID="txtFromDt">
                                                </ajaxToolkit:CalendarExtender>
                                                <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender1" runat="server" Mask="99/99/9999"
                                                    MaskType="Date" TargetControlID="txtFromDt">
                                                </ajaxToolkit:MaskedEditExtender>
                                            </td>
                                        </tr>
                                    </table>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </ContentTemplate>
                    </ajaxToolkit:TabPanel>
                    <ajaxToolkit:TabPanel runat="server" HeaderText="Shift Report" ID="TabPanel2">
                        <ContentTemplate>
                            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                <ContentTemplate>
                                    <table>
                                        <tr>
                                            <td>
                                                <table>
                                                    <tr>
                                                        <th>Institute
                                                        </th>
                                                        <th>Department
                                                        </th>
                                                        <th>Shift
                                                        </th>
                                                        <th>From Date
                                                        </th>
                                                        <th>To Date
                                                        </th>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:DropDownList ID="ddlIns" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlIns_SelectedIndexChanged"></asp:DropDownList>
                                                        </td>
                                                        <td>
                                                            <asp:DropDownList ID="ddlDept" runat="server" Width="150px"></asp:DropDownList>
                                                        </td>
                                                        <td>
                                                            <asp:DropDownList ID="ddlShiftRpt" runat="server" Width="150px"></asp:DropDownList>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtFrom" runat="server" Width="100px"></asp:TextBox>
                                                            <ajaxToolkit:CalendarExtender ID="CalendarExtender2" runat="server" Enabled="True" Format="dd/MM/yyyy" TargetControlID="txtFrom">
                                                            </ajaxToolkit:CalendarExtender>
                                                            <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender2" runat="server" Mask="99/99/9999"
                                                                MaskType="Date" TargetControlID="txtFrom">
                                                            </ajaxToolkit:MaskedEditExtender>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtTo" runat="server" Width="100px"></asp:TextBox>
                                                            <ajaxToolkit:CalendarExtender ID="CalendarExtender3" runat="server" Enabled="True" Format="dd/MM/yyyy" TargetControlID="txtTo">
                                                            </ajaxToolkit:CalendarExtender>
                                                            <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender3" runat="server" Mask="99/99/9999"
                                                                MaskType="Date" TargetControlID="txtTo">
                                                            </ajaxToolkit:MaskedEditExtender>
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
                                                <div style="overflow: auto; width: 100%; max-height: 600px">
                                                    <asp:GridView ID="gvShift" runat="server" AutoGenerateColumns="False" DataKeyNames="SFT_CNG_ID" CssClass="gridDynamic">
                                                        <Columns>
                                                            <asp:TemplateField HeaderText="S.No.">
                                                                <ItemTemplate>
                                                                    <%# ((GridViewRow)Container).RowIndex + 1%>
                                                                </ItemTemplate>
                                                                <ItemStyle Width="15px" />
                                                            </asp:TemplateField>
                                                            <asp:BoundField HeaderText="Code" DataField="EMP_ID" />
                                                            <asp:BoundField HeaderText="Name" DataField="EMP_NAME" />
                                                            <asp:BoundField HeaderText="Shift" DataField="SHIFT_ID" />
                                                            <asp:BoundField HeaderText="From Date " DataField="FROM_DATE" DataFormatString="{0:dd/MM/yyyy}" />
                                                            <asp:BoundField HeaderText="To Date " DataField="TO_DATE" DataFormatString="{0:dd/MM/yyyy}" />

                                                        </Columns>
                                                    </asp:GridView>
                                                </div>
                                            </td>
                                        </tr>
                                    </table>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </ContentTemplate>
                    </ajaxToolkit:TabPanel>
                </ajaxToolkit:TabContainer>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</asp:Content>

