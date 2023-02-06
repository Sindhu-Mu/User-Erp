<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/FullLength.master" AutoEventWireup="true" CodeFile="PurOrder.aspx.cs" Inherits="Inventory_PurOrder" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
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
            if (bTrim(document.getElementById(ctrl).value) == "" || bTrim(document.getElementById(ctrl).value) == "Select" || bTrim(document.getElementById(ctrl).value) == ".") {
                document.getElementById(ctrl).style.backgroundColor = "#fc6";
                return false;
            }
            else
                document.getElementById(ctrl).style.backgroundColor = "#fff";
            return true;
        }

        function validateDate() {
            var flag = true;
            var msg = "", ctrl = "";
            if (!CheckControl("<%=txtDate.ClientID%>")) {
                msg += "- Enter date.\n";
                if (ctrl == "")
                    ctrl = "<%=txtDate.ClientID%>";
                flag = false;
            }
            if (msg != "") alert(msg);
            if (ctrl != "")
                document.getElementById(ctrl).focus();
            return flag;

        }

        function validate() {
            var flag = true;
            var msg = "", ctrl = "";
            if (!CheckControl("<%=ddlItem.ClientID%>")) {
                msg += "- Select Item from List\n";
                if (ctrl == "")
                    ctrl = "<%=ddlItem.ClientID%>";
                flag = false;
            }
            if (!CheckControl("<%=txtQty.ClientID%>")) {
                msg += "- Enter Required Quantity \n";
                if (ctrl == "")
                    ctrl = "<%=txtQty.ClientID%>";
                flag = false;
            }
            if (!CheckControl("<%=txtrate.ClientID%>")) {
                msg += "- Enter rate of item \n";
                if (ctrl == "")
                    ctrl = "<%=txtrate.ClientID%>";
                flag = false;
            }
            if (!CheckControl("<%=txtTax.ClientID%>")) {
                msg += "- Enter Tax \n";
                if (ctrl == "")
                    ctrl = "<%=txtTax.ClientID%>";
                flag = false;
            }
            if (!CheckControl("<%=txtdisc.ClientID%>")) {
                msg += "- Enter Discount \n";
                if (ctrl == "")
                    ctrl = "<%=txtdisc.ClientID%>";
                flag = false;
            }
            if (msg != "") alert(msg);
            if (ctrl != "")
                document.getElementById(ctrl).focus();
            return flag;
        }

        function validat() {
            var flag = true;
            var msg = "", ctrl = "";
            if (!CheckControl("<%=ddlTerm.ClientID%>")) {
                msg += "- Select Term from List\n";
                if (ctrl == "")
                    ctrl = "<%=ddlTerm.ClientID%>";
                flag = false;
            }
            if (!CheckControl("<%=txtCondition.ClientID%>")) {
                msg += "- Enter Condition \n";
                if (ctrl == "")
                    ctrl = "<%=txtCondition.ClientID%>";
                flag = false;
            }
            if (msg != "") alert(msg);
            if (ctrl != "")
                document.getElementById(ctrl).focus();
            return flag;
        }

        function validation() {
            var flag = true;
            var msg = "", ctrl = "";
            if (!CheckControl("<%=ddlPurReq.ClientID%>")) {
                msg += "- Select Purchase requisition fom list \n";
                if (ctrl == "")
                    ctrl = "<%=ddlPurReq.ClientID%>";
                flag = false;
            }
            if (!CheckControl("<%=ddlFAN.ClientID%>")) {
                msg += "- Select FAN No from list \n";
                if (ctrl == "")
                    ctrl = "<%=ddlFAN.ClientID%>";
                flag = false;
            }
           
            if (!CheckControl("<%=ddlStore.ClientID%>")) {
                msg += "- Select Store from list \n";
                if (ctrl == "")
                    ctrl = "<%=ddlStore.ClientID%>";
                flag = false;
            }
            if (!CheckControl("<%=ddlSupp.ClientID%>")) {
                msg += "- Select Supplier from list \n";
                if (ctrl == "")
                    ctrl = "<%=ddlSupp.ClientID%>";
                flag = false;
            }

            if (document.getElementById("<%=ddlRef.ClientID%>").value == "1") {
                if (!CheckControl("<%=txtrefNo.ClientID%>")) {
                    msg += "- Enter Refrence No\n";
                    if (ctrl == "")
                        ctrl = "<%=txtrefNo.ClientID%>";
                    flag = false;
                }
            }
            if (!CheckControl("<%=txtdiscount.ClientID%>")) {
                msg += "- Enter Discount on total amount\n";
                if (ctrl == "")
                    ctrl = "<%=txtdiscount.ClientID%>";
                flag = false;
            }
            if (!CheckControl("<%=txtOtherCharges.ClientID%>")) {
                msg += "- Enter Other Charges of this order\n";
                if (ctrl == "")
                    ctrl = "<%=txtOtherCharges.ClientID%>";
                flag = false;
            }
            if (msg != "") alert(msg);
            if (ctrl != "")
                document.getElementById(ctrl).focus();
            return flag;
        }
        function validatPay() {
            var flag = true;
            var msg = "", ctrl = "";

            if (!CheckControl("<%=txtPayment.ClientID%>")) {
                msg += "- Enter Payment Percentage \n";
                if (ctrl == "")
                    ctrl = "<%=txtPayment.ClientID%>";
                flag = false;
            }
            if (!CheckControl("<%=txtPayDay.ClientID%>")) {
                msg += "- Enter payment days \n";
                if (ctrl == "")
                    ctrl = "<%=txtPayDay.ClientID%>";
                flag = false;
            }
            if (msg != "") alert(msg);
            if (ctrl != "")
                document.getElementById(ctrl).focus();
            return flag;
        }

        function validation1() {
            var flag = true;
            var msg = "", ctrl = "";
            if (!CheckControl("<%=ddlStore.ClientID%>")) {
                msg += "- Select Store from list \n";
                if (ctrl == "")
                    ctrl = "<%=ddlStore.ClientID%>";
        flag = false;
    }
    if (!CheckControl("<%=ddlSupp.ClientID%>")) {
                msg += "- Select Supplier from list \n";
                if (ctrl == "")
                    ctrl = "<%=ddlSupp.ClientID%>";
        flag = false;
    }

    if (document.getElementById("<%=ddlRef.ClientID%>").value == "1") {
                if (!CheckControl("<%=txtrefNo.ClientID%>")) {
                    msg += "- Enter Refrence No\n";
                    if (ctrl == "")
                        ctrl = "<%=txtrefNo.ClientID%>";
                   flag = false;
               }
           }
           if (!CheckControl("<%=txtdiscount.ClientID%>")) {
                msg += "- Enter Discount on total amount\n";
                if (ctrl == "")
                    ctrl = "<%=txtdiscount.ClientID%>";
        flag = false;
    }
    if (!CheckControl("<%=txtOtherCharges.ClientID%>")) {
                msg += "- Enter Other Charges of this order\n";
                if (ctrl == "")
                    ctrl = "<%=txtOtherCharges.ClientID%>";
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
            <h2>Purchase Order</h2>
        </div>
        <div>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <table>
                        <tr>
                            <td>
                                <asp:Button ID="btnPurchaseReq" runat="server" Text="By Purchase Requisition" OnClick="btnPurchaseReq_Click" BackColor="Gray"></asp:Button>
                                <asp:Button ID="btnDirect" runat="server" Text="Direct Purchase Order" OnClick="btnDirect_Click"></asp:Button>
                            </td>
                        </tr>
                        <tr id="trPurReq" runat="server">
                            <td>
                                <table>

                                    <tr>
                                        <th>Purchase Requisition Number<span class="required">*</span>  </th>
                                        <th>Requested Department</th>
                                        <th>Request Date</th>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:DropDownList ID="ddlPurReq" runat="server" Width="160px" AutoPostBack="true" OnSelectedIndexChanged="ddlPurReq_SelectedIndexChanged">
                                            </asp:DropDownList>

                                        </td>
                                        <td>
                                            <asp:Label ID="lblDept" runat="server" CssClass="textbox"></asp:Label>

                                        </td>
                                        <td>
                                            <asp:Label ID="lblPurDate" runat="server" CssClass="textbox"></asp:Label>

                                        </td>
                                    </tr>
                                    <tr>
                                        <th>FAN Number<span class="required">*</span></th>
                                        <th>FAN Amount</th>
                                        <th>FAN Date</th>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:DropDownList ID="ddlFAN" runat="server" Width="160px" AutoPostBack="true" OnSelectedIndexChanged="ddlFAN_SelectedIndexChanged">
                                            </asp:DropDownList></td>
                                        <td>
                                            <asp:Label ID="lblFANAMT" runat="server"></asp:Label></td>
                                        <td>
                                            <asp:Label ID="lblFanDate" runat="server"></asp:Label></td>
                                    </tr>

                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <table>
                                    <tr>
                                        <th>Date<span class="required">*</th>
                                        <th>Store<span class="required">*</span></th>
                                        <th colspan="2">Supplier<span class="required">*</span></th>
                                    </tr>
                                    <tr>
                                         <td>
                                                                <asp:TextBox ID="txtDate" runat="server">
                                                                                        
                                                                </asp:TextBox>
                                                                <ajaxToolkit:CalendarExtender runat="server" ID="calendar" TargetControlID="txtDate"></ajaxToolkit:CalendarExtender>
                                                            </td>
                                        <td>
                                            <asp:DropDownList ID="ddlStore" runat="server" Width="160px" AutoPostBack="true" OnSelectedIndexChanged="ddlStore_SelectedIndexChanged">
                                            </asp:DropDownList></td>
                                        <td colspan="2">
                                            <asp:DropDownList ID="ddlSupp" runat="server" Width="300px" OnSelectedIndexChanged="ddlSupp_SelectedIndexChanged" AutoPostBack="true">
                                            </asp:DropDownList></td>
                                    </tr>
                                    <tr>
                                        <th>
                                            Category
                                        </th>
                                        <th>
                                            SubCategory
                                        </th>
                                        <th colspan="2">Department</th>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:DropDownList ID="ddlCat" runat="server" OnSelectedIndexChanged="ddlCat_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlSubCat" runat="server" OnSelectedIndexChanged="ddlSubCat_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                                        </td>
                                        <td>
                                             <asp:DropDownList ID="ddlDepartment" runat="server" ></asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <th colspan="3">Item Name<span class="required">*</span></th>
                                    </tr>
                                    <tr>
                                        <td colspan="3">
                                            <asp:DropDownList ID="ddlItem" runat="server" Width="600px" AutoPostBack="true" OnSelectedIndexChanged="ddlItem_SelectedIndexChanged">
                                            </asp:DropDownList></td>
                                    </tr>
                                    <tr>
                                        <td colspan="3">
                                            <table>

                                                <tr>
                                                    <th>Quantity<span class="required">*</span></th>
                                                    <th>Rate (Rs)<span class="required">*</span></th>
                                                    <th>Discount (%)<span class="required">*</span></th>
                                                    <th>GST (%)<span class="required">*</span></th>
                                                    <th>Unit<span class="required">*</span></th>
                                                    <th>Specification</th>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <cc1:NumericTextBox ID="txtQty" runat="server" Width="45px" AllowDecimal="True" DecimalPlaces="3"></cc1:NumericTextBox></td>
                                                    <td>
                                                        <cc1:NumericTextBox ID="txtrate" runat="server" Width="90px" AllowDecimal="true" DecimalPlaces="3"></cc1:NumericTextBox></td>
                                                    <td>
                                                        <cc1:NumericTextBox ID="txtdisc" runat="server" Width="90px" AllowDecimal="true" DecimalPlaces="2">0</cc1:NumericTextBox>
                                                    </td>
                                                    <td>
                                                        <cc1:NumericTextBox ID="txtTax" runat="server" Width="90px" AllowDecimal="true" DecimalPlaces="2">0</cc1:NumericTextBox>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtUnit" runat="server" Width="45px"></asp:TextBox></td>
                                                    <td>
                                                        <asp:TextBox ID="txtSpecification" runat="server" Width="300px"></asp:TextBox></td>
                                                    <td>
                                                        <asp:Button ID="btnAdd" runat="server" Width="50px" Text="Add" CssClass="btnBrown" OnClick="btnAdd_Click"></asp:Button></td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <th>List of Item(s)
                                <hr style="color: #ff0000; HEIGHT: 1px" />
                            </th>
                        </tr>
                        <tr>
                            <td>
                                <asp:GridView ID="gvItemDetail" CssClass="gridDynamic" runat="server" Width="97%" EmptyDataText="No rocord found" AutoGenerateColumns="False" ShowFooter="true" OnRowDeleting="gvItemDetail_RowDeleting">
                                    <FooterStyle HorizontalAlign="Right" CssClass="gridDynamic" />
                                    <Columns>
                                        <asp:TemplateField HeaderText="S#">
                                            <ItemTemplate>
                                                <%# ((GridViewRow)Container).RowIndex + 1%>
                                            </ItemTemplate>
                                            <ItemStyle Width="10px" />
                                        </asp:TemplateField>
                                        <asp:BoundField HeaderText="ITEM DESCRIPTION" DataField="ITEM_NAME" ReadOnly="true">
                                            <ItemStyle Width="300px" />
                                        </asp:BoundField>
                                        <asp:BoundField HeaderText="QTY" DataField="Qty">
                                            <ItemStyle HorizontalAlign="Right" Width="50px" />
                                        </asp:BoundField>
                                        <asp:BoundField HeaderText="UNIT" DataField="UNIT" ReadOnly="true">
                                            <ItemStyle Width="70px" />
                                        </asp:BoundField>
                                        <asp:BoundField HeaderText="RATE" DataField="Rate" ReadOnly="true" DataFormatString="{0:N2}"
                                            HtmlEncode="False">
                                            <ItemStyle HorizontalAlign="Right" Width="90px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="AMOUNT" DataFormatString="{0:N2}" HeaderText="AMOUNT"
                                            HtmlEncode="False" ReadOnly="true">
                                            <ItemStyle HorizontalAlign="Right" Width="90px" />
                                        </asp:BoundField>
                                        <asp:BoundField HeaderText="DISC (%)" DataField="DISCOUNT" ReadOnly="true" DataFormatString="{0:N2}"
                                            HtmlEncode="False">
                                            <ItemStyle HorizontalAlign="Right" Width="50px" />
                                        </asp:BoundField>
                                        <asp:BoundField HeaderText="GST (%)" DataField="TAX" HtmlEncode="False">
                                            <ItemStyle HorizontalAlign="Right" Width="50px" />
                                        </asp:BoundField>
                                        <asp:BoundField HeaderText="NET AMOUNT" DataField="TOTAL" ReadOnly="true" DataFormatString="{0:N2}"
                                            HtmlEncode="False">
                                            <ItemStyle HorizontalAlign="Right" Width="100px" />
                                        </asp:BoundField>
                                        <asp:CommandField ShowDeleteButton="true" ButtonType="Image" DeleteImageUrl="~/Siteimages/delete.jpg"
                                            HeaderText="DELETE">
                                            <ItemStyle Width="40px" />
                                        </asp:CommandField>
                                    </Columns>

                                </asp:GridView>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <table>
                                    <tr>
                                        <th>Reference:-</th>
                                        <td>
                                            <asp:DropDownList ID="ddlRef" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlRef_SelectedIndexChanged">
                                                <asp:ListItem Value="0">Verbal Discussion</asp:ListItem>
                                                <asp:ListItem Value="1">Quotation</asp:ListItem>
                                            </asp:DropDownList>

                                        </td>
                                        <th id="thQuot" runat="server">Quotation No:-</th>
                                        <td id="tdQuot" style="vertical-align: top" runat="server">
                                            <asp:TextBox ID="txtrefNo" runat="server" Width="100px"></asp:TextBox>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr id="trTerm" runat="server">
                            <td>
                                <table>
                                    <tr>
                                        <th colspan="4">Payment &amp; Conditions
                                            <hr style="color: #ff8c00; height: 1px" />
                                        </th>
                                    </tr>
                                    <tr>
                                        <th>Payment Option<span class="required">*</span></th>
                                        <th>Pay Per(%)<span class="required">*</span></th>
                                        <th>Pay Duration<span class="required">*</span></th>
                                        <th>&nbsp;</th>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:DropDownList ID="ddlPayment" runat="server" OnSelectedIndexChanged="ddlPayment_SelectedIndexChanged" AutoPostBack="true">
                                                <asp:ListItem Value="0">After Delivery</asp:ListItem>
                                                <asp:ListItem Value="1">Advance with PO</asp:ListItem>
                                                <asp:ListItem Value="2">On Delivery</asp:ListItem>
                                                <asp:ListItem Value="4">After Installation</asp:ListItem>
                                            </asp:DropDownList></td>
                                        <td>
                                            <cc1:NumericTextBox ID="txtPayment" runat="server" Width="100px"></cc1:NumericTextBox></td>
                                        <td>
                                            <cc1:NumericTextBox ID="txtPayDay" runat="server" Width="100px"></cc1:NumericTextBox></td>
                                        <td>
                                            <asp:Button ID="btnPayAdd" runat="server" Width="60px" Text="Add" OnClick="btnPayAdd_Click"></asp:Button></td>
                                    </tr>
                                    <tr>
                                        <td colspan="4">
                                            <asp:GridView ID="gvPayment" CssClass="gridDynamic" runat="server" Width="98%" AutoGenerateColumns="False" OnRowDeleting="gvPayment_RowDeleting">
                                                <Columns>
                                                    <asp:TemplateField HeaderText="S#">
                                                        <ItemTemplate>
                                                            <%# ((GridViewRow)Container).RowIndex + 1%>
                                                        </ItemTemplate>
                                                        <ItemStyle Width="10px"></ItemStyle>
                                                    </asp:TemplateField>
                                                    <asp:BoundField DataField="PAYON" HeaderText="Payment Option">
                                                        <ItemStyle Width="200px"></ItemStyle>
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="PAYPER" HeaderText="Pay Per(%)"></asp:BoundField>
                                                    <asp:BoundField DataField="PAYDAYS" HeaderText="Pay Duration"></asp:BoundField>
                                                    <asp:CommandField DeleteImageUrl="~/Siteimages/delete.jpg" ShowDeleteButton="True" ButtonType="Image"
                                                        HeaderText="Delete">
                                                        <ItemStyle Width="50px"></ItemStyle>
                                                    </asp:CommandField>
                                                </Columns>
                                            </asp:GridView>
                                        </td>
                                    </tr>

                                </table>
                                <table>

                                    <tr>
                                        <th colspan="4">Term &amp; Conditions</span>
                                            <hr style="color: #ff0000; height: 1px" />
                                        </th>
                                    </tr>
                                    <tr>
                                        <th>Term<span class="required">*</span>&nbsp;</th>
                                        <th></th>
                                        <th>Condition<span class="required">*</span>&nbsp;</th>
                                        <th></th>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:DropDownList ID="ddlTerm" runat="server" Width="150px" AutoPostBack="true" OnSelectedIndexChanged="ddlTerm_SelectedIndexChanged">
                                            </asp:DropDownList></td>
                                        <td></td>
                                        <td>
                                            <asp:TextBox ID="txtCondition" runat="server" Width="680px" Height="20px" TextMode="MultiLine"></asp:TextBox></td>
                                        <td>
                                            <asp:Button ID="btnTermAdd" runat="server" Width="60px" Text="Add " OnClick="btnTermAdd_Click"></asp:Button></td>
                                    </tr>
                                    <tr>
                                        <td colspan="4">
                                            <asp:GridView ID="gvTermCondition" CssClass="gridDynamic" runat="server" Width="98%" AutoGenerateColumns="False" OnRowDeleting="gvTermCondition_RowDeleting">
                                                <Columns>
                                                    <asp:TemplateField HeaderText="S#">
                                                        <ItemTemplate>
                                                            <%# ((GridViewRow)Container).RowIndex + 1%>
                                                        </ItemTemplate>
                                                        <ItemStyle Width="10px" />
                                                    </asp:TemplateField>
                                                    <asp:BoundField DataField="Term" HeaderText="Term">
                                                        <ItemStyle Width="200px" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="Condition" HeaderText="Condition" />
                                                    <asp:CommandField DeleteImageUrl="~/Siteimages/delete.jpg" ShowDeleteButton="True" ButtonType="Image" HeaderText="Delete">
                                                        <ItemStyle Width="50px" />
                                                    </asp:CommandField>
                                                </Columns>
                                            </asp:GridView>
                                        </td>
                                    </tr>

                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <table>
                                    <tr>
                                        <th>Other Charges (Rs)</th>
                                        <td>
                                            <cc1:NumericTextBox ID="txtOtherCharges" runat="server" Width="100px" DecimalPlaces="2">0</cc1:NumericTextBox>
                                        </td>
                                        <th>Discount on Complete PO</th>
                                        <td>
                                            <cc1:NumericTextBox ID="txtdiscount" runat="server" Width="100px" DecimalPlaces="2">0</cc1:NumericTextBox>
                                            <asp:DropDownList ID="ddlDis" runat="server" Width="40px" AutoPostBack="true" OnSelectedIndexChanged="ddlDis_SelectedIndexChanged">
                                                <asp:ListItem Value="--">--</asp:ListItem>
                                                <asp:ListItem Value="Rs">Rs</asp:ListItem>
                                                <asp:ListItem Value="%">%</asp:ListItem>
                                            </asp:DropDownList></td>
                                    </tr>
                                    <tr>
                                        <th>Net Amount (Rs)</th>
                                        <td>
                                            <asp:Label ID="lblNetAmount" runat="server" ForeColor="Blue">0</asp:Label></td>
                                        <th>Remark</th>
                                        <td>
                                            <asp:TextBox ID="txtremark" runat="server" Width="300px" Height="50px" TextMode="MultiLine"></asp:TextBox></td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Button ID="cmdSubmit" runat="server" Width="70px" Text="Submit" OnClick="cmdSubmit_Click"></asp:Button>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:TextBox ID="txtXML" runat="server" Visible="false"></asp:TextBox>
                                <asp:TextBox ID="txtPay" runat="server" Visible="false"></asp:TextBox>
                                <asp:TextBox ID="txtTerm" runat="server" Visible="false"></asp:TextBox>
                                <ajaxToolkit:AutoCompleteExtender ID="AutoComExt1" runat="server" EnableCaching="true" TargetControlID="txtCondition" ContextKey="1" ServicePath="../AutoComplete.asmx" ServiceMethod="GetConditionList" MinimumPrefixLength="1" CompletionSetCount="12" CompletionInterval="500">
                                </ajaxToolkit:AutoCompleteExtender>
                            </td>
                        </tr>
                    </table>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
</asp:Content>

