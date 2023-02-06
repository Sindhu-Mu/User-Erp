<%@ Page Title="ERP|Internal Marks" Language="C#" MasterPageFile="~/MasterPages/FullLength.master" AutoEventWireup="true" CodeFile="InternalMarks.aspx.cs" Inherits="Academic_InternalMarks" %>

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
        function doPrint() {
            var prtContent = document.getElementById('<%= divStudent.ClientID %>');
            prtContent.border = 1;
            var WinPrint = window.open('', '', 'left=100,top=100,width=1000,height=1000,toolbar=0,scrollbars=1,status=0,resizable=1');
            WinPrint.document.write(prtContent.outerHTML);
            WinPrint.document.close();
            WinPrint.focus();
            oncontextmenu = "return false"; ondragstart = "return false"; onselectstart = "return false";
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
            if (!CheckControl("<%=ddlExamination.ClientID%>")) {
                msg += "Select valid Exam Type from List\n";
                if (ctrl == "")
                    ctrl = "<%=ddlExamination.ClientID%>";
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
            <h2>Internal Marks</h2>
        </div>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <ajaxToolkit:TabContainer ID="step1" runat="server" ActiveTabIndex="1">
                    <ajaxToolkit:TabPanel runat="server" HeaderText="Choose Paper" ID="TabPanel1">
                        <ContentTemplate>
                            <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                <ContentTemplate>
                                    <div>
                                        <asp:GridView ID="gvShow" runat="server" SelectedRowStyle-BackColor="Yellow" CssClass="gridDynamic" AutoGenerateColumns="False" DataKeyNames="TT_ID,GRP_ID" EmptyDataText="No Record Avaliable" OnRowCommand="gvShow_RowCommand">
                                            <Columns>
                                                <asp:TemplateField HeaderText="S.No.">
                                                    <ItemTemplate>
                                                        <%# ((GridViewRow)Container).RowIndex + 1%>.
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:BoundField DataField="Course_Code" HeaderText="COURSE CODE" />
                                                <asp:BoundField DataField="ACA_SEM_NO" HeaderText="SEM" />
                                                <asp:BoundField DataField="ACA_SEC_NAME" HeaderText="SECTION " />
                                                <asp:BoundField DataField="GRP_VALUE" HeaderText="GROUP" />
                                                <asp:CommandField ButtonType="Button" HeaderText="Select" ShowSelectButton="True" />
                                                <asp:ButtonField ButtonType="Button" CommandName="Print" HeaderText="PRINT" Text="PRINT" />
                                            </Columns>
                                        </asp:GridView>
                                    </div>
                                    <div id="DivDownload" runat="server" visible="false">
                                        
                                    </div>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </ContentTemplate>
                    </ajaxToolkit:TabPanel>
                    <ajaxToolkit:TabPanel runat="server" HeaderText="Insert Marks" ID="TabPanel2">
                        <ContentTemplate>
                            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                <ContentTemplate>

                                    <table>
                                        <tr>
                                            <td>


                                                <table>
                                                    <tr>
                                                        <th>Course Code</th>
                                                        <td>&nbsp;</td>
                                                        <th>Examination Name </th>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblCourseCode1" runat="server" Font-Bold="true" Text="Label"></asp:Label></td>
                                                        <td>&nbsp;</td>

                                                        <td>
                                                            <asp:DropDownList ID="ddlExamination" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlExamination_SelectedIndexChanged"></asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>

                                                <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                                                    <ContentTemplate>
                                                        <asp:Label ID="lblMaxMark" runat="server" Font-Bold="true" ForeColor="Red"></asp:Label>
                                                        <div id="divStudent" runat="server" style="overflow: auto; height: 450px; width: 100%;">
                                                            <asp:GridView ID="gridStudent" CssClass="gridDynamic" Caption="Student List" runat="server" AutoGenerateColumns="False"
                                                                DataKeyNames="TT_PAP_ID,STU_MAIN_ID">
                                                                <Columns>
                                                                    <asp:TemplateField HeaderText="S.No.">
                                                                        <ItemTemplate>
                                                                            <%# ((GridViewRow)Container).RowIndex + 1%>
                                                                        </ItemTemplate>
                                                                        <ItemStyle Width="20px" />
                                                                    </asp:TemplateField>
                                                                    <asp:BoundField HeaderText="Enrollment No." DataField="ENROLLMENT_NO" />
                                                                    <asp:BoundField HeaderText="Name" DataField="STU_FULL_NAME" />
                                                                    <asp:TemplateField HeaderText="Marks" ItemStyle-Width="200px">
                                                                        <ItemTemplate>
                                                                            <cc1:NumericTextBox ID="txtMarks" runat="server" AllowDecimal="true" AllowNegative="false" MaxLength="4" DecimalPlaces="1" AutoCompleteType="None" Width="80px" placeholder="Marks"></cc1:NumericTextBox>
                                                                            <asp:RangeValidator ID="rgvDob" runat="server" ErrorMessage="Invalid Marks" Type="Double" ControlToValidate="txtMarks" ForeColor="Red" MaximumValue='<%# Eval("EXAM_MAX_MARKS") %>' MinimumValue="0" SetFocusOnError="True" EnableClientScript="false"></asp:RangeValidator>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Attendance">
                                                                        <ItemTemplate>
                                                                            <asp:RadioButtonList ID="AttList" Width="150px" runat="server" CellPadding="0" CellSpacing="0" RepeatDirection="Horizontal" OnSelectedIndexChanged="AttList_SelectedIndexChanged">
                                                                                <asp:ListItem Selected="True" Value="1">Present</asp:ListItem>
                                                                                <asp:ListItem Value="0">Absent</asp:ListItem>
                                                                            </asp:RadioButtonList>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                </Columns>
                                                            </asp:GridView>
                                                        </div>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="text-align: right;">

                                                <asp:Button ID="btnVerify" runat="server" Text="Verify Entry" OnClick="btnVerify_Click" />&nbsp;
                                                <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" OnClientClick="show_confirm()" /></td>
                                        </tr>
                                    </table>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </ContentTemplate>
                    </ajaxToolkit:TabPanel>
                    <ajaxToolkit:TabPanel runat="server" HeaderText="Marks Inserted" ID="TabPanel3">
                        <ContentTemplate>
                            <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                                <ContentTemplate>
                                    <table>
                                        <tr>
                                            <td>
                                                <table>
                                                    <tr>
                                                        <th>Course Code</th>
                                                        <td>&nbsp;</td>
                                                        <th>Examination Name </th>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblCourseCode2" runat="server" Font-Bold="true" Text="Label"></asp:Label></td>
                                                        <td>&nbsp;</td>
                                                        <td>
                                                            <asp:Label ID="lblExam" runat="server" Font-Bold="true" Text="Label"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Button ID="btnPrint" runat="server" Text="Print" OnClick="btnPrint_Click" /></td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="vertical-align: top;">
                                                <asp:GridView ID="gridStudent1" runat="server" CssClass="gridDynamic" EmptyDataText="Marks Not submitted" AutoGenerateColumns="False" EnableViewState="True">
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="S.No.">
                                                            <ItemTemplate>
                                                                <%# ((GridViewRow)Container).RowIndex + 1%>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:BoundField HeaderText="Enroll" DataField="ENROLLMENT_NO" />
                                                        <asp:BoundField HeaderText="Name" DataField="STU_FULL_NAME" ItemStyle-Width="250px" />
                                                        <asp:BoundField HeaderText="Marks" DataField="INT_MARKS" />
                                                        <asp:BoundField HeaderText="Attendance" DataField="ATTSTS" />
                                                        <asp:BoundField HeaderText="Insert Date" DataField="INT_IN_DT" DataFormatString="{0:dd/MM/yyyy}" />
                                                    </Columns>
                                                </asp:GridView>
                                            </td>
                                        </tr>

                                    </table>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </ContentTemplate>
                    </ajaxToolkit:TabPanel>
                </ajaxToolkit:TabContainer>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</asp:Content>

