<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/FullLength.master" AutoEventWireup="true" CodeFile="PA03_Report.aspx.cs" Inherits="Appraisal_PA03_Report" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="container">
        <div class="heading">
            <h2>Appraisal Main
            </h2>
        </div>
        <div>
            <table >
                <tr>
                    <td>
                        <table>
                            <tr>
                                <th>By Institute
                                </th>
                                <th>By Department</th>
                                <th>By Employee
                                </th>
                                <th>By Status
                                </th>
                            </tr>
                            <tr>
                                <td>
                                    <asp:DropDownList ID="ddlIns" runat="server" Width="180px" OnSelectedIndexChanged="ddlIns_SelectedIndexChanged" AutoPostBack="True">
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlDept" runat="server" Width="180px">
                                    </asp:DropDownList>
                                </td>

                                <td>
                                    <asp:TextBox ID="txtEmp" runat="server" Width="180px">
                                    </asp:TextBox>
                                    <ajaxToolkit:AutoCompleteExtender ID="autoComplete1" runat="server" CompletionInterval="500"
                                        CompletionSetCount="12" ContextKey="1,2,3,0" EnableCaching="true" MinimumPrefixLength="1"
                                        ServiceMethod="GetEmployeeList" ServicePath="~\AutoComplete.asmx" TargetControlID="txtEmp">
                                    </ajaxToolkit:AutoCompleteExtender>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlStatus" runat="server" Width="180px">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>

                <tr>
                    <th>By Start Date 
                    </th>
                </tr>
                <tr>
                    <td>
                        <table style="margin: 0px; border: 0px;">
                            <tr>
                                <td>
                                    <asp:DropDownList ID="ddlStartDt" runat="server" Width="180px" AutoPostBack="True" OnSelectedIndexChanged="DateType_Change">
                                        <asp:ListItem Value="0" Text="All"></asp:ListItem>
                                        <asp:ListItem Value="1" Text="Less Than"></asp:ListItem>
                                        <asp:ListItem Value="2" Text="Greater Than"></asp:ListItem>
                                        <asp:ListItem Value="3" Text="Between"></asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtRStartSD" runat="server"></asp:TextBox>
                                    <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtRStartSD" Format="dd/MM/yyyy">
                                    </ajaxToolkit:CalendarExtender>
                                    <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender3" runat="server" Mask="99/99/9999" MaskType="Date"
                                        TargetControlID="txtRStartSD">
                                    </ajaxToolkit:MaskedEditExtender>
                                    &nbsp;
                                </td>
                                <td>
                                    <asp:TextBox ID="txtRStartED" runat="server"></asp:TextBox>
                                    <ajaxToolkit:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtRStartED" Format="dd/MM/yyyy">
                                    </ajaxToolkit:CalendarExtender>
                                    <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender1" runat="server" Mask="99/99/9999" MaskType="Date"
                                        TargetControlID="txtRStartED">
                                    </ajaxToolkit:MaskedEditExtender>
                                    &nbsp;
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <th>By End Date 
                    </th>
                </tr>
                <tr>
                    <td>
                        <table style="margin: 0px; border: 0px;">
                            <tr>
                                <td>
                                    <asp:DropDownList ID="ddlEndDate" runat="server" Width="180px" AutoPostBack="True" OnSelectedIndexChanged="DateType_Change">
                                        <asp:ListItem Value="0" Text="All"></asp:ListItem>
                                        <asp:ListItem Value="1" Text="Less Than"></asp:ListItem>
                                        <asp:ListItem Value="2" Text="Greater Than"></asp:ListItem>
                                        <asp:ListItem Value="3" Text="Between"></asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtREndSD" runat="server"></asp:TextBox>
                                    <ajaxToolkit:CalendarExtender ID="CalendarExtender3" runat="server" TargetControlID="txtREndSD" Format="dd/MM/yyyy">
                                    </ajaxToolkit:CalendarExtender>
                                    <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender2" runat="server" Mask="99/99/9999" MaskType="Date"
                                        TargetControlID="txtREndSD">
                                    </ajaxToolkit:MaskedEditExtender>
                                    &nbsp;
                                </td>
                                <td>
                                    <asp:TextBox ID="txtREndED" runat="server"></asp:TextBox>
                                    <ajaxToolkit:CalendarExtender ID="CalendarExtender4" runat="server" TargetControlID="txtREndED" Format="dd/MM/yyyy">
                                    </ajaxToolkit:CalendarExtender>
                                    <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender4" runat="server" Mask="99/99/9999" MaskType="Date"
                                        TargetControlID="txtREndED">
                                    </ajaxToolkit:MaskedEditExtender>
                                    &nbsp;
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td>
                        <table>
                            <tr>
                                <th>By Year
                                </th>
                                <th>By Semester</th>

                            </tr>
                            <tr>
                                <td>
                                    <asp:DropDownList ID="ddlYear" runat="server" Width="180px">
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlSem" runat="server" Width="180px">
                                        <asp:ListItem Value="." Text="Select"></asp:ListItem>
                                        <asp:ListItem Value="0" Text="Odd"></asp:ListItem>
                                        <asp:ListItem Value="1" Text="Even"></asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td></td><td> <asp:Button ID="btnShow" runat="server" Text="Show" OnClick="btnShow_Click" /></td>
                            </tr>
                        </table>
                    </td>
                </tr>
               
                <tr>
                    <td>
                        <div style="width: 100%; overflow: auto">
                            <asp:GridView ID="gvReportInfo" runat="server" AutoGenerateColumns="False" CssClass="gridDynamic" DataKeyNames="PA03_FAC_ID" HeaderStyle-CssClass="GVFixedHeader" Width="97%" EmptyDataText="No Record Found">
                                <Columns>
                                    <asp:TemplateField HeaderText="S.No.">
                                        <ItemTemplate>
                                            <%# ((GridViewRow)Container).RowIndex + 1%>.
                                        </ItemTemplate>
                                        <ItemStyle Width="30px" />
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="EMP_ID" HeaderText="Emp.Code"></asp:BoundField>
                                    <asp:BoundField DataField="EMP_NAME" HeaderText="Faculty Name"></asp:BoundField>
                                  <%--  <asp:BoundField DataField="PA03_FAC_SEM_TYPE" HeaderText="Semester"></asp:BoundField>--%>
                                    <asp:BoundField DataField="PA03_FAC_YEAR" HeaderText="Year"></asp:BoundField>
                                    <asp:BoundField DataField="DOJ" HeaderText="DOJ" DataFormatString="{0: dd/MM/yyy}"></asp:BoundField>
                                    <asp:BoundField DataField="DES_VALUE" HeaderText="Designation"></asp:BoundField>
                                    <asp:BoundField DataField="DEPT_VALUE" HeaderText="Department"></asp:BoundField>
                                    <asp:BoundField DataField="INS_VALUE" HeaderText="Institution"></asp:BoundField>
                                    <asp:BoundField DataField="PENDING" HeaderText="Pending With"></asp:BoundField>



                                    <asp:HyperLinkField DataNavigateUrlFields="PA03_FAC_ID" HeaderText="Report"
                                        DataNavigateUrlFormatString="~/Appraisal/PA03.aspx?id={0}" Text="Detail" Target="_blank" />
                                </Columns>

                                <HeaderStyle CssClass="GVFixedHeader"></HeaderStyle>
                            </asp:GridView>
                        </div>
                    </td>
                </tr>
                <tr id="trPrint" runat="server" visible="false">
                    <td>
                        <asp:Button ID="btnPrint" runat="server" Text="Print" OnClick="btnPrint_Click" />
                        <asp:Button ID="btnExport" runat="server" Text="Export To Excel" OnClick="btnExport_Click" />
                    </td>
                </tr>
            </table>
        </div>
    </div>
</asp:Content>

