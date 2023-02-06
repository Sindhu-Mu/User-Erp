<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/FullLength.master" AutoEventWireup="true" CodeFile="StuMarksUpdate.aspx.cs" Inherits="Academic_StuMarksUpdate" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script lang="javascript" type="text/javascript">
        function SelectAllCheckboxes(spanChk) {


            var oItem = spanChk.children;
            var theBox = (spanChk.type == "checkbox") ?
                spanChk : spanChk.children.item[0];
            xState = theBox.checked;
            elm = theBox.form.elements;

            for (i = 0; i < elm.length; i++)
                if (elm[i].type == "checkbox" &&
                         elm[i].id != theBox.id) {

                    if (elm[i].checked != xState)
                        elm[i].click();

                }

        }


        function CheckControl(ctrl) {
            if (bTrim(document.getElementById(ctrl).value) == "." || bTrim(document.getElementById(ctrl).value) == "Select") {
                document.getElementById(ctrl).style.backgroundColor = "#fc6";
                return false;
            }
            else
                document.getElementById(ctrl).style.backgroundColor = "#fff";
            return true;

        }
        function validat() {

            var flag = true;
            var msg = "", ctrl = "";
            if (!CheckControl("<%=ddlDept.ClientID%>")) {
                msg += "Select Department from List\n";
                if (ctrl == "")
                    ctrl = "<%=ddlDept.ClientID%>";
                flag = false;
            }
            if (!CheckControl("<%=ddlPgm.ClientID%>")) {
                msg += "Select Program from List\n";
                if (ctrl == "")
                    ctrl = "<%=ddlPgm.ClientID%>";
                flag = false;
            }
            if (!CheckControl("<%=ddlBrnch.ClientID%>")) {
                msg += "Select Branch from List\n";
                if (ctrl == "")
                    ctrl = "<%=ddlBrnch.ClientID%>";
                flag = false;
            }
            if (!CheckControl("<%=ddlFac.ClientID%>")) {
                msg += "Select Faculty from List\n";
                if (ctrl == "")
                    ctrl = "<%=ddlFac.ClientID%>";
                flag = false;
            }
            if (!CheckControl("<%=ddlPaper.ClientID%>")) {
                msg += "Select Paper from List\n";
                if (ctrl == "")
                    ctrl = "<%=ddlPaper.ClientID%>";
                flag = false;
            }
            if (!CheckControl("<%=ddlExam.ClientID%>")) {
                msg += "Select Exam Type from List\n";
                if (ctrl == "")
                    ctrl = "<%=ddlExam.ClientID%>";
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
            <h2>Update Marks
            </h2>
        </div>
        <div>
            <table>
                <tr>
                    <td>
                        <table>
                            <tr>

                                <th>Department<span class="required">*</span>
                                </th>
                                <th>Program<span class="required">*</span>
                                </th>
                                <th>Branch<span class="required">*</span>
                                </th>
                                <th>Faculty<span class="required">*</span>
                                </th>
                                <th>Paper Code<span class="required">*</span>
                                </th>
                                <th>Exam<span class="required">*</span>
                                </th>
                            </tr>
                            <tr>

                                <td>
                                    <asp:DropDownList ID="ddlDept" runat="server" OnSelectedIndexChanged="ddlDept_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlPgm" runat="server" OnSelectedIndexChanged="ddlPgm_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlBrnch" runat="server" OnSelectedIndexChanged="ddlBrnch_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlFac" runat="server" OnSelectedIndexChanged="ddlFac_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlPaper" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlPaper_SelectedIndexChanged"></asp:DropDownList>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlExam" runat="server"></asp:DropDownList>
                                </td>
                                <td>
                                    <asp:Button ID="btnShow" runat="server" Text="Show" OnClick="btnShow_Click" />
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>

                <tr>
                    <td>
                        <asp:GridView ID="gvDetail" runat="server" AutoGenerateColumns="false" DataKeyNames="TT_PAP_ID,INT_ATT_STS,STU_MAIN_ID,EXAM_TYPE_SUB_ID" OnRowCancelingEdit="gvDetail_RowCancelingEdit" OnRowEditing="gvDetail_RowEditing" OnRowUpdating="gvDetail_RowUpdating" CssClass="gridDynamic">
                            <Columns>
                                <asp:TemplateField HeaderText="S.No.">
                                    <ItemTemplate>
                                        <%# ((GridViewRow)Container).RowIndex + 1%>.
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField HeaderText="Enrollment" DataField="ENROLLMENT_NO" />
                                <asp:BoundField HeaderText="Name" DataField="STU_FULL_NAME" />
                                <asp:TemplateField HeaderText="Attendance">
                                    <ItemTemplate>
                                        <asp:RadioButtonList ID="rblAtt" runat="server" RepeatDirection="Horizontal">
                                            <asp:ListItem Text="Absent" Value="False"></asp:ListItem>
                                            <asp:ListItem Text="Present" Value="True"></asp:ListItem>
                                        </asp:RadioButtonList>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Marks">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txtMarks" runat="server" Text='<%#Eval("INT_MARKS") %>'></asp:TextBox>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblMarks" runat="server" Text='<%#Eval("INT_MARKS") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:CommandField ShowEditButton="True" ButtonType="Button" HeaderText="Update">
                                    <ControlStyle CssClass="btnblue" />
                                </asp:CommandField>
                                <%-- <asp:TemplateField HeaderText="All">
                                    <HeaderTemplate>
                                        <input id="chkAll" onclick="javascript: SelectAllCheckboxes(this);" type="checkbox"
                                            value="on" runat="server" style="border-right: blue 2px groove; border-top: blue 2px groove; border-left: blue 2px groove; border-bottom: blue 2px groove" />
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:CheckBox ID="CHK_SelectAll" runat="server" />
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

