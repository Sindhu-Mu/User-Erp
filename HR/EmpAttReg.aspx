<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/FullLength.master" AutoEventWireup="true" CodeFile="EmpAttReg.aspx.cs" Inherits="HR_EmpAttReg" %>

<%@ Register Src="../Control/MonthYear.ascx" TagName="MonthYear" TagPrefix="uc2" %>
<%@ Register Src="~/Control/EmpTodyaAtt.ascx" TagPrefix="uc1" TagName="EmpTodyaAtt" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="container">
        <div class="heading">
            <h2>Attendance Status
            </h2>
        </div>
        <div>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <table>

                        <tr>
                            <td>
                                <uc1:EmpTodyaAtt runat="server" ID="EmpTodyaAtt" />
                            </td>
                        </tr>
                        <tr>
                            <td valign="top">
                                <table>
                                    <tr>
                                        <th>Month/Year</th>
                                        <td>&nbsp;</td>
                                        <th>Attendance Status</th>
                                        <td>&nbsp;</td>
                                        <td></td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <uc2:MonthYear ID="MonthYear1" runat="server" />
                                        </td>
                                        <td>&nbsp;</td>
                                        <td>
                                            <asp:DropDownList ID="ddlAttType" runat="server"></asp:DropDownList></td>
                                        <td>&nbsp;</td>
                                        <td>
                                            <asp:Button ID="btnShow" runat="server" Text="Show" OnClick="btnShow_Click"/></td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:GridView ID="gridAttendance" CssClass="gridDynamic" DataKeyNames="dcDate" Caption="Month Attendance" runat="server" AutoGenerateColumns="False" OnDataBound="gridAttendance_DataBound" OnRowCommand="gridAttendance_RowCommand" >
                                    <Columns>
                                        <asp:BoundField DataField="dcDay" HeaderText="Day" />
                                        <asp:BoundField DataField="dcWeekDay" HeaderText="Week Day" />
                                        <asp:BoundField DataField="dcDutyTime" HeaderText="Shift" ItemStyle-Width="150px"/>
                                        <asp:BoundField DataField="dcInTime" HeaderText="In-Time" ItemStyle-Width="100px"/>
                                        <asp:BoundField DataField="dcOutTime" HeaderText="Out-Time" ItemStyle-Width="100px"/>                                       
                                        <asp:BoundField DataField="dcStatus" HeaderText="Status" ItemStyle-Width="300px" />
                                        <asp:CommandField ButtonType="Button" SelectText="Detail" ShowSelectButton="True" />
                                    </Columns>
                                </asp:GridView>
                            </td>
                        </tr>
                    </table>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>

</asp:Content>

