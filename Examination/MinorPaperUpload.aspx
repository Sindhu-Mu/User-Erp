<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/FullLength.master" AutoEventWireup="true" CodeFile="MinorPaperUpload.aspx.cs" Inherits="Examination_MinorPaperUpload" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script lang="javascript" type="text/javascript">


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
            if (!CheckControl("<%=ddlCourse.ClientID%>")) {
                msg += "Select Course from list \n";
                if (ctrl == "")
                    ctrl = "<%=ddlCourse.ClientID%>";
                flag = false;
            }

            if (CheckControl("<%=txtDate.ClientID%>")) {
                if (!CheckDate("<%=txtDate.ClientID%>")) {
                    msg += "- Invalid Format of Date.Please Enter in this[dd/MM/yyyy]\n";
                    if (ctrl == "")
                        ctrl = "<%=txtDate.ClientID%>";
                    flag = false;
                }
            }
            else {
                msg += "- Please enter exam date\n";
                if (ctrl == "")
                    ctrl = "<%=txtDate.ClientID%>";
                flag = false;
            }
            if (!CheckControl("<%=ddlTimeSlot.ClientID%>")) {
                msg += "Select examination time slot from list \n";
                if (ctrl == "")
                    ctrl = "<%=ddlTimeSlot.ClientID%>";
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
            <h2>Online Minor(Step-1)</h2>
        </div>

        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>

                <div style="float: left; width: 35%;">
                    <div style="margin-top: 20px; border-bottom: 1px solid black;">
                        <h4>Course Examination Schedule & Paper Upload</h4>
                    </div>
                    <div>
                        <table>
                            <tr>
                                <th>Examination <span class="required">*</span></th>
                                <td>&nbsp;</td>
                                <td>
                                    <asp:DropDownList ID="ddlMinorExam" runat="server"></asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <th style="width: 40%;">Course <span class="required">*</span></th>
                                <td>&nbsp;</td>
                                <td>
                                    <asp:DropDownList ID="ddlCourse" runat="server" ></asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <th>Date<span class="required">*</span></th>
                                <td>&nbsp;</td>
                                <td>
                                    <asp:TextBox ID="txtDate" runat="server" CssClass="textBox"></asp:TextBox>
                                    <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd/MM/yyyy"
                                        TargetControlID="txtDate">
                                    </ajaxToolkit:CalendarExtender>
                                    <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender1" runat="server" Mask="99/99/9999"
                                        MaskType="Date" TargetControlID="txtDate">
                                    </ajaxToolkit:MaskedEditExtender>
                                </td>
                            </tr>
                            <tr>
                                <th>Duration<span class="required">*</span></th>
                                <td>&nbsp;</td>
                                <td>
                                    <asp:DropDownList ID="ddlTimeSlot" runat="server"></asp:DropDownList></td>
                            </tr>
                            <tr>
                                <th>Upload Paper(.pdf) </th>
                                <td>&nbsp;</td>
                                <td>
                                    <asp:FileUpload ID="fileupload1" runat="server" /></td>
                            </tr>
                            <tr>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td>
                                    <asp:Button ID="btnSave" runat="server" Text="Save" Width="70px" OnClick="btnSave_Click" /></td>
                            </tr>

                        </table>
                    </div>
                </div>
                <div style="float: left; width: 5%;">&nbsp;</div>
                <div style="float: left; width: 60%;">
                    <div style="margin-top: 20px; border-bottom: 1px solid black;">
                        <h4>Uploaded Schedule & Paper </h4>
                    </div>
                    <div style="overflow: auto; max-height: 400px">
                        <asp:GridView ID="GridPaperDetail" runat="server" AutoGenerateColumns="False" DataKeyNames="MAIN_ID" OnRowCommand="GridPaperDetail_RowCommand" Width="100%" EmptyDataText="No Record Avaliable" CssClass="gridDynamic">
                            <Columns>
                                <asp:TemplateField HeaderText="S.No.">
                                    <ItemTemplate>
                                        <%# ((GridViewRow)Container).RowIndex + 1%>                                    .
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField HeaderText="Course Code" DataField="CRS_CODE" />
                                <asp:BoundField HeaderText="Exam Date" DataField="EXAM_DATE" DataFormatString="{0:dd/MM/yyyy}" />
                                <asp:BoundField HeaderText="Exam Timing" DataField="TT_SLOT_VALUE" />                                
                                <asp:TemplateField HeaderText="Question Paper">
                                    <ItemTemplate>
                                        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%# Bind("QUESTION_FILE") %>'
                                            Text="Download" Target="_blank"></asp:HyperLink>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:CommandField ButtonType="Image" SelectImageUrl="~/Siteimages/edit.gif" ShowSelectButton="True" HeaderText="Modify">
                                    <ItemStyle Width="40px" />
                                </asp:CommandField>
                            </Columns>
                        </asp:GridView>
                    </div>
                </div>
                <div class="cleaner"></div>
            </ContentTemplate>
            <Triggers >
                <asp:PostBackTrigger ControlID="btnSave" />
            </Triggers>
        </asp:UpdatePanel>
    </div>
</asp:Content>

