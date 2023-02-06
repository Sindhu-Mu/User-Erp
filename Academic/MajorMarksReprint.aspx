<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/FullLength.master" AutoEventWireup="true" CodeFile="MajorMarksReprint.aspx.cs" Inherits="Academic_MajorMarksReprint" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="container">
        <div class="heading">
            <h2>Reprint Major </h2>
        </div>
        <div>
            <table>
                <tr>
                    <td>
                        <table>
                            <tr>
                                <th>Examination</th>
                                <th>Institute
                                </th>
                                <th>Program
                                </th>
                                <th>Branch
                                </th>
                                <th>Semester
                                </th>
                                <th>Paper Code
                                </th>
                                <th>Date
                                </th>
                            </tr>
                            <tr>
                                <td>
                                    <asp:DropDownList ID="ddlExam" runat="server" Width="100px"></asp:DropDownList>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlIns" runat="server" OnSelectedIndexChanged="ddlIns_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlPrgm" Width="80px" runat="server" OnSelectedIndexChanged="ddlPrgm_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlBranch" runat="server"></asp:DropDownList>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlSem" runat="server" OnSelectedIndexChanged="ddlSem_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlPaper" runat="server" Width="80px"></asp:DropDownList>
                                </td>

                                <td>
                                    <asp:TextBox ID="txtDate" runat="server"></asp:TextBox>
                                </td>
                                <ajaxToolkit:CalendarExtender ID="CalendarExtender3" Format="dd/MM/yyyy" runat="server" TargetControlID="txtDate" Enabled="True"></ajaxToolkit:CalendarExtender>
                                <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender5" runat="server" Mask="99/99/9999" MaskType="Date"
                                    TargetControlID="txtDate">
                                </ajaxToolkit:MaskedEditExtender>
                                <td>
                                    <asp:Button ID="btnShow" runat="server" Text="Show" OnClick="btnShow_Click" />
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:GridView ID="gvDetail" runat="server" AutoGenerateColumns="false" CssClass="gridDynamic" OnRowCommand="gvDetail_RowCommand" DataKeyNames="MEM_ID">
                            <Columns>
                                <asp:TemplateField HeaderText="S.No.">
                                    <ItemTemplate>
                                        <%# ((GridViewRow)Container).RowIndex + 1%>
                                    </ItemTemplate>
                                    <ItemStyle Width="15px" />
                                </asp:TemplateField>
                                <asp:BoundField DataField="INSTITUTE" HeaderText="INSTITUTE"></asp:BoundField>
                                <asp:BoundField DataField="PROGRAM" HeaderText="PROGRAM"></asp:BoundField>
                                <asp:BoundField DataField="BRANCH" HeaderText="BRANCH"></asp:BoundField>
                                <asp:BoundField DataField="SEM" HeaderText="SEMESTER"></asp:BoundField>
                                <asp:BoundField DataField="PAPER_CODE" HeaderText="PAPER CODE"></asp:BoundField>
                                <asp:CommandField SelectText="RE-PRINT" ShowSelectButton="True" ButtonType="Button">
                                    <ControlStyle CssClass="btnblue"></ControlStyle>
                                </asp:CommandField>
                            </Columns>
                        </asp:GridView>
                    </td>
                </tr>
            </table>
        </div>
    </div>
</asp:Content>

