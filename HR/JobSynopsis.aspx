<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/FullLength.master" AutoEventWireup="true" CodeFile="JobSynopsis.aspx.cs" Inherits="HR_JobSynopsis" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="container">
        <div class="heading">
            <h2>Job Synopsis
            </h2>
        </div>
        <div>
            <table>
                <tr>
                    <td>
                        <table>
                            <tr>
                                <td>
                                    <table>
                                        <tr>
                                            <th>Institute
                                            </th>
                                            <td>
                                                <asp:DropDownList ID="ddlIns" runat="server" OnSelectedIndexChanged="ddlIns_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                                            </td>
                                            <th>Department
                                            </th>
                                            <td>
                                                <asp:DropDownList ID="ddlDept" runat="server" OnSelectedIndexChanged="ddlDept_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                                            </td>
                                            <th>Job No.</th>
                                            <td>
                                                <asp:DropDownList ID="ddlJob" runat="server" OnSelectedIndexChanged="ddlJob_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>

                            <tr>
                                <td>
                                    <table>
                                        <tr>
                                            <td>
                                                <div>
                                                    <asp:GridView ID="gvDetails" runat="server" AutoGenerateColumns="false" CssClass="gridDynamic" EmptyDataText="No Record Found">
                                                        <Columns>
                                                            <asp:TemplateField HeaderText="S.No.">
                                                                <ItemTemplate><%#((GridViewRow)Container).RowIndex+1 %>.</ItemTemplate>
                                                                <ItemStyle Width="15px" />
                                                            </asp:TemplateField>
                                                            <asp:BoundField DataField="NAME" HeaderText="Name" />
                                                            <asp:BoundField DataField="CONTACT_NO" HeaderText="Contact No." />
                                                            <asp:BoundField DataField="LOCATION" HeaderText="Location" />
                                                            <asp:BoundField DataField="DATE" HeaderText="Interview Date" />
                                                            <asp:BoundField DataField="ATTENDANCE" HeaderText="Present/Absent" />
                                                            <asp:BoundField DataField="INT_ROUND" HeaderText="Round" />
                                                            <asp:BoundField DataField="STATUS" HeaderText="Status" />
                                                        </Columns>
                                                    </asp:GridView>
                                                </div>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Button ID="btnPrint" runat="server" Text="Print" OnClick="btnPrint_Click" Visible="false" />
                                </td>
                            </tr>
                        </table>
                    </td>
                    <td style="vertical-align: top" id="tdCount" runat="server" visible="false">
                        <table>
                            <tr>
                                <td>Total:<asp:Label ID="lblTotal" runat="server" Font-Bold="true"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>Joined:<asp:Label ID="lblJoin" runat="server" Font-Bold="true"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>Selected:<asp:Label ID="lblSelected" runat="server" Font-Bold="true"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>Not Selected:<asp:Label ID="lblNotSelected" runat="server" Font-Bold="true"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>Present:<asp:Label ID="lblPresent" runat="server" Font-Bold="true"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>Absent:<asp:Label ID="lblAbsent" runat="server" Font-Bold="true"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </div>
    </div>
</asp:Content>

