<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/FullLength.master" AutoEventWireup="true" CodeFile="EmpIdCard.aspx.cs" Inherits="HR_EmpIdCard" %>

<%@ Register Src="~/Control/Employee.ascx" TagPrefix="uc1" TagName="Employee" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="content" style="padding: 40px;">
        <h2 >Employee Id Card</h2>

        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <table>
                    <tr>
                        <td>Employee Code</td>
                        <td>
                            <asp:TextBox ID="txtCode" runat="server" /></td>
                        <td>
                            <asp:Button ID="btnView" runat="server" Text="View" OnClick="btnView_Click" /></td>
                        <td>
                            <asp:Button ID="btnPrint" runat="server" Text="Print" OnClick="btnPrint_Click" /></td>
                    </tr>

                </table>
                <uc1:Employee runat="server" ID="Employee" />
                <asp:GridView ID="gvDetail" runat="server" AutoGenerateColumns="False" CssClass="gridDynamic">
                    <Columns>
                        <asp:TemplateField HeaderText="S.No.">
                            <ItemTemplate>
                                <%# ((GridViewRow)Container).RowIndex + 1%>
                            </ItemTemplate>
                            <ItemStyle Width="15px" />
                        </asp:TemplateField>
                        <asp:BoundField HeaderText="Printed On" DataField="IN_DT" />
                        <asp:BoundField HeaderText="Printed By" DataField="IN_BY" />
                        <asp:BoundField HeaderText="Remark" DataField="CRD_STATUS" />

                    </Columns>
                </asp:GridView>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</asp:Content>

