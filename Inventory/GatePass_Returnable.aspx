<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/FullLength.master" AutoEventWireup="true" CodeFile="GatePass_Returnable.aspx.cs" Inherits="Inventory_GatePass_Returnable" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <script lang="javascript" type="text/javascript">
        function CheckDate(ctrl) {
            var dt = document.getElementById(ctrl).value;
            if (isDatecheck(dt, "dd/MM/yyyy") == false) {
                document.getElementById(ctrl).style.backgroundColor = "#fc6";
                return false;
            }
            else
                document.getElementById(ctrl).style.backgroundColor = "#fff";
            return true;
        }
        function CheckControl(ctrl) {
            if (bTrim(document.getElementById(ctrl).value) == "" || bTrim(document.getElementById(ctrl).value) == "." || bTrim(document.getElementById(ctrl).value) == "Select") {
                document.getElementById(ctrl).style.backgroundColor = "#fc6";
                return false;
            }
            else
                document.getElementById(ctrl).style.backgroundColor = "#fff";
            return true;
        }
        function validate() {
            var flag = true;
            var msg = "", ctrl = "";
            if (!CheckControl("<%=ddlGatePass.ClientID%>")) {
                 msg += "- Select Gate Pass from List\n";
                 if (ctrl == "")
                     ctrl = "<%=ddlGatePass.ClientID%>";
                flag = false;
            }
            if (!CheckControl("<%=txtRcvBy.ClientID%>")) {
                 msg += "- Enter Received By \n";
                 if (ctrl == "")
                     ctrl = "<%=txtRcvBy.ClientID%>";
                flag = false;
            }
            if (!CheckControl("<%=txtBillNo.ClientID%>")) {
                 msg += "- Enter Bill No. \n";
                 if (ctrl == "")
                     ctrl = "<%=txtBillNo.ClientID%>";
                flag = false;
            }
            if (!CheckControl("<%=txtChallanNo.ClientID%>")) {
                 msg += "- Enter Challan No. \n";
                 if (ctrl == "")
                     ctrl = "<%=txtChallanNo.ClientID%>";
                flag = false;
            }
            if (!CheckControl("<%=txtDate.ClientID%>")) {
                 msg += "- Enter Date \n";
                 if (ctrl == "")
                     ctrl = "<%=txtDate.ClientID%>";
                flag = false;
            }


            if (msg != "") alert(msg);
            if (ctrl != "")
                document.getElementById(ctrl).focus();
            return flag;
        }
    </script>
    <div class="container">
        <div class="heading">
            <h2>Returnable Gate-Pass</h2>
        </div>
        <div>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <table>
                        <tr>
                            <td>
                                <table>
                                    <tr>
                                        <th>Pending Gate-Pass<span class="required">*</span>
                                        </th>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:DropDownList ID="ddlGatePass" AutoPostBack="true" runat="server"  Width="150px" OnSelectedIndexChanged="ddlGatePass_SelectedIndexChanged"></asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>

                                            <div style="border-collapse: collapse; border-spacing: 0px; overflow: auto; width: 100%">
                                                <asp:GridView ID="gridRtrnGatePass" runat="server" AutoGenerateColumns="false" DataKeyNames="ITEM_ID" CssClass="gridDynamic" AlternatingRowStyle-CssClass="alt" Width="100%" EmptyDataText="No record found">
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="S#">
                                                            <ItemTemplate>
                                                                <%# ((GridViewRow)Container).RowIndex + 1%>.
                                                            </ItemTemplate>
                                                            <ItemStyle Width="10px" />
                                                        </asp:TemplateField>
                                                        <asp:BoundField HeaderText="Item Name" DataField="ITEM_NAME">
                                                            <ItemStyle HorizontalAlign="Left" />
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                        </asp:BoundField>

                                                        <asp:BoundField HeaderText="Sent Quantity" DataField="SENT_QTY">
                                                            <ItemStyle Width="40px" />
                                                        </asp:BoundField>
                                                        
                                                        <asp:TemplateField HeaderText="Received Quantity">
                                                            <ItemTemplate>
                                                                <cc1:NumericTextBox ID="txtQuantity" runat="server" Width="50px" placeholder="Quantity" Text='<%#Eval("QTY") %>' required="required" Style="text-align: center">
                                                                </cc1:NumericTextBox>
                                                            </ItemTemplate>
                                                            <ItemStyle Width="10px" />
                                                        </asp:TemplateField>
                                                       
                                                    </Columns>
                                                </asp:GridView>
                                            </div>

                                        </td>
                                    </tr>

                                </table>
                            </td>
                            <td style="width: 1px; height: 100%; border-left: 1px solid red"></td>
                            <td style="width: 50%; vertical-align: top">
                                <table>
                                    <tr>
                                        <td>
                                            <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                                <ContentTemplate>
                                                    <table>
                                                        <tr>
                                                            <td>
                                                                <table>
                                                                    <tr>
                                                                        <th>Details<span class="expected">*</span>
                                                                        </th>
                                                                        <th>Date<span class="required">*</span>
                                                                        </th>
                                                                        <th>Received By<span class="required">*</span>
                                                                        </th>
                                                                       
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                            <asp:TextBox ID="txtGAtePassDetails" runat="server" MaxLength="50" Width="200px" placeholder="Details" CssClass="textbox"></asp:TextBox>
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="txtDate" runat="server" Width="85px" required="required" CssClass="textbox"></asp:TextBox>
                                                                            <ajaxToolkit:CalendarExtender ID="cal1" runat="server" TargetControlID="txtDate" Format="dd/MM/yyyy" PopupPosition="TopLeft">
                                                                            </ajaxToolkit:CalendarExtender>
                                                                            <ajaxToolkit:MaskedEditExtender ID="me1" runat="server" Mask="99/99/9999" MaskType="Date"
                                                                                TargetControlID="txtDate">
                                                                            </ajaxToolkit:MaskedEditExtender>

                                                                        </td>
                                                                        <td>
                                                                           
                                                                             <asp:TextBox ID="txtRcvBy" runat="server" Width="200px"></asp:TextBox></td>

                                                                        </td>
                                                                        
                                                                    </tr>
                                                        <tr>
                                                            <td>
                                                                 <ajaxToolkit:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" CompletionSetCount="12"
                                                        EnableCaching="true" MinimumPrefixLength="1" ServiceMethod="GetEmployeeList"
                                                        ServicePath="~\AutoComplete.asmx" TargetControlID="txtRcvBy" ContextKey="1,2,3,0">
                                                    </ajaxToolkit:AutoCompleteExtender>
                                                            </td>
                                                        </tr>
                                                                </table>
                                                            </td>
                                                        </tr>
                                                        <tr>

                                                            <td>
                                                                <table>
                                                                    <tr>
                                                                        <th>Bill No.<span class="expected">*</span>
                                                                        </th>
                                                                        <th>Challan No.<span class="required">*</span>
                                                                        </th>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                            <asp:TextBox ID="txtBillNo" placeholder="Bill" runat="server" CssClass="textbox"></asp:TextBox>
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="txtChallanNo" placeholder="Challan" runat="server" CssClass="textbox" required="required"></asp:TextBox>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </td>
                                    </tr>

                                    <tr>
                                        <td>
                                            <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" />
                                        </td>
                                    </tr>
                                </table>

                            </td>
                        </tr>
                    </table>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
</asp:Content>

