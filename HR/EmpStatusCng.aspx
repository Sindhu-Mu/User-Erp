<%@ Page Title="ERP | Employee Status Change" Language="C#" MasterPageFile="~/MasterPages/Short.master" AutoEventWireup="true" CodeFile="EmpStatusCng.aspx.cs" Inherits="HR_EmpStatusCng" %>

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
        function validat() {

            var flag = true;
            var msg = "", ctrl = "";
            if (!CheckAutoComplete("<%=txtEmp.ClientID%>")) {
                msg += "- Enter Employee Name & Code\n";
                if (ctrl == "")
                    ctrl = "<%=txtEmp.ClientID%>";
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
            if (!CheckControl("<%=ddlStatus.ClientID%>")) {
                msg += "- Select status from list\n";
                if (ctrl == "")
                    ctrl = "<%=ddlStatus.ClientID%>";
                flag = false;
            }
            if (!CheckAutoComplete("<%=txtEmp.ClientID%>")) {
                msg += "- Enter Employee Name & Code\n";
                if (ctrl == "")
                    ctrl = "<%=txtEmp.ClientID%>";
                flag = false;
            }

            if (!CheckControl("<%=txtDate.ClientID%>")) {
                msg += "- Enter Date \n";
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
            <h2>Employee Status Change</h2>
        </div>
        <div>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>

                    <div style="float: right;">
                        <table>
                            <tr>

                                <th>Employee<span class="required">*</span></th>
                                <td>
                                    <asp:TextBox ID="txtEmp" runat="server" Width="250px"></asp:TextBox>
                                    <ajaxToolkit:AutoCompleteExtender ID="autoComplete1" runat="server" CompletionInterval="500"
                                        CompletionSetCount="12" ContextKey="0,1,2,3,4" EnableCaching="true" MinimumPrefixLength="1"
                                        ServiceMethod="GetEmployeeList" ServicePath="~\AutoComplete.asmx" TargetControlID="txtEmp">
                                    </ajaxToolkit:AutoCompleteExtender>
                                </td>
                                <td>
                                    <asp:Button ID="btnView" runat="server" Text="View" OnClick="btnView_Click" />
                                </td>
                            </tr>
                        </table>
                    </div>
                    <div class="cleaner"></div>
                    <div>
                        <uc1:Employee ID="Employee" runat="server" />
                    </div>
                    <div>
                        <table>
                            <tr>

                                <th>Status <span class="required">*</span></th>
                                <td>&nbsp;</td>
                                <th>Form Date <span class="required">*</span></th>
                                <td>&nbsp; 
                                    <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd/MM/yyyy"
                                        TargetControlID="txtDate">
                                    </ajaxToolkit:CalendarExtender>
                                </td>

                            </tr>
                            <tr>

                                <td>
                                    <asp:DropDownList ID="ddlStatus" runat="server" Width="170px" AutoPostBack="True">
                                    </asp:DropDownList></td>
                                <td>&nbsp;</td>

                                <td>
                                    <asp:TextBox ID="txtDate" runat="server" CssClass="textBox" Width="100px"></asp:TextBox></td>
                                <td>
                                    <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" Width="50px" /></td>
                            </tr>
                        </table>
                    </div>
                    <div style="overflow: auto; width: 100%; height: 400px">
                        <asp:GridView ID="GridShow" runat="server" AutoGenerateColumns="False" Width="100%"
                            DataKeyNames="ID" CssClass="gridDynamic">
                            <Columns>
                                <asp:TemplateField HeaderText="S.No.">
                                    <ItemTemplate>
                                        <%# ((GridViewRow)Container).RowIndex + 1%>                                .
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="EMP_ID" HeaderText="Employee ID" />
                                <asp:BoundField DataField="EMP_NAME" HeaderText="Employee Name" />
                                <asp:BoundField DataField="STS_VALUE" HeaderText="Status" />
                                <asp:BoundField DataField="FRM_DATE" HeaderText="From Date" DataFormatString="{0:dd/MM/yyyy}" />
                                <asp:BoundField DataField="TO_DATE" DataFormatString="{0:dd/MM/yyyy}" HeaderText="To Date" />
                            </Columns>
                        </asp:GridView>
                    </div>

                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>

</asp:Content>

