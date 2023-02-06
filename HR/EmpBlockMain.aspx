<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Short.master" AutoEventWireup="true" CodeFile="EmpBlockMain.aspx.cs" Inherits="HR_EmpBlockMain" %>

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
            if (!CheckAutoComplete("<%=txtEmpName.ClientID%>")) {
                msg += " * Enter Name with Code. \n";
                if (ctrl == "")
                    ctrl = "<%=txtEmpName.ClientID%>";
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
            if (!CheckAutoComplete("<%=txtEmpName.ClientID%>")) {
                msg += " * Enter Name with Code. \n";
                if (ctrl == "")
                    ctrl = "<%=txtEmpName.ClientID%>";
                flag = false;
            }
            if (!CheckControl("<%=ddlBlockType.ClientID%>")) {
                msg += " * Select Block Type from list. \n";
                if (ctrl == "")
                    ctrl = "<%=ddlBlockType.ClientID%>";
                flag = false;
            }
            if (!CheckControl("<%=txtFrmDt.ClientID%>")) {
                msg += " * Kindly Provide From Date \n";
                if (ctrl == "")
                    ctrl = "<%=txtFrmDt.ClientID%>";
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
            <h2>Block Employee</h2>
        </div>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <ajaxToolkit:TabContainer ID="step1" runat="server" ActiveTabIndex="0" AutoPostBack="true" OnActiveTabChanged="step1_ActiveTabChanged">
                    <ajaxToolkit:TabPanel runat="server" HeaderText="Block Entry" ID="TabPanel1">
                        <ContentTemplate>
                            <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                <ContentTemplate>
                                    <table>
                                        <tr>
                                            <td>
                                                <table>
                                                    <tr>
                                                        <th>Employee Name</th>
                                                        <td>
                                                            <asp:TextBox ID="txtEmpName" runat="server" Width="200px"></asp:TextBox></td>
                                                        <td>
                                                            <asp:Button ID="btnShow" runat="server" Text="Show" OnClick="btnShow_Click" /></td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <uc1:Employee runat="server" ID="Employee1" />
                                            </td>

                                        </tr>
                                        <tr>
                                            <td>
                                                <table>
                                                    <tr>
                                                        <th>Block Type</th>
                                                        <th>From Date</th>
                                                        <th>Remark</th>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:DropDownList ID="ddlBlockType" runat="server"></asp:DropDownList></td>
                                                        <td>
                                                            <asp:TextBox ID="txtFrmDt" runat="server"></asp:TextBox></td>
                                                        <td>
                                                            <asp:TextBox ID="txtRemark" runat="server"></asp:TextBox></td>
                                                        <td>
                                                            <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" /></td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <div style="max-height: 500px; overflow: auto">
                                                    <asp:GridView ID="gvDetail" runat="server" AutoGenerateColumns="false" CssClass="gridDynamic">
                                                        <Columns>
                                                            <asp:TemplateField HeaderText="S#">
                                                                <ItemTemplate>
                                                                    <%# ((GridViewRow )Container).RowIndex+1 %>.
                                                                </ItemTemplate>
                                                                <ItemStyle Width="15px" />
                                                            </asp:TemplateField>
                                                            <asp:BoundField DataField="EMP_ID" HeaderText="Code" />
                                                            <asp:BoundField DataField="EMP_NAME" HeaderText="Name" />
                                                            <asp:BoundField DataField="DES_VALUE" HeaderText="Designation" />
                                                            <asp:BoundField DataField="FROM_DT" HeaderText="From Date" DataFormatString="{0:dd/MM/yyy}" />
                                                            <asp:BoundField DataField="TO_DATE" HeaderText="To Date" DataFormatString="{0:dd/MM/yyy}" />
                                                        </Columns>
                                                    </asp:GridView>
                                                </div>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <ajaxToolkit:CalendarExtender ID="cal1" runat="server" TargetControlID="txtFrmDt" Format="dd/MM/yyyy">
                                                </ajaxToolkit:CalendarExtender>
                                                <ajaxToolkit:MaskedEditExtender ID="me1" runat="server" Mask="99/99/9999" MaskType="Date"
                                                    TargetControlID="txtFrmDt">
                                                </ajaxToolkit:MaskedEditExtender>
                                            </td>
                                            <td>
                                                <ajaxToolkit:AutoCompleteExtender ID="autoComplete1" runat="server" CompletionInterval="500"
                                                    CompletionSetCount="12" ContextKey="1" EnableCaching="true" MinimumPrefixLength="1"
                                                    ServiceMethod="GetEmployeeList" ServicePath="~\AutoComplete.asmx" TargetControlID="txtEmpName">
                                                </ajaxToolkit:AutoCompleteExtender>
                                            </td>
                                        </tr>
                                    </table>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </ContentTemplate>
                    </ajaxToolkit:TabPanel>
                    <ajaxToolkit:TabPanel ID="TabPanel2" runat="server" HeaderText="Block Report">
                        <ContentTemplate>
                            <asp:UpdatePanel ID="up2" runat="server">
                                <ContentTemplate>
                                    <table>
                                        <tr>
                                            <td>
                                                <div style="max-height: 600px; overflow: auto">
                                                    <asp:GridView ID="gvBlock" runat="server" AutoGenerateColumns="false" CssClass="gridDynamic">
                                                        <Columns>
                                                            <asp:TemplateField HeaderText="S#">
                                                                <ItemTemplate>
                                                                    <%# ((GridViewRow )Container).RowIndex+1 %>.
                                                                </ItemTemplate>
                                                                <ItemStyle Width="15px" />
                                                            </asp:TemplateField>
                                                            <asp:BoundField DataField="EMP_ID" HeaderText="Code" />
                                                            <asp:BoundField DataField="EMP_NAME" HeaderText="Name" />
                                                            <asp:BoundField DataField="DES_VALUE" HeaderText="Designation" />
                                                            <asp:BoundField DataField="FROM_DT" HeaderText="From Date" DataFormatString="{0:dd/MM/yyy}" />
                                                            <asp:BoundField DataField="TO_DATE" HeaderText="To Date" DataFormatString="{0:dd/MM/yyy}" />
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

