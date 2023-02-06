<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Short.master" AutoEventWireup="true" CodeFile="ResignationMain.aspx.cs" Inherits="HR_ResignationMain" %>

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
        function validate() {
            var flag = true;
            var msg = "", ctrl = "";
            if (!CheckAutoComplete("<%=txtEmployee.ClientID%>")) {
                msg += "* Enter Employee Name & Code!!\n";
                if (ctrl == "")
                    ctrl = "<%=txtEmployee.ClientID%>";
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
            if (!CheckAutoComplete("<%=txtEmployee.ClientID%>")) {
                msg += "* Enter Employee Name & Code!!\n";
                if (ctrl == "")
                    ctrl = "<%=txtEmployee.ClientID%>";
                flag = false;
            }
            if (!CheckControl("<%=ddlReason.ClientID%>")) {
                msg += "* Select Reason from List\n";
                if (ctrl == "")
                    ctrl = "<%=ddlReason.ClientID%>";
                flag = false;
            }
            if (!CheckControl("<%=txtRelDate.ClientID%>")) {
                msg += "* Enter Releiving Date!!\n";
                if (ctrl == "")
                    ctrl = "<%=txtRelDate.ClientID%>";
                flag = false;
            }
            if (!CheckControl("<%=txtResigDate.ClientID%>")) {
                msg += "* Enter Resignation Date!!\n";
                if (ctrl == "")
                    ctrl = "<%=txtResigDate.ClientID%>";
                flag = false;
            }
            if (!CheckControl("<%=txtRemark.ClientID%>")) {
                msg += "* Enter Remark!!\n";
                if (ctrl == "")
                    ctrl = "<%=txtRemark.ClientID%>";
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
            <h2>Employee Releiving
            </h2>
        </div>
        <div>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                    <table>
                        <tr>
                            <td align="right">
                                <table>
                                    <tr>

                                        <td>
                                            <asp:TextBox ID="txtEmployee" runat="server" Width="221px" placeholder="Enter Employee Name & Code"></asp:TextBox>

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
                            <td>
                                <table>
                                    <tr>
                                        <th>Reason<span class="required">*</span>
                                        </th>
                                        <th>Resignation Date<span class="required">*</span>
                                        </th>
                                        <th>Releiving Date<span class="required">*</span>
                                        </th>
                                        <th>Remark<span class="required">*</span>
                                        </th>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:DropDownList ID="ddlReason" runat="server"></asp:DropDownList>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtResigDate" runat="server"></asp:TextBox>

                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtRelDate" runat="server"></asp:TextBox>

                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtRemark" runat="server"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" />
                                        </td>

                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <div>
                                    <asp:GridView ID="gvResig" runat="server" AutoGenerateColumns="false" DataKeyNames="EMP_RESIG_ID" OnRowCancelingEdit="gvResig_RowCancelingEdit" OnRowEditing="gvResig_RowEditing" OnRowUpdating="gvResig_RowUpdating" CssClass="gridDynamic">
                                        <Columns>
                                            <asp:BoundField HeaderText="Emp.Code" DataField="EMP_ID" ReadOnly="true" />
                                            <asp:BoundField HeaderText="Emp.Name" DataField="EMP_NAME" ReadOnly="true" />
                                            <asp:BoundField HeaderText="Designation" DataField="DES_VALUE" ReadOnly="true" />
                                            <asp:BoundField HeaderText="Resign On" DataField="RESIG_DATE" DataFormatString="{0:dd/MM/yyyy}" ReadOnly="true" />
                                            <asp:TemplateField HeaderText="Reliving Date" SortExpression="RELVNG_DATE">
                                                <EditItemTemplate>
                                                    <asp:TextBox ID="txtRDate" runat="server" Width="90px" CssClass="textbox" Text='<%# Bind("RELVNG_DATE","{0:dd/MM/yyyy}") %>'></asp:TextBox>
                                                    <ajaxToolkit:CalendarExtender ID="CalendarExtender" runat="server" TargetControlID="txtRDate" Format="dd/MM/yyyy">
                                                    </ajaxToolkit:CalendarExtender>
                                                    <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender" runat="server" Mask="99/99/9999" MaskType="Date"
                                                        TargetControlID="txtRDate">
                                                    </ajaxToolkit:MaskedEditExtender>

                                                </EditItemTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblRelDate" runat="server" Text='<%# Bind("RELVNG_DATE", "{0:dd/MM/yyyy}") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle Width="90px" />

                                            </asp:TemplateField>
                                            <asp:CommandField ButtonType="Button" ShowEditButton="True" HeaderText="Edit"></asp:CommandField>
                                            <asp:CommandField ButtonType="Button" SelectText="View" ShowSelectButton="True" HeaderText="View">
                                                <ItemStyle Width="27px" />
                                            </asp:CommandField>
                                        </Columns>

                                    </asp:GridView>
                                </div>

                            </td>
                        </tr>
                        <tr>
                            <td>
                                <ajaxToolkit:AutoCompleteExtender ID="autoComplete1" runat="server" CompletionInterval="500"
                                    CompletionSetCount="12" ContextKey="1,0" EnableCaching="true" MinimumPrefixLength="1"
                                    ServiceMethod="GetEmployeeList" ServicePath="~\AutoComplete.asmx" TargetControlID="txtEmployee">
                                </ajaxToolkit:AutoCompleteExtender>
                                <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtResigDate" Format="dd/MM/yyyy">
                                </ajaxToolkit:CalendarExtender>
                                <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender1" runat="server" Mask="99/99/9999" MaskType="Date"
                                    TargetControlID="txtResigDate">
                                </ajaxToolkit:MaskedEditExtender>
                                <ajaxToolkit:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtRelDate" Format="dd/MM/yyyy">
                                </ajaxToolkit:CalendarExtender>
                                <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender2" runat="server" Mask="99/99/9999" MaskType="Date"
                                    TargetControlID="txtRelDate">
                                </ajaxToolkit:MaskedEditExtender>
                            </td>
                        </tr>
                    </table>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>

    </div>
</asp:Content>

