<%@ Page Title="ERP | Branch Master" Language="C#" MasterPageFile="~/MasterPages/FullLength.master" AutoEventWireup="true" CodeFile="BranchMain.aspx.cs" Inherits="Academic_BranchMain" %>

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
                flag = false; 9
            }
            if (!CheckControl("<%=ddlCourse.ClientID%>")) {
                msg += "- Select Program Name from list\n";
                if (ctrl == "")
                    ctrl = "<%=ddlCourse.ClientID%>";
                flag = false;
            }
            if (!CheckControl("<%=txtBranchName.ClientID%>")) {
                msg += "- Enter Branch Name\n";
                if (ctrl == "")
                    ctrl = "<%=txtBranchName.ClientID%>";
                flag = false;
            }
            if (!CheckControl("<%=txtShortName.ClientID%>")) {
                msg += "- Enter Short Name of Course\n";
                if (ctrl == "")
                    ctrl = "<%=txtShortName.ClientID%>";
                flag = false;
            }


            if (!CheckControl("<%=txtCapacity.ClientID%>")) {
                msg += "- Enter Capacity of this Branch\n";
                if (ctrl == "")
                    ctrl = "<%=txtCapacity.ClientID%>";
                flag = false;
            }
            if (!CheckControl("<%=ddlSemester.ClientID%>")) {
                msg += "- Select Semester Type from list\n";
                if (ctrl == "")
                    ctrl = "<%=ddlSemester.ClientID%>";
                flag = false;
            }

            if (!CheckControl("<%=txtRollFormate.ClientID%>")) {
                msg += "- Enter Roll Formate of this Branch\n";
                if (ctrl == "")
                    ctrl = "<%=txtRollFormate.ClientID%>";
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
            <h2>Branch Master</h2>
        </div>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <table>
                    <tr>
                        <td>
                            <table>
                                <tr>
                                    <th>&nbsp;Institute Name
                <span class="required">*</span></th>

                                    <th>Program Name
                <span class="required">*</span></th>
                                    <th>Full Name <span class="required">*</span></th>
                                    <th>Short Name <span class="required">*</span></th>

                                </tr>

                                <tr>
                                    <td>
                                        <asp:DropDownList ID="ddlInstitute" runat="server" Width="200px" OnSelectedIndexChanged="ddlInstitute_SelectedIndexChanged" AutoPostBack="true">
                                        </asp:DropDownList></td>
                                    <td>
                                        <asp:DropDownList ID="ddlCourse" runat="server" Width="200px"></asp:DropDownList></td>
                                    <td>
                                        <asp:TextBox ID="txtBranchName" runat="server" Width="150px" CssClass="textbox"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtShortName" runat="server" Width="115px" CssClass="textbox"></asp:TextBox>
                                    </td>
                                    <%--  <td>&nbsp;<cc1:NumericTextBox ID="txtDuration" runat="server" Width="115px"></cc1:NumericTextBox></td>--%>
                                </tr>

                                <tr>
                                    <th>Capacity <span class="required">*</span></th>
                                    <th>Semester Type <span class="required">*</span></th>
                                    <th>Roll Format <span class="required">*</span></th>
                                </tr>
                                <tr>
                                    <td>
                                        <cc1:NumericTextBox ID="txtCapacity" runat="server" Width="150px"></cc1:NumericTextBox>
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="ddlSemester" runat="server" Width="200px">
                                        </asp:DropDownList>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtRollFormate" runat="server" Width="150px" CssClass="textbox" MaxLength="3"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:Button ID="btnSave" runat="server" Text="Save" Width="70px" OnClick="btnSave_Click1" Height="25px" /></td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td>
                             <div style="height:450px; overflow:scroll">
                            <asp:GridView ID="gvShow" runat="server" AutoGenerateColumns="False" DataKeyNames="PGM_BRN_ID" OnRowCommand="gvShow_RowCommand" Width="100%" EmptyDataText="No Record Avaliable" CssClass="gridDynamic">
                                <Columns>
                                    <asp:TemplateField HeaderText="S.No.">
                                        <ItemTemplate>
                                            <%# ((GridViewRow)Container).RowIndex + 1%>
                                .
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField HeaderText="Course Name" DataField="PGM_FULL_NAME" />
                                    <asp:BoundField HeaderText="Branch Name" DataField="BRN_FULL_NAME" />
                                    <asp:BoundField HeaderText="Institute Name" DataField="INS_VALUE" />
                                    <asp:BoundField HeaderText="Branch Short Name" DataField="BRN_SHORT_NAME" />
                                    <asp:BoundField HeaderText="Roll Format" DataField="BRN_ROLL_TYPE" />
                                    <asp:CommandField ButtonType="Image" SelectImageUrl="~/Siteimages/edit.gif" ShowSelectButton="True" HeaderText="Modify">
                                        <ItemStyle Width="40px" />
                                    </asp:CommandField>
                                    <asp:TemplateField ShowHeader="False" HeaderText="Status">
                                        <ItemStyle Width="20px" HorizontalAlign="Right" />
                                        <ItemTemplate>
                                            <asp:ImageButton ID="ImageButton1" runat="server" CausesValidation="false" CommandArgument='<%# Bind("PGM_BRN_ID") %>'
                                                ImageUrl='<%# Bind("STS_IMG") %>' CommandName='<%# Bind("STS_CMD") %>' ToolTip='<%# Bind("STS_TOOLTIP")%>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                                 </div>
                        </td>
                    </tr></table>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</asp:Content>

