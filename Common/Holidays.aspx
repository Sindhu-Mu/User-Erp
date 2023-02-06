<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/FullLength.master" AutoEventWireup="true" CodeFile="Holidays.aspx.cs" Inherits="Common_Holidays" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="container">
        <div class="heading">
            <h2>Holidays</h2>
        </div>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <table>
                    <tr>
                        <td valign="top">
                            <table>
                                <tr>
                                    <th>Institution</th>
                                    <td>
                                        <asp:DropDownList ID="ddlIns" runat="server" AutoPostBack="True"
                                            OnSelectedIndexChanged="ddlIns_SelectedIndexChanged"
                                            Width="200px">
                                        </asp:DropDownList></td>
                                    <th>Year</th>
                                    <td>
                                        <asp:DropDownList ID="ddlHolidayYear" runat="server" AutoPostBack="True"
                                            OnSelectedIndexChanged="ddlHolidayYear_SelectedIndexChanged"
                                            Width="200px">
                                        </asp:DropDownList></td>
                                    <td></td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:GridView ID="gvHoliday" runat="server" AutoGenerateColumns="False"
                                CellPadding="4" Height="79px"
                                CssClass="gridDynamic">
                                <Columns>
                                    <asp:TemplateField HeaderText="S.No.">
                                        <ItemTemplate>
                                            <%# ((GridViewRow)Container).RowIndex + 1%>
                                        </ItemTemplate>
                                        <ItemStyle Width="15px" />
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="HOLIDAY_DT" DataFormatString="{0:dd/MM/yyyy}" HeaderText="Date"></asp:BoundField>
                                    <asp:BoundField DataField="DayName" HeaderText="Day Name"></asp:BoundField>
                                    <asp:BoundField DataField="HOLIDAY_NAME" HeaderText="Holiday" ItemStyle-Width="450px"></asp:BoundField>
                                    <asp:BoundField DataField="DAY_TYPE_NAME" HeaderText="For" ItemStyle-Width="120px"></asp:BoundField>
                                     <asp:BoundField DataField="TYPE" HeaderText="Holiday Type" ItemStyle-Width="120px"></asp:BoundField>
                                </Columns>

                             
                            </asp:GridView>
                        </td>
                        
                        
                    </tr>
                    <tr>
                        <th> <span style="color:black">*</span> Subject on change of visibility of moon</th>
                    </tr>
                    <tr>

<%--<th> <span style="color:black">**</span> For Restricted Holidays-The faculty/staff members of the University may avail any two of these restricted Holidays during the calendar Year 2016.</th>--%>
                    </tr>
                </table>
            </ContentTemplate>
        </asp:UpdatePanel>

    </div>
</asp:Content>

