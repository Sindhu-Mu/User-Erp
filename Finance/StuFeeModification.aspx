<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/FullLength.master" AutoEventWireup="true" CodeFile="StuFeeModification.aspx.cs" Inherits="Finance_StuFeeModification" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script lang="javascript" type="text/javascript">
        function CheckControl(ctrl) {
            if (bTrim(document.getElementById(ctrl).value) == "" || bTrim(document.getElementById(ctrl).value) == "Select" || bTrim(document.getElementById(ctrl).value) == ".") {
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

            if (!CheckControl("<%=ddlFeesHead.ClientID%>")) {
                msg += "- Select Fee from list\n";
                if (ctrl == "")
                    ctrl = "<%=ddlFeesHead.ClientID%>";
                flag = false;
            }
            if (!CheckControl("<%=txtAmount.ClientID%>")) {
                msg += "- Enter Fee Amount \n";
                if (ctrl == "")
                    ctrl = "<%=txtAmount.ClientID%>";
                flag = false;
            }

            if (msg != "") alert(msg);
            if (ctrl != "")
                document.getElementById(ctrl).focus();
            return flag;
        }
        function valid() {
            var flag = true;
            var msg = "", ctrl = "";


            if (!CheckControl("<%=txtEnrollment.ClientID%>")) {
                msg += "- Enter Enrollment No.\n";
                if (ctrl == "")
                    ctrl = "<%=txtEnrollment.ClientID%>";
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
            <h2>Student Fee Modification</h2>
        </div>
        <div id="cBody">
            <asp:UpdatePanel ID="up1" runat="server">
                <ContentTemplate>
                    <div id="cHead" style="float: right;">
                        <table style="text-align: left; vertical-align: top">
                            <tr style="vertical-align: bottom;">
                                <th>Name</th>
                                <td>&nbsp;</td>
                                <th>Batch</th>
                                <td>&nbsp;</td>
                                <th>Branch</th>
                                <td>&nbsp;</td>
                                <th>Semester<span class="required">*</span></th>
                                <td>&nbsp;</td>
                                <th>Enrollment No<span class="required">*</span></th>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td style="height: 19px">
                                    <asp:Label ID="lblName" runat="server"></asp:Label>
                                </td>
                                <td>&nbsp;</td>
                                <td style="height: 19px">
                                    <asp:Label ID="lblBatch" runat="server"></asp:Label>
                                </td>
                                <td>&nbsp;</td>
                                <td style="height: 19px">
                                    <asp:DropDownList ID="ddlBranch" runat="server">
                                    </asp:DropDownList>
                                </td>
                                <td>&nbsp;</td>
                                <td style="height: 19px">
                                    <asp:DropDownList ID="ddlSemester" runat="server">
                                    </asp:DropDownList>
                                </td>
                                <td>&nbsp;</td>
                                <td style="height: 19px">
                                    <asp:TextBox ID="txtEnrollment" runat="server" Width="164px" CssClass="textbox">
                                    </asp:TextBox>
                                </td>
                                <td>&nbsp;</td>
                                <td style="height: 19px">
                                    <asp:Button ID="btnShow" runat="server" Width="60px" Text="Show" OnClick="btnShow_Click"></asp:Button>
                                </td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                            </tr>
                        </table>
                    </div>
                    <div class="cleaner"></div>
                    <div id="cCenter">
                        <div>
                            Demand Detail
            <hr style="color: #ff0000" />
                        </div>
                        <div>

                            <asp:GridView ID="gvFees" runat="server" AutoGenerateColumns="False" Width="97%" AutoPostBack="true"
                                DataKeyNames="FEE_DEMAND_ID,FEE_MAIN_HEAD_ID" ShowFooter="True" CssClass="gridDynamic" OnRowCancelingEdit="gvFees_RowCancelingEdit" OnRowEditing="gvFees_RowEditing" OnRowUpdating="gvFees_RowUpdating" OnRowDeleting="gvFees_RowDeleting">
                                <Columns>
                                    <asp:TemplateField HeaderText="S.No.">
                                        <ItemTemplate>
                                            <%# ((GridViewRow)Container).RowIndex + 1%>
                                                                .
                                        </ItemTemplate>
                                        <ItemStyle Width="20px" />
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="FEE_MAIN_HEAD_NAME" HeaderText="FEE NAME" ReadOnly="True"
                                        FooterText="TOTAL:-">
                                        <FooterStyle Font-Bold="True" HorizontalAlign="Right" />
                                        <ItemStyle Width="200px" />
                                    </asp:BoundField>
                                    <asp:TemplateField HeaderText="DEMAND AMOUNT">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txtAmount" runat="server" CssClass="txtno" Text='<%# Bind("FD_FEE_AMT") %>' ></asp:TextBox>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblAmt" runat="server" Text='<%# Bind("FD_FEE_AMT", "{0:N2}") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Right" />
                                        <FooterStyle HorizontalAlign="Right" Font-Bold="true" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="ADJUST">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txtAdjust" runat="server" CssClass="txtno" Text='<%# Bind("FD_ADJUST_AMT") %>' Width="80px"></asp:TextBox>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblAdjAmt" runat="server" Text='<%# Bind("FD_ADJUST_AMT", "{0:N2}") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Right" />
                                        <FooterStyle HorizontalAlign="Right" Font-Bold="true" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="CONCESSION">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txtConcession" runat="server" CssClass="txtno" Text='<%# Bind("CONCESSION_AMT") %>' Width="80px"></asp:TextBox>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblConcession" runat="server" Text='<%# Bind("CONCESSION_AMT", "{0:N2}") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Right" />
                                        <FooterStyle HorizontalAlign="Right" Font-Bold="true" />
                                    </asp:TemplateField>
                                       <asp:TemplateField HeaderText="CONCESSION REMARK">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txtConcessionRemark" runat="server" CssClass="txtno" Text='<%# Bind("CONC_REMARK") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblConcessionRemark" runat="server" Text='<%# Bind("CONC_REMARK") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Right" />
                                        <FooterStyle HorizontalAlign="Right" Font-Bold="true" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="WAVE">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txtWAVE" runat="server" CssClass="txtno" Text='<%# Bind("FEE_WAVE_OFF") %>' Width="80px"></asp:TextBox>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblWAVE" runat="server" Text='<%# Bind("FEE_WAVE_OFF", "{0:N2}") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Right" />
                                        <FooterStyle HorizontalAlign="Right" Font-Bold="true" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="RECEIVE">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txtRECEIVE" runat="server" CssClass="txtno" Text='<%# Bind("FD_RCV_AMT") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblRECEIVE" runat="server" Text='<%# Bind("FD_RCV_AMT", "{0:N2}") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Right" />
                                        <FooterStyle HorizontalAlign="Right" Font-Bold="true" />
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="FD_BALANCE_AMT" HeaderText="BALANCE" ReadOnly="True">
                                        <ItemStyle HorizontalAlign="Right" />
                                        <FooterStyle HorizontalAlign="Right" Font-Bold="true" />
                                    </asp:BoundField>
                                    <asp:CommandField ButtonType="Image" CancelImageUrl="~/Siteimages/cancel_icon.gif" EditImageUrl="~/Siteimages/editsmall.gif"
                                        ShowEditButton="True" UpdateImageUrl="~/Siteimages/update_icon.gif" HeaderText="MODIFY" />
                                    <asp:CommandField ButtonType="Image" DeleteImageUrl="~/Siteimages/delete.jpg" ShowDeleteButton="True" HeaderText="DELETE" />
                                </Columns>
                            </asp:GridView>


                            <asp:HiddenField ID="HD1" runat="server" />
                        </div>
                        <div id="DivOther" runat="server" visible="false">
                            <table>
                                <tr>
                                    <th colspan="3">ADD DEMAND FOR OTHER FEE HEAD
                                       <hr style="color: #ff0000" />
                                    </th>

                                    <tr>
                                        <td>&nbsp;Fee Head<span class="required">*</span></td>
                                        <td>&nbsp;Amount<span class="required">*</span></td>
                                        <td>&nbsp;</td>
                                    </tr>
                                <tr>
                                    <td>
                                        <asp:DropDownList ID="ddlFeesHead" runat="server" Width="200px">
                                        </asp:DropDownList></td>
                                    <td>
                                        <cc1:NumericTextBox ID="txtAmount" runat="server" AllowDecimal="true" DecimalPlaces="2" AllowNegative="false" Width="93px"></cc1:NumericTextBox>
                                    <td>

                                    <td>
                                        <asp:Button ID="btnAdd" runat="server" Text="Add  & Save" Width="100px" OnClick="btnAdd_Click" /></td>
                                </tr>
                            </table>
                        </div>
                    </div>
                    <div id="cFooter" runat="server" visible="false">
                        <div>
                            Receipt Detail<hr style="color: #ff0000" />
                        </div>
                        <div>
                            <asp:GridView ID="gvPayTransaction" runat="server" AutoGenerateColumns="False" EmptyDataText="No record found." DataKeyNames="FEE_RCV_RECEIPT_NO" CssClass="gridDynamic" OnRowDeleting="gvPayTransaction_RowDeleting">
                                <Columns>
                                    <asp:TemplateField HeaderText="S.No.">
                                        <ItemTemplate>
                                            <%#((GridViewRow)Container).RowIndex +1 %>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:HyperLinkField DataTextField="RECEIPT_NO" HeaderText="Receipt No" ControlStyle-ForeColor="Blue" DataNavigateUrlFields="FEE_RCV_RECEIPT_NO" DataNavigateUrlFormatString="prtFeeReceipt.aspx?id={0}" Target="_blank" ItemStyle-Width="170px" />
                                    <asp:BoundField DataField="AMOUNT" HeaderText="Amount" />
                                    <asp:BoundField DataField="FEE_DEPOSIT_DT" HeaderText="Deposit Date" DataFormatString="{0:dd/MM/yyyy}" />
                                    <asp:BoundField DataField="TRAN_DT" HeaderText="Entry Date" DataFormatString="{0:dd/MM/yyyy HH:mm}" />
                                    <asp:BoundField DataField="EMP_NAME" HeaderText="Entry By" />
                                    <asp:BoundField DataField="FEE_RCV_REMARK" HeaderText="Remark" />
                                    <asp:CommandField ButtonType="Button" DeleteText="Select" ShowDeleteButton="True" HeaderText="Modify" />
                                </Columns>
                                <SelectedRowStyle BackColor="Yellow" />
                               
                            </asp:GridView>
                        </div>
                        <div >
                            <div>
                         <asp:Label ID="lblReceiptNo" runat="server" ></asp:Label>
                        </div>
                            <div>
                            <asp:GridView ID="GridReceipt" runat="server" AutoGenerateColumns="False" Width="97%" AutoPostBack="true" DataKeyNames="FEE_RCV_TRAN_ID" ShowFooter="True" CssClass="gridDynamic" OnRowDeleting="GridReceipt_RowDeleting">
                                <Columns>
                                    <asp:TemplateField HeaderText="S.No.">
                                        <ItemTemplate>
                                            <%# ((GridViewRow)Container).RowIndex + 1%>                                                                .
                                        </ItemTemplate>
                                        <ItemStyle Width="20px" />
                                    </asp:TemplateField>
                                  
                                     <asp:TemplateField HeaderText="FEE NAME"  FooterText="TOTAL:-">
                                        <ItemTemplate>
                                            <asp:DropDownList ID="ddlHead" runat="server"></asp:DropDownList>
                                        </ItemTemplate>
                                       <FooterStyle Font-Bold="True" HorizontalAlign="Right" />
                                        <ItemStyle Width="200px" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="RECEIPT AMOUNT">
                                        <ItemTemplate>
                                            <cc1:NumericTextBox runat="server" ID="txtTranAmount" AllowDecimal="true" DecimalPlaces="2" MaxLength="10" Width="100px" Text='<%# Bind("FEE_RCV_TRAN_AMT", "{0:N2}") %>'></cc1:NumericTextBox>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Right" />
                                        <FooterStyle HorizontalAlign="Right" Font-Bold="true" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Deposit Date">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtDepositDate" runat="server" Text='<%# Bind("FEE_DEPOSIT_DT", "{0:dd/MM/yyyy}") %>'></asp:TextBox>
                                            <ajaxToolkit:CalendarExtender ID="CalendarExtender1" Format="dd/MM/yyyy" runat="server" TargetControlID="txtDepositDate"></ajaxToolkit:CalendarExtender>
                                            <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender1" runat="server" TargetControlID="txtDepositDate" Mask="99/99/9999"
                                                MaskType="Date">
                                            </ajaxToolkit:MaskedEditExtender>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Remark">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtRemark" runat="server" Text='<%# Bind("FEE_RCV_REMARK") %>'></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:CommandField ButtonType="Image" DeleteImageUrl="~/Siteimages/delete.jpg" ShowDeleteButton="True" HeaderText="DELETE" />
                                </Columns>
                         
                            </asp:GridView>
                            <asp:GridView ID="GridMode" runat="server" AutoGenerateColumns="False" Width="97%" AutoPostBack="true" DataKeyNames="RCV_TRAN_MODE_ID" ShowFooter="True" CssClass="gridDynamic"  OnRowDeleting="GridMode_RowDeleting">
                                <Columns>
                                    <asp:TemplateField HeaderText="S.No.">
                                        <ItemTemplate>
                                            <%# ((GridViewRow)Container).RowIndex + 1%>                                                                .
                                        </ItemTemplate>
                                        <ItemStyle Width="20px" />
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="PAY_MODE_VALUE" HeaderText="Payment Mode" ReadOnly="True"
                                        FooterText="TOTAL:-">
                                        <FooterStyle Font-Bold="True" HorizontalAlign="Right" />
                                        <ItemStyle Width="200px" />
                                    </asp:BoundField>
                                    <asp:TemplateField HeaderText="Payment Mode"  FooterText="TOTAL:-">
                                        <ItemTemplate>
                                            <asp:DropDownList ID="ddlPayMode" runat="server"></asp:DropDownList>
                                        </ItemTemplate>
                                       <FooterStyle Font-Bold="True" HorizontalAlign="Right" />
                                        <ItemStyle Width="200px" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="MODE AMOUNT">
                                        <ItemTemplate>
                                            <cc1:NumericTextBox runat="server" ID="txtAmount" AllowDecimal="true" DecimalPlaces="2" MaxLength="10" Width="100px" Text='<%# Bind("RCV_TRAN_MODE_AMT", "{0:N2}") %>'></cc1:NumericTextBox>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Right" />
                                        <FooterStyle HorizontalAlign="Right" Font-Bold="true" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Transaction No">
                                        <ItemTemplate>
                                            <cc1:NumericTextBox runat="server" ID="txtModeNo" AllowDecimal="false" MaxLength="20" Width="100px" Text='<%# Bind("RCV_TRAN_MODE_NO") %>'></cc1:NumericTextBox>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Right" />
                                        <FooterStyle HorizontalAlign="Right" Font-Bold="true" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Mode Date">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtModeDate" runat="server" Text='<%# Bind("RCV_TRAN_MODE_DT", "{0:dd/MM/yyyy}") %>'></asp:TextBox>
                                            <ajaxToolkit:CalendarExtender ID="CalendarExtender1" Format="dd/MM/yyyy" runat="server" TargetControlID="txtModeDate"></ajaxToolkit:CalendarExtender>
                                            <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender1" runat="server" TargetControlID="txtModeDate" Mask="99/99/9999" MaskType="Date"></ajaxToolkit:MaskedEditExtender>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                      <asp:TemplateField HeaderText="Payment Bank">
                                        <ItemTemplate>
                                            <asp:DropDownList ID="ddlBank" runat="server"></asp:DropDownList>                                     
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                      <asp:TemplateField HeaderText="Branch">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtBranch" runat="server" Text='<%# Bind("TRAN_DRAWEE_BRANCH") %>'></asp:TextBox>                                          
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:CommandField ButtonType="Image" DeleteImageUrl="~/Siteimages/delete.jpg" ShowDeleteButton="True" HeaderText="DELETE" />
                                </Columns>
                            </asp:GridView>
                                </div>
                        </div>
                        <div>
                            <hr />
                            <asp:Button ID="btnUpdate" runat="server" Text="Update Receipt Details" OnClick="btnUpdate_Click" Height="30px" />
                        </div>
                        </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
</asp:Content>

