<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/FullLength.master" AutoEventWireup="true" CodeFile="rprtSalPayble.aspx.cs" Inherits="PayRoll_rprtSalPayble" %>

<%@ Register Src="~/Control/MonthYear.ascx" TagPrefix="uc1" TagName="MonthYear" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div id="page_content" class="container" style="padding:5px;">
        <div id="header" class="heading">
            <h2>Payable Salary</h2>
            </div>
        <div id="contentFilter" >
            <table>
                                                    <tr>
                                                        <th>
                                                            By Institution</th>
                                                        <th>
                                                            By Department</th>
                                                        <th>
                                                            By Designation</th>
                                                        <th>
                                                            By Type</th>
                                                        <th>
                                                            By Employee</th>
                                                        <th>
                                                            By Template</th>
                                                        <th>
                                                            By Month & Year</th>
                                                    </tr>
                                                    <tr>
                                                        <td >
                                                            <asp:DropDownList ID="ddlInsName" runat="server" AutoPostBack="True" Width="90px"
                                                                OnSelectedIndexChanged="ddlInsName_SelectedIndexChanged">
                                                            </asp:DropDownList></td>
                                                        <td >
                                                            <asp:DropDownList ID="ddlDept" runat="server" Width="160px">
                                                            </asp:DropDownList></td>
                                                        <td >
                                                            <asp:DropDownList ID="ddlDesig" runat="server" Width="160px">
                                                            </asp:DropDownList></td>
                                                        <td >
                                                            <asp:DropDownList ID="ddlType" runat="server" Width="100px">
                                                                <asp:ListItem Value=".">Select</asp:ListItem>
                                                                <asp:ListItem Value="1">Teaching</asp:ListItem>
                                                                <asp:ListItem Value="0">Non-Teaching</asp:ListItem>
                                                            </asp:DropDownList></td>
                                                        <td ><asp:TextBox ID="txtEmp" runat="server" CssClass="textBox" Width="150px" placeholder="Employee Name or Code"></asp:TextBox>
                        <ajaxToolkit:AutoCompleteExtender ID="AutoCompleteExtender2" runat="server" CompletionInterval="500"
                            CompletionSetCount="12" ContextKey="1" EnableCaching="true" MinimumPrefixLength="1"
                            ServiceMethod="GetEmployeeList" ServicePath="~\AutoComplete.asmx" TargetControlID="txtEmp">
                        </ajaxToolkit:AutoCompleteExtender> </td>
                                                        <td >
                                                            <asp:DropDownList ID="ddlTemplate" runat="server" Width="110px">
                                                                <asp:ListItem Value=".">Select</asp:ListItem>
                                                                <asp:ListItem Value="1">Earnings</asp:ListItem>
                                                                <asp:ListItem Value="0">Deduction</asp:ListItem>
                                                            </asp:DropDownList></td>
                                                        <td>
                                                            <uc1:MonthYear runat="server" ID="MonthYear" />
                                                        </td>
                                                        <td>
                                                         <asp:Button ID="btnView" runat="server" CssClass="btnBrown" Text="View " OnClick="btnView_Click"
                                        Font-Overline="False" AccessKey="s" Width="60px"></asp:Button>
                                                            </td>
                                                    </tr>
                                                </table>
            </div>
        <div id="pageGrid" style="max-height:500px;overflow:scroll">
            <asp:GridView ID="gvPayable" runat="server" CssClass="gridDynamic" ShowFooter="true">
                                        </asp:GridView>
        </div>
        <div id="contentFooter">
             <asp:Button ID="btnExport" runat="server" Text="Export To Excel" CssClass="btnBrown"
                                        OnClick="btnExport_Click"  Visible="false"/>
        </div>
        </div>
</asp:Content>

