<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/FullLength.master" AutoEventWireup="true" CodeFile="rptAdditionDeletion.aspx.cs" Inherits="HR_rptAdditionDeletion" %>

<%@ Register Src="../Control/MonthYear.ascx" TagName="MonthYear" TagPrefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="container">
        <div class="heading">
            <h2>Addition and Deletion
            </h2>
        </div>
        <div>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <table>
                        <tr>
                            <td>
                                <table>
                                    <tr>
                                        <td>
                                            <table>
                                                <tr>
                                                    <th>Institute</th>
                                                    <td>&nbsp;</td>
                                                    <th>Department</th>
                                                    <td>&nbsp;</td>
                                                    <th>Designation</th>
                                                    <td>&nbsp;</td>
                                                    <th>Job Type</th>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:DropDownList ID="ddlInstitute" runat="server" Width="70px" OnSelectedIndexChanged="ddlInstitute_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList></td>
                                                    <td>&nbsp;</td>
                                                    <td>
                                                        <asp:DropDownList ID="ddlDepartment" runat="server" Width="140px"></asp:DropDownList></td>
                                                    <td>&nbsp;</td>
                                                    <td>
                                                        <asp:DropDownList ID="ddlDesignation" runat="server" Width="140px"></asp:DropDownList></td>
                                                    <td>&nbsp;</td>
                                                    <td>
                                                        <asp:DropDownList ID="ddlJobType" runat="server" Width="100px"></asp:DropDownList></td>

                                                </tr>
                                                <tr>
                                                    <th>Service Type</th>
                                                    <td>&nbsp;</td>
                                                    <th colspan="3">Search Based On</th>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:DropDownList ID="ddlServiceType" runat="server" Width="100px"></asp:DropDownList></td>
                                                    <td>&nbsp;</td>

                                                    <td>
                                                        <asp:DropDownList ID="ddlSearch" runat="server" Width="100px" AutoPostBack="true" OnSelectedIndexChanged="ddlSearch_SelectedIndexChanged">
                                                            <asp:ListItem Value="0">Daily</asp:ListItem>
                                                            <asp:ListItem Value="1">Monthly</asp:ListItem>
                                                            <asp:ListItem Value="2">Yearly</asp:ListItem>
                                                            <asp:ListItem Value="3">Date Range</asp:ListItem>
                                                        </asp:DropDownList></td>
                                                    <td>&nbsp;</td>
                                                    <td>
                                                        <table>
                                                            <tbody>
                                                                <tr id="trYear" runat="server">

                                                                    <td colspan="2">
                                                                        <asp:DropDownList ID="ddlYear" runat="server">
                                                                        </asp:DropDownList>
                                                                    </td>
                                                                </tr>
                                                                <tr id="trMonth" runat="server">

                                                                    <td colspan="2">
                                                                        <uc1:MonthYear ID="MonthYear1" runat="server" />
                                                                    </td>
                                                                </tr>
                                                                <tr id="trDaily" runat="server">

                                                                    <td colspan="2">
                                                                        <asp:TextBox ID="txtDate" runat="server" Width="80px" CssClass="textbox"></asp:TextBox>
                                                                        <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtDate" Format="dd/MM/yyyy">
                                                                        </ajaxToolkit:CalendarExtender>
                                                                        <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender3" runat="server" Mask="99/99/9999" MaskType="Date"
                                                                            TargetControlID="txtDate">
                                                                        </ajaxToolkit:MaskedEditExtender>
                                                                    </td>
                                                                </tr>
                                                                <tr id="trDR" runat="server">
                                                                    <td>
                                                                        <asp:TextBox ID="txtFrm" runat="server" Width="90px" CssClass="textbox"></asp:TextBox>
                                                                        <ajaxToolkit:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtFrm" Format="dd/MM/yyyy">
                                                                        </ajaxToolkit:CalendarExtender>
                                                                        <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender1" runat="server" Mask="99/99/9999" MaskType="Date"
                                                                            TargetControlID="txtFrm">
                                                                        </ajaxToolkit:MaskedEditExtender>
                                                                    </td>
                                                                    <td>
                                                                        <asp:TextBox ID="txtTo" runat="server" Width="97px" CssClass="textbox"></asp:TextBox>
                                                                        <ajaxToolkit:CalendarExtender ID="CalendarExtender3" runat="server" TargetControlID="txtTo" Format="dd/MM/yyyy">
                                                                        </ajaxToolkit:CalendarExtender>
                                                                        <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender2" runat="server" Mask="99/99/9999" MaskType="Date"
                                                                            TargetControlID="txtTo">
                                                                        </ajaxToolkit:MaskedEditExtender>
                                                                    </td>
                                                                </tr>
                                                            </tbody>
                                                        </table>
                                                    </td>
                                                    <td>
                                                        <asp:Button ID="btnShow" runat="server" Text="Show" OnClick="btnShow_Click" />
                                                    </td>
                                                    <td>
                                                        <asp:Button ID="btnExport" runat="server" Text="Export to Excel" OnClick="btnExport_Click" /></td>
                                                </tr>

                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>

                                            <asp:GridView ID="gridAddition" CssClass="gridDynamic" Caption="Addition" runat="server" AutoGenerateColumns="False" EmptyDataText="no record found">
                                                <Columns>
                                                    <asp:TemplateField HeaderText="S.No.">
                                                        <ItemTemplate>
                                                            <%# ((GridViewRow)Container).RowIndex + 1%>
                                                        </ItemTemplate>
                                                        <ItemStyle Width="15px" />
                                                    </asp:TemplateField>
                                                    <asp:BoundField DataField="Emp_Id" HeaderText="Emp.Code" />
                                                    <asp:BoundField DataField="Emp_Name" HeaderText="Name" />
                                                    <asp:BoundField DataField="DOJ" HeaderText="DOJ" ItemStyle-Width="100px" DataFormatString="{0:dd/MM/yyyy}">
                                                        <ItemStyle Width="100px" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="Dept_Value" HeaderText="Department" ItemStyle-Width="100px">
                                                        <ItemStyle Width="100px" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="Des_Value" HeaderText="Designation" ItemStyle-Width="100px">
                                                        <ItemStyle Width="100px" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="Job_Type_Value" HeaderText="Job Type" ItemStyle-Width="100px">
                                                        <ItemStyle Width="100px" />
                                                    </asp:BoundField>
                                                </Columns>
                                            </asp:GridView>

                                        </td>

                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:GridView ID="gridDeletion" CssClass="gridDynamic" Caption="Deletion" runat="server" AutoGenerateColumns="False" EmptyDataText="no record found">
                                                <Columns>
                                                    <asp:TemplateField HeaderText="S.No.">
                                                        <ItemTemplate>
                                                            <%# ((GridViewRow)Container).RowIndex + 1%>
                                                        </ItemTemplate>
                                                        <ItemStyle Width="15px" />
                                                    </asp:TemplateField>
                                                    <asp:BoundField DataField="Emp_Id" HeaderText="Emp.Code" />
                                                    <asp:BoundField DataField="Emp_Name" HeaderText="Name" />
                                                    <asp:BoundField DataField="DOJ" HeaderText="DOJ" ItemStyle-Width="100px" DataFormatString="{0:dd/MM/yyyy}">
                                                        <ItemStyle Width="100px" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="Dept_Value" HeaderText="Department" ItemStyle-Width="100px">
                                                        <ItemStyle Width="100px" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="Des_Value" HeaderText="Designation" ItemStyle-Width="100px">
                                                        <ItemStyle Width="100px" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="Job_Type_Value" HeaderText="Job Type" ItemStyle-Width="100px">
                                                        <ItemStyle Width="100px" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="RELVNG_DATE" HeaderText="DOR" ItemStyle-Width="100px" DataFormatString="{0:dd/MM/yyyy}">
                                                        <ItemStyle Width="100px" />
                                                    </asp:BoundField>

                                                </Columns>
                                            </asp:GridView>

                                        </td>

                                    </tr>


                                </table>
                            </td>
                            <td style="width: 180px; vertical-align: top">
                                <table>
                                    <tr>

                                        <td>
                                            <h5>Total Active Employee </h5>

                                            <asp:Label ID="lblActive" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <h5>Joined Employees </h5>
                                            <asp:Label ID="lblJoined" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <h5>Relived Employees </h5>
                                            <asp:Label ID="lblRelvd" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                </table>

                            </td>
                        </tr>
                    </table>
                </ContentTemplate>
                <Triggers>
                    <asp:PostBackTrigger ControlID="btnExport" />
                </Triggers>
            </asp:UpdatePanel>
        </div>
    </div>
</asp:Content>

