<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/FullLength.master" AutoEventWireup="true" CodeFile="MajorMarksUpdate.aspx.cs" Inherits="Academic_MajorMarksUpdate" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script lang="javascript" type="text/javascript">
        function CheckControl(ctrl) {
            if (bTrim(document.getElementById(ctrl).value) == "" || bTrim(document.getElementById(ctrl).value) == ".") {
                document.getElementById(ctrl).style.backgroundColor = "#fc6";
                return false;
            }
            else
                document.getElementById(ctrl).style.backgroundColor = "#fff";
            return true;
        }
        function CheckAutoComplete(ctrl) {

            var Value = bTrim(document.getElementById(ctrl).value);
            if (Value.indexOf(":") > 0 && Value.length - 1 != Value.lastIndexOf(":")) {
                document.getElementById(ctrl).style.backgroundColor = "#fff";
                return true;
            }
            else
                document.getElementById(ctrl).style.backgroundColor = "#fc6";
            return false;
        }
        function validation() {
            var flag = true;
            var msg = "", ctrl = "";
            if (!CheckControl("<%=ddlBranch.ClientID%>")) {
                msg += " * Select Branch \n";
                if (ctrl == "")
                    ctrl = "<%=ddlBranch.ClientID%>";
                flag = false;
            }
            if (!CheckControl("<%=ddlExam.ClientID%>")) {
                msg += " * Select Exam \n";
                if (ctrl == "")
                    ctrl = "<%=ddlExam.ClientID%>";
                flag = false;
            }
            if (!CheckControl("<%=ddlIns.ClientID%>")) {
                msg += " * Select Institute \n";
                if (ctrl == "")
                    ctrl = "<%=ddlIns.ClientID%>";
                flag = false;
            }
            if (!CheckControl("<%=ddlPaper.ClientID%>")) {
                msg += " * Select Paper \n";
                if (ctrl == "")
                    ctrl = "<%=ddlExam.ClientID%>";
                flag = false;
            }
            if (!CheckControl("<%=ddlPrgm.ClientID%>")) {
                msg += " * Select Program \n";
                if (ctrl == "")
                    ctrl = "<%=ddlPrgm.ClientID%>";
                flag = false;
            }
            if (!CheckControl("<%=ddlSem.ClientID%>")) {
                msg += " * Select Semester \n";
                if (ctrl == "")
                    ctrl = "<%=ddlSem.ClientID%>";
                flag = false;
            }
            if (msg != "") alert(msg);
            if (ctrl != "")
                document.getElementById(ctrl).focus();
            return flag;
        }


        function SaveValidation() {
            var flag = true;
            var msg = "", ctrl = "";
            if (!CheckControl("<%=ddlAward.ClientID%>")) {
                msg += " * Select Award No. \n";
                if (ctrl == "")
                    ctrl = "<%=ddlAward.ClientID%>";
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
            <h2>Update Major</h2>
        </div>
        <div>
            <table>
                <tr>
                    <td>


                        <table>
                            <tr>
                                <th>Examination</th>
                                <th>Institute
                                </th>
                                <th>Programme
                                </th>
                                <th>Branch
                                </th>
                                <th>Semester
                                </th>
                                <th>Paper Code
                                </th>
                            </tr>
                            <tr>
                                <td>
                                    <asp:DropDownList ID="ddlExam" runat="server"></asp:DropDownList>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlIns" runat="server" Width="100px" OnSelectedIndexChanged="ddlIns_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlPrgm" Width="100px" runat="server" OnSelectedIndexChanged="ddlPrgm_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlBranch" runat="server"></asp:DropDownList>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlSem" runat="server" OnSelectedIndexChanged="ddlSem_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlPaper" runat="server" Width="200px"></asp:DropDownList>
                                </td>

                                <td>
                                    <asp:Button ID="btnShow" runat="server" Text="Show" OnClick="btnShow_Click" />
                                </td>
                            </tr>

                            <tr>
                                <th>AwardList No.
                                </th>
                                <th id="thWeigtage" runat="server" visible="false">Weightage
                                </th>
                            </tr>
                            <tr>
                                <td>
                                    <asp:DropDownList ID="ddlAward" runat="server" OnSelectedIndexChanged="ddlAward_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                                </td>
                                <td id="tdWeigtage" runat="server" visible="false">
                                    <asp:RadioButtonList ID="rbWeightage" runat="server" RepeatDirection="Horizontal" CellPadding="0" CellSpacing="0" Width="80px">
                                        <asp:ListItem Text="100%" Value="100"></asp:ListItem>
                                        <asp:ListItem Text="80%" Value="80"></asp:ListItem>
                                        <asp:ListItem Text="50%" Value="50" Selected="True"></asp:ListItem>
                                    </asp:RadioButtonList>
                                </td>
                                <td>
                                    <asp:Button ID="btnUpdate" runat="server" Text="Update Weightage" OnClick="btnUpdate_Click" />
                                </td>
                            </tr>

                        </table>
                    </td>
                </tr>
                <tr>
                    <td>
                        <div>
                            <asp:GridView ID="gvMarks" runat="server" AutoGenerateColumns="False" EmptyDataText="No Record Found" DataKeyNames="MEM_ID,MEM_SUB_ID"
                                CssClass="gridDynamic" OnRowCancelingEdit="gvMarks_RowCancelingEdit" OnRowEditing="gvMarks_RowEditing" OnRowUpdating="gvMarks_RowUpdating">
                                <Columns>
                                    <asp:TemplateField HeaderText="S.No.">
                                        <ItemTemplate>
                                            <%# ((GridViewRow)Container).RowIndex + 1%>
                                        </ItemTemplate>
                                        <ItemStyle Width="20px" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Enrollment No.">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txtEnroll" runat="server" Text='<%#Eval("ENROLLMENT_NO") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblEnroll" runat="server" Text='<%#Eval("ENROLLMENT_NO") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Marks">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txtMarks" runat="server" Text='<%#Eval("MARKS") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblMarks" runat="server" Text='<%#Eval("MARKS") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="MEM_W_MARKS" HeaderText="Weightage" ReadOnly="true" />

                                    <asp:CommandField ShowEditButton="True" ButtonType="Button" HeaderText="Update">
                                        <ControlStyle CssClass="btnblue" />
                                    </asp:CommandField>
                                </Columns>
                            </asp:GridView>
                        </div>
                    </td>
                </tr>

            </table>
        </div>
    </div>
</asp:Content>

