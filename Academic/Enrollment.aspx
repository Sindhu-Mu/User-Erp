<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/FullLength.master" AutoEventWireup="true" CodeFile="Enrollment.aspx.cs" Inherits="Academic_Enrollment" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="container">
        <div class="heading">
            <h2>Enrollment Process
            </h2>
        </div>
        <div>
            <table>
                <tr>
                    <td>
                        <table>
                            <tr>
                                <th>By Institute
                                </th>
                                <th>By Program
                                </th>
                                <th>By Branch
                                </th>
                                 <th>By Caste
                                </th>
                                <th>By Type
                                </th>
                                <th>By Lateral
                                </th>
                                <th>By Year
                                </th>
                                <th>By Form No.
                                </th>
                            </tr>
                            <tr>
                                <td>
                                    <asp:DropDownList ID="ddlIns" runat="server" Width="80px" OnSelectedIndexChanged="ddlIns_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlPgm" runat="server" Width="140px" OnSelectedIndexChanged="ddlPgm_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlBranch" runat="server" Width="140px"></asp:DropDownList>
                                </td>
                                 <td>
                                    <asp:DropDownList ID="ddlCaste" runat="server" Width="80px">                                        
                                        <asp:ListItem Value="0">All</asp:ListItem>
                                        <asp:ListItem Value="1">SC/ST</asp:ListItem>                                       
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlType" runat="server" Width="90px">
                                        
                                        <asp:ListItem Value="3">Final Admission</asp:ListItem>
                                        <asp:ListItem Value="2">Provisional Admission</asp:ListItem>
                                        <asp:ListItem Value="1">Registration</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlLateral" runat="server" Width="90px">
                                        <asp:ListItem Value="0">No</asp:ListItem>
                                        <asp:ListItem Value="1">Yes</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlYear" runat="server" Width="90px"></asp:DropDownList>
                                </td>
                                <td>
                                    <cc1:NumericTextBox ID="txtForm" runat="server" AllowDecimal="false" AllowNegative="false" Width="80px"></cc1:NumericTextBox>
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
                        <div style="min-height:400px;overflow:auto">
                            <asp:GridView ID="gvDetail" runat="server" AutoGenerateColumns="false" CssClass="gridDynamic" EmptyDataText="No Record Found">
                                <Columns>
                                    <asp:TemplateField HeaderText="S.No.">
                                        <ItemTemplate>
                                            <%# ((GridViewRow)Container).RowIndex + 1%>
                                    .
                                        </ItemTemplate>
                                        <ItemStyle Width="10px" />
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="ADM_REG_NO" HeaderText="Reg No." />
                                    <asp:BoundField DataField="APP_NO" HeaderText="App No." />
                                    <asp:BoundField DataField="APP_NAME" HeaderText="Name" />
                                    <asp:BoundField DataField="GEN_VALUE" HeaderText="Gender" />
                                    <asp:BoundField DataField="INS_CRS_SHORT_NAME" HeaderText="Program" />
                                    <asp:BoundField DataField="BRANCH_SHORT_NAME" HeaderText="Branch" />
                                    <asp:BoundField DataField="ADM_REG_DT" HeaderText="Date" DataFormatString="{0:dd/MM/yyyy}" />
                                </Columns>
                            </asp:GridView>
                        </div>

                    </td>
                </tr>
                <tr>
                    <td style="text-align:right;">
                        <asp:Button ID="btnEnroll" runat="server" Text="Process Enrollment" OnClick="btnEnroll_Click" Visible="false" />
                    </td>
                </tr>
            </table>
        </div>
    </div>
</asp:Content>

