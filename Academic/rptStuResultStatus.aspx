<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/FullLength.master" AutoEventWireup="true" CodeFile="rptStuResultStatus.aspx.cs" Inherits="Academic_rptStuResultStatus" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script type="text/javascript" lang="javascript">

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
            if (!CheckControl("<%=ddlCrsResultId.ClientID%>")) {
                msg += " * Select Result Status From List \n";
                if (ctrl == "")
                    ctrl = "<%=ddlCrsResultId.ClientID%>";
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
            if (!CheckControl("<%=rbtn.ClientID%>")) {
                msg += " * Choose Report Type \n";
                if (ctrl == "")
                    ctrl = "<%=rbtn.ClientID%>";
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
            <h2>Result Status</h2>
        </div>
        <div style="font-weight: bold">
            * This report show the back and detained detail student wise.<br />
            * To view the report you can either select full Detail and Counting Detail.<br />
            * In full report you get student detail with each paper code name and marks.<br />
            * In Counting report you get student wise back and detained paper counting.<br />
            * In care of credit check you can select the condition and enter credit point in free textbox.<br />
            * Credit only show the detail of grade base results.<br />
            * System automatically select students result only that results generated in grade evaluation basis.<br />
            * its applied once you enter credit in textbox or check credit checkbox's.
        </div>
        <div>

            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                <ContentTemplate>
                    <table id="tblColumns">

                        <tr>
                            <td>
                                <div style="float: left">
                                    <table style="margin: 0px; border: 0px;">
                                        <tr>
                                            <th>Institute<span class="required"></span></th>

                                            <th>Batch</th>

                                            <th>Programme</th>

                                            <th>Branch</th>

                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:DropDownList ID="ddlInstitute" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlInstitute_SelectedIndexChanged">
                                                </asp:DropDownList>
                                            </td>

                                            <td>
                                                <asp:DropDownList ID="ddlBatch" runat="server">
                                                </asp:DropDownList>
                                            </td>

                                            <td>
                                                <asp:DropDownList ID="ddlProgramm" runat="server" Width="150px" AutoPostBack="True" OnSelectedIndexChanged="ddlProgramm_SelectedIndexChanged">
                                                </asp:DropDownList>
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="ddlBranch" runat="server" Width="150px">
                                                </asp:DropDownList>
                                            </td>

                                        </tr>
                                        <tr>
                                            <th>Semester</th>
                                           <%-- <th colspan="3">Course</th>--%>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:DropDownList ID="ddlSemester" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlSemester_SelectedIndexChanged" Width="90px">
                                                </asp:DropDownList>
                                            </td>
                                            <%--<td colspan="3">
                                                <asp:DropDownList ID="ddlCourse" runat="server" AutoPostBack="True" Width="250px">
                                                </asp:DropDownList>
                                            </td>--%>
                                        </tr>
                                        <tr>
                                            <th>Subject Type</th>
                                            <th>Student Status</th>
                                            <div id="head" runat="server" visible="true">
                                                <th>Result Status</th>
                                            </div>
                                            <tr>
                                                <td>
                                                    <asp:DropDownList ID="ddlType" runat="server" AutoPostBack="true" Width="80px">
                                                        <asp:ListItem Value="2">All</asp:ListItem>
                                                        <asp:ListItem Value="1">Practical</asp:ListItem>
                                                        <asp:ListItem Value="0">Theory</asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>

                                                <td>
                                                    <asp:DropDownList ID="ddlStudentStatusId" runat="server" AutoPostBack="true" Width="80px">
                                                        <asp:ListItem Value="0">All</asp:ListItem>
                                                        <asp:ListItem Value="1">Normal</asp:ListItem>
                                                        <asp:ListItem Value="4">Fail</asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>

                                                <td id="res" runat="server" visible="true">
                                                    <asp:DropDownList ID="ddlCrsResultId" runat="server" AutoPostBack="true" Width="100px">
                                                        <asp:ListItem Value="">Select</asp:ListItem>
                                                        <asp:ListItem Value="1">Normal</asp:ListItem>
                                                        <asp:ListItem Value="2,3">Back+Detained</asp:ListItem>
                                                        <asp:ListItem Value="3">Detained</asp:ListItem>
                                                        <asp:ListItem Value="2">Back</asp:ListItem>
                                                        <asp:ListItem Value="3">Detained</asp:ListItem>
                                                        <asp:ListItem Value="4">Grace</asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>

                                            </tr>
                                        <tr>
                                            <th>Credit </th>
                                            <td>
                                                <asp:DropDownList ID="ddlCondition" runat="server" Width="120px">
                                                    <asp:ListItem Value="1">Equal To</asp:ListItem>
                                                    <asp:ListItem Value="2">Less Than</asp:ListItem>
                                                    <asp:ListItem Value="3">Greater Than</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                            <td>
                                                <cc1:NumericTextBox ID="txtCredit" runat="server" AllowDecimal="false" Width="100px">
                                                </cc1:NumericTextBox>
                                            </td>

                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:UpdateProgress ID="UpdateProgress1" runat="server" DynamicLayout="False">
                                                    <ProgressTemplate>
                                                        <img src="../images/25-1.gif" />
                                                        Loading....
                                                    </ProgressTemplate>
                                                </asp:UpdateProgress>
                                            </td>
                                        </tr>

                                    </table>
                                </div>
                                <div style="float: left">
                                    <table>

                                        <tr>
                                            <th>Fields </th>
                                        </tr>
                                        <tr>
                                            <th>Personal </th>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:CheckBoxList ID="ChPersonal1" runat="server" RepeatColumns="3">
                                                    <asp:ListItem Value="SV.SEM_ROLL_NO">Roll No</asp:ListItem>
                                                    <%--  <asp:ListItem Value="ESV.GEN_VALUE">Gender</asp:ListItem>--%>
                                                    <asp:ListItem Value="Convert(varchar,SV.DT_OF_BIRTH,103)">Date of Birth</asp:ListItem>
                                                    <asp:ListItem Value="SV.FATHER_NAME">Father Name</asp:ListItem>
                                                    <asp:ListItem Value="SV.MOTHER_NAME">Mother Name</asp:ListItem>
                                                    <asp:ListItem Value="SV.PHN_NO">Mobile No</asp:ListItem>
                                                    <asp:ListItem Value="SV.EMAIL">E-Mail ID</asp:ListItem>
                                                </asp:CheckBoxList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <th>Academic</th>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:CheckBoxList ID="ChAcademic1" runat="server" RepeatColumns="3">
                                                    <asp:ListItem Value="SV.INS_VALUE">Institution </asp:ListItem>
                                                    <asp:ListItem Value="SV.ACA_BATCH_NAME">Batch</asp:ListItem>
                                                    <asp:ListItem Value="SV.PGM_FULL_NAME">Programme</asp:ListItem>
                                                    <asp:ListItem Value="SV.BRN_SHORT_NAME">Branch</asp:ListItem>
                                                    <asp:ListItem Value="SV.ACA_SEM_ID">Semester</asp:ListItem>
                                                    <asp:ListItem Value="SV.ACA_SEC_NAME">Section</asp:ListItem>
                                                    <%--<asp:ListItem Value="SV.STU_STS_VALUE">Status</asp:ListItem>--%>

                                                </asp:CheckBoxList>

                                            </td>
                                        </tr>
                                        <tr>
                                            <th>Examination</th>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:CheckBoxList ID="ChExamination1" runat="server" RepeatColumns="3">
                                                    <asp:ListItem Value="SRSI.TOTAL_CREDIT">Total Credit</asp:ListItem>
                                                    <asp:ListItem Value="SRSI.TOTAL_CREDIT_EARN">Gain Credit</asp:ListItem>

                                                </asp:CheckBoxList>

                                            </td>
                                        </tr>
                                        <tr>
                                            <th>Select Report Type </th>
                                        </tr>
                                        <tr>

                                            <td>
                                                <asp:RadioButtonList ID="rbtn" runat="server" AutoPostBack="true" OnSelectedIndexChanged="rbtn_SelectedIndexChanged" RepeatDirection="Horizontal">

                                                    <asp:ListItem Value="0" Selected="True">Full Detail</asp:ListItem>
                                                    <asp:ListItem Value="1">Counting Detail</asp:ListItem>
                                                </asp:RadioButtonList>
                                            </td>

                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Button ID="btnView" runat="server" OnClick="btnView_Click" Text="View" />
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </td>
                        </tr>
                    </table>


                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>



</asp:Content>

