<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/FullLength.master" AutoEventWireup="true" CodeFile="SalMonthHold.aspx.cs" Inherits="PayRoll_SalMonthHold" %>

<%@ Register Src="~/Control/MonthYear.ascx" TagPrefix="uc1" TagName="MonthYear" %>
<%@ Register Src="~/Control/EmpPayrollProfile.ascx" TagPrefix="uc2" TagName="EmpPayrollProfile" %>



<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="mainBody" class="container">
        <div id="pageHeading" class="heading">
            Salary Hold
        </div>
        <div id="EmpUsrControl" style="margin: 10px;">
            <asp:TextBox ID="txtEmp" runat="server" CssClass="textBox" Width="228px" placeholder="Employee Name or Code"></asp:TextBox>&nbsp;&nbsp;&nbsp;<asp:Button ID="btnShow" runat="server" Text="Show" OnClick="btnShow_Click" />
            <ajaxToolkit:AutoCompleteExtender ID="AutoCompleteExtender2" runat="server" CompletionInterval="500"
                CompletionSetCount="12" ContextKey="0,1,2,3" EnableCaching="true" MinimumPrefixLength="1"
                ServiceMethod="GetEmployeeList" ServicePath="~\AutoComplete.asmx" TargetControlID="txtEmp">
            </ajaxToolkit:AutoCompleteExtender>
        </div>
        <div id="EmpPayrollCntrl">
            <uc2:EmpPayrollProfile runat="server" ID="EmpPayrollProfile" />
        </div>
        <div id="gridFilters">
            <table>
                <tr>
                    <th>Month
                    </th>
                    <th>Action Type
                    </th>
                    <th>Remarks
                    </th>
                    <th></th>
                </tr>
                <tr>
                    <td>
                        <uc1:MonthYear runat="server" ID="MonthYear1" />
                        
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlStatus" runat="server">
                            <asp:ListItem Value="0">Hold</asp:ListItem>
                            <asp:ListItem Value="1">Un-Hold</asp:ListItem>
                        </asp:DropDownList></td>
                    <td>
                        <asp:TextBox ID="txtRemark" runat="server" CssClass="textbox"></asp:TextBox></td>
                    <td>
                        <asp:Button ID="btnSave" runat="server" CssClass="btnBrown" OnClick="btnSave_Click"
                            Text="Save" /></td>
                </tr>
            </table>
        </div>
    </div>
</asp:Content>

