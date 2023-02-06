<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Short.master" AutoEventWireup="true" CodeFile="rptBirthday.aspx.cs" Inherits="HR_rptBirthday" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentHolder1" runat="Server">
    <div class="container">
        <div class="heading">
            <h2>Birthday Report</h2>
        </div>
        <div>
            <table>
                <tr>
                    <th>Institution
                    </th>
                    <th>Department
                    </th>
                    <th>Month
                    </th>
                </tr>
                <tr>
                    <td>
                        <asp:DropDownList ID="ddlIns" runat="server" OnSelectedIndexChanged="ddlIns_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlDept" runat="server"></asp:DropDownList>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlMonth" runat="server">
                            <asp:ListItem Text="Select" Value="."></asp:ListItem>
                            <asp:ListItem Text="January" Value="01"></asp:ListItem>
                            <asp:ListItem Text="February" Value="02"></asp:ListItem>
                            <asp:ListItem Text="March" Value="03"></asp:ListItem>
                            <asp:ListItem Text="April" Value="04"></asp:ListItem>
                            <asp:ListItem Text="May" Value="05"></asp:ListItem>
                            <asp:ListItem Text="June" Value="06"></asp:ListItem>
                            <asp:ListItem Text="July" Value="07"></asp:ListItem>
                            <asp:ListItem Text="August" Value="08"></asp:ListItem>
                            <asp:ListItem Text="September" Value="09"></asp:ListItem>
                            <asp:ListItem Text="October" Value="10"></asp:ListItem>
                            <asp:ListItem Text="November" Value="11"></asp:ListItem>
                            <asp:ListItem Text="December" Value="12"></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td>
                        <asp:Button ID="btnShow" runat="server" Text="Show" OnClick="btnShow_Click" />
                    </td>
                    <td>
                        <asp:Button ID="btnExport" runat="server" Text="Export To Excel" OnClick="btnExport_Click" />
                    </td>
                </tr>
                <tr>
                    <td colspan="5">
                        <asp:GridView ID="gvBirthDetail" runat="server" AutoGenerateColumns="false" CssClass="gridDynamic">
                            <Columns>
                                <asp:BoundField HeaderText="S#" HtmlEncode="False">
                                    <ItemStyle HorizontalAlign="Right" />
                                </asp:BoundField>
                                <asp:BoundField DataField="EMP_ID" HeaderText="Emp.Code" />
                                <asp:BoundField DataField="EMP_NAME" HeaderText="Name" />
                                <asp:BoundField DataField="DOB" HeaderText="Birth Date"  ItemStyle-Width="60px" />
                                <asp:BoundField DataField="DES_VALUE" HeaderText="Designation" />
                                <asp:BoundField DataField="DEPT_VALUE" HeaderText="Department" />
                                <asp:BoundField DataField="INS_VALUE" HeaderText="Institution" />
                            </Columns>
                        </asp:GridView>
                    </td>
                </tr>
            </table>
        </div>
    </div>
</asp:Content>

