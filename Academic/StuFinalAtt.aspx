<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/FullLength.master" AutoEventWireup="true" CodeFile="StuFinalAtt.aspx.cs" Inherits="Academic_StuFinalAtt" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="container">
        <div class="heading">
            <h2>Final Attendance Calculation
            </h2>
        </div>
        <div>
            <table>
                <tr>
                    <td>
                        <table>
                            <tr>
                                <th>Institute
                                </th>
                                <th>Program
                                </th>
                                <th>Branch
                                </th>
                                <th>Batch
                                </th>
                                <th>Semester
                                </th>
                                <th>Date
                                </th>
                            </tr>
                            <tr>
                                <td>
                                    <asp:DropDownList ID="ddlIns" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlIns_SelectedIndexChanged"></asp:DropDownList>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlPgm" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlPgm_SelectedIndexChanged"></asp:DropDownList>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlBrn" runat="server"></asp:DropDownList>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlBatch" runat="server"></asp:DropDownList>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlSem" runat="server"></asp:DropDownList>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtDate" runat="server"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:Button ID="btnCalculate" runat="server" Text="Calculate" OnClick="btnCalculate_Click" />
                                </td>
                            </tr>
                            <tr>
                                <th>%age<span class="required">*</span>
                                </th>
                                <td>
                                    <asp:DropDownList ID="ddlPercentage" runat="server" required="required" Width="80px">
                                    </asp:DropDownList>
                                </td>
                                <th>Credit
                                </th>
                                <td>
                                    <cc1:NumericTextBox ID="txtCredit" runat="server" AllowNegative="false" Text="0"></cc1:NumericTextBox>
                                </td>
                                <th>View Type
                                </th>
                                <td>
                                    <asp:DropDownList ID="ddlType" runat="server">
                                        <asp:ListItem Text="Detail" Value="0"></asp:ListItem>
                                        <asp:ListItem Text="Paper Code With %age" Value="1"></asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    <asp:Button ID="btnView" runat="server" Text="View" OnClick="btnView_Click" />
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>

                <tr>
                    <td>
                        <asp:GridView ID="gvDetain" runat="server" CssClass="gridDynamic">
                            <Columns>
                                <asp:TemplateField HeaderText="S.No.">
                                    <ItemTemplate>
                                        <%# ((GridViewRow)Container).RowIndex + 1%>
                                                        .
                                    </ItemTemplate>
                                    <ItemStyle Width="10px" />
                                </asp:TemplateField>

                            </Columns>

                        </asp:GridView>
                    </td>
                </tr>
                <tr>
                    <td>
                        <table>
                            <tr id="trButton" runat="server" visible="false">
                                <td>
                                    <asp:Button id="btnPrint" runat="server" Text="Print" OnClick="btnPrint_Click"/>
                                </td>
                                <td>
                                    <asp:Button ID="btnExport" runat="server" Text="Export To Excel" OnClick="btnExport_Click" />
                                </td>
                                <td>
                                    <asp:Button ID="btnSubmit" runat="server"  Text="Submit" OnClick="btnSubmit_Click"/>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </div>
    </div>
</asp:Content>

