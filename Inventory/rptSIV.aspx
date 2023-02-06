<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/FullLength.master" AutoEventWireup="true" CodeFile="rptSIV.aspx.cs" Inherits="Inventory_rptSIV" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>

                    <table>
                        <tr>
                            <td style="margin-left:10px;">
                                <table>
                                    <tr>
                                        <th>BY YEAR</th>
                                        <th>BY STORE</th>
                                        <th>BY SIV NO.</th>                                         
                                        <th>BY INDENT NO.</th>
                                        <th>BY SIV ITEM</th> 
                                        <th>BY INDENTOR</th>
                                       

                                    </tr>
                                    <tr>

                                        <td>
                                            <asp:DropDownList ID="ddlYear" runat="server" Width="100px">
                                                <asp:ListItem Value="0">All</asp:ListItem>
                                                <asp:ListItem Value="2018-2019">2018-19</asp:ListItem>
                                                <asp:ListItem Value="2017-2018">2017-18</asp:ListItem>
                                                <asp:ListItem Value="2016-2017">2016-17</asp:ListItem>
                                                <asp:ListItem Value="2015-2016">2015-16</asp:ListItem>
                                                <asp:ListItem Value="2014-2015">2014-15</asp:ListItem>
                                                <asp:ListItem Value="2013-2014">2013-14</asp:ListItem>
                                                <asp:ListItem Value="2012-2013">2012-13</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                         <td>
                                            <asp:DropDownList ID="ddlSTORE" runat="server" Width="85px" OnSelectedIndexChanged="ddlSTORE_SelectedIndexChanged" AutoPostBack="true">
                                                 </asp:DropDownList>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlSIV" runat="server" Width="150px">
                                            </asp:DropDownList>
                                        </td>
                                       
                                        <td>
                                            <asp:DropDownList ID="ddlINDENT" runat="server" Width="150px">
                                            </asp:DropDownList>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlSIVITEM" runat="server" Width="150px">
                                            </asp:DropDownList></td>
                                        
                                         <td>
                                                        <asp:TextBox ID="txtIndentor" runat="server"></asp:TextBox>
                                                    </td>
                                                    <ajaxToolkit:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" CompletionSetCount="12"
                                                        EnableCaching="true" MinimumPrefixLength="1" ServiceMethod="GetEmployeeList"
                                                        ServicePath="~\AutoComplete.asmx" TargetControlID="txtIndentor" ContextKey="1,2,3,0">
                                                    </ajaxToolkit:AutoCompleteExtender>
                                    </tr>
                                    <tr>
                                      
                                        <th>BY DATE</th>

                                    </tr>
                                    <tr>
                                    
                                     
                                        <td>
                                            <asp:DropDownList ID="ddlDate" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlDate_SelectedIndexChanged">
                                                <asp:ListItem Value="0">All</asp:ListItem>
                                                <asp:ListItem Value="1">Less Than</asp:ListItem>
                                                <asp:ListItem Value="2">Greater Than</asp:ListItem>
                                                <asp:ListItem Value="3">Between</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtFromDT" runat="server" Width="90px"></asp:TextBox></td>
                                        <td>
                                            <asp:TextBox ID="txtToDT" runat="server" Width="90px"></asp:TextBox>
                                        </td>

                                        <td>
                                            <asp:Button ID="btnView" runat="server" Text="View" OnClick="btnView_Click"></asp:Button>
                                        </td>
                                        <td>
                                            <asp:Button ID="btnExport" runat="server" Text="Export To Excel" OnClicK="btnExport_Click" />
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <ajaxToolkit:MaskedEditExtender ID="ME1" runat="server" Enabled="True" TargetControlID="txtFromDT"
                                    MaskType="Date" Mask="99/99/9999">
                                </ajaxToolkit:MaskedEditExtender>
                                <ajaxToolkit:MaskedEditExtender ID="ME2" runat="server" TargetControlID="txtToDT"
                                    MaskType="Date" Mask="99/99/9999">
                                </ajaxToolkit:MaskedEditExtender>
                                <ajaxToolkit:CalendarExtender ID="CE1" runat="server" TargetControlID="txtFromDT"
                                    Format="dd/MM/yyyy">
                                </ajaxToolkit:CalendarExtender>
                                <ajaxToolkit:CalendarExtender ID="CalEx2" runat="server" TargetControlID="txtToDT"
                                    Format="dd/MM/yyyy">
                                </ajaxToolkit:CalendarExtender>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <div style="overflow: auto; width: 100%; height: 380px">
                                    <asp:GridView ID="gvSIV" runat="server" Width="98%"  AutoGenerateColumns="False"
                                        CssClass="gridDynamic" CellPadding="4">
                                        <Columns>
                                            <asp:TemplateField HeaderText="S.No.">
                                                <ItemTemplate>
                                                    <%# ((GridViewRow)Container).RowIndex + 1%>
                                                </ItemTemplate>
                                                <ItemStyle Width="15px"></ItemStyle>
                                            </asp:TemplateField>
                                         <asp:BoundField DataField="SIV_NO" HeaderText="SIV NO."><ItemStyle Width="170px"></ItemStyle> </asp:BoundField>
                                             <asp:BoundField HeaderText="SIV Date" DataField="SIV_Date"><ItemStyle Width="170px"></ItemStyle> </asp:BoundField>
                                            <asp:BoundField HeaderText="SIV By" DataField="SIV_Inseretd_By"><ItemStyle Width="170px"></ItemStyle> </asp:BoundField>
                                            <asp:BoundField DataField="Indent_No" HeaderText="Indent No.">
                                                <ItemStyle Width="80px"></ItemStyle>
                                            </asp:BoundField>
                                            <asp:BoundField DataField="Indent_Date" DataFormatString="{0:dd/MM/yyyy}" HeaderText="Indent Date">
                                                <ItemStyle Width="80px"></ItemStyle>
                                            </asp:BoundField>
                                               <asp:BoundField DataField="Indent_By" HeaderText="Indent By" DataFormatString="{0:N2}"><ItemStyle Width="170px"></ItemStyle> </asp:BoundField>
                                            <asp:BoundField DataField="Store" HeaderText="Store">
                                                <ItemStyle Width="170px"></ItemStyle>
                                            </asp:BoundField>
                                             <asp:BoundField HeaderText="SIV Item" DataField="SIV_Item" DataFormatString="{0:N2}"><ItemStyle Width="170px"></ItemStyle> </asp:BoundField>
                                            <asp:BoundField DataField="Requested_Qty" HeaderText="Requested Qty ">
                                                <ItemStyle Width="200px"></ItemStyle>
                                            </asp:BoundField>
                                            <asp:BoundField HeaderText="SIV Quantity" DataField="SIV_Quantity"><ItemStyle Width="170px"></ItemStyle> </asp:BoundField>

                                            </Columns>
                                    </asp:GridView>
                                </div>
                            </td>
                        </tr>
                        

                    </table>

                </ContentTemplate>
            </asp:UpdatePanel>

        </div>
</asp:Content>

