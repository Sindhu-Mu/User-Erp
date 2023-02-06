<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/FullLength.master" AutoEventWireup="true" CodeFile="HallBooking.aspx.cs" Inherits="Facility_HallBooking" %>

<%@ Register Src="~/Control/MonthYear.ascx" TagPrefix="uc1" TagName="MonthYear" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
              <style type="text/css">
        .fancy-green .ajax__tab_header {
            background: url(../Siteimages/green_bg_Tab.gif) repeat-x;
            cursor: pointer;
        }

        .fancy-green .ajax__tab_hover .ajax__tab_outer, .fancy-green .ajax__tab_active .ajax__tab_outer {
            background: url(../Siteimages/green_left_Tab.gif) no-repeat left top;
        }

        .fancy-green .ajax__tab_hover .ajax__tab_inner, .fancy-green .ajax__tab_active .ajax__tab_inner {
            background: url(../Siteimages/green_right_Tab.gif) no-repeat right top;
        }

        .fancy .ajax__tab_header {
            font-size: 13px;
            font-weight: bold;
            color: #000;
            font-family: sans-serif;
        }

            .fancy .ajax__tab_active .ajax__tab_outer, .fancy .ajax__tab_header .ajax__tab_outer, .fancy .ajax__tab_hover .ajax__tab_outer {
                height: 46px;
            }

            .fancy .ajax__tab_active .ajax__tab_inner, .fancy .ajax__tab_header .ajax__tab_inner, .fancy .ajax__tab_hover .ajax__tab_inner {
                height: 46px;
                margin-left: 16px; /* offset the width of the left image */
            }

            .fancy .ajax__tab_active .ajax__tab_tab, .fancy .ajax__tab_hover .ajax__tab_tab, .fancy .ajax__tab_header .ajax__tab_tab {
                margin: 16px 16px 0px 0px;
            }

        .fancy .ajax__tab_hover .ajax__tab_tab, .fancy .ajax__tab_active .ajax__tab_tab {
            color: #fff;
        }

        .fancy .ajax__tab_body {
            font-family: Arial;
            font-size: 10pt;
            border-top: 0;
            border: 1px solid #999999;
            padding: 8px;
            background-color: #ffffff;
        }
    </style>
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

        function validateType() {
            var flag = true;
            var msg = "", ctrl = "";
            if (!CheckControl("<%=ddlComplex.ClientID%>")) {
                msg += "- Select Complex.\n";
                if (ctrl == "")
                    ctrl = "<%=ddlComplex.ClientID%>";
                flag = false;
            }
            if (!CheckControl("<%=ddlEvnt.ClientID%>")) {
                msg += "- Select Event From The List. \n";
                if (ctrl == "")
                    ctrl = "<%=ddlEvnt.ClientID%>";
                flag = false;
            }
            if (!CheckControl("<%=txtname.ClientID%>"))
            {
                msg += "-Enter Guest Name \n";
                if (ctrl == "")
                    ctrl = "<%=txtname.ClientID%>";
                flag = false;
            }
            if (!CheckControl("<%=txtFrmDt.ClientID%>")) {
                msg += "-Enter From Date \n";
                if (ctrl == "")
                    ctrl = "<%=txtFrmDt.ClientID%>";
                flag = false;
            }
            if (!CheckControl("<%=txttoDt.ClientID%>")) {
                msg += "-Enter to Date \n";
                if (ctrl == "")
                    ctrl = "<%=txttoDt.ClientID%>";
                flag = false;
            }
            if (!CheckControl("<%=txtFrmTime.ClientID%>")) {
                msg += "-Enter From Time.\n";
                if (ctrl == "")
                    ctrl = "<%=txtdetail.ClientID%>";
                flag = false;
            }
            if (!CheckControl("<%=txtToTime.ClientID%>")) {
                msg += "-Enter To Time.\n";
                if (ctrl == "")
                    ctrl = "<%=txtToTime.ClientID%>";
                flag = false;
            }
            if (!CheckControl("<%=txtNo.ClientID%>")) {
                msg += "-Enter Number of Persons \n";
                if (ctrl == "")
                    ctrl = "<%=txtNo.ClientID%>";
                flag = false;
            }
            if (!CheckControl("<%=txtdetail.ClientID%>")) {
                msg += "-Provide Detail Of the Event.\n";
                if (ctrl == "")
                    ctrl = "<%=txtdetail.ClientID%>";
                flag = false;
            }
            if (msg != "") alert(msg);
            if (ctrl != "")
                document.getElementById(ctrl).focus();
            return flag;
        }
        function ValidateHall()
        {
            var flag = true;
            var msg = "", ctrl = "";
            if (!CheckControl("<%=ddlBookedHall.ClientID%>")) {
                msg += "- Select Complex.\n";
                if (ctrl == "")
                    ctrl = "<%=ddlBookedHall.ClientID%>";
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
            <h2>Hall Booking</h2>
        </div>
        <table>
            <tr>
                <td>
                    <ajaxToolkit:TabContainer ID="tab1" runat="server" ActiveTabIndex="3" AutoPostBack="true" CssClass="fancy fancy-green">
                        <ajaxToolkit:TabPanel ID="TabPanel1" runat="server" HeaderText="New Booking">
                            <ContentTemplate>
                                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                    <ContentTemplate>
                                        <table>

                                            <tr>
                                                <th>Complex<span class="required">*</span></th>
                                                <td>
                                                    <asp:DropDownList ID="ddlComplex" runat="server"></asp:DropDownList></td>
                                            </tr>
                                            <tr>
                                                <th>Event Type<span class="required">*</span></th>
                                                <td>
                                                    <asp:DropDownList ID="ddlEvnt" runat="server">
                                                    </asp:DropDownList></td>
                                            </tr>

                                            <tr>
                                                <th colspan="2">DETAILS OF THE CHIEF GUEST/GUEST OF HOUNOUR </span></th>
                                            </tr>


                                            <tr>
                                                <th>Name<span class="required">*</span></th>
                                                <td>
                                                    <asp:TextBox ID="txtname" runat="server" Width="250px"></asp:TextBox></td>
                                            </tr>
                                            <tr>
                                                <th>Email Id</th>
                                                <td>
                                                    <asp:TextBox ID="txtemail" runat="server" Width="250px"></asp:TextBox></td>
                                            </tr>
                                            <tr>
                                                <th>Contact No</th>
                                                <td>
                                                    <cc1:NumericTextBox ID="txtContact" runat="server" Width="100px"></cc1:NumericTextBox></td>
                                            </tr>
                                            <tr>
                                                <th>Address</th>
                                                <td>
                                                    <asp:TextBox ID="txtAdd" runat="server" TextMode="MultiLine" Width="248px"></asp:TextBox></td>
                                            </tr>
                                            <tr>
                                                <td colspan="2">
                                                    <table>
                                                        <tr>
                                                            <th>From Date<span class="required">*</span></th>
                                                            <th>To Date<span class="required">*</span></th>
                                                            <th>From Time<span class="required">*</span></th>
                                                            <th>To Time<span class="required">*</span></th>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:TextBox ID="txtFrmDt" runat="server"></asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txttoDt" runat="server"></asp:TextBox></td>
                                                            <td>
                                                                 <asp:TextBox ID="txtFrmTime" runat="server" Width="40px"></asp:TextBox>(HH:MM) Use 24hr Format
                                                        <ajaxToolkit:MaskedEditExtender
                                                            ID="MaskedEditExtender3" runat="server" CultureName="en-US"
                                                            Mask="99:99" MaskType="Time" TargetControlID="txtFrmTime" CultureAMPMPlaceholder="AM;PM" CultureCurrencySymbolPlaceholder="$" CultureDateFormat="MDY" CultureDatePlaceholder="/" CultureDecimalPlaceholder="." CultureThousandsPlaceholder="," CultureTimePlaceholder=":" Enabled="True">
                                                        </ajaxToolkit:MaskedEditExtender>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txtToTime" runat="server" Width="40px"></asp:TextBox>(HH:MM) Use 24hr Format
                                                        <ajaxToolkit:MaskedEditExtender
                                                            ID="MaskedEditExtender1" runat="server" CultureName="en-US"
                                                            Mask="99:99" MaskType="Time" TargetControlID="txtToTime" CultureAMPMPlaceholder="AM;PM" CultureCurrencySymbolPlaceholder="$" CultureDateFormat="MDY" CultureDatePlaceholder="/" CultureDecimalPlaceholder="." CultureThousandsPlaceholder="," CultureTimePlaceholder=":" Enabled="True">
                                                        </ajaxToolkit:MaskedEditExtender>
                                                                
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <ajaxToolkit:CalendarExtender ID="CalendarExtender1" Format="dd/MM/yyyy" runat="server" TargetControlID="txtFrmDt"></ajaxToolkit:CalendarExtender>
                                                    <ajaxToolkit:CalendarExtender ID="CalendarExtender2" Format="dd/MM/yyyy" runat="server" TargetControlID="txttoDt"></ajaxToolkit:CalendarExtender>
                                                </td>
                                            </tr>

                                         
                                                <tr>
                                                    <th>Approximate No<span class="required">*</span></th>
                                                    <td>
                                                        <asp:TextBox ID="txtNo" runat="server" Width="80px"></asp:TextBox></td>
                                                </tr>
                                                <tr>
                                                    <th>Facility Required</th>
                                                    <td>
                                                        <asp:CheckBoxList ID="chFac" runat="server" RepeatColumns="3">
                                                            <asp:ListItem Value="1"> Sound System</asp:ListItem>
                                                            <asp:ListItem Value="2"> Projection System</asp:ListItem>
                                                            <asp:ListItem Value="3"> University Vehicle</asp:ListItem>
                                                        </asp:CheckBoxList></td>
                                                </tr>

                                                <tr>
                                                    <th>Administrative Support</th>
                                                    <td>
                                                        <asp:CheckBoxList ID="chSupport" runat="server" RepeatColumns="4">
                                                            <asp:ListItem Value="1"> Carpenter</asp:ListItem>
                                                            <asp:ListItem Value="2"> Attendent</asp:ListItem>
                                                            <asp:ListItem Value="3"> Electrician</asp:ListItem>
                                                            <asp:ListItem Value="4"> ISD Staff</asp:ListItem>
                                                        </asp:CheckBoxList>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2">
                                                        <asp:GridView ID="gvStore" Caption="Requirements From Store" runat="server" AutoGenerateColumns="false" CssClass="gridDynamic" EmptyDataText="No Record(s) Found" DataKeyNames="ITEM_ID">
                                                            <Columns>
                                                                <asp:BoundField HeaderText="Facility" DataField="ITEM_VALUE" />
                                                                <asp:TemplateField>
                                                                    <HeaderTemplate>Quantity</HeaderTemplate>
                                                                    <ItemTemplate>
                                                                        <cc1:NumericTextBox ID="txtCount" runat="server" MaxLength="3" AllowDecimal="false" AllowNegative="false"></cc1:NumericTextBox>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                            </Columns>
                                                        </asp:GridView>
                                                    </td>
                                                </tr>

                                                <tr>
                                                    <th style="vertical-align: middle">Detail of Event<span class="required">*</span></th>
                                                    <td>
                                                        <asp:TextBox ID="txtdetail" runat="server" TextMode="MultiLine" Width="500px" Height="50px"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <th style="vertical-align: middle">Remark</th>
                                                    <td>
                                                        <asp:TextBox ID="txtRemark" runat="server" TextMode="MultiLine" Width="500px" Height="20px"></asp:TextBox></td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Button ID="btnSave" runat="server" Text="SAVE" OnClick="btnSave_Click" /></td>
                                                </tr>
                                         
                                          
                                        </table>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </ContentTemplate>
                        </ajaxToolkit:TabPanel>
                        <ajaxToolkit:TabPanel ID="tabpanel2" runat="server" HeaderText="Booking Detail">
                            <ContentTemplate>
                                <table>
                                    <tr>
                                        <td>
                                            <table>
                                                <tr>
                                                    <th>By complex</th>
                                                    <th colspan="3">By Booking Date</th>
                                                    <th>By Event</th>
                                                    <th>By Status</th>
                                                    <th>By Employee</th>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:DropDownList ID="ddlbComplex" runat="server"></asp:DropDownList></td>
                                                    <td>
                                                        <asp:DropDownList ID="ddldt" runat="server" OnSelectedIndexChanged="DateType_Change" AutoPostBack="true">
                                                            <asp:ListItem Value="0" Text="All"></asp:ListItem>
                                                            <asp:ListItem Value="1" Text="Less Than"></asp:ListItem>
                                                            <asp:ListItem Value="2" Text="Greater Than"></asp:ListItem>
                                                            <asp:ListItem Value="3" Text="Between"></asp:ListItem>
                                                        </asp:DropDownList></td>
                                                    <td>
                                                        <asp:TextBox ID="txtSdt" runat="server"></asp:TextBox></td>
                                                    <td>
                                                        <asp:TextBox ID="txtEdt" runat="server"></asp:TextBox></td>
                                                    <td>
                                                        <asp:DropDownList ID="ddlevent" runat="server"></asp:DropDownList></td>
                                                    <td>
                                                        <asp:DropDownList ID="ddlsts" runat="server"></asp:DropDownList></td>
                                                    <td>
                                                        <asp:DropDownList ID="ddlemp" runat="server"></asp:DropDownList></td>
                                                    <td>
                                                        <asp:Button ID="btnView" runat="server" Text="View" OnClick="btnView_Click" /></td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <ajaxToolkit:CalendarExtender ID="CalendarExtender3" Format="dd/MM/yyyy" runat="server" TargetControlID="txtSdt" Enabled="True"></ajaxToolkit:CalendarExtender>
                                                        <ajaxToolkit:CalendarExtender ID="CalendarExtender4" Format="dd/MM/yyyy" runat="server" TargetControlID="txtEdt" Enabled="True"></ajaxToolkit:CalendarExtender>
                                                    </td>
                                                </tr>
                                            </table>
                                            <table>
                                                <tr>
                                                    <td>
                                                        <asp:GridView ID="gvBookingDetail" runat="server" AutoGenerateColumns="False" CssClass="gridDynamic" EmptyDataText="No Record(s) Found" DataKeyNames="HALL_REQ_ID">
                                                            <Columns>
                                                                <asp:TemplateField HeaderText="S.No">
                                                                    <ItemTemplate>
                                                                        <%#((GridViewRow)Container).RowIndex +1 %>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:BoundField HeaderText="Complex Name" DataField="FAC_CMPLX_NAME" />
                                                                <asp:BoundField HeaderText="Event Name" DataField="EVENT_INFO" />
                                                                <asp:BoundField HeaderText="Request Date" DataField="HALL_FROM_DT" DataFormatString="{0:dd/MM/yyy}" />
                                                                <asp:BoundField HeaderText="Action By" DataField="EMP_NAME" />
                                                                <asp:BoundField HeaderText="Booking Dates" DataField="BOOKINGON" />
                                                                <asp:BoundField HeaderText="No Of Seat" DataField="HALL_BOOK_NO" />
                                                                <asp:BoundField HeaderText="Status" DataField="STS_VALUE" />
                                                                <asp:HyperLinkField HeaderText="Detail" Text="Detail....." DataNavigateUrlFields="HALL_REQ_ID"
                                                                    DataNavigateUrlFormatString="rptHallBooking.aspx?{0}" NavigateUrl="rptHallBooking.aspx"
                                                                    Target="_blank">
                                                                    <ControlStyle ForeColor="Blue" />
                                                                    <ItemStyle Font-Bold="True" Width="40px" />
                                                                </asp:HyperLinkField>

                                                            </Columns>
                                                        </asp:GridView>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                            </ContentTemplate>
                        </ajaxToolkit:TabPanel>
                        <ajaxToolkit:TabPanel ID="tabpanel3" runat="server" HeaderText="Cancel Booking">
                            <ContentTemplate>
                                <table>
                                    <tr>
                                        <td>
                                            <table>
                                                <tr>
                                                    <td>
                                                        <asp:GridView ID="gvCancelBooking" runat="server" AutoGenerateColumns="False" CssClass="gridDynamic" EmptyDataText="No Record(s) Found" OnRowCommand="gvCancelBooking_RowCommand" DataKeyNames="HALL_REQ_ID">
                                                            <Columns>
                                                                <asp:TemplateField HeaderText="S.No">
                                                                    <ItemTemplate>
                                                                        <%#((GridViewRow)Container).RowIndex +1 %>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:BoundField HeaderText="Complex" DataField="FAC_CMPLX_NAME" />
                                                                <asp:BoundField HeaderText="Event" DataField="EVENT_INFO" />
                                                                <asp:BoundField HeaderText="Request Date" DataField="HALL_TRAN_DATE" />
                                                                <asp:BoundField HeaderText="Last Action By" DataField="EMP_NAME" />
                                                                <asp:BoundField HeaderText="Booking On" DataField="BOOKINGON" />
                                                                <asp:BoundField HeaderText="Status" DataField="STS_VALUE" />
                                                                <asp:TemplateField HeaderText="Cancel Remark">
                                                                    <ItemTemplate>
                                                                        <asp:TextBox ID="txtCancelRemark" runat="server"></asp:TextBox>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:CommandField ButtonType="Image" SelectImageUrl="~/Siteimages/delete.jpg" ShowSelectButton="True" />
                                                            </Columns>
                                                        </asp:GridView>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                            </ContentTemplate>
                        </ajaxToolkit:TabPanel>
                        <ajaxToolkit:TabPanel ID="TabPanel4" runat="server" HeaderText="Hall Status">
                            <ContentTemplate>
                                <table>
                                    <tr>
                                        <td>
                                            <table>
                                                <tr>
                                                    <th>Month/Year</th>
                                                    <td></td>
                                                    <th>Hall<span class="required">*</span></th>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <uc1:MonthYear runat="server" ID="MonthYear" />
                                                    </td>
                                                    <td></td>
                                                    <td>
                                                        <asp:DropDownList ID="ddlBookedHall" runat="server"></asp:DropDownList></td>
                                                    <td>
                                                        <asp:Button ID="btnshow" runat="server" Text="View" OnClick="btnshow_Click" /></td>
                                                </tr>
                                            </table>
                                            <table>
                                                <tr>
                                                    <td>
                                                        <span style="background-color: #ff8080">Holidays</span> and <span style="background-color: #ffff80">Sundays</span> are Highlighted&nbsp;
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td id="tdMain" runat="server"></td>
                                    </tr>
                                </table>
                            </ContentTemplate>
                        </ajaxToolkit:TabPanel>
                    </ajaxToolkit:TabContainer>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:TextBox ID="txtData" runat="server" Visible="false"></asp:TextBox>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>

