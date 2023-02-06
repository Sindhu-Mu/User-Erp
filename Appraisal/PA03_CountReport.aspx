<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/FullLength.master" AutoEventWireup="true" CodeFile="PA03_CountReport.aspx.cs" Inherits="Appraisal_PA03_CountReport" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="container">
        <div class="heading">
            <h2>Appraisal Counting Report</h2>
        </div>
        <div>
            <table id="tblColumns">
                <tr>
                    <td style="width: 50%; vertical-align: top">
                        <table>
                            <tr>
                                <th>Filters
                                </th>
                            </tr>

                            <tr>
                                <td>
                                    <table>
                                        <tr>
                                            <td>
                                                <table>
                                                    <tr>
                                                        <th colspan="2" style="width: 100%">By Institution
                                                        </th>
                                                        <th colspan="2" style="width: 100%">By Department</th>
                                                        <th colspan="2" style="width: 100%">By Status
                                                        </th>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="2" style="width: 200px">
                                                            <asp:DropDownList ID="ddlIns" runat="server" OnSelectedIndexChanged="ddlIns_SelectedIndexChanged" AutoPostBack="true">
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td colspan="2" style="width: 200px">
                                                            <asp:DropDownList ID="ddlDept" runat="server" Width="80px">
                                                            </asp:DropDownList>
                                                        </td>

                                                        <td colspan="2" style="width: 200px">
                                                            <asp:DropDownList ID="ddlStatus" runat="server">
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>

                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <th>Date Started</th>
                            </tr>
                            <tr>
                                <td>
                                    <table>
                                        <tr>
                                            <td colspan="2" style="width: 200px">
                                                <asp:DropDownList ID="ddlSDate" runat="server" Width="80px" AutoPostBack="true" OnSelectedIndexChanged="DateType_Change">

                                                    <asp:ListItem Value="0" Text="All"></asp:ListItem>
                                                    <asp:ListItem Value="1" Text="Less Than"></asp:ListItem>
                                                    <asp:ListItem Value="2" Text="Greater Than"></asp:ListItem>
                                                    <asp:ListItem Value="3" Text="Between"></asp:ListItem>
                                                </asp:DropDownList></td>
                                            <td colspan="2" style="width: 200px">
                                                <asp:TextBox ID="txtSSDt" runat="server" Width="95px"></asp:TextBox>&nbsp;
                                                <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtSSDt"
                                                    Format="dd/MM/yyyy">
                                                </ajaxToolkit:CalendarExtender>

                                            </td>
                                            <td colspan="2" style="width: 200px">
                                                <asp:TextBox ID="txtSEDt" runat="server" Width="95px"></asp:TextBox>&nbsp;
                                                  <ajaxToolkit:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtSEDt"
                                                      Format="dd/MM/yyyy">
                                                  </ajaxToolkit:CalendarExtender>
                                            </td>

                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <th>Date Ended
                                </th>
                            </tr>
                            <tr>
                                <td>
                                    <table>
                                        <tr>
                                            <td colspan="2" style="width: 200px">
                                                <asp:DropDownList ID="ddlEDate" runat="server" Width="80px" AutoPostBack="true" OnSelectedIndexChanged="DateType_Change">

                                                    <asp:ListItem Value="0" Text="All"></asp:ListItem>
                                                    <asp:ListItem Value="1" Text="Less Than"></asp:ListItem>
                                                    <asp:ListItem Value="2" Text="Greater Than"></asp:ListItem>
                                                    <asp:ListItem Value="3" Text="Between"></asp:ListItem>
                                                </asp:DropDownList></td>
                                            <td colspan="2" style="width: 200px">
                                                <asp:TextBox ID="txtESDt" runat="server" Width="95px"></asp:TextBox>&nbsp;
                                                 <ajaxToolkit:CalendarExtender ID="CalendarExtender3" runat="server" TargetControlID="txtESDt"
                                                     Format="dd/MM/yyyy">
                                                 </ajaxToolkit:CalendarExtender>

                                            </td>
                                            <td colspan="2" style="width: 200px">
                                                <asp:TextBox ID="txtEEDt" runat="server" Width="95px"></asp:TextBox>&nbsp;
                                                    <ajaxToolkit:CalendarExtender ID="CalendarExtender4" runat="server" TargetControlID="txtESDt"
                                                        Format="dd/MM/yyyy">
                                                    </ajaxToolkit:CalendarExtender>
                                            </td>

                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </td>
                    <td style="width: 50%; vertical-align: top">
                        <table>
                            <tr>
                                <th>Fields
                                </th>
                            </tr>
                            <tr>
                                <td>
                                    <asp:CheckBoxList ID="chkFeild" runat="server" RepeatColumns="3" RepeatDirection="Horizontal"
                                        Width="245px">                                   
                                        <asp:ListItem Value="DEPT_VALUE">Department</asp:ListItem>
                                        <asp:ListItem Value="CONVERT(VARCHAR, STARTDATE,103)">Start Date</asp:ListItem>
                                        <asp:ListItem Value="CONVERT(VARCHAR, SUBMIT_DATE,103)">Submit Date</asp:ListItem>
                                        <asp:ListItem Value="PENDING">Pending With</asp:ListItem>
                                    </asp:CheckBoxList>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Button ID="btnExecute" runat="server" Text="View" CssClass="btnBrown" Width="64px" OnClick="btnExecute_Click" /></td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">

                        <span style="font-weight: bold">No. of Records =
                    <asp:Label ID="lblCount" runat="server" Text="0"></asp:Label>
                        </span>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <table class="entry" style="width: 100%">
                            <tr>
                                <td>
                                    <asp:Panel ID="panStudent" runat="server" Height="400px" Width="97%" ScrollBars="Auto">
                                        <asp:GridView ID="gridReportInfo" runat="server" AutoGenerateColumns="True" CssClass="gridDynamic" EmptyDataText="No Records Found" Width="90%">
                                            <Columns>
                                                <asp:TemplateField HeaderText="S.No.">
                                                    <ItemTemplate>
                                                        <%# ((GridViewRow)Container).RowIndex + 1%>.
                                                    </ItemTemplate>
                                                    <ItemStyle Width="30px" />
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                    </asp:Panel>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </div>
    </div>
</asp:Content>

