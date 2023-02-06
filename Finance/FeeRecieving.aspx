<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/FullLength.master" AutoEventWireup="true" CodeFile="FeeRecieving.aspx.cs" Inherits="Finance_BankAccount" %>

<%@ Register Src="~/Control/Student.ascx" TagPrefix="uc1" TagName="Student" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script lang="javascript" type="text/javascript">
        // Client Side Validation Script

        function CheckDate(ctrl) {
            var dt = document.getElementById(ctrl).value;
            if (isDatecheck(dt, "mm/dd/yyyy") == false) {
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
        function validation() {
            var flag = true;
            var msg = "", ctrl = "";

            if (CheckControl("<%=txtDepositDate.ClientID%>")) {
                if (!CheckDate("<%=txtDepositDate.ClientID%>")) {
                    msg += "- Invalid Format of Date.Enter in this[dd/MM/yyyy]\n";
                    if (ctrl == "")
                        ctrl = "<%=txtDepositDate.ClientID%>";
                    flag = false;
                }
            }
            else {
                msg += "- Enter Receipt Date\n";
                if (ctrl == "")
                    ctrl = "<%=txtDepositDate.ClientID%>";
                flag = false;
            }
            if (msg != "") alert(msg);
            if (ctrl != "")
                document.getElementById(ctrl).focus();
            return flag;
        }
        function Cashvalidat() {

            var flag = true;
            var msg = "", ctrl = "";
            if (!CheckControl("<%=ddlPaymentMode.ClientID%>")) {
                msg += "- Select Payment Mode from list \n";
                if (ctrl == "")
                    ctrl = "<%=ddlPaymentMode.ClientID%>";
                flag = false;
            }
            if (!CheckControl("<%=txtModeAmount.ClientID%>")) {
                msg += "- Enter Amount \n";
                if (ctrl == "")
                    ctrl = "<%=txtModeAmount.ClientID%>";
                flag = false;
            }
            if (msg != "") alert(msg);
            if (ctrl != "")
                document.getElementById(ctrl).focus();
            return flag;
        }
        function Adjustmentvalidat() {

            var flag = true;
            var msg = "", ctrl = "";
            if (!CheckControl("<%=ddlPaymentMode.ClientID%>")) {
                msg += "- Select Payment Mode from list \n";
                if (ctrl == "")
                    ctrl = "<%=ddlPaymentMode.ClientID%>";
                flag = false;
            }
            if (!CheckControl("<%=txtModeAmount.ClientID%>")) {
                msg += "- Enter Amount \n";
                if (ctrl == "")
                    ctrl = "<%=txtModeAmount.ClientID%>";
                flag = false;
            }

            if (msg != "") alert(msg);
            if (ctrl != "")
                document.getElementById(ctrl).focus();
            return flag;
        }
        function Othervalidat() {

            var flag = true;
            var msg = "", ctrl = "";
            if (!CheckControl("<%=ddlPaymentMode.ClientID%>")) {
                msg += "- Select Payment Mode from list \n";
                if (ctrl == "")
                    ctrl = "<%=ddlPaymentMode.ClientID%>";
                flag = false;
            }

            if (!CheckControl("<%=txtModeAmount.ClientID%>")) {
                msg += "- Enter Amount \n";
                if (ctrl == "")
                    ctrl = "<%=txtModeAmount.ClientID%>";
                flag = false;
            }

            if (msg != "") alert(msg);
            if (ctrl != "")
                document.getElementById(ctrl).focus();
            return flag;
        }


    </script>
    <script type="text/javascript">
        var isSubmitted = 0
        function preventMultipleSubmissions() {
            if (++isSubmitted>1) {
                alert('Receipt transaction is in process. Wait.....');
                return false;
           }
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
            <h2>
                <!-- Page Heading-->
                Student Fee Receiving 
            </h2>

        </div>
        <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel1">
            <ProgressTemplate>
                <div class="divModalBackground">
                    <img src="../Siteimages/loading.gif" alt="Loading" />
                </div>
            </ProgressTemplate>
        </asp:UpdateProgress>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <div id="cBody">
                    <div id="cHead" style="float: right;">
                        <!-- Content  Header ex: Filters-->
                        <table>
                            <tr>
                                <td>
                                    <asp:DropDownList ID="ddlBranch" runat="server"></asp:DropDownList>
                                    <asp:HiddenField ID="HiddenField1" runat="server" />
                                </td>
                                <td>&nbsp;</td>
                                <td>
                                    <asp:DropDownList ID="ddlSem" runat="server"></asp:DropDownList></td>
                                <td>&nbsp;</td>
                                <td>
                                    <asp:TextBox ID="txtEnrollment" runat="server" Width="250px"></asp:TextBox></td>
                                <td>&nbsp;</td>
                                <td>
                                    <asp:Button ID="btnShow" runat="server" Text="Show" OnClick="btnShow_Click" /></td>
                            </tr>
                        </table>
                    </div>
                    <div class="cleaner"></div>
                    <div id="cCenter">
                        <div>
                            <!-- Content Header ex: Grids-->
                            <uc1:Student runat="server" ID="Student" />
                            <br />
                        </div>
                        <div>
                            <table style="width: 100%">
                                <tr>
                                    <td style="width: 50%; vertical-align: top" id="divDemand" runat="server">
                                        <div>
                                            <b>Account Credit : Rs.
                                <asp:Label runat="server" ID="lblCredit"></asp:Label></b>
                                        </div>
                                        <hr />
                                        <div id="divDemand_2" runat="server">
                                            Fee Demand
                                        <hr />
                                            <asp:GridView ID="gvFees" runat="server" AutoGenerateColumns="False" Width="97%"
                                                ShowFooter="True" CssClass="gridDynamic" DataKeyNames="FEE_DEMAND_ID,FEE_MAIN_HEAD_ID">
                                                <Columns>
                                                    <asp:BoundField DataField="FEE_MAIN_HEAD_NAME" HeaderText="FEE HEAD" FooterText="TOTAL:-" />
                                                    <asp:BoundField DataField="DUE_AMOUNT" DataFormatString="{0:N2}" HeaderText="DUE AMOUNT" />
                                                    <asp:TemplateField HeaderText="PAYMENT">
                                                        <ItemTemplate>
                                                            <cc1:NumericTextBox ID="txtPayAmt" runat="server" Width="100px" CssClass="txtno" AllowDecimal="true"></cc1:NumericTextBox>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="FROM CREDIT">
                                                        <ItemTemplate>
                                                            <cc1:NumericTextBox ID="txtCredit" runat="server" Width="100px" CssClass="txtno" AllowDecimal="true"></cc1:NumericTextBox>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                                <FooterStyle Font-Bold="True" />
                                            </asp:GridView>
                                        </div>
                                        <div id="divAdv" runat="server" visible="false">
                                            <p>Advance</p>
                                            <hr />
                                            <table style="text-align: left; width: 100%;">
                                                <tr>
                                                    <th>&nbsp; Advance Head</th>
                                                    <td>
                                                        <asp:DropDownList ID="ddlAdvance" runat="server">
                                                            <asp:ListItem Value="52">Academic Fee</asp:ListItem>
                                                            <asp:ListItem Value="51">Facility Fee</asp:ListItem>
                                                        </asp:DropDownList></td>
                                                </tr>
                                                <tr>
                                                    <th>&nbsp; Fee Amount</th>
                                                    <td>
                                                        <cc1:NumericTextBox ID="txtFees" runat="server" CssClass="textbox"></cc1:NumericTextBox></td>
                                                </tr>
                                                <tr>
                                                    <td></td>
                                                    <td>
                                                        <asp:Button runat="server" ID="rcvAdv" Text="Recive" OnClick="btnAdvRcv_Click" /></td>
                                                </tr>

                                            </table>
                                            <asp:Label runat="server" ID="lblRegIg"></asp:Label>
                                            <asp:TextBox ID="txtData" runat="server" Visible="false"></asp:TextBox>
                                        </div>
                                    </td>
                                    <td style="width: 50%">
                                        <div>
                                            <b>Payment Details</b><hr />
                                        </div>
                                        <div>
                                            <table>
                                                <tr>
                                                    <td>Payment Mode</td>
                                                    <td>
                                                        <asp:DropDownList ID="ddlPaymentMode" runat="server" OnSelectedIndexChanged="ddlPaymentMode_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList></td>
                                                </tr>
                                            </table>
                                        </div>
                                        <div id="trRefDetail" runat="server" style="text-align: left;">
                                            <table style="width: 100%;">
                                                <tr>
                                                    <td>
                                                        <b>
                                                            <asp:Label ID="lblRefType" runat="server"></asp:Label>&nbsp;</b>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtRefNo" runat="server" CssClass="textbox" Width="150px"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>Bank Name</td>
                                                    <td>
                                                        <asp:DropDownList ID="ddlBank" runat="server" Width="200px">
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>Branch Name</td>
                                                    <td>
                                                        <asp:TextBox ID="txtBranchName" runat="server" CssClass="textbox" Width="150px"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>Account No</td>
                                                    <td>
                                                        <asp:DropDownList ID="ddlAcountNo" runat="server" Width="200px">
                                                        </asp:DropDownList></td>
                                                </tr>
                                                <tr>
                                                    <td>Deposit Date</td>
                                                    <td>
                                                        <asp:TextBox ID="txtDate" runat="server" CssClass="textbox" Width="85px"></asp:TextBox></td>
                                                    <ajaxToolkit:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtDate" Format="dd/MM/yyyy">
                                                    </ajaxToolkit:CalendarExtender>
                                                    <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender2" runat="server" Mask="99/99/9999" MaskType="Date" TargetControlID="txtDate">
                                                    </ajaxToolkit:MaskedEditExtender>
                                                </tr>
                                            </table>
                                        </div>
                                        <div id="DivAdjustment" runat="server" style="text-align: left;" visible="false">
                                            <table>
                                                <tr>
                                                    <td>Deposit Date</td>
                                                    <td>
                                                        <asp:TextBox ID="TextBox1" runat="server" CssClass="textbox" Width="100px"></asp:TextBox></td>
                                                    <ajaxToolkit:CalendarExtender ID="CalendarExtender3" runat="server" TargetControlID="txtDate" Format="dd/MM/yyyy">
                                                    </ajaxToolkit:CalendarExtender>
                                                    <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender3" runat="server" Mask="99/99/9999" MaskType="Date" TargetControlID="txtDate">
                                                    </ajaxToolkit:MaskedEditExtender>
                                                </tr>
                                            </table>
                                        </div>
                                        <hr />
                                        <div>
                                            Amount &nbsp;&nbsp;&nbsp;<cc1:NumericTextBox ID="txtModeAmount" runat="server"></cc1:NumericTextBox>&nbsp;&nbsp;&nbsp;
                                   <asp:Button runat="server" ID="btnModeAdd" Text="Add Detail" OnClick="btnModeAdd_Click" />
                                            &nbsp;&nbsp;&nbsp; 
                                   <asp:HyperLink ID="HyperLink" Text="View Ledger" NavigateUrl="leadger.aspx?<%##%>>" Target="blank" runat="server"></asp:HyperLink>
                                        </div>
                                        <hr />
                                        <div>
                                            <asp:GridView ID="gvRefDetail" runat="server" AutoGenerateColumns="False" Width="100%"
                                                OnRowDeleting="gvRefDetail_RowDeleting" ShowFooter="True" CssClass="gridDynamic">
                                                <Columns>
                                                    <asp:BoundField HeaderText="S#" />
                                                    <asp:BoundField DataField="PAY_MODE" HeaderText="Pay Mode" />
                                                    <asp:BoundField DataField="BANK" HeaderText="Bank" />
                                                    <asp:BoundField HeaderText="REF. No" DataField="RCV_TRAN_MODE_NO" />
                                                    <asp:BoundField DataField="RCV_TRAN_MODE_DT" HeaderText="Date" DataFormatString="{0:dd/MM/yyyy}"
                                                        HtmlEncode="False" FooterText="Total:-">
                                                        <FooterStyle HorizontalAlign="Right" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="RCV_TRAN_MODE_AMT" HeaderText="Amount" DataFormatString="{0:N2}"
                                                        HtmlEncode="False">
                                                        <FooterStyle HorizontalAlign="Right" />
                                                        <ItemStyle HorizontalAlign="Right" />
                                                    </asp:BoundField>
                                                    <asp:CommandField ButtonType="Image" DeleteImageUrl="~/images/delete.gif" ShowDeleteButton="True" />
                                                </Columns>
                                                <HeaderStyle ForeColor="#CC0000" />
                                            </asp:GridView>
                                        </div>
                                        <div id="deposit_remark">
                                            <table style="width: 100%;">
                                                <tr>
                                                    <td>Receipt Date</td>
                                                    <td>
                                                        <asp:TextBox ID="txtDepositDate" runat="server"></asp:TextBox>
                                                        <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtDepositDate" Format="dd/MM/yyyy">
                                                        </ajaxToolkit:CalendarExtender>
                                                        <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender1" runat="server" Mask="99/99/9999" MaskType="Date" TargetControlID="txtDepositDate">
                                                        </ajaxToolkit:MaskedEditExtender>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>Remark</td>
                                                    <td>
                                                        <asp:TextBox ID="txtRemark" runat="server" Width="90%"></asp:TextBox></td>

                                                </tr>
                                            </table>
                                        </div>
                                        <div style="text-align: center">
                                            <asp:Button ID="btnReceive" runat="server" CssClass="btnBrown" Text="Receive Fee" OnClientClick="return preventMultipleSubmissions();" OnClick="btnReceive_Click" />
                                            <br />
                                            <asp:Label ID="lblMsg" runat="server" Font-Bold="True" ForeColor="Red" Font-Size="Large"></asp:Label>
                                        </div>
                                    </td>

                                </tr>
                            </table>

                        </div>
                    </div>
                    <div id="cFooter">
                        <!-- Content Header ex:Buttons-->

                    </div>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>

</asp:Content>

