<%@ Page Title="ERP | Employee Document Status" Language="C#" MasterPageFile="~/MasterPages/Short.master" AutoEventWireup="true" CodeFile="EmpDocSts.aspx.cs" Inherits="HR_EmpDocSts" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentHolder1" runat="Server">
    <script language="javascript" type="text/javascript">
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
            if (bTrim(document.getElementById(ctrl).value) == "" || bTrim(document.getElementById(ctrl).value) == "Select") {
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
                msg += "- Enter Employee Name and Code\n";
                if (ctrl == "")
                    ctrl = "<%=txtEmp.ClientID%>";
                flag = false;
            }
            if (!CheckDate("<%=txtDate.ClientID%>")) {
                msg += "- Enter Date of Receiving \n";
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
            <h2>Document Submission </h2>
        </div>
        <div>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <table>
                        <tr>
                            <td>
                                <table>
                                    <tr>
                                        <th>Employee Name<span class="required">*</span></th>
                                        <td>&nbsp;</td>
                                        <th>Submitting Date<span class="required">*</span></th>
                                        <td>&nbsp;</td>
                                        <th>Remark</th>
                                        <td>&nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:TextBox ID="txtEmp" runat="server" Width="200px"></asp:TextBox></td>
                                        <td>&nbsp;</td>
                                        <td>
                                            <asp:TextBox ID="txtDate" runat="server" Width="100px"></asp:TextBox></td>
                                        <td>&nbsp;</td>
                                        <td>
                                            <asp:TextBox ID="txtReamrk" runat="server" Width="233px"></asp:TextBox></td>

                                        <td>
                                            <asp:Button ID="btnSave" runat="server" Text="Save" Width="70px" OnClick="btnSave_Click" /></td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:GridView ID="grdShow" runat="server" AutoGenerateColumns="false" EmptyDataText="No Record Found" CssClass="gridDynamic" DataKeyNames="DOC_STS_ID" OnRowCommand="grdShow_RowCommand">
                                    <Columns>
                                        <asp:TemplateField HeaderText="S.No.">
                                            <ItemTemplate>
                                                <%# ((GridViewRow)Container).RowIndex + 1%>
                                            </ItemTemplate>
                                            <ItemStyle Width="20px" />
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="EMP_ID" HeaderText="Employee ID" />
                                        <asp:BoundField DataField="EMP_NAME" HeaderText="Employee Name" />
                                        <asp:BoundField DataField="DEPT_VALUE" HeaderText="Department Name" />
                                        <asp:BoundField DataField="DES_VALUE" HeaderText="Designation" />
                                        <asp:BoundField DataField="REMARK" HeaderText="Remark" />
                                        <asp:CommandField ButtonType="Image" SelectImageUrl="~/Siteimages/edit.gif" ShowSelectButton="True" HeaderText="Modify">
                                            <ItemStyle Width="40px" />
                                        </asp:CommandField>
                                        <asp:TemplateField ShowHeader="False" HeaderText="Status">
                                            <ItemStyle Width="20px" HorizontalAlign="Right"  />
                                            <ItemTemplate>
                                                <asp:ImageButton ID="imgAct" runat="server" CausesValidation="false" CommandArgument='<%# Bind("DOC_STS_ID") %>'
                                                    ImageUrl='<%# Bind("STS_IMG") %>' CommandName='<%# Bind("STS_CMD") %>' ToolTip='<%# Bind("STS_TOOLTIP")%>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                    </Columns>
                                </asp:GridView>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <ajaxToolkit:AutoCompleteExtender ID="autoComplete1" runat="server" CompletionInterval="500"
                                    CompletionSetCount="12" ContextKey="1" EnableCaching="true" MinimumPrefixLength="1"
                                    ServiceMethod="GetEmployeeList" ServicePath="~\AutoComplete.asmx" TargetControlID="txtEmp">
                                </ajaxToolkit:AutoCompleteExtender>
                                <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd/MM/yyyy"
                                    TargetControlID="txtDate">
                                </ajaxToolkit:CalendarExtender>
                                <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender1" runat="server" Mask="99/99/9999"
                                    MaskType="Date" TargetControlID="txtDate">
                                </ajaxToolkit:MaskedEditExtender>
                            </td>
                        </tr>
                    </table>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
</asp:Content>

