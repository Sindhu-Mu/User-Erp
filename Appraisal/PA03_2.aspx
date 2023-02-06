<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/FullLength.master" AutoEventWireup="true" CodeFile="PA03_2.aspx.cs" Inherits="Appraisal_PA032" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script lang="javascript" type="text/javascript">
        function CheckDate(ctrl) {
            var dt = document.getElementById(ctrl).value;
            if (isDatecheck(dt, "dd/MM/yyyy") == false) {
                document.getElementById(ctrl).style.backgroundColor = "#fc6";
                return false;
            }
            else
                document.getElementById(ctrl).style.backgroundColor = "#fff";
            return true;
        }
        function CheckControl(ctrl) {
            if (bTrim(document.getElementById(ctrl).value) == "" || bTrim(document.getElementById(ctrl).value) == "-1") {
                document.getElementById(ctrl).style.backgroundColor = "#fc6";
                return false;
            }
            else
                document.getElementById(ctrl).style.backgroundColor = "#fff";
            return true;
        }
        function validation2A() {

            var flag = true;
            var msg = "", ctrl = "";

            if (!CheckControl("<%=txtDuty2A.ClientID%>")) {
                msg += "- Enter Duty\n";
                if (ctrl == "")
                    ctrl = "<%=txtDuty2A.ClientID%>";
                flag = false;
            }
            if (!CheckControl("<%=ddlLevel2A.ClientID%>")) {
                msg += "- Select Level\n";
                if (ctrl == "")
                    ctrl = "<%=ddlLevel2A.ClientID%>";
                flag = false;
            }
            if (CheckControl("<%=txtFromDate2A.ClientID%>")) {
                if (!CheckDate("<%=txtFromDate2A.ClientID%>")) {
                    msg += "- Invalid Format of Date.Please Enter in this[dd/MM/yyyy]\n";
                    if (ctrl == "")
                        ctrl = "<%=txtFromDate2A.ClientID%>";
                    flag = false;
                }
            }
            else {
                msg += "- Enter To Date\n";
                if (ctrl == "")
                    ctrl = "<%=txtFromDate2A.ClientID%>";
                flag = false;
            }
            if (CheckControl("<%=txtToDate2A.ClientID%>")) {
                if (!CheckDate("<%=txtToDate2A.ClientID%>")) {
                    msg += "- Invalid Format of Date.Please Enter in this[dd/MM/yyyy]\n";
                    if (ctrl == "")
                        ctrl = "<%=txtToDate2A.ClientID%>";
                     flag = false;
                 }
             }
             else {
                 msg += "- Enter To Date\n";
                 if (ctrl == "")
                     ctrl = "<%=txtToDate2A.ClientID%>";
                flag = false;
            }
            if (msg != "") alert(msg);
            if (ctrl != "")
                document.getElementById(ctrl).focus();
            return flag;
        }

        function validation2B() {

            var flag = true;
            var msg = "", ctrl = "";

            if (!CheckControl("<%=txtDuty2B.ClientID%>")) {
                 msg += "- Enter Duty\n";
                 if (ctrl == "")
                     ctrl = "<%=txtDuty2B.ClientID%>";
                flag = false;
            }
            if (!CheckControl("<%=ddlLevel2B.ClientID%>")) {
                 msg += "- Select Level\n";
                 if (ctrl == "")
                     ctrl = "<%=ddlLevel2B.ClientID%>";
                flag = false;
            }
            if (!CheckControl("<%=ddlOPMF2B.ClientID%>")) {
                 msg += "- Enter O/M/P/F\n";
                 if (ctrl == "")
                     ctrl = "<%=ddlOPMF2B.ClientID%>";
                flag = false;
            }
            if (CheckControl("<%=txtFromDate2B.ClientID%>")) {
                 if (!CheckDate("<%=txtFromDate2B.ClientID%>")) {
                    msg += "- Invalid Format of Date.Please Enter in this[dd/MM/yyyy]\n";
                    if (ctrl == "")
                        ctrl = "<%=txtFromDate2B.ClientID%>";
                    flag = false;
                }
            }
            else {
                msg += "- Enter To Date\n";
                if (ctrl == "")
                    ctrl = "<%=txtFromDate2B.ClientID%>";
                flag = false;
            }
            if (CheckControl("<%=txtToDate2B.ClientID%>")) {
                 if (!CheckDate("<%=txtToDate2B.ClientID%>")) {
                    msg += "- Invalid Format of Date.Please Enter in this[dd/MM/yyyy]\n";
                    if (ctrl == "")
                        ctrl = "<%=txtToDate2B.ClientID%>";
                    flag = false;
                }
            }
            else {
                msg += "- Enter To Date\n";
                if (ctrl == "")
                    ctrl = "<%=txtToDate2B.ClientID%>";
                 flag = false;
             }
             if (msg != "") alert(msg);
             if (ctrl != "")
                 document.getElementById(ctrl).focus();
             return flag;
         }

         function validation2C() {

             var flag = true;
             var msg = "", ctrl = "";

             if (!CheckControl("<%=txtDuty2C.ClientID%>")) {
                msg += "- Enter Duty\n";
                if (ctrl == "")
                    ctrl = "<%=txtDuty2C.ClientID%>";
                 flag = false;
             }
             if (!CheckControl("<%=ddlLevel2C.ClientID%>")) {
                msg += "- Select Level\n";
                if (ctrl == "")
                    ctrl = "<%=ddlLevel2C.ClientID%>";
                 flag = false;
             }
             if (!CheckControl("<%=ddlOPMF2C.ClientID%>")) {
                msg += "- Enter O/M/P/F\n";
                if (ctrl == "")
                    ctrl = "<%=ddlOPMF2C.ClientID%>";
                 flag = false;
             }
             if (CheckControl("<%=txtFromDate2C.ClientID%>")) {
                if (!CheckDate("<%=txtFromDate2C.ClientID%>")) {
                    msg += "- Invalid Format of Date.Please Enter in this[dd/MM/yyyy]\n";
                    if (ctrl == "")
                        ctrl = "<%=txtFromDate2C.ClientID%>";
                    flag = false;
                }
            }
            else {
                msg += "- Enter To Date\n";
                if (ctrl == "")
                    ctrl = "<%=txtFromDate2C.ClientID%>";
                flag = false;
            }
            if (CheckControl("<%=txtToDate2C.ClientID%>")) {
                if (!CheckDate("<%=txtToDate2C.ClientID%>")) {
                    msg += "- Invalid Format of Date.Please Enter in this[dd/MM/yyyy]\n";
                    if (ctrl == "")
                        ctrl = "<%=txtToDate2C.ClientID%>";
                    flag = false;
                }
            }
            else {
                msg += "- Enter To Date\n";
                if (ctrl == "")
                    ctrl = "<%=txtToDate2C.ClientID%>";
                flag = false;
            }
            if (msg != "") alert(msg);
            if (ctrl != "")
                document.getElementById(ctrl).focus();
            return flag;
        }

        function validation2D() {

            var flag = true;
            var msg = "", ctrl = "";

            if (!CheckControl("<%=txtDuty2D.ClientID%>")) {
                 msg += "- Enter Duty\n";
                 if (ctrl == "")
                     ctrl = "<%=txtDuty2D.ClientID%>";
                flag = false;
            }
            if (!CheckControl("<%=ddlLevel2D.ClientID%>")) {
                 msg += "- Select Level\n";
                 if (ctrl == "")
                     ctrl = "<%=ddlLevel2D.ClientID%>";
                flag = false;
            }
            if (!CheckControl("<%=ddlOPMF2D.ClientID%>")) {
                 msg += "- Enter O/M/P/F\n";
                 if (ctrl == "")
                     ctrl = "<%=ddlOPMF2D.ClientID%>";
                flag = false;
            }
            if (CheckControl("<%=txtFromDate2D.ClientID%>")) {
                 if (!CheckDate("<%=txtFromDate2D.ClientID%>")) {
                    msg += "- Invalid Format of Date.Please Enter in this[dd/MM/yyyy]\n";
                    if (ctrl == "")
                        ctrl = "<%=txtFromDate2D.ClientID%>";
                    flag = false;
                }
            }
            else {
                msg += "- Enter To Date\n";
                if (ctrl == "")
                    ctrl = "<%=txtFromDate2D.ClientID%>";
                flag = false;
            }
            if (CheckControl("<%=txtToDate2D.ClientID%>")) {
                 if (!CheckDate("<%=txtToDate2D.ClientID%>")) {
                    msg += "- Invalid Format of Date.Please Enter in this[dd/MM/yyyy]\n";
                    if (ctrl == "")
                        ctrl = "<%=txtToDate2D.ClientID%>";
                    flag = false;
                }
            }
            else {
                msg += "- Enter To Date\n";
                if (ctrl == "")
                    ctrl = "<%=txtToDate2D.ClientID%>";
                flag = false;
            }
            if (msg != "") alert(msg);
            if (ctrl != "")
                document.getElementById(ctrl).focus();
            return flag;
        }

        function validation2E() {

            var flag = true;
            var msg = "", ctrl = "";

            if (!CheckControl("<%=txtDuty2E.ClientID%>")) {
                 msg += "- Enter Duty\n";
                 if (ctrl == "")
                     ctrl = "<%=txtDuty2E.ClientID%>";
                flag = false;
            }
            if (msg != "") alert(msg);
            if (ctrl != "")
                document.getElementById(ctrl).focus();
            return flag;
        }
    </script>
    <div class="container" style="width: 100%">
        <div class="heading">
            <h2>Management & Institutional Development Elements
            </h2>
        </div>
        <div style="text-align: right; color: #5a72f8; font-weight: bold; font-size: 14px">
            <a href="PA03_Home.aspx" style="">Back To Main Page</a>
        </div>
        <div style="width: 98%; padding-left: 10px">

            <ajaxToolkit:Accordion ID="Accordion1" runat="server" Width="950px" SelectedIndex="0" HeaderCssClass="accordionHeader" ContentCssClass="accordionContent" HeaderSelectedCssClass="accordionHeaderSelected"
                AutoSize="None" FadeTransitions="true" TransitionDuration="250" FramesPerSecond="40" RequireOpenedPane="false" SuppressHeaderPostbacks="true">
                <Panes>
                    <ajaxToolkit:AccordionPane runat="server" ID="AccordionPane1">
                        <Header>
                            <asp:Label ID="lblHeader2A" runat="server"></asp:Label>
                            <br />
                            <asp:Label ID="lblDescription2A" runat="server"></asp:Label>
                        </Header>
                        <Content>

                            <asp:UpdatePanel ID="upPA03_2A" runat="server">
                                <ContentTemplate>



                                    <table>
                                        <tr>
                                            <td>
                                                <table>
                                                    <tr>
                                                        <th>Duties<span class="required">*</span>
                                                        </th>
                                                        <th>Level<span class="required">*</span></th>
                                                        <th>From Date<span class="required">*</span>
                                                        </th>
                                                        <th>To Date<span class="required">*</span>
                                                        </th>
                                                    </tr>
                                                    <tr>
                                                        <td style="vertical-align: top">
                                                            <asp:TextBox ID="txtDuty2A" runat="server" MaxLength="1000" TextMode="MultiLine" Rows="5"
                                                                Width="300px" Height="100px"></asp:TextBox></td>
                                                        <td style="vertical-align: top">
                                                            <asp:DropDownList ID="ddlLevel2A" runat="server" Width="97px">
                                                            </asp:DropDownList></td>
                                                        <td style="vertical-align: top">
                                                            <asp:TextBox ID="txtFromDate2A" runat="server" Width="97px">
                                                            </asp:TextBox>
                                                            <ajaxToolkit:CalendarExtender ID="CalendarExtender3" runat="server" TargetControlID="txtFromDate2A" Format="dd/MM/yyyy">
                                                            </ajaxToolkit:CalendarExtender>
                                                            <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender1" runat="server" Mask="99/99/9999" MaskType="Date"
                                                                TargetControlID="txtFromDate2A">
                                                            </ajaxToolkit:MaskedEditExtender>
                                                        </td>
                                                        <td style="vertical-align: top">
                                                            <asp:TextBox ID="txtToDate2A" runat="server" Width="97px">
                                                            </asp:TextBox>
                                                            <ajaxToolkit:CalendarExtender ID="CalendarExtender4" runat="server" TargetControlID="txtToDate2A" Format="dd/MM/yyyy">
                                                            </ajaxToolkit:CalendarExtender>
                                                            <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender2" runat="server" Mask="99/99/9999" MaskType="Date"
                                                                TargetControlID="txtToDate2A">
                                                            </ajaxToolkit:MaskedEditExtender>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Button ID="btnSave2A" Text="Save" runat="server" OnClick="btnSave2A_Click" />
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="6">
                                                <asp:GridView ID="gridData2A" runat="server" AutoGenerateColumns="false" GridLines="None"
                                                    AllowPaging="false" CssClass="gridDynamic" AlternatingRowStyle-CssClass="alt"
                                                    SelectedRowStyle-CssClass="pgr" OnRowDeleting="gridData_RowDeleting" DataKeyNames="PA03_2A_ID">
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="S.No.">
                                                            <ItemTemplate>
                                                                <%# ((GridViewRow)Container).RowIndex + 1%>
                                        .
                                                            </ItemTemplate>
                                                            <ItemStyle Width="30px" />
                                                        </asp:TemplateField>
                                                        <asp:BoundField DataField="PA03_2A_DUT" HeaderText="Duties" />
                                                        <asp:BoundField DataField="PA03_UNIV_LVL_VALUE" HeaderText="Level" />
                                                        <asp:BoundField DataField="PA03_2A_FROM_DATE" HeaderText="From Date" DataFormatString="{0:dd/MM/yyyy}" />
                                                        <asp:BoundField DataField="PA03_2A_TO_DATE" HeaderText="To Date" DataFormatString="{0:dd/MM/yyyy}" />
                                                        <%--<asp:BoundField DataField="PA03_2A_STATUS" HeaderText="Status" />--%>
                                                    </Columns>
                                                </asp:GridView>
                                                <br />
                                                <br />
                                            </td>
                                        </tr>
                                    </table>

                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </Content>
                    </ajaxToolkit:AccordionPane>
                    <ajaxToolkit:AccordionPane runat="server" ID="AccordionPane2">
                        <Header>
                            <asp:Label ID="lblHeader2B" runat="server"></asp:Label><br />
                            <asp:Label ID="lblDescription2B" runat="server"></asp:Label>
                        </Header>
                        <Content>
                            <asp:UpdatePanel ID="upPA03_2B" runat="server">
                                <ContentTemplate>

                                    <table>
                                        <tr>
                                            <td>
                                                <table>
                                                    <tr>
                                                        <th>Duties<span class="required">*</span>
                                                        </th>
                                                        <th>Level<span class="required">*</span>
                                                        </th>
                                                        <th>O/M/P/F<span class="required">*</span>
                                                        </th>
                                                        <th>From Date<span class="required">*</span>
                                                        </th>
                                                        <th>To Date<span class="required">*</span>
                                                        </th>
                                                    </tr>
                                                    <tr>
                                                        <td style="vertical-align: top">
                                                            <asp:TextBox ID="txtDuty2B" runat="server" MaxLength="400" TextMode="MultiLine" Rows="5"
                                                                Width="300px"></asp:TextBox>
                                                        </td>
                                                        <td style="vertical-align: top">
                                                            <asp:DropDownList ID="ddlLevel2B" runat="server" Width="97px">
                                                            </asp:DropDownList></td>
                                                        <td style="vertical-align: top">
                                                            <asp:DropDownList ID="ddlOPMF2B" runat="server" Width="97px">
                                                            </asp:DropDownList></td>
                                                        <td style="vertical-align: top">
                                                            <asp:TextBox ID="txtFromDate2B" runat="server" Width="97px">
                                                            </asp:TextBox>
                                                            <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtFromDate2B" Format="dd/MM/yyyy">
                                                            </ajaxToolkit:CalendarExtender>
                                                            <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender3" runat="server" Mask="99/99/9999" MaskType="Date"
                                                                TargetControlID="txtFromDate2B">
                                                            </ajaxToolkit:MaskedEditExtender>
                                                        </td>
                                                        <td style="vertical-align: top">
                                                            <asp:TextBox ID="txtToDate2B" runat="server" Width="97px">
                                                            </asp:TextBox>
                                                            <ajaxToolkit:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtToDate2B" Format="dd/MM/yyyy">
                                                            </ajaxToolkit:CalendarExtender>
                                                            <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender4" runat="server" Mask="99/99/9999" MaskType="Date"
                                                                TargetControlID="txtToDate2B">
                                                            </ajaxToolkit:MaskedEditExtender>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Button ID="btnSave2B" Text="Save" runat="server" OnClick="btnSave2B_Click" />
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="6">
                                                <asp:GridView ID="gridData2B" runat="server" AutoGenerateColumns="false" GridLines="None" DataKeyNames="PA03_2B_ID"
                                                    AllowPaging="false" CssClass="gridDynamic" AlternatingRowStyle-CssClass="alt"
                                                    SelectedRowStyle-CssClass="pgr" OnRowDeleting="gridData2B_RowDeleting">
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="S.No.">
                                                            <ItemTemplate>
                                                                <%# ((GridViewRow)Container).RowIndex + 1%>
                                        .
                                                            </ItemTemplate>
                                                            <ItemStyle Width="30px" />
                                                        </asp:TemplateField>
                                                        <asp:BoundField DataField="PA03_2B_DUT" HeaderText="Duties" />
                                                        <asp:BoundField DataField="PA03_UNIV_LVL_VALUE" HeaderText="Level" />
                                                        <asp:BoundField DataField="PA03_OPMF_VALUE" HeaderText="O/M/P/F" />
                                                        <asp:BoundField DataField="PA03_2B_FROM_DATE" HeaderText="From Date" DataFormatString="{0:dd/MM/yyyy}" />
                                                        <asp:BoundField DataField="PA03_2B_TO_DATE" HeaderText="To Date" DataFormatString="{0:dd/MM/yyyy}" />
                                                    </Columns>
                                                </asp:GridView>
                                                <br />
                                                <br />
                                            </td>
                                        </tr>
                                    </table>

                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </Content>
                    </ajaxToolkit:AccordionPane>

                    <ajaxToolkit:AccordionPane runat="server" ID="AccordionPane3">
                        <Header>
                            <asp:Label ID="lblHeader2C" runat="server"></asp:Label><br />
                            <asp:Label ID="lblDescription2C" runat="server"></asp:Label>
                        </Header>
                        <Content>
                            <asp:UpdatePanel ID="upPA03_2C" runat="server">
                                <ContentTemplate>
                                    <table>
                                        <tr>
                                            <td>
                                                <table>
                                                    <tr>
                                                        <th>Duties<span class="required">*</span>
                                                        </th>
                                                        <th>Level<span class="required">*</span>
                                                        </th>
                                                        <th>O/M/P/F<span class="required">*</span>
                                                        </th>
                                                        <th>From Date<span class="required">*</span>
                                                        </th>
                                                        <th>To Date<span class="required">*</span>
                                                        </th>
                                                    </tr>
                                                    <tr>
                                                        <td style="vertical-align: top">
                                                            <asp:TextBox ID="txtDuty2C" runat="server" MaxLength="400" TextMode="MultiLine" Rows="5"
                                                                Width="300px"></asp:TextBox>
                                                        </td>
                                                        <td style="vertical-align: top">
                                                            <asp:DropDownList ID="ddlLevel2C" runat="server" Width="97px">
                                                            </asp:DropDownList></td>
                                                        <td style="vertical-align: top">
                                                            <asp:DropDownList ID="ddlOPMF2C" runat="server" Width="97px">
                                                            </asp:DropDownList></td>
                                                        <td style="vertical-align: top">
                                                            <asp:TextBox ID="txtFromDate2C" runat="server" Width="97px">
                                                            </asp:TextBox>
                                                            <ajaxToolkit:CalendarExtender ID="CalendarExtender9" runat="server" TargetControlID="txtFromDate2C" Format="dd/MM/yyyy">
                                                            </ajaxToolkit:CalendarExtender>
                                                            <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender5" runat="server" Mask="99/99/9999" MaskType="Date"
                                                                TargetControlID="txtFromDate2C">
                                                            </ajaxToolkit:MaskedEditExtender>
                                                        </td>
                                                        <td style="vertical-align: top">
                                                            <asp:TextBox ID="txtToDate2C" runat="server" Width="97px">
                                                            </asp:TextBox>
                                                            <ajaxToolkit:CalendarExtender ID="CalendarExtender10" runat="server" TargetControlID="txtToDate2C" Format="dd/MM/yyyy">
                                                            </ajaxToolkit:CalendarExtender>
                                                            <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender6" runat="server" Mask="99/99/9999" MaskType="Date"
                                                                TargetControlID="txtToDate2C">
                                                            </ajaxToolkit:MaskedEditExtender>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Button ID="btnSave2C" Text="Save" runat="server" OnClick="btnSave_Click" />
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="6">
                                                <asp:GridView ID="gridData2C" runat="server" AutoGenerateColumns="false" GridLines="None"
                                                    AllowPaging="false" CssClass="gridDynamic" AlternatingRowStyle-CssClass="alt"
                                                    SelectedRowStyle-CssClass="pgr" OnRowDeleting="gridData2C_RowDeleting" DataKeyNames="PA03_2C_ID">
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="S.No.">
                                                            <ItemTemplate>
                                                                <%# ((GridViewRow)Container).RowIndex + 1%>
                                    .
                                                            </ItemTemplate>
                                                            <ItemStyle Width="30px" />
                                                        </asp:TemplateField>
                                                        <asp:BoundField DataField="PA03_2C_DUT" HeaderText="Duties" />
                                                        <asp:BoundField DataField="PA03_UNIV_LVL_VALUE" HeaderText="Level" />
                                                        <asp:BoundField DataField="PA03_OPMF_VALUE" HeaderText="O/M/P/F" />
                                                        <asp:BoundField DataField="PA03_2C_FROM_DATE" HeaderText="From Date" DataFormatString="{0:dd/MM/yyyy}" />
                                                        <asp:BoundField DataField="PA03_2C_TO_DATE" HeaderText="To Date" DataFormatString="{0:dd/MM/yyyy}" />
                                                    </Columns>
                                                </asp:GridView>
                                                <br />
                                                <br />
                                            </td>
                                        </tr>
                                    </table>

                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </Content>
                    </ajaxToolkit:AccordionPane>
                    <ajaxToolkit:AccordionPane runat="server" ID="AccordionPane4">
                        <Header>
                            <asp:Label ID="lblHeader2D" runat="server"></asp:Label>
                            <br />
                            <asp:Label ID="lblDescription2D" runat="server"></asp:Label>
                        </Header>
                        <Content>
                            <asp:UpdatePanel ID="upPA03_2D" runat="server">
                                <ContentTemplate>
                                    <table>
                                        <tr>
                                            <td>
                                                <table>
                                                    <tr>
                                                        <th>Duties<span class="required">*</span>
                                                        </th>
                                                        <th>Level<span class="required">*</span>
                                                        </th>
                                                        <th>O/M/P/F<span class="required">*</span>
                                                        </th>
                                                        <th>From Date<span class="required">*</span>
                                                        </th>
                                                        <th>To Date<span class="required">*</span>
                                                        </th>
                                                    </tr>
                                                    <tr>
                                                        <td style="vertical-align: top">
                                                            <asp:TextBox ID="txtDuty2D" runat="server" MaxLength="400" TextMode="MultiLine" Rows="5"
                                                                Width="300px"></asp:TextBox>
                                                        </td>
                                                        <td style="vertical-align: top">
                                                            <asp:DropDownList ID="ddlLevel2D" runat="server" Width="97px">
                                                            </asp:DropDownList></td>
                                                        <td style="vertical-align: top">
                                                            <asp:DropDownList ID="ddlOPMF2D" runat="server" Width="97px">
                                                            </asp:DropDownList></td>
                                                        <td style="vertical-align: top">
                                                            <asp:TextBox ID="txtFromDate2D" runat="server" Width="97px">
                                                            </asp:TextBox>
                                                            <ajaxToolkit:CalendarExtender ID="CalendarExtender5" runat="server" TargetControlID="txtFromDate2D" Format="dd/MM/yyyy">
                                                            </ajaxToolkit:CalendarExtender>
                                                            <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender7" runat="server" Mask="99/99/9999" MaskType="Date"
                                                                TargetControlID="txtFromDate2D">
                                                            </ajaxToolkit:MaskedEditExtender>
                                                        </td>
                                                        <td style="vertical-align: top">
                                                            <asp:TextBox ID="txtToDate2D" runat="server" Width="97px">
                                                            </asp:TextBox>
                                                            <ajaxToolkit:CalendarExtender ID="CalendarExtender6" runat="server" TargetControlID="txtToDate2D" Format="dd/MM/yyyy">
                                                            </ajaxToolkit:CalendarExtender>
                                                            <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender8" runat="server" Mask="99/99/9999" MaskType="Date"
                                                                TargetControlID="txtToDate2D">
                                                            </ajaxToolkit:MaskedEditExtender>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Button ID="btnSave2D" Text="Save" runat="server" OnClick="btnSave2D_Click" />
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="6">
                                                <asp:GridView ID="gridData2D" runat="server" AutoGenerateColumns="false" GridLines="None"
                                                    AllowPaging="false" CssClass="gridDynamic" AlternatingRowStyle-CssClass="alt"
                                                    SelectedRowStyle-CssClass="pgr" DataKeyNames="PA03_2D_ID" OnRowDeleting="gridData2D_RowDeleting">
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="S.No.">
                                                            <ItemTemplate>
                                                                <%# ((GridViewRow)Container).RowIndex + 1%>
                                    .
                                                            </ItemTemplate>
                                                            <ItemStyle Width="30px" />
                                                        </asp:TemplateField>
                                                        <asp:BoundField DataField="PA03_2D_DUT" HeaderText="Duties" />
                                                        <asp:BoundField DataField="PA03_UNIV_LVL_VALUE" HeaderText="Level" />
                                                        <asp:BoundField DataField="PA03_OPMF_VALUE" HeaderText="O/M/P/F" />
                                                        <asp:BoundField DataField="PA03_2D_FROM_DATE" HeaderText="From Date" DataFormatString="{0:dd/MM/yyyy}" />
                                                        <asp:BoundField DataField="PA03_2D_TO_DATE" HeaderText="To Date" DataFormatString="{0:dd/MM/yyyy}" />
                                                        <asp:BoundField DataField="PA03_2D_STATUS" HeaderText="Status" />
                                                    </Columns>
                                                </asp:GridView>
                                                <br />
                                                <br />
                                            </td>
                                        </tr>
                                    </table>

                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </Content>
                    </ajaxToolkit:AccordionPane>
                    <ajaxToolkit:AccordionPane runat="server" ID="AccordionPane5">
                        <Header>
                            <asp:Label ID="lblHeader2E" runat="server"></asp:Label>
                            <br />
                            <asp:Label ID="lblDescription2E" runat="server"></asp:Label>
                        </Header>
                        <Content>
                            <asp:UpdatePanel ID="upPA03_2E" runat="server">
                                <ContentTemplate>
                                    <table>
                                        <tr>
                                            <td>
                                                <table>
                                                    <tr>
                                                        <th>Duties<span class="required">*</span>
                                                        </th>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="8">
                                                            <asp:TextBox ID="txtDuty2E" runat="server" MaxLength="400" TextMode="MultiLine" Rows="5"
                                                                Width="300px"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Button ID="btnSave2E" Text="Save" runat="server" OnClick="btnSave2E_Click" /></td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="6">
                                                <asp:GridView ID="gridData2E" runat="server" AutoGenerateColumns="false" GridLines="None"
                                                    AllowPaging="false" CssClass="gridDynamic" AlternatingRowStyle-CssClass="alt"
                                                    SelectedRowStyle-CssClass="pgr" DataKeyNames="PA03_2E_ID" OnRowDeleting="gridData2E_RowDeleting">
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="S.No.">
                                                            <ItemTemplate>
                                                                <%# ((GridViewRow)Container).RowIndex + 1%>
                                        .
                                                            </ItemTemplate>
                                                            <ItemStyle Width="30px" />
                                                        </asp:TemplateField>
                                                        <asp:BoundField DataField="PA03_2E_DUT" HeaderText="Duties" />
                                                        <asp:BoundField DataField="PA03_2E_STATUS" HeaderText="Status" />
                                                    </Columns>
                                                </asp:GridView>
                                                <br />
                                                <br />
                                            </td>
                                        </tr>
                                    </table>

                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </Content>
                    </ajaxToolkit:AccordionPane>
                    <ajaxToolkit:AccordionPane runat="server" ID="AccordionPane6">
                        <Header>
                            <asp:Label ID="lblHeader2F" runat="server"></asp:Label>
                            <br />
                            <asp:Label ID="lblDescription2F" runat="server"></asp:Label>
                        </Header>
                        <Content>
                            <asp:UpdatePanel ID="upPA03_2F" runat="server">
                                <ContentTemplate>
                                    <table>
                                        <tr>
                                            <th>1.	General Involvement</th>
                                        </tr>
                                        <tr>
                                            <td>
                                                <table>
                                                    <tr>
                                                        <th>i) Counselling at Admission Cell <span class="required">*</span>
                                                        </th>
                                                        <td>&nbsp;</td>
                                                        <td colspan="6">
                                                            <asp:TextBox ID="txtCounselling" runat="server" MaxLength="200"
                                                                Width="300px"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <th>ii) Total time spent (hours) <span class="required">*</span>
                                                        </th>
                                                        <td>&nbsp;</td>
                                                        <td colspan="6">
                                                            <asp:TextBox ID="txtTotalTime" runat="server" MaxLength="200"
                                                                Width="300px"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <th>iii) Contact explored / travel made off campus details <span class="required">*</span>
                                                        </th>

                                                        <td colspan="6">
                                                            <asp:TextBox ID="txtContact" runat="server" MaxLength="200"
                                                                Width="300px"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                  
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <th>2. Any other contribution</th>
                                        </tr>
                                        <tr>
                                            <td>
                                                <table>
                                                    <tr>
                                                        <th>i)No. of students motivated to pursue higher study here  <span class="required">*</span>
                                                        </th>
                                                        <td>&nbsp;</td>
                                                        <td colspan="3">
                                                            <asp:TextBox ID="txtAny1" runat="server" MaxLength="50"
                                                                Width="100px"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <th>ii) No. of students encouraged to purchase admission form  <span class="required">*</span>
                                                        </th>
                                                        <td>&nbsp;</td>
                                                        <td colspan="6">
                                                            <asp:TextBox ID="txtAny2" runat="server" MaxLength="50"
                                                                Width="100px"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <th>iii) No. of students to visit university campus  <span class="required">*</span>
                                                        </th>

                                                        <td colspan="6">
                                                            <asp:TextBox ID="txtAny3" runat="server" MaxLength="50"
                                                                Width="100px"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <th>iv) No. of students connected put up for counselling in admission cell  <span class="required">*</span>
                                                        </th>

                                                        <td colspan="6">
                                                            <asp:TextBox ID="txtAny4" runat="server" MaxLength="50"
                                                                Width="100px"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <th>V) No. of students got admission  <span class="required">*</span>
                                                        </th>

                                                        <td colspan="6">
                                                            <asp:TextBox ID="txtAny5" runat="server" MaxLength="50"
                                                                Width="100px"></asp:TextBox>
                                                        </td>
                                                    </tr>

                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="6">
                                                <table style="width:100%;">
                                                    <tr>
                                                       
                                                        <th>Program</th>
                                                        <th>Students Name</th>
                                                        <th></th>
                                                    </tr>
                                                    <tr>
                                                       
                                                        <td>
                                                            <asp:TextBox ID="txtProgram1" runat="server"></asp:TextBox></td>
                                                        <td><asp:TextBox ID="txtStudent1" runat="server"></asp:TextBox></td>
                                                        <td>
                                                            <asp:Button ID="btnAdd" runat="server" Text="Add Student" OnClick="lnkAdd_Click"/></td>
                                                    </tr>
                                                    
                                                    <tr>
                                                       <td>
                                                           <asp:GridView ID="gvStudentDetail" AutoGenerateColumns="False" runat="server" EmptyDataText="No recoeds found." CssClass="gridDynamic" OnRowDeleting="gvStudentDetail_RowDeleting">
                                                            <Columns>
                                                                <asp:TemplateField HeaderText="S.No.">
                                                                    <ItemTemplate>
                                                                        <%# ((GridViewRow)Container).RowIndex + 1%>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:BoundField HeaderText="Program" DataField="PA03_2F_PROGRAM" />
                                                                <asp:BoundField HeaderText="Student" DataField="PA03_2F_STUDENT" />                                                               
                                                                <asp:CommandField ButtonType="Image" HeaderText="Delete" DeleteImageUrl="~/images/delete.gif" ShowDeleteButton="True"></asp:CommandField>
                                                            </Columns>
                                                        </asp:GridView>
                                                       </td>
                                                    </tr>
                                                   
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:TextBox ID="txtXML" runat="server" Visible="false"></asp:TextBox>
                                                <asp:Button ID="btnSave2F" Text="Save" runat="server" OnClick="btnSave2F_Click" />
                                            </td>
                                        </tr>
                                    </table>

                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </Content>
                    </ajaxToolkit:AccordionPane>
                </Panes>
            </ajaxToolkit:Accordion>
        </div>
        <div style="text-align: right; color: #5a72f8; font-weight: bold; font-size: 14px">
            <a href="PA03_Home.aspx" style="">Back To Main Page</a>
        </div>
    </div>
</asp:Content>

