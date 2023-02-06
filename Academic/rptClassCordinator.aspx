<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/FullLength.master" AutoEventWireup="true" CodeFile="rptClassCordinator.aspx.cs" Inherits="Academic_rptClassCordinator" %>

<%@ Register Src="~/Control/StuFullProfile.ascx" TagPrefix="uc1" TagName="StuFullProfile" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <div class="container">

        <div class="heading">
            <h2>Class Attendance</h2>
        </div>
        <div style="width: 100%">
            <asp:UpdatePanel ID="UP10" runat="server">
                <ContentTemplate>
                    <table>
                        <tr>
                            <td>
                                <asp:GridView ID="gvShow" runat="server" AutoGenerateColumns="False" CssClass="gridDynamic" DataKeyNames="TT_ID,GRP_ID,EMP_ID" EmptyDataText="No Record Avaliable" OnRowCommand="gvShow_RowCommand">
                                    <Columns>
                                        <asp:TemplateField HeaderText="S.No.">
                                            <ItemTemplate>
                                                <%# ((GridViewRow)Container).RowIndex + 1%>.
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="COURSE_CODE" HeaderText="Course">
                                            <ItemStyle Width="300px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="EMP_NAME" HeaderText="Faculty">
                                            <ItemStyle Width="200px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="HELD" HeaderText="HELD" />
                                        <asp:BoundField DataField="MARKED" HeaderText="MARKED" />
                                        <asp:BoundField DataField="BLOCK" HeaderText="BLOCK" />
                                        <asp:BoundField DataField="TOTAL" HeaderText="TOTAL" />
                                        <asp:CommandField ButtonType="Button" HeaderText="Detail" ShowSelectButton="True" />
                                        <asp:ButtonField ButtonType="Button" CommandName="Student" HeaderText="Student" Text="Student" />
                                    </Columns>
                                </asp:GridView>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <div style="overflow: auto; width: 100%; height: 400px">
                                    <asp:GridView ID="gridClass" runat="server" Caption="Time Table Detail" AutoGenerateColumns="False" CssClass="gridDynamic" SelectedRowStyle-CssClass="pgr" EmptyDataText="No Record Avaliable" HeaderStyle-CssClass="GVFixedHeader">
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
                                        </Columns>
                                    </asp:GridView>
                                    <asp:GridView ID="gridStudent" runat="server" Caption="Student List" AutoGenerateColumns="False" CssClass="gridDynamic" EmptyDataText="No Record Avaliable" DataKeyNames="STU_MAIN_ID" OnRowCommand="gridStudent_RowCommand">
                                        <Columns>
                                            <asp:TemplateField HeaderText="S.No.">
                                                <ItemTemplate>
                                                    <%# ((GridViewRow)Container).RowIndex + 1%>.
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="Enrollment_No" HeaderText="Enrollment" />
                                            <asp:BoundField DataField="STU_FULL_NAME" HeaderText="Student Name" />
                                            <asp:CommandField ButtonType="Button" HeaderText="Detail" ShowSelectButton="True" />
                                        </Columns>
                                    </asp:GridView>
                                </div>
                            </td>
                        </tr>
                        <tr id="trProfile" runat="server" visible="false">
                            <td>
                                <uc1:StuFullProfile runat="server" ID="StuFullProfile" ClientIDMode="Static" />

                            </td>
                        </tr>
                    </table>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
</asp:Content>

