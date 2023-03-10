<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/FullLength.master" AutoEventWireup="true" CodeFile="rptSto_Main.aspx.cs" Inherits="Inventory_rptSto_Main" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="container">
        <div class="heading">
            <h2>Store Report</h2>
        </div>
        <div>

            <table>
                <tr>
                    <td>
                        <table
                            id="tblColumns">
                            <tr>
                                <td style="width: 60%; border-right-style: ridge; vertical-align: top">
                                    <table>
                                        <tr>
                                            <th>Filters
                                            </th>
                                        </tr>
                                        <tr>
                                            <th>Store GRN
                                            </th>
                                        </tr>
                                        <tr>
                                            <td>
                                                <table style="margin: 0px; border: 0px;">
                                                    <tr>
                                                        <td>
                                                            <table style="margin: 0px; border: 0px;">
                                                                <tr>
                                                                    <th colspan="2" style="width: 35%">By PO No.
                                                                    </th>
                                                                    <th colspan="2" style="width: 35%">By GRN No.</th>
                                                                    <th colspan="2" style="width: 100%">By Received By
                                                                    </th>
                                                                </tr>
                                                                <tr>
                                                                    <td colspan="2" style="width: 200px">
                                                                        <asp:DropDownList ID="ddlGRN_PO" runat="server" Width="180px">
                                                                        </asp:DropDownList>
                                                                    </td>
                                                                    <td colspan="2" style="width: 200px">
                                                                        <asp:DropDownList ID="ddlGRN" runat="server" Width="180px">
                                                                        </asp:DropDownList>
                                                                    </td>

                                                                    <td colspan="2" style="width: 200px">
                                                                        <asp:DropDownList ID="ddlGRN_RcvBy" runat="server" Width="180px">
                                                                        </asp:DropDownList>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>

                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <table style="margin: 0px; border: 0px;">
                                                    <tr>

                                                        <th style="width: 100%">By Item</th>
                                                        <th colspan="3">By Date </th>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:DropDownList ID="ddlGRN_Item" runat="server" Width="200px" AutoPostBack="true"></asp:DropDownList>
                                                        </td>
                                                        <td>
                                                            <asp:DropDownList ID="ddlGRN_Date" runat="server" Width="80px" AutoPostBack="true" OnSelectedIndexChanged="DateType_Change">
                                                                <asp:ListItem Value="0" Text="All"></asp:ListItem>
                                                                <asp:ListItem Value="1" Text="Less Than"></asp:ListItem>
                                                                <asp:ListItem Value="2" Text="Greater Than"></asp:ListItem>
                                                                <asp:ListItem Value="3" Text="Between"></asp:ListItem>
                                                            </asp:DropDownList></td>
                                                        <td>
                                                            <asp:TextBox ID="txtGRNSD" runat="server" Width="95px"></asp:TextBox>&nbsp;
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtGRNED" runat="server" Width="90px"></asp:TextBox>&nbsp;
                                                        </td>

                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <th>Store Indent</th>
                                        </tr>
                                        <tr>
                                            <td>
                                                <table style="margin: 0px; border: 0px;">
                                                    <tr>
                                                        <th colspan="2" style="width: 35%">By Indent Id</th>
                                                        <th colspan="2" style="width: 35%">By Store</th>
                                                        <th colspan="2" style="width: 100%">By Item</th>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 200px" colspan="2">
                                                            <asp:DropDownList ID="ddlInd" runat="server" Width="180px">
                                                            </asp:DropDownList></td>
                                                        <td style="width: 200px" colspan="2">
                                                            <asp:DropDownList ID="ddlInd_Store" runat="server" Width="180px">
                                                            </asp:DropDownList></td>
                                                        <td style="width: 200px" colspan="2">
                                                            <asp:DropDownList ID="ddlInd_Item" runat="server" Width="180px">
                                                            </asp:DropDownList></td>

                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <table style="margin: 0px; border: 0px;">
                                                    <tr>
                                                        <th colspan="2" style="width: 100%">By Status</th>

                                                        <th colspan="3">By Date </th>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 200px" colspan="2">
                                                            <asp:DropDownList ID="ddlInd_Status" runat="server">
                                                            </asp:DropDownList></td>


                                                        <td>
                                                            <asp:DropDownList ID="ddlInd_Date" runat="server" Width="80px" AutoPostBack="true" OnSelectedIndexChanged="DateType_Change">
                                                                <asp:ListItem Value="0" Text="All"></asp:ListItem>
                                                                <asp:ListItem Value="1" Text="Less Than"></asp:ListItem>
                                                                <asp:ListItem Value="2" Text="Greater Than"></asp:ListItem>
                                                                <asp:ListItem Value="3" Text="Between"></asp:ListItem>
                                                            </asp:DropDownList></td>
                                                        <td>
                                                            <asp:TextBox ID="txtIndSD" runat="server" Width="95px"></asp:TextBox>&nbsp;
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtIndED" runat="server" Width="90px"></asp:TextBox>&nbsp;
                                                        </td>

                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>


                                        <tr>
                                            <th>Store Issue Voucher
                                            </th>
                                        </tr>
                                        <tr>
                                            <td>
                                                <table style="margin: 0px; border: 0px;">
                                                    <tr>
                                                        <th style="width: 50%" colspan="2">By Indent ID</th>
                                                        <th style="width: 50%" colspan="2">By SIV ID</th>

                                                    </tr>
                                                    <tr>
                                                        <td style="width: 200px" colspan="2">
                                                            <asp:DropDownList ID="ddlSIVInd" runat="server" Width="270px">
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td style="width: 200px" colspan="2">
                                                            <asp:DropDownList ID="ddlSIV" runat="server" Width="270px">
                                                            </asp:DropDownList>
                                                        </td>

                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>

                                        <tr>
                                            <td>
                                                <table style="margin: 0px; border: 0px;">
                                                    <tr>
                                                        <th style="width: 100%" colspan="2">By Item</th>
                                                        <th colspan="3">By Date </th>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 200px" colspan="2">
                                                            <asp:DropDownList ID="ddlSIVItem" runat="server" Width="200px">
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td>
                                                            <asp:DropDownList ID="ddlSIVDate" runat="server" Width="80px" AutoPostBack="true" OnSelectedIndexChanged="DateType_Change">

                                                                <asp:ListItem Value="0" Text="All"></asp:ListItem>
                                                                <asp:ListItem Value="1" Text="Less Than"></asp:ListItem>
                                                                <asp:ListItem Value="2" Text="Greater Than"></asp:ListItem>
                                                                <asp:ListItem Value="3" Text="Between"></asp:ListItem>
                                                            </asp:DropDownList></td>
                                                        <td>
                                                            <asp:TextBox ID="txtSIVSD" runat="server" Width="95px"></asp:TextBox>&nbsp;
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtSIVED" runat="server" Width="90px"></asp:TextBox>&nbsp;
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <table style="margin: 0px; border: 0px;">
                                                </table>
                                            </td>
                                        </tr>

                                    </table>
                                </td>
                                <td style="width: 60%; vertical-align: top">
                                    <table style="width: 100%">
                                        <tr>
                                            <th>Fields
                                            </th>
                                        </tr>
                                        <tr>
                                            <th>Store GRN
                                            </th>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:CheckBoxList ID="chkGRN" runat="server" CssClass="checkList" RepeatColumns="3">
                                                    <%--<asp:ListItem Value="POM.PO_NO" Text="PO No."></asp:ListItem>--%>
                                                    <asp:ListItem Value="GRN.GRN_NO" Text="GRN No."></asp:ListItem>
                                                    <asp:ListItem Value="GRN.GRN_DET" Text="GRN Detail"></asp:ListItem>
                                                    <asp:ListItem Value="GRN.CLN_NO" Text="Challan No."></asp:ListItem>
                                                    <asp:ListItem Value="EV.EMP_NAME" Text="GRN Received By"></asp:ListItem>
                                                    <asp:ListItem Value="GRN.EXT_CGS" Text="Extra Charges"></asp:ListItem>
                                                    <asp:ListItem Value="CONVERT(VARCHAR,GRN.GRN_DATE,103)" Text="Date"></asp:ListItem>
                                                    <asp:ListItem Value="IT.ITEM_NAME" Text="Item Name"></asp:ListItem>
                                                    <asp:ListItem Value="GRNI.QTY" Text="Received Quantity"></asp:ListItem>
                                                    <asp:ListItem Value="GRNI.AVLBL_QTY" Text="Available Quantity"></asp:ListItem>
                                                    <asp:ListItem Value="GRNI.RATE_PER_ITEM" Text="Rate Per Item"></asp:ListItem>
                                                    <asp:ListItem Value="GRNB.BILL_NO" Text="Bill No."></asp:ListItem>
                                                </asp:CheckBoxList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <th>Store Indent</th>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:CheckBoxList ID="chkInd" runat="server" CssClass="checkList" RepeatColumns="3">
                                                    <asp:ListItem Value="IND.IND_CAL_ID" Text="Indent No."></asp:ListItem>
                                                    <asp:ListItem Value="CONVERT(VARCHAR,IND.INS_DATE,103)" Text="Indent Date"></asp:ListItem>
                                                    <asp:ListItem Value="STO.STO_NAME" Text="Store"></asp:ListItem>
                                                    <asp:ListItem Value="IT.ITEM_NAME" Text="Item"></asp:ListItem>
                                                    <asp:ListItem Value="IND_IT.REQ_QTY" Text="Requested Qty"></asp:ListItem>
                                                    <asp:ListItem Value="IND_IT.APR_QTY" Text="Approved Qty"></asp:ListItem>
                                                    <asp:ListItem Value="IND_IT.ISD_QTY" Text="Issued Quantity"></asp:ListItem>
                                                    <asp:ListItem Value="IND_TRAN.IND_REM" Text="Remark"></asp:ListItem>
                                                    <asp:ListItem Value="IND_TRAN.IND_DONE_VALUE" Text="Status"></asp:ListItem>
                                                </asp:CheckBoxList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <th>Store Issue Voucher</th>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:CheckBoxList ID="chkSIV" runat="server" CssClass="checkList" RepeatColumns="3">
                                                    <asp:ListItem Value="SIV.SIV_CAL_ID" Text="SIV Id"></asp:ListItem>
                                                    <asp:ListItem Value="IND.IND_CAL_ID" Text="IND Id"></asp:ListItem>
                                                    <asp:ListItem Value="EV.EMP_NAME" Text="SIV Inseretd By"></asp:ListItem>
                                                    <asp:ListItem Value="CONVERT(VARCHAR,SIV.INS_DATE,103)" Text="SIV Date"></asp:ListItem>
                                                    <asp:ListItem Value="IT.ITEM_NAME" Text="SIV Item"></asp:ListItem>
                                                    <asp:ListItem Value="SIV_ITEM.QTY" Text="SIV Quantity"></asp:ListItem>
                                                </asp:CheckBoxList>
                                            </td>
                                        </tr>

                                        <tr>
                                            <td>
                                                <asp:Button ID="btnExecute" runat="server" Text="View" CssClass="btnBrown" Width="64px" OnClick="btnExecute_Click" /></td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td style="height: 20px">
                        <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtGRNSD"
                            Format="dd/MM/yyyy">
                        </ajaxToolkit:CalendarExtender>
                        <ajaxToolkit:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtGRNED"
                            Format="dd/MM/yyyy">
                        </ajaxToolkit:CalendarExtender>
                        <ajaxToolkit:CalendarExtender ID="CalendarExtender3" runat="server" TargetControlID="txtIndSD"
                            Format="dd/MM/yyyy">
                        </ajaxToolkit:CalendarExtender>
                        <ajaxToolkit:CalendarExtender ID="CalendarExtender4" runat="server" TargetControlID="txtIndED"
                            Format="dd/MM/yyyy">
                        </ajaxToolkit:CalendarExtender>
                        <ajaxToolkit:CalendarExtender ID="CalendarExtender5" runat="server" TargetControlID="txtSIVSD"
                            Format="dd/MM/yyyy">
                        </ajaxToolkit:CalendarExtender>
                        <ajaxToolkit:CalendarExtender ID="CalendarExtender6" runat="server" TargetControlID="txtSIVED"
                            Format="dd/MM/yyyy">
                        </ajaxToolkit:CalendarExtender>
                    </td>
                </tr>
            </table>

        </div>
    </div>
</asp:Content>

