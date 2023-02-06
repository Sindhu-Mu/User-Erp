<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/FullLength.master" AutoEventWireup="true" CodeFile="FeeProcess.aspx.cs" Inherits="Finance_BankAccount" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script lang="javascript" type="text/javascript">
        // Client Side Validation Script
    </script>
    <div class="container">
        <div class="heading">
            <h2>Fee Process

            </h2>

        </div>

        <div id="cBody">
            <div id="cHead">

                <table>
                    <tr style="vertical-align: bottom; text-align: left;">
                        <th>Session<span style="color: #ff0000">*</span></th>
                        <td>&nbsp;</td>
                        <th>Sem Type<span style="color: #ff0000">*</span></th>
                        <td>&nbsp;</td>
                        <th>Process Name<span style="color: #ff0000">*</span></th>
                        <td>&nbsp;</td>
                        <th>Start Date<span style="color: #ff0000">*</span></th>
                        <td>&nbsp;</td>
                        <th>Last Date<span style="color: #ff0000">*</span></th>
                        <td>&nbsp;</td>
                        <td></td>
                    </tr>
                    <tr style="vertical-align: top;">
                        <td>
                            <asp:DropDownList ID="ddlSession" runat="server">
                            </asp:DropDownList></td>
                        <td>&nbsp;</td>
                        <td>
                            <asp:RadioButtonList ID="RLSemType" runat="server" CellPadding="0" CellSpacing="0"
                                Font-Bold="True" ForeColor="#C00000" RepeatDirection="Horizontal">
                                <asp:ListItem Selected="True" Value="0">Even</asp:ListItem>
                                <asp:ListItem Value="1">Odd</asp:ListItem>
                            </asp:RadioButtonList></td>
                        <td>&nbsp;</td>
                        <td>
                            <asp:TextBox ID="txtProcessName" runat="server" Width="205px" CssClass="textbox"></asp:TextBox>
                        </td>
                        <td>&nbsp;</td>
                        <td>
                            <asp:TextBox ID="txtStartDt" runat="server" CssClass="textbox" Width="80px"></asp:TextBox></td>
                        <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender2" runat="server" Mask="99/99/9999" MaskType="Date" TargetControlID="txtStartDt">
                                            </ajaxToolkit:MaskedEditExtender>
                                            <ajaxToolkit:CalendarExtender ID="CalendarExtender2" runat="server" Format="dd/MM/yyyy" TargetControlID="txtStartDt">
                                            </ajaxToolkit:CalendarExtender>

                        <td>&nbsp;</td>
                        <td>
                            <asp:TextBox ID="txtLastDt" runat="server" CssClass="textbox" Width="80px"></asp:TextBox>&nbsp;</td>
                        <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender1" runat="server" Mask="99/99/9999" MaskType="Date" TargetControlID="txtLastDt">
                                            </ajaxToolkit:MaskedEditExtender>
                                            <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd/MM/yyyy" TargetControlID="txtLastDt">
                                            </ajaxToolkit:CalendarExtender>

                        <td></td>
                        <td>
                            <asp:Button ID="btnSave" OnClick="btnSave_Click" runat="server" Text="Save" CssClass="btnBrown"
                                Width="60px"></asp:Button></td>
                    </tr>
                </table>


            </div>
            <div id="cCenter">

                <table>
                    <tr>
                        <td>

                            <asp:GridView ID="gvFeeProcess" runat="server" Width="97%" ShowHeader="true" OnRowCommand="gvFeeProcess_RowCommand"
                                DataKeyNames="FEE_PROS_ID" AutoGenerateColumns="False" CellPadding="3" EmptyDataText="No record found" CssClass="gridDynamic">
                                <Columns>
                                    <asp:BoundField HeaderText="S#" DataField="ROW">
                                        <ItemStyle Width="15px" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="FEE_PROS_NAME" HeaderText="PROCESS NAME">
                                        <ItemStyle Width="200px" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="ACA_SESN_VALUE" HeaderText="SESSION ">
                                        <ItemStyle Width="90px" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="SEM_TYPE_VALUE" HeaderText="SEM TYPE ">
                                        <ItemStyle Width="80px" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="FEE_PROS_ST_DT" HeaderText="START DT" DataFormatString="{0:dd/MM/yyyy}">
                                        <ItemStyle Width="80px" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="FEE_PROS_ED_DT" HeaderText="CLOSE DT" DataFormatString="{0:dd/MM/yyyy}">
                                        <ItemStyle Width="80px" />
                                    </asp:BoundField>
                                    <asp:CommandField ButtonType="Image" SelectImageUrl="~/images/edit.jpg" ShowSelectButton="True">
                                        <ItemStyle Width="50px" />
                                    </asp:CommandField>
                                    <asp:TemplateField ShowHeader="False" HeaderText="Status">
                                        <ItemStyle Width="20px" HorizontalAlign="Right" />
                                        <ItemTemplate>
                                            <asp:ImageButton ID="imgAct" runat="server" CausesValidation="false" CommandArgument='<%# Bind("FEE_PROS_ID") %>'
                                                CommandName="Delete" ImageUrl="~/images/deactivate.gif" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                                <SelectedRowStyle BackColor="#99FF33" />
                            </asp:GridView>


                        </td>
                    </tr>
                </table>

            </div>
            <div id="cFooter">
                <!-- Content Header ex:Buttons-->

            </div>
        </div>
    </div>

</asp:Content>

