<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/FullLength.master" AutoEventWireup="true" CodeFile="InternalMarksExam.aspx.cs" Inherits="Academic_InternalMarksExam" %>

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
        function validation() {
            var flag = true;
            var msg = "", ctrl = "";



            if (!CheckControl("<%=ddlBatch.ClientID%>")) {
                msg += " * Select batch. \n";
                if (ctrl == "")
                    ctrl = "<%=ddlBatch.ClientID%>";
                flag = false;
            }
            if (!CheckControl("<%=ddlSemester.ClientID%>")) {
                msg += " * Select semster. \n";
                if (ctrl == "")
                    ctrl = "<%=ddlSemester.ClientID%>";
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
            <h2>Print Internal Marks</h2>
        </div>

        <table>
            <tr>
                <th>Institution<span style="color: red">*</span></th>
                <th>Course<span style="color: red">*</span></th>
                <th>Batch<span style="color: red">*</span></th>
                <th>Branch<span style="color: red">*</span></th>
                <th>Semester<span style="color: red">*</span></th>

            </tr>
            <tr>
                <td>
                    <asp:DropDownList ID="ddlInstitution" runat="server" Width="80px" OnSelectedIndexChanged="ddlInstitution_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList>
                </td>
                <td>
                    <asp:DropDownList ID="ddlCourse" runat="server" Width="153px" OnSelectedIndexChanged="ddlCourse_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList>
                </td>
                <td>
                    <asp:DropDownList ID="ddlBatch" runat="server" Width="156px" AutoPostBack="True"></asp:DropDownList>
                </td>
                <td>
                    <asp:DropDownList ID="ddlBranch" runat="server" Width="156px" AutoPostBack="True"></asp:DropDownList>
                </td>
                <td>
                    <asp:DropDownList ID="ddlSemester" runat="server" Width="60px"></asp:DropDownList>
                </td>
                <td>
                    <asp:Button ID="btnShow" runat="server" Text="Show" CssClass="btnBrown" OnClick="btnShow_Click" />

                </td>
            </tr>
        </table>
        <table>
            <tr>
                <td>
                    <asp:GridView ID="gvShow" runat="server" CssClass="gridDynamic" AutoGenerateColumns="False" DataKeyNames="TT_ID,GRP_ID" EmptyDataText="No Record Avaliable" OnRowCommand="gvShow_RowCommand">
                        <Columns>
                            <asp:TemplateField HeaderText="S.NO.">
                                <ItemTemplate>
                                    <%# ((GridViewRow)Container).RowIndex + 1%>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="COURSE_CODE" HeaderText="COURSE CODE" />
                            <asp:BoundField DataField="ACA_SUB_NAME" HeaderText="SUBJECT NAME" />
                            <asp:BoundField DataField="ACA_SEM_NO" HeaderText="SEM" />
                            <asp:BoundField DataField="ACA_SEC_NAME" HeaderText="SECTION " />
                            <asp:BoundField DataField="GRP_VALUE" HeaderText="GROUP" />
                            <asp:BoundField DataField="EMP_ID" HeaderText="FACULTY CODE " />
                            <asp:BoundField DataField="EMP_NAME" HeaderText="FACULTY NAME" />
                            <asp:ButtonField ButtonType="Button" CommandName="Print" HeaderText="PRINT" Text="PRINT" />
                        </Columns>
                    </asp:GridView>
                </td>
            </tr>
        </table>


    </div>
</asp:Content>

