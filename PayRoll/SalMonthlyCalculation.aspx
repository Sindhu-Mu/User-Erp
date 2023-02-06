<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/FullLength.master" AutoEventWireup="true" CodeFile="SalMonthlyCalculation.aspx.cs" Inherits="PayRoll_SalMonthlyCalculation" %>

<%@ Register Src="~/Control/MonthYear.ascx" TagPrefix="uc1" TagName="MonthYear" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="container">
        <div class="heading">
            <h2>Monthly Salary Calculation
            </h2>
        </div>
        <div>
            <div>
            <table>
                <tr>

                    <th>Month/Year
                    </th>
                    <th>Template
                    </th>                   
                    <th>Employee Code
                    </th>
                    <th>Calculation Type</th>

                    <th>Sort By
                    </th>
                </tr>
                <tr>

                    <td>
                        <uc1:MonthYear runat="server" ID="MonthYear" />
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlTemplate" runat="server"></asp:DropDownList>
                    </td>

                    
                  
                    <td>
                        <asp:TextBox ID="txtEmp" runat="server"></asp:TextBox>
                        <ajaxToolkit:AutoCompleteExtender ID="AutoCompleteExtender2" runat="server" CompletionInterval="500"
                            CompletionSetCount="12" ContextKey="1" EnableCaching="true" MinimumPrefixLength="1"
                            ServiceMethod="GetEmployeeList" ServicePath="~\AutoComplete.asmx" TargetControlID="txtEmp">
                        </ajaxToolkit:AutoCompleteExtender>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlCalType" runat="server">
                            <asp:ListItem Value="0" Text="Main"></asp:ListItem>
                            <asp:ListItem Value="1" Text="Balance"></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlSort" runat="server">
                            <asp:ListItem Value="0" Text="Emp Code"></asp:ListItem>
                            <asp:ListItem Value="1" Text="Gross Salary"></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td>
                        <asp:Button ID="btnShow" runat="server" Text="Show" OnClick="btnShow_Click" />
                    </td>

                </tr>
                </table>
                </div>
            <div>
                <asp:CheckBox ID="ChSalary" runat="server" AutoPostBack="true" Text="Salary based condiation" OnCheckedChanged="ChSalary_CheckedChanged" />
            </div>
            <div id="DivSalary" runat="server" visible="false">
                <table>
                    <tr>
                     <th>Type
                    </th>
                    <th>Min Salary
                    </th>
                    <th>Max Salary
                    </th>
                        </tr>
                    <tr>
                          <td>
                        <asp:DropDownList ID="ddlType" runat="server" OnSelectedIndexChanged="ddlType_SelectedIndexChanged" AutoPostBack="true">
                            <asp:ListItem Value="0" Text="All"></asp:ListItem>
                            <asp:ListItem Value="1" Text="Equal To"></asp:ListItem>
                            <asp:ListItem Value="2" Text="Less Than"></asp:ListItem>
                            <asp:ListItem Value="3" Text="Greater Than"></asp:ListItem>
                            <asp:ListItem Value="4" Text="Between"></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td>
                        <cc1:NumericTextBox ID="txtMin" runat="server" AllowDecimal="true" DecimalPlaces="2" Width="80px" Enabled="false" Text="0"></cc1:NumericTextBox>
                        <%-- <asp:TextBox ID="txtMin" width="80px" runat="server"></asp:TextBox>--%>
                    </td>
                    <td>
                        <cc1:NumericTextBox ID="txtMax" runat="server" AllowDecimal="true" DecimalPlaces="2" Width="80px" Enabled="false" Text="0"></cc1:NumericTextBox>
                        <%--<asp:TextBox ID="txtMax" width="80px" runat="server"></asp:TextBox>--%>
                    </td>
                    </tr>
                </table>
            </div>
                        <div style="height: 380px; overflow: auto; width: 950px">
                            <asp:GridView ID="gridSAL" runat="server" Width="100%" CellPadding="0" Font-Size="10px"
                                CssClass="gridDynamic" ShowFooter="True">
                                <Columns>
                                    <asp:TemplateField HeaderText="S.No">
                                        <ItemTemplate>
                                            <%#((GridViewRow)Container).RowIndex+1 %>.
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                </Columns>
                            </asp:GridView>
                        </div>
                  <div style="text-align:right;">
                        <asp:Button ID="btnExport" runat="server" CssClass="btnBrown" Height="30px" Text="Export To Excel" OnClick="btnExport_Click" />
                        <asp:Button ID="btnSave" runat="server" CssClass="btnBrown" Height="30px" Text="Submit Salary" OnClick="btnSave_Click" />
                    </div>
            
        </div>
    </div>
</asp:Content>

