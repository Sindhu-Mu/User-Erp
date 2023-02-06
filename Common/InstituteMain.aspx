<%@ Page Title="ERP | Institute" Language="C#" MasterPageFile="~/MasterPages/Short.master" AutoEventWireup="true" CodeFile="InstituteMain.aspx.cs" Inherits="Common_InstituteMain" %>

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
        function CheckDate(ctrl) {
            var dt = document.getElementById(ctrl).value;
            if (!isDatecheck(dt, "dd/MM/yyyy")) {
                document.getElementById(ctrl).style.backgroundColor = "#fc6";
                return false;
            }
            else {
                document.getElementById(ctrl).style.backgroundColor = "#fff";
                return true;
            }
        }
        function validation() {
            var flag = true;
            var msg = "", ctrl = "";
            if (!CheckControl("<%=ddlUnivCode.ClientID%>")) {
                msg += " * Select University Code \n";
                if (ctrl == "")
                    ctrl = "<%=ddlUnivCode.ClientID%>";
                flag = false;
            }
            if (!CheckControl("<%=txtInsDesc.ClientID%>")) {
                msg += " * Enter Full Name  \n";
                if (ctrl == "")
                    ctrl = "<%=txtInsDesc.ClientID%>";
                flag = false;
            }
            if (!CheckControl("<%=txtIns.ClientID%>")) {
                msg += " * Enter Short Name \n";
                if (ctrl == "")
                    ctrl = "<%=txtIns.ClientID%>";
                flag = false;
            }
            if (!CheckControl("<%=txtEvl.ClientID%>")) {
                msg += " * Enter Code \n";
                if (ctrl == "")
                    ctrl = "<%=txtEvl.ClientID%>";
                flag = false;
            }
            if (msg != "") alert(msg);
            if (ctrl != "")
                document.getElementById(ctrl).focus();
            return flag;
        }
        function validateIncharge() {
            var flag = true;
            var msg = "", ctrl = "";
            if (!CheckControl("<%=ddlUniv.ClientID%>")) {
                msg += "* Select Store from list\n";
                if (ctrl == "")
                    ctrl = "<%=ddlUniv.ClientID%>";
                flag = false;
            }
            if (!CheckAutoComplete("<%=txtEmp.ClientID%>")) {
                msg += "* Enter Name & Emp.Code\n";
                if (ctrl == "")
                    ctrl = "<%=txtEmp.ClientID%>";
                flag = false;
            }
            if (!CheckDate("<%=txtFromDt.ClientID%>")) {
                if (!CheckControl("<%=txtFromDt.ClientID%>")) {
                    msg += "* Enter From date. \n";
                    if (ctrl == "")
                        ctrl = "<%=txtFromDt.ClientID%>";
                    flag = false;
                }
                else {
                    msg += "* Enter Correct Date.  \n";
                    if (ctrl == "")
                        ctrl = "<%=txtFromDt.ClientID%>";
                     flag = false;
                 }
             }
             if (msg != "")
                 alert(msg);
             if (ctrl != "")
                 document.getElementById(ctrl).focus();
             return flag;
         }
    </script>
    <div class="container">
        <div class="heading">
            <h2>Institute</h2>
        </div>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <ajaxToolkit:TabContainer ID="step1" runat="server" ActiveTabIndex="0" AutoPostBack="true" OnActiveTabChanged="step1_ActiveTabChanged">
                    <ajaxToolkit:TabPanel runat="server" HeaderText="Institution Master" ID="TabPanel1">
                        <ContentTemplate>
                            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                <ContentTemplate>
                                    <table>
                                        <tr>
                                            <td>
                                                <table>

                                                    <tr>
                                                        <th>University<span class="required">*</span></th>
                                                        <td>&nbsp;</td>
                                                        <th>Full Name<span class="required">*</span></th>
                                                        <td>&nbsp;</td>
                                                        <th>Short Name<span class="required">*</span></th>
                                                        <td>&nbsp;</td>
                                                        <th>Institute Code<span class="required">*</span></th>
                                                        <td>&nbsp;</td>

                                                        <td>&nbsp;</td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:DropDownList ID="ddlUnivCode" runat="server" AutoPostBack="true" Width="90px"></asp:DropDownList></td>
                                                        <td>&nbsp;</td>
                                                        <td>
                                                            <asp:TextBox ID="txtInsDesc" runat="server" Width="300px"></asp:TextBox></td>
                                                        <td>&nbsp;</td>
                                                        <td>
                                                            <asp:TextBox ID="txtIns" runat="server" Width="94px"></asp:TextBox></td>
                                                        <td>&nbsp;</td>

                                                        <td>
                                                            <asp:TextBox ID="txtEvl" runat="server" Width="81px"></asp:TextBox>
                                                        </td>
                                                        <td>&nbsp;</td>
                                                        <td>
                                                            <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" Width="49px" /></td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:GridView ID="gvShow" runat="server" AutoGenerateColumns="False" DataKeyNames="INS_ID" CssClass="gridDynamic" OnRowCommand="gvShow_RowCommand">
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="S.No.">
                                                            <ItemTemplate>
                                                                <%# ((GridViewRow)Container).RowIndex + 1%>
                                                            </ItemTemplate>
                                                            <ItemStyle Width="15px" />
                                                        </asp:TemplateField>
                                                        <asp:BoundField HeaderText="Full Name" DataField="INS_DESC" />
                                                        <asp:BoundField HeaderText="Short Name" DataField="INS_VALUE" />
                                                        <asp:BoundField HeaderText="Institute Code" DataField="INS_CODE" />
                                                        <asp:CommandField ButtonType="Image" SelectImageUrl="~/Siteimages/edit.gif" ShowSelectButton="True" HeaderText="Modify">
                                                            <ItemStyle Width="40px" />
                                                        </asp:CommandField>
                                                        <asp:TemplateField ShowHeader="False" HeaderText="Status">
                                                            <ItemStyle Width="20px" HorizontalAlign="Right" />
                                                            <ItemTemplate>
                                                                <asp:ImageButton ID="imgAct" runat="server" CausesValidation="false" CommandArgument='<%# Bind("INS_ID") %>'
                                                                    ImageUrl='<%# Bind("STS_IMG") %>' CommandName='<%# Bind("STS_CMD") %>' ToolTip='<%# Bind("STS_TOOLTIP")%>' />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                    </Columns>
                                                </asp:GridView>
                                            </td>
                                        </tr>
                                    </table>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </ContentTemplate>
                    </ajaxToolkit:TabPanel>
                    <ajaxToolkit:TabPanel runat="server" HeaderText="Institution Head" ID="TabPanel2">
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
                                                        <th>Head Name<span class="required">*</span>
                                                        </th>
                                                        <td>&nbsp;</td>
                                                        <th>From Date  <span class="required">*</span>
                                                        </th>
                                                        <td>&nbsp;</td>

                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:DropDownList ID="ddlUniv" runat="server" Width="100px"></asp:DropDownList>
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
                                                        <asp:GridView ID="gvHead" runat="server" AutoGenerateColumns="False" CssClass="gridDynamic"
                                                            DataKeyNames="ID" >
                                                            <Columns>
                                                                <asp:TemplateField HeaderText="S.No.">
                                                                    <ItemTemplate>
                                                                        <%# ((GridViewRow)Container).RowIndex + 1%>
                                                                    </ItemTemplate>
                                                                    <ItemStyle Width="20px" />
                                                                </asp:TemplateField>
                                                                <asp:BoundField HeaderText="Institution" DataField="INS_VALUE" />
                                                                <asp:BoundField HeaderText="Head" DataField="EMP_NAME" />
                                                                <asp:BoundField HeaderText="From Date" DataField="FRM_DATE" DataFormatString="{0:dd/MM/yyyy}" />
                                                            </Columns>
                                                        </asp:GridView>
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

