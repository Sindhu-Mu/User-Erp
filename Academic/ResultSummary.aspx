<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/FullLength.master" AutoEventWireup="true" CodeFile="ResultSummary.aspx.cs" Inherits="Academic_ResultSummary" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="container">
        <div class="heading">
            <h2>Result Summary</h2>
        </div>

        <div>
            <table>
                <tr>
                    <th>Institution</th>
                    <td>&nbsp;</td>
                     <th>Batch</th>
                    <td>&nbsp;</td>
                    <th>Program</th>
                    <td>&nbsp;</td>                   
                    <th>Branch</th>
                    <td>&nbsp;</td>
                    <th>Semester</th>
                    <td>&nbsp;</td>
                    <th>Paper</th>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>
                        <asp:DropDownList ID="ddlInstitution" runat="server" Width="80px"
                            AutoPostBack="True" OnSelectedIndexChanged="ddlInstitution_SelectedIndexChanged">
                        </asp:DropDownList>
                    </td>
                    <td>&nbsp;</td>
                     <td>
                        <asp:DropDownList ID="ddlBatch" runat="server" Width="80px">
                        </asp:DropDownList>
                    </td>
                    <td>&nbsp;</td>
                    <td>
                        <asp:DropDownList ID="ddlCourse" runat="server" Width="153px"
                            AutoPostBack="True" OnSelectedIndexChanged="ddlCourse_SelectedIndexChanged">
                        </asp:DropDownList>
                    </td>
                    <td>&nbsp;</td>

                    <td>
                        <asp:DropDownList ID="ddlBranch" runat="server" Width="156px">
                        </asp:DropDownList>
                    </td>
                    <td>&nbsp;</td>
                   
                    <td>
                        <asp:DropDownList ID="ddlSemester" runat="server" Width="60px" AutoPostBack="True" OnSelectedIndexChanged="ddlSemester_SelectedIndexChanged">
                        </asp:DropDownList>
                    </td>
                    <td>&nbsp;</td>
                    <td>
                        <asp:DropDownList ID="ddlPaper" runat="server" Width="250px">
                        </asp:DropDownList>
                    </td>
                    <td>&nbsp;</td>
                    <td>
                        <asp:Button ID="btnView" runat="server" Text="View" CssClass="btnBrown" OnClick="btnView_Click" />
                    </td>
                </tr>
            </table>
        </div>

        <div style="overflow: auto; width: 100%; height: 400px">
            <asp:GridView ID="gridSummary" runat="server" AutoGenerateColumns="true" EmptyDataText="No records found"
                CssClass="gridDynamic"
                SelectedRowStyle-CssClass="pgr" Width="97%">
                <Columns>
                    <asp:TemplateField HeaderText="S.No.">
                        <ItemTemplate>
                            <%# ((GridViewRow)Container).RowIndex + 1%>
                                                .
                        </ItemTemplate>
                        <ItemStyle Width="20px" />
                    </asp:TemplateField>

                    <%-- <asp:BoundField DataField="EVA_SCH_PAPER_CODE" HeaderText="Paper Code" />
                    <asp:BoundField DataField="ACA_SUB_NAME" HeaderText="Course Name" />
                    <asp:BoundField DataField="PGM_SHORT_NAME" HeaderText="Program">
                        <ItemStyle Width="120px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="ACA_BATCH_NAME" HeaderText="Batch" />
                    <asp:BoundField DataField="BRN_SHORT_NAME" HeaderText="Branch" />
                    <asp:BoundField DataField="ACA_SEM_ID" HeaderText="Sem">
                        <ItemStyle Width="20px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="CREDIT_POINT" HeaderText="Credit" />
                    <asp:BoundField DataField="SUB_TYPE_VALUE" HeaderText="Subject Type" />
                    <asp:BoundField DataField="ELE_VALUE" HeaderText="Elective Type" />--%>
                </Columns>
            </asp:GridView>
        </div>
        <div id="DivExport" runat="server" visible="false">
            <asp:Button ID="btnExport" runat="server" Text="Export To Excel" OnClick="btnExport_Click1" />
        </div>
    </div>
</asp:Content>

