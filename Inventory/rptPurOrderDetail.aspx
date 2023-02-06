<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/FullLength.master" AutoEventWireup="true" CodeFile="rptPurOrderDetail.aspx.cs" Inherits="Inventory_rptPurOrderDetail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="container">
        <div class="heading">
            <h2>Purchase Order Detail
            </h2>
        </div>
        <div>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>

                    <table>
                        <tr>
                            <td style="margin-left:10px;">
                                <table>
                                    <tr>
                                        <th>BY YEAR</th>
                                        <th>BY PUR.NO.</th>
                                        <th>BY SORT</th>

                                    </tr>
                                    <tr>

                                        <td>
                                            <asp:DropDownList ID="ddlYear" runat="server" Width="100px" OnSelectedIndexChanged="ddlYear_SelectedIndexChanged" AutoPostBack="true">
                                               <asp:ListItem Value="0">All</asp:ListItem>
                                                 <asp:ListItem Value="2017-18">2017-18</asp:ListItem>
                                                <asp:ListItem Value="2016-17">2016-17</asp:ListItem>
                                                <asp:ListItem Value="2015-16">2015-16</asp:ListItem>
                                                <asp:ListItem Value="2014-15">2014-15</asp:ListItem>
                                                <asp:ListItem Value="2013-14">2013-14</asp:ListItem>
                                                <asp:ListItem Value="2012-13">2012-13</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlPOID" runat="server" Width="150px">
                                            </asp:DropDownList>
                                        </td>
                                       
                                        <td>
                                            <asp:DropDownList ID="ddlSort" runat="server" Width="85px">
                                                <asp:ListItem>Select</asp:ListItem>
                                                <asp:ListItem Value="PO_ID">PO.ID</asp:ListItem>
                                                <asp:ListItem Value="ORG_NAME">SUPPLIER</asp:ListItem>
                                                <asp:ListItem Value="PO_DATE">DATE</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>

                                    </tr>
                                    <tr>
                                        <th>BY SUPPLIER</th>
                                        <th>By ITEM</th>
                                        <th>BY DATE</th>

                                    </tr>
                                    <tr>
                                    
                                        <td>
                                            <asp:DropDownList ID="ddlSupplier" runat="server" Width="250px">
                                            </asp:DropDownList>
                                        </td>
                                            <td>
                                             <asp:DropDownList ID="ddlItem" runat="server" Width="250px">
                                            </asp:DropDownList>
                                        </td>
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
                                            <asp:Button ID="btnExport" runat="server" Text="Export To Excel" OnClick="btnExport_Click"/>
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
                            <td >
                                <div style="overflow: auto; width: 100%; height: 380px">
                                    <asp:GridView ID="gvPurchase" runat="server" Width="98%" DataKeyNames="PO_ID" ShowFooter="True" ShowHeader="True" AutoGenerateColumns="False"
                                        CssClass="gridDynamic" CellPadding="4" >
                                        <Columns>
                                            <asp:TemplateField HeaderText="S.No.">
                                                <ItemTemplate>
                                                    <%# ((GridViewRow)Container).RowIndex + 1%>
                                                </ItemTemplate>
                                                <ItemStyle Width="15px"></ItemStyle>
                                            </asp:TemplateField>
                                        
                                            <asp:BoundField DataField="PO_NO" HeaderText="PO NO">
                                                <ItemStyle Width="80px"></ItemStyle>
                                            </asp:BoundField>
                                            <asp:BoundField DataField="PO_DATE" DataFormatString="{0:dd/MM/yyyy}" HeaderText="PO DATE">
                                                <ItemStyle Width="80px"></ItemStyle>
                                            </asp:BoundField>
                                            <asp:BoundField DataField="EMP_NAME" HeaderText="CREATED  BY">
                                                <ItemStyle Width="170px"></ItemStyle>
                                            </asp:BoundField>
                                            <asp:BoundField DataField="ORG_NAME" HeaderText="SUPPLIER ">
                                                <ItemStyle Width="200px"></ItemStyle>
                                            </asp:BoundField>
                                           
                                             <asp:BoundField DataField="ITEM_NAME" HeaderText="ITEM NAME"><ItemStyle Width="170px"></ItemStyle> </asp:BoundField>                                            
                                                    <asp:BoundField HeaderText="SPECIFICATION" DataField="SPECIFICATION"><ItemStyle Width="170px"></ItemStyle> </asp:BoundField>
                                                    <asp:BoundField DataField="QTY" HeaderText="QUANTITY"><ItemStyle Width="170px"></ItemStyle> </asp:BoundField>
                                            <asp:BoundField DataField="UNIT_NAME" HeaderText="UNIT"><ItemStyle Width="170px"></ItemStyle> </asp:BoundField>
                                                    <asp:BoundField DataField="RATE" HeaderText="RATE" DataFormatString="{0:N2}"><ItemStyle Width="170px"></ItemStyle> </asp:BoundField>
                                                    
                                                    <asp:BoundField HeaderText="TAX(%)" DataField="TAX"><ItemStyle Width="170px"></ItemStyle> </asp:BoundField>
                                                    <asp:BoundField HeaderText="DISCOUNT(%)" DataField="DISCOUNT"><ItemStyle Width="170px"></ItemStyle> </asp:BoundField>
                                                    <asp:BoundField HeaderText="AMOUNT" DataField="AMOUNT" DataFormatString="{0:N2}"><ItemStyle Width="170px"></ItemStyle> </asp:BoundField>
                                             <asp:BoundField DataField="PO_AMOUNT" DataFormatString="{0:N2}" HeaderText="TOTAL AMOUNT">
                                                <ItemStyle HorizontalAlign="Right" Font-Bold="True" Width="100px"></ItemStyle>
                                            </asp:BoundField>
                                              <asp:BoundField HeaderText="BILL NO." DataField="BILL_NO"><ItemStyle Width="170px"></ItemStyle> </asp:BoundField>
                                            <asp:BoundField HeaderText="GRN NO." DataField="GRN_NO"><ItemStyle Width="170px"></ItemStyle> </asp:BoundField>
                                            <asp:BoundField HeaderText="GRN DATE" DataField="GRN_DATE"><ItemStyle Width="170px"></ItemStyle> </asp:BoundField>
                                           </Columns>
                                    </asp:GridView>
                                </div>
                            </td>
                        </tr>
                        

                    </table>

                </ContentTemplate>
            </asp:UpdatePanel>

        </div>
    </div>
</asp:Content>


