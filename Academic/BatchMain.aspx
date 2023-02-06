<%@ Page Title="ERP | ACADEMIC BATCH" Language="C#" MasterPageFile="~/MasterPages/FullLength.master" AutoEventWireup="true" CodeFile="BatchMain.aspx.cs" Inherits="Academic_BatchMain" %>

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
            if (bTrim(document.getElementById(ctrl).value) == "" || bTrim(document.getElementById(ctrl).value) == "Select") {
                document.getElementById(ctrl).style.backgroundColor = "#fc6";
                return false;
            }
            else
                document.getElementById(ctrl).style.backgroundColor = "#fff";
            return true;
        }

        function validation() {

            var flag = true;
            var msg = "", ctrl = "";
            if (!CheckControl("<%=txtBatchName.ClientID%>")) {

                msg += "- Enter Batch Name\n";
                if (ctrl == "")
                    ctrl = "<%=txtBatchName.ClientID%>";
                flag = false;
            }


            if (CheckControl("<%=txtBatchDT.ClientID%>")) {
                if (!CheckDate("<%=txtBatchDT.ClientID%>")) {
                    msg += "- Invalid Format of Date.Please Enter in this[dd/MM/yyyy]\n";
                    if (ctrl == "")
                        ctrl = "<%=txtBatchDT.ClientID%>";
                    flag = false;
                }
            }
            else {
                msg += "- Please enter From Date\n";
                if (ctrl == "")
                    ctrl = "<%=txtBatchDT.ClientID%>";
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
            <h2>Academic Batch</h2>
        </div>
        <div>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <table>
                        <tr>
                            <td>
                                <table>
                                    <tr>
                                        <th>Batch Name <span class="required">*</span></th>
                                        <td>&nbsp;</td>
                                        <th>Starting Date<span class="required">*</span></th>
                                        <td>&nbsp;</td>
                                        <th>Description </th>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <cc1:NumericTextBox ID="txtBatchName" runat="server" AllowDecimal="False" AllowNegative="False" DecimalPlaces="-1" Width="104px" MaxLength="4"></cc1:NumericTextBox>
                                        </td>
                                        <td>&nbsp;</td>
                                        <td>

                                            <asp:TextBox ID="txtBatchDT" runat="server" CssClass="textBox"></asp:TextBox>
                                        </td>
                                        <td>&nbsp;</td>
                                        <td>
                                            <asp:TextBox ID="txtDesc" runat="server" CssClass="textBox" Width="261px"></asp:TextBox></td>
                                        <td>&nbsp;</td>
                                        <td>
                                            <asp:Button ID="btnSave" runat="server" Text="Save" Width="70px" OnClick="btnSave_Click" /></td>

                                    </tr>
                                </table>
                            </td>
                        </tr>

                        <tr>
                            <td>
                                <asp:GridView ID="gvShow" runat="server" AutoGenerateColumns="False" DataKeyNames="ACA_BATCH_ID" OnRowCommand="gvShow_RowCommand" Width="100%" EmptyDataText="No Record Avaliable" CssClass="gridDynamic">
                                    <Columns>
                                        <asp:TemplateField HeaderText="S.No.">
                                            <ItemTemplate>
                                                <%# ((GridViewRow)Container).RowIndex + 1%>
                                    .
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField HeaderText="Batch Name" DataField="ACA_BATCH_NAME" />
                                        <asp:BoundField HeaderText="Starting Date" DataField="ACA_BATCH_START_DT" DataFormatString="{0:dd/MM/yyyy}" />
                                        <asp:BoundField HeaderText="Description" DataField="ACA_BATCH_DESC" />
                                        <asp:CommandField ButtonType="Image" SelectImageUrl="~/Siteimages/edit.gif" ShowSelectButton="True" HeaderText="Modify">
                                            <ItemStyle Width="40px" />
                                        </asp:CommandField>
                                        <asp:TemplateField ShowHeader="False" HeaderText="Status">
                                            <ItemStyle Width="20px" HorizontalAlign="Right" />
                                            <ItemTemplate>
                                                <asp:ImageButton ID="ImageButton1" runat="server" CausesValidation="false" CommandArgument='<%# Bind("ACA_BATCH_ID") %>'
                                                    ImageUrl='<%# Bind("STS_IMG") %>' CommandName='<%# Bind("STS_CMD") %>' ToolTip='<%# Bind("STS_TOOLTIP")%>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                    </Columns>
                                </asp:GridView>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd/MM/yyyy"
                                    TargetControlID="txtBatchDT">
                                </ajaxToolkit:CalendarExtender>
                                <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender1" runat="server" Mask="99/99/9999"
                                    MaskType="Date" TargetControlID="txtBatchDT">
                                </ajaxToolkit:MaskedEditExtender>

                            </td>
                        </tr>
                    </table>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
</asp:Content>

