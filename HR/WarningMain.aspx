<%@ Page Title="ERP | Warning Master" Language="C#" MasterPageFile="~/MasterPages/FullLength.master" AutoEventWireup="true" CodeFile="WarningMain.aspx.cs" Inherits="HR_WarningMain" %>

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
            if (!CheckAutoComplete("<%=txtEmployeeID.ClientID%>")) {
                msg += "- Enter Employee name and code. \n";+`  `                   `   
                if (ctrl == "")
                    ctrl = "<%=txtEmployeeID.ClientID%>";
                flag = false;
            }
            if (!CheckControl("<%=txtWarningSubject.ClientID%>")) {
                msg += "- Enter Subject of Warning.\n";
                if (ctrl == "")
                    ctrl = "<%=txtWarningSubject.ClientID%>";
                flag = false;
            }

            if (!CheckControl("<%=ddlWarningType.ClientID%>")) {
                msg += "- Select Item From List. \n";
                if (ctrl == "")
                    ctrl = "<%=ddlWarningType.ClientID%>";
                flag = false;
            }
            if (!CheckDate("<%=txtWarningDate.ClientID%>")) {
                msg += "- Enter Warning Date. \n";
                if (ctrl == "")
                    ctrl = "<%=txtWarningDate.ClientID%>";
                flag = false;
            }
            if (!CheckAutoComplete("<%=txtWarningGivenBy.ClientID%>")) {
                msg += "- Enter Employee code and name.\n";
                if (ctrl == "")
                    ctrl = "<%=txtWarningGivenBy.ClientID%>";
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
            <h2>Warning Master</h2>
        </div>
        <div>
            <table>
                <tr>
                    <td>
                        <table>
                            <tr>
                                <th>Employee ID</th>
                                <th>Subject Of Warning</th>
                                <th>Type Of Warning</th>
                                <th>Warning Date</th>
                            </tr>
                            <tr>
                                <td>
                                    <asp:TextBox ID="txtEmployeeID" runat="server" CssClass="textBox" Width="200px"></asp:TextBox>
                                </td>
                                <td>&nbsp;<asp:TextBox ID="txtWarningSubject" runat="server" CssClass="textBox" Width="200px"></asp:TextBox></td>
                                <td>&nbsp;<asp:DropDownList ID="ddlWarningType" runat="server" CssClass="textBox" Width="200px" Height="25px"></asp:DropDownList></td>
                                <td>&nbsp;<asp:TextBox ID="txtWarningDate" runat="server" CssClass="textBox" Width="150px"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <th>Warning Given By</th>
                                <%--<th>Upload Warning Letter</th>--%>
                            </tr>
                            <tr>
                                <td>&nbsp;
                <asp:TextBox ID="txtWarningGivenBy" runat="server" CssClass="textBox" Width="200px"></asp:TextBox>
                                </td>
                                <%--  <td colspan="2">&nbsp;<asp:FileUpload ID="FileUpload" runat="server" CssClass="textBox" Width="400px" /></td>--%>
                                <td>&nbsp;&nbsp;<asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" Width="70px" Height="25px" />
                                </td>
                            </tr>

                        </table>
                    </td>
                </tr>
                <tr>
                    <td>
                        <div style="overflow: auto; width: 100%; height: 400px">
                            <asp:GridView ID="gvShow" runat="server" AutoGenerateColumns="False" DataKeyNames="WARN_ID" OnRowCommand="gvShow_RowCommand" EmptyDataText="No Record Found">
                                <Columns>
                                    <asp:TemplateField HeaderText="S.No.">
                                        <ItemTemplate>
                                            <%# ((GridViewRow)Container).RowIndex + 1%>.
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="EMP_ID" HeaderText="Employee ID" />
                                    <asp:BoundField DataField="EMP_NAME" HeaderText="Employee Name" />
                                    <%--<asp:BoundField DataField="" HeaderText="Department Name" />
                                    <asp:BoundField DataField="" HeaderText="Designation" />--%>
                                    <asp:BoundField DataField="WARN_SUB" HeaderText=" Warning Subject" />
                                    <asp:BoundField DataField="WARN_TYPE_DESC" HeaderText="Warning Type" />
                                    <asp:BoundField DataField="WARN_DATE" HeaderText="Warning Date" />
                                    <asp:BoundField DataField="WARN_BY" HeaderText="Warning Given By" />
                                    <%-- <asp:TemplateField HeaderText="Uploded Letter">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("WARN_DOC") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:HyperLink ID="HyperLink2" runat="server" Text='<%# Bind("WARN_TYPE_DESC") %>'
                                                NavigateUrl='<%# Bind("WARN_DOC") %>' Target="_blank" />
                                        </ItemTemplate>
                                        <ControlStyle Font-Underline="True" ForeColor="Blue" />
                                        <ItemStyle Font-Underline="True" ForeColor="CornflowerBlue" Width="100px" />
                                    </asp:TemplateField>--%>
                                    <asp:CommandField ButtonType="Image" SelectImageUrl="~/Siteimages/edit.gif" ShowSelectButton="True" HeaderText="Modify">
                                        <ItemStyle Width="40px" />
                                    </asp:CommandField>
                                    <asp:TemplateField ShowHeader="False" HeaderText="Status">
                                        <ItemStyle Width="20px" HorizontalAlign="Right" />
                                        <ItemTemplate>
                                            <asp:ImageButton ID="imgAct" runat="server" CausesValidation="false" CommandArgument='<%# Bind("WARN_ID") %>'
                                                CommandName="Deactivate" ImageUrl="~/Siteimages/deactivate.gif" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td>
                        <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd/MM/yyyy"
                            TargetControlID="txtWarningDate">
                        </ajaxToolkit:CalendarExtender>
                        <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender1" runat="server" Mask="99/99/9999"
                            MaskType="Date" TargetControlID="txtWarningDate">
                        </ajaxToolkit:MaskedEditExtender>
                    </td>
                </tr>
                <tr>
                    <td>
                        <ajaxToolkit:AutoCompleteExtender ID="AutoCompleteExtender2" runat="server" CompletionSetCount="12"
                            EnableCaching="true" MinimumPrefixLength="1" ServiceMethod="GetEmployeeList"
                            ServicePath="~\AutoComplete.asmx" TargetControlID="txtEmployeeID" ContextKey="1">
                        </ajaxToolkit:AutoCompleteExtender>
                    </td>
                    <td>
                        <ajaxToolkit:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" CompletionSetCount="12"
                            EnableCaching="true" MinimumPrefixLength="1" ServiceMethod="GetEmployeeList"
                            ServicePath="~\AutoComplete.asmx" TargetControlID="txtWarningGivenBy" ContextKey="1">
                        </ajaxToolkit:AutoCompleteExtender>
                    </td>
                </tr>
            </table>

        </div>
    </div>
</asp:Content>

