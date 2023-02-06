<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/FullLength.master" AutoEventWireup="true" CodeFile="rpt_ExamRegFeeReceive.aspx.cs" Inherits="Finance_rpt_ExamRegFeeReceive" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="container">
        <div class="heading">
            <h2>Exam Reg Fee Receive Report</h2>
        </div>
        <div>
            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                <ContentTemplate>
                    <table>
                        <tr>
                            <td>

                                <table>

                                    <tr>
                                        <th>Examination<span class="required">*</th>
                                        <th>By Exam Type<span class="required">*</th>
                                        <th>By Insitute</th>
                                        <th>By Program</th>
                                        <th style="height: 26px">By Branch</th>
                                        <th style="height: 26px">By Sem</th>
                                        <th>By Type</th>
                                        <th style="height: 26px">By Receipt<span class="required">*</th>

                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:DropDownList ID="ddlExamination" runat="server" Width="120px">
                                            </asp:DropDownList>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlexamtypes" runat="server" AutoPostBack="true" Width="120px">
                                                <asp:ListItem  Value="0" Text="All"></asp:ListItem>
                                                <asp:ListItem Value="1" Text="Back"></asp:ListItem>
                                                <asp:ListItem Value="2" Text="Detained"></asp:ListItem>
                                                <asp:ListItem Value="3" Text="Improvement"></asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlIns" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlIns_SelectedIndexChanged" Width="120px"></asp:DropDownList>

                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlPgm" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlPgm_SelectedIndexChanged" Width="120px"></asp:DropDownList>

                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlBranch" runat="server" AutoPostBack="True" Width="120px"></asp:DropDownList>

                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlSem" runat="server" Width="110px"></asp:DropDownList>

                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlType" runat="server" Width="110px">
                                                <asp:ListItem Value="-1" Text="Select"></asp:ListItem>
                                                <asp:ListItem Value="0" Text="Cleared"></asp:ListItem>
                                                <asp:ListItem Value="1" Text="Permission"></asp:ListItem>
                                            </asp:DropDownList>
                                        </td>


                                        <td>
                                            <asp:DropDownList ID="ddlReceipt" runat="server" Width="120px">
                                                <asp:ListItem Value="0" Text="With Receipt"></asp:ListItem>
                                                <asp:ListItem Value="1" Text="Without Receipt"></asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>

                                        <th style="height: 26px">By date</th>

                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:TextBox ID="txtdate" runat="server" Width="120px"></asp:TextBox>
                                            <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender2" runat="server" Mask="99/99/9999" MaskType="Date" TargetControlID="txtdate">
                                            </ajaxToolkit:MaskedEditExtender>
                                            <ajaxToolkit:CalendarExtender ID="CalendarExtender2" runat="server" Format="dd/MM/yyyy" TargetControlID="txtdate">
                                            </ajaxToolkit:CalendarExtender>

                                        </td>
                                        <td>
                                            <asp:Button ID="btnView" runat="server" Text="View" OnClick="btnView_Click" />
                                        </td>
                                        <td>
                                            <asp:Button ID="BtnExport" runat="server" Text="Export To Excel" OnClick="BtnExport_Click" Width="114px" />
                                        </td>

                                    </tr>

                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <div style="height: 410px; overflow: auto; width: 100%;">

                                    <asp:GridView ID="gvFeeReport" runat="server" CssClass="gridDynamic" Width="97%" ShowFooter="True" OnRowCommand="gvFeeReport_RowCommand">
                                        <Columns>
                                            <asp:ButtonField Text="Print" CommandName="show"/>
                                            <asp:TemplateField HeaderText="S.No">
                                                <ItemTemplate>
                                                    <%#((GridViewRow)Container).RowIndex +1 %>
                                                   
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                        </Columns>
                                    </asp:GridView>
                                </div>
                            </td>
                        </tr>

                    </table>
                </ContentTemplate><Triggers><asp:PostBackTrigger ControlID="btnExport" /></Triggers>
            </asp:UpdatePanel>
        </div>

    </div>
</asp:Content>

