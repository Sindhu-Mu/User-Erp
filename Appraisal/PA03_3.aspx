<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/FullLength.master" AutoEventWireup="true" CodeFile="PA03_3.aspx.cs" Inherits="Appraisal_PA033" %>

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
        function validation3A() {

            var flag = true;
            var msg = "", ctrl = "";

            if (!CheckControl("<%=txtAward3A.ClientID%>")) {
                msg += "- Enter Award\n";
                if (ctrl == "")
                    ctrl = "<%=txtAward3A.ClientID%>";
                flag = false;
            }
            if (!CheckControl("<%=txtRemark3A.ClientID%>")) {
                msg += "- Enter Remark\n";
                if (ctrl == "")
                    ctrl = "<%=txtRemark3A.ClientID%>";
                flag = false;
            }
            
                   
            if (msg != "") alert(msg);
            if (ctrl != "")
                document.getElementById(ctrl).focus();
            return flag;
        }

        function validation3B() {

            var flag = true;
            var msg = "", ctrl = "";

            if (!CheckControl("<%=txtMembership3B.ClientID%>")) {
                msg += "- Enter Membership\n";
                if (ctrl == "")
                    ctrl = "<%=txtMembership3B.ClientID%>";
                flag = false;
            }
            if (!CheckControl("<%=txtRemark3B.ClientID%>")) {
                 msg += "- Enter Remark\n";
                 if (ctrl == "")
                     ctrl = "<%=txtRemark3B.ClientID%>";
                flag = false;
            }


            if (msg != "") alert(msg);
            if (ctrl != "")
                document.getElementById(ctrl).focus();
            return flag;
        }

        function validation3C() {

            var flag = true;
            var msg = "", ctrl = "";

            if (!CheckControl("<%=txtName3C.ClientID%>")) {
                msg += "- Enter Name\n";
                if (ctrl == "")
                    ctrl = "<%=txtName3C.ClientID%>";
                flag = false;
            }
            if (!CheckControl("<%=txtSponsoredBy3C.ClientID%>")) {
                msg += "-Enter Sponsored\n";
                if (ctrl == "")
                    ctrl = "<%=txtSponsoredBy3C.ClientID%>";
                flag = false;
            }
            if (CheckControl("<%=txtFromDate3C.ClientID%>")) {
                if (!CheckDate("<%=txtFromDate3C.ClientID%>")) {
                    msg += "- Invalid Format of Date.Please Enter in this[dd/MM/yyyy]\n";
                    if (ctrl == "")
                        ctrl = "<%=txtFromDate3C.ClientID%>";
                    flag = false;
                }
            }
            else {
                msg += "- Enter To Date\n";
                if (ctrl == "")
                    ctrl = "<%=txtFromDate3C.ClientID%>";
                 flag = false;
             }
             if (CheckControl("<%=txtToDate3C.ClientID%>")) {
                if (!CheckDate("<%=txtToDate3C.ClientID%>")) {
                    msg += "- Invalid Format of Date.Please Enter in this[dd/MM/yyyy]\n";
                    if (ctrl == "")
                        ctrl = "<%=txtToDate3C.ClientID%>";
                     flag = false;
                 }
             }
             else {
                 msg += "- Enter To Date\n";
                 if (ctrl == "")
                     ctrl = "<%=txtToDate3C.ClientID%>";
                flag = false;
            }
            if (msg != "") alert(msg);
            if (ctrl != "")
                document.getElementById(ctrl).focus();
            return flag;
        }
        function validation3D() {

            var flag = true;
            var msg = "", ctrl = "";

            if (!CheckControl("<%=txtIns3D.ClientID%>")) {
                msg += "- Enter Instt.\n";
                if (ctrl == "")
                    ctrl = "<%=txtIns3D.ClientID%>";
                flag = false;
            }
            if (!CheckControl("<%=txtPup3D.ClientID%>")) {
                msg += "-Enter Purpose\n";
                if (ctrl == "")
                    ctrl = "<%=txtPup3D.ClientID%>";
                flag = false;
            }
            if (CheckControl("<%=txtFromDate3D.ClientID%>")) {
                if (!CheckDate("<%=txtFromDate3D.ClientID%>")) {
                    msg += "- Invalid Format of Date.Please Enter in this[dd/MM/yyyy]\n";
                    if (ctrl == "")
                        ctrl = "<%=txtFromDate3D.ClientID%>";
                    flag = false;
                }
            }
            else {
                msg += "- Enter To Date\n";
                if (ctrl == "")
                    ctrl = "<%=txtFromDate3D.ClientID%>";
                flag = false;
            }
            if (CheckControl("<%=txtToDate3D.ClientID%>")) {
                if (!CheckDate("<%=txtToDate3D.ClientID%>")) {
                     msg += "- Invalid Format of Date.Please Enter in this[dd/MM/yyyy]\n";
                     if (ctrl == "")
                         ctrl = "<%=txtToDate3D.ClientID%>";
                    flag = false;
                }
            }
            else {
                msg += "- Enter To Date\n";
                if (ctrl == "")
                    ctrl = "<%=txtToDate3D.ClientID%>";
                 flag = false;
             }
             if (msg != "") alert(msg);
             if (ctrl != "")
                 document.getElementById(ctrl).focus();
             return flag;
         }
        function validation3E() {

            var flag = true;
            var msg = "", ctrl = "";

            if (!CheckControl("<%=txtName3E.ClientID%>")) {
                msg += "- Enter Name\n";
                if (ctrl == "")
                    ctrl = "<%=txtName3E.ClientID%>";
                flag = false;
            }
            if (!CheckControl("<%=txtPlace3E.ClientID%>")) {
                msg += "- Enter Place\n";
                if (ctrl == "")
                    ctrl = "<%=txtPlace3E.ClientID%>";
                flag = false;
            }
            if (!CheckControl("<%=txtSponsoredBy3E.ClientID%>")) {
                msg += "-Enter Sponsored\n";
                if (ctrl == "")
                    ctrl = "<%=txtSponsoredBy3E.ClientID%>";
                flag = false;
            }
            if (CheckControl("<%=txtFromDate3E.ClientID%>")) {
                if (!CheckDate("<%=txtFromDate3E.ClientID%>")) {
                    msg += "- Invalid Format of Date.Please Enter in this[dd/MM/yyyy]\n";
                    if (ctrl == "")
                        ctrl = "<%=txtFromDate3E.ClientID%>";
                    flag = false;
                }
            }
            else {
                msg += "- Enter To Date\n";
                if (ctrl == "")
                    ctrl = "<%=txtFromDate3E.ClientID%>";
                flag = false;
            }
            if (CheckControl("<%=txtToDate3E.ClientID%>")) {
                if (!CheckDate("<%=txtToDate3E.ClientID%>")) {
                     msg += "- Invalid Format of Date.Please Enter in this[dd/MM/yyyy]\n";
                     if (ctrl == "")
                         ctrl = "<%=txtToDate3E.ClientID%>";
                    flag = false;
                }
            }
            else {
                msg += "- Enter To Date\n";
                if (ctrl == "")
                    ctrl = "<%=txtToDate3E.ClientID%>";
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
            <h2>Other Academic Activities</h2>
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
                            <asp:Label ID="lblHeader3A" runat="server"></asp:Label>
                            <br />
                            <asp:Label ID="lblDescription3A" runat="server"></asp:Label>
                        </Header>
                        <Content>
                            <asp:UpdatePanel ID="up3A" runat="server">
                                <ContentTemplate>


                                    <table>
                                        <tr>
                                            <td>
                                                <table>
                                                    <tr>
                                                        <th>Award<span class="required">*</span>
                                                        </th>
                                                        <th>Remark<span class="required">*</span>
                                                        </th>
                                                    </tr>
                                                    <tr>
                                                        <th>
                                                            <asp:TextBox ID="txtAward3A" runat="server" MaxLength="200" TextMode="MultiLine" Rows="5" Width="200px"></asp:TextBox></th>
                                                        <th>
                                                            <asp:TextBox ID="txtRemark3A" runat="server" MaxLength="400" TextMode="MultiLine" Rows="5" Width="200px"></asp:TextBox></th>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Button ID="btnSave3A" Text="Save" runat="server" OnClick="btnSave3A_Click" /></td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:GridView ID="gridData3A" runat="server" AutoGenerateColumns="false" GridLines="None"
                                                    AllowPaging="false" CssClass="gridDynamic" AlternatingRowStyle-CssClass="alt"
                                                    SelectedRowStyle-CssClass="pgr" DataKeyNames="PA03_3A_ID" OnRowDeleting="gridData3A_RowDeleting">
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="S.No.">
                                                            <ItemTemplate>
                                                                <%# ((GridViewRow)Container).RowIndex + 1%>
                                    .
                                                            </ItemTemplate>
                                                            <ItemStyle Width="30px" />
                                                        </asp:TemplateField>
                                                        <asp:BoundField DataField="PA03_3A_AWD" HeaderText="Award" />
                                                        <asp:BoundField DataField="PA03_3A_RMK" HeaderText="Remark" />
                                                        <%--<asp:BoundField DataField="PA03_3A_STATUS" HeaderText="Status" />--%>
                                                    </Columns>
                                                </asp:GridView>
                                            </td>
                                        </tr>
                                    </table>

                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </Content>
                    </ajaxToolkit:AccordionPane>
                    <ajaxToolkit:AccordionPane runat="server" ID="AccordionPane2">
                        <Header>
                            <asp:Label ID="lblHeader3B" runat="server"></asp:Label><br />
                            <asp:Label ID="lblDescription3B" runat="server"></asp:Label>
                        </Header>
                        <Content>
                            <asp:UpdatePanel ID="up3B" runat="server">
                                <ContentTemplate>

                                    <table>
                                        <tr>
                                            <td>
                                                <table>
                                                    <tr>
                                                        <th>Membership<span class="required">*</span>
                                                        </th>
                                                        <th>Remark<span class="required">*</span>
                                                        </th>
                                                    </tr>
                                                    <tr>
                                                        <th>
                                                            <asp:TextBox ID="txtMembership3B" runat="server" MaxLength="200" TextMode="MultiLine"
                                                                Rows="5" Width="200px"></asp:TextBox></th>
                                                        <th>
                                                            <asp:TextBox ID="txtRemark3B" runat="server" MaxLength="400" TextMode="MultiLine" Rows="5" Width="200px"></asp:TextBox></th>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Button ID="btnSave3B" Text="Save" runat="server" OnClick="btnSave3B_Click" /></td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:GridView ID="gridData3B" runat="server" AutoGenerateColumns="false" GridLines="None"
                                                    AllowPaging="false" CssClass="gridDynamic" AlternatingRowStyle-CssClass="alt" DataKeyNames="PA03_3B_ID"
                                                    SelectedRowStyle-CssClass="pgr" OnRowDeleting="gridData3B_RowDeleting">
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="S.No.">
                                                            <ItemTemplate>
                                                                <%# ((GridViewRow)Container).RowIndex + 1%>
                                    .
                                                            </ItemTemplate>
                                                            <ItemStyle Width="30px" />
                                                        </asp:TemplateField>
                                                        <asp:BoundField DataField="PA03_3B_MEM" HeaderText="Membership" />
                                                        <asp:BoundField DataField="PA03_3B_RMK" HeaderText="Remark" />
                                                        <%-- <asp:BoundField DataField="PA03_3B_STATUS" HeaderText="Status" />--%>
                                                    </Columns>
                                                </asp:GridView>
                                            </td>
                                        </tr>
                                    </table>

                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </Content>
                    </ajaxToolkit:AccordionPane>

                    <ajaxToolkit:AccordionPane runat="server" ID="AccordionPane3">
                        <Header>
                            <asp:Label ID="lblHeader3C" runat="server"></asp:Label><br />
                            <asp:Label ID="lblDescription3C" runat="server"></asp:Label>
                        </Header>
                        <Content>
                            <asp:UpdatePanel ID="up3C" runat="server">
                                <ContentTemplate>
                                    <table>
                                        <tr>
                                            <td>
                                                <table>
                                                    <tr>
                                                        <th>Name of the Conf./Seminar/Course<span class="required">*</span></th>
                                                        <th>Sponsored By<span class="required">*</span></th>
                                                        <th>From Date<span class="required">*</span></th>
                                                        <th>To Date<span class="required">*</span></th>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:TextBox ID="txtName3C" runat="server" MaxLength="200" TextMode="MultiLine" Rows="5" Width="200px"></asp:TextBox></td>
                                                        <td>
                                                            <asp:TextBox ID="txtSponsoredBy3C" runat="server" MaxLength="200" TextMode="MultiLine" Rows="5" Width="200px"></asp:TextBox></td>
                                                        <td style="vertical-align: top">
                                                            <asp:TextBox ID="txtFromDate3C" runat="server" Width="80px"></asp:TextBox>
                                                            <ajaxToolkit:CalendarExtender ID="CalendarExtender3" runat="server" TargetControlID="txtFromDate3C" Format="dd/MM/yyyy">
                                                            </ajaxToolkit:CalendarExtender>
                                                            <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender1" runat="server" Mask="99/99/9999" MaskType="Date"
                                                                TargetControlID="txtFromDate3C">
                                                            </ajaxToolkit:MaskedEditExtender>
                                                        </td>
                                                        <td style="vertical-align: top">
                                                            <asp:TextBox ID="txtToDate3C" runat="server" Width="80px"></asp:TextBox>
                                                            <ajaxToolkit:CalendarExtender ID="CalendarExtender4" runat="server" TargetControlID="txtToDate3C" Format="dd/MM/yyyy">
                                                            </ajaxToolkit:CalendarExtender>
                                                            <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender2" runat="server" Mask="99/99/9999" MaskType="Date"
                                                                TargetControlID="txtToDate3C">
                                                            </ajaxToolkit:MaskedEditExtender>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Button ID="btnSave3C" Text="Save" runat="server" OnClick="btnSave3C_Click" />
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:GridView ID="gridData3C" runat="server" AutoGenerateColumns="false" GridLines="None"
                                                    AllowPaging="false" CssClass="gridDynamic" AlternatingRowStyle-CssClass="alt"
                                                    SelectedRowStyle-CssClass="pgr" DataKeyNames="PA03_3C_ID" OnRowDeleting="gridData3C_RowDeleting">
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="S.No.">
                                                            <ItemTemplate>
                                                                <%# ((GridViewRow)Container).RowIndex + 1%>
                                    .
                                                            </ItemTemplate>
                                                            <ItemStyle Width="30px" />
                                                        </asp:TemplateField>
                                                        <asp:BoundField DataField="PA03_3C_NAME" HeaderText="Name of the Conf./Seminar/Course" />
                                                        <asp:BoundField DataField="PA03_3C_SPD" HeaderText="Sponsored By" />
                                                        <asp:BoundField DataField="PA03_3C_FROM_DATE" HeaderText="From Date" DataFormatString="{0:dd/MM/yyyy}" />
                                                        <asp:BoundField DataField="PA03_3C_TO_DATE" HeaderText="To Date" DataFormatString="{0:dd/MM/yyyy}" />
                                                        <%-- <asp:BoundField DataField="PA03_3C_STATUS" HeaderText="Status" />--%>
                                                    </Columns>
                                                </asp:GridView>
                                            </td>
                                        </tr>
                                    </table>

                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </Content>
                    </ajaxToolkit:AccordionPane>

                    <ajaxToolkit:AccordionPane runat="server" ID="AccordionPane4">
                        <Header>
                            <asp:Label ID="lblHeader3D" runat="server"></asp:Label><br />
                            <asp:Label ID="lblDescription3D" runat="server"></asp:Label>
                        </Header>
                        <Content>
                            <asp:UpdatePanel ID="up3D" runat="server">
                                <ContentTemplate>

                                    <table>
                                        <tr>
                                            <td>
                                                <table>
                                                    <tr>
                                                        <th>Instt./Organisation Visited<span class="required">*</span></th>
                                                        <th>Purpose Of Visit<span class="required">*</span></th>
                                                        <th>From Date<span class="required">*</span></th>
                                                        <th>To Date<span class="required">*</span></th>
                                                    </tr>
                                                    <tr>
                                                        <th>
                                                            <asp:TextBox ID="txtIns3D" runat="server" MaxLength="200" TextMode="MultiLine" Rows="5" Width="209px"></asp:TextBox></th>
                                                        <th>
                                                            <asp:TextBox ID="txtPup3D" runat="server" MaxLength="200" TextMode="MultiLine" Rows="5"
                                                                Width="200px"></asp:TextBox></th>
                                                        <td style="vertical-align: top">
                                                            <asp:TextBox ID="txtFromDate3D" runat="server" Width="80px"></asp:TextBox>
                                                            <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtFromDate3D" Format="dd/MM/yyyy">
                                                            </ajaxToolkit:CalendarExtender>
                                                            <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender3" runat="server" Mask="99/99/9999" MaskType="Date"
                                                                TargetControlID="txtFromDate3D">
                                                            </ajaxToolkit:MaskedEditExtender>
                                                        </td>
                                                        <td style="vertical-align: top">
                                                            <asp:TextBox ID="txtToDate3D" runat="server" Width="80px"></asp:TextBox>
                                                            <ajaxToolkit:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtToDate3D" Format="dd/MM/yyyy">
                                                            </ajaxToolkit:CalendarExtender>
                                                            <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender4" runat="server" Mask="99/99/9999" MaskType="Date"
                                                                TargetControlID="txtToDate3D">
                                                            </ajaxToolkit:MaskedEditExtender>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Button ID="btnSave3D" Text="Save" runat="server" OnClick="btnSave_Click" />
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:GridView ID="gridData3D" runat="server" AutoGenerateColumns="false" GridLines="None"
                                                    AllowPaging="false" CssClass="gridDynamic" AlternatingRowStyle-CssClass="alt"
                                                    SelectedRowStyle-CssClass="pgr" DataKeyNames="PA03_3D_ID" OnRowDeleting="gridData3D_RowDeleting">
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="S.No.">
                                                            <ItemTemplate>
                                                                <%# ((GridViewRow)Container).RowIndex + 1%>
                                        .
                                                            </ItemTemplate>
                                                            <ItemStyle Width="30px" />
                                                        </asp:TemplateField>
                                                        <asp:BoundField DataField="PA03_3D_INS" HeaderText="Instt./Organisation Visited" />
                                                        <asp:BoundField DataField="PA03_3D_PUP" HeaderText="Purpose Of Visit" />
                                                        <asp:BoundField DataField="PA03_3D_FROM_DATE" HeaderText="From Date" DataFormatString="{0:dd/MM/yyyy}" />
                                                        <asp:BoundField DataField="PA03_3D_TO_DATE" HeaderText="To Date" DataFormatString="{0:dd/MM/yyyy}" />
                                                        <%--<asp:BoundField DataField="PA03_3D_STATUS" HeaderText="Status" />--%>
                                                    </Columns>
                                                </asp:GridView>
                                            </td>
                                        </tr>
                                    </table>

                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </Content>
                    </ajaxToolkit:AccordionPane>
                    <ajaxToolkit:AccordionPane runat="server" ID="AccordionPane5">
                        <Header>
                            <asp:Label ID="lblHeader3E" runat="server"></asp:Label><br />
                            <asp:Label ID="lblDescription3E" runat="server"></asp:Label>
                        </Header>
                        <Content>
                            <asp:UpdatePanel ID="up3E" runat="server">
                                <ContentTemplate>

                                    <table>
                                        <tr>
                                            <td>
                                                <table>
                                                    <tr>
                                                        <th>Conf./Seminar/Sym./Workshop/Short Term Courses<span style="color: #ff0000">*</span></th>
                                                        <th>Place<span class="required">*</span></th>
                                                        <th>Sponsored By<span class="required">*</span></th>
                                                        <th>From Date<span class="required">*</span></th>
                                                        <th>To Date<span class="required">*</span></th>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:TextBox ID="txtName3E" runat="server" MaxLength="200" TextMode="MultiLine" Rows="5"
                                                                Width="285px"></asp:TextBox></td>
                                                        <td>
                                                            <asp:TextBox ID="txtPlace3E" runat="server" MaxLength="400" TextMode="MultiLine" Rows="5"
                                                                Width="150px"></asp:TextBox></td>
                                                        <td>
                                                            <asp:TextBox ID="txtSponsoredBy3E" runat="server" MaxLength="200" TextMode="MultiLine"
                                                                Rows="5" Width="150px"></asp:TextBox></td>
                                                        <td style="vertical-align: top">
                                                            <asp:TextBox ID="txtFromDate3E" runat="server" Width="96px"></asp:TextBox>
                                                            <ajaxToolkit:CalendarExtender ID="CalendarExtender5" runat="server" TargetControlID="txtFromDate3E" Format="dd/MM/yyyy">
                                                            </ajaxToolkit:CalendarExtender>
                                                            <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender5" runat="server" Mask="99/99/9999" MaskType="Date"
                                                                TargetControlID="txtFromDate3E">
                                                            </ajaxToolkit:MaskedEditExtender>
                                                        </td>
                                                        <td style="vertical-align: top">
                                                            <asp:TextBox ID="txtToDate3E" runat="server" Width="92px"></asp:TextBox>
                                                            <ajaxToolkit:CalendarExtender ID="CalendarExtender6" runat="server" TargetControlID="txtToDate3E" Format="dd/MM/yyyy">
                                                            </ajaxToolkit:CalendarExtender>
                                                            <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender6" runat="server" Mask="99/99/9999" MaskType="Date"
                                                                TargetControlID="txtToDate3E">
                                                            </ajaxToolkit:MaskedEditExtender>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Button ID="btnSave3E" Text="Save" runat="server" OnClick="btnSave3E_Click" />
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:GridView ID="gridData3E" runat="server" AutoGenerateColumns="false" GridLines="None"
                                                    AllowPaging="false" CssClass="gridDynamic" AlternatingRowStyle-CssClass="alt"
                                                    SelectedRowStyle-CssClass="pgr" DataKeyNames="PA03_3E_ID" OnRowDeleting="gridData3E_RowDeleting">
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="S.No.">
                                                            <ItemTemplate>
                                                                <%# ((GridViewRow)Container).RowIndex + 1%>
                                        .
                                                            </ItemTemplate>
                                                            <ItemStyle Width="30px" />
                                                        </asp:TemplateField>
                                                        <asp:BoundField DataField="PA03_3E_NAME" HeaderText="Conf./Seminar/Sym./Workshop/Short Term Courses" />
                                                        <asp:BoundField DataField="PA03_3E_PLC" HeaderText="Place" />
                                                        <asp:BoundField DataField="PA03_3E_SPD" HeaderText="Sponsored By" />
                                                        <asp:BoundField DataField="PA03_3E_FROM_DATE" HeaderText="From Date" DataFormatString="{0:dd/MM/yyyy}" />
                                                        <asp:BoundField DataField="PA03_3E_TO_DATE" HeaderText="To Date" DataFormatString="{0:dd/MM/yyyy}" />
                                                        <%--<asp:BoundField DataField="PA03_3E_STATUS" HeaderText="Status" />--%>
                                                    </Columns>
                                                </asp:GridView>
                                            </td>
                                        </tr>
                                    </table>

                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </Content>
                    </ajaxToolkit:AccordionPane>
                </Panes>
            </ajaxToolkit:Accordion>
            <div style="text-align: right; color: #5a72f8; font-weight: bold; font-size: 14px">
                <a href="PA03_Home.aspx" style="">Back To Main Page</a>
            </div>
        </div>
    </div>
</asp:Content>

