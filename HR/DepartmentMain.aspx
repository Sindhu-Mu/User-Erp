<%@ Page Title="ERP | Employee Department Master" Language="C#" MasterPageFile="~/MasterPages/FullLength.master" AutoEventWireup="true" CodeFile="DepartmentMain.aspx.cs" Inherits="HR_DepartmentMain" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">


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

        function validation() {
            var flag = true;
            var msg = "", ctrl = "";
            if (!CheckControl("<%=ddlInstitue.ClientID%>")) {
                msg += "* Select Institute from List\n";
                if (ctrl == "")
                    ctrl = "<%=ddlInstitue.ClientID%>";
                flag = false;
            }
            if (!CheckControl("<%=txtDeptName.ClientID%>")) {
                msg += "* Enter Department Name!!\n";
                if (ctrl == "")
                    ctrl = "<%=txtDeptName.ClientID%>";
                flag = false;
            }
            if (!CheckControl("<%=txtDeptShortName.ClientID%>")) {
                msg += "* Enter Department Short Name!!\n";
                if (ctrl == "")
                    ctrl = "<%=txtDeptShortName.ClientID%>";
                flag = false;
            }
            if (!CheckControl("<%=ddlDeptType.ClientID%>")) {
                msg += "* Select Department Type List\n";
                if (ctrl == "")
                    ctrl = "<%=ddlDeptType.ClientID%>";
                flag = false;
            }
            if (msg != "") alert(msg);
            if (ctrl != "")
                document.getElementById(ctrl).focus();
            return flag;
        }


        function validationHead() {
            var flag = true;
            var msg = "", ctrl = "";
            if (!CheckControl("<%=ddlIns.ClientID%>")) {
                msg += "* Select Institute from List\n";
                if (ctrl == "")
                    ctrl = "<%=ddlIns.ClientID%>";
                flag = false;
            }
            if (!CheckAutoComplete("<%=txtEmp.ClientID%>")) {
                msg += "* Enter Employee Name With Code!!\n";
                if (ctrl == "")
                    ctrl = "<%=txtEmp.ClientID%>";
                flag = false;
            }
            if (!CheckControl("<%=txtFromDt.ClientID%>")) {
                msg += "* Enter From Date!!\n";
                if (ctrl == "")
                    ctrl = "<%=txtFromDt.ClientID%>";
                flag = false;
            }
            if (!CheckControl("<%=ddlDept.ClientID%>")) {
                msg += "* Select Department from List\n";
                if (ctrl == "")
                    ctrl = "<%=ddlDept.ClientID%>";
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
            <h2>Department Main</h2>
        </div>
        <div>
            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                <ContentTemplate>
                    <ajaxToolkit:TabContainer ID="step1" runat="server" ActiveTabIndex="0" AutoPostBack="true" OnActiveTabChanged="step1_ActiveTabChanged">
                        <ajaxToolkit:TabPanel runat="server" HeaderText="Department Master" ID="TabPanel1">
                            <ContentTemplate>
                                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                    <ContentTemplate>
                                        <table>
                                            <tr>
                                                <td>
                                                    <table>
                                                        <tr>
                                                            <th>Institute <span class="required">*</span></th>
                                                            <td>&nbsp;</td>
                                                            <th>Full Name<span class="required">*</span></th>
                                                            <td>&nbsp;</td>
                                                            <th>&nbsp;Short Name<span class="required">*</span></th>
                                                            <td>&nbsp;</td>
                                                            <th>Department Type<span class="required">*</span></th>
                                                            <td>&nbsp;</td>
                                                            <th>Is Essential<span class="required">*</span></th>
                                                            <td>&nbsp;</td>
                                                            <td>&nbsp;</td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:DropDownList ID="ddlInstitue" runat="server" Width="100px" AutoPostBack="True" OnSelectedIndexChanged="ddlInstitue_SelectedIndexChanged"></asp:DropDownList>
                                                            </td>
                                                            <td>&nbsp;</td>

                                                            <td>&nbsp;<asp:TextBox ID="txtDeptName" runat="server" Width="230px"></asp:TextBox></td>
                                                            <td>&nbsp;</td>
                                                            <td>&nbsp;<asp:TextBox ID="txtDeptShortName" runat="server" Width="100px"></asp:TextBox>
                                                            </td>
                                                            <td>&nbsp;</td>
                                                            <td>
                                                                <asp:DropDownList ID="ddlDeptType" runat="server" Width="120px"></asp:DropDownList>
                                                            </td>
                                                            <td>&nbsp;</td>
                                                            <td><asp:RadioButtonList ID="RbEssential" runat="server" RepeatDirection="Horizontal">
                                                                <asp:ListItem Value="0" Selected="True"> No</asp:ListItem>
                                                                <asp:ListItem Value="1"> Yes</asp:ListItem>
                                                            </asp:RadioButtonList>
                                                            </td>

                                                            <td>&nbsp;</td>
                                                            <td>
                                                                <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" /></td>
                                                        </tr>



                                                    </table>

                                                    <tr>
                                                        <td>
                                                            <div style="overflow: auto; width: 100%; height: 430px">
                                                                <asp:GridView ID="gvShow" runat="server" AutoGenerateColumns="False" DataKeyNames="DEPT_ID" OnRowCommand="gvShow_RowCommand" CssClass="gridDynamic">
                                                                    <Columns>
                                                                        <asp:TemplateField HeaderText="S.No.">
                                                                            <ItemTemplate>
                                                                                <%# ((GridViewRow)Container).RowIndex + 1%>
                                                                            </ItemTemplate>
                                                                            <ItemStyle Width="15px" />
                                                                        </asp:TemplateField>
                                                                        <asp:BoundField HeaderText="Institute" DataField="INS_VALUE" />
                                                                        <asp:BoundField HeaderText="Full Name " DataField="DEPT_VALUE" />
                                                                        <asp:BoundField HeaderText="Short Name" DataField="DEPT_ALIAS" />
                                                                        <asp:BoundField HeaderText="Type" DataField="DEPT_TYPE_VALUE" />
                                                                           <asp:BoundField HeaderText="Essential" DataField="IS_ESSENTIAL" />
                                                                        <asp:CommandField ButtonType="Image" SelectImageUrl="~/Siteimages/edit.gif" ShowSelectButton="True" HeaderText="Modify">
                                                                            <ItemStyle Width="40px" />
                                                                        </asp:CommandField>
                                                                        <asp:TemplateField ShowHeader="False" HeaderText="Status">
                                                                            <ItemStyle Width="20px" HorizontalAlign="Right" />
                                                                            <ItemTemplate>
                                                                                <asp:ImageButton ID="imgAct" runat="server" CausesValidation="false" CommandArgument='<%# Bind("DEPT_ID") %>'
                                                                                    ImageUrl='<%# Bind("STS_IMG") %>' CommandName='<%# Bind("STS_CMD") %>' ToolTip='<%# Bind("STS_TOOLTIP")%>' />
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                    </Columns>
                                                                </asp:GridView>
                                                            </div>
                                                        </td>
                                                    </tr>
                                                </td>
                                            </tr>
                                        </table>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </ContentTemplate>
                        </ajaxToolkit:TabPanel>
                        <ajaxToolkit:TabPanel runat="server" HeaderText="Department Head" ID="TabPanel2">
                            <ContentTemplate>
                                <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                    <ContentTemplate>
                                        <table>
                                            <tr>
                                                <td>
                                                    <table>
                                                        <tr>
                                                            <th>Institute
                                                         <span class="required">*</span>
                                                            </th>
                                                            <td>&nbsp;</td>
                                                            <th>Department
                                                         <span class="required">*</span>
                                                            </th>
                                                            <td>&nbsp;</td>
                                                            <th>HOD Name<span class="required">*</span>
                                                            </th>
                                                            <td>&nbsp;</td>
                                                            <th>From Date  <span class="required">*</span>
                                                            </th>
                                                            <td>&nbsp;</td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:DropDownList ID="ddlIns" runat="server" Width="100px" OnSelectedIndexChanged="ddlIns_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                                                            </td>
                                                            <td>&nbsp;</td>
                                                            <td>
                                                                <asp:DropDownList ID="ddlDept" runat="server" Width="100px" OnSelectedIndexChanged="ddlDept_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                                                            </td>
                                                            <td>&nbsp;</td>
                                                            <td>
                                                                <asp:TextBox ID="txtEmp" runat="server" Width="200px"></asp:TextBox>
                                                            </td>
                                                            <td>&nbsp;</td>
                                                            <td>
                                                                <asp:TextBox ID="txtFromDt" runat="server" Width="90px"></asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:Button ID="btnHeadSave" runat="server" Text="Save" OnClick="btnHeadSave_Click" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                    <tr>
                                                        <td>
                                                            <div style="width: 100%; max-height: 430px; overflow: auto">
                                                                <asp:GridView ID="gvDeptHead" runat="server" AutoGenerateColumns="False" CssClass="gridDynamic" DataKeyNames="DEPT_ID">
                                                                    <Columns>
                                                                        <asp:TemplateField HeaderText="S.No.">
                                                                            <ItemTemplate>
                                                                                <%# ((GridViewRow)Container).RowIndex + 1%>
                                                                            </ItemTemplate>
                                                                            <ItemStyle Width="20px" />
                                                                        </asp:TemplateField>
                                                                        <asp:BoundField HeaderText="Institution" DataField="INS_VALUE" />
                                                                        <asp:BoundField HeaderText="Department" DataField="DEPT_VALUE" />
                                                                        <asp:BoundField HeaderText="Head" DataField="EMP_NAME" />
                                                                        <asp:BoundField HeaderText="From Date" DataField="FRM_DATE" DataFormatString="{0:dd/MM/yyyy}" />
                                                                    </Columns>
                                                                </asp:GridView>
                                                            </div>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <ajaxToolkit:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" TargetControlID="txtEmp"
                                                                CompletionSetCount="12" EnableCaching="true" MinimumPrefixLength="1" ServiceMethod="GetEmployeeList"
                                                                ServicePath="~\AutoComplete.asmx" ContextKey="1">
                                                            </ajaxToolkit:AutoCompleteExtender>
                                                            <ajaxToolkit:CalendarExtender runat="server" ID="calendar" TargetControlID="txtFromDt" Format="dd/MM/yyyy"></ajaxToolkit:CalendarExtender>
                                                            <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender1" runat="server" Mask="99/99/9999" MaskType="Date"
                                                                TargetControlID="txtFromDt">
                                                            </ajaxToolkit:MaskedEditExtender>
                                                        </td>
                                                    </tr>
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
    </div>

</asp:Content>

