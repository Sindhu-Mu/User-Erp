<%@ Page Title="ERP | Payroll Profile" Language="C#" MasterPageFile="~/MasterPages/FullLength.master" AutoEventWireup="true" CodeFile="SalEmpProfile.aspx.cs" Inherits="Payroll_SalEmpProfile" %>

<%@ Register Src="~/Control/Employee.ascx" TagName="Employee" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script lang="javascript" type="text/javascript">

        function CheckControl(ctrl) {
            if (bTrim(document.getElementById(ctrl).value) == "" || bTrim(document.getElementById(ctrl).value) == ".") {
                document.getElementById(ctrl).style.backgroundColor = "#fc6";
                return false;
            }
            else
                document.getElementById(ctrl).style.backgroundColor = "#fff";
            return true;
        }


        function validation() {
            var flag = true;
            var msg = "", ctrl = "";


            if (msg != "") alert(msg);
            if (ctrl != "")
                document.getElementById(ctrl).focus();
            return flag;
        }
    </script>
    <div class="container">
        <div class="heading">
            <h2>Payroll Profile</h2>
        </div>
        <div style="width:80%;">
            <asp:UpdatePanel ID="up1" runat="server">
                <ContentTemplate>
                    <div style="float: right; width: 100%;">

                        <table >

                            <tr>
                                <td>
                                    <asp:TextBox ID="txtEmp" runat="server" Width="228px" placeholder="Employee Name or Code"></asp:TextBox>
                                    <ajaxToolkit:AutoCompleteExtender ID="AutoCompleteExtender2" runat="server" CompletionInterval="500"
                                        CompletionSetCount="12" ContextKey="1" EnableCaching="true" MinimumPrefixLength="1"
                                        ServiceMethod="GetEmployeeList" ServicePath="~\AutoComplete.asmx" TargetControlID="txtEmp">
                                    </ajaxToolkit:AutoCompleteExtender>
                                </td>
                                <td>
                                    <asp:Button ID="btnShow" runat="server" Text="Show" OnClick="btnShow_Click" />
                                </td>
                            </tr>

                        </table>
                    </div>
                    <div class="cleaner">&nbsp;</div>
                    <div>
                        <div>
                            <uc1:Employee ID="Employee1" runat="server"></uc1:Employee>
                        </div>
                        <div>
                            &nbsp;
                        </div>
                        <div>
                            <table>
                                <tr>
                                    <th>Salary Template<span style="color: #ff0000">*</span></th>
                                    <td>&nbsp;</td>
                                    <th>
                                        <b>Pay Sacle<span style="color: #ff0000">*</span></b></th>
                                    <td>&nbsp;</td>
                                    <th>
                                        <b>With Increments<span style="color: #ff0000">*</span></b></th>
                                    <td></td>
                                </tr>
                                <tr>
                                    <td align="left">
                                        <asp:DropDownList ID="ddlTemplate" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlTemplate_SelectedIndexChanged">
                                        </asp:DropDownList></td>
                                    <td>&nbsp;</td>
                                    <td>
                                        <asp:DropDownList ID="ddlPayScale" runat="server" Width="200px">
                                        </asp:DropDownList>
                                        <asp:Label ID="lblScale" runat="server" Font-Bold="true"></asp:Label></td>
                                    <td></td>
                                    <td>
                                        <asp:DropDownList ID="ddlIncrement" runat="server" Width="80px">
                                            <asp:ListItem Value="0">Nill</asp:ListItem>
                                            <asp:ListItem>1</asp:ListItem>
                                            <asp:ListItem>2</asp:ListItem>
                                            <asp:ListItem>3</asp:ListItem>
                                            <asp:ListItem>4</asp:ListItem>
                                            <asp:ListItem>5</asp:ListItem>
                                            <asp:ListItem>6</asp:ListItem>
                                            <asp:ListItem>7</asp:ListItem>
                                            <asp:ListItem>8</asp:ListItem>
                                            <asp:ListItem>9</asp:ListItem>
                                            <asp:ListItem>10</asp:ListItem>
                                            <asp:ListItem>11</asp:ListItem>
                                            <asp:ListItem>12</asp:ListItem>
                                            <asp:ListItem>13</asp:ListItem>
                                            <asp:ListItem>14</asp:ListItem>
                                            <asp:ListItem>15</asp:ListItem>
                                            <asp:ListItem>16</asp:ListItem>
                                            <asp:ListItem>17</asp:ListItem>
                                            <asp:ListItem>18</asp:ListItem>
                                            <asp:ListItem>19</asp:ListItem>
                                        </asp:DropDownList>
                                        <asp:TextBox ID="txtData" runat="server" Visible="false"></asp:TextBox></td>
                                    <td>
                                        <asp:Button ID="btnAdd" OnClick="btnAdd_Click" runat="server" Width="50px" Text="Add"
                                            CssClass="btnBrown"></asp:Button></td>
                                </tr>
                            </table>
                        </div>
                        <div>
                            &nbsp;
                        </div>
                        <div>
                            <table style="font-size: 11px; font-family: Tahoma; width: 100%">

                                <tr style="font-weight: bold; font-size: 11pt; color: blue; text-align: center">
                                    <td style="width: 48%">
                                        <span><strong>Earning Heads</strong></span></td>
                                    <td style="width: 4%">&nbsp;</td>
                                    <td>
                                        <strong><span style="font-size: 11pt">Deduction Heads</span></strong></td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:GridView ID="gvEarnings" runat="server" Width="97%" DataKeyNames="HEAD_ID,HEAD_ENTRY_TYPE"
                                            CssClass="gridDynamic" AutoGenerateColumns="False">
                                            <Columns>
                                                <asp:TemplateField HeaderText="S.No.">
                                                    <ItemTemplate>
                                                        <%# ((GridViewRow)Container).RowIndex + 1%>
                                                    </ItemTemplate>
                                                    <ItemStyle Width="15px" />
                                                </asp:TemplateField>
                                                <asp:BoundField DataField="Head_NAME" HeaderText="Head Name"></asp:BoundField>
                                                <asp:BoundField DataField="TYPE" HeaderText="Type" HtmlEncode="False">
                                                    <ItemStyle HorizontalAlign="Right"></ItemStyle>
                                                </asp:BoundField>
                                                <asp:TemplateField HeaderText="Value">
                                                    <ItemTemplate>
                                                        <cc1:NumericTextBox ID="txtValue" runat="server" Width="100px" Text='<%# Bind("HEAD_ENTRY_VALUE") %>'
                                                            CssClass="txtno"></cc1:NumericTextBox>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Right" Width="100px" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Days Effected">
                                                    <ItemTemplate>
                                                        <asp:RadioButtonList ID="Rlist1" runat="server" RepeatDirection="Horizontal" CellSpacing="0"
                                                            CellPadding="0">
                                                            <asp:ListItem Selected="true" Value="1">Yes</asp:ListItem>
                                                            <asp:ListItem Value="0">No</asp:ListItem>
                                                        </asp:RadioButtonList>
                                                    </ItemTemplate>
                                                    <ItemStyle Width="80px" />
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                    </td>
                                    <td></td>
                                    <td>
                                        <asp:GridView ID="gvDeductions" runat="server" Width="97%" DataKeyNames="HEAD_ID,HEAD_ENTRY_TYPE"
                                            CssClass="gridDynamic" AutoGenerateColumns="False">
                                            <Columns>
                                                <asp:TemplateField HeaderText="S.No.">
                                                    <ItemTemplate>
                                                        <%# ((GridViewRow)Container).RowIndex + 1%>
                                                    </ItemTemplate>
                                                    <ItemStyle Width="15px" />
                                                </asp:TemplateField>
                                                <asp:BoundField DataField="Head_NAME" HeaderText="Head Name" />
                                                <asp:BoundField DataField="TYPE" HeaderText="Type" HtmlEncode="False">
                                                    <ItemStyle HorizontalAlign="Right" />
                                                </asp:BoundField>
                                                <asp:TemplateField HeaderText="Value">
                                                    <ItemTemplate>
                                                        <cc1:NumericTextBox ID="txtValue" runat="server" Width="100px" Text='<%# Bind("HEAD_ENTRY_VALUE") %>'
                                                            CssClass="txtno"></cc1:NumericTextBox>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Right" Width="100px" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Days Effected">
                                                    <ItemTemplate>
                                                        <asp:RadioButtonList ID="Rlist1" runat="server" RepeatDirection="Horizontal" CellSpacing="0"
                                                            CellPadding="0">
                                                            <asp:ListItem Selected="true" Value="1">Yes</asp:ListItem>
                                                            <asp:ListItem Value="0">No</asp:ListItem>
                                                        </asp:RadioButtonList>
                                                    </ItemTemplate>
                                                    <ItemStyle Width="80px" />
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                    </td>
                                </tr>

                            </table>
                        </div>
                        <div style="text-align: right;">
                            <asp:Button ID="btnCalculate" OnClick="btnCalculate_Click" runat="server"
                                Text="Calculate" Height="50px" ></asp:Button>
                        </div>
                        <div id="DivSalary" runat="server" visible="false">
                            <div>
                                <table>
                                    <tr style="font-weight: bold; font-size: 14px">
                                        <td id="ear" valign="top" runat="server"></td>
                                        <td></td>
                                        <td id="ded" valign="top" runat="server"></td>
                                    </tr>
                                    <tr>
                                        <td colspan="3">
                                            <hr style="color: red" size="1" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td valign="top" colspan="2">
                                            <table style="font-size: 11px; font-family: Tahoma; border-collapse: collapse" cellpadding="0"
                                                width="100%" border="0">
                                                <tbody>
                                                    <tr>
                                                        <td style="padding-left: 20px; font-size: 11px; font-family: Tahoma" align="left"
                                                            width="30%" height="20">TOTAL EARNINGS [A]</td>
                                                        <td style="padding-right: 20px; font-size: 11px; font-family: Tahoma" align="right"
                                                            width="20%" height="20">
                                                            <asp:Label ID="lblTOTER" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </tbody>
                                            </table>
                                        </td>
                                        <td valign="top" width="50%">
                                            <table style="font-size: 11px; font-family: Tahoma; border-collapse: collapse" cellpadding="0"
                                                width="100%" border="0">
                                                <tbody>
                                                    <tr>
                                                        <td style="padding-left: 20px; font-size: 11px; font-family: Tahoma" align="left"
                                                            width="30%" height="20">TOTAL DEDUCTIONS [B]</td>
                                                        <td style="padding-right: 20px; font-size: 11px; font-family: Tahoma" id="totded"
                                                            align="right" width="20%" height="20" runat="server">
                                                            <asp:Label ID="lblTOtdE" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </tbody>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="3">
                                            <hr style="color: red" size="1" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td id="netSal" valign="top" colspan="3" runat="server"></td>
                                    </tr>
                                </table>
                            </div>
                            <div>
                                <table>
                                    <tr>
                                        <th>Order No<span style="color: #ff0000">*</span></th>
                                        <td></td>
                                        <th>Order Date<span style="color: #ff0000">*</span>
                                            <ajaxToolkit:MaskedEditExtender ID="ME1" runat="server" TargetControlID="txtOrderDate"
                                                MaskType="Date" Mask="99/99/9999">
                                            </ajaxToolkit:MaskedEditExtender>
                                            <ajaxToolkit:CalendarExtender ID="CalEx1" runat="server" TargetControlID="txtOrderDate"
                                                Format="dd/MM/yyyy">
                                            </ajaxToolkit:CalendarExtender>
                                        </th>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:TextBox ID="txtOrderNo" runat="server" Width="200px" CssClass="textbox"></asp:TextBox></td>
                                        <td></td>
                                        <td>
                                            <asp:TextBox ID="txtOrderDate" runat="server" Width="100px" CssClass="textbox"></asp:TextBox></td>
                                        <td>
                                            <asp:Button ID="btnSubmit" OnClick="btnSubmit_Click" runat="server" 
                                                Text="Submit" CssClass="btnBrown"></asp:Button></td>
                                    </tr>
                                </table>
                            </div>
                        </div>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
</asp:Content>

