<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/FullLength.master" AutoEventWireup="true" CodeFile="rptPur_Main.aspx.cs" Inherits="Inventory_rptPur_Main" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="container">
        <div class="heading">
            <h2>Purchase Report</h2>
        </div>
        <div>

            <table id="tblColumns">
                <tr>
                    <td style="width: 60%; vertical-align: top">
                        <table>
                            <tr>
                                <th>Filters
                                </th>
                            </tr>
                            <tr>
                                <th>Purchase Requisition
                                </th>
                            </tr>
                            <tr>
                                <td>
                                    <table>
                                        <tr>
                                            <td>
                                                <table>
                                                    <tr>
                                                        <th colspan="2" style="width: 100%">By Year
                                                        </th>
                                                        <th colspan="2" style="width: 100%">By Pur. Req. No.</th>
                                                        <th colspan="2" style="width: 100%">By Status
                                                        </th>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="2" style="width: 200px">
                                                            <asp:DropDownList ID="ddlReqYear" runat="server">
                                                                <asp:ListItem Value="0">ALL</asp:ListItem>
                                                                <asp:ListItem Value="2018-19">2018-19</asp:ListItem>
                                                                <asp:ListItem Value="2017-18">2017-18</asp:ListItem>
                                                                <asp:ListItem Value="2016-17">2016-17</asp:ListItem>
                                                                <asp:ListItem Value="2015-16">2015-16</asp:ListItem>
                                                                <asp:ListItem Value="2014-15">2014-15</asp:ListItem>
                                                                <asp:ListItem Value="2013-14">2013-14</asp:ListItem>
                                                                <asp:ListItem Value="2012-13">2012-13</asp:ListItem>
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td colspan="2" style="width: 200px">
                                                            <asp:DropDownList ID="ddlReqNo" runat="server" Width="80px">
                                                            </asp:DropDownList>
                                                        </td>

                                                        <td colspan="2" style="width: 200px">
                                                            <asp:DropDownList ID="ddlReqStatus" runat="server">
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
                                <th>FAN Allocation</th>
                            </tr>
                            <tr>
                                <td>
                                    <table>
                                        <tr>
                                            <th colspan="2" style="width: 100%">By FAN No.</th>
                                            <th colspan="2" style="width: 100%">By Department</th>
                                            <th colspan="2" style="width: 100%">By Pur. Req. No. </th>
                                        </tr>
                                        <tr>
                                            <td style="width: 200px" colspan="2">
                                                <asp:DropDownList ID="ddlFanNo" runat="server">
                                                </asp:DropDownList></td>
                                            <td style="width: 200px" colspan="2">
                                                <asp:DropDownList ID="ddlFANDept" runat="server">
                                                </asp:DropDownList></td>
                                            <td style="width: 200px" colspan="2">
                                                <asp:DropDownList ID="ddlFANReqNo" runat="server">
                                                </asp:DropDownList></td>

                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <table>
                                        <tr>
                                            <th colspan="2" style="width: 100%">By Status</th>

                                            <th colspan="3">By Date </th>
                                        </tr>
                                        <tr>
                                            <td style="width: 200px" colspan="2">
                                                <asp:DropDownList ID="ddlFANStatus" runat="server">
                                                </asp:DropDownList></td>


                                            <td>
                                                <asp:DropDownList ID="ddlFANDate" runat="server" Width="80px" AutoPostBack="true" OnSelectedIndexChanged="DateType_Change">
                                                    <asp:ListItem Value="0" Text="All"></asp:ListItem>
                                                    <asp:ListItem Value="1" Text="Less Than"></asp:ListItem>
                                                    <asp:ListItem Value="2" Text="Greater Than"></asp:ListItem>
                                                    <asp:ListItem Value="3" Text="Between"></asp:ListItem>
                                                </asp:DropDownList></td>
                                            <td>
                                                <asp:TextBox ID="txtFANSD" runat="server" Width="95px"></asp:TextBox>&nbsp;
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtFANED" runat="server" Width="90px"></asp:TextBox>&nbsp;
                                            </td>

                                        </tr>
                                    </table>
                                </td>
                            </tr>


                            <tr>
                                <th>Purchase Order
                                </th>
                            </tr>
                            <tr>
                                <td>
                                    <table>
                                        <tr>
                                            <th>By Year</th>
                                            <th>By Pur. Order No.</th>
                                            <th>By Fan No.</th>
                                            <th>By Pur. Req. No.</th>

                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:DropDownList ID="ddlPOYear" runat="server" Width="131px">
                                                    <asp:ListItem Value="0">ALL</asp:ListItem>
                                                    <asp:ListItem Value="2015-16">2015-16</asp:ListItem>
                                                    <asp:ListItem Value="2014-15">2014-15</asp:ListItem>
                                                    <asp:ListItem Value="2013-14">2013-14</asp:ListItem>
                                                    <asp:ListItem Value="2012-13">2012-13</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="ddlPONo" runat="server" Width="139px">
                                                </asp:DropDownList>
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="ddlPOFAN" runat="server" Width="139px">
                                                </asp:DropDownList>
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="ddlPOReqNo" runat="server">
                                                </asp:DropDownList></td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>

                            <tr>
                                <td>
                                    <table>
                                        <tr>
                                            <th>By Supplier</th>
                                            <th colspan="3">By Date </th>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:DropDownList ID="ddlPOSup" runat="server" Width="250px">
                                                </asp:DropDownList></td>


                                            <td>
                                                <asp:DropDownList ID="ddlPODate" runat="server" Width="80px" AutoPostBack="true" OnSelectedIndexChanged="DateType_Change">

                                                    <asp:ListItem Value="0" Text="All"></asp:ListItem>
                                                    <asp:ListItem Value="1" Text="Less Than"></asp:ListItem>
                                                    <asp:ListItem Value="2" Text="Greater Than"></asp:ListItem>
                                                    <asp:ListItem Value="3" Text="Between"></asp:ListItem>
                                                </asp:DropDownList></td>
                                            <td>
                                                <asp:TextBox ID="txtPOSD" runat="server" Width="95px"></asp:TextBox>&nbsp;
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtPOED" runat="server" Width="90px"></asp:TextBox>&nbsp;
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>


                        </table>
                    </td>
                    <td style="width: 40%; vertical-align: top">
                        <table >
                            <tr>
                                <th>Fields
                                </th>
                            </tr>
                            <tr>
                                <th>Purchase Requisition
                                </th>
                            </tr>
                            <tr>
                                <td>
                                    <asp:CheckBoxList ID="chkPurReq" runat="server" CssClass="checkList" RepeatColumns="3">
                                        <asp:ListItem Value="IT.ITEM_NAME" Text="Req.Item Name"></asp:ListItem>
                                        <asp:ListItem Value="VEN.ORG_NAME" Text="Req.Vendor Name"></asp:ListItem>
                                        <asp:ListItem Value="PURD.REQ_ITEM_QTY" Text="Req.Quantity"></asp:ListItem>
                                        <asp:ListItem Value="CONVERT(VARCHAR,PROC_TRAN.IN_DT,103)" Text="Req.Date"></asp:ListItem>
                                        <asp:ListItem Value="PURD.REQ_ITEM_RATE" Text="Req.Rate"></asp:ListItem>
                                        <asp:ListItem Value="PURD.REQ_JUSTIFICATION" Text="Req.Justification"></asp:ListItem>
                                        <asp:ListItem Value="EV.EMP_NAME" Text="Requested By"></asp:ListItem>
                                        <%--<asp:ListItem Value="PURM.PUR_REQ_NO" Text="Pur.Req.No."></asp:ListItem>--%>
                                        <asp:ListItem Value="STO.STO_NAME" Text="Req.Store Name"></asp:ListItem>
                                    </asp:CheckBoxList>
                                </td>
                            </tr>
                            <tr>
                                <th>FAN Allocation</th>
                            </tr>
                            <tr>
                                <td>
                                    <asp:CheckBoxList ID="chkFAN" runat="server" CssClass="checkList" RepeatColumns="3">
                                        <asp:ListItem Value="FANM.FAN_NO" Text="FAN No."></asp:ListItem>
                                        <asp:ListItem Value="CONVERT(VARCHAR,FANM.FAN_ASSIGN_DT,103)" Text="FAN Date"></asp:ListItem>
                                        <asp:ListItem Value="FANM.FAN_AMOUNT" Text="FAN Amount"></asp:ListItem>
                                        <asp:ListItem Value="EV1.EMP_NAME" Text="FAN Assign By"></asp:ListItem>
                                        <asp:ListItem Value="PURM.PUR_REQ_NO" Text="FAN Pur. Req. No."></asp:ListItem>
                                    </asp:CheckBoxList>
                                </td>
                            </tr>
                            <tr>
                                <th>Purchase Order</th>
                            </tr>
                            <tr>
                                <td>
                                    <asp:CheckBoxList ID="chkPO" runat="server" CssClass="checkList" RepeatColumns="3">
                                        <asp:ListItem Value="POM.PO_NO" Text="Pur.Order No."></asp:ListItem>
                                        <asp:ListItem Value="IT2.Item_Name" Text="PO Item Name"></asp:ListItem>
                                        <asp:ListItem Value="POD.QTY" Text="PO Quantity"></asp:ListItem>
                                        <asp:ListItem Value="POD.RATE" Text="PO Rate"></asp:ListItem>
                                        <asp:ListItem Value="POD.TAX" Text="PO Tax"></asp:ListItem>
                                        <asp:ListItem Value="POD.DISCOUNT" Text="PO Discount"></asp:ListItem>
                                        <asp:ListItem Value="POD.AMOUNT" Text="PO Amount"></asp:ListItem>
                                        <asp:ListItem Value="POM.PO_OTHER_CHARGES" Text="PO Other Charges"></asp:ListItem>
                                        <asp:ListItem Value="POD.SPECIFICATION" Text="PO Specification"></asp:ListItem>
                                        <asp:ListItem Value="STO2.Sto_Name" Text="PO Store Name"></asp:ListItem>
                                        <asp:ListItem Value="VEN2.ORG_NAME" Text="PO Supplier Name"></asp:ListItem>
                                        <asp:ListItem Value="EV2.EMP_NAME" Text="PO Order By"></asp:ListItem>

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
                <tr>
                    <td>
                        <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtPOSD"
                            Format="dd/MM/yyyy">
                        </ajaxToolkit:CalendarExtender>
                        <ajaxToolkit:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtPOED"
                            Format="dd/MM/yyyy">
                        </ajaxToolkit:CalendarExtender>
                        <ajaxToolkit:CalendarExtender ID="CalendarExtender3" runat="server" TargetControlID="txtFANSD"
                            Format="dd/MM/yyyy">
                        </ajaxToolkit:CalendarExtender>
                        <ajaxToolkit:CalendarExtender ID="CalendarExtender4" runat="server" TargetControlID="txtFANED"
                            Format="dd/MM/yyyy">
                        </ajaxToolkit:CalendarExtender>
                    </td>
                </tr>
            </table>

        </div>
    </div>
</asp:Content>

