<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/FullLength.master" AutoEventWireup="true" CodeFile="RptStuVerifyMarks.aspx.cs" Inherits="Academic_RptStuVerifyMarks" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="container">
        <div class="heading">
            <h2>Verified Marks Report</h2>
        </div>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <table>
                    <tr>
                        <th>By Insititue</th>
                        <th>By Program</th>
                        <th>By Branch</th>
                        <th>By Sem</th>
                        <th>By Subject Type</th>
                    </tr>
                    <tr>
                        <td><asp:DropDownList ID="ddlIns" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlIns_SelectedIndexChanged"></asp:DropDownList></td>
                        <td><asp:DropDownList ID="ddlPgm" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlPgm_SelectedIndexChanged"></asp:DropDownList></td>
                        <td><asp:DropDownList ID="ddlBrn" runat="server" AutoPostBack="True"></asp:DropDownList></td>
                        <td><asp:DropDownList ID="ddlSem" runat="server" AutoPostBack="True"></asp:DropDownList></td>
                         <td><asp:DropDownList ID="ddlSubType" runat="server" AutoPostBack="True"></asp:DropDownList></td>
                        <td><asp:Button ID="btnView" runat="server" Text="View" OnClick="btnView_Click" /></td>
                    </tr>
                </table>
                <table>
                    <tr>
                        <td>
                            <asp:GridView ID="gvVerify" runat="server" AutoGenerateColumns="false" CssClass="gridDynamic" EmptyDataText="No Record(s) Found">
                                <Columns>
                                    <asp:TemplateField HeaderText="S.No">
                                        <ItemTemplate>
                                            <%#((GridViewRow)Container).RowIndex +1 %>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField HeaderText="Subject" DataField="SUBJECT" />
                                    <asp:BoundField HeaderText="Verified By" DataField="EMP_NAME" />
                                    <asp:BoundField HeaderText="Verified Date" DataField="INS_DT" DataFormatString="{00:dd/MM/yyyy}" />
                                    <asp:BoundField HeaderText="Pending Marks Status" DataField="PENDING_STS" />
                                    <asp:BoundField HeaderText="Exam Verify Status" DataField="EXAM_TYPE" />
                                </Columns>
                            </asp:GridView>
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</asp:Content>

