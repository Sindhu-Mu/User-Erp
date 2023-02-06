<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/FullLength.master" AutoEventWireup="true" CodeFile="rptBank.aspx.cs" Inherits="PayRoll_rptBank" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="container">
        <div class="heading">
            <h2>Salary Bank Report
            </h2>
        </div>
        <div>
            <table style="width: 100%; margin: 0px; border: 0px;" id="tblColumns">
                <tr>
                    <td style="width: 60%; border-right-style: ridge; vertical-align: top">
                        <table style="margin: 0px; border: 0px; width: 100%;">
                            <tr>
                                <th>Filters
                                </th>
                            </tr>
                            <tr>
                                <td>
                                    <table class="entry">
                                        <tr>
                                            <th>By Institution
                                            </th>
                                            <th>By Department</th>
                                            <th>By Designation
                                            </th>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:DropDownList ID="ddlInstitution" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlInstitution_SelectedIndexChanged">
                                                </asp:DropDownList></td>
                                            <td>
                                                <asp:DropDownList ID="ddlDept" runat="server" Width="171px">
                                                </asp:DropDownList></td>
                                            <td>
                                                <asp:DropDownList ID="ddlDes" runat="server" Width="181px">
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <table class="entry">
                                        <tr>
                                            <th>By Employee
                                            </th>
                                            <th>By Category</th>
                                            <th>By Gender</th>
                                            <th>Emp Type</th>
                                        </tr>

                                        <tr>
                                            <td>
                                                <asp:TextBox ID="txtEmp" runat="server" Width="200px"></asp:TextBox>
                                                <ajaxToolkit:AutoCompleteExtender ID="AutoCompleteExtender2" runat="server" CompletionInterval="500"
                                                    CompletionSetCount="12" ContextKey="1" EnableCaching="true" MinimumPrefixLength="1"
                                                    ServiceMethod="GetEmployeeList" ServicePath="~\AutoComplete.asmx" TargetControlID="txtEmp">
                                                </ajaxToolkit:AutoCompleteExtender>
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="ddlCat" runat="server" Width="180px">
                                                    <%-- <asp:ListItem Value="0" Text="ALL" />
                                                    <asp:ListItem Value="1" Text="SC" />
                                                    <asp:ListItem Value="2" Text="ST" />
                                                    <asp:ListItem Value="3" Text="OBC" />
                                                    <asp:ListItem Value="4" Text="General" />
                                                    <asp:ListItem Value="5" Text="MBC" />
                                                    <asp:ListItem Value="6" Text="Other" />--%>
                                                </asp:DropDownList>
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="ddlGender" runat="server" Width="100px">
                                                    <%-- <asp:ListItem Value="0" Text="ALL"></asp:ListItem>
                                                    <asp:ListItem Value="M" Text="Male"></asp:ListItem>
                                                    <asp:ListItem Value="F" Text="Female"></asp:ListItem>--%>
                                                </asp:DropDownList>
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="ddlempType" runat="server" Width="100px">
                                                    <%--  <asp:ListItem Value="0" Text="ALL"></asp:ListItem>
                                                    <asp:ListItem Value="T" Text="Teaching"></asp:ListItem>
                                                    <asp:ListItem Value="N" Text="Non Teaching"></asp:ListItem>--%>
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <table class="entry">
                                        <tr>
                                            <th colspan="2">By Gross Salary
                                            </th>
                                            <th colspan="2">Payment Mode
                                            </th>
                                        </tr>
                                        <tr>
                                            <th style="Width: 150px">Minimum Salary
                                            </th>
                                            <th style="Width: 150px">Maximum Salary
                                            </th>
                                            <th>Payment Mode
                                            </th>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:TextBox ID="txtMinSalary" runat="server" Width="150px"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtMaxSalary" runat="server" Width="150px"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="ddlMode" runat="server" Width="200px">
                                                    <asp:ListItem Value="all" Text="ALL"></asp:ListItem>
                                                    <asp:ListItem Value="1" Text="Bank"></asp:ListItem>
                                                    <asp:ListItem Value="0" Text="Cash"></asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <th>Salary Month
                                </th>
                            </tr>
                            <tr>
                                <td>
                                    <table class="entry">
                                        <tr>
                                            <th>By Month
                                            </th>
                                            <th>By Year
                                            </th>
                                            <th>By Reference
                                            </th>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:DropDownList ID="ddlAppMnth" runat="server">
                                                    <asp:ListItem Value="0" Text="ALL" />
                                                    <asp:ListItem Value="1" Text="Jan" />
                                                    <asp:ListItem Value="2" Text="Feb" />
                                                    <asp:ListItem Value="3" Text="Mar" />
                                                    <asp:ListItem Value="4" Text="Apr" />
                                                    <asp:ListItem Value="5" Text="May" />
                                                    <asp:ListItem Value="6" Text="Jun" />
                                                    <asp:ListItem Value="7" Text="Jul" />
                                                    <asp:ListItem Value="8" Text="Aug" />
                                                    <asp:ListItem Value="9" Text="Sep" />
                                                    <asp:ListItem Value="10" Text="Oct" />
                                                    <asp:ListItem Value="11" Text="Nov" />
                                                    <asp:ListItem Value="12" Text="Dec" />
                                                </asp:DropDownList>
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="ddlAppYear" runat="server" Width="200px">
                                                </asp:DropDownList>
                                            </td>
                                            <td> <asp:DropDownList ID="ddlByRef" runat="server" Width="220px">
                                                </asp:DropDownList></td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <th>Transfer Month
                                </th>
                            </tr>
                            <tr>
                                <td>
                                    <table class="entry">
                                        <tr>
                                            <th>By Month
                                            </th>
                                            <th>By Year
                                            </th>
                                            <th>By Date
                                            </th>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:DropDownList ID="ddlTranMonth" runat="server">
                                                    <asp:ListItem Value="0" Text="ALL" />
                                                    <asp:ListItem Value="1" Text="Jan" />
                                                    <asp:ListItem Value="2" Text="Feb" />
                                                    <asp:ListItem Value="3" Text="Mar" />
                                                    <asp:ListItem Value="4" Text="Apr" />
                                                    <asp:ListItem Value="5" Text="May" />
                                                    <asp:ListItem Value="6" Text="Jun" />
                                                    <asp:ListItem Value="7" Text="Jul" />
                                                    <asp:ListItem Value="8" Text="Aug" />
                                                    <asp:ListItem Value="9" Text="Sep" />
                                                    <asp:ListItem Value="10" Text="Oct" />
                                                    <asp:ListItem Value="11" Text="Nov" />
                                                    <asp:ListItem Value="12" Text="Dec" />
                                                </asp:DropDownList>
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="ddlTranYear" runat="server" Width="200px">
                                                </asp:DropDownList>
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="ddlDate" runat="server" Width="220px">
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </td>
                    <td style="width: 60%; vertical-align: top">
                        <table style="width: 100%">
                            <tr>
                                <th>Fields
                                </th>
                            </tr>
                            <tr>
                                <td>
                                    <asp:CheckBoxList ID="chkFeild" runat="server" RepeatColumns="3" RepeatDirection="Horizontal">
                                        <asp:ListItem Value="EV.INS_VALUE AS INSTITUTION">Institution</asp:ListItem>
                                        <asp:ListItem Value="EV.DEPT_VALUE AS DEPT_NAME">DEPT_NAME</asp:ListItem>
                                        <asp:ListItem Value="EV.DES_VALUE AS DESIG_NAME">DESIG_NAME</asp:ListItem>
                                    </asp:CheckBoxList>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Button ID="btnExecute" runat="server" Text="View" CssClass="btnBrown" Width="64px" OnClick="btnExecute_Click" />&nbsp;&nbsp;
&nbsp;                                        
                                    <asp:Button ID="btnPrint" runat="server" Text="Print" CssClass="btnBrown" Width="64px" OnClick="btnPrint_Click" />


                                </td>

                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </div>
    </div>
</asp:Content>

