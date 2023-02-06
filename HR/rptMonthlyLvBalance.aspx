<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Short.master" AutoEventWireup="true" CodeFile="rptMonthlyLvBalance.aspx.cs" Inherits="HR_rptMonthlyLvBalance" %>

<%@ Register Src="../Control/MonthYear.ascx" TagName="MonthYear" TagPrefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentHolder1" runat="Server">
    <div class="container">
        <div class="heading">
            <h2>Monthly Leave Balance</h2>
        </div>
        <div>
            <table>
                <tr>
                    <th style="min-width: 200px">Institution
                    </th>
                    <th>Department
                    </th>
                    <th>Employee
                    </th>
                    <th>Job Type
                    </th>
                </tr>
                <tr>
                     <td style="min-width: 200px">
                        <asp:DropDownList ID="ddlIns" runat="server"></asp:DropDownList>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlDept" runat="server"></asp:DropDownList>
                    </td>
                    <td>
                        <asp:TextBox ID="txtEmployee" runat="server"></asp:TextBox>
                        <ajaxToolkit:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" CompletionInterval="500"
                            CompletionSetCount="12" ContextKey="1" EnableCaching="true" MinimumPrefixLength="1"
                            ServiceMethod="GetEmployeeList" ServicePath="~\AutoComplete.asmx" TargetControlID="txtEmployee">
                        </ajaxToolkit:AutoCompleteExtender>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlJobType" runat="server"></asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <th>Leave Type</th>
                    <th>Month & Year</th>
                </tr>
                <tr>
                    <td style="min-width: 200px; font-size: smaller">
                        <asp:CheckBoxList ID="chLeaveType" runat="server" Font-Bold="True" RepeatLayout="Flow">
                            <asp:ListItem Value="1" Text="Academic Leave"></asp:ListItem>
                            <asp:ListItem Value="2" Text="Casual Leave"></asp:ListItem>
                            <asp:ListItem Value="3" Text="Compensatory Leave"></asp:ListItem>
                            <asp:ListItem Value="4" Text="Earned Leave"></asp:ListItem>
                            <asp:ListItem Value="8" Text="Medical Leave"></asp:ListItem>
                            <asp:ListItem Value="10" Text="Vacation Leave"></asp:ListItem>
                        </asp:CheckBoxList>
                    </td>
                    <td style="vertical-align: top">
                        <uc2:MonthYear ID="MonthYear2" runat="server" />
                    </td>

                    <td></td>
                    <td style="vertical-align: top">
                        <asp:Button ID="btnShow" runat="server" Text="Show" OnClick="btnShow_Click" />
                    </td>
                </tr>
                <tr>
                    <td colspan="4">
                        <div style="height: 400px; overflow: auto">
                            <asp:GridView ID="gvDetail" runat="server" AutoGenerateColumns="false" CssClass="gridDynamic" DataKeyNames="EMP_ID">
                                <Columns>
                                    <asp:TemplateField HeaderText="S.No.">
                                        <ItemTemplate><%#((GridViewRow)Container).RowIndex+1 %>.</ItemTemplate>
                                        <ItemStyle Width="15px" />
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="EMP_ID" HeaderText="Emp Code" />
                                    <asp:BoundField DataField="EMP_NAME" HeaderText="Name" />
                                    <asp:BoundField DataField="DOJ" DataFormatString="{0:dd/MM/yyyy}" HeaderText="Date Of Joining" />
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            <table cellpadding="1" border="0" cellspacing="0" width="100%">
                                                <tr>
                                                    <th style="width: 120px">Leave Type</th>
                                                    <th style="width: 80px">Opening</th>
                                                    <th style="width: 80px">Availed</th>
                                                    <th style="width: 80px">Balance</th>
                                                </tr>
                                            </table>
                                        </HeaderTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Repeater ID="Repeater1" runat="server">
                                                <ItemTemplate>
                                                    <table cellpadding="1" border="0" cellspacing="0" width="100%">
                                                        <tr>
                                                             <td style="width: 120px">
                                                                <%# DataBinder.Eval(Container.DataItem, "LV_VALUE")%>
                                                            </td>
                                                            <td style="width: 80px">
                                                                <%# DataBinder.Eval(Container.DataItem, "OP")%>
                                                            </td>
                                                            <td style="width: 80px">
                                                                <%# DataBinder.Eval(Container.DataItem, "AVL")%>
                                                            </td>
                                                            <td style="width: 80px">
                                                                <%# DataBinder.Eval(Container.DataItem, "BL")%>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </ItemTemplate>
                                            </asp:Repeater>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </div>
                    </td>
                </tr>
            </table>
        </div>
    </div>
</asp:Content>

