<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/FullLength.master" AutoEventWireup="true" CodeFile="Pur_RFQ_Item_Rates.aspx.cs" Inherits="Inventory_Pur_RFQ_Item_Rates" %>

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
                         elm[i].id != theBox.id)
                {

                    if (elm[i].checked != xState)
                        elm[i].click();

                }

        }



        function CheckControl(ctrl)
        {
            if (bTrim(document.getElementById(ctrl).value) == "" || bTrim(document.getElementById(ctrl).value) == "Select" || bTrim(document.getElementById(ctrl).value) == ".")
            {
                document.getElementById(ctrl).style.backgroundColor = "#fc6";
                return false;
            }
            else
            {
                document.getElementById(ctrl).style.backgroundColor = "#fff";
                return true;
            }
        }


        function validateView() {
            var flag = true;
            var msg = "", ctrl = "";



            if (!CheckControl("<%=ddlVendor.ClientID%>")) {
                msg += "- Select vendor from list\n";
                if (ctrl == "") {
                    ctrl = "<%=ddlVendor.ClientID%>";
                }
                flag = false;
            }

            if (msg != "")
                alert(msg);
            if (ctrl != "")
                document.getElementById(ctrl).focus();
            return flag;
        }

        function validateSubmit() {
            var flag = true;
            var msg = "", ctrl = "";



            if (!CheckControl("<%=txtRmrk.ClientID%>")) {
                msg += "- Enter Remark\n";
                if (ctrl == "") {
                    ctrl = "<%=txtRmrk.ClientID%>";
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
            <h2>Quotation Item Master</h2>
        </div>
        <div>
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
                                                    <th>Pur.RFQ.No.
                                                    </th>
                                                    <th id="thVendor" runat="server" visible="false"> Vendor
                                                    </th>
                                                    

                                                    <%--<th id="thItem" runat="server" visible="false">Item
                                                    </th>--%>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:DropDownList ID="ddlStore" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlStore_SelectedIndexChanged"></asp:DropDownList>
                                                    </td>
                                                    <td>
                                                        <asp:DropDownList ID="ddlPurRFQID" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlPurRFQID_SelectedIndexChanged"></asp:DropDownList>
                                                    </td>
                                                    <td id="tdVendor" runat="server" visible="false">
                                                        <asp:DropDownList ID="ddlVendor" runat="server" AutoPostBack="true"></asp:DropDownList>
                                                    </td>
                                                    


                                                   <%-- <td id="tdItem" runat="server" visible="false">
                                                        <asp:DropDownList ID="ddlItem" runat="server" AutoPostBack="true"></asp:DropDownList>
                                                    </td>--%>
                                                    <td>
                                                        <asp:Button ID="btnView" runat="server" Text="View Detail" OnClick="btnView_Click" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td></td>
                                                </tr>
                                                <tr>
                                                    <td colspan="5">
                                                        <asp:GridView ID="gvItemDetail" runat="server" AutoGenerateColumns="False" CellPadding="2"
                                                            Width="97%" DataKeyNames="PUR_RFQ_ITEM_ID,PUR_RFQ_VEN_ID" OnRowDataBound="gvItemDetail_RowDataBound">
                                                            <Columns>
                                                                <asp:TemplateField HeaderText="S.No.">
                                                                    <ItemTemplate>
                                                                        <%# ((GridViewRow)Container).RowIndex + 1%>
                                                                    </ItemTemplate>
                                                                    <ItemStyle Width="20px" />
                                                                </asp:TemplateField>
                                                                <asp:BoundField DataField="ITEM_NAME" HeaderText="Item Name" ReadOnly="True" />
                                                                <asp:BoundField DataField="UNIT" HeaderText="Unit" ReadOnly="True" />
                                                                <asp:BoundField DataField="QTY" HeaderText="App.Qty" />
                                                                <asp:TemplateField HeaderText="ITEM RATE">
                                                                    <EditItemTemplate>
                                                                        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                                                                    </EditItemTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:TextBox ID="txtRate" runat="server" CssClass="txtno" Width="70px"></asp:TextBox>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="DISCOUNT">
                                                                    <EditItemTemplate>
                                                                        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                                                                    </EditItemTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:TextBox ID="txtDiscount" runat="server" CssClass="txtno" Width="70px"></asp:TextBox>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="TAX">
                                                                    <EditItemTemplate>
                                                                        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                                                                    </EditItemTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:TextBox ID="txtTax" runat="server" CssClass="txtno" Width="70px"></asp:TextBox>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                            </Columns>
                                                            <HeaderStyle ForeColor="Crimson" />
                                                        </asp:GridView>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td></td>
                                                </tr>
                                                <tr id="trRmrk" runat="server">
                                                    <th>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Remark
                                                    </th>
                                                    <td>
                                                        <asp:TextBox ID="txtRmrk" runat="server"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td></td>
                                                </tr>
                                                <tr id="trBtn" runat="server">
                                                    <td>
                                                        <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" />
                                                    </td>
                                                    <td colspan="2">
                                                        <asp:Button ID="btnCmprtvStmnt" runat="server" Text="Generate Comparative Statement" OnClick="btnCmprtvStmnt_Click" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td></td>
                                                </tr>
                                                <tr>
                                                    <td id="tdMain" runat="server" colspan="5"></td>
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
        </div>
    </div>
</asp:Content>

