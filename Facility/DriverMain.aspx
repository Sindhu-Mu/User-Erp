<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/FullLength.master" AutoEventWireup="true" CodeFile="DriverMain.aspx.cs" Inherits="Facility_DriverMain" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script lang="javascript" type="text/javascript">
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
            if (bTrim(document.getElementById(ctrl).value) == "" || bTrim(document.getElementById(ctrl).value) == "." || bTrim(document.getElementById(ctrl).value) == "Select") {
                document.getElementById(ctrl).style.backgroundColor = "#fc6";
                return false;
            }
            else
                document.getElementById(ctrl).style.backgroundColor = "#fff";
            return true;
        }

        function validate() {
            var flag = true;
            var msg = "", ctrl = "";
            if (!CheckAutoComplete("<%=txtEmp.ClientID%>")) {
                     msg += " * Enter employee name & code. \n";
                     if (ctrl == "")
                         ctrl = "<%=txtEmp.ClientID%>";
                     flag = false;
            }
            if (!CheckControl("<%=txtLicence.ClientID%>")) {
                msg += "- Enter Licence Number.\n";
                if (ctrl == "")
                    ctrl = "<%=txtLicence.ClientID%>";
                     flag = false;
                 }
            if (!CheckControl("<%=txtIssueDt.ClientID%>")) {
                msg += "- Enter Licence Issue Date.\n";
                if (ctrl == "")
                    ctrl = "<%=txtIssueDt.ClientID%>";
                     flag = false;
            }
            if (!CheckControl("<%=txtValidUpto.ClientID%>")) {
                msg += "- Enter Licence Valid Upto Date.\n";
                if (ctrl == "")
                    ctrl = "<%=txtValidUpto.ClientID%>";
                     flag = false;
            }
            if (!CheckControl("<%=txtRenewDt.ClientID%>")) {
                msg += "- Enter Licence Renew Date.\n";
                if (ctrl == "")
                    ctrl = "<%=txtRenewDt.ClientID%>";
                     flag = false;
            }
            if (!CheckControl("<%=txtPhone.ClientID%>")) {
                msg += "- Enter Driver Phone Number.\n";
                if (ctrl == "")
                    ctrl = "<%=txtPhone.ClientID%>";
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
            <h2>Driver Main</h2>
        </div>
        <table>
            <tr>
                <td>
                    <table>
                        <tr>
                            <th>Employee<span class="required">*</span></th>
                            <th>Licence No<span class="required">*</span></th>
                            <th>Issue Date<span class="required">*</span></th>
                            <th>Valid Upto<span class="required">*</span></th>
                            <th>Renew Date<span class="required">*</span></th>
                        </tr>
                        <tr>
                            <td>
                                <asp:TextBox ID="txtEmp" runat="server"></asp:TextBox>
                                <ajaxToolkit:AutoCompleteExtender ID="autoComplete1" runat="server" CompletionInterval="500"
                                    CompletionSetCount="12" ContextKey="1" EnableCaching="true" MinimumPrefixLength="1"
                                    ServiceMethod="GetEmployeeList" ServicePath="~\AutoComplete.asmx" TargetControlID="txtEmp">
                                </ajaxToolkit:AutoCompleteExtender>
                            </td>
                            <td>
                                <asp:TextBox ID="txtLicence" runat="server"></asp:TextBox></td>
                            <td>
                                <asp:TextBox ID="txtIssueDt" runat="server"></asp:TextBox>
                                <ajaxToolkit:CalendarExtender ID="CalendarExtender2" Format="dd/MM/yyyy" runat="server" TargetControlID="txtIssueDt"></ajaxToolkit:CalendarExtender>
                                <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender2" runat="server" TargetControlID="txtIssueDt" Mask="99/99/9999" MaskType="Date">
                                </ajaxToolkit:MaskedEditExtender>
                            </td>
                            <td>
                                <asp:TextBox ID="txtValidUpto" runat="server"></asp:TextBox>
                                <ajaxToolkit:CalendarExtender ID="CalendarExtender1" Format="dd/MM/yyyy" runat="server" TargetControlID="txtValidUpto"></ajaxToolkit:CalendarExtender>
                                <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender1" runat="server" TargetControlID="txtValidUpto" Mask="99/99/9999" MaskType="Date">
                                </ajaxToolkit:MaskedEditExtender>
                            </td>
                            <td>
                                <asp:TextBox ID="txtRenewDt" runat="server"></asp:TextBox>
                                <ajaxToolkit:CalendarExtender ID="CalendarExtender3" Format="dd/MM/yyyy" runat="server" TargetControlID="txtRenewDt"></ajaxToolkit:CalendarExtender>
                                <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender3" runat="server" TargetControlID="txtRenewDt" Mask="99/99/9999" MaskType="Date">
                                </ajaxToolkit:MaskedEditExtender>
                            </td>
                        </tr>
                        <tr>
                            <th>Authorize For</th>
                            <th>Blood Group</th>
                            <th>Phone No<span class="required">*</span></th>
                        </tr>
                        <tr>
                            <td>
                                <asp:RadioButtonList ID="rdbAutFor" runat="server">
                                    <asp:ListItem Text="Light Motor Vehicle" Value="LMV" Selected="True"></asp:ListItem>
                                    <asp:ListItem Text="Heavy Motor Vehicle" Value="HMV"></asp:ListItem>
                                </asp:RadioButtonList></td>
                            <td>
                                <asp:DropDownList ID="ddlBloodGrp" runat="server">
                                    <asp:ListItem Text="Select"></asp:ListItem>
                                    <asp:ListItem Text="A+"></asp:ListItem>
                                    <asp:ListItem Text="A-"></asp:ListItem>
                                    <asp:ListItem Text="AB+"></asp:ListItem>
                                    <asp:ListItem Text="AB-"></asp:ListItem>
                                    <asp:ListItem Text="B+"></asp:ListItem>
                                    <asp:ListItem Text="B-"></asp:ListItem>
                                    <asp:ListItem Text="O+"></asp:ListItem>
                                    <asp:ListItem Text="O-"></asp:ListItem>
                                </asp:DropDownList></td>
                            <td>
                                <cc1:NumericTextBox ID="txtPhone" runat="server"></cc1:NumericTextBox></td>
                            <td>
                                <asp:Button ID="btnSave" runat="server" Text="SAVE" OnClick="btnSave_Click" /></td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td>
                    <table>
                        <tr>
                            <td>
                                <asp:GridView ID="gvDriverFill" AutoGenerateColumns="false" runat="server" DataKeyNames="DRIVER_ID" CssClass="gridDynamic" OnRowCommand="gvDriverFill_RowCommand">
                                    <Columns>
                                        <asp:TemplateField HeaderText="S.No.">
                                            <ItemTemplate>
                                                <%# ((GridViewRow)Container).RowIndex + 1%>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField HeaderText="Driver Name" DataField="EMP_NAME" />
                                        <asp:BoundField HeaderText="Licence No" DataField="DRIVER_LICENCE_NO" />
                                        <asp:BoundField HeaderText="Licence Issue Date" DataField="DRIVER_DL_ISSUE_DT" />
                                        <asp:BoundField HeaderText="Issued By" DataField="ISSUE_BY" />
                                        <asp:BoundField HeaderText="Licence Renew Date" DataField="DRIVER_DL_RENEW_DT" />
                                        <asp:BoundField HeaderText="Blood Group" DataField="DRIVER_BLOOD_GP" />
                                        <asp:BoundField HeaderText="Phone" DataField="DRIVER_PHONE" />
                                        <asp:BoundField HeaderText="Authorized For" DataField="DRIVER_AUTH_FOR" />
                                        <asp:CommandField ButtonType="Image" SelectImageUrl="~/Siteimages/edit.gif" ShowSelectButton="True" HeaderText="Modify">
                                            <ItemStyle Width="40px" />
                                        </asp:CommandField>
                                         <asp:TemplateField ShowHeader="False" HeaderText="Status">
                                                    <ItemStyle Width="20px" HorizontalAlign="Right" />
                                                                <ItemTemplate>
                                                            <asp:ImageButton ID="ImageButton1" runat="server" CausesValidation="false" CommandArgument='<%# Bind("DRIVER_ID") %>'
                                                             ImageUrl='<%# Bind("STS_IMG") %>' CommandName='<%# Bind("STS_CMD") %>' ToolTip='<%# Bind("STS_TOOLTIP")%>' />
                                                    </ItemTemplate>
                                            </asp:TemplateField>
                                    </Columns>
                                    <SelectedRowStyle BackColor="#FFFF99" />
                                </asp:GridView>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>

