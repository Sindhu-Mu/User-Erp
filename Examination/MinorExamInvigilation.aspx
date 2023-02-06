<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/FullLength.master" AutoEventWireup="true" CodeFile="MinorExamInvigilation.aspx.cs" Inherits="Examination_MinorExamInvigilation" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="container">
        <div class="heading">
            <h2>Online Minor(Step-2)</h2>
        </div>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>

                <div style="width: 90%;">
                    <div style="margin-top: 5px;margin-bottom:5px; border-bottom: 1px solid black;">
                        <h4>Examination Monitoring</h4>
                    </div>
                    <div>
                        <table>
                            <tr>
                                <th>Examination <span class="required">*</span></th>
                                <td>&nbsp;</td>
                                <th>Course Code <span class="required">*</span></th>
                                <td>&nbsp;</td>
                                <th>Examnation Date & Time <span class="required">*</span></th>
                                <td>&nbsp;</td>
                                <th>Total Student<span class="required">*</span></th>
                                <td>&nbsp;</td>
                                <th>Question Downloaded </th>
                                <td>&nbsp;</td>
                                <th>Answer Uploaded</th>
                            </tr>

                            <tr>
                                <td>
                                    <asp:DropDownList ID="ddlMinorExam" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlMinorExam_SelectedIndexChanged"></asp:DropDownList>
                                </td>
                                <td>&nbsp;</td>
                                <td>
                                    <asp:DropDownList ID="ddlCourse" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlCourse_SelectedIndexChanged" ></asp:DropDownList>
                                </td>
                                <td>&nbsp;</td>
                                <td>
                                    <asp:Label ID="lblDatetime" runat="server"></asp:Label></td>
                                <td>&nbsp;</td>
                                <td>
                                    <asp:LinkButton ID="lnkTotal" runat="server" OnClick="lnkTotal_Click"></asp:LinkButton></td>
                                <td>&nbsp;</td>
                                <td>
                                    <asp:LinkButton ID="lnkStarted" runat="server" OnClick="lnkStarted_Click"></asp:LinkButton></td>
                                <td>&nbsp;</td>
                                <td>
                                    <asp:LinkButton ID="lnkUploaded" runat="server" OnClick="lnkUploaded_Click"></asp:LinkButton></td>
                            </tr>

                        </table>
                    </div>
                

               
                    <div style="margin-top: 20px; border-bottom: 1px solid black;">
                        <h4>Student Details </h4>
                    </div>
                    <div>
                        <asp:GridView ID="GridStudent1" runat="server" AutoGenerateColumns="False" Width="100%" EmptyDataText="No Record Avaliable" CssClass="gridDynamic">
                            <Columns>
                                <asp:TemplateField HeaderText="S.No.">
                                    <ItemTemplate>
                                        <%# ((GridViewRow)Container).RowIndex + 1%>                                    .
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField HeaderText="Enrollment No" DataField="ENROLLMENT_NO" />
                                <asp:BoundField HeaderText="Student Name" DataField="STU_FULL_NAME" />
                                <asp:BoundField HeaderText="Program" DataField="PGM_SHORT_NAME" />
                                <asp:BoundField HeaderText="Branch" DataField="BRN_SHORT_NAME" />
                                <asp:BoundField HeaderText="Sem" DataField="ACA_SEM_ID" />
                            </Columns>
                        </asp:GridView>
                        <asp:GridView ID="GridStudent2" runat="server" AutoGenerateColumns="False" DataKeyNames="SUB_ID" OnRowDeleting="GridStudent2_RowDeleting" Width="100%" EmptyDataText="No Record Avaliable" CssClass="gridDynamic">
                            <Columns>
                                <asp:TemplateField HeaderText="S.No.">
                                    <ItemTemplate>
                                        <%# ((GridViewRow)Container).RowIndex + 1%>                                    .
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField HeaderText="Enrollment No" DataField="ENROLLMENT_NO" />
                                <asp:BoundField HeaderText="Student Name" DataField="STU_FULL_NAME" />
                                <asp:BoundField HeaderText="Program" DataField="PGM_SHORT_NAME" />
                                <asp:BoundField HeaderText="Branch" DataField="BRN_SHORT_NAME" />
                                <asp:BoundField HeaderText="Sem" DataField="ACA_SEM_ID" />
                               <asp:CommandField ShowDeleteButton="true" ButtonType="Button" HeaderText="Student" DeleteText="Deactivate" />
                            </Columns>
                        </asp:GridView>
                         <asp:GridView ID="GridStudent3" runat="server" AutoGenerateColumns="False" DataKeyNames="SUB_ID" OnRowDeleting="GridStudent3_RowDeleting" Width="100%" EmptyDataText="No Record Avaliable" CssClass="gridDynamic">
                            <Columns>
                                <asp:TemplateField HeaderText="S.No.">
                                    <ItemTemplate>
                                        <%# ((GridViewRow)Container).RowIndex + 1%>                                    .
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField HeaderText="Enrollment No" DataField="ENROLLMENT_NO" />
                                <asp:BoundField HeaderText="Student Name" DataField="STU_FULL_NAME" />
                                <asp:BoundField HeaderText="Program" DataField="PGM_SHORT_NAME" />
                                <asp:BoundField HeaderText="Branch" DataField="BRN_SHORT_NAME" />
                                <asp:BoundField HeaderText="Sem" DataField="ACA_SEM_ID" />
                               <asp:CommandField ShowDeleteButton="true" ButtonType="Button" HeaderText="Student" DeleteText="Re-Upload" />
                            </Columns>
                        </asp:GridView>
                    </div>
                </div>
                <div class="cleaner">
                    <asp:HiddenField ID="HiddenField1" runat="server" />
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</asp:Content>

