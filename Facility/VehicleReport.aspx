<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/FullLength.master" AutoEventWireup="true" CodeFile="VehicleReport.aspx.cs" Inherits="Facility_VehicleReport" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="container">
        <div class="heading">
            <h2>Vehicle Requisition Report</h2>
        </div>
        <div>
            <table>
                <tr>
                    <td>
                        <table style="width: 100%; border-collapse: collapse; border-spacing: 0px;">
                            <tr>
                                <td>
                                    <table style="width: 100%; margin: 0px; border: 0px;" id="tblColumns">
                                        <tr>
                                            <td style="width: 60%; border-right-style: ridge; vertical-align: top">
                                                <table style="margin: 0px; border: 0px; width: 100%;">
                                                    <tr>
                                                        <th>Filters</th>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <table style="margin: 0px; border: 0px;">
                                                                <tr>
                                                                    <td>
                                                                         <table style="margin: 0px; border: 0px;">
                                                                             <tr>
                                                                                 <th style="width: 100px">By Institute</th>
                                                                                 <th style="width: 100px">By Department</th>
                                                                                 <th style="width: 100px">By Driver Name</th>
                                                                                 <th style="width: 100px">By Place</th>
                                                                             </tr>
                                                                             <tr>
                                                                                 <td style="width: 100px">
                                                                                     <asp:DropDownList ID="ddlIns" runat="server" Width="100px" AutoPostBack="True" OnSelectedIndexChanged="ddlIns_SelectedIndexChanged"></asp:DropDownList>
                                                                                 </td>
                                                                                 <td style="width: 100px">
                                                                                     <asp:DropDownList ID="ddlDept" runat="server" Width="100px"></asp:DropDownList>
                                                                                     </td>
                                                                                 <td style="width: 100px">
                                                                                     <asp:DropDownList ID="ddlDriver" runat="server" Width="100px"></asp:DropDownList>
                                                                                     </td>
                                                                                 <td style="width: 100px">
                                                                                     <asp:DropDownList ID="ddlPlace" runat="server" Width="100px"></asp:DropDownList>
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
                                                                     <th style="width: 100px" colspan="3">By Request Date</th>
                                                                    <th style="width: 100px">By Vehicle</th>
                                                                </tr>
                                                                <tr>
                                                                    <td style="width: 100px">
                                                                        <asp:DropDownList ID="ddlReqDt" runat="server" Width="100px" OnSelectedIndexChanged="DateType_Change" AutoPostBack="True">
                                                                        <asp:ListItem Value="0" Text="All"></asp:ListItem>
                                                                        <asp:ListItem Value="1" Text="Less Than"></asp:ListItem>
                                                                        <asp:ListItem Value="2" Text="Greater Than"></asp:ListItem>
                                                                        <asp:ListItem Value="3" Text="Between"></asp:ListItem>
                                                                        </asp:DropDownList>
                                                                    </td>
                                                                    <td style="width: 100px">
                                                                        <asp:TextBox ID="txtStartDt" runat="server" Width="100px"></asp:TextBox>
                                                                    </td>
                                                                    <td style="width: 100px">
                                                                        <asp:TextBox ID="txtEndDt" runat="server" Width="100px"></asp:TextBox>
                                                                        </td>
                                                                    <td style="width: 100px">
                                                                        <asp:DropDownList ID="ddlVeh" runat="server" Width="100px"></asp:DropDownList>
                                                                    </td>
                                                                </tr>
                                                                </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <table style="margin: 0px; border: 0px;">
                                                                <tr>
                                                                    <th style="width: 100px">By Status</th>
                                                                    <th style="width:100px" colspan="3">By Journey Date</th>
                                                                </tr>
                                                                <tr>
                                                                    <td style="width: 100px">
                                                                        <asp:DropDownList ID="ddlStatus" runat="server" Width="100px"></asp:DropDownList>
                                                                    </td>
                                                                    <td style="width:100px">
                                                                        <asp:DropDownList ID="ddlJouDate" runat="server" Width="100px" OnSelectedIndexChanged="DateType_Change" AutoPostBack="True">
                                                                        <asp:ListItem Value="0" Text="All"></asp:ListItem>
                                                                        <asp:ListItem Value="1" Text="Less Than"></asp:ListItem>
                                                                        <asp:ListItem Value="2" Text="Greater Than"></asp:ListItem>
                                                                        <asp:ListItem Value="3" Text="Between"></asp:ListItem>
                                                                        </asp:DropDownList>
                                                                    </td>
                                                                    <td style="width:100px">
                                                                        <asp:TextBox ID="txtSrtDt" runat="server" Width="100px"></asp:TextBox>
                                                                        </td>
                                                                    <td style="width:100px">
                                                                        <asp:TextBox ID="txtedDt" runat="server" Width="100px"></asp:TextBox>
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
                                                         <th>Fields</th>
                                                     </tr>
                                                     <tr>
                                                         <td>
                                                             <asp:CheckBoxList ID="ChVehicle" runat="server" RepeatColumns="3">
                                                                <asp:ListItem Value="EV.EMP_NAME">Emp Name</asp:ListItem>
                                                                <asp:ListItem Value="EV.DEPT_VALUE">Department</asp:ListItem>
                                                                <asp:ListItem Value="CASE WHEN VRD.VRD_JRNY_TYPE = 1 THEN 'ONE WAY' ELSE 'TWO WAY' END">Jounrney Type</asp:ListItem>
                                                                <asp:ListItem Value="CONVERT(varchar,VRD.VRD_JRNY_DT_TIME, 103)">Journey Date</asp:ListItem>
                                                                <asp:ListItem Value="VRM.VR_DESTI_ADD">Destination</asp:ListItem>
                                                                <asp:ListItem Value="CONVERT(varchar, VRT.VRT_DT, 103)">Request date</asp:ListItem>
                                                                <asp:ListItem Value="VRM.VR_PICK_UP_LOC">Pick Up Location</asp:ListItem>
                                                                <asp:ListItem Value="VRM.VR_NOP">Travellers</asp:ListItem>
                                                                <asp:ListItem Value="CASE WHEN VRM.VR_REQ_TYPE = 1 THEN 'Official' ELSE 'Personal' END">Request Type</asp:ListItem>
                                                                <asp:ListItem Value="EM.EMP_NAME">Driver</asp:ListItem>
                                                                <asp:ListItem Value="VM.VEH_REG_NO">Vehicle Number</asp:ListItem>                                                 
                                                              </asp:CheckBoxList>
                                                         </td>
                                                     </tr>
                                                     <tr>
                                                        <td>
                                                            <asp:Button ID="btnView" runat="server" Text="View" CssClass="btnBrown" Width="64px" OnClick="btnView_Click"/></td>
                                                    </tr>
                                                 </table>
                                             </td>
                                        </tr>
                                        </table>
                                </td>
                            </tr>
                            <tr>
                                <td style="height:20px">
                                    <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtStartDt"
                                        Format="dd/MM/yyyy">
                                    </ajaxToolkit:CalendarExtender>
                                    <ajaxToolkit:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtEndDt"
                                        Format="dd/MM/yyyy">
                                    </ajaxToolkit:CalendarExtender>
                                    <ajaxToolkit:CalendarExtender ID="CalendarExtender3" runat="server" TargetControlID="txtSrtDt"
                                        Format="dd/MM/yyyy">
                                    </ajaxToolkit:CalendarExtender>
                                    <ajaxToolkit:CalendarExtender ID="CalendarExtender4" runat="server" TargetControlID="txtedDt"
                                        Format="dd/MM/yyyy">
                                    </ajaxToolkit:CalendarExtender>
                                </td>
                            </tr>
                            </table>
                    </td>
                </tr>
            </table>
        </div>
    </div>
</asp:Content>

