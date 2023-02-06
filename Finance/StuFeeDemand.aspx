<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/FullLength.master" AutoEventWireup="true" CodeFile="StuFeeDemand.aspx.cs" Inherits="Finance_StuFeeDemand" %>

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
            if (!CheckControl("<%=ddlProcess.ClientID%>")) {
                msg += "- Select Process no from list \n";
                if (ctrl == "")
                    ctrl = "<%=ddlProcess.ClientID%>";
                flag = false;
            }
            if (!CheckControl("<%=ddlFine.ClientID%>")) {
                msg += "- Select Fine rule from list \n";
                if (ctrl == "")
                    ctrl = "<%=ddlFine.ClientID%>";
                flag = false;
            }
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
            <h2>Student Fee Demand</h2>
        </div>
        <div id="cBody">
            <asp:UpdatePanel ID="up1" runat="server">
                <ContentTemplate>
                    <div id="cHead" style="float:right;">
                        <table style="text-align: left;vertical-align: top">
                            <tr style="vertical-align: bottom; ">
                                <th>Branch</th><td>&nbsp;</td>
                                <th>Semester<span class="required">*</span></th><td>&nbsp;</td>
                                <th>Enrollment No<span class="required">*</span></th><td>&nbsp;</td>
                                <td>&nbsp;</td><td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td style="height: 19px">
                                    <asp:DropDownList ID="ddlBranch" runat="server">
                                    </asp:DropDownList>
                                </td><td>&nbsp;</td>
                                <td style="height: 19px">
                                    <asp:DropDownList ID="ddlSemester" runat="server">
                                    </asp:DropDownList>
                                </td><td>&nbsp;</td>
                                <td style="height: 19px">
                                    <asp:TextBox ID="txtEnrollment" runat="server" Width="164px" CssClass="textbox">
                                    </asp:TextBox>
                                </td><td>&nbsp;</td>
                                <td style="height: 19px">
                                    <asp:Button ID="btnShow" runat="server" Width="60px" Text="Show" OnClick="btnShow_Click"></asp:Button>
                                </td><td>&nbsp;</td><td>&nbsp;</td>
                            </tr>
                        </table>
                    </div>
                    <div class="cleaner"> </div>
                    <div id="cCenter">
                        <table>
                            <tr>
                                <td>
                                    <uc1:Student runat="server" ID="Student" />
                                </td>
                            </tr>
                            <tr>

                                <th>
                                    <br />
                                    Demand Detail
                                </th>
                            </tr>
                            <tr>
                                <td>
                                    <hr style="color: #ff0000" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:UpdatePanel ID="up2" runat="server">
                                        <ContentTemplate>
                                            <asp:GridView ID="gvFees" runat="server" AutoGenerateColumns="False" Width="97%"
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
                                                            <asp:TextBox ID="txtAmount" runat="server" CssClass="txtno" Text='<%# Bind("FD_FEE_AMT") %>'></asp:TextBox>
                                                        </EditItemTemplate>
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblAmt" runat="server" Text='<%# Bind("FD_FEE_AMT", "{0:N2}") %>'></asp:Label>
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Right" />
                                                        <FooterStyle HorizontalAlign="Right" Font-Bold="true" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="ADJUST">
                                                        <EditItemTemplate>
                                                            <asp:TextBox ID="txtAdjust" runat="server" CssClass="txtno" Text='<%# Bind("FD_ADJUST_AMT") %>'></asp:TextBox>
                                                        </EditItemTemplate>
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblAdjAmt" runat="server" Text='<%# Bind("FD_ADJUST_AMT", "{0:N2}") %>'></asp:Label>
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Right" />
                                                        <FooterStyle HorizontalAlign="Right" Font-Bold="true" />
                                                    </asp:TemplateField>

                                                    <asp:BoundField DataField="FEE_WAVE_OFF" HeaderText="WAVE" ReadOnly="True">
                                                        <ItemStyle HorizontalAlign="Right" />
                                                        <FooterStyle HorizontalAlign="Right" Font-Bold="true" />
                                                    </asp:BoundField>

                                                    <asp:BoundField DataField="FD_RCV_AMT" HeaderText="RECEIVE" ReadOnly="True">
                                                        <ItemStyle HorizontalAlign="Right" />
                                                        <FooterStyle HorizontalAlign="Right" Font-Bold="true" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="FD_BALANCE_AMT" HeaderText="BALANCE" ReadOnly="True">
                                                        <ItemStyle HorizontalAlign="Right" />
                                                        <FooterStyle HorizontalAlign="Right" Font-Bold="true" />
                                                    </asp:BoundField>
                                                    <asp:CommandField ButtonType="Image" CancelImageUrl="~/Siteimages/cancel_icon.gif" EditImageUrl="~/Siteimages/editsmall.gif"
                                                        ShowEditButton="True" UpdateImageUrl="~/Siteimages/update_icon.gif" HeaderText="MODIFY" />
                                                    <asp:CommandField ButtonType="Image" DeleteImageUrl="~/Siteimages/delete.jpg" ShowDeleteButton="True" HeaderText="DELETE" />
                                                </Columns>
                                            </asp:GridView>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>

                                    <asp:HiddenField ID="HD1" runat="server" />
                                </td>
                            </tr>
                            <asp:UpdatePanel ID="up3" runat="server">
                                <ContentTemplate>
                                    <tr>
                                        <td>
                                            <table>
                                                <tr style="text-align: left; vertical-align: bottom;">
                                                    <th>PROCESS RULE<span class="required">*</span>
                                                    </th>
                                                    <td></td>
                                                    <th>FINE RULE <span class="required">*</span></th>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:DropDownList ID="ddlProcess" runat="server" Width="120px">
                                                        </asp:DropDownList></td>
                                                    <td style="width: 8px"></td>
                                                    <td>
                                                        <asp:DropDownList ID="ddlFine" runat="server" Width="120px">
                                                        </asp:DropDownList></td>
                                                    <td>&nbsp;
                                                            <asp:Button ID="btnUpdate" runat="server" Text="Update" CssClass="btnBrown" OnClick="btnUpdate_Click" />
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </table>
                    </div>
                    <div id="cFooter">
                        <table>
                            <tr>
                                <td style="vertical-align: top;">
                                    <table>
                                        <tr>
                                            <th colspan="2">
                                                <br />
                                                ADD OTHERS
                                            </th>
                                        </tr>
                                        <tr>
                                            <td colspan="2">
                                                <hr style="color: #ff0000" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 61px">Fee Head<span class="required">*</span></td>
                                            <td>&nbsp;Amount<span class="required">*</span></td>
                                             <td>&nbsp;Remark<span class="required">*</span></td>
                                        </tr>
                                        <tr>
                                            <td style="width: 61px">
                                                <asp:DropDownList ID="ddlFeesHead" runat="server" Width="200px">
                                                </asp:DropDownList></td>
                                            <td>
                                                <cc1:NumericTextBox ID="txtAmount" runat="server" AllowDecimal="true" DecimalPlaces="2" AllowNegative="false" Width="93px"></cc1:NumericTextBox>
                                                <asp:Button ID="btnAdd" runat="server" Text="Add  & Save" Width="100px" OnClick="btnAdd_Click" /></td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
</asp:Content>

