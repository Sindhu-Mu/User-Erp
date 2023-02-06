<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/FullLength.master" AutoEventWireup="true" CodeFile="EmpLeaveDetail.aspx.cs" Inherits="HR_EmpLeaveDetail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script lang="javascript" type="text/javascript">
        function CheckAutoComplete(ctrl) {

            var Value = bTrim(document.getElementById(ctrl).value);
            if (Value.indexOf(":") > 0 && Value.length - 1 != Value.lastIndexOf(":")) {
                document.getElementById(ctrl).style.backgroundColor = "#fff";
                return true;
            }
            else
                document.getElementById(ctrl).style.backgroundColor = "#fc6";
            return false;
        }

        function validateView() {
            var flag = true;
            var msg = "", ctrl = "";
            if (!CheckAutoComplete("<%=txtEmployee.ClientID%>")) {
                msg += " * Enter Employee Name & Code. \n";
                if (ctrl == "")
                    ctrl = "<%=txtEmployee.ClientID%>";
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
            <h2>Leave Register</h2>
        </div>
        <div>
            <asp:UpdateProgress ID="UpdateProgress1" runat="server">
                <ProgressTemplate>
                    <img src="../Siteimages/loading.gif" alt="loading" />
                </ProgressTemplate>
            </asp:UpdateProgress>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <table style="width: 100%">

                        <tr>
                            <td>
                                <table style="width: 100%">
                                    
                                        <tr>
                                            <th>BY EMPLOYEE<span style="color: red">*</span></th>

                                            <th>BY YEAR</th>

                                            <th>BY LEAVE TYPE</th>

                                            <th>BY STATUS</th>
                                            <th colspan="2">BY DATE</th>
                                            <td id="tdss" runat="server">&nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:TextBox ID="txtEmployee" runat="server" Width="200px"></asp:TextBox></td>

                                            <td>
                                                <asp:DropDownList ID="ddlYear" runat="server" Width="80px"
                                                    AutoPostBack="True">
                                                </asp:DropDownList>
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="ddlLeaveType" runat="server" Width="100px">
                                                </asp:DropDownList>
                                            </td>

                                            <td>
                                                <asp:DropDownList ID="ddlStatus" runat="server" Width="100px">
                                                    <asp:ListItem Value=".">All</asp:ListItem>
                                                    <asp:ListItem Value="-2">Apply</asp:ListItem>
                                                    <asp:ListItem Value="-1">Arrangement Accept</asp:ListItem>
                                                    <asp:ListItem Value="1">Recommanded</asp:ListItem>
                                                    <asp:ListItem Value="2">Approved</asp:ListItem>
                                                    <asp:ListItem Value="0">Reject</asp:ListItem>
                                                    <asp:ListItem Value="3">Cancel Apply</asp:ListItem>
                                                    <asp:ListItem Value="4">Cancel Approved</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtFromDT" runat="server" Width="80px"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtToDT" runat="server" Width="80px"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:Button ID="btnView" runat="server" Text="View" OnClick="btnView_Click"></asp:Button>
                                                &nbsp;<asp:Button ID="btnNew" runat="server" Text="New" OnClick="btnNew_Click"></asp:Button>
                                                &nbsp;<asp:Button ID="btnPrint" runat="server" Text="Print" OnClick="btnPrint_Click"></asp:Button>
                                                &nbsp;</td>
                                        </tr>
                                   
                                </table>
                            </td>
                        </tr>
                       
                        <tr id="trNew" runat="server">
                            <td>
                                <table style="width: 100%">
                                
                                        <tr style="text-align: left;">
                                            <th>Leave Type<span style="color: red">*</span></th>
                                            <th>Date<span style="color: #ff0000">*</span></th>
                                            <th>Balance<span style="color: #ff0000">*</span></th>
                                            <th>Remark<span style="color: #ff0000">*</span></th>
                                            <th></th>
                                        </tr>
                                        <tr style="vertical-align: top;">
                                            <td>
                                                <asp:DropDownList ID="ddlLvType" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlLvType_SelectedIndexChanged">
                                                </asp:DropDownList></td>
                                            <td>&nbsp;<asp:TextBox ID="txtDate" runat="server"></asp:TextBox></td>
                                            <td>
                                                <asp:TextBox ID="txtCredit" runat="server"></asp:TextBox></td>
                                            <td>
                                                <asp:TextBox ID="txtRemark" runat="server" Width="200px"></asp:TextBox></td>
                                            <td>
                                                <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click"></asp:Button>&nbsp;<asp:Button ID="btnCancel" runat="server" OnClick="btnCancel_Click" Text="Cancel" />
                                            </td>
                                        </tr>
                                 
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:GridView ID="gvBalance" runat="server" EmptyDataText="No record found." AutoGenerateColumns="False" Caption="Leave Balance"
                                    CssClass="gridDynamic" DataKeyNames="LV_ID" OnRowCommand="gvBalance_RowCommand" OnRowDataBound="gvBalance_RowDataBound">
                                    <Columns>
                                        <asp:TemplateField HeaderText="S.No.">
                                            <ItemTemplate><%#((GridViewRow)Container).RowIndex+1 %></ItemTemplate>
                                            <ItemStyle Width="15px" />
                                        </asp:TemplateField>
                                        <asp:BoundField HeaderText="Type" DataField="LV_VALUE" ReadOnly="True" />
                                        <asp:BoundField DataField="OPENING_BAL" HeaderText="Opening Balance" ReadOnly="True"
                                            HtmlEncode="False">
                                            <ItemStyle HorizontalAlign="Right" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="CREDIT_BAL" HeaderText="Credit Balance" HtmlEncode="False">
                                            <ItemStyle HorizontalAlign="Right" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="LAPSED_BAL" HeaderText="Lapsed">
                                            <ItemStyle HorizontalAlign="Right" />
                                        </asp:BoundField>
                                        <asp:BoundField HeaderText="Current. Balance" DataField="CURRENT_BAL" HtmlEncode="False">
                                            <ItemStyle HorizontalAlign="Right" />
                                        </asp:BoundField>
                                        <asp:BoundField HeaderText="Availed" DataField="AVAILED_BAL" ReadOnly="True" HtmlEncode="False">
                                            <ItemStyle HorizontalAlign="Right" />
                                        </asp:BoundField>
                                        <asp:BoundField HeaderText="Applied" DataField="APPLIED_BAL" HtmlEncode="False">
                                            <ItemStyle HorizontalAlign="Right" />
                                        </asp:BoundField>
                                        <asp:CommandField ButtonType="Image" HeaderText="Edit" SelectImageUrl="~/Siteimages/edit.gif"
                                            ShowSelectButton="True" />
                                        <asp:ButtonField ButtonType="Button" Text="Credit" CommandName="Tran" />
                                    </Columns>
                                </asp:GridView>
                            </td>
                        </tr>
                       
                        <tr>
                            <td>
                                <asp:GridView ID="GridShow" runat="server" Width="100%"
                                    EmptyDataText="No Record found." AutoGenerateColumns="False" DataKeyNames="LV_APP_ID" Caption="Leave History"
                                    CssClass="gridDynamic" OnRowCancelingEdit="GridShow_RowCancelingEdit" OnRowDeleting="GridShow_RowDeleting" OnRowEditing="GridShow_RowEditing" OnRowUpdating="GridShow_RowUpdating" OnRowDataBound="GridShow_RowDataBound">
                                    <Columns>
                                        <asp:TemplateField HeaderText="S.No.">
                                            <ItemTemplate><%#((GridViewRow)Container).RowIndex+1 %></ItemTemplate>
                                            <ItemStyle Width="15px" />
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="LV_APP_ID" ReadOnly="True" HeaderText="Leave Id"></asp:BoundField>
                                        <asp:BoundField DataField="REQ_DT" DataFormatString="{0:dd/MM/yyyy}" HeaderText="Req. Date"
                                            ReadOnly="True"></asp:BoundField>
                                        <asp:BoundField DataField="LV_VALUE" HeaderText="Leave type" ReadOnly="True"></asp:BoundField>
                                        <asp:TemplateField HeaderText="From Date">
                                            <EditItemTemplate>
                                                <asp:TextBox ID="txtFrom" runat="server" Text='<%# Bind("FROM_DT", "{0:dd/MM/yyyy}") %>'
                                                    Width="90px"></asp:TextBox>
                                                <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender2" runat="server" TargetControlID="txtFrom"
                                                    Mask="99/99/9999" MaskType="Date">
                                                </ajaxToolkit:MaskedEditExtender>
                                                <ajaxToolkit:CalendarExtender ID="CalendarExtender3" runat="server" TargetControlID="txtFrom"
                                                    Format="dd/MM/yyyy">
                                                </ajaxToolkit:CalendarExtender>
                                            </EditItemTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="Label1" runat="server" Text='<%# Bind("FROM_DT", "{0:dd/MM/yyyy}") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="To Date">
                                            <EditItemTemplate>
                                                <asp:TextBox ID="txtTO" runat="server" Text='<%# Bind("TO_DT", "{0:dd/MM/yyyy}") %>'
                                                    Width="90px"></asp:TextBox>
                                                <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender3" runat="server" TargetControlID="txtTO"
                                                    Mask="99/99/9999" MaskType="Date">
                                                </ajaxToolkit:MaskedEditExtender>
                                                <ajaxToolkit:CalendarExtender ID="CalendarExtender4" runat="server" TargetControlID="txtTO"
                                                    Format="dd/MM/yyyy">
                                                </ajaxToolkit:CalendarExtender>
                                            </EditItemTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="Label2" runat="server" Text='<%# Bind("TO_DT", "{0:dd/MM/yyyy}") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:BoundField DataField="TOT_DAYS" HeaderText="NOD" ReadOnly="True" />
                                        <asp:BoundField DataField="DAY_TYPE_NAME" HeaderText="Day Type" ReadOnly="true" />
                                        <asp:BoundField DataField="Reason" HeaderText="Reason" ReadOnly="True" />
                                        <asp:BoundField HeaderText="Action date" ReadOnly="True" DataField="ACT_DT" DataFormatString="{0:dd/MM/yyyy}"></asp:BoundField>
                                        <asp:BoundField HeaderText="Action By" ReadOnly="True" DataField="ACT_BY"></asp:BoundField>
                                        <asp:BoundField HeaderText="Status" ReadOnly="True" DataField="STS_VALUE"></asp:BoundField>
                                        <asp:BoundField HeaderText="Pending" ReadOnly="True" DataField="PENDING_WITH"></asp:BoundField>
                                        <asp:CommandField ButtonType="Image" CancelImageUrl="~/Siteimages/cancel_icon.gif" EditImageUrl="~/Siteimages/editsmall.gif"
                                            ShowEditButton="True" UpdateImageUrl="~/Siteimages/update_icon.gif" />
                                        <asp:CommandField ButtonType="Image" DeleteImageUrl="~/Siteimages/delete.jpg" ShowDeleteButton="True" />
                                    </Columns>
                                </asp:GridView>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <ajaxToolkit:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" CompletionSetCount="12"
                                    EnableCaching="true" MinimumPrefixLength="1" ServiceMethod="GetEmployeeList"
                                    ServicePath="~\AutoComplete.asmx" TargetControlID="txtEmployee" ContextKey="1,2,3,0">
                                </ajaxToolkit:AutoCompleteExtender>
                                <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender1" runat="server" TargetControlID="txtDate"
                                    Mask="99/99/9999" MaskType="Date">
                                </ajaxToolkit:MaskedEditExtender>
                                <ajaxToolkit:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtDate"
                                    Format="dd/MM/yyyy">
                                </ajaxToolkit:CalendarExtender>
                                <ajaxToolkit:MaskedEditExtender ID="ME1" runat="server" TargetControlID="txtFromDT"
                                    Mask="99/99/9999" MaskType="Date">
                                </ajaxToolkit:MaskedEditExtender>
                                <ajaxToolkit:MaskedEditExtender ID="ME2" runat="server" TargetControlID="txtToDT"
                                    Mask="99/99/9999" MaskType="Date">
                                </ajaxToolkit:MaskedEditExtender>
                                <ajaxToolkit:CalendarExtender ID="cde1" runat="server" TargetControlID="txtFromDT"
                                    Format="dd/MM/yyyy">
                                </ajaxToolkit:CalendarExtender>
                                <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtToDT"
                                    Format="dd/MM/yyyy">
                                </ajaxToolkit:CalendarExtender>
                                <ajaxToolkit:ModalPopupExtender ID="ModalPopupExtender1" runat="server" DropShadow="false"
                                    PopupControlID="Panel1" TargetControlID="tdss">
                                </ajaxToolkit:ModalPopupExtender>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Panel Style="display: none; width: 50%" ID="Panel1" runat="server">
                                    <asp:Panel Style="border-right: gray 1px solid; border-top: gray 1px solid; border-left: gray 1px solid; cursor: move; color: black; border-bottom: gray 1px solid; background-color: #dddddd"
                                        ID="Panel3" runat="server">
                                        <table style="width: 100%">
                                            <tr>
                                                <td style="font-size: 14px; font-weight: bold">Leave Credit Transaction
                                                </td>
                                                <td style="text-align: right">
                                                    <asp:ImageButton ID="CancelButton" runat="server" ImageUrl="~/Siteimages/cancel_icon.gif" /></td>
                                            </tr>
                                        </table>
                                    </asp:Panel>
                                    <asp:GridView ID="gvCredit" runat="server" ShowFooter="True" Width="100%" AutoGenerateColumns="False"
                                        EmptyDataText="Cash Deposit" CssClass="gridDynamic">
                                        <Columns>
                                            <asp:TemplateField HeaderText="S#">
                                                <ItemTemplate>
                                                    <%# ((GridViewRow)Container).RowIndex + 1%>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField HeaderText="Credit Balance" DataField="CR_BAL"></asp:BoundField>
                                            <asp:BoundField DataField="CR_DATE" HeaderText="Credit Date" DataFormatString="{0:dd/MM/yyyy}"></asp:BoundField>
                                            <asp:BoundField DataField="CR_REM" HeaderText="Remarks"></asp:BoundField>
                                        </Columns>
                                    </asp:GridView>
                                </asp:Panel>
                            </td>
                        </tr>

                    </table>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
</asp:Content>

