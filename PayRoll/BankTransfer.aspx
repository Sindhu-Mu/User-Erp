<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/FullLength.master" AutoEventWireup="true" CodeFile="BankTransfer.aspx.cs" Inherits="PayRoll_BankTransfer" EnableEventValidation="false" %>

<%@ Register Src="~/Control/MonthYear.ascx" TagPrefix="uc1" TagName="MonthYear" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script lang="javascript" type="text/javascript">

        function SelectAllCheckboxes(spanChk) {


            var oItem = spanChk.children;
            var theBox = (spanChk.type == "checkbox") ?
                spanChk : spanChk.children.item[0];
            xState = theBox.checked;
            elm = theBox.form.elements;

            for (i = 0; i < elm.length; i++)
                if (elm[i].type == "checkbox" &&
                         elm[i].id != theBox.id) {

                    if (elm[i].checked != xState)
                        elm[i].click();

                }
        }

    </script>
    <div id="content" style="padding: 25px">
        <h1>Bank Transfer</h1>
        <hr />
        <table>

            <tr>
                <td>
                    <table >
                        <tr style="vertical-align:bottom">
                            <th >For Month<span style="color: #ff0000">*</span></th>
                            <th >Institution</th>
                            <th >Department </th>
                   
                            <th >Category</th>
                            <th >Payment Type</th>
                            <th>Min Salary </th>
                            <th>Max Salary</th>
                            <th >Maximum Amt. </th>
                           <th>Order By</th>
                        </tr>
                        <tr>
                            <td>
                                <uc1:MonthYear runat="server" ID="MonthYear" />
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlInsitution" runat="server" AutoPostBack="True"
                                    OnSelectedIndexChanged="ddlInsitution_SelectedIndexChanged">
                                </asp:DropDownList></td>
                            <td>
                                <asp:DropDownList ID="ddlDepartment" runat="server" >
                                    <asp:ListItem Value="0">Select</asp:ListItem>
                                </asp:DropDownList></td>
                            
                            <td>
                                <asp:DropDownList ID="ddlCategory" runat="server" Width="100px">
                                    <asp:ListItem Value="-1">Select</asp:ListItem>
                                    <asp:ListItem Value="1">Teaching</asp:ListItem>
                                    <asp:ListItem Value="0">Non-Teaching</asp:ListItem>
                                </asp:DropDownList></td>
                            <td>
                                <asp:DropDownList ID="ddlType" runat="server" >
                                    <asp:ListItem Value="1">A/C PAY</asp:ListItem>
                                    <asp:ListItem Value="0">Cash</asp:ListItem>
                                </asp:DropDownList></td>
                            <td>
                                <cc1:NumericTextBox ID="txtSalaryMin" runat="server" CssClass="txtno" AllowDecimal="true"
                                    MaxLength="10" DecimalPlaces="2" Width="100px" ></cc1:NumericTextBox>
                            </td>
                            <td>
                                <cc1:NumericTextBox ID="txtSalaryMax" runat="server" CssClass="txtno" AllowDecimal="true"
                                    MaxLength="10" DecimalPlaces="2" Width="100px" ></cc1:NumericTextBox>
                            </td>
                            <td>
                                <cc1:NumericTextBox ID="txtPay" runat="server" CssClass="txtno" AllowDecimal="true"
                                    MaxLength="10" DecimalPlaces="2"  Width="100px"></cc1:NumericTextBox>
                            </td>
                              <td>
                                   <asp:DropDownList ID="ddlOrder" runat="server" >
                                    <asp:ListItem Value="0">Code</asp:ListItem>
                                    <asp:ListItem Value="1">Gross Salary</asp:ListItem>
                                </asp:DropDownList>
                              </td>
                            <td>
                                <asp:Button ID="btnView" runat="server" CssClass="btnBrown" Font-Overline="False"
                                    OnClick="btnView_Click" Text="View " /></td>
                          
                        </tr>
                    </table>
                    <DIV>Reference Number:<asp:TextBox runat="server" ID="txtRefNo"></asp:TextBox></DIV>
                </td>
            </tr>
            <%--Fields--%>

            <tr>
                <td>
                    <asp:CheckBox runat="server" ID="add_employee" Text="Add Employee" OnCheckedChanged="add_employee_CheckedChanged"
                        AutoPostBack="true" />
                    <table id="add_employee_div" runat="server" visible="false">
                        <tr>
                            <td>Employee</td>
                            <td>
  <asp:TextBox ID="txtEmp" runat="server" CssClass="textBox" Width="228px" placeholder="Employee Name or Code"></asp:TextBox>
                        <ajaxToolkit:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" CompletionInterval="500"
                            CompletionSetCount="12" ContextKey="1" EnableCaching="true" MinimumPrefixLength="1"
                            ServiceMethod="GetEmployeeList" ServicePath="~\AutoComplete.asmx" TargetControlID="txtEmp">
                        </ajaxToolkit:AutoCompleteExtender>
                            </td>
                            <td style="text-align: center">
                                <asp:Button ID="btnAddEmp" runat="server" OnClick="btnAddEmp_Click" Text="Add" CssClass="btnBrown" />
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <asp:ListBox ID="listEmpCode" runat="server" Width="300px"></asp:ListBox>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <%--// Add Employee--%>

            <tr>
                <td>
                    <div style="overflow: auto; width: 100%">
                        <asp:GridView ID="GridShow" runat="server" AutoGenerateColumns="False" Width="97%"
                            DataKeyNames="SAL_REC_ID" CssClass="gridDynamic" ShowFooter="True">
                            <Columns>
                                <asp:TemplateField HeaderText="S.No.">
                                    <ItemTemplate>
                                        <%# ((GridViewRow)Container).RowIndex + 1%>
                                                        .
                                    </ItemTemplate>
                                    <ItemStyle Width="15px" />
                                </asp:TemplateField>
                                <asp:BoundField DataField="EMP_ID" HeaderText="EMP.CODE">
                                    <ItemStyle Width="70px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="EMP_NAME" HeaderText="NAME">
                                    <ItemStyle Width="230px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="SAL_PAYBALE" HeaderText="AMOUNT" FooterText="Total Payble">
                                    <ItemStyle Width="100px" HorizontalAlign="Right" Font-Bold="true" ForeColor="blue" />
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="AMOUNT PAYBALE">
                                    <ItemTemplate>
                                        <cc1:NumericTextBox ID="txtAmount" runat="server" Text='<%# Bind("SalToPay") %>'
                                            CssClass="txtno" AllowDecimal="true" MaxLength="6" DecimalPlaces="2" Width="100px"></cc1:NumericTextBox>
                                    </ItemTemplate>
                                    <ItemStyle Width="100px" />
                                </asp:TemplateField>
                                <%--<asp:TemplateField HeaderText="Remarks">
                                                    <ItemTemplate>
                                                        <%# ((GridViewRow)Container).RowIndex + 1%>
                                                        .
                                                    </ItemTemplate>
                                                    <ItemStyle Width="100px" />
                                                </asp:TemplateField>--%>
                                <%--<asp:BoundField DataField="SalToPay" HeaderText="AMOUNT PAYABLE" ReadOnly="false" />--%>
                                <asp:BoundField DataField="MONTH" HeaderText="MONTH">
                                    <ItemStyle Width="90px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="AC_NO" HeaderText="AC.NO">
                                    <ItemStyle Width="130px" />
                                </asp:BoundField>

                                <asp:TemplateField>

                                    <HeaderTemplate>
                                        <input id="chkAll" onclick="javascript: SelectAllCheckboxes(this);" type="checkbox"
                                            value="on" runat="server" style="border-right: blue 2px groove; border-top: blue 2px groove; border-left: blue 2px groove; border-bottom: blue 2px groove" />
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:CheckBox ID="chk" runat="server" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Remarks">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtRemark" runat="server"></asp:TextBox>
                                    </ItemTemplate>

                                    <ItemStyle Width="100px" />
                                </asp:TemplateField>
                            </Columns>
                            <PagerStyle BorderColor="#FFFFC0" Font-Size="Larger" Font-Underline="True" Wrap="True" />
                            <SelectedRowStyle BackColor="#99FF33" />
                            <HeaderStyle ForeColor="Blue" />
                        </asp:GridView>
                    </div>
                </td>
            </tr>
            <%--// Grid--%>

            <tr>
                <td align="center">
                    <div id="divCalculateButton" runat="server" visible="false">
                        <asp:Button ID="btnSave" runat="server" OnClick="btnSave_Click" Text="Save" CssClass="btnBrown" />
                        &nbsp;&nbsp;&nbsp;&nbsp;
                                        <asp:Button ID="btnCalculate" runat="server" Text="Calculate" CssClass="btnBrown"
                                            OnClick="btnCalculate_Click" />
                        &nbsp;&nbsp;&nbsp;&nbsp;
                                        <asp:Button ID="exportExcel" runat="server" Text="Export To Excel" CssClass="btnBrown"
                                            OnClick="btnExcel_Click" />
                        &nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp; &nbsp;
                                        <asp:TextBox ID="txtXML" runat="server" Visible="false"></asp:TextBox>
                    </div>
                    
                </td>
            </tr>
            <%--// Bind Data--%>
        </table>
    </div>
</asp:Content>

