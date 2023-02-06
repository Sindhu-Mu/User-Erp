<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/FullLength.master" AutoEventWireup="true" CodeFile="rptSto_Indent.aspx.cs" Inherits="Inventory_rptSto_Indent" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script lang="javascript" type="text/javascript">
        function CheckControl(ctrl) {
            if (bTrim(document.getElementById(ctrl).value) == "" || bTrim(document.getElementById(ctrl).value) == "Select" || bTrim(document.getElementById(ctrl).value) == ".") {
                document.getElementById(ctrl).style.backgroundColor = "#fc6";
                return false;
            }
            else {
                document.getElementById(ctrl).style.backgroundColor = "#fff";
                return true;
            }
        }
        function validateView() {
            var flag = true;
            var msg = "", ctrl = "";
            if (!CheckControl("<%=ddlStore.ClientID%>")) {
                msg += "- Select Store from List\n";
                if (ctrl == "") {
                    ctrl = "<%=ddlStore.ClientID%>";
                }
                flag = false;
            }
            if (msg != "")
                alert(msg);
            if (ctrl != "")
                document.getElementById(ctrl).focus();
            return flag;
        }
     </script>
    <div class="container">
        <div class="heading">
            <h2>Store Indent</h2>
        </div>
        <div>
            <table id="tblColumns">
                <tr id="trModify" runat="server">
                    <td>
                        <table>
                            <tr>
                                <td>
                                    <div style="width: 95%">
                                        <table>
                                            <tr style="padding-bottom: 2px">
                                                <th>BY STORE

                                                </th>
                                                <th>BY DEPARTMENT
                                                </th>
                                                <th>BY INDENT NO

                                                </th>
                                                
                                                <th>BY ITEM

                                                </th>

                                                <th>BY STATUS

                                                </th>
                                                <th>FROM DATE

                                                </th>

                                                <th>TO DATE</th>
                                                <th>BY SORT</th>

                                                <tr>
                                                    <td style="padding-right: 4px; width: 150px;">
                                                        <asp:DropDownList ID="ddlStore" runat="server" Width="110px" OnSelectedIndexChanged="ddlStore_SelectedIndexChanged" AutoPostBack="true">
                                                        </asp:DropDownList></td>
                                                    <td style="padding-right: 4px;">&nbsp;<asp:DropDownList ID="ddlDept" runat="server" Width="150px" OnSelectedIndexChanged="ddlDept_SelectedIndexChanged">
                                                    </asp:DropDownList></td>
                                                    <td style="padding-right: 2px">&nbsp;<asp:DropDownList ID="ddlIndent" runat="server" Width="80px">
                                                    </asp:DropDownList></td>
                                                    
                                                    <td style="padding-right: 4px; width: 150px">
                                                        <asp:DropDownList ID="ddlItems" runat="server" Width="150px">
                                                        </asp:DropDownList></td>
                                                    <td style="padding-right: 4px">
                                                        <asp:DropDownList ID="ddlStatus" runat="server" Width="100px">
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtFromDT" runat="server" Width="80px"></asp:TextBox>
                                                    </td>

                                                    <td>
                                                        <asp:TextBox ID="txtToDT" runat="server" Width="80px"></asp:TextBox>
                                                    </td>

                                                    <td>&nbsp; &nbsp; &nbsp;  &nbsp;  &nbsp;  
                                                    <asp:DropDownList ID="ddlSort" runat="server" Width="50px">
                                                        <asp:ListItem Value=".">All</asp:ListItem>
                                                        <asp:ListItem Value="INS_DEPT_INF.DEPT_VALUE">DEPT</asp:ListItem>
                                                        <asp:ListItem Value=" A.IND_ID">INDENT ID</asp:ListItem>
                                                        <asp:ListItem Value="INV_STORE_MASTER.STO_NAME">STORE</asp:ListItem>
                                                        <%--<asp:ListItem Value="INDENT_STATUS">STATUS</asp:ListItem>--%>
                                                        <asp:ListItem Value="INV_STO_IND_INF.INS_DATE">DATE</asp:ListItem>
                                                    </asp:DropDownList>
                                                    </td>
                                                    <td style="padding-left: 4px">
                                                        <asp:Button ID="btnView" runat="server" CssClass="btnblue" Height="33px"
                                                            Text="View" Width="70px" OnClick="btnView_Click" />
                                                    </td>
                                                </tr>
                                        </table>
                                    </div>
                                </td>
                            </tr>


                            <tr>
                                <td style="padding-top: 4px">

                                    <ajaxToolkit:MaskedEditExtender ID="ME1" runat="server" Mask="99/99/9999"
                                        MaskType="Date" TargetControlID="txtFromDT" Enabled="True" />

                                    <ajaxToolkit:MaskedEditExtender ID="ME2" runat="server" Mask="99/99/9999"
                                        MaskType="Date" TargetControlID="txtToDT" />
                                    <ajaxToolkit:CalendarExtender ID="CE1" runat="server" Format="dd/MM/yyyy"
                                        TargetControlID="txtFromDT">
                                    </ajaxToolkit:CalendarExtender>
                                    <ajaxToolkit:CalendarExtender ID="CalEx2" runat="server" Format="dd/MM/yyyy"
                                        TargetControlID="txtToDT">
                                    </ajaxToolkit:CalendarExtender>
                                    &nbsp;&nbsp;
                                </td>
                            </tr>


                            <tr>
                                <td>
                                    <div style="height: 250px; overflow: auto; width: 95%">
                                        <asp:GridView ID="gvDetail" runat="server" Width="93%" AutoGenerateColumns="False" CellPadding="4" ShowHeader="true" DataKeyNames="IND_ID" OnRowCommand="gvDetail_RowCommand" EmptyDataText="No Record Found">
                                            <Columns>
                                                <asp:TemplateField HeaderText="S#">
                                                    <ItemTemplate>
                                                        <%# ((GridViewRow)Container).RowIndex + 1%>
                                                    </ItemTemplate>
                                                    <ItemStyle Width="20px" />
                                                </asp:TemplateField>
                                                <asp:BoundField DataField="DEPT_VALUE" HeaderText="DEPARTMENT">
                                                    <ItemStyle Width="150px" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="IND_CAL_ID" HeaderText="INDENT ID">
                                                    <ItemStyle Width="90px" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="STO_NAME" HeaderText="FROM STORE">
                                                    <ItemStyle Width="120px" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="INS_DATE" DataFormatString="{0:dd/MM/yyyy}" HeaderText="INSERT DATE">
                                                    <ItemStyle Width="100px" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="EMP_NAME" HeaderText="INSERT BY">
                                                    <ItemStyle Width="160px" />
                                                </asp:BoundField>

                                                <asp:BoundField DataField="IND_STEP_VALUE" HeaderText="STATUS">
                                                    <ItemStyle Width="100px" />
                                                </asp:BoundField>
                                                <asp:ButtonField ButtonType="Button" CommandName="DETAIL" HeaderText="DETAIL" Text="DETAIL">
                                                    <ControlStyle CssClass="btnblue" />
                                                    <ItemStyle Width="60px" />
                                                </asp:ButtonField>
                                            </Columns>
                                            <HeaderStyle ForeColor="Crimson"></HeaderStyle>
                                            <SelectedRowStyle ForeColor="#FFC0C0" />
                                        </asp:GridView>
                                    </div>
                                </td>
                            </tr>

                        </table>
                    </td>
                </tr>



                <tr id="trDetail" runat="server">
                    <td>
                        <table>
                            <tr>
                                <td>Item Detail 
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:GridView ID="gvItemDetail" runat="server" AutoGenerateColumns="False" DataKeyNames="ITEM_ID,DEPT_ID" OnRowCommand="gvItemDetail_RowCommand" EmptyDataText="No Record Found">
                                        <Columns>
                                            <asp:TemplateField HeaderText="S#">
                                                <ItemTemplate>
                                                    <%# ((GridViewRow)Container).RowIndex + 1%>
                                                </ItemTemplate>
                                                <ItemStyle Width="20px" />
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="ITEM_NAME" HeaderText="Item Name" ReadOnly="True" />
                                            <asp:TemplateField HeaderText="Req.Qty">
                                                <EditItemTemplate>
                                                    <asp:TextBox ID="txtQty" runat="server" CssClass="textbox" Text='<%# Bind("REQ_QTY") %>'
                                                        Width="70px"></asp:TextBox>
                                                </EditItemTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("REQ_QTY") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="UNIT_NAME" HeaderText="Unit" ReadOnly="True" />
                                            <asp:BoundField DataField="ISD_QTY" HeaderText="Issued Qty" ReadOnly="True" />
                                            <%--<asp:BoundField HeaderText="Urgency Level" ReadOnly="True" DataField="URGENCY" />--%>
                                            <asp:ButtonField ButtonType="Button" HeaderText="Previous" Text="Previous" CommandName="Previous">
                                                <ControlStyle CssClass="btnblue" />
                                            </asp:ButtonField>
                                        </Columns>
                                        <%--<HeaderStyle ForeColor="White" BackColor="#6B696B" Font-Bold="True" />
                                        <RowStyle BackColor="#F7F7DE" />
                                        <FooterStyle BackColor="#CCCC99" />
                                        <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
                                        --%><SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
                                        <%--<AlternatingRowStyle BackColor="White" />--%>
                                    </asp:GridView>
                                </td>

                            </tr>
                            <tr id="trPrevious" runat="server">
                                <td>
                                    <table>
                                        <tr>
                                            <td>Previous Detail 

                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:GridView ID="gvPrevious" runat="server" AutoGenerateColumns="False" EmptyDataText="No Record Found" CssClass="gridDynamic">
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="S#">
                                                            <ItemTemplate>
                                                                <%# ((GridViewRow)Container).RowIndex + 1%>
                                                            </ItemTemplate>
                                                            <ItemStyle Width="20px" />
                                                        </asp:TemplateField>
                                                        <asp:BoundField DataField="IND_CAL_ID" HeaderText="INDENT ID" />
                                                        <asp:BoundField DataField="DATE" HeaderText="INDENT DATE" DataFormatString="{0:dd/MM/yyyy}" />
                                                        <asp:BoundField DataField="REQ_QTY" HeaderText="INDENT QTY" />
                                                        <asp:BoundField DataField="SIV_CAL_ID" HeaderText="SIV ID" />
                                                        <asp:BoundField DataField="ISSUE_DATE" HeaderText="ISSUED DATE" />
                                                        <asp:BoundField DataField="ISD_QTY" HeaderText="ISSUED QTY" />
                                                    </Columns>
                                                    <%--<HeaderStyle ForeColor="#E7E7FF" BackColor="#4A3C8C" Font-Bold="True" />--%>
                                                    <%--<RowStyle BackColor="#DEDFDE" ForeColor="Black" />--%>
                                                    <FooterStyle BackColor="#C6C3C6" ForeColor="Black" />
                                                    <%--<PagerStyle BackColor="#C6C3C6" ForeColor="Black" HorizontalAlign="Right" />--%>
                                                    <SelectedRowStyle BackColor="#9471DE" Font-Bold="True" ForeColor="White" />
                                                </asp:GridView>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>


            </table>
        </div>
    </div>
</asp:Content>

