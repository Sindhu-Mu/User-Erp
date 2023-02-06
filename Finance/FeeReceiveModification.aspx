<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/FullLength.master" AutoEventWireup="true" CodeFile="FeeReceiveModification.aspx.cs" Inherits="Finance_FeeReceiveModification" %>

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
     


    </script>
    <div class="container">

        <div class="heading">
            <h2>Fee Receive Modify</h2>
        </div>
        <div id="cBody">
            <div id="cHead" style="float: right;">
                <table style="vertical-align: top">
                    <tr style="vertical-align: bottom; text-align: left">
                        <th>Branch</th>
                        <th>Semester<span class="required">*</span></th>
                        <th>Enrollment No<span class="required">*</span></th>
                        <td></td>
                    </tr>
                    <tr>
                        <td style="height: 19px">
                            <asp:DropDownList ID="ddlBranch" runat="server">
                            </asp:DropDownList>
                        </td>
                        <td style="height: 19px">
                            <asp:DropDownList ID="ddlSemester" runat="server">
                            </asp:DropDownList>
                        </td>
                        <td style="height: 19px">
                            <asp:TextBox ID="txtEnrollment" runat="server" Width="164px" CssClass="textbox">
                            </asp:TextBox>
                        </td>
                        <td style="height: 19px">
                            <asp:Button ID="btnShow" runat="server" Width="60px" Text="Show" OnClick="btnShow_Click"></asp:Button>
                        </td>
                    </tr>
                </table>
            </div>
            <div class="cleaner"></div>
            <div>
                <uc1:Student runat="server" ID="Student" />
               
            </div>

      
        <div>
            <div style="float: left;">
                <table>
                    <tr>
                        <th>
                            <br />
                            Fee Demand
                        </th>
                    </tr>
                    <tr>
                        <td>
                            <hr style="color: #ff0000" />
                        </td>
                    </tr>

                    <tr>
                        <td>
                            <asp:GridView ID="gv" runat="server" AutoGenerateColumns="False" Width="99%" CssClass="gridDynamic">
                                <Columns>
                                    <asp:TemplateField HeaderText="S#">
                                        <ItemTemplate>
                                            <%# ((GridViewRow)Container).RowIndex + 1%>
                                        </ItemTemplate>
                                        <ItemStyle Width="20px" />
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="FEE_MAIN_HEAD_NAME" HeaderText="MAIN HEAD" />
                                    <asp:BoundField DataField="FD_FEE_AMT" DataFormatString="{0:N2}" HeaderText="FEE AMOUNT" />
                                    <asp:BoundField DataField="FD_RCV_AMT" DataFormatString="{0:N2}" HeaderText="RECEIVE AMOUNT" />
                                    <asp:BoundField DataField="FD_BALANCE_AMT" DataFormatString="{0:N2}" HeaderText="BALANCE AMOUNT" />

                                </Columns>
                            </asp:GridView>
                        </td>
                    </tr>
                    <tr>
                        <th>
                            <br />
                            Fee Receive
                        </th>
                    </tr>
                    <tr>
                        <td>
                            <hr style="color: #ff0000" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:GridView ID="gvDetail" runat="server" AutoGenerateColumns="False" Width="99%"
                                CssClass="gridDynamic" DataKeyNames="FEE_RCV_RECEIPT_NO,FEE_RCV_ID" OnRowCommand="gvDetail_RowCommand">
                                <Columns>
                                    <asp:TemplateField HeaderText="S#">
                                        <ItemTemplate>
                                            <%# ((GridViewRow)Container).RowIndex + 1%>
                                        </ItemTemplate>
                                        <ItemStyle Width="20px" />
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="FEE_RCV_RECEIPT_NO" HeaderText="REF#" />
                                    <asp:BoundField DataField="RECEIPT_NO" HeaderText="Receipt No" />
                                    <asp:BoundField DataField="FEE_DEPOSIT_DT" HeaderText="Deposit Date" />
                                    <asp:BoundField DataField="FEE_RCV_TRAN_DT" HeaderText="Entry Date" />
                                    <asp:BoundField DataField="FEE_RCV_AMT" DataFormatString="{0:N2}" HeaderText="RECEIVE AMOUNT" />
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:Button ID="btnDetail" runat="server" Text="Detail" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </td>
                    </tr>

                </table>
            </div>
             <div style="float: left;width:3%;">&nbsp;</div>
            <div style="float: left;" id="divReceive" runat="server" visible="false">
                <table >
                    <tr>
                        <th>
                            <br />
                            Received Detail
                        </th>
                    </tr>
                    <tr>
                        <td>
                            <hr style="color: #ff0000" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:GridView ID="gvRcvDetail" runat="server" AutoGenerateColumns="False" Width="97%" ShowFooter="true"
                                CssClass="gridDynamic">
                                <Columns>
                                    <asp:TemplateField HeaderText="S#">
                                        <ItemTemplate>
                                            <%# ((GridViewRow)Container).RowIndex + 1%>
                                        </ItemTemplate>
                                        <ItemStyle Width="20px" />
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="FEE_MAIN_HEAD_NAME" HeaderText="FEE HEAD" FooterText="TOTAL:-" />
                                    <asp:BoundField DataField="FEE_RCV_TRAN_AMT" DataFormatString="{0:N2}" HeaderText="RECEIVE AMOUNT" />
                                </Columns>
                                <FooterStyle Font-Bold="True" />
                            </asp:GridView>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:GridView ID="gvFeesHead" runat="server" AutoGenerateColumns="False" Width="97%"
                                ShowFooter="True" CssClass="gridDynamic" DataKeyNames="FEE_MAIN_HEAD_ID">
                                <Columns>
                                    <asp:BoundField DataField="FEE_MAIN_HEAD_NAME" HeaderText="FEE HEAD" FooterText="TOTAL:-" />
                                    <asp:TemplateField HeaderText="PAYMENT">
                                        <ItemTemplate>
                                            <cc1:NumericTextBox ID="txtPayAmt" runat="server" Width="100px" CssClass="txtno" AllowDecimal="true"></cc1:NumericTextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                                <FooterStyle Font-Bold="True" />
                            </asp:GridView>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Button ID="btnCal" runat="server" Text="Calculate" CssClass="btnBrown" Visible="false" OnClick="btnCal_Click" />
                            &nbsp;
                                                    <asp:Button ID="btnModify" runat="server" Text="Modify Fee" CssClass="btnBrown" OnClick="btnModify_Click" Visible="false" />
                        </td>
                    </tr>
                </table>
            </div>
            <div class="cleaner"></div>
        </div>
            </div>
    </div>
</asp:Content>

