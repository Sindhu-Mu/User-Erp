<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/FullLength.master" AutoEventWireup="true" CodeFile="FeeChequeReport.aspx.cs" Inherits="Finance_BankAccount" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script language="javascript" type="text/javascript">
        // Client Side Validation Script

    </script>
    <div class="container">
        <div class="heading">
            <h2>Cheque Report

            </h2>

        </div>

        <div id="cBody">
            <div id="cHead">
                <!-- Content  Header ex: Filters-->
                <table style="width: 100%">
                    <tr>
                        <th>Cheque Number</th>

                        <th>Enrollment No.</th>

                        <th>From Date</th>

                        <th>To Date</th>

                        <th>Status</th>

                        <th>Mode Type<span style="color: Red">*</span></th>

                    </tr>
                    <tr>
                        <td>
                            <asp:TextBox ID="txtChequeNo" runat="server"></asp:TextBox>
                        </td>

                        <td>
                            <asp:TextBox ID="txtEnRoll" runat="server"></asp:TextBox>
                        </td>

                        <td>
                            <asp:TextBox ID="txtDateFrom" runat="server"></asp:TextBox>
                        </td>

                        <td>
                            <asp:TextBox ID="txtDateTo" runat="server"></asp:TextBox>
                        </td>

                        <td>
                            <asp:DropDownList ID="ddlStatus" runat="server" Width="100px">
                                <asp:ListItem Value="0">All</asp:ListItem>
                                <asp:ListItem Value="1">Cleared</asp:ListItem>
                                <asp:ListItem Value="2">Peding</asp:ListItem>
                            </asp:DropDownList>
                        </td>

                        <td>
                            <asp:DropDownList ID="ddlMode" runat="server" Width="100px"></asp:DropDownList>
                        </td>

                        <td>
                            <asp:Button ID="btnShow" runat="server" Text="Show"
                                OnClick="btnShow_Click" />
                        </td>
                    </tr>
                </table>

            </div>
            <div id="cCenter">
                <!-- Content Header ex: Grids-->
                <div style="max-height: 500px; overflow: scroll">
                    <asp:GridView ID="gvShow" runat="server" AutoGenerateColumns="False" Width="100%"
                        EmptyDataText="No Record Found" DataKeyNames="RCV_TRAN_MODE_ID"
                        OnRowCommand="gvShow_RowCommand">
                        <Columns>
                            <asp:TemplateField HeaderText="S#">
                                <ItemTemplate>
                                    <%# ((GridViewRow)Container).RowIndex + 1%>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="STU_ADM_NO" HeaderText="Enrollment#" />
                            <asp:BoundField DataField="FEE_RCV_RECEIPT_NO" HeaderText="Receipt#" />
                            <asp:BoundField DataField="PAY_MODE_VALUE" HeaderText="MODE TYPE" />
                            <asp:BoundField DataField="RCV_TRAN_MODE_NO" HeaderText="Cheque/DD Number" />
                            <asp:BoundField DataField="RCV_TRAN_MODE_DT" HeaderText="Deposit Date" />
                            <asp:BoundField DataField="RCV_TRAN_MODE_AMT" HeaderText="AMOUNT" DataFormatString="{0:N2}"
                                HtmlEncode="False"></asp:BoundField>
                            <asp:BoundField DataField="CLEARANCE_DATE" HeaderText="Date"></asp:BoundField>
                            <asp:TemplateField HeaderText="Clearance Date (MM/DD/YYYY)">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtDate" runat="server">
                                         
                                    </asp:TextBox>
                                    <ajaxToolkit:CalendarExtender ID="CalendarExtender2" runat="server" Format="dd/MM/yyyy"
                                        TargetControlID="txtDate">
                                    </ajaxToolkit:CalendarExtender>
                                    <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender2" runat="server" Mask="99/99/9999"
                                        MaskType="Date" TargetControlID="txtDate">
                                    </ajaxToolkit:MaskedEditExtender>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:CommandField ShowSelectButton="true" ButtonType="Button" SelectText="Update" />

                            <%--<asp:CommandField ShowDeleteButton="true" ButtonType="Button" DeleteText="Cancel" />--%>
                        </Columns>
                    </asp:GridView>
                </div>


            </div>
            <div id="cFooter">
                <!-- Content Header ex:Buttons-->
            </div>
            <table>
                <tr>
                    <td>
                        <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd/MM/yyyy"
                            TargetControlID="txtDateFrom">
                        </ajaxToolkit:CalendarExtender>
                        <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender1" runat="server" Mask="99/99/9999"
                            MaskType="Date" TargetControlID="txtDateFrom">
                        </ajaxToolkit:MaskedEditExtender>

                        <ajaxToolkit:CalendarExtender ID="CalendarExtender3" runat="server" Format="dd/MM/yyyy"
                            TargetControlID="txtDateTo">
                        </ajaxToolkit:CalendarExtender>
                        <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender3" runat="server" Mask="99/99/9999"
                            MaskType="Date" TargetControlID="txtDateTo">
                        </ajaxToolkit:MaskedEditExtender>



                    </td>
                </tr>
            </table>
        </div>
    </div>

</asp:Content>

