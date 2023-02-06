<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/FullLength.master" AutoEventWireup="true" CodeFile="NoticeCirucular.aspx.cs" Inherits="Common_NoticeCirucular" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script lang="javascript" type="text/javascript">
        function CheckDate(ctrl) {
            var dt = document.getElementById(ctrl).value;
            if (!isDatecheck(dt, "dd/MM/yyyy")) {
                document.getElementById(ctrl).style.backgroundColor = "#fc6";
                return false;
            }
            else
                document.getElementById(ctrl).style.backgroundColor = "#fff";
            return true;
        }

        function CheckControl(ctrl) {
            if (bTrim(document.getElementById(ctrl).value) == "" || bTrim(document.getElementById(ctrl).value) == "." || bTrim(document.getElementById(ctrl).value) == "Select") {
                document.getElementById(ctrl).style.backgroundColor = "#fc6";
                return false;
            }
            else {
                document.getElementById(ctrl).style.backgroundColor = "#fff";
                return true;
            }
        }

        function Validate() {
            var flag = true;
            var msg = "", ctrl = "";
            if (!CheckControl("<%=txtHeading.ClientID%>")) {
                msg += " * Enter Name with Code. \n";
                if (ctrl == "")
                    ctrl = "<%=txtHeading.ClientID%>";
                flag = false;
            }
            if (!CheckDate("<%=txtAnnDate.ClientID%>")) {
                if (!CheckControl("<%=txtAnnDate.ClientID%>")) {
                    msg += " * Enter Announcment Date. \n";
                    if (ctrl == "")
                        ctrl = "<%=txtAnnDate.ClientID%>";
                    flag = false;
                }
                else {
                    msg += " * Enter Date in dd/mm/yyyy format.  \n";
                    if (ctrl == "")
                        ctrl = "<%=txtAnnDate.ClientID%>";
                    flag = false;
                }
            }
            if (!CheckDate("<%=txtExpire.ClientID%>")) {
                if (!CheckControl("<%=txtExpire.ClientID%>")) {
                    msg += " * Enter Closing Date. \n";
                    if (ctrl == "")
                        ctrl = "<%=txtExpire.ClientID%>";
                    flag = false;
                }
                else {
                    msg += " * Enter Date in dd/mm/yyyy format.  \n";
                    if (ctrl == "")
                        ctrl = "<%=txtExpire.ClientID%>";
                    flag = false;
                }
            }
            if (!CheckControl("<%=ddlNoticeDisplay.ClientID%>")) {
                msg += " * Select display type form list. \n";
                if (ctrl == "")
                    ctrl = "<%=ddlNoticeDisplay.ClientID%>";
                flag = false;
            }
            if (!CheckControl("<%=ddlNotice.ClientID%>")) {
                msg += " * Select notice for form list. \n";
                if (ctrl == "")
                    ctrl = "<%=ddlNotice.ClientID%>";
                flag = false;
            }
            if (!CheckControl("<%=txtDesc.ClientID%>")) {
                msg += " * Enter description of notice. \n";
                if (ctrl == "")
                    ctrl = "<%=txtDesc.ClientID%>";
                flag = false;
            }
            if (msg != "") alert(msg);
            if (ctrl != "")
                document.getElementById(ctrl).focus();
            return flag;
        }
        function Validat() {
            var flag = true;
            var msg = "", ctrl = "";
            if (!CheckControl("<%=ddlUploadType.ClientID%>")) {
                msg += " * Select upload type. \n";
                if (ctrl == "")
                    ctrl = "<%=ddlUploadType.ClientID%>";
                flag = false;
            }

            if (msg != "") alert(msg);
            if (ctrl != "")
                document.getElementById(ctrl).focus();
            return flag;
        }
    </script>
    <div>
        <div class="heading">
            <h2>Notice And Circular</h2>
        </div>
        <div>

            <div>
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                            <ContentTemplate>
                                <table>
                                    <tr>
                                        <th>Heading <span class="required">*</span></th>
                                        <td>&nbsp;</td>
                                        <th>Announcment Date<span class="required">*</span></th>
                                        <td>&nbsp;</td>
                                        <th>Expired On<span class="required">*</span></th>
                                        <td>&nbsp;</td>
                                        <th>Displayed On<span class="required">*</span></th>
                                        <td>&nbsp;</td>
                                        <th>Notice For<span class="required">*</span></th>
                                    </tr>
                                    <tr>

                                        <td>
                                            <asp:TextBox ID="txtHeading" runat="server" Width="338px"></asp:TextBox></td>
                                        <td>
                                            <asp:TextBox ID="txtAnnDate" runat="server"></asp:TextBox></td>
                                        <td>
                                            <asp:TextBox ID="txtExpire" runat="server"></asp:TextBox></td>
                                        <td>
                                            <asp:DropDownList ID="ddlNoticeDisplay" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlNoticeDisplay_SelectedIndexChanged">
                                            </asp:DropDownList></td>
                                        <td>
                                            <asp:DropDownList ID="ddlNotice" runat="server"></asp:DropDownList><ajaxToolkit:CalendarExtender ID="CalendarExtender1" Format="dd/MM/yyyy" runat="server" TargetControlID="txtAnnDate" Enabled="True"></ajaxToolkit:CalendarExtender>
                                            <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender1" runat="server" TargetControlID="txtAnnDate" Mask="99/99/9999"
                                                MaskType="Date">
                                            </ajaxToolkit:MaskedEditExtender>
                                            <ajaxToolkit:CalendarExtender ID="CalendarExtender2" Format="dd/MM/yyyy" runat="server" TargetControlID="txtExpire" Enabled="True"></ajaxToolkit:CalendarExtender>
                                            <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender2" runat="server" TargetControlID="txtExpire" Mask="99/99/9999"
                                                MaskType="Date">
                                            </ajaxToolkit:MaskedEditExtender>
                                        </td>
                                    </tr>
                                </table>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                   </div>
              <div>
                        <table>
                            <tr>
                                <th>File Upload Type</th>
                                <td>&nbsp;</td>
                                <th>Upload File</th>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:DropDownList ID="ddlUploadType" runat="server"></asp:DropDownList></td>
                                <td>&nbsp;</td>
                                <td>
                                    <asp:FileUpload ID="txtView" runat="server" /></td>
                                <td>&nbsp;</td>
                                <td>
                                    <asp:Button ID="btnAdd" runat="server" Text="Add" OnClick="btnAdd_Click" />
                                    <asp:TextBox ID="TextBox1" runat="server" Visible="false"></asp:TextBox>
                                </td>
                            </tr>
                        </table>
                   </div>
              <div>
                        <asp:GridView ID="gvAdd" runat="server" AutoGenerateColumns="false" CssClass="gridDynamic" OnRowDeleting="gvAdd_RowDeleting">
                            <Columns>
                                <asp:TemplateField HeaderText="S.No">
                                    <ItemTemplate>
                                        <%#((GridViewRow)Container).RowIndex +1 %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField HeaderText="File Type" DataField="TYPE_VALUE" />
                                <asp:BoundField HeaderText="File" DataField="FILE_PATH" />
                                <asp:CommandField ShowDeleteButton="true" />
                            </Columns>
                        </asp:GridView>
                  </div>
            <div>
                        <table>
                            <tr>
                                <th>Description<span class="required">*</span></th>
                                <td>
                                    <asp:TextBox ID="txtDesc" runat="server" TextMode="MultiLine" Width="300px" Height="79px"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td></td>
                                <td>

                                    <asp:Button ID="btnSave" runat="server" OnClick="btnSave_Click" Text="Save" />
                                </td>
                            </tr>
                        </table>
                  </div>

                <tr>
                    <td>
                        <asp:GridView ID="gvNotice" runat="server" AutoGenerateColumns="false" CssClass="gridDynamic" DataKeyNames="NEWS_ID,FILE_ID" OnRowCommand="gvNotice_RowCommand">
                            <Columns>
                                <asp:TemplateField HeaderText="S.No">
                                    <ItemTemplate>
                                        <%#((GridViewRow)Container).RowIndex +1 %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField HeaderText="Notice Date" DataField="NEWS_DT" />
                                <asp:BoundField HeaderText="Notice Heading" DataField="NEWS_HEADING" />
                                <asp:BoundField HeaderText="Notice For" DataField="NOTICE_TYPE_VALUE" />
                                <asp:BoundField HeaderText="Upload Doc Type" DataField="TYPE_VALUE" />
                                <asp:BoundField HeaderText="File Path" DataField="FILE_PATH" />
                                <%--<asp:CommandField ButtonType="Image" SelectImageUrl="~/Siteimages/edit.gif" ShowSelectButton="True" HeaderText="Modify">
                                            <ItemStyle Width="40px" />
                                        </asp:CommandField>--%>
                                <%--<asp:TemplateField ShowHeader="False" HeaderText="Status">
                                            <ItemStyle Width="20px" HorizontalAlign="Right" />
                                            <ItemTemplate>
                                                <asp:ImageButton ID="ImageButton1" runat="server" CausesValidation="false" CommandArgument='<%# Bind("FILE_ID") %>'
                                                    ImageUrl='<%# Bind("STATUS_IMG") %>' CommandName='<%# Bind("STATUS_CMD") %>' ToolTip='<%# Bind("STATUS_TOOLTIP")%>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>--%>
                            </Columns>
                        </asp:GridView>
                    </td>
                </tr>

            </table>

        </div>
    </div>
</asp:Content>

