<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/FullLength.master" AutoEventWireup="true" CodeFile="ApplicantAttendance.aspx.cs" Inherits="HR_ApplicantAttendance" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="container">
        <div class="heading">
            <h2>Applicant Attendance
            </h2>
        </div>
        <div>
            <table>
                <tr>
                    <td>
                        <table>
                            <tr>
                                <th>Job No.
                                </th>
                                <th>Round
                                </th>
                                <th>Interview Datetime
                                </th>

                            </tr>
                            <tr>
                                <td>
                                    <asp:DropDownList ID="ddlJob" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlJob_SelectedIndexChanged"></asp:DropDownList>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlRound" runat="server" OnSelectedIndexChanged="ddlRound_SelectedIndexChanged" AutoPostBack="true">
                                        <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                        <asp:ListItem Text="1st Round" Value="1"></asp:ListItem>
                                        <asp:ListItem Text="2nd Round" Value="2"></asp:ListItem>
                                        <asp:ListItem Text="3rd Round" Value="3"></asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlInt" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlInt_SelectedIndexChanged"></asp:DropDownList>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr id="trAtt" runat="server" visible="false">
                    <td style="text-align: center">
                        <table>
                            <tr>
                                <td style="text-align: center">
                                    <div style="min-width: 350px; overflow: auto">
                                        <asp:GridView ID="gvAttendance" runat="server" AutoGenerateColumns="false" Caption="Mark Attendance" CssClass="gridDynamic" DataKeyNames="INT_SUB_ID" EmptyDataText="No Record Found">
                                            <Columns>
                                                <asp:TemplateField HeaderText="S.No.">
                                                    <ItemTemplate><%#((GridViewRow)Container).RowIndex+1 %>.</ItemTemplate>
                                                    <ItemStyle Width="15px" />
                                                </asp:TemplateField>
                                                <asp:BoundField DataField="NAME" HeaderText="Name" />
                                                <asp:TemplateField HeaderText="Attendance">
                                                    <ItemTemplate>
                                                        <asp:RadioButtonList ID="rbAttendance" runat="server" RepeatDirection="Horizontal" Enabled="true">
                                                            <asp:ListItem Text="Present" Value="9" ></asp:ListItem>
                                                            <asp:ListItem Text="Absent" Value="10"></asp:ListItem>
                                                        </asp:RadioButtonList>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align: right">
                                    <asp:TextBox ID="TextBox1" runat="server" Visible="false"></asp:TextBox>
                                    <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" Visible="false" />
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </div>
    </div>
</asp:Content>

