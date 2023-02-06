<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/FullLength.master" AutoEventWireup="true" CodeFile="rprtSalaryIncrement.aspx.cs" Inherits="PayRoll_rprtSalaryIncrement" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div id="container" class="container">
        <div id="heading" class="heading">
            Increment Report
         </div>
        <div id="header">
            <div class="bg-brown-center"><p>Improve Your Search</p></div>
            <div>
                <table style="width:100%">
                    <tr class="filter-heading">
                        <td>Institution</td>
                        <td>Department</td>
                        <td>Designation</td>
                        <td>Employee</td>
                        <td>Template</td>
                        <td>Employee Type</td>
                    </tr>
                     <tr>
                       <td style="width: 150px">
                                        <asp:DropDownList ID="ddlInstitution" runat="server" AutoPostBack="True">
                                        </asp:DropDownList></td>
                                    <td >
                                        <asp:DropDownList ID="ddlDept" runat="server" >
                                        </asp:DropDownList></td>
                                    <td >
                                        <asp:DropDownList ID="ddlDes" runat="server" >
                                        </asp:DropDownList>
                                    </td>
                                    <td >
                                        <asp:TextBox ID="txtEmp" runat="server" CssClass="textbox"></asp:TextBox>
                                    </td>
                                    <td style="width: 150px">
                                        <asp:DropDownList ID="ddlTemp" runat="server" >
                                        </asp:DropDownList></td>
                                    <td >
                                        <asp:DropDownList ID="ddlEmpType" runat="server">
                                            <asp:ListItem Text="ALL" Value="."></asp:ListItem>
                                            <asp:ListItem Text="Teaching" Value="1"></asp:ListItem>
                                            <asp:ListItem Text="Non-Teaching" Value="0"></asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                    </tr>

                    </table>
                <table style="width:100%">
                    <tr class="filter-heading">
                         <td>Increment Month</td>
                         <td>Increment Year</td>
                         <td>Increment From Month</td>
                         <td>Increment From Year</td>
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
                         <td> <asp:DropDownList ID="ddlAppYear" runat="server">
                                        </asp:DropDownList></td>
                         <td> <asp:DropDownList ID="DropDownList1" runat="server">
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
                              <asp:DropDownList ID="ddlGivYear" runat="server">
                              </asp:DropDownList>

                         </td>
                    </tr>
                    </table>
                </div>
        </div>
    </div>
</asp:Content>

