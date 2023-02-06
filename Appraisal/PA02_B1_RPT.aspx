<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/FullLength.master" AutoEventWireup="true" CodeFile="PA02_B1_RPT.aspx.cs" Inherits="Appraisal_PA02_B1_RPT" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="container">
        <div class="heading">
            <h2>SUMMARY OF STUDENT'S RESPONSE
            </h2>
        </div>
        <div>
            <table>
                <tr>
                    <td>
                        <table>
                            <tr>
                                <th>Faculty
                                </th>
                                <th>Institution</th>
                                <th>Department</th>
                                <th>Batch</th>
                                <th>Semester</th>
                            </tr>
                            <tr>
                                <td>
                                    <asp:TextBox ID="txtFaculty" runat="server" CssClass="textBox" Width="197px"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlInstitution" runat="server" Width="140px" AutoPostBack="True"
                                      >
                                    </asp:DropDownList></td>
                                <td>
                                    <asp:DropDownList ID="ddlDepartment" runat="server" Width="151px">
                                    </asp:DropDownList></td>
                                <td>
                                    <asp:DropDownList ID="ddlBatch" runat="server" Width="80px">
                                    </asp:DropDownList></td>
                                <td>
                                    <asp:DropDownList ID="ddlSemester" runat="server" Width="58px">
                                    </asp:DropDownList></td>
                                <td>
                                    <asp:Button ID="btnView" runat="server" Text="View" OnClick="btnView_Click" /></td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td>
                        <table>
                            <tr>
                                <td>
                                    <asp:Panel ID="panStudent" runat="server" Height="400px" Width="100%" ScrollBars="Auto">
                                        <asp:GridView ID="gridReportInfo" runat="server" AutoGenerateColumns="false" GridLines="None"
                                            DataKeyNames="PA02_B1_FAC_ID" AllowPaging="false" CssClass="gridDynamic" Width="97%"
                                            HeaderStyle-CssClass="GVFixedHeader" AlternatingRowStyle-CssClass="alt">
                                            <Columns>
                                                <asp:TemplateField HeaderText="S.No.">
                                                    <ItemTemplate>
                                                        <%# ((GridViewRow)Container).RowIndex + 1%>
                                                    .
                                                    </ItemTemplate>
                                                    <ItemStyle Width="30px" />
                                                </asp:TemplateField>
                                                <asp:BoundField DataField="EMP_NAME" HeaderText="Faculty Name">
                                                    <ItemStyle Width="200px" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="DOJ" HeaderText="DOJ" DataFormatString="{0: dd/MM/yyy}">
                                                    <ItemStyle Width="80px" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="DES_VALUE" HeaderText="Designation">
                                                    <ItemStyle Width="150px" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="DEPT_VALUE" HeaderText="Department">
                                                    <ItemStyle Width="100px" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="INS_VALUE" HeaderText="Institution">
                                                    <ItemStyle Width="70px" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="PA02_B1_YEAR" HeaderText="Year">
                                                    <ItemStyle Width="50px" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="ACA_SEM_NO" HeaderText="Sem">
                                                    <ItemStyle Width="50px" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="EVA_SCH_PAPER_CODE" HeaderText="Paper Code">
                                                    <ItemStyle Width="80px" />
                                                </asp:BoundField>
                                                <asp:TemplateField HeaderText="Details" ShowHeader="False">
                                                    <ItemTemplate>
                                                        <asp:HyperLink ID="linkReport"  runat="server" Target="_blank">Details</asp:HyperLink>
                                                    </ItemTemplate>
                                                    <ItemStyle Width="50px" />
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                    </asp:Panel>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </div>
    </div>
    <div class="content">
        <table class="entry" style="width: 100%">
        </table>
    </div>
</asp:Content>

