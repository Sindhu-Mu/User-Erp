<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Short.master" AutoEventWireup="true" CodeFile="EmpWeekOffCng.aspx.cs" Inherits="HR_EmpWeekOffCng" %>

<%@ Register Src="~/Control/Employee.ascx" TagPrefix="uc1" TagName="Employee" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentHolder1" runat="Server">
    <script language="javascript" type="text/javascript">
        function CheckControl(ctrl) {
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
                msg += " * Enter Employee name & code. \n";
                if (ctrl == "")
                    ctrl = "<%=txtEmp.ClientID%>";
                flag = false;
            }

            if (msg != "") alert(msg);
            if (ctrl != "")
                document.getElementById(ctrl).focus();
            return flag;
        }
        function validat() {
            var flag = true;
            var msg = "", ctrl = "";

            if (!CheckAutoComplete("<%=txtEmp.ClientID%>")) {
                msg += " * Enter Employee name & code. \n";
                if (ctrl == "")
                    ctrl = "<%=txtEmp.ClientID%>";
                flag = false;
            }
            if (!CheckControl("<%=ddlWeekDay.ClientID%>")) {
                msg += " * Select Week Day. \n";
                if (ctrl == "")
                    ctrl = "<%=ddlWeekDay.ClientID%>";
                flag = false;
            }
            if (!CheckControl("<%=ddlOffType.ClientID%>")) {
                msg += " * Select Off Type. \n";
                if (ctrl == "")
                    ctrl = "<%=ddlOffType.ClientID%>";
                flag = false;
            }
            if (!CheckControl("<%=txtFromDate.ClientID%>")) {
                msg += " * Enter From Date \n";
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
    <div>
        <div class="heading">
            <h2>Employee Week Off</h2>
        </div>
        <table>
            <tr>
                <td>
                    <table>

                        <tr>
                            <td colspan="4" style="width: 600px">
                                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                    <ContentTemplate>
                                        <ajaxToolkit:TabContainer ID="step1" runat="server" ActiveTabIndex="0" AutoPostBack="true">
                                            <ajaxToolkit:TabPanel runat="server" HeaderText="Week Off Entry" ID="TabPanel1">
                                                <ContentTemplate>
                                                    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                                        <ContentTemplate>
                                                            <table>
                                                                <tr>
                                                                    <td></td>
                                                                    <td></td>
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
                                                                    <td colspan="6">
                                                                        <uc1:Employee ID="Employee" runat="server" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <th>Week Off Day<span class="required">*</span></th>
                                                                    <td>&nbsp;</td>
                                                                    <th>Week Off Type<span class="required">*</span></th>
                                                                    <td>&nbsp;</td>
                                                                    <th>From Date</th>
                                                                    <td>&nbsp;</td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        <asp:DropDownList ID="ddlWeekDay" runat="server" Width="150px">
                                                                            <asp:ListItem>Select</asp:ListItem>
                                                                            <asp:ListItem Value="6">Sunday</asp:ListItem>
                                                                            <asp:ListItem Value="0">Monday</asp:ListItem>
                                                                            <asp:ListItem Value="1">Tuesday</asp:ListItem>
                                                                            <asp:ListItem Value="2">Wednesday</asp:ListItem>
                                                                            <asp:ListItem Value="3">Thursday</asp:ListItem>
                                                                            <asp:ListItem Value="4">Friday</asp:ListItem>
                                                                            <asp:ListItem Value="5">Saturday</asp:ListItem>
                                                                        </asp:DropDownList></td>
                                                                    <td></td>
                                                                    <td>
                                                                        <asp:DropDownList ID="ddlOffType" runat="server" Width="150px">
                                                                            <asp:ListItem Value="0">Only one</asp:ListItem>
                                                                            <asp:ListItem Value="1">With Second day</asp:ListItem>
                                                                            <asp:ListItem Value="2">With First and Third day</asp:ListItem>
                                                                            <asp:ListItem Value="3">With Second and Fourth day</asp:ListItem>
                                                                        </asp:DropDownList></td>
                                                                    <td></td>
                                                                    <td>
                                                                        <asp:TextBox ID="txtFromDate" runat="server"></asp:TextBox>
                                                                        <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtFromDate" Format="dd/MM/yyyy">
                                                                        </ajaxToolkit:CalendarExtender>
                                                                        <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender1" runat="server" Mask="99/99/9999" MaskType="Date"
                                                                            TargetControlID="txtFromDate">
                                                                        </ajaxToolkit:MaskedEditExtender>
                                                                    </td>
                                                                    <td>
                                                                        <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td colspan="6">
                                                                        <asp:GridView ID="gvReport" runat="server" AutoGenerateColumns="False" DataKeyNames="ID" EmptyDataText="No record found." CssClass="gridDynamic" OnRowCommand="gvShow_RowCommand">
                                                                            <Columns>
                                                                                <asp:TemplateField HeaderText="S#">
                                                                                    <ItemTemplate>
                                                                                        <%# ((GridViewRow )Container).RowIndex+1 %>
                                                                                    </ItemTemplate>
                                                                                    <ItemStyle Width="15px" />
                                                                                </asp:TemplateField>
                                                                                <asp:BoundField DataField="WEEK_OFF" HeaderText="Week Off Day"></asp:BoundField>
                                                                                <asp:BoundField DataField="OFF_TYPE" HeaderText="Off Type"></asp:BoundField>
                                                                                <asp:BoundField DataField="FROM_DT" HeaderText="From Date" DataFormatString="{0:dd/MM/yyy}"></asp:BoundField>
                                                                                <asp:BoundField DataField="TO_DT" HeaderText="To Date" DataFormatString="{0:dd/MM/yyy}" />
                                                                            </Columns>
                                                                        </asp:GridView>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </ContentTemplate>
                                                    </asp:UpdatePanel>
                                                </ContentTemplate>
                                            </ajaxToolkit:TabPanel>


                                            <ajaxToolkit:TabPanel runat="server" HeaderText="Week Off Report" ID="TabPanel2">
                                                <ContentTemplate>
                                                    <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                                        <ContentTemplate>
                                                            <table>

                                                                <tr>
                                                                    <td colspan="3">
                                                                        <asp:GridView ID="gvShow" runat="server" DataKeyNames="ID" AutoGenerateColumns="False"  EmptyDataText="No record found." CssClass="gridDynamic" OnRowCommand="gvShow_RowCommand">
                                                                            <Columns>
                                                                                <asp:TemplateField HeaderText="S#">
                                                                                    <ItemTemplate>
                                                                                        <%# ((GridViewRow )Container).RowIndex+1 %>
                                                                                    </ItemTemplate>
                                                                                    <ItemStyle Width="15px" />
                                                                                </asp:TemplateField>
                                                                                <asp:BoundField DataField="EMP_ID" HeaderText="Employee Code"></asp:BoundField>
                                                                                <asp:BoundField DataField="EMP_NAME" HeaderText="Employee Name"></asp:BoundField>
                                                                                <asp:BoundField DataField="WEEK_OFF" HeaderText="Week Off Day"></asp:BoundField>
                                                                                <asp:BoundField DataField="OFF_TYPE" HeaderText="Off Type"></asp:BoundField>
                                                                                <asp:BoundField DataField="FROM_DT" HeaderText="From Date" DataFormatString="{0:dd/MM/yyy}"></asp:BoundField>
                                                                                <asp:TemplateField ShowHeader="False" HeaderText="Status">
                                                                                    <ItemStyle Width="20px" HorizontalAlign="Right" />
                                                                                    <ItemTemplate>
                                                                                        <asp:ImageButton ID="imgAct" runat="server" CausesValidation="false" CommandArgument='<%# Bind("ID") %>'
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

                                        </ajaxToolkit:TabContainer>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>
                        </tr>

                    </table>
                </td>
            </tr>


        </table>
    </div>
</asp:Content>

