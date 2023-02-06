<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/FullLength.master" AutoEventWireup="true" CodeFile="rptDepartmentStudent.aspx.cs" Inherits="Academic_rpt_Department_Student" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="container">
        <div class="heading">
            <h2>Department Student Report
            </h2>
        </div>
        <div>
            <table>
                <tr>
                    <td>
                        <table>
                            <tr>
                                <th>By Batch
                                </th>
                                <th>By Course
                                </th>
                                <th>By Branch
                                </th>
                                <th>By Semester
                                </th>
                                <th>By Section
                                </th>
                                <th>By Group
                                </th>
                                <th>By Status
                                </th>
                                <th>By Sort
                                </th>
                            </tr>
                            <tr>
                                <td>
                                    <asp:DropDownList ID="ddlBatch" runat="server" Width="100px">
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlCourse" runat="server" Width="100px" OnSelectedIndexChanged="ddlCourse_SelectedIndexChanged" AutoPostBack="true">
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlBranch" runat="server" Width="100px">
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlSem" runat="server" Width="100px">
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlSec" runat="server" Width="100px">
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlGroup" runat="server" Width="100px">
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlStatus" runat="server" Width="100px">
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlSort" runat="server" Width="100px">
                                        <asp:ListItem Value="INS_PGM_INF.INS_PGM_ID">Batch</asp:ListItem>
                                        <asp:ListItem Value="ACA_BATCH_INF.ACA_BATCH_ID">Course</asp:ListItem>
                                        <asp:ListItem Value="INS_PGM_BRN_INF.PGM_BRN_ID">Branch</asp:ListItem>
                                        <asp:ListItem Value="ACA_SEM_INF.ACA_SEM_ID">Semester</asp:ListItem>
                                        <asp:ListItem Value="ACA_SEC_INF.ACA_SEC_ID">Section</asp:ListItem>
                                        <asp:ListItem Value="TT_GRP_INF.GRP_ID">Group</asp:ListItem>
                                        <asp:ListItem Value="STU_MAIN_INF.STU_STS_ID">Status</asp:ListItem>

                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="6"></td>
                                <td>
                                    <asp:Button ID="btnView" runat="server" Text="View" Width="100px" OnClick="btnView_Click" />
                                </td>
                                <td>
                                    <asp:Button ID="btnExport" runat="server" Text="Export to Excel" Width="110px" />
                                </td>
                            </tr>
                            <tr>
                                <td colspan="8">
                                    <asp:GridView ID="gvDetail" runat="server" Width="98%" ShowHeader="true" AutoGenerateColumns="False" CssClass="gridDynamic">
                                        <Columns>
                                            <asp:BoundField HeaderText="S#">
                                                <ItemStyle Width="15px"></ItemStyle>
                                            </asp:BoundField>
                                            <asp:BoundField DataField="ENROLLMENT_NO" HeaderText="ENROLLMENT">
                                                <ItemStyle Width="90px"></ItemStyle>
                                            </asp:BoundField>
                                            <asp:BoundField DataField="SEM_ROLL_NO" HeaderText="ROLL NO">
                                                <ItemStyle Width="90px"></ItemStyle>
                                            </asp:BoundField>
                                            <asp:BoundField DataField="STU_FULL_NAME" HeaderText="STUDENT">
                                                <ItemStyle Width="170px"></ItemStyle>
                                            </asp:BoundField>
                                            <asp:BoundField DataField="PGM_FULL_NAME" HeaderText="COURSE">
                                                <ItemStyle Width="140px"></ItemStyle>
                                            </asp:BoundField>
                                            <asp:BoundField DataField="ACA_SEM_NO" HeaderText="SEMESTER">
                                                <ItemStyle Width="65px"></ItemStyle>
                                            </asp:BoundField>
                                            <asp:BoundField DataField="ACA_SEC_NAME" HeaderText="SECTION">
                                                <ItemStyle Width="65px"></ItemStyle>
                                            </asp:BoundField>
                                            <asp:BoundField DataField="GRP_VALUE" HeaderText="GROUP">
                                                <ItemStyle Width="65px"></ItemStyle>
                                            </asp:BoundField>
                                            <asp:BoundField DataField="STU_ENROLL_DT" DataFormatString="{0:dd/MM/yyyy}" HeaderText="ADMISSTION DATE">
                                                <ItemStyle Width="80px"></ItemStyle>
                                            </asp:BoundField>
                                            <asp:BoundField DataField="PHN_NO" HeaderText="CONTACT">
                                                <ItemStyle Width="60px"></ItemStyle>
                                            </asp:BoundField>
                                        </Columns>
                                    </asp:GridView>
                                </td>
                            </tr>
                        </table>
                    </td>

                </tr>
            </table>
        </div>

    </div>
</asp:Content>

