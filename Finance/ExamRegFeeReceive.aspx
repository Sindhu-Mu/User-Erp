<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/FullLength.master" AutoEventWireup="true" CodeFile="ExamRegFeeReceive.aspx.cs" Inherits="Finance_ExamRegFeeReceive" %>

<%@ Register Src="~/Control/Student.ascx" TagPrefix="uc1" TagName="Student" %>
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
            if (!CheckControl("<%=txtAmount.ClientID%>")) {
                msg += "- Enter Amount \n";
                if (ctrl == "")
                    ctrl = "<%=txtAmount.ClientID%>";
                flag = false;
            }

            if (!CheckControl("<%=txtDiscount.ClientID%>")) {
                msg += "- Enter Discount.\n";
                if (ctrl == "")
                    ctrl = "<%=txtDiscount.ClientID%>";
                flag = false;
            }
            if (!CheckControl("<%=ddltype.ClientID%>")) {
                msg += "- Select Receive Type.\n";
                if (ctrl == "")
                    ctrl = "<%=ddltype.ClientID%>";
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

            if (!CheckControl("<%=ddlExamination.ClientID%>")) {
                msg += "- Select semester no from list.\n";
                if (ctrl == "")
                    ctrl = "<%=ddlExamination.ClientID%>";
                flag = false;
            }
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
            <h2>Examination Fee Receive</h2>
        </div>
        <div id="cBody">
            <asp:UpdatePanel ID="up1" runat="server">
                <ContentTemplate>
                    <div id="cHead" style="float:right;">
                        <table style="vertical-align: top">
                            <tr style="vertical-align: bottom;">
                                <th>Examination<span class="required">*</span></th>
                                <th>Enrollment No<span class="required">*</span></th>
                                <td></td>
                            </tr>
                            <tr>

                                <td>
                                    <asp:DropDownList ID="ddlExamination" runat="server">
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtEnrollment" runat="server" Width="164px" CssClass="textbox">
                                    </asp:TextBox>
                                </td>
                                <td>
                                    <asp:Button ID="btnShow" runat="server" Width="60px" Text="Show" OnClick="btnShow_Click"></asp:Button>
                                </td>
                            </tr>
                        </table>
                    </div>
                    <div id="cCenter" >
                        <table style="width: 100%">
                            <tr>
                                <td>
                                    <uc1:Student runat="server" ID="Student" />
                                </td>
                            </tr>
                                     <tr>
                                <td>
                                    <asp:GridView ID="gvPrevDue" runat="server" AutoGenerateColumns="False" Width="97%"
                                        CssClass="gridDynamic" Caption="Previous Due">
                                         <Columns>
                                            <asp:TemplateField HeaderText="S.No.">
                                                <ItemTemplate>
                                                    <%# ((GridViewRow)Container).RowIndex + 1%>
                                                                .
                                                </ItemTemplate>
                                                <ItemStyle Width="20px" />
                                            </asp:TemplateField>
                                             <asp:BoundField DataField="Caption" HeaderText="Type" />
                                             <asp:BoundField DataField="Balance" HeaderText="Due Amount"></asp:BoundField>
                                             </Columns>
                                        
                                        </asp:GridView>
                                </td>
                            </tr>

                            <tr>
                                <td>
                                    <asp:GridView ID="gvPrevious" runat="server" AutoGenerateColumns="False" Width="97%"
                                        CssClass="gridDynamic" Caption="Previous Transaction">
                                        <Columns>
                                            <asp:TemplateField HeaderText="S.No.">
                                                <ItemTemplate>
                                                    <%# ((GridViewRow)Container).RowIndex + 1%>
                                                                .
                                                </ItemTemplate>
                                                <ItemStyle Width="20px" />
                                            </asp:TemplateField>
                                            <asp:HyperLinkField ItemStyle-Font-Bold="true" ItemStyle-ForeColor="Blue" DataTextField="RECIEPT_NO" HeaderText="Receipt No" DataNavigateUrlFormatString="prtExamRegFee.aspx?={0}" Target="_blank" DataNavigateUrlFields="BACK_FEE_RCV_ID" />

                                            <asp:BoundField DataField="EMP_NAME" HeaderText="Receive By" ReadOnly="True" />
                                            <asp:BoundField DataField="RECIEVE_AMT" HeaderText="Receive Amount"></asp:BoundField>
                                            <asp:BoundField DataField="REG_TRAN_DT" HeaderText="Receive Date" DataFormatString="{0:dd/MM/yyyy}"></asp:BoundField>

                                        </Columns>
                                    </asp:GridView>
                                </td>
                            </tr>
                            <tr>

                                <th>REGISTRATION DETAIL 
                                    <hr style="color: #ff0000" />
                                </th>
                            </tr>


                            <tr>
                                <td>

                                    <asp:GridView ID="gvCrsDetail" runat="server" AutoGenerateColumns="False" Width="97%"
                                        DataKeyNames="BACK_REG_MAIN_ID" CssClass="gridDynamic" ShowFooter="true" OnRowDataBound="gvCrsDetail_RowDataBound">
                                        <Columns>
                                            <asp:TemplateField HeaderText="S.No.">
                                                <ItemTemplate>
                                                    <%# ((GridViewRow)Container).RowIndex + 1%>
                                                                .
                                                </ItemTemplate>
                                                <ItemStyle Width="20px" />
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="CRS_CODE" HeaderText="Course Code" />
                                            <asp:BoundField DataField="CRS_NAME" HeaderText="Course Name" ReadOnly="True" />
                                            <asp:BoundField DataField="CRS_TYPE_VALUE" HeaderText="Course Type" />
                                            <asp:BoundField DataField="CRS_REG_TYPE" HeaderText="Registration Type" ReadOnly="True" FooterText="TOTAL" />
                                            <asp:BoundField DataField="FEEAMT" HeaderText="Amount"/>
                                            <asp:BoundField DataField ="CRS_REG_TYPE_ID" HeaderText="Reg type id"  Visible="TRUE"/>
                                            <asp:BoundField  DataField="CRS_TYP_ID" HeaderText="crs type" Visible="TRUE"/>
                                            <asp:BoundField DataField="BACK_PAPER_DATE" HeaderText="Reg Date" />
                                        </Columns>
                                    </asp:GridView>

                                </td>
                            </tr>
                        </table>
                    </div>
                    <div id="cFooter">
                        <table style="width: 100%">
                            <tr>
                                <th colspan="2">FEE DETAIL
                                      <hr style="color: #ff0000" />
                                </th>
                            </tr>
                            <tr>
                                <th>Demand Amount<span class="required">*</span></th>
                                <td>
                                    <cc1:NumericTextBox ID="txtDemand" runat="server" AllowDecimal="true" AllowNegative="false" DecimalPlaces="2" Width="93px" Enabled="false"></cc1:NumericTextBox>
                            </tr>
                            <tr>
                                <th>Fine Amount <span class="required">*</span></th>
                                <td>
                                    <cc1:NumericTextBox ID="txtFine" runat="server" AllowDecimal="true" AllowNegative="false" DecimalPlaces="2"  Width="93px"></cc1:NumericTextBox>
                                </td>
                            </tr>
                            <tr>
                                <th>Discount/Waybed<span class="required">*</span></th>
                                <td>
                                    <cc1:NumericTextBox ID="txtDiscount" runat="server" AllowDecimal="true" AllowNegative="false" AutoPostBack="True" DecimalPlaces="2" OnTextChanged="txtDiscount_TextChanged" Width="93px">0</cc1:NumericTextBox>
                                </td>
                            </tr>
                            <tr>
                                <th>Hostel Amount</th>
                                <td>
                                    <cc1:NumericTextBox ID="txtHstl" runat="server" AllowDecimal="true" AllowNegative="false" AutoPostBack="True" DecimalPlaces="2" Width="93px">0</cc1:NumericTextBox>
                                </td>
                            </tr>
                            <tr>
                                <th>Receive Amount<span class="required">*</span></th>
                                <td>
                                    <cc1:NumericTextBox ID="txtAmount" runat="server" AllowDecimal="true" AllowNegative="false" DecimalPlaces="2" Width="93px" Enabled="true"></cc1:NumericTextBox>
                                </td>
                            </tr>
                            <tr>
                                <th>Due Amount<span class="required">*</span></th>
                                <td>
                                    <cc1:NumericTextBox ID="txtdue" runat="server" AllowDecimal="true" AllowNegative="false" DecimalPlaces="2" Width="93px" Enabled="true">0</cc1:NumericTextBox>
                                </td>
                            </tr>
                            <tr>
                                <th>Receive Type<span class="required">*</span></th>
                                <td>
                                    <asp:DropDownList ID="ddltype" runat="server">
                                        <asp:ListItem Value="0" Text="Cleared"></asp:ListItem>
                                        <asp:ListItem Value="1" Text="Permission"></asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>

                            <tr>
                                <th>Note/Remark<span class="required">*</span></th>
                                <td>
                                    <asp:TextBox ID="txtRemark" runat="server"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td></td>
                                <td>
                                    <asp:Button ID="btnSave" runat="server" Text="Submit" OnClick="btnSave_Click" Visible="false" /></td>
                            </tr>
                        </table>

                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
</asp:Content>

