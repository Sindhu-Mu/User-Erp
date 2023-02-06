<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/FullLength.master" AutoEventWireup="true" CodeFile="EvaluationScheme.aspx.cs" Inherits="Academic_EvaluationScheme" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script lang="javascript" type="text/javascript">
        //function Check(ch) {
        //    if (ch.checked) {
        //        document.getElementById('tblCopy').style.display = 'block';
        //        document.getElementById('tblAdd').style.display = 'none';
        //    }
        //    else {
        //        document.getElementById('tblCopy').style.display = 'none';
        //        document.getElementById('tblAdd').style.display = 'block';
        //    }
        //}

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


            if (!CheckControl("<%=ddlSchemeName.ClientID%>") && !CheckControl("<%=txtSchemeName.ClientID%>")) {
                msg += " * Select scheme name from the the list or type new name. \n";
                if (ctrl == "")
                    ctrl = "<%=ddlInstitution.ClientID%>";
                flag = false;
            }
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
            if (!CheckControl("<%=ddlSubject.ClientID%>")) {
                msg += " * Select subject. \n";
                if (ctrl == "")
                    ctrl = "<%=ddlSubject.ClientID%>";
                flag = false;
            }
            if (!CheckControl("<%=txtPaperCode.ClientID%>")) {
                msg += " * Enter Paper code. \n";
                if (ctrl == "")
                    ctrl = "<%=txtPaperCode.ClientID%>";
                flag = false;
            }
            if (!CheckControl("<%=ddlMarksTemplate.ClientID%>")) {
                msg += " * Select Marks Template. \n";
                if (ctrl == "")
                    ctrl = "<%=ddlMarksTemplate.ClientID%>";
                flag = false;
            }
            if (!CheckControl("<%=ddlPoint.ClientID%>")) {
                msg += " * Select Credit Point . \n";
                if (ctrl == "")
                    ctrl = "<%=ddlPoint.ClientID%>";
                flag = false;
            }
            if (msg != "") alert(msg);
            if (ctrl != "")
                document.getElementById(ctrl).focus();
            return flag;
        }
        function validationCopy() {
            var flag = true;
            var msg = "", ctrl = "";
            if (!CheckControl("<%=ddlSchemeName.ClientID%>") && !CheckControl("<%=txtSchemeName.ClientID%>")) {
                msg += " * Select scheme name from the the list or type new name. \n";
                if (ctrl == "")
                    ctrl = "<%=ddlInstitution.ClientID%>";
                flag = false;
            }
            if (!CheckControl("<%=ddlBatch.ClientID%>")) {
                msg += " * Select batch. \n";
                if (ctrl == "")
                    ctrl = "<%=ddlBatch.ClientID%>";
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
            <h2>Evaluation Scheme </h2>
        </div>
        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
            <ContentTemplate>
                <div>
                    <table>
                        <tr>
                            <th>Institution<span style="color: red">*</span></th>
                            <th>Course<span style="color: red">*</span></th>
                            <th>Batch<span style="color: red">*</span></th>
                            <th>Branch<span style="color: red">*</span></th>
                            <th>Scheme Name<span style="color: red">*</span></th>

                        </tr>
                        <tr>
                            <td>
                                <asp:DropDownList ID="ddlInstitution" runat="server" Width="80px" OnSelectedIndexChanged="ddlInstitution_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlCourse" runat="server" Width="153px" OnSelectedIndexChanged="ddlCourse_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlBatch" runat="server" Width="156px" AutoPostBack="True" OnSelectedIndexChanged="ddlBatch_SelectedIndexChanged"></asp:DropDownList>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlBranch" runat="server" Width="156px" OnSelectedIndexChanged="ddlBranch_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList>
                            </td>

                            <td>
                                <table>
                                    <tr>
                                        <td id="ddlscheme" runat="server" visible="true">
                                            <asp:DropDownList ID="ddlSchemeName" runat="server" Width="156px"></asp:DropDownList></td>
                                        <%--                                                <td style="font-size: large">/
                                                </td>--%>
                                        <td id="txtscheme" runat="server" visible="false">
                                            <asp:TextBox ID="txtSchemeName" runat="server" Width="144px" MaxLength="50" CssClass="textbox"></asp:TextBox></td>
                                        <td>
                                            <asp:TextBox ID="txtXML" runat="server" Visible="False"></asp:TextBox>
                                        </td>
                                    </tr>
                                </table>

                            </td>
                        </tr>
                    </table>
                </div>
                <div>
                    <asp:CheckBox ID="chkCopy" runat="server" Text="Check/Uncheck to Copy / Add data" OnCheckedChanged="chkCopy_CheckedChanged" AutoPostBack="true" /></td>
                </div>
                <div id="tblAdd" runat="server">
                    <div>
                        <table>
                            <tr>
                                <th>Semester<span style="color: red">*</span></th>
                                <th>Subject Type<span style="color: red">*</span></th>
                                <th>Paper Type<span style="color: red">*</span></th>
                                <th>Subject Name<span style="color: red">*</span></th>
                            </tr>
                            <tr>
                                <td>
                                    <asp:DropDownList ID="ddlSemester" runat="server" Width="60px"></asp:DropDownList>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlSubjectType" runat="server" Width="100px" OnSelectedIndexChanged="ddlSubjectType_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlPaperType" runat="server">
                                        <asp:ListItem Text="Compulsory" Selected="True" Value="1"></asp:ListItem>
                                        <asp:ListItem Text="Elective" Value="2"></asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlSubject" runat="server" Width="400px"></asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <th>Paper Code<span style="color: red">*</span></th>
                                <th>Marks Template<span style="color: red">*</span></th>
                                <th>Credit Point<span style="color: red">*</span></th>
                                <th>Upload Syllabus<span style="color: red">*</span></th>
                            </tr>
                            <tr>
                                <td>
                                    <asp:TextBox ID="txtPaperCode" runat="server" CssClass="textbox" Width="108px"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlMarksTemplate" runat="server" Width="200px" OnSelectedIndexChanged="ddlMarksTemplate_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlPoint" runat="server" Width="69px">
                                        <asp:ListItem Value=".">Select</asp:ListItem>
                                        <asp:ListItem>30</asp:ListItem>
                                        <asp:ListItem>25</asp:ListItem>
                                        <asp:ListItem>24</asp:ListItem>
                                        <asp:ListItem>20</asp:ListItem>
                                        <asp:ListItem>19</asp:ListItem>
                                        <asp:ListItem>18</asp:ListItem>
                                        <asp:ListItem>17</asp:ListItem>
                                        <asp:ListItem>16</asp:ListItem>
                                        <asp:ListItem>15</asp:ListItem>
                                        <asp:ListItem>14</asp:ListItem>
                                        <asp:ListItem>13</asp:ListItem>
                                        <asp:ListItem>12</asp:ListItem>
                                        <asp:ListItem>11</asp:ListItem>
                                        <asp:ListItem>10</asp:ListItem>
                                        <asp:ListItem>9</asp:ListItem>
                                        <asp:ListItem>8</asp:ListItem>
                                        <asp:ListItem>7</asp:ListItem>
                                        <asp:ListItem>6</asp:ListItem>
                                        <asp:ListItem>5</asp:ListItem>
                                        <asp:ListItem>4.5</asp:ListItem>
                                        <asp:ListItem>4</asp:ListItem>
                                        <asp:ListItem>3</asp:ListItem>
                                        <asp:ListItem>2</asp:ListItem>
                                        <asp:ListItem>1.5</asp:ListItem>
                                        <asp:ListItem>1</asp:ListItem>
                                        <asp:ListItem>0.5</asp:ListItem>
                                        <asp:ListItem>0</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    <asp:FileUpload runat="server" ID="FileUpload1" /></td>
                                <td>
                                    <asp:Button ID="btnAdd" runat="server" Text="Add" CssClass="btnBrown" OnClick="btnAdd_Click" />

                                </td>
                            </tr>
                        </table>
                    </div>
                    <div>
                        <asp:Repeater ID="repMarksTemplateDetails" runat="server">
                            <HeaderTemplate>
                                <table>
                                    <tr>
                                        <th>Marks Template Details
                                        </th>
                                    </tr>
                                    <tr>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <td style="border: 1px solid #000000;">
                                    <table>
                                        <tr>
                                            <th style="text-decoration: underline">
                                                <%#Eval("EXAM_TYPE_SUB_HEAD")%>
                                            </th>
                                        </tr>
                                        <tr>
                                            <td>
                                                <%#Eval("MARKS")%>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </ItemTemplate>
                            <FooterTemplate>
                                </tr>
                                        </table>
                            </FooterTemplate>
                        </asp:Repeater>
                    </div>

                    <div>
                    </div>
                    <div>
                        <asp:GridView ID="gridXMLAdd" runat="server" AutoGenerateColumns="false" EmptyDataText="No. records found" OnRowDeleting="gridXMLAdd_RowDeleting"
                            CssClass="gridDynamic" Caption="Added Papers" DataKeyNames= "FILE_PATH">
                            <Columns>
                                <asp:TemplateField HeaderText="S.No.">
                                    <ItemTemplate>
                                        <%# ((GridViewRow)Container).RowIndex + 1%>.
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="ACA_SEM_NAME" HeaderText="Semester" />
                                <asp:TemplateField HeaderText="Paper Code">
                                    <ItemTemplate>
                                        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%# Bind("FILE_PATH") %>'
                                            Text='<%# Bind("EVA_SCH_PAPER_CODE") %>' Target="_blank"></asp:HyperLink>
                                    </ItemTemplate>
                                </asp:TemplateField>                            
                                <asp:BoundField DataField="ELE_VALUE" HeaderText="Paper Type" />
                                <asp:BoundField DataField="SUB_TYPE_NAME" HeaderText="Subject Name" />
                                <asp:BoundField DataField="CREDIT_POINT" HeaderText="Credit Point" />
                                <asp:CommandField ShowDeleteButton="true" />
                            </Columns>
                        </asp:GridView>

                    </div>

                </div>
                <div>
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                            <table id="tblCopy" runat="server" visible="false">
                                <tr>
                                    <td>
                                        <fieldset>
                                            <legend>Copy From Existing</legend>
                                            <table>
                                                <tr>
                                                    <th>Institution<span style="color: red">*</span></th>
                                                    <th>Course<span style="color: red">*</span></th>
                                                    <th>Batch<span style="color: red">*</span></th>
                                                    <th>Semester<span style="color: red">*</span></th>
                                                    <th>Branch<span style="color: red">*</span></th>
                                                    <th>Scheme Name<span style="color: red">*</span></th>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:DropDownList ID="ddlInstitutionCopy" runat="server" Width="80px" OnSelectedIndexChanged="ddlInstitutionCopy_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList>
                                                    </td>
                                                    <td>
                                                        <asp:DropDownList ID="ddlCourseCopy" runat="server" Width="153px" OnSelectedIndexChanged="ddlCourseCopy_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList>
                                                    </td>
                                                    <td>
                                                        <asp:DropDownList ID="ddlBatchCopy" runat="server" Width="156px" AutoPostBack="True" OnSelectedIndexChanged="ddlBatchCopy_SelectedIndexChanged"></asp:DropDownList>
                                                    </td>
                                                    <td>
                                                        <asp:DropDownList ID="ddlSemesterCopy" runat="server" Width="80px" AutoPostBack="True" OnSelectedIndexChanged="ddlSemesterCopy_SelectedIndexChanged"></asp:DropDownList>
                                                    </td>
                                                    <td>
                                                        <asp:DropDownList ID="ddlBranchCopy" runat="server" Width="156px" OnSelectedIndexChanged="ddlBranchCopy_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList>
                                                    </td>
                                                    <td>
                                                        <asp:DropDownList ID="ddlSchemeNameCopy" runat="server" Width="156px" AutoPostBack="True" OnSelectedIndexChanged="ddlSchemeNameCopy_SelectedIndexChanged"></asp:DropDownList>
                                                    </td>
                                                </tr>
                                            </table>
                                        </fieldset>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <fieldset>
                                            <legend>Select the papers to copy</legend>
                                            <table>
                                                <tr>
                                                    <td>
                                                        <asp:GridView ID="gridExistingPapers" runat="server" AutoGenerateColumns="false" EmptyDataText="No. records found"
                                                            DataKeyNames="EVA_SCH_PAPER_CODE,ACA_SEM_ID,EXAM_TEMP_MAIN_ID,ACA_SUB_ID,SUB_TYPE_ID,CREDIT_POINT,ELE_ID" CssClass="gridDynamic">
                                                            <Columns>
                                                                <asp:TemplateField HeaderText="S.No.">
                                                                    <ItemTemplate>
                                                                        <%# ((GridViewRow)Container).RowIndex + 1%>.
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:BoundField DataField="EVA_SCH_PAPER_CODE" HeaderText="Paper Code" />
                                                                <asp:BoundField DataField="ACA_SUB_NAME" HeaderText="Subject Name" />
                                                                <asp:TemplateField HeaderText="Select">
                                                                    <ItemTemplate>
                                                                        <asp:CheckBox ID="chkAdd" runat="server" Checked="true" />
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                            </Columns>
                                                        </asp:GridView>
                                                    </td>

                                                    <td>
                                                        <asp:Button ID="btnCopy" runat="server" Text="Copy" Enabled="False" OnClick="btnCopy_Click" />
                                                    </td>
                                                </tr>
                                            </table>
                                        </fieldset>
                                    </td>
                                </tr>
                            </table>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
                <div style="text-align: right;" id="DivButton" runat="server" visible="false">
                    <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" />
                    &nbsp;
                    <asp:Button ID="btnClear" runat="server" Text="Clear" OnClick="btnClear_Click" />
                </div>
            </ContentTemplate>
            <Triggers>
                <asp:PostBackTrigger ControlID="btnAdd" />
            </Triggers>
        </asp:UpdatePanel>
    </div>
</asp:Content>

