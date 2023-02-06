<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/FullLength.master" AutoEventWireup="true" CodeFile="MonthlyCugBill.aspx.cs" Inherits="PayRoll_MonthlyCugBill" %>

<%@ Register Src="~/Control/MonthYear.ascx" TagPrefix="uc1" TagName="MonthYear" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="container">
        <div id="heading" class="heading">
            <h2>Monthly CUG Bill</h2>
        </div>
        <div id="bodyHeader">
            <table>
                <tbody>
                    <tr >
                        <th>Employee Code</th>
                        <th>Month</th>
                        <td></td>
                    </tr>
                    <tr >
                        <td>
                            <asp:TextBox ID="txtEmpCode" runat="server" Width="95px" CssClass="textbox"></asp:TextBox></td>
                        <td>
                           
                            <uc1:MonthYear runat="server" ID="MonthYear" />
                            &nbsp;&nbsp;
                        </td>
                        <td>
                            <asp:Button ID="btnEntry" runat="server" Text="Bill Entery" CssClass="btnBrown" OnClick="btnEntry_Click"></asp:Button>
                            <asp:Button ID="btnShow" OnClick="btnShow_Click" runat="server" Width="70px" Text="Detail Show"
                                CssClass="btnBrown"></asp:Button></td>
                    </tr>
                </tbody>
            </table>
        </div>
        <div id="bodyCenter">
             <asp:GridView ID="gvAllowance" runat="server" CssClass="gridDynamic" AutoGenerateColumns="False">
                                                                <Columns>
                                                                    <asp:TemplateField HeaderText="S.No.">
                                                                        <ItemTemplate>
                                                                            <%# ((GridViewRow)Container).RowIndex + 1%>
                                                                        </ItemTemplate>
                                                                        <ItemStyle Width="20px" />
                                                                    </asp:TemplateField>
                                                                    <asp:BoundField DataField="EMP_ID" HeaderText="EMP.CODE" />
                                                                    <asp:BoundField DataField="EMP_NAME" HeaderText="EMPLOYEE NAME" />
                                                                    <asp:BoundField DataField="DEPT_VALUE" HeaderText="DEPARTMENT" />
                                                                    <asp:BoundField HeaderText="CONTACT NO." DataField="CUG_CONTACT_NO" />
                                                                    <asp:BoundField HeaderText="ALLOWANCE" DataField="ALLOWANCE_CAT_VALUE" />
                                                                    <asp:TemplateField>
                                                                        <ItemTemplate>
                                                                            <cc1:NumericTextBox ID="txtBillAmount" runat="server" AllowDecimal="false" MaxLength="10"
                                                                                Width="100px" CssClass="txtno"></cc1:NumericTextBox></ItemTemplate>
                                                                    </asp:TemplateField>
                                                                </Columns>
                                                            </asp:GridView>
            <br/>
               <asp:GridView ID="gvBill" runat="server" CssClass="gridDynamic" AutoGenerateColumns="False">
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="S.No.">
                                                            <ItemTemplate>
                                                                <%# ((GridViewRow)Container).RowIndex + 1%>
                                                            </ItemTemplate>
                                                            <ItemStyle Width="20px" />
                                                        </asp:TemplateField>
                                                        <asp:BoundField DataField="EMP_ID" HeaderText="EMP.CODE" />
                                                        <asp:BoundField DataField="EMP_NAME" HeaderText="EMPLOYEE NAME" />
                                                        <asp:BoundField DataField="DEPT_VALUE" HeaderText="DEPARTMENT" />
                                                        <asp:BoundField HeaderText="CONTACT NO." DataField="CUG_CONTACT_NO" />
                                                        <asp:BoundField HeaderText="ALLOWANCE" DataField="ALLOWANCE_CAT_VALUE" />
                                                        <asp:BoundField HeaderText="BILL" DataField="HEAD_VALUE" />
                                                        <asp:BoundField HeaderText="DEDUCTION" DataField="DEDUCTION" />
                                                    </Columns>
                                                </asp:GridView>
        </div>
        <div id="body_footer" style="text-align:right">
             <asp:TextBox ID="txtData" runat="server" Visible="False"></asp:TextBox>
                                                            <asp:Button ID="btnSave" runat="server" Width="80px" Text="Save" CssClass="btnBrown"
                                                                OnClick="btnSave_Click" Visible="false"></asp:Button>
        </div>
    </div>
</asp:Content>

