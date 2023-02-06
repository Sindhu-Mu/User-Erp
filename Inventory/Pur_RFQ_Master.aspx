<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/FullLength.master" AutoEventWireup="true" CodeFile="Pur_RFQ_Master.aspx.cs" Inherits="Inventory_Pur_RFQ_Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script lang="javascript" type="text/javascript">

        function SelectAllCheckboxes(spanChk) {


            var oItem = spanChk.children;
            var theBox = (spanChk.type == "checkbox") ?
                spanChk : spanChk.children.item[0];
            xState = theBox.checked;
            elm = theBox.form.elements;

            for (i = 0; i < elm.length; i++)
                if (elm[i].type == "checkbox" &&
                         elm[i].id != theBox.id) {

                    if (elm[i].checked != xState)
                        elm[i].click();

                }

        }

       

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


        function validateAdd()
        {
            var flag = true;
            var msg = "", ctrl = "";
            

             
            if (!CheckControl("<%=txtRFQRmrk.ClientID%>"))
            {
                msg += "- Enter Remark\n";
                if (ctrl == "") {
                    ctrl = "<%=txtRFQRmrk.ClientID%>";
                 }
                 flag = false;
             }

             if (msg != "")
                 alert(msg);
             if (ctrl != "")
                 document.getElementById(ctrl).focus();
             return flag;
         }
       
        function validate()
        {
            var flag = true;
            var msg = "", ctrl = "";
            if (!CheckControl("<%=ddlDrctStore.ClientID%>"))
            {
                msg += "- Select Store From List\n";
                if (ctrl == "")
                {
                    ctrl = "<%=ddlDrctStore.ClientID%>";
                }
                flag = false;
            }
            if (!CheckControl("<%=ddlDrctItem.ClientID%>"))
            {
                msg += "- Select Item From List\n";
                if (ctrl == "")
                {
                    ctrl = "<%=ddlDrctItem.ClientID%>";
                }
                flag = false;
            }
            if (!CheckControl("<%=txtQty.ClientID%>")) {
                msg += "- Enter Quantity\n";
                if (ctrl == "") {
                    ctrl = "<%=txtQty.ClientID%>";
                }
                flag = false;
            }
            if (!CheckControl("<%=txtSpec.ClientID%>")) {
                msg += "- Enter Specification\n";
                if (ctrl == "") {
                    ctrl = "<%=txtSpec.ClientID%>";
                }
                flag = false;
            }
            

            if (msg != "")
                alert(msg);
            if (ctrl != "")
                document.getElementById(ctrl).focus();
            return flag;
        }
        function validateRe()
        {
            var flag = true;
            var msg = "", ctrl = "";
            if (!CheckControl("<%=txtDrctRmrk.ClientID%>"))
            {
                msg += "- Enter Remark\n";
                if (ctrl == "") {
                    ctrl = "<%=txtDrctRmrk.ClientID%>";
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
            <h2>Purchase RFQ Master</h2>
        </div>
        <table>
            <tr>
                <td>
                    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                        <ContentTemplate>
                            <ajaxToolkit:TabContainer ID="step1" runat="server" ActiveTabIndex="1" AutoPostBack="true" OnActiveTabChanged="step1_ActiveTabChanged">
                                <ajaxToolkit:TabPanel runat="server" ID="TabPanel1">
                                    <HeaderTemplate>
                                        Purchase Requisition
                                    </HeaderTemplate>
                                    <ContentTemplate>
                                        <table>
                                            <tr>
                                                <td>
                                                    <table style="width: 100%; border-collapse: collapse; border-spacing: 0px; text-align: center">
                                                        <tr>
                                                            <td>

                                                                <asp:UpdatePanel ID="up1" runat="server">
                                                                    <ContentTemplate>
                                                                        <table style="width: 100%; border-collapse: collapse; border-spacing: 0px; text-align: center">
                                                                            <tr>

                                                                                <th>Store
                                                                                </th>
                                                                                <th>Pur.Req.No.
                                                                                </th>
                                                                                <%--<th>Item
                                                                                </th>--%>
                                                                            </tr>
                                                                            <tr>
                                                                                <td>
                                                                                    <asp:DropDownList ID="ddlStore" runat="server" OnSelectedIndexChanged="ddlStore_SelectedIndexChanged" AutoPostBack="true" Width="100px"></asp:DropDownList>
                                                                                </td>
                                                                                <td>
                                                                                    <asp:DropDownList ID="ddlPurId" runat="server" AutoPostBack="true" Width="100px"></asp:DropDownList>
                                                                                </td>
                                                                                <%--<td>
                                                                                    <asp:DropDownList ID="ddlItem" runat="server" AutoPostBack="true"></asp:DropDownList>
                                                                                </td>--%>
                                                                                <td>
                                                                                    <asp:Button ID="btnViewItemDetail" runat="server" Text="View Detail" OnClick="btnViewItemDetail_Click" />
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td></td>
                                                                            </tr>
                                                                            <tr id="trItemDetails" runat="server" visible="false">
                                                                                <td style="width: 50%; vertical-align: top" colspan="5">
                                                                                    <fieldset style="border-collapse: collapse; border-spacing: 0px; margin: 0px; padding: 0px; border: none">
                                                                                        <legend>Item Details</legend>
                                                                                        <div style="width: 100%; overflow: auto">
                                                                                            <asp:GridView ID="gvRFQItemDetails" runat="server" AutoGenerateColumns="false" EmptyDataText="No Record Found" Width="487px" DataKeyNames="ITEM_ID">
                                                                                                <Columns>
                                                                                                    <asp:TemplateField HeaderText="S.No.">
                                                                                                        <ItemTemplate>
                                                                                                            <%# ((GridViewRow)Container).RowIndex + 1%>
                                                                                                        </ItemTemplate>
                                                                                                        <ItemStyle Width="20px" />
                                                                                                    </asp:TemplateField>
                                                                                                    <asp:BoundField HeaderText="Item" DataField="ITEM_NAME" />
                                                                                                    <asp:BoundField HeaderText="Unit" DataField="UNIT_NAME" />
                                                                                                    <asp:BoundField HeaderText="Quantity" DataField="QTY" />
                                                                                                    <asp:BoundField HeaderText="Store" DataField="STO_NAME" />
                                                                                                    <asp:TemplateField HeaderText="All">
                                                                                                        <HeaderTemplate>
                                                                                                            <input id="chkAll" onclick="javascript: SelectAllCheckboxes(this);" type="checkbox"
                                                                                                                value="on" runat="server" style="border-right: blue 2px groove; border-top: blue 2px groove; border-left: blue 2px groove; border-bottom: blue 2px groove" />
                                                                                                        </HeaderTemplate>
                                                                                                        <ItemTemplate>
                                                                                                            <asp:CheckBox ID="CHK_SelectAllItem" runat="server" />
                                                                                                        </ItemTemplate>
                                                                                                    </asp:TemplateField>
                                                                                                </Columns>

                                                                                            </asp:GridView>
                                                                                        </div>
                                                                                    </fieldset>

                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td></td>
                                                                            </tr>
                                                                            <tr id="trSupplierDetails" runat="server" visible="false">
                                                                                <td style="width: 50%; vertical-align: top" colspan="5">
                                                                                    <fieldset style="border-collapse: collapse; border-spacing: 0px; margin: 0px; padding: 0px; border: none">
                                                                                        <legend>Supplier Details</legend>
                                                                                        <div style="width: 100%; overflow: auto">
                                                                                            <asp:GridView ID="gvSuppDetails" runat="server" AutoGenerateColumns="false" EmptyDataText="No Record Found" Width="487px" DataKeyNames="VENDOR_ID">
                                                                                                <Columns>
                                                                                                    <asp:TemplateField HeaderText="S.No.">
                                                                                                        <ItemTemplate>
                                                                                                            <%# ((GridViewRow)Container).RowIndex + 1%>
                                                                                                        </ItemTemplate>
                                                                                                        <ItemStyle Width="20px" />
                                                                                                    </asp:TemplateField>
                                                                                                    <asp:BoundField HeaderText="Name" DataField="VENDOR_ORG_NAME" />
                                                                                                    <asp:BoundField HeaderText="Address" DataField="VEN_ORG_ADD_1" />
                                                                                                    <asp:BoundField HeaderText="City" DataField="CIT_VALUE" />
                                                                                                    <asp:BoundField HeaderText="Phone" DataField="VEN_ORG_PHN_NO" />
                                                                                                    <asp:TemplateField HeaderText="All">
                                                                                                        <HeaderTemplate>
                                                                                                            <input id="chkAll" onclick="javascript: SelectAllCheckboxes(this);" type="checkbox"
                                                                                                                value="on" runat="server" style="border-right: blue 2px groove; border-top: blue 2px groove; border-left: blue 2px groove; border-bottom: blue 2px groove" />
                                                                                                        </HeaderTemplate>
                                                                                                        <ItemTemplate>
                                                                                                            <asp:CheckBox ID="CHK_SelectAll" runat="server" />
                                                                                                        </ItemTemplate>
                                                                                                    </asp:TemplateField>
                                                                                                </Columns>

                                                                                            </asp:GridView>
                                                                                        </div>
                                                                                    </fieldset>

                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td></td>
                                                                            </tr>
                                                                            <tr id="trRemark" runat="server" visible="false">
                                                                                <th>RFQ Remark
                                                                                </th>
                                                                                <td>
                                                                                    <asp:TextBox ID="txtRFQRmrk" runat="server"></asp:TextBox>
                                                                                </td>
                                                                                <td></td>
                                                                                <td></td>
                                                                                <td>
                                                                                    <asp:Button ID="btnSubmit" runat="server" Text="Submit And Print RFQ" OnClick="btnSubmit_Click" />

                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </ContentTemplate>
                                                                </asp:UpdatePanel>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                        </table>
                                    </ContentTemplate>
                                </ajaxToolkit:TabPanel>
                                <ajaxToolkit:TabPanel runat="server" ID="TabPanel2">
                                    <HeaderTemplate>
                                        Direct
                                    </HeaderTemplate>
                                    <ContentTemplate>
                                        <table>
                                            <tr>
                                                <td>
                                                    <table>
                                                        <tr>
                                                            <td>
                                                                <asp:UpdatePanel ID="up2" runat="server">
                                                                    <ContentTemplate>
                                                                        <table>
                                                                            <tr>
                                                                                <th>Store
                                                                                </th>
                                                                                <th>Item Name
                                                                                </th>
                                                                                <th>Quantity
                                                                                </th>
                                                                                <th>Specification
                                                                                </th>
                                                                            </tr>
                                                                            <tr>
                                                                                <td>
                                                                                    <asp:DropDownList ID="ddlDrctStore" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlDrctStore_SelectedIndexChanged" Width="100px"></asp:DropDownList>
                                                                                </td>
                                                                                <td>
                                                                                    <asp:DropDownList ID="ddlDrctItem" runat="server" AutoPostBack="true" Width="100px"></asp:DropDownList>
                                                                                </td>
                                                                                <td><cc1:NumericTextBox ID="txtQty" runat="server" AllowDecimal="False" AllowNegative="False" DecimalPlaces="-1" Height="30px" Width="50px"></cc1:NumericTextBox></td>
                                                                               
                                                                                <td>
                                                                                    <asp:TextBox ID="txtSpec" runat="server"></asp:TextBox>
                                                                                </td>
                                                                                <td>
                                                                                    <asp:Button ID="btnAdd" runat="server" Text="Add" OnClick="btnAdd_Click" />
                                                                                </td>
                                                                               
                                                                            </tr>
                                                                            <tr id="trDirectItemDetails" runat="server" visible="false">
                                                                                <td style="width: 50%; vertical-align: top" colspan="5">
                                                                                    <fieldset style="border-collapse: collapse; border-spacing: 0px; margin: 0px; padding: 0px; border: none">
                                                                                        <legend>Item Details</legend>
                                                                                        <div style="width: 100%; overflow: auto">
                                                                                            <asp:GridView ID="gvDirectItemDetails" runat="server" CssClass="gridDynamic" AutoGenerateColumns="false" EmptyDataText="No Record Found" Width="487px" DataKeyNames="ITEM_ID" OnRowDeleting="gvDirectItemDetails_RowDeleting">
                                                                                                <Columns>
                                                                                                    <asp:TemplateField HeaderText="S.No.">
                                                                                                        <ItemTemplate>
                                                                                                            <%# ((GridViewRow)Container).RowIndex + 1%>
                                                                                                        </ItemTemplate>
                                                                                                        <ItemStyle Width="20px" />
                                                                                                    </asp:TemplateField>
                                                                                                    <asp:BoundField HeaderText="Item Name" DataField="ITEM_NAME" />
                                                                                                    <asp:BoundField HeaderText="Quantity" DataField="QTY" />
                                                                                                    <asp:BoundField HeaderText="Specification" DataField="SPECIFICATION" />
                                                                                                    <asp:CommandField HeaderText="Delete" ShowDeleteButton="True">
                                                                                                        <ItemStyle Width="20px" />
                                                                                                    </asp:CommandField>
                                                                                                </Columns>

                                                                                            </asp:GridView>
                                                                                        </div>
                                                                                    </fieldset>

                                                                                </td>
                                                                            </tr>
                                                                            <tr id="trDirectSuppDetails" runat="server" visible="false">
                                                                                <td style="width: 50%; vertical-align: top" colspan="5">
                                                                                    <fieldset style="border-collapse: collapse; border-spacing: 0px; margin: 0px; padding: 0px; border: none">
                                                                                        <legend>Supplier Details</legend>
                                                                                        <div style="width: 100%; overflow: auto">
                                                                                            <asp:GridView ID="gvDirectSuppDetails" runat="server" CssClass="gridDynamic" AutoGenerateColumns="false" EmptyDataText="No Record Found" Width="487px" DataKeyNames="VENDOR_ID">
                                                                                                <Columns>
                                                                                                    <asp:TemplateField HeaderText="S.No.">
                                                                                                        <ItemTemplate>
                                                                                                            <%# ((GridViewRow)Container).RowIndex + 1%>
                                                                                                        </ItemTemplate>
                                                                                                        <ItemStyle Width="20px" />
                                                                                                    </asp:TemplateField>
                                                                                                    <asp:BoundField HeaderText="Name" DataField="ORG_NAME" />
                                                                                                    <asp:BoundField HeaderText="Address" DataField="ADD_1" />
                                                                                                    <asp:BoundField HeaderText="City" DataField="CIT_VALUE" />
                                                                                                    <asp:BoundField HeaderText="Phone" DataField="ORG_PHN_NO" />
                                                                                                    <asp:TemplateField HeaderText="All">
                                                                                                        <HeaderTemplate>
                                                                                                            <input id="chkAll" onclick="javascript: SelectAllCheckboxes(this);" type="checkbox"
                                                                                                                value="on" runat="server" style="border-right: blue 2px groove; border-top: blue 2px groove; border-left: blue 2px groove; border-bottom: blue 2px groove" />
                                                                                                        </HeaderTemplate>
                                                                                                        <ItemTemplate>
                                                                                                            <asp:CheckBox ID="CHK_SelectAll" runat="server" />
                                                                                                        </ItemTemplate>
                                                                                                    </asp:TemplateField>
                                                                                                </Columns>

                                                                                            </asp:GridView>
                                                                                        </div>
                                                                                    </fieldset>

                                                                                </td>
                                                                            </tr>
                                                                            <tr id="trDirect" runat="server">
                                                                                <th>Remark
                                                                                </th>
                                                                                <td>
                                                                                    <asp:TextBox ID="txtDrctRmrk" runat="server"></asp:TextBox>
                                                                                </td>
                                                                                <td>
                                                                                    <asp:Button ID="btnDrctFinish" runat="server" Text="Submit & Print RFQ" OnClick="btnDrctFinish_Click" />
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </ContentTemplate>
                                                                </asp:UpdatePanel>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                        </table>
                                    </ContentTemplate>
                                </ajaxToolkit:TabPanel>
                            </ajaxToolkit:TabContainer>
                        </ContentTemplate>

                    </asp:UpdatePanel>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>

