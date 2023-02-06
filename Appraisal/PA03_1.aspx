<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/FullLength.master" AutoEventWireup="true" CodeFile="PA03_1.aspx.cs" Inherits="Appraisal_PA031" %>

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
        function validation1A() {

            var flag = true;
            var msg = "", ctrl = "";

            if (!CheckControl("<%=txtCode.ClientID%>")) {
                msg += "- Enter Paper Code\n";
                if (ctrl == "")
                    ctrl = "<%=txtCode.ClientID%>";
                flag = false;
            }
            if (!CheckControl("<%=txtName.ClientID%>")) {
                msg += "- Enter Paper Name\n";
                if (ctrl == "")
                    ctrl = "<%=txtName.ClientID%>";
                flag = false;
            }
            if (!CheckControl("<%=txtCount.ClientID%>")) {
                msg += "- Enter Student Count\n";
                if (ctrl == "")
                    ctrl = "<%=txtCount.ClientID%>";
                flag = false;
            }
            if (!CheckControl("<%=txtLecture.ClientID%>")) {
                msg += "- Enter Lecture\n";
                if (ctrl == "")
                    ctrl = "<%=txtLecture.ClientID%>";
                flag = false;
            }
            if (!CheckControl("<%=txtTutorial.ClientID%>")) {
                msg += "- Enter Tutorial\n";
                if (ctrl == "")
                    ctrl = "<%=txtTutorial.ClientID%>";
                flag = false;
            }
            if (!CheckControl("<%=txtPractical.ClientID%>")) {
                msg += "- Enter Practical\n";
                if (ctrl == "")
                    ctrl = "<%=txtPractical.ClientID%>";
                flag = false;
            }
            if (msg != "") alert(msg);
            if (ctrl != "")
                document.getElementById(ctrl).focus();
            return flag;
        }
        function validation1B() {

            var flag = true;
            var msg = "", ctrl = "";

            if (!CheckControl("<%=txtDetail.ClientID%>")) {
                msg += "- Enter Detail\n";
                if (ctrl == "")
                    ctrl = "<%=txtDetail.ClientID%>";
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
            <h2>Instructional Element
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
                            <asp:Label ID="lblHeader1A" runat="server" Font-Underline="true"></asp:Label><br />
                            <asp:Label ID="lblDescription1A" runat="server"></asp:Label>
                        </Header>
                        <Content>
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                <ContentTemplate>
                                    <table>
                                        <tr>
                                            <td>
                                                <table>
                                                    <tr>
                                                        <th>Paper Code<span class="required">*</span></th>
                                                        <th>Paper Name<span class="required">*</span></th>
                                                        <th>Student Count<span class="required">*</span></th>
                                                        <th>Lecture<span class="required">*</span></th>
                                                        <th>Tutorial<span class="required">*</span></th>
                                                        <th>Practical<span class="required">*</span></th>
                                                        <th>Innovation in teaching.if any</th>
                                                    </tr>
                                                    <tr>
                                                        <td style="vertical-align: top">
                                                            <asp:TextBox ID="txtCode" runat="server" MaxLength="30" Width="67px"></asp:TextBox></td>
                                                        <td style="vertical-align: top">
                                                            <asp:TextBox ID="txtName" runat="server" MaxLength="200" TextMode="MultiLine" Rows="5"
                                                                Width="150px"></asp:TextBox></td>
                                                        <td style="vertical-align: top">
                                                            <cc1:NumericTextBox ID="txtCount" runat="server" AllowDecimal="false" MaxLength="3"
                                                                Width="80px"></cc1:NumericTextBox></td>
                                                        <td style="vertical-align: top">
                                                            <cc1:NumericTextBox ID="txtLecture" runat="server" AllowDecimal="true" MaxLength="5"
                                                                DecimalPlaces="2" Width="60px"></cc1:NumericTextBox></td>
                                                        <td style="vertical-align: top">
                                                            <cc1:NumericTextBox ID="txtTutorial" runat="server" AllowDecimal="true" MaxLength="5"
                                                                DecimalPlaces="2" Width="60px"></cc1:NumericTextBox></td>
                                                        <td style="vertical-align: top">
                                                            <cc1:NumericTextBox ID="txtPractical" runat="server" AllowDecimal="true" MaxLength="5"
                                                                DecimalPlaces="2" Width="60px"></cc1:NumericTextBox></td>
                                                        <td style="vertical-align: top">
                                                            <asp:TextBox ID="txtRemark" runat="server" MaxLength="400" TextMode="MultiLine" Rows="5"
                                                                Width="200px"></asp:TextBox></td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="required">Note:- All entries are for weekly records.</td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Button ID="btnSave1A" Text="Save" runat="server" OnClick="btnSave1A_Click" /></td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:GridView ID="gridData1A" runat="server" AutoGenerateColumns="false" DataKeyNames="PA03_1A_ID" CssClass="gridDynamic" OnRowDeleting="gridData1A_RowDeleting">
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="S.No.">
                                                            <ItemTemplate>
                                                                <%# ((GridViewRow)Container).RowIndex + 1%>
                                        .
                                                            </ItemTemplate>
                                                            <ItemStyle Width="30px" />
                                                        </asp:TemplateField>
                                                        <asp:BoundField HeaderText="Paper Code" DataField="PA03_1A_CODE" ItemStyle-Width="50px" />
                                                        <asp:BoundField HeaderText="Paper Name" DataField="PA03_1A_NAME" ItemStyle-Width="100px" />
                                                        <asp:BoundField HeaderText="Student Count" DataField="PA03_1A_COT" ItemStyle-Width="50px" />
                                                        <asp:BoundField HeaderText="Lecture" DataField="PA03_1A_LAB" ItemStyle-Width="50px" />
                                                        <asp:BoundField HeaderText="Tutorial" DataField="PA03_1A_TUT" ItemStyle-Width="50px" />
                                                        <asp:BoundField HeaderText="Practical" DataField="PA03_1A_PCT" ItemStyle-Width="50px" />
                                                        <asp:BoundField HeaderText="Innovation" DataField="PA03_1A_RMK" ItemStyle-Width="200px" />
                                                        <%--<asp:BoundField HeaderText="Status" DataField="PA03_1A_STATUS" ItemStyle-Width="50px" />--%>
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
                            <asp:Label ID="lblHeader1B" runat="server" Font-Underline="true"></asp:Label><br />
                            <asp:Label ID="lblDescription1B" runat="server"></asp:Label>
                        </Header>
                        <Content>
                            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                <ContentTemplate>
                                    <table>
                                        <tr>
                                            <td>
                                                <table>
                                                    <tr>
                                                        <th>Details</th>
                                                    </tr>
                                                    <tr>
                                                        <th>
                                                            <asp:TextBox ID="txtDetail" runat="server" MaxLength="400" TextMode="MultiLine" Rows="5" Width="400px"></asp:TextBox>
                                                        </th>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Button ID="btnSave1B" Text="Save" runat="server" OnClick="btnSave1B_Click" /></td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:GridView ID="gridData1B" runat="server" AutoGenerateColumns="false" GridLines="None"
                                                    AllowPaging="false" CssClass="gridDynamic"
                                                    OnRowDeleting="gridData1B_RowDeleting" DataKeyNames="PA03_1B_ID">
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="S.No.">
                                                            <ItemTemplate>
                                                                <%# ((GridViewRow)Container).RowIndex + 1%>                                    .
                                                            </ItemTemplate>
                                                            <ItemStyle Width="30px" />
                                                        </asp:TemplateField>
                                                        <asp:BoundField DataField="PA03_1B_DET" HeaderText="Details" ItemStyle-Width="500px" />
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
                </Panes>
            </ajaxToolkit:Accordion>

        </div>
        <div style="text-align: right; color: #5a72f8; font-weight: bold; font-size: 14px">
            <a href="PA03_Home.aspx">Back To Main Page</a>
        </div>
    </div>
</asp:Content>

