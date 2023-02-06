<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/FullLength.master" AutoEventWireup="true" CodeFile="returnToSupplier.aspx.cs" Inherits="Inventory_returnToSupplier" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <script type="text/javascript" >
        function validation() {
            if (document.getElementById("ddGrnNo").value == "Select") {
                alert("Please Select GRN No. From list");
                document.getElementById("ddGrnNo").focus();
                return false;
            }
            return true;
        }
		</script>
    <div class="container">
        <div class="heading">
            <h2>Return to Vendor</h2>
        </div>
        <div >
            <table>
                <tr>
                    <th style="text-align:right; width:400px;text-align:right">GRN No</th>
                    <td style="text-align:left">
					<asp:dropdownlist id="ddGrnNo" runat="server" CssClass="textbox" AutoPostBack="True" onselectedindexchanged="ddGrnNo_SelectedIndexChanged"></asp:dropdownlist>
					</td>
				</tr>

            </table>
        </div>
    <table id="Table1" border="0" runat="server">
				
				<tr>
					<td colspan="4" style="text-align:center;width:100%"><asp:label id="lblError" runat="server" Font-Bold="True" ForeColor="Red"></asp:label></td>
				</tr>
				
				<tr>
					<td><asp:panel id="Panel1" runat="server">
							<table id="Table2" border="0">
								<tr>
									<th style="text-align:left; width: 100px;">Store Name:</th>
									<td>
										<asp:label id="lblStore" runat="server" CssClass="lbl"></asp:label>

									</td>
									<th style="text-align:left; width: 120px;">Receiving Date:</th>
									<td>
										<asp:label id="lblReceiveDate" runat="server" CssClass="lbl"></asp:label>

									</td>
								</tr>
								<tr>
									<th style="text-align:left; width: 100px;">PO No.:</th>
									<td>
										<asp:label id="lblPoNo" runat="server" CssClass="lbl"></asp:label>

									</td>
									<th style="text-align:left; width: 120px;"> Recieve By:</th>
									<td>
										<asp:label id="lblRecieveBy" runat="server" CssClass="lbl"></asp:label>

									</td>
								</tr>
								<tr>
									<th style="text-align:left; width: 100px;">Supplier:</th>
									<td>
										<asp:label id="lblSupp" runat="server" CssClass="lbl"></asp:label>

									</td>
									<th style="text-align:left; width: 120px;">Challan No :</th>
									<td>
										<asp:label id="lblChallan" runat="server" CssClass="lbl"></asp:label>

									</td>
								</tr>
								<tr>
									<th style="text-align:left; width: 100px;">Bill No:</th>
									<td>
										<asp:label id="lblBill" runat="server" CssClass="lbl"></asp:label>

									</td>
									
								</tr>
								<tr class="trSt2">
									<td colspan="4">
										<asp:GridView id="dgShow" runat="server" Width="98%" CssClass="gridDynamic"
                                                AutoGenerateColumns="False" GridLines="None">
											
											<Columns>
                                                          <asp:TemplateField HeaderText="Sr. No.">
                                                        <ItemTemplate>
                                                            <%# ((GridViewRow)Container).RowIndex + 1%>
                                                        </ItemTemplate>
                                                        <ItemStyle Width="10px" />
                                                    </asp:TemplateField>
                                                <asp:BoundField DataField="ITEM_NAME" HeaderText="Item Name" >
                                                    <ItemStyle Width="200px" />
                                                    </asp:BoundField>
                                                <asp:BoundField DataField="QTY" HeaderText="Quantity"></asp:BoundField>
                                                <asp:BoundField DataField="AVLBL_QTY" HeaderText="Balance Quantity"></asp:BoundField>
                                                <asp:BoundField DataField="RATE_PER_ITEM" HeaderText="Rate"></asp:BoundField>
                                                <asp:BoundField DataField="TAX" HeaderText="Tax(%)"></asp:BoundField>
                                                <asp:BoundField DataField="DISCOUNT" HeaderText="Discount(Rs)"></asp:BoundField>
                                               <%-- <asp:BoundField DataField="BATCH_NO" HeaderText="Batch No."></asp:BoundField>--%>
                                                <asp:TemplateField HeaderText="Quantity to be returned">
                                                        <ItemTemplate>
                                                          <asp:TextBox id="txtRtnItem" runat="server" CssClass="NumericTextBoxRight" Width="112px" Text='<%# DataBinder.Eval(Container, "DataItem.AVLBL_QTY") %>' MaxLength="4">
                                                              </asp:TextBox>
                                                        </ItemTemplate>
                                                        <ItemStyle Width="10px" />
                                                    </asp:TemplateField>                                                																						
												<asp:TemplateField HeaderText="Select">
                                                    <ItemTemplate>
                                                        <asp:CheckBox ID="chkSelect" runat="server" />
                                                    </ItemTemplate>
												</asp:TemplateField>
												
												
											</Columns>
										</asp:GridView></td>
								</tr>
                             
							</table>
						</asp:panel></td>
				</tr>
				   <tr class="trSt1">
					<td colspan="4" style="text-align:center">
                        <asp:button id="btnSubmit" runat="server" CssClass="btn" Text="Submit" OnClick="btnSubmit_Click" ></asp:button></td>
				</tr>
			</table>
        </div>
</asp:Content>

