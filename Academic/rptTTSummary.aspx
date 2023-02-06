<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/FullLength.master" AutoEventWireup="true" CodeFile="rptTTSummary.aspx.cs" Inherits="Academic_rptTTSummary" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script language="javascript" type="text/javascript">
        function show_confirm() {
            var r = confirm("You won't be able any further changes. Do you wish to continue?");
            if (r == true) {
                return true;
            }
            else {
                return false;
            }
        }
    </script>
    <div class="container">
        <div class="heading">
            <h2>Class Summary</h2>
        </div>
        <div style="width: 100%">
            <asp:UpdatePanel ID="UP10" runat="server">
                <ContentTemplate>
                    <table>
                        <tr>
                            <td>
                                <asp:GridView ID="gvShow" runat="server" AutoGenerateColumns="False" CssClass="gridDynamic" DataKeyNames="TT_ID,GRP_ID,CLS_TYPE_ID,SEC_ID" EmptyDataText="No Record Avaliable" OnRowCommand="gvShow_RowCommand">
                                    <Columns>
                                        <asp:TemplateField HeaderText="S.No.">
                                            <ItemTemplate>
                                                <%# ((GridViewRow)Container).RowIndex + 1%>.
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="Course_Code" HeaderText="COURSE CODE" />
                                        <asp:BoundField DataField="CLS_TYPE_VALUE" HeaderText="CLASS TYPE" />
                                        <asp:BoundField DataField="ACA_SEM_NO" HeaderText="SEM" />
                                        <asp:BoundField DataField="ACA_SEC_NAME" HeaderText="SECTION " />
                                        <asp:BoundField DataField="GRP_VALUE" HeaderText="GROUP" />
                                        <asp:BoundField DataField="HELD" HeaderText="HELD" />
                                        <asp:BoundField DataField="MARKED" HeaderText="MARKED" />
                                        <asp:BoundField DataField="BLOCK" HeaderText="BLOCK" />
                                        <asp:BoundField DataField="TOTAL" HeaderText="TOTAL" />
                                        <asp:CommandField ButtonType="Button" HeaderText="Detail" ShowSelectButton="True" />
                                        <asp:ButtonField ButtonType="Button" CommandName="Student" HeaderText="Student" Text="Student" />
                                        <asp:ButtonField ButtonType="Button" CommandName="Faculty" HeaderText="Faculty" Text="Faculty" />
                                        <asp:HyperLinkField Text="Percentage"
                                            DataNavigateUrlFormatString="prtCommulativeAttendance.aspx?TT_ID={0}&GRP_ID={1}&CLS_TYPE_ID={2}&SEC_ID={3}&HELD={4}&MARKED={5}&EMP_ID={6}"
                                            Target="_blank" DataNavigateUrlFields="TT_ID,GRP_ID,CLS_TYPE_ID,SEC_ID,HELD,MARKED,EMP_ID" />
                                    </Columns>
                                </asp:GridView>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <div style="overflow: auto; width: 100%; height: 400px">
                                    <asp:GridView ID="gridClass" runat="server" Caption="Time Table Detail" AutoGenerateColumns="False" CssClass="gridDynamic" DataKeyNames="TT_DET_ID"
                                        SelectedRowStyle-CssClass="pgr" EmptyDataText="No Record Avaliable" HeaderStyle-CssClass="GVFixedHeader" OnRowCommand="gridClass_RowCommand">
                                        <Columns>
                                            <asp:TemplateField HeaderText="S.No.">
                                                <ItemTemplate>
                                                    <%# ((GridViewRow)Container).RowIndex + 1%>.
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="CLS_DATE" HeaderText="DATE" DataFormatString="{0:dd/MM/yyyy}" />
                                            <asp:BoundField DataField="TT_SLOT_VALUE" HeaderText="TIME" />
                                            <asp:BoundField DataField="STATUS" HeaderText="STATUS" />
                                            <asp:BoundField DataField="REASON" HeaderText="REASON" />
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="btnDelete" runat="server" CommandName="Del"
                                                        CommandArgument="<%#((GridViewRow)Container).RowIndex%>" Text="Delete" OnClientClick="return show_confirm()" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:HyperLinkField Target="_blank" Text="Detail"
                                                HeaderText="Report" DataNavigateUrlFields="TT_DET_ID" DataNavigateUrlFormatString="prtClassStudent.aspx?id={0}"></asp:HyperLinkField>
                                        </Columns>
                                    </asp:GridView>

                                    <asp:GridView ID="gridStudent" runat="server" Caption="Student List" AutoGenerateColumns="False" CssClass="gridDynamic"
                                        EmptyDataText="No Record Avaliable" DataKeyNames="TT_ID, STU_MAIN_ID">
                                        <Columns>
                                            <asp:TemplateField HeaderText="S.No.">
                                                <ItemTemplate>
                                                    <%# ((GridViewRow)Container).RowIndex + 1%>.
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="Enrollment_No" HeaderText="Enrollment" />
                                            <asp:BoundField DataField="STU_FULL_NAME" HeaderText="Student Name" />
                                            <asp:HyperLinkField Target="_blank" Text="Detail"
                                                HeaderText="Report" DataNavigateUrlFields="TT_ID, STU_MAIN_ID" DataNavigateUrlFormatString="prtStudentDailyAtt.aspx?TT_ID={0}&STU_MAIN_ID={1}"></asp:HyperLinkField>
                                        </Columns>
                                    </asp:GridView>
                                    <asp:GridView ID="gridFaculty" runat="server" Caption="Faculty List" AutoGenerateColumns="False" CssClass="gridDynamic"
                                        EmptyDataText="No Record Avaliable">
                                        <Columns>
                                            <asp:TemplateField HeaderText="S.No.">
                                                <ItemTemplate>
                                                    <%# ((GridViewRow)Container).RowIndex + 1%>.
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="USR_LOGIN_ID" HeaderText="Emp Code" />
                                            <asp:BoundField DataField="EMP_NAME" HeaderText="Employee Name" />
                                            <asp:BoundField DataField="HELD" HeaderText="Held" />
                                            <asp:BoundField DataField="MARKED" HeaderText="Marked" />
                                            <asp:BoundField DataField="BLOCK" HeaderText="Block" />
                                        </Columns>
                                    </asp:GridView>
                                </div>
                            </td>
                        </tr>
                    </table>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
</asp:Content>

