<%@ Page Title="ERP | Program Master" Language="C#" MasterPageFile="~/MasterPages/FullLength.master" AutoEventWireup="true" CodeFile="ProgramMain.aspx.cs" Inherits="Academic_ProgramMain" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script lang="javascript" type="text/javascript">
        function CheckControl(ctrl) {
            if (bTrim(document.getElementById(ctrl).value) == "" || bTrim(document.getElementById(ctrl).value) == "Select" || bTrim(document.getElementById(ctrl).value) == ".") {
                document.getElementById(ctrl).style.backgroundColor = "#fc6";
                return false;
            }
            else
                document.getElementById(ctrl).style.backgroundColor = "#fff";
            return true;
        }
        function validation() {

            var flag = true;
            var msg = "", ctrl = "";
            if (!CheckControl("<%=ddlInstitute.ClientID%>")) {
                msg += "- Select Institution from list\n";
                if (ctrl == "")
                    ctrl = "<%=ddlInstitute.ClientID%>";
                flag = false;
            }

            if (!CheckControl("<%=ddlProgramType.ClientID%>")) {
                msg += "- Select Program from list\n";
                if (ctrl == "")
                    ctrl = "<%=ddlProgramType.ClientID%>";
                flag = false;
            }


            if (!CheckControl("<%=ddlDegreeType.ClientID%>")) {
                msg += "- Select Degree from list\n";
                if (ctrl == "")
                    ctrl = "<%=ddlDegreeType.ClientID%>";
                flag = false;
            }
            if (!CheckControl("<%=txtDuration.ClientID%>")) {
                msg += "- Enter Duration \n";
                if (ctrl == "")
                    ctrl = "<%=txtDuration.ClientID%>";
                flag = false;
            }
            if (!CheckControl("<%=txtFulltName.ClientID%>")) {
                msg += "- Enter Course Name\n";
                if (ctrl == "")
                    ctrl = "<%=txtFulltName.ClientID%>";
                flag = false;
            }


            if (!CheckControl("<%=txtShortName.ClientID%>")) {
                msg += "- Enter Short Name of Course\n";
                if (ctrl == "")
                    ctrl = "<%=txtShortName.ClientID%>";
                flag = false;
            }
            if (msg != "") alert(msg);
            if (ctrl != "")
                document.getElementById(ctrl).focus();
            return flag;
        }

        function validate() {
            var flag = true;
            var msg = "", ctrl = "";
            if (!CheckControl("<%=ddlSingleDegree.ClientID%>")) {
                msg += "- Select Program from list\n";
                if (ctrl == "")
                    ctrl = "<%=ddlSingleDegree.ClientID%>";
                flag = false;
            }
            if (!CheckControl("<%=txtSemesterFrom.ClientID%>")) {
                msg += "- Enter Semester From Value\n";
                if (ctrl == "")
                    ctrl = "<%=txtSemesterFrom.ClientID%>";
                flag = false;
            }
            if (!CheckControl("<%=txtSemesterTo.ClientID%>")) {
                msg += "- Enter Semester To Value\n";
                if (ctrl == "")
                    ctrl = "<%=txtSemesterFrom.ClientID%>";
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
            <h2>Program Main</h2>
        </div>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <table>
                    <tr>
                        <td>
                            <table>
                                <tr>
                                    <th>Institute<span class="required">*</span></th>
                                    <th>Program Type<span class="required">*</span></th>
                                    <th>Degree Type<span class="required">*</span></th>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:DropDownList ID="ddlInstitute" runat="server" OnSelectedIndexChanged="ddlInstitute_SelectedIndexChanged" AutoPostBack="True">
                                        </asp:DropDownList></td>
                                    <td>
                                        <asp:DropDownList ID="ddlProgramType" runat="server" OnSelectedIndexChanged="ddlProgramType_SelectedIndexChanged" AutoPostBack="True">
                                        </asp:DropDownList></td>
                                    <td>
                                        <asp:DropDownList ID="ddlDegreeType" runat="server" OnSelectedIndexChanged="ddlDegree_SelectedIndexChanged" AutoPostBack="true">
                                        </asp:DropDownList></td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <table>
                                <tr>
                                    <th>Full Name<span class="required">*</span></th>
                                    <th>Short Name<span class="required">*</span></th>
                                    <th>Duration[In Months]<span class="required">*</span></th>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:TextBox ID="txtFulltName" runat="server" MaxLength="100"></asp:TextBox></td>
                                    <td>
                                        <asp:TextBox ID="txtShortName" runat="server" MaxLength="100"></asp:TextBox>
                                    </td>
                                    <td>
                                        <cc1:NumericTextBox ID="txtDuration" runat="server"></cc1:NumericTextBox></td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr id="trDegree" runat="server">
                        <td>
                            <table>
                                <tr>
                                    <th>Institute<span class="required">*</span></th>
                                    <th>Single Degree Program <span class="required">*</span></th>
                                    <th>Semester From<span class="required">*</span></th>
                                    <th>Semester To<span class="required">*</span></th>
                                </tr>
                                <tr>
                                     <td>
                                        <asp:DropDownList ID="ddlAttIns" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlAttIns_SelectedIndexChanged">
                                        </asp:DropDownList></td>
                                    <td>
                                        <asp:DropDownList ID="ddlSingleDegree" runat="server">
                                        </asp:DropDownList></td>
                                    <td>
                                        <cc1:NumericTextBox ID="txtSemesterFrom" runat="server"></cc1:NumericTextBox>
                                    </td>
                                    <td>
                                        <cc1:NumericTextBox ID="txtSemesterTo" runat="server"></cc1:NumericTextBox>
                                    </td>
                                    <td>
                                        <asp:Button ID="btnAddDegree" runat="server" Text="Add" OnClick="btnAddDegree_Click" /></td>
                                </tr>
                                <tr>
                                    <td colspan="7">
                                            <asp:GridView ID="grdSemShow" runat="server" AutoGenerateColumns="False" OnRowDeleting="grdSemShow_RowDeleting" Width="100%" EmptyDataText="No Record Avaliable" CssClass="gridDynamic">
                                            <Columns>
                                                <asp:TemplateField HeaderText="S.No.">
                                                    <ItemTemplate>
                                                        <%# ((GridViewRow)Container).RowIndex + 1%>
                                .
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:BoundField HeaderText="Attached Program" DataField="ATT_PRG_VALUE" />
                                                <asp:BoundField HeaderText="Semester Time" DataField="ACA_SEM_ID" />
                                                <asp:CommandField ButtonType="Image" DeleteImageUrl="~/Siteimages/delete.jpg" ShowDeleteButton="True" />
                                            </Columns>
                                        </asp:GridView>
                                    </td>
                                </tr>
                            </table>

                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: right;">
                            <asp:TextBox ID="txt2" runat="server" Visible="False"></asp:TextBox>
                            <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" /></td>
                    </tr>
                    <tr>
                        <td>
                            <div style="height:450px; overflow:scroll">
                            <asp:GridView ID="gvShow" runat="server" AutoGenerateColumns="False" DataKeyNames="INS_PGM_ID" OnRowCommand="gvShow_RowCommand" EmptyDataText="No Record Avaliable" CssClass="gridDynamic">
                                <Columns>
                                    <asp:TemplateField HeaderText="S.No.">
                                        <ItemTemplate>
                                            <%# ((GridViewRow)Container).RowIndex + 1%>
                                .
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField HeaderText="Course Name" DataField="PGM_FULL_NAME" />
                                    <asp:BoundField HeaderText="Short Name" DataField="PGM_SHORT_NAME" />
                                    <asp:BoundField HeaderText="Institute Name" DataField="INS_VALUE" />
                                    <asp:BoundField HeaderText="Duration" DataField="PGM_DURATION" />
                                    <asp:BoundField HeaderText="Program Type" DataField="PRG_TYPE_VALUE" />
                                    <asp:BoundField HeaderText="Degree Type" DataField="DRG_VALUE" />
                                    <asp:CommandField ButtonType="Image" SelectImageUrl="~/Siteimages/edit.gif" ShowSelectButton="True" HeaderText="Modify">
                                        <ItemStyle Width="40px" />
                                    </asp:CommandField>
                                    <asp:TemplateField ShowHeader="False" HeaderText="Status">
                                        <ItemStyle Width="20px" HorizontalAlign="Right" />
                                        <ItemTemplate>
                                            <asp:ImageButton ID="ImageButton1" runat="server" CausesValidation="false" CommandArgument='<%# Bind("INS_PGM_ID") %>'
                                                ImageUrl='<%# Bind("STS_IMG") %>' CommandName='<%# Bind("STS_CMD") %>' ToolTip='<%# Bind("STS_TOOLTIP")%>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                </Columns>
                            </asp:GridView>
                                </div>
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</asp:Content>

