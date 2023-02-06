<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Short.master" AutoEventWireup="true" CodeFile="InsDeptEmp.aspx.cs" Inherits="HR_InsDeptEmp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentHolder1" runat="Server">
    <div class="container">
        <div class="heading">
            <h2>Employee List
            </h2>
        </div>
        <div>
            <table>
                <tr>
                    <th>Institute
                    </th>
                    <td>&nbsp;</td>
                    <th>Department
                    </th>
                    <th>Gender</th>
                </tr>
                <tr>
                    <td>
                        <asp:DropDownList ID="ddlIns" runat="server" Width="100px" OnSelectedIndexChanged="ddlIns_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                    </td>
                    <td>&nbsp;</td>
                    <td>
                        <asp:DropDownList ID="ddlDept" runat="server" Width="100px" AutoPostBack="true"></asp:DropDownList>
                    </td>
                    <td><asp:DropDownList ID="ddlGen" runat="server" Width="100px" AutoPostBack="true"></asp:DropDownList></td>
                    <td>
                        <asp:Button ID="btnShow" runat="server" Text="Show" OnClick="btnShow_Click" />
                    </td>
                    <td><asp:Button ID="btnView" runat="server" Text="View" OnClick="btnView_Click" /></td>
                </tr>
            </table>
             <div>
                            <br/>
                            <center>
                            <asp:Label ID="lblName" runat="server" Font-Size="Large"></asp:Label><br/>
                            <asp:Label ID="lblCode" runat="server" Font-Size="Large"></asp:Label>
                            </center>
                        </div>
            <table>
                <tr>
                    <td>
                       
                    </td>
                </tr>
            </table>
        </div>
    </div>
</asp:Content>

