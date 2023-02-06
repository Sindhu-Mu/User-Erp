
<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/FullLength.master" AutoEventWireup="true" CodeFile="DetainedRegisteredList.aspx.cs" Inherits="Academic_DetainedRegisteredList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script lang="javascript" type="text/javascript">
        function show_confirm() {
            var r = confirm("You have decided to mark the entries as final. You won't be able any further changes. Do you wish to continue?");
            if (r == true) {
                return true;
            }
            else {
                return false;
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
        function CheckControl(ctrl) {
            if (bTrim(document.getElementById(ctrl).value) == "" || bTrim(document.getElementById(ctrl).value) == "-1") {
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


            if (!CheckControl("<%=ddlExamination.ClientID%>")) {
                msg += "- Please Select Examination \n";
                if (ctrl == "")
                    ctrl = "<%=ddlExamination.ClientID%>";
                flag = false;
            }


            if (!CheckControl("<%=ddlInstitution.ClientID%>")) {
                msg += "- Please Select Institution \n";
                if (ctrl == "")
                    ctrl = "<%=ddlInstitution.ClientID%>";
                 flag = false;
             }

             if (!CheckControl("<%=ddlProgram.ClientID%>")) {
                msg += "- Please Select Program \n";
                if (ctrl == "")
                    ctrl = "<%=ddlProgram.ClientID%>";
                 flag = false;
             }
             if (!CheckControl("<%=ddlBranch.ClientID%>")) {
                msg += "- Please Select Branch \n";
                if (ctrl == "")
                    ctrl = "<%=ddlBranch.ClientID%>";
                flag = false;
            }
            if (!CheckControl("<%=ddlSem.ClientID%>")) {
                msg += "- Please Select Semester \n";
                if (ctrl == "")
                    ctrl = "<%=ddlSem.ClientID%>";
                flag = false;
            }
            if (!CheckControl("<%=ddlDetained.ClientID%>")) {
                msg += "- Please Select Paper code \n";
                if (ctrl == "")
                    ctrl = "<%=ddlDetained.ClientID%>";
                flag = false;
            }

            if (msg != "") alert(msg);
            if (ctrl != "")
                document.getElementById(ctrl).focus();
            return flag;
        }
    </script>
    <div>
        <table>
            <tr>
                <th>Examination<span style="color: red">*</span></th>
                <th>Institution<span style="color: red">*</span></th>
                <th style="padding-left: 20px;">Program<span style="color: red;">*</span></th>
                <th>Branch<span style="color: red">*</span></th>
                <th>Sem<span style="color: red">*</span></th>
                <th>Paper<span style="color: red">*</span></th>
            </tr>
            <tr>
                <td>
                    <asp:DropDownList ID="ddlExamination" runat="server" Width="200px"></asp:DropDownList>
                </td>
                <td>
                    <asp:DropDownList ID="ddlInstitution" runat="server" Width="80px" OnSelectedIndexChanged="ddlInstitution_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList>
                </td>
                <td>
                    <asp:DropDownList ID="ddlProgram" runat="server" Width="160px" OnSelectedIndexChanged="ddlProgram_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList>
                </td>
                <td>
                    <asp:DropDownList ID="ddlBranch" runat="server" Width="160px" OnSelectedIndexChanged="ddlBranch_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList>
                </td>
                <td>
                    <asp:DropDownList ID="ddlSem" runat="server" Width="80px" OnSelectedIndexChanged="ddlSem_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList>
                </td>
                <td>
                    <asp:DropDownList ID="ddlDetained" runat="server" Width="160px" OnSelectedIndexChanged="ddlDetained_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList>
                </td>
            </tr>

        </table>
        <table style="min-width: 400px;">
            <tr>
                <td colspan="2">
                    <asp:GridView ID="gvDetained" runat="server" AutoGenerateColumns="false" CssClass="gridDynamic" DataKeyNames="STU_MAIN_ID,CRS_PAPER_ID">
                        <Columns>
                            <asp:TemplateField HeaderText="S.No.">
                                <ItemTemplate>
                                    <%# ((GridViewRow)Container).RowIndex + 1%>.
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="ENROLLMENT_NO" HeaderText="Enroll No." />
                            <asp:BoundField DataField="STU_FULL_NAME" HeaderText="Name" />
                            <asp:TemplateField HeaderText="minor1">
                                <ItemTemplate>
                                    <cc1:NumericTextBox ID="txtminor1" runat="server" AllowDecimal="true" AllowNegative="false" MaxLength="4" DecimalPlaces="1" AutoCompleteType="None" Width="80px"></cc1:NumericTextBox>

                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Minor2">
                                <ItemTemplate>
                                    <cc1:NumericTextBox ID="txtminor2" runat="server" AllowDecimal="true" AllowNegative="false" MaxLength="4" DecimalPlaces="1" AutoCompleteType="None" Width="80px"></cc1:NumericTextBox>

                                </ItemTemplate>
                                <ItemStyle Width="10px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Class Performance">
                                <ItemTemplate>
                                    <cc1:NumericTextBox ID="txtClassPerfo" runat="server" AllowDecimal="true" AllowNegative="false" MaxLength="4" DecimalPlaces="1" AutoCompleteType="None" Width="80px"></cc1:NumericTextBox>

                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Total Class">
                                <ItemTemplate>
                                    <cc1:NumericTextBox ID="txtTotlAttend" runat="server" AllowDecimal="true" AllowNegative="false" MaxLength="4" DecimalPlaces="1" AutoCompleteType="None" Width="80px"></cc1:NumericTextBox>

                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Present">
                                <ItemTemplate>
                                    <cc1:NumericTextBox ID="txtAttended" runat="server" AllowDecimal="true" AllowNegative="false" MaxLength="4" DecimalPlaces="1" AutoCompleteType="None" Width="80px"></cc1:NumericTextBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                              <asp:TemplateField HeaderText="Marks">
                                <ItemTemplate>
                                    <cc1:NumericTextBox ID="txtAttMarks" runat="server" AllowDecimal="true" AllowNegative="false" MaxLength="4" DecimalPlaces="1" AutoCompleteType="None" Width="80px"></cc1:NumericTextBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Select">
                                <ItemTemplate>
                                    <asp:CheckBox ID="chkSelect" runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>

                </td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" OnClientClick="show_confirm()" />
                </td>
                <td>
                    <asp:Button ID="btnPrint" runat="server" Text="Print" OnClick="btnPrint_Click" /></td>

            </tr>
            <tr>
                <td colspan="2">

                    <asp:GridView ID="GvDetainPaper" runat="server" AutoGenerateColumns="false" EmptyDataText="No record found" CssClass="gridDynamic" DataKeyNames="CRS_CODE,EXAM_ID">
                        <Columns>
                            <asp:TemplateField HeaderText="S.No.">
                                <ItemTemplate>
                                    <%# ((GridViewRow)Container).RowIndex + 1%>
                                .
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:BoundField DataField="EXAM_NAME" HeaderStyle-Width="250px" HeaderText="Exam" />

                            <asp:BoundField DataField="CRS_CODE" HeaderText="Paper Code" />
                            <asp:HyperLinkField DataNavigateUrlFields="CRS_CODE,EXAM_ID" Text="Re-Print"
                                DataNavigateUrlFormatString="~/Academic/PrtDetainedMarksList.aspx?CRS_CODE={0}&EXAM_ID={1}" HeaderText="Print Marks"
                                NavigateUrl="~/Academic/PrtDetainedMarksList.aspx" Target="_blank,fullscreen=yes" />

                        </Columns>
                    </asp:GridView>
                </td>
            </tr>
        </table>
    </div>


</asp:Content>

