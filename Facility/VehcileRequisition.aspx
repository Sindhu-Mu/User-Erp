<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/FullLength.master" AutoEventWireup="true" CodeFile="VehcileRequisition.aspx.cs" Inherits="Facility_VehcileRequisition" %>

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
    <script lang="javascript" type="text/javascript">
        function CheckControl(ctrl) {
            if (bTrim(document.getElementById(ctrl).value) == "" || bTrim(document.getElementById(ctrl).value) == "." || bTrim(document.getElementById(ctrl).value) == "Select") {
                document.getElementById(ctrl).style.backgroundColor = "#fc6";
                return false;
            }
            else
                document.getElementById(ctrl).style.backgroundColor = "#fff";
            return true;
        }

        function validate() {
            var flag = true;
            var msg = "", ctrl = "";
            if (!CheckControl("<%=txtDesAdd.ClientID%>")) {
                msg += "- Enter Destination Address. \n";
                if (ctrl == "")
                    ctrl = "<%=txtDesAdd.ClientID%>";
                flag = false;
            }
            if (!CheckControl("<%=txtPickLoc.ClientID%>")) {
                msg += "- Enter PickUp Location \n";
                if (ctrl == "")
                    ctrl = "<%=txtPickLoc.ClientID%>";
                flag = false;
            }
            if (!CheckControl("<%=txtMobile.ClientID%>")) {
                msg += "- Mobile No Field can't be blank. \n";
                if (ctrl == "")
                    ctrl = "<%=txtMobile.ClientID%>";
                flag = false;
            }
            if (!CheckControl("<%=txtNoPer.ClientID%>")) {
                msg += "- Enter No Of Persons. \n";
                if (ctrl == "")
                    ctrl = "<%=txtNoPer.ClientID%>";
                flag = false;
            }
            if (!CheckControl("<%=txtDate.ClientID%>")) {
                msg += "- Enter Journey Date. \n";
                if (ctrl == "")
                    ctrl = "<%=txtDate.ClientID%>";
                flag = false;
            }
            if (!CheckControl("<%=txtPurVisit.ClientID%>")) {
                msg += "- Enter Visit Purpose. \n";
                if (ctrl == "")
                    ctrl = "<%=txtPurVisit.ClientID%>";
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
            <h2>Vehicle Requisition</h2>
        </div>
        <div>
            <ajaxToolkit:TabContainer ID="TabContainer1" runat="server" AutoPostBack="true" ActiveTabIndex="0" CssClass="fancy fancy-green" OnActiveTabChanged="TabContainer1_ActiveTabChanged">
                <ajaxToolkit:TabPanel ID="TabPanel1" runat="server" HeaderText="New Requisition">
                    <ContentTemplate>
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                            <ContentTemplate>
                                <div>
                                    <table>
                                        <tr>
                                            <th>Requisition For</th>
                                            <td>&nbsp;</td>
                                            <td>
                                                <asp:RadioButtonList ID="rdbtnReqFor" runat="server" AutoPostBack="True" RepeatDirection="Horizontal" OnSelectedIndexChanged="rdbtnReqFor_SelectedIndexChanged">
                                                    <asp:ListItem Text="One Way" Value="1" Selected="True"></asp:ListItem>
                                                    <asp:ListItem Text="Two Way" Value="2"></asp:ListItem>
                                                </asp:RadioButtonList></td>
                                        </tr>
                                        <tr>
                                            <th>Destination Address<span class="required">*</span></th>
                                            <td>&nbsp;</td>
                                            <td>
                                                <asp:TextBox ID="txtDesAdd" runat="server" Width="99%"></asp:TextBox></td>
                                        </tr>
                                        <tr>
                                            <th>Pick Up Location<span class="required">*</span></th>
                                            <td>&nbsp;</td>
                                            <td>
                                                <asp:TextBox ID="txtPickLoc" runat="server" Width="99%"></asp:TextBox></td>
                                        </tr>
                                        <tr>
                                            <th>Mobile Number<span class="required">*</span></th>
                                            <td>&nbsp;</td>
                                            <td>
                                                <cc1:NumericTextBox ID="txtMobile" runat="server"></cc1:NumericTextBox>
                                            </td>
                                            <td><span class="required">Verify Your Mobile Number</span></td>
                                        </tr>
                                        <tr>
                                            <th>No of Person<span class="required">*</span></th>
                                            <td>&nbsp;</td>
                                            <td>
                                                <cc1:NumericTextBox ID="txtNoPer" runat="server"></cc1:NumericTextBox></td>
                                        </tr>
                                        <tr>
                                            <th>Requisition Type</th>
                                            <td>&nbsp;</td>
                                            <td>
                                                <asp:RadioButtonList ID="rbReqType" runat="server" RepeatDirection="Horizontal">
                                                    <asp:ListItem Text="Official" Selected="True" Value="1">
                                                    </asp:ListItem>
                                                    <asp:ListItem Text="Personal" Value="2"></asp:ListItem>
                                                </asp:RadioButtonList></td>
                                        </tr>
                                        <tr>
                                            <th>Requisition For</th>
                                            <td>&nbsp;</td>
                                            <td>
                                                <asp:RadioButtonList ID="rbReqFor" runat="server" AutoPostBack="True" RepeatDirection="Horizontal" OnSelectedIndexChanged="rbReqFor_SelectedIndexChanged">
                                                    <asp:ListItem Text="One Day" Selected="True" Value="1">
                                                    </asp:ListItem>
                                                    <asp:ListItem Text="Date Range" Value="2"></asp:ListItem>
                                                </asp:RadioButtonList></td>
                                        </tr>
                                        <tr>
                                            <th>Date<span class="required">*</span></th>
                                            <td>&nbsp;</td>
                                            <td>
                                                <asp:TextBox ID="txtDate" runat="server"></asp:TextBox></td>
                                            <th id="ToDt" runat="server">To Date</th>
                                            <td id="TxtTo" runat="server">
                                                <asp:TextBox ID="txtToDate" runat="server"></asp:TextBox></td>
                                        </tr>
                                        <tr>
                                            <th>Time<span class="required">*</span></th>
                                            <td>&nbsp;</td>
                                            <td>
                                                <asp:TextBox ID="txtTime" runat="server" Width="40px"></asp:TextBox>(HH:MM)Use 24hr Format
                                                        <ajaxToolkit:MaskedEditExtender
                                                            ID="MaskedEditExtender5" runat="server" CultureName="en-US"
                                                            Mask="99:99" MaskType="Time" TargetControlID="txtTime" CultureAMPMPlaceholder="AM;PM" CultureCurrencySymbolPlaceholder="$" CultureDateFormat="MDY" CultureDatePlaceholder="/" CultureDecimalPlaceholder="." CultureThousandsPlaceholder="," CultureTimePlaceholder=":" Enabled="True">
                                                        </ajaxToolkit:MaskedEditExtender>
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                                <div id="ExcDay" runat="server">

                                    <table>
                                        <tr>
                                            <th>
                                                <span class="required">EXCLUDING DAYS</span>
                                            </th>
                                        </tr>
                                        <tr>
                                            <th>Excluded Date</th>
                                            <th>Reason</th>
                                            <td>
                                                <asp:CheckBox ID="chkHolidays" runat="server" Text="Holidays" /></td>

                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:TextBox ID="txtExcDt" runat="server"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtReason" runat="server"></asp:TextBox></td>
                                            <td>
                                                <asp:Button ID="btnExclude" runat="server" Text="Exclude" /></td>
                                            <td>
                                                <asp:GridView ID="grdExclude" runat="server" AutoGenerateColumns="false" CssClass="gridDynamic" DataKeyNames="EXC_ID">
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="S.No.">
                                                            <ItemTemplate>
                                                                <%# ((GridViewRow)Container).RowIndex + 1%>
                                .                                          
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:BoundField HeaderText="Exclude Date" DataField="EXCLUDE_DATE" />
                                                        <asp:BoundField HeaderText="Reason" DataField="EXCLUDE_REASON" />
                                                        <asp:TemplateField ShowHeader="False" HeaderText="Status">
                                                            <ItemStyle Width="20px" HorizontalAlign="Right" />
                                                            <ItemTemplate>
                                                                <asp:ImageButton ID="ImageButton1" runat="server" CausesValidation="false" CommandArgument='<%# Bind("EXC_ID") %>'
                                                                    ImageUrl='<%# Bind("STS_IMG") %>' CommandName='<%# Bind("STS_CMD") %>' ToolTip='<%# Bind("STS_TOOLTIP")%>' />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                    </Columns>
                                                </asp:GridView>
                                            </td>
                                        </tr>
                                    </table>

                                </div>
                                <div>
                                    Purpose Of Visit<span class="required">*</span><br />
                                    <asp:TextBox ID="txtPurVisit" runat="server" Width="70%" TextMode="MultiLine"></asp:TextBox>
                                </div>




                                <div id="RetJou" runat="server">

                                    <table>
                                        <tr>
                                            <th>
                                                <span class="required">RETURN JOURNEY</span>
                                            </th>
                                        </tr>
                                        <tr>
                                            <th>PickUp Location</th>
                                            <td>
                                                <asp:TextBox ID="txtPickUp" runat="server"></asp:TextBox></td>
                                        </tr>
                                        <tr>
                                            <th>Return Date</th>
                                            <td>
                                                <asp:TextBox ID="txtRetDt" runat="server"></asp:TextBox></td>
                                        </tr>
                                        <tr>
                                            <th>Return Time</th>
                                            <td>
                                                <asp:TextBox ID="txtRetTime" runat="server" Width="40px"></asp:TextBox>(HH:MM)Use 24hr Format
                                                        <ajaxToolkit:MaskedEditExtender
                                                            ID="MaskedEditExtender6" runat="server" CultureName="en-US"
                                                            Mask="99:99" MaskType="Time" TargetControlID="txtRetTime" CultureAMPMPlaceholder="AM;PM" CultureCurrencySymbolPlaceholder="$" CultureDateFormat="MDY" CultureDatePlaceholder="/" CultureDecimalPlaceholder="." CultureThousandsPlaceholder="," CultureTimePlaceholder=":" Enabled="True">
                                                        </ajaxToolkit:MaskedEditExtender>
                                            </td>
                                        </tr>
                                        <tr>
                                            <th>No Of Person</th>
                                            <td>
                                                <asp:TextBox ID="txtNoOfPer" runat="server"></asp:TextBox></td>
                                        </tr>
                                    </table>

                                </div>
                                <div style="text-align:right;">
                                    <asp:Button ID="btnSubmit" runat="server" Text="APPLY" OnClick="btnSubmit_Click" /></td>
                                </div>
                                <div>
                                    <ajaxToolkit:CalendarExtender ID="CalendarExtender1" Format="dd/MM/yyyy" runat="server" TargetControlID="txtRetDt">
                                    </ajaxToolkit:CalendarExtender>
                                    <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender1" runat="server" TargetControlID="txtRetDt" Mask="99/99/9999"
                                        MaskType="Date">
                                    </ajaxToolkit:MaskedEditExtender>

                                    <ajaxToolkit:CalendarExtender ID="CalendarExtender2" Format="dd/MM/yyyy" runat="server" TargetControlID="txtExcDt">
                                    </ajaxToolkit:CalendarExtender>
                                    <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender2" runat="server" TargetControlID="txtExcDt" Mask="99/99/9999"
                                        MaskType="Date">
                                    </ajaxToolkit:MaskedEditExtender>

                                    <ajaxToolkit:CalendarExtender ID="CalendarExtender3" Format="dd/MM/yyyy" runat="server" TargetControlID="txtToDate">
                                    </ajaxToolkit:CalendarExtender>
                                    <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender3" runat="server" TargetControlID="txtToDate" Mask="99/99/9999"
                                        MaskType="Date">
                                    </ajaxToolkit:MaskedEditExtender>

                                    <ajaxToolkit:CalendarExtender ID="CalendarExtender4" Format="dd/MM/yyyy" runat="server" TargetControlID="txtDate">
                                    </ajaxToolkit:CalendarExtender>
                                    <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender4" runat="server" TargetControlID="txtDate" Mask="99/99/9999"
                                        MaskType="Date">
                                    </ajaxToolkit:MaskedEditExtender>
                                </div>

                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </ContentTemplate>
                </ajaxToolkit:TabPanel>
                <ajaxToolkit:TabPanel ID="TabPanel2" runat="server" HeaderText="Previous Requisition">
                    <ContentTemplate>
                        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                            <ContentTemplate>
                                <table>
                                    <tr>
                                        <td>
                                            <asp:GridView ID="grdPreReq" runat="server" AutoGenerateColumns="false" CssClass="gridDynamic" DataKeyNames="VR_REQ_ID">
                                                <Columns>
                                                    <asp:TemplateField HeaderText="S.No.">
                                                        <ItemTemplate>
                                                            <%# ((GridViewRow)Container).RowIndex + 1%>
                                .                                          
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:BoundField DataField="VRD_JRNY_TYPE" HeaderText="Journey Type" />
                                                    <asp:BoundField DataField="VR_DESTI_ADD" HeaderText="Destination" />
                                                    <asp:BoundField DataField="VRD_JRNY_DT" HeaderText="Journey Date" />
                                                    <asp:BoundField DataField="VR_PICK_UP_LOC" HeaderText="Pick up from" />
                                                    <asp:BoundField DataField="VR_NOP" HeaderText="Travellers" />
                                                    <asp:BoundField DataField="VR_REQ_TYPE" HeaderText="Type" />
                                                    <asp:BoundField DataField="STS_VALUE" HeaderText="Status" />
                                                </Columns>
                                            </asp:GridView>
                                        </td>
                                    </tr>
                                </table>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </ContentTemplate>
                </ajaxToolkit:TabPanel>
            </ajaxToolkit:TabContainer>
        </div>
    </div>
</asp:Content>

