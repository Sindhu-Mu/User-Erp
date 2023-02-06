<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/FullLength.master" AutoEventWireup="true" CodeFile="rptAttendanceMarked.aspx.cs" Inherits="Academic_rptAttendanceMarked" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="container">
        <div class="heading">
            <h2>Temporary Attendance
            </h2>
        </div>
        <div>
            <asp:UpdatePanel ID="up1" runat="server">
                <ContentTemplate>
                    <table>
                        <tr>
                            <td>
                                <table>
                                    <tr>
                                        <th>Institute
                                        </th>
                                        <th colspan="2">Program
                                        </th>
                                        <th>Branch
                                        </th>


                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:DropDownList ID="ddlIns" runat="server" OnSelectedIndexChanged="ddlIns_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                                        </td>
                                        <td colspan="2">
                                            <asp:DropDownList ID="ddlPgm" runat="server" OnSelectedIndexChanged="ddlPgm_SelectedIndexChanged" AutoPostBack="true" Width="250px"></asp:DropDownList>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlBranch" runat="server" Width="280px"></asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <th>Batch
                                        </th>
                                        <th>Semester
                                        </th>
                                        <th>Section
                                        </th>
                                        <th>Date
                                        </th>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:DropDownList ID="ddlBatch" runat="server"></asp:DropDownList>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlSem" runat="server"></asp:DropDownList>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlSec" runat="server"></asp:DropDownList>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtDate" runat="server"></asp:TextBox>
                                            <ajaxToolkit:CalendarExtender ID="CalendarExtender1" Format="dd/MM/yyyy" runat="server" TargetControlID="txtDate"></ajaxToolkit:CalendarExtender>
                                            <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender1" runat="server" TargetControlID="txtDate" Mask="99/99/9999"
                                                MaskType="Date">
                                            </ajaxToolkit:MaskedEditExtender>
                                        </td>
                                        <td>
                                            <asp:Button ID="btnView" runat="server" Text="View" OnClick="btnView_Click" />
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:GridView ID="gvDetail" runat="server" AutoGenerateColumns="false" CssClass="gridDynamic">
                                    <Columns>
                                        <asp:TemplateField HeaderText="S.No.">
                                            <ItemTemplate>
                                                <%# ((GridViewRow)Container).RowIndex + 1%>
                                                    .
                                            </ItemTemplate>
                                            <ItemStyle Width="20px" />
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="PAP_CODE" HeaderText="Paper Code" />
                                        <asp:BoundField DataField="ATT_DATE" HeaderText="Date" />
                                        <asp:BoundField DataField="TT_SLOT_VALUE" HeaderText="Time Slot" />
                                        <asp:BoundField DataField="NAME" HeaderText="Marked By" />
                                        <asp:BoundField DataField="TOTAL" HeaderText="Total Students" />
                                        <asp:BoundField DataField="PRESENT" HeaderText="Present" />
                                        <asp:BoundField DataField="ABSENT" HeaderText="Absent" />
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

