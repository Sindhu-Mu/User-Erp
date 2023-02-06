<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/FullLength.master" AutoEventWireup="true" CodeFile="SalIncrement.aspx.cs" Inherits="PayRoll_SalIncrement" %>


<%@ Register Src="~/Control/MonthYear.ascx" TagPrefix="uc3" TagName="MonthYear" %>
<%@ Register Src="~/Control/EmpPayrollProfile.ascx" TagPrefix="uc2" TagName="EmpPayrollProfile" %>



<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="container">
    <div class="heading">
Employee Increment

    </div>
    <div>
          <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                         <ContentTemplate>
                             <div id="empautocomplete">
                                 <table >
            <tbody>

                <tr>
                    <td>
                        <asp:TextBox ID="txtEmp" runat="server" CssClass="textBox" Width="228px" placeholder="Employee Name or Code"></asp:TextBox>
                        <ajaxToolkit:AutoCompleteExtender ID="AutoCompleteExtender2" runat="server" CompletionInterval="500"
                            CompletionSetCount="12" ContextKey="1" EnableCaching="true" MinimumPrefixLength="1"
                            ServiceMethod="GetEmployeeList" ServicePath="~\AutoComplete.asmx" TargetControlID="txtEmp">
                        </ajaxToolkit:AutoCompleteExtender>
                    </td>
                    <td>
                        <asp:Button ID="btnShow" runat="server" Text="Show" OnClick="btnShow_Click" />
                    </td>
                </tr>
            </tbody>
        </table>

                             </div>
                             <div id="empconrol">
                                 <uc2:EmpPayrollProfile runat="server" id="EmpPayrollProfile" />
                             </div> 
                             <div id="feildArea">
                                  <table >
                                        <tr>
                                            <th>
                                                Increment Type<span style="color: #ff0000">*</span></th>
                                            <td>
                                                &nbsp;</td>
                                            <th>
                                                </th>
                                            <tr style="vertical-align: top;">
                                                <td>
                                                    <asp:RadioButtonList ID="Rlist1" runat="server" RepeatDirection="Horizontal">
                                                        <asp:ListItem Selected="True" Value="0">Grade</asp:ListItem>
                                                        <asp:ListItem Value="1">Amount</asp:ListItem>
                                                    </asp:RadioButtonList>
                                                </td>
                                                <td></td>
                                                <td>
                                                    <cc1:NumericTextBox ID="txtIncAmt" runat="server" AllowDecimal="true" CssClass="txtno" DecimalPlaces="2" Width="100px"></cc1:NumericTextBox>
                                                </td>
                                                <td>
                                                    <asp:Button ID="btnCalculate" runat="server" CssClass="btnBrown" OnClick="btnCalculate_Click" Text="Calculate" />
                                                </td>
                                                <th>Total Incrment:-<asp:Label ID="lblIncrement" runat="server" Font-Bold="True"></asp:Label>
                                                </th>
                                            </tr>
                                        </tr>
                                    </table>
                                </td>
                             </div>
                             <div id="gridArea">
                                  <table style="font-size: 11px; font-family: Tahoma" cellspacing="0" cellpadding="0"
                                        width="100%">
                                        <tbody>
                                            <tr style="font-weight: bold; font-size: 11pt; color: blue; text-align: center">
                                                <td style="width: 48%" valign="top">
                                                    <span><strong>Earning Heads</strong></span></td>
                                                <td style="width: 4%">
                                                    &nbsp;</td>
                                                <td valign="top">
                                                    <strong><span style="font-size: 11pt">Deduction Heads</span></strong></td>
                                            </tr>
                                            <tr>
                                                <td valign="top">
                                                    <asp:GridView ID="gvEarnings" runat="server" Width="97%" DataKeyNames="HEAD_ID,HEAD_ENTRY_TYPE,ED_CALCULATION,ES_ID"
                                                        CssClass="gridDynamic" AutoGenerateColumns="False" ShowFooter="True">
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
                                                            <asp:BoundField DataField="HEAD_ENTRY_VALUE" HeaderText="Value" HtmlEncode="False"
                                                                FooterText="Total:-">
                                                                <ItemStyle HorizontalAlign="Right"></ItemStyle>
                                                            </asp:BoundField>
                                                            <asp:TemplateField HeaderText="Amount">
                                                                <ItemTemplate>
                                                                    <cc1:NumericTextBox ID="txtValue" runat="server" Width="100px" Text='<%# Bind("HEAD_VALUE") %>'
                                                                        CssClass="txtno"></cc1:NumericTextBox>
                                                                </ItemTemplate>
                                                                <ItemStyle HorizontalAlign="Right" Width="100px" />
                                                            </asp:TemplateField>
                                                        </Columns>
                                                    </asp:GridView>
                                                </td>
                                                <td>
                                                </td>
                                                <td valign="top">
                                                    <asp:GridView ID="gvDeductions" runat="server" Width="97%" DataKeyNames="HEAD_ID,HEAD_ENTRY_TYPE,ED_CALCULATION"
                                                        CssClass="gridDynamic" AutoGenerateColumns="False" ShowFooter="True">
                                                        <Columns>
                                                            <asp:TemplateField HeaderText="S.No.">
                                                                <ItemTemplate>
                                                                    <%# ((GridViewRow)Container).RowIndex + 1%>
                                                                </ItemTemplate>
                                                                <ItemStyle Width="15px" />
                                                            </asp:TemplateField>
                                                            <asp:BoundField DataField="Head_NAME" HeaderText="Head Name" />
                                                            <asp:BoundField DataField="TYPE" HeaderText="Type" HtmlEncode="False">
                                                                <ItemStyle HorizontalAlign="Right"></ItemStyle>
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="HEAD_ENTRY_VALUE" HeaderText="Value" HtmlEncode="False"
                                                                FooterText="Total:-">
                                                                <ItemStyle HorizontalAlign="Right"></ItemStyle>
                                                            </asp:BoundField>
                                                            <asp:TemplateField HeaderText="Amount">
                                                                <ItemTemplate>
                                                                    <cc1:NumericTextBox ID="txtValue" runat="server" Width="100px" Text='<%# Bind("HEAD_VALUE") %>'
                                                                        CssClass="txtno"></cc1:NumericTextBox>
                                                                </ItemTemplate>
                                                                <ItemStyle HorizontalAlign="Right" Width="100px" />
                                                            </asp:TemplateField>
                                                        </Columns>
                                                    </asp:GridView>
                                                </td>
                                            </tr>
                                        </tbody>
                                    </table>
                                 </div>
                             <div id="pageFooter">
                                  <table>
                                        <tr>
                                            <th>
                                                Order No<span style="color: #ff0000">*</span></th>
                                            <td>
                                            </td>
                                            <th>
                                                Order Date<span style="color: #ff0000">*</span></th>
                                            <td>
                                            </td>
                                            <th>
                                                From Month<span style="color: #ff0000">*</span></th>
                                            <td>
                                            </td>
                                            <th>
                                                Remark</th>
                                            <td>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:TextBox ID="txtOrderNo" runat="server" CssClass="textbox"></asp:TextBox>
                                            </td>
                                            <td>
                                            </td>
                                            <td><asp:TextBox ID="txtOrderDate" runat="server" CssClass="textbox"></asp:TextBox>
                                            </td>
                                            <td>
                                            </td>
                                            <td>
                                                <uc3:MonthYear runat="server" ID="MonthYear" />
                                                
                                            </td>
                                            <td>
                                                &nbsp;</td>
                                            <td>
                                                <asp:TextBox ID="txtRemark" runat="server" CssClass="textbox" Width="224px"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:Button ID="btnSubmit" runat="server" Width="70px" Text="Submit" CssClass="btnBrown"
                                                    OnClick="btnSubmit_Click"></asp:Button>
                                        </tr>
                                    </table>
                                 </div>
                        </ContentTemplate>
              </asp:UpdatePanel>
        </div>  


    </div>
</asp:Content>

