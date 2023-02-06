<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/FullLength.master" AutoEventWireup="true" CodeFile="RoleTransfer.aspx.cs" Inherits="Admin_RoleTransfer" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script lang="javascript" type="text/javascript">
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
    </script>
    <div class="container">
        <div class="heading">
            <h2>Role Transfer</h2>
        </div>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <table>
                    <tr>
                        <td align="right">
                            <table>
                                <tr>
                                    <th>Employee name & code </th>
                                    <td>
                                        <asp:TextBox ID="txtemp" runat="server" Width="200PX"></asp:TextBox></td>
                                    <td>
                                        <asp:Button ID="btnShow" runat="server" Text="Show" OnClick="btnShow_Click" /></td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td>

                            <asp:GridView ID="gvRole" runat="server" AutoGenerateColumns="false" CssClass="gridDynamic" DataKeyNames="USR_ROLE_ID,ROLE_ID,USR_TRAN_ID">
                                <Columns>
                                    <asp:TemplateField HeaderText="S.No">
                                        <ItemTemplate>
                                            <%#((GridViewRow)Container).RowIndex +1 %>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="USR_LOGIN_ID" HeaderText="Emp Id" />
                                    <asp:BoundField DataField="USR_NAME" HeaderText="Employee Name" />
                                    <asp:BoundField DataField="ROLE_VALUE" HeaderText="Role" />
                                    <asp:BoundField DataField="FROM_DT" HeaderText="From Date" DataFormatString="{0:dd/MM/yyyy}" />
                                    <asp:BoundField DataField="INS_DEPT" HeaderText="Institute/Department" />
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            <input id="chkAll" onclick="javascript: SelectAllCheckboxes(this);" type="checkbox"
                                                value="on" runat="server" checked='<%# Bind("ACTIVE") %>' />
                                            All
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:CheckBox ID="chk" runat="server" />
                                        </ItemTemplate>
                                        <ItemStyle Width="40px" />
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <table id="trDetail" runat="server">
                                <tr>
                                    <th>Assign Employee</th>
                                    <th>From Date</th>
                                    <td></td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:TextBox ID="txtNewEmp" runat="server" Width="200px"></asp:TextBox></td>
                                    <td>
                                        <asp:TextBox ID="txtDate" runat="server"></asp:TextBox></td>
                                    <td>
                                        <asp:Button ID="btnAssign" runat="server" Text="Assign" OnClick="btnAssign_Click" /></td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <ajaxToolkit:AutoCompleteExtender ID="AutoCompleteExtender2" runat="server" CompletionSetCount="12"
                                EnableCaching="true" MinimumPrefixLength="1" ServiceMethod="GetEmployeeList"
                                ServicePath="~\AutoComplete.asmx" TargetControlID="txtemp" ContextKey="0,1,2">
                            </ajaxToolkit:AutoCompleteExtender>
                            <ajaxToolkit:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" CompletionSetCount="12"
                                EnableCaching="true" MinimumPrefixLength="1" ServiceMethod="GetEmployeeList"
                                ServicePath="~\AutoComplete.asmx" TargetControlID="txtNewEmp" ContextKey="1">
                            </ajaxToolkit:AutoCompleteExtender>
                            <ajaxToolkit:CalendarExtender ID="CalendarExtender1" Format="dd/MM/yyyy" runat="server" TargetControlID="txtDate"></ajaxToolkit:CalendarExtender>
                            <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender1" runat="server" TargetControlID="txtDate" Mask="99/99/9999"
                                MaskType="Date">
                            </ajaxToolkit:MaskedEditExtender>
                        </td>

                    </tr>
                </table>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</asp:Content>

