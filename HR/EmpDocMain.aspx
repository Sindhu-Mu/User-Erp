<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/FullLength.master" AutoEventWireup="true" CodeFile="EmpDocMain.aspx.cs" Inherits="HR_EmpDocMain" %>


<%@ Register Src="../Control/Employee.ascx" TagName="Employee" TagPrefix="uc1" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script lang="javascript" type="text/javascript">

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
            if (!CheckAutoComplete("<%=txtEmp.ClientID%>")) {
                msg += " * Enter Name with Code. \n";
                if (ctrl == "")
                    ctrl = "<%=txtEmp.ClientID%>";
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
            <h2>Document Collection </h2>
        </div>
        <div>
            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                <ContentTemplate>
                    <table>
                        <tr>
                            <td  style="min-width:900px;" align="right">
                                <table style="text-align: left;">
                                    <tr>
                                       
                                        <td>
                                            <asp:TextBox ID="txtEmp" runat="server" CssClass="textBox" Width="228px" placeholder="Employee Name or Code"></asp:TextBox>
                                            <ajaxToolkit:AutoCompleteExtender ID="AutoCompleteExtender2" runat="server" CompletionSetCount="12"
                                                        EnableCaching="true" MinimumPrefixLength="1" ServiceMethod="GetEmployeeList"
                                                        ServicePath="~\AutoComplete.asmx" TargetControlID="txtEmp" ContextKey="1,2,0,3">
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

                                <uc1:Employee ID="Employee1" runat="server" />

                            </td>
                        </tr>
                        <tr>
                            <td>
                                <div runat="server" style="overflow: auto; max-height: 430px">
                                    <asp:GridView ID="gvDocument" runat="server" Caption="Document Information" DataKeyNames="DOC_ID,DOC_DTL_ID" AutoGenerateColumns="False"
                                        Width="99%" CssClass="gridDynamic" OnRowCommand="gvDocument_RowCommand">
                                        <Columns>
                                            <asp:TemplateField HeaderText="S.No.">
                                                <ItemTemplate>
                                                    <%# ((GridViewRow)Container).RowIndex + 1%>
                                                </ItemTemplate>
                                                <ItemStyle Width="15px" />
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="DOC_NAME" HeaderText="Document Name" />
                                            <asp:TemplateField HeaderText="Document Status">

                                                <ItemTemplate>
                                                    <asp:RadioButtonList ID="Rlist1" runat="server" RepeatDirection="Horizontal"
                                                        Width="200px" Font-Bold="True">
                                                        <asp:ListItem Value="True">Collected</asp:ListItem>
                                                        <asp:ListItem Value="False" Selected="True">Pending</asp:ListItem>
                                                    </asp:RadioButtonList>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="COLLECTED_BY" HeaderText="Collected  By" />
                                            <asp:BoundField DataField="COLLECTED_DT" DataFormatString="{0:dd/MM/yyyy}" HeaderText="Collected Date" />
                                            <asp:TemplateField HeaderText="Remark">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="txtRemark" runat="server" Text='<%# Bind("DOC_REMARK")%>' Width="131px"></asp:TextBox>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                    <input id="chkAll" onclick="javascript: SelectAllCheckboxes(this);" type="checkbox"
                                                        value="on" runat="server" />All
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:CheckBox ID="ChSelect" runat="server" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField ShowHeader="False" HeaderText="Visible">
                                                <ItemStyle Width="20px" HorizontalAlign="Right" />
                                                <ItemTemplate>
                                                    <asp:ImageButton ID="imgStatus" runat="server" CausesValidation="false" CommandArgument='<%# Bind("DOC_DTL_ID") %>'
                                                        ImageUrl='<%# Bind("STS_IMG") %>' CommandName='<%# Bind("STS_CMD") %>' ToolTip='<%# Bind("STS_TOOLTIP")%>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </div>
                            </td>
                        </tr>
                    
                        <tr id="trAdd" runat="server">
                            <td>
                                <table>
                                    <tr>
                                        <td>
                                            <b>Document Name</b></td>
                                        <td>
                                            <b>Document Status</b></td>
                                        <td>
                                            <b>Remark</b></td>
                                        <td></td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:DropDownList ID="ddlDocument" runat="server" Width="200px">
                                            </asp:DropDownList></td>
                                        <td>
                                            <asp:DropDownList ID="ddlStatus" runat="server" Width="120px">
                                                <asp:ListItem Value="1">Collected</asp:ListItem>
                                                <asp:ListItem Value="0">Pending</asp:ListItem>
                                            </asp:DropDownList></td>
                                        <td>
                                            <asp:TextBox ID="txtDocRemark" runat="server" Width="200px" CssClass="textbox"></asp:TextBox></td>
                                        <td>
                                            <asp:Button ID="btnAdd" runat="server" Text="Add New" CssClass="btnBrown" OnClick="btnAdd_Click" /></td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                            <tr>
                            <td>
                                <asp:Button ID="btnSave" runat="server" Text="Save" Width="60px" OnClick="btnSave_Click" />&nbsp;
                                <asp:Button ID="btnCancel" runat="server" Text="Cancel" Width="60px" />
                                  <asp:Button ID="btnLeave" runat="server" Text="Leave Open" OnClick="btnLeave_Click" />                              
                                <asp:TextBox ID="txtData" runat="server" Visible="False"></asp:TextBox>

                            </td>
                        </tr>
                        <tr>
                            <td>
                                <ajaxToolkit:AutoCompleteExtender ID="autoComplete1" runat="server" CompletionInterval="500"
                                    CompletionSetCount="12" ContextKey="1" EnableCaching="true" MinimumPrefixLength="1"
                                    ServiceMethod="GetEmployeeList" ServicePath="~\AutoComplete.asmx" TargetControlID="txtEmp">
                                </ajaxToolkit:AutoCompleteExtender>
                            </td>
                        </tr>

                    </table>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
</asp:Content>

