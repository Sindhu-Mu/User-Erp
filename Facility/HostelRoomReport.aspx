<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/FullLength.master" AutoEventWireup="true" CodeFile="HostelRoomReport.aspx.cs" Inherits="Facility_HostelReport" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <script lang ="javascript" type="text/javascript">
        function CheckControl(ctrl) {
            if (bTrim(document.getElementById(ctrl).value) == "" || bTrim(document.getElementById(ctrl).value) == "." || bTrim(document.getElementById(ctrl).value) == "Select") {
                document.getElementById(ctrl).style.backgroundColor = "#fc6";
                return false;
            }
            else
                document.getElementById(ctrl).style.backgroundColor = "#fff";
            return true;
        }
        function Allotvalidate() {
            var flag = true;
            var msg = "", ctrl = "";
            if (!CheckControl("<%=ddlComplex.ClientID%>")) {
                msg += "- Select Complex From List. \n";
                if (ctrl == "")
                    ctrl = "<%=ddlComplex.ClientID%>";
                flag = false;
            }
            if (!CheckControl("<%=ddlStatus.ClientID%>")) {
                msg += "- Select Status From List. \n";
                if (ctrl == "")
                    ctrl = "<%=ddlStatus.ClientID%>";
                flag = false;
            }
            if (!CheckControl("<%=ddlSession.ClientID%>")) {
                msg += "- Select Session From List. \n";
                if (ctrl == "")
                    ctrl = "<%=ddlSession.ClientID%>";
                flag = false;
            }
            if (msg != "") alert(msg);
            if (ctrl != "")
                document.getElementById(ctrl).focus();              
            return flag;

        }
        </script>
    <div class="container">
        <div class="heading">
            <h2>Hostel Main Report</h2>
        </div>
        <div>
            <table>
                <tr>
                    <td>
                        <table style="width: 100%; border-collapse: collapse; border-spacing: 0px;">
                            <tr>
                                <td>
                                    <table style="width: 100%; margin: 0px; border: 0px;"
                                        id="tblColumns">
                                        <tr>
                                            <td style="width: 60%; border-right-style: ridge; vertical-align: top">
                                                <table style="margin: 0px; border: 0px; width: 100%;">
                                                    <tr>
                                                        <th>Filters
                                                        </th>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <table style="margin: 0px; border: 0px;">
                                                                <tr>
                                                                    <td>
                                                                        <table style="margin: 0px; border: 0px;">
                                                                            <tr>
                                                                                <th style="width: 100px">By Complex<span class="required">*</span></th>
                                                                                <th style="width: 100px">By Floor</th>
                                                                                <th style="width: 100px">By Type</th>
                                                                                <th style="width: 100px">By Room</th>
                                                                                <th style="width: 100px">By Session</th>
                                                                            </tr>
                                                                            <tr>
                                                                                <td style="width:100px">
                                                                                    <asp:DropDownList ID="ddlComplex" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlComplex_SelectedIndexChanged" Width="100px"></asp:DropDownList>
                                                                                </td>
                                                                                 <td style="width:100px">
                                                                                    <asp:DropDownList ID="ddlFloor" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlFloor_SelectedIndexChanged" Width="100px"></asp:DropDownList>
                                                                                </td> 
                                                                                <td style="width:100px">
                                                                                    <asp:DropDownList ID="ddlRoomCategory" runat="server" Width="100px" AutoPostBack="True" OnSelectedIndexChanged="ddlRoomCategory_SelectedIndexChanged1"></asp:DropDownList>
                                                                                </td>
                                                                               
                                                                                <td style="width:100px">
                                                                                    <asp:DropDownList ID="ddlRoom" runat="server" Width="100px"></asp:DropDownList>
                                                                                </td>
                                                                                <td style="width:100px">
                                                                                    <asp:DropDownList ID="ddlSession" runat="server" Width="100px"></asp:DropDownList>
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
                                                                    <th style="width: 130px">By Institute</th>
                                                                    <th style="width: 130px">By Batch</th>
                                                                    <th style="width: 130px">By Course</th>
                                                                    <th style="width:130px">By Year</th>
                                                                </tr>
                                                                <tr>
                                                                    <td style="width: 100px">
                                                                        <asp:DropDownList ID="ddlIns" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlIns_SelectedIndexChanged" Width="125px">
                                                                        </asp:DropDownList></td>
                                                                    <td style="width: 100px">
                                                                        <asp:DropDownList ID="ddlBatch" runat="server" Width="125px">
                                                                        </asp:DropDownList></td>
                                                                    <td style="width: 100px">
                                                                        <asp:DropDownList ID="ddlCourse" runat="server" AutoPostBack="True" OnSelectedIndexChanged= "ddlCourse_SelectedIndexChanged" Width="125px">
                                                                        </asp:DropDownList></td>
                                                                   <td style="width:100px">
                                                                       <asp:DropDownList ID="ddlYear" runat="server" AutoPostBack="true">
                                                                           <asp:ListItem Value="0">All</asp:ListItem>
                                                                           <asp:ListItem Value="1">Final Year</asp:ListItem>
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
                                                                    <th style="width: 180px">By Branch</th>
                                                                     <th style="width:180px">By Semester</th>
                                                                    <th style="width:180px">By Section</th>
                                                                </tr>
                                                                <tr>
                                                                    <td style="width: 125px">
                                                                        <asp:DropDownList ID="ddlBranch" runat="server" Width="125px">
                                                                        </asp:DropDownList></td>
                                                                     <td style="width:125px">
                                                                        <asp:DropDownList ID="ddlSem" runat="server" Width="125px">
                                                                        </asp:DropDownList></td>
                                                                    <td style="width: 125px">
                                                                        <asp:DropDownList ID="ddlSec" runat="server" Width="125px">
                                                                        </asp:DropDownList></td>
                                                                  </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <table style="margin: 0px; border: 0px;">
                                                                <tr>
                                                                    <th style="width: 180px">By Gender</th>
                                                                    <th style="width: 180px">By Religion</th>
                                                                    <th style="width: 180px">By Cast</th>
                                                                </tr>
                                                                <tr>
                                                                    <td style="width: 180px">
                                                                        <asp:DropDownList ID="ddlGender" runat="server" Width="125px">
                                                                        </asp:DropDownList>
                                                                    </td>
                                                                    <td style="width: 180px">
                                                                        <asp:DropDownList ID="ddlReligion" runat="server" Width="125px">
                                                                        </asp:DropDownList>
                                                                    </td>
                                                                    <td style="width:180px">
                                                                        <asp:DropDownList ID="ddlCast" runat="server" Width="125px">
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
                                                                    <th style="width:180px">By State</th>
                                                                    <th style="width:180px">By City</th>
                                                                    <th style="width:180px">By Status<span class="required">*</span></th>
                                                                   
                                                                    </tr>
                                                                <tr>
                                                                    <td style="width: 180px">
                                                                        <asp:DropDownList ID="ddlState" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlState_SelectedIndexChanged">
                                                                        </asp:DropDownList></td>
                                                                    <td style="width: 180px">
                                                                        <asp:DropDownList ID="ddlCity" runat="server">
                                                                        </asp:DropDownList></td>
                                                                    <td style="width: 180px">
                                                                        <asp:DropDownList ID="ddlStatus" runat="server">
                                                                             <asp:ListItem>All</asp:ListItem>
                                                                            <asp:ListItem Value="-1" Text="Apply"></asp:ListItem>
                                                                            <asp:ListItem Value="1" Text="Room Selected"></asp:ListItem> 
                                                                            <asp:ListItem Value="2" Text="Room Allotted"></asp:ListItem>
                                                                          
                                                                        </asp:DropDownList></td>
                                                                   <%-- <td style="width:125px">
                                                                       <%-- <asp:DropDownList ID="ddlFees" runat="server" Width="80px">
                                                                         <asp:ListItem Value=" " Text="Select"></asp:ListItem>
                                                                         <asp:ListItem Value="0" Text="Paid"></asp:ListItem>
                                                                         <asp:ListItem Value="1" Text="Not Paid"></asp:ListItem> 
                                                                        </asp:DropDownList>--%>
                                                                   <%-- </td>--%>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <table style="margin: 0px; border: 0px;">
                                                                <tr>
                                                                    <th style="width:540px" colspan="4">By Date Of Allotment</th>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        <asp:DropDownList ID="ddlAlloted" runat="server" Width="125px" OnSelectedIndexChanged="ddlAlloted_SelectedIndexChanged" AutoPostBack="True">
                                                                        <asp:ListItem Value="0" Text="All"></asp:ListItem>
                                                                        <asp:ListItem Value="1" Text="Less Than"></asp:ListItem>
                                                                        <asp:ListItem Value="2" Text="Greater Than"></asp:ListItem>
                                                                        <asp:ListItem Value="3" Text="Between"></asp:ListItem>
                                                                        </asp:DropDownList>
                                                                    </td>
                                                                    <td>
                                                                        <asp:TextBox ID="txtDOA1" runat="server" Width="125px"></asp:TextBox>
                                                                    </td>
                                                                    <td>
                                                                        <asp:TextBox ID="txtDOA2" runat="server" Width="125px"></asp:TextBox>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                             <table>
                                                <tr>
                                                    
                                                    <th style="width:180px">By Sem Type</th>
                                                    <th style="width:180px">By Head Type</th>
                                                    <th style="width:180px">By Fee Head</th>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:DropDownList ID="ddlSemType" runat="server" Width="100%"></asp:DropDownList></td>
                                                    <td>
                                                        <asp:DropDownList ID="ddlHeadType" runat="server" Width="100px" AutoPostBack="true" >
                                                            <asp:ListItem Value="0">Select</asp:ListItem>
                                                            <asp:ListItem Value="1">Facility</asp:ListItem>
                                                        </asp:DropDownList></td>
                                                    <td>
                                                        <asp:DropDownList ID="ddlFeeHead" runat="server" Width="180px">
                                                        <asp:ListItem Value="0">Select</asp:ListItem>
                                                            <asp:ListItem Value="13">Hostel Caution Deposit</asp:ListItem>
                                                            <asp:ListItem Value="14">Hostel Fee</asp:ListItem>
                                                            </asp:DropDownList>
                                                    </td>
                                                </tr>
                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <%--<table style="margin:0px; border:0px;">
                                                                <tr>
                                                                    <th style="width:100%" colspan="4">By Date Of Vacant</th>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                    <asp:DropDownList ID="ddlVacant" runat="server" Width="125px" OnSelectedIndexChanged="ddlVacant_SelectedIndexChanged" AutoPostBack="True">
                                                                   <asp:ListItem Value="0" Text="All"></asp:ListItem>
                                                                   <asp:ListItem Value="1" Text="Less Than"></asp:ListItem>
                                                                   <asp:ListItem Value="2" Text="Greater Than"></asp:ListItem>
                                                                   <asp:ListItem Value="3" Text="Between"></asp:ListItem>
                                                                   </asp:DropDownList>
                                                                    </td>
                                                                    <td>
                                                                        <asp:TextBox ID="txtDOV1" runat="server" Width="125px"></asp:TextBox>
                                                                    </td>
                                                                    <td>
                                                                        <asp:TextBox ID="txtDOV2" runat="server" Width="125px"></asp:TextBox>
                                                                    </td>
                                                                </tr>
                                                            </table>--%>
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
                                                   <%-- <tr>
                                                        <th>Personal
                                                        </th>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:CheckBoxList ID="ChPersonal" runat="server" RepeatColumns="3">
                                                                <asp:ListItem Value="SV.SEM_ROLL_NO">Roll No</asp:ListItem>
                                                                <asp:ListItem Value="SV.GEN_VALUE">Gender</asp:ListItem>
                                                                <asp:ListItem Value="Convert(varchar,SV.DT_OF_BIRTH,103)">Date of Birth</asp:ListItem>
                                                                <asp:ListItem Value="SV.FATHER_NAME">Father Name</asp:ListItem>
                                                                <asp:ListItem Value="SV.MOTHER_NAME">Monther Name</asp:ListItem>
                                                                <asp:ListItem Value="SV.REL_VALUE">Religion</asp:ListItem>
                                                                <asp:ListItem Value="SV.CAS_VALUE">Category</asp:ListItem>
                                                                <asp:ListItem Value="SV.BLO_GRP_VALUE">Blood Group</asp:ListItem>
                                                                <asp:ListItem Value="SV.PHN_NO">Mobile No</asp:ListItem>
                                                                <asp:ListItem Value="SV.EMAIL">E-Mail ID</asp:ListItem>                                                  
                                                            </asp:CheckBoxList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <th>Academic</th>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:CheckBoxList ID="ChAcademic" runat="server" RepeatColumns="3">
                                                                <asp:ListItem Value="SV.INS_VALUE">Institution </asp:ListItem>
                                                                <asp:ListItem Value="SV.ACA_BATCH_NAME">Batch</asp:ListItem>
                                                                <asp:ListItem Value="SV.PGM_SHORT_NAME">Course Name</asp:ListItem>
                                                                <asp:ListItem Value="SV.BRN_SHORT_NAME">Branch Name</asp:ListItem>
                                                                <asp:ListItem Value="SV.ACA_SEM_NO">Semester</asp:ListItem>
                                                                <asp:ListItem Value="SV.ACA_SEC_NAME">Section</asp:ListItem>                                            
                                                                <asp:ListItem Value="SV.FORM_NO">Application No</asp:ListItem>
                                                            </asp:CheckBoxList>
                                                        </td>
                                                    </tr>--%>
                                                    <tr>
                                                        <th>Address</th>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:CheckBoxList ID="ChCommunication" runat="server" RepeatColumns="3">
                                                                <asp:ListItem Value="(SV.ADD_1+' '+ISNULL(SV.ADD_2,''))">Address</asp:ListItem>
                                                                <asp:ListItem Value="SV.CIT_VALUE">City</asp:ListItem>
                                                                <asp:ListItem Value="SV.STA_VALUE">State</asp:ListItem>
                                                                <asp:ListItem Value="SV.COU_VALUE">Country</asp:ListItem>
                                                                <asp:ListItem Value="SV.PHN_NO">PHONE</asp:ListItem>
                                                                <asp:ListItem Value=" SV.PARENT_CONTACT">Parent Mobile</asp:ListItem>
                                                                <asp:ListItem Value="SV.EMAIL">Mail </asp:ListItem>
                                                             </asp:CheckBoxList>
                                                        </td>
                                                        </tr>
                                                    <tr>
                                                        <th> Hostel Detail</th>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                             <asp:CheckBoxList ID="ChHostel" runat="server" RepeatColumns="3">
                                                             <asp:ListItem Value="FC.FAC_CMPLX_NAME">Complex Name</asp:ListItem>
                                                             <asp:ListItem Value="FR.ROOM_FLOOR">Floor</asp:ListItem>
                                                             <asp:ListItem Value="convert(varchar,MAXIMUM_PRSN)+ ' ' +'Seater'">Type</asp:ListItem>
                                                             <asp:ListItem Value="EM.EMP_NAME">Alloted By</asp:ListItem>
                                                             <asp:ListItem Value="CASE WHEN SHD.STS = -1 THEN 'Apply' when shd.STS=1 then 'Room Selected' when shd.STS=2 then 'Room Alloted' when shd.STS=0 then 'Room Selected' END">Status</asp:ListItem>
                                                             <asp:ListItem Value="FHRT.ALLOTE_REMARK">Remark</asp:ListItem>
                                                             <asp:ListItem Value="CONVERT(VARCHAR,FHRA.OCCUPIED_DATE,103)">Alloted Date</asp:ListItem>
                                                             <asp:ListItem Value="CONVERT(VARCHAR,SHD.APP_DATE,103)">Apply Date</asp:ListItem>
                                                             <asp:ListItem Value="CONVERT(VARCHAR,FHRT.ALLOT_DT,103)">Action Date</asp:ListItem>
                                                             </asp:CheckBoxList>    
                                                        </td>
                                                    </tr>
                                                     <tr>
                                        <th>Fees</th>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:CheckBoxList ID="ChFeeMain" runat="server" RepeatColumns="3">
                                                <asp:ListItem Value="(FD_FEE_AMT)">Demand</asp:ListItem>
                                                <asp:ListItem Value="(FD_ADJUST_AMT)">Adjust</asp:ListItem>
                                               
                                                <asp:ListItem Value="(FD_RCV_AMT)">Receive</asp:ListItem>
                                                 <asp:ListItem Value="(FEE_WAVE_OFF)">Wave</asp:ListItem>
                                                <asp:ListItem Value="(FD_BALANCE_AMT)">Balance</asp:ListItem>
                                            </asp:CheckBoxList></td>
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
                                <td style="height: 20px">
                                   <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtDOA1"
                                        Format="dd/MM/yyyy">
                                    </ajaxToolkit:CalendarExtender>
                                    <ajaxToolkit:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtDOA2"
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

