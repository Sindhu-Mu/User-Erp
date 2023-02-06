<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/FullLength.master" AutoEventWireup="true" CodeFile="HrDashBoard.aspx.cs" Inherits="HR_HrDashBoard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="container">
        <div style="text-align:center">
            <h2>Recent Activities
            </h2>
        </div>
        <br />
        <br />

        <div>
            <table id="tblCol">
                
                <tr>
                    <td style="width: 400px; vertical-align: top">
                        <table border="1">
                            <tr>
                                <th>Attendance
                                </th>
                            </tr>
                            <tr>
                                <td>
                                    <div style="height: 220px; overflow: auto">
                                        <asp:GridView ID="gvAttendance" runat="server" 
                                            GridLines="None" CellPadding="3" EmptyDataText="No Record Found." CssClass="gridDynamic" Width="80%">
                                            <Columns>
                                            </Columns>
                                            <SelectedRowStyle BackColor="#FFC0C0" />
                                        </asp:GridView>
                                    </div>
                                </td>
                            </tr>
                        </table>
                    </td>
                    <td style=" vertical-align: top" >
                        <table border="1">
                            <tr>
                                <th>Long Absent Detail
                                </th>
                            </tr>
                            <tr>
                                <td>
                                    <div style="height: 220px; overflow: auto">
                                        <asp:GridView ID="gvLongAbsent" runat="server" Width="90%" 
                                            GridLines="None" CellPadding="3" EmptyDataText="No Record Found." CssClass="gridDynamic">
                                            <Columns>
                                            </Columns>
                                            <SelectedRowStyle BackColor="#FFC0C0" />
                                        </asp:GridView>
                                    </div>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td style="width: 400px; vertical-align: top">
                        <table border="1">
                            <tr>
                                <th>New Joining
                                </th>
                            </tr>
                            <tr>
                                <td>
                                    <div style="height: 220px; overflow: auto">
                                        <asp:GridView ID="gvNewJoin" runat="server" 
                                            GridLines="None" CellPadding="3" EmptyDataText="No Record Found." CssClass="gridDynamic" Width="80%">
                                            <Columns>
                                            </Columns>
                                            <SelectedRowStyle BackColor="#FFC0C0" />
                                        </asp:GridView>
                                    </div>
                                </td>
                            </tr>
                        </table>
                    </td>
                    <td style="width: 400px; vertical-align: top">
                        <table border="1">
                            <tr>
                                <th>Releiving Detail
                                </th>
                            </tr>
                            <tr>
                                <td>
                                    <div style="height: 220px; overflow: auto">
                                        <asp:GridView ID="gvReleived" runat="server" 
                                            GridLines="None" CellPadding="3" EmptyDataText="No Record Found." CssClass="gridDynamic" Width="80%">
                                            <Columns>
                                            </Columns>
                                            <SelectedRowStyle BackColor="#FFC0C0" />
                                        </asp:GridView>
                                    </div>
                                </td>
                            </tr>
                        </table>
                    </td>

                </tr>
                <tr>

                    <td style="width: 400px; vertical-align: top">
                        <table border="1">
                            <tr>
                                <th>EOL Start 
                                </th>
                            </tr>
                            <tr>
                                <td>
                                    <div style="height: 220px; overflow: auto">
                                        <asp:GridView ID="gvEolStart" runat="server" 
                                            GridLines="None" CellPadding="3" EmptyDataText="No Record Found." CssClass="gridDynamic" Width="80%" >
                                            <Columns>
                                            </Columns>
                                            <SelectedRowStyle BackColor="#FFC0C0" />
                                        </asp:GridView>
                                    </div>
                                </td>
                            </tr>
                        </table>
                    </td>
                    <td style="width: 400px; vertical-align: top">
                        <table border="1">
                            <tr>
                                <th>EOL Finish
                                </th>
                            </tr>
                            <tr>
                                <td>
                                    <div style="height: 220px; overflow: auto">
                                        <asp:GridView ID="gvEolFinish" runat="server" 
                                            GridLines="None" CellPadding="3" EmptyDataText="No Record Found." CssClass="gridDynamic" Width="80%" >
                                            <Columns>
                                            </Columns>
                                            <SelectedRowStyle BackColor="#FFC0C0" />
                                        </asp:GridView>
                                    </div>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>


                    <td style="width: 400px; vertical-align: top">
                        <table border="1">
                            <tr>
                                <th>Department Change
                                </th>
                            </tr>
                            <tr>
                                <td>
                                    <div style="height: 220px; overflow: auto">
                                        <asp:GridView ID="gvDeptChng" runat="server" 
                                            GridLines="None" CellPadding="3" EmptyDataText="No Record Found." CssClass="gridDynamic" Width="80%">
                                            <Columns>
                                            </Columns>
                                            <SelectedRowStyle BackColor="#FFC0C0" />
                                        </asp:GridView>
                                    </div>
                                </td>
                            </tr>
                        </table>
                    </td>
                    <td style="width: 400px; vertical-align: top">
                        <table border="1">
                            <tr>
                                <th>Deputation Detail
                                </th>
                            </tr>
                            <tr>
                                <td>
                                    <div style="height: 220px; overflow: auto">
                                        <asp:GridView ID="gvDeputation" runat="server" 
                                            GridLines="None" CellPadding="3" EmptyDataText="No Record Found." CssClass="gridDynamic" Width="80%">
                                            <Columns>
                                            </Columns>
                                            <SelectedRowStyle BackColor="#FFC0C0" />
                                        </asp:GridView>
                                    </div>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>

                    <td style="width: 400px; vertical-align: top">
                        <table border="1">
                            <tr>
                                <th>Appointment Letter To Be Issued
                                </th>
                            </tr>
                            <tr>
                                <td>
                                    <div style="height: 220px; overflow: auto">
                                        <asp:GridView ID="gvAppointment" runat="server" 
                                            GridLines="None" CellPadding="3" EmptyDataText="No Record Found." CssClass="gridDynamic" Width="80%">
                                            <Columns>
                                            </Columns>
                                            <SelectedRowStyle BackColor="#FFC0C0" />
                                        </asp:GridView>
                                    </div>
                                </td>
                            </tr>
                        </table>
                    </td>
                    <td style="width: 400px; vertical-align: top">
                        <table border="1">
                            <tr>
                                <th>Employee's Document Pending
                                </th>
                            </tr>
                            <tr>
                                <td>
                                    <div style="height: 220px; overflow: auto">
                                        <asp:GridView ID="gvDocument" runat="server" 
                                            GridLines="None" CellPadding="3" EmptyDataText="No Record Found." CssClass="gridDynamic" Width="80%">
                                            <Columns>
                                            </Columns>
                                            <SelectedRowStyle BackColor="#FFC0C0" />
                                        </asp:GridView>
                                    </div>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                </table>
        </div>
    </div>
</asp:Content>

