<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/FullLength.master" AutoEventWireup="true" CodeFile="Arrear.aspx.cs" Inherits="PayRoll_Arrear" %>
<%@ Register Src="~/Control/MonthYear.ascx" TagPrefix="uc1" TagName="MonthYear" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div id="" class="container">
    <div class="heading">
       <h2>Monthly Arrear</h2>
        </div>
    <div id="bodyHeader">
        <table>
            <tr>
                <th>Employee Code</th>
                <th>To Month</th>
                <th>Arrear Type</th>
                </tr>
            <tr>
                <td><asp:TextBox ID="txtEmp" runat="server" CssClass="textBox" Width="228px" placeholder="Employee Name or Code"></asp:TextBox>
                        <ajaxToolkit:AutoCompleteExtender ID="AutoCompleteExtender2" runat="server" CompletionInterval="500"
                            CompletionSetCount="12" ContextKey="1" EnableCaching="true" MinimumPrefixLength="1"
                            ServiceMethod="GetEmployeeList" ServicePath="~\AutoComplete.asmx" TargetControlID="txtEmp">
                        </ajaxToolkit:AutoCompleteExtender></td>
                <td> <uc1:MonthYear runat="server" ID="MonthYear" /></td>
                <td>
                     <asp:DropDownList ID="ddlArrearType" runat="server">                                                    
                                                    <asp:ListItem Value="1">Balance Days</asp:ListItem>
                                                    <asp:ListItem Value="2">Balance Increment</asp:ListItem>
                                                </asp:DropDownList>

                </td>
                <td><asp:Button ID="btnDetail" runat="server" Text="View Arrear" CssClass="btnBrown" OnClick="btnDetail_Click"  /></td>
                </tr>

            </table>
        </div>
        <div id="bodyCenter">
             <div style="overflow: auto; width: 100%">
                                                    <asp:GridView ID="gvTranDetail" Width="97%" runat="server" CssClass="gridDynamic"
                                                        AutoGenerateColumns="False" DataKeyNames="EMP_ID" HeaderStyle-CssClass="GVFixedHeader">
                                                        <Columns>
                                                            <asp:TemplateField HeaderText="S.No.">
                                                                <ItemTemplate>
                                                                    <%# ((GridViewRow)Container).RowIndex + 1%>
                                                                    .
                                                                </ItemTemplate>
                                                                <ItemStyle Width="15px" />
                                                            </asp:TemplateField>
                                                            <asp:BoundField DataField="EMP_ID" HeaderText="EMP.CODE" />
                                                            <asp:BoundField DataField="EMP_NAME" HeaderText="NAME" />
                                                          <asp:BoundField DataField="ATT_MONTH" HeaderText="Month" />
                                                            <asp:BoundField DataField="ATT_YEAR" HeaderText="Year" />
                                                            <asp:TemplateField HeaderText="AMOUNT">
                                                                <ItemTemplate>
                                                                    <cc1:NumericTextBox ID="txtAmount" runat="server" Text='<%# Bind("AMMOUNT") %>' CssClass="txtno"
                                                                        AllowDecimal="true" MaxLength="6" DecimalPlaces="2" Width="100px"></cc1:NumericTextBox></ItemTemplate>
                                                                <ItemStyle Width="100px" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="REMARKS">
                                                                <ItemTemplate>
                                                                    <asp:TextBox ID="txtRemark" CssClass="textbox" runat="server" Text=''
                                                                        Width="200px" />
                                                                </ItemTemplate>
                                                                <ItemStyle Width="200px" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField>
                                                                <ItemTemplate>
                                                                    <asp:CheckBox id="chkBox" runat="server"/>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                        </Columns>
                                                        <HeaderStyle CssClass="GVFixedHeader" />
                                                    </asp:GridView>
                                                </div>
            </div>
        <div id="bodyFooter">
              <asp:Button id="btnSave" runat="server" Text="Save" OnClick="btnSave_Click"/>
            <asp:TextBox ID="txtXML" runat="server" Visible="false"></asp:TextBox> 
            </div>
        </div>
</asp:Content>

