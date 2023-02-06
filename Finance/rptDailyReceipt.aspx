<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/FullLength.master" AutoEventWireup="true" CodeFile="rptDailyReceipt.aspx.cs" Inherits="Finance_rptDailyReceipt" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script lang="javascript" type="text/javascript">
        function CheckControl(ctrl) {
            if (btrim(document.getElementById(ctrl).value) == "" || btrim(document.getElementById(ctrl).value) == "0" || btrim(document.getElementById(ctrl).value) == "-1") {
                document.getElementById(ctrl).style.backgroundColor = "#fc6";
                return false;
            }
            else
                document.getElementById(ctrl).style.backgroundColor = "#fff";
            return true;
        }
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
        function Validat() {

            var flag = true;
            var msg = "", ctrl = "";
            if (CheckControl("<%=txtForm.ClientID%>")) {
                if (!CheckDate("<%=txtForm.ClientID%>")) {
                    msg += "- Invalid Format of Date.Please Enter in this[dd/MM/yyyy]\n";
                    if (ctrl == "")
                        ctrl = "<%=txtForm.ClientID%>";
                    flag = false;
                }
            }
            else {
                msg += "- Enter From Date\n";
                if (ctrl == "")
                    ctrl = "<%=txtForm.ClientID%>";
                flag = false;
            }
            if (CheckControl("<%=txtTo.ClientID%>")) {
                if (!CheckDate("<%=txtTo.ClientID%>")) {
                    msg += "- Invalid Format of Date.Please Enter in this[dd/MM/yyyy]\n";
                    if (ctrl == "")
                        ctrl = "<%=txtTo.ClientID%>";
                    flag = false;
                }
            }
            else {
                msg += "- Enter To Date\n";
                if (ctrl == "")
                    ctrl = "<%=txtTo.ClientID%>";
                flag = false;
            }
            if (msg != "") alert(msg);
            if (ctrl != "")
                document.getElementById(ctrl).focus();
            return flag;
        }
        function PrintPanel() {
            var panel = document.getElementById("<%=DivPrint.ClientID %>");
            var printWindow = window.open('', '', 'height=400,width=800');
            printWindow.document.write('<html><head><title>Daily Receipt Report</title>');
            printWindow.document.write('</head><body >');
            printWindow.document.write(panel.innerHTML);
            printWindow.document.write('</body></html>');
            printWindow.document.close();
            setTimeout(function () {
                printWindow.print();
            }, 500);
            return false;
        }
    </script>
    <style type="text/css">
        .divModalBackground {
            filter: alpha(opacity=50);
            -moz-opacity: 0.5;
            opacity: 0.5;
            width: 100%;
            height: 100%;
            background-color: #f7e1d2;
            position: fixed;
            top: 0px;
            left: 0px;
            z-index: 100;
        }

            .divModalBackground img {
                left: 50%;
                top: 50%;
                position: absolute;
                z-index: 101;
                width: 32px;
                height: 32px;
                margin-left: -16px;
                margin-top: -16px;
            }
    </style>
    <div class="container">
        <div class="heading">
            <h2>Daily Receipt Report</h2>
        </div>
        <div>
            <asp:UpdatePanel ID="UP1" runat="server">
                <ContentTemplate>
                    <asp:UpdateProgress
                        ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UP1">
                        <ProgressTemplate>
                            <div class="divModalBackground">
                                <img src="../Siteimages/loading.gif" alt="Loading" />
                            </div>
                        </ProgressTemplate>
                    </asp:UpdateProgress>

                    <table>
                        <tr>
                            <td>
                                <div style="float: right; text-align: left;">
                                    <table>
                                        <tr>
                                            <th>Receipt Type</th>
                                            <th>&nbsp;</th>
                                            <th>From Date</th>
                                            <th>&nbsp;</th>
                                            <th>To Date</th>
                                            <th>&nbsp;</th>
                                            <th>Receipt No</th>
                                            <th>&nbsp;</th>
                                            <td></td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:DropDownList ID="ddlReceiptType" runat="server">
                                                    <asp:ListItem Value="1">Fee Payment</asp:ListItem>
                                                    <asp:ListItem Value="2">Doc Payment</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                            <th>&nbsp;</th>
                                            <td>
                                                <asp:TextBox ID="txtForm" runat="server" CssClass="form-control"></asp:TextBox>
                                                <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender1" runat="server" TargetControlID="txtForm"
                                                    MaskType="Date" Mask="99/99/9999">
                                                </ajaxToolkit:MaskedEditExtender>
                                                <ajaxToolkit:CalendarExtender ID="cde1" runat="server" Format="dd/MM/yyyy" TargetControlID="txtForm">
                                                </ajaxToolkit:CalendarExtender>
                                            </td>
                                            <td></td>
                                            <td>
                                                <asp:TextBox ID="txtTo" runat="server" CssClass="form-control"></asp:TextBox>
                                                <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender2" runat="server" TargetControlID="txtTo"
                                                    MaskType="Date" Mask="99/99/9999">
                                                </ajaxToolkit:MaskedEditExtender>
                                                <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd/MM/yyyy"
                                                    TargetControlID="txtTo">
                                                </ajaxToolkit:CalendarExtender>
                                            </td>
                                            <th>&nbsp;</th>
                                            <td>
                                                <asp:TextBox ID="txtReceiptNo" runat="server" CssClass="form-control"></asp:TextBox></td>
                                            <th>&nbsp;</th>
                                            <td>
                                                <asp:Button ID="btnShow" runat="server" Text="Show" CssClass="btn btn-info" OnClick="btnShow_Click" /></td>
                                            <td>
                                                <asp:Button ID="btnNewFormat" runat="server" Text="New Report" OnClick="btnNewFormat_Click" /></td>
                                        </tr>

                                    </table>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <div id="DivPrint" runat="server" style="font-family: 'Book Antiqua'; margin-left: 10px; font-size: 14px; width: 750px; background-color: white; color: black;">
                                    <div style="width: 100%;">
                                        <div style="text-align: justify; vertical-align: top;">
                                            <div style="float: left; width: 20%; padding-left: 20px">
                                                <img src="../Siteimages/PrintLogo.png" alt="" style="width: 70%;" />
                                            </div>
                                            <div style="float: left; text-align: center; width: 70%; font-size: 16px">
                                                <span style="font-size: 23px">Mangalayatan University</span><br />
                                                Extended NCR, 33rd Milestone Mathura, Highway, Beswan<br />
                                                Aligarh, Uttar Pradesh 202145.<br />
                                                <%--  <span style="font-size: 13px">  Telephone: +91 -(05198) – 224413, 224263, 224230 &nbsp;    Email: jrhuniversity@yahoo.com</span><br />--%>
                                            </div>
                                            <div style="clear: both;"></div>
                                        </div>
                                        <div style="font-size: 15px; text-align: center; border-bottom: 1px solid black; border-top: 1px solid black;">
                                            Daily Receipt Report<asp:Label ID="lblSession" runat="server"></asp:Label>
                                        </div>
                                    </div>
                                    <div>
                                        <asp:GridView ID="GridFeeReceipt" runat="server" CssClass="gridDynamic" AutoGenerateColumns="false" ShowFooter="true">
                                            <Columns>
                                                <asp:TemplateField HeaderText="S#">
                                                    <ItemTemplate>
                                                        <%# ((GridViewRow)Container).RowIndex + 1%>
                                                    </ItemTemplate>
                                                    <ItemStyle Width="20px" />
                                                </asp:TemplateField>
                                                <asp:HyperLinkField DataTextField="RECEIPT_NO" ControlStyle-ForeColor="Blue" ItemStyle-Font-Underline="true" ItemStyle-Font-Italic="true" HeaderText="Receipt No" DataNavigateUrlFields="FEE_RCV_RECEIPT_NO" DataNavigateUrlFormatString="prtFeeReceipt.aspx?id={0}" Target="_blank" />
                                                <asp:BoundField DataField="Enrollment_No" HeaderText="Enrollnent" />
                                                <asp:BoundField DataField="STU_FULL_NAME" HeaderText="Student Name" />
                                                <asp:BoundField DataField="PAY_MODE_VALUE" HeaderText="Payment Mode" />
                                                <asp:BoundField DataField="FEE_RCV_TRAN_DT" HeaderText="Date" DataFormatString="{0:dd/MM/yyyy}" />
                                                <asp:BoundField DataField="Amount" HeaderText="Paid Amount" />
                                                <%-- <asp:BoundField DataField="BALANCE" HeaderText="BALANCE" />--%>
                                            </Columns>
                                        </asp:GridView>
                                        <asp:GridView ID="GridDocReceipt" runat="server" CssClass="gridDynamic" AutoGenerateColumns="false" ShowFooter="true">
                                            <Columns>
                                                <asp:TemplateField HeaderText="S#">
                                                    <ItemTemplate>
                                                        <%# ((GridViewRow)Container).RowIndex + 1%>
                                                    </ItemTemplate>
                                                    <ItemStyle Width="20px" />
                                                </asp:TemplateField>
                                                <asp:HyperLinkField DataTextField="FEE_RCV_RECEIPT_NO" ControlStyle-ForeColor="Blue" ItemStyle-Font-Underline="true" ItemStyle-Font-Italic="true" HeaderText="Receipt No" DataNavigateUrlFields="FEE_RCV_RECEIPT_NO" DataNavigateUrlFormatString="prtDocFeeReceipt.aspx?id={0}" Target="_blank" />
                                                <asp:BoundField DataField="Enrollment_No" HeaderText="Enrollnent" />
                                                <asp:BoundField DataField="STU_FULL_NAME" HeaderText="Student Name" />
                                                <asp:BoundField DataField="PAY_MODE_VALUE" HeaderText="Payment Mode" />
                                                <asp:BoundField DataField="FEE_RCV_TRAN_DT" HeaderText="Date" DataFormatString="{0:dd/MM/yyyy}" />
                                                <asp:BoundField DataField="Amount" HeaderText="Paid Amount" />
                                            </Columns>
                                        </asp:GridView>
                                    </div>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <div style="text-align: right;">
                                    <asp:LinkButton ID="lnkPrint" Visible="false" runat="server" OnClientClick="return PrintPanel();" CssClass="btn btn-default pull-right"><i class="fa fa-print"></i> Print</asp:LinkButton>
                                    <div></div>
                            </td>
                        </tr>

                    </table>

                    </div>
                </ContentTemplate>
               <Triggers>
                    <asp:PostBackTrigger ControlID="btnNewFormat" />
               </Triggers>
            </asp:UpdatePanel>
        </div>
</asp:Content>

