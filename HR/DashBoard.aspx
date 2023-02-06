<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DashBoard.aspx.cs" Inherits="HR_DashBoard" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Untitled Page</title>
    <link href="../css/Main.css" rel="stylesheet" type="text/css" />
</head>
<body style="width: 100%; background-color: #EBEBEB; text-align: center">
    <form id="form1" runat="server">
        <div class="container">
            <table id="tblCol">
                <tr>
                    <td>
                        <div style="text-align: center">
                            <h2>HR DashBoard
                            </h2>
                        </div>
                        <br />
                        <br />
                    </td>
                </tr>
                <tr>
                    <td>
                        <div style="text-align: center">
                            <table align="center" style="text-align: center" cellspacing="20px">
                                <tr>
                                    <td style="max-width: 33.33%; vertical-align: top">
                                        <div style="height: 220px; overflow: auto">
                                            <asp:GridView ID="gvAttendance" runat="server" Caption="Attendance"
                                                GridLines="None" CellPadding="3" EmptyDataText="No Record Found." CssClass="gridDynamic" Width="80%">
                                                <Columns>
                                                </Columns>
                                                <SelectedRowStyle BackColor="#FFC0C0" />
                                            </asp:GridView>
                                        </div>
                                    </td>
                                    <td style="max-width: 33.33%; vertical-align: top">
                                        <div style="height: 220px; overflow: auto">
                                            <asp:GridView ID="gvLongAbsent" runat="server" Width="90%" Caption="Long Absent Detail"
                                                GridLines="None" CellPadding="3" EmptyDataText="No Record Found." CssClass="gridDynamic">
                                                <Columns>
                                                </Columns>
                                                <SelectedRowStyle BackColor="#FFC0C0" />
                                            </asp:GridView>
                                        </div>
                                    </td>
                                    <td style="max-width: 33.33%; vertical-align: top">
                                        <div style="height: 220px; overflow: auto">
                                            <asp:GridView ID="gvDeptChng" runat="server"
                                                GridLines="None" CellPadding="3" EmptyDataText="No Record Found." Caption="Department Change" CssClass="gridDynamic" Width="80%">
                                                <Columns>
                                                </Columns>
                                                <SelectedRowStyle BackColor="#FFC0C0" />
                                            </asp:GridView>
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <div style="height: 220px; overflow: auto">
                                            <asp:GridView ID="gvNewJoin" runat="server" Caption="New Joining"
                                                GridLines="None" CellPadding="3" EmptyDataText="No Record Found." CssClass="gridDynamic" Width="80%">
                                                <Columns>
                                                </Columns>
                                                <SelectedRowStyle BackColor="#FFC0C0" />
                                            </asp:GridView>
                                        </div>
                                    </td>
                                    <td style="max-width: 33.33%; vertical-align: top">
                                        <div style="height: 220px; overflow: auto">
                                            <asp:GridView ID="gvReleived" runat="server" Caption="Releiving Detail"
                                                GridLines="None" CellPadding="3" EmptyDataText="No Record Found." CssClass="gridDynamic" Width="80%">
                                                <Columns>
                                                </Columns>
                                                <SelectedRowStyle BackColor="#FFC0C0" />
                                            </asp:GridView>
                                        </div>
                                    </td>
                                    <td style="max-width: 33.33%; vertical-align: top">
                                        <div style="height: 220px; overflow: auto">
                                            <asp:GridView ID="gvDeputation" runat="server" Caption="Deputation Detail"
                                                GridLines="None" CellPadding="3" EmptyDataText="No Record Found." CssClass="gridDynamic" Width="80%">
                                                <Columns>
                                                </Columns>
                                                <SelectedRowStyle BackColor="#FFC0C0" />
                                            </asp:GridView>
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="max-width: 33.33%; vertical-align: top">
                                        <div style="height: 220px; overflow: auto">
                                            <asp:GridView ID="gvEolStart" runat="server" Caption="EOL Start"
                                                GridLines="None" CellPadding="3" EmptyDataText="No Record Found." CssClass="gridDynamic" Width="80%">
                                                <Columns>
                                                </Columns>
                                                <SelectedRowStyle BackColor="#FFC0C0" />
                                            </asp:GridView>
                                        </div>
                                    </td>
                                    <td style="max-width: 33.33%; vertical-align: top">
                                        <div style="height: 220px; overflow: auto">
                                            <asp:GridView ID="gvEolFinish" runat="server" Caption="EOL Finish"
                                                GridLines="None" CellPadding="3" EmptyDataText="No Record Found." CssClass="gridDynamic" Width="80%">
                                                <Columns>
                                                </Columns>
                                                <SelectedRowStyle BackColor="#FFC0C0" />
                                            </asp:GridView>
                                        </div>
                                    </td>
                                    <td style="max-width: 33.33%; vertical-align: top">
                                        <div style="height: 220px; overflow: auto">
                                            <asp:GridView ID="gvDocument" runat="server" Caption="Employee's Document Pending"
                                                GridLines="None" CellPadding="3" EmptyDataText="No Record Found." CssClass="gridDynamic" Width="80%">
                                                <Columns>
                                                </Columns>
                                                <SelectedRowStyle BackColor="#FFC0C0" />
                                            </asp:GridView>
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="max-width: 33.33%; vertical-align: top">
                                        <div style="height: 220px; overflow: auto">
                                            <asp:GridView ID="gvAppointment" runat="server" Caption="Appointment Letter To Be Issued"
                                                GridLines="None" CellPadding="3" EmptyDataText="No Record Found." CssClass="gridDynamic" Width="80%">
                                                <Columns>
                                                </Columns>
                                                <SelectedRowStyle BackColor="#FFC0C0" />
                                            </asp:GridView>
                                        </div>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
