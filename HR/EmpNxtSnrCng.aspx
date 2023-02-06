<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Short.master" AutoEventWireup="true" CodeFile="EmpNxtSnrCng.aspx.cs" Inherits="HR_EmpNxtSnrCng" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentHolder1" runat="Server">
    <script language="javascript" type="text/javascript">
        function SelectAllCheckboxes(spanChk) {


            var oItem = spanChk.children;
            var theBox = (spanChk.type == "checkbox") ?
                spanChk : spanChk.children.item[0];
            xState = theBox.checked;
            elm = theBox.form.elements;

            for (i = 0; i < elm.length; i++)
                if (elm[i].type == "checkbox" &&
                         elm[i].id != theBox.id) {
                    //elm[i].click();
                    if (elm[i].checked != xState)
                        elm[i].click();
                    //elm[i].checked=xState;
                }
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
            if (bTrim(document.getElementById(ctrl).value) == "" || bTrim(document.getElementById(ctrl).value) == "." || bTrim(document.getElementById(ctrl).value) == "Select") {
                document.getElementById(ctrl).style.backgroundColor = "#fc6";
                return false;
            }
            else {
                document.getElementById(ctrl).style.backgroundColor = "#fff";
                return true;
            }
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
        function getDate(ctrl, ctrl1) {
            var dd = (compareDateshr(document.getElementById(ctrl).value, "dd/MM/yyyy", document.getElementById(ctrl1).value, "dd/MM/yyyy"));
            if (dd == 1)
                return false;

            return true;
        }
        function validate() {
            var flag = true;
            var msg = "", ctrl = "";
            if (!CheckControl("<%=ddlDepartment.ClientID%>")) {
                msg += "- Select Department from List\n";
                if (ctrl == "")
                    ctrl = "<%=ddlDepartment.ClientID%>";
                flag = false;
            }
            if (!CheckControl("<%=ddlNextSenior.ClientID%>")) {
                msg += "- Select Next Senior from the List \n";
                if (ctrl == "")
                    ctrl = "<%=ddlNextSenior.ClientID%>";
                flag = false;
            }
            if (!CheckControl("<%=txtNextSenior.ClientID%>")) {
                msg += "- Enter New Next Senior Name\n";
                if (ctrl == "")
                    ctrl = "<%=txtNextSenior.ClientID%>";
                flag = false;
            }
            if (!CheckDate("<%=txtDate.ClientID%>")) {
                msg += "- Enter Date of Activation \n";
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
            <h2>Next Senior Change
            </h2>
        </div>
        <div>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <table>
                        <tr>
                            <td>
                                <table>
                                    <tr>
                                        <th>Institution<span class="required">*</span></th>
                                        <th>Department<span class="required">*</span></th>
                                        <th>Existing Next Senior<span class="required">*</span></th>
                                    </tr>
                                    <tr>
                                        <td style="height: 20px">
                                            <asp:DropDownList ID="ddlInstitute" runat="server" AutoPostBack="true" Width="200px" OnSelectedIndexChanged="ddlInstitute_SelectedIndexChanged" />&nbsp;</td>
                                        <td style="height: 20px">
                                            <asp:DropDownList ID="ddlDepartment" runat="server" AutoPostBack="true" Width="200px" OnSelectedIndexChanged="ddlDepartment_SelectedIndexChanged" />&nbsp;</td>
                                        <td style="height: 20px">
                                            <asp:DropDownList ID="ddlNextSenior" runat="server" AutoPostBack="true" Width="200px" OnSelectedIndexChanged="ddlNextSenior_SelectedIndexChanged" />&nbsp;</td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:GridView ID="gvShow" runat="server" AutoGenerateColumns="false" EmptyDataText="No Record Found"
                                    CssClass="gridDynamic">
                                    <Columns>
                                        <asp:TemplateField HeaderText="S.No.">
                                            <ItemTemplate>
                                                <%# ((GridViewRow)Container).RowIndex + 1%>
                                            </ItemTemplate>
                                            <ItemStyle Width="50px" />
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="EMP_ID" HeaderText="Employee ID" />
                                        <asp:BoundField DataField="EMP_NAME" HeaderText="Employee Name" />
                                        <asp:BoundField DataField="DEPT_VALUE" HeaderText="Department Name" />
                                        <asp:BoundField DataField="DES_VALUE" HeaderText="Designation" />
                                        <asp:TemplateField>
                                            <HeaderTemplate>
                                                <input id="chkAll" onclick="javascript: SelectAllCheckboxes(this);" type="checkbox" />
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:CheckBox ID="chk1" runat="server" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>

                                </asp:GridView>
                            </td>
                        </tr>
                        <tr id="trSave" runat="server">
                            <td>
                                <table>
                                    <tr>
                                        <th>Next Senior<span style="color: Red">*</span></th>
                                        <th>Active From<span style="color: Red">*</span></th>
                                        <th>Remarks</th>
                                        <th></th>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:TextBox ID="txtNextSenior" runat="server" Width="200px" CssClass="textbox" />

                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtDate" runat="server" CssClass="textbox" Width="80px"></asp:TextBox></td>
                                        <td>
                                            <asp:TextBox ID="txtRemark" runat="server" CssClass="textbox"></asp:TextBox></td>
                                        <td>
                                            <asp:Button ID="btnSave" runat="server" CssClass="btnBrown" Text="Save" Width="50px" OnClick="btnSave_Click" /></td>
                                    </tr>
                                    <tr>
                                        <td >
                                            <ajaxToolkit:AutoCompleteExtender ID="AutoCompleteExtender2" runat="server" CompletionSetCount="12"
                                                EnableCaching="true" MinimumPrefixLength="1" ServiceMethod="GetEmployeeList"
                                                ServicePath="~\AutoComplete.asmx" TargetControlID="txtNextSenior" ContextKey="1">
                                            </ajaxToolkit:AutoCompleteExtender>
                                            <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd/MM/yyyy"
                                                TargetControlID="txtDate">
                                            </ajaxToolkit:CalendarExtender>
                                            <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender1" runat="server" Mask="99/99/9999"
                                                MaskType="Date" TargetControlID="txtDate">
                                            </ajaxToolkit:MaskedEditExtender>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtXml" runat="server" Visible="false"></asp:TextBox>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
</asp:Content>

