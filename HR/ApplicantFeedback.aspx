<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/FullLength.master" AutoEventWireup="true" CodeFile="ApplicantFeedback.aspx.cs" Inherits="HR_ApplicantFeedback" %>

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
                          elm[i].id != theBox.id) {

                     if (elm[i].checked != xState)
                         elm[i].click();
                 }
         }
    </script>
    <div class="container">
        <div class="heading">
            <h2>Applicants FeedBack
            </h2>
        </div>
        <div>
            <table>
                <tr>
                    <td>
                        <table>
                            <tr>
                                <td>
                                    <table>
                                        <tr>
                                            <th>Job No.
                                            </th>
                                            <th>Round
                                            </th>
                                            <th>Interview Datetime
                                            </th>

                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:DropDownList ID="ddlJob" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlJob_SelectedIndexChanged"></asp:DropDownList>
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="ddlRound" runat="server" OnSelectedIndexChanged="ddlRound_SelectedIndexChanged" AutoPostBack="true">
                                                    <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                                    <asp:ListItem Text="1st Round" Value="1"></asp:ListItem>
                                                    <asp:ListItem Text="2nd Round" Value="2"></asp:ListItem>
                                                    <asp:ListItem Text="3rd Round" Value="3"></asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="ddlInt" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlInt_SelectedIndexChanged"></asp:DropDownList>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr >
                    <td>
                        <table>
                            <tr id="trDetail" runat="server" visible="false">
                                <td colspan="2">
                                    <asp:GridView ID="gvApplicants" runat="server" AutoGenerateColumns="false" CssClass="gridDynamic" Caption="Applicants Name" DataKeyNames="INT_CAN_ID" EmptyDataText="No Record Found">
                                        <Columns>
                                            <asp:TemplateField HeaderText="S.No.">
                                                <ItemTemplate><%#((GridViewRow)Container).RowIndex+1 %>.</ItemTemplate>
                                                <ItemStyle Width="15px" />
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="NAME" HeaderText="Name" />
                                            <asp:TemplateField HeaderText="All">
                                                <HeaderTemplate>
                                                    <input id="chkAll" onclick="javascript: SelectAllCheckboxes(this);" type="checkbox"
                                                        value="on" runat="server" style="border-right: blue 2px groove; border-top: blue 2px groove; border-left: blue 2px groove; border-bottom: blue 2px groove" />
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:CheckBox ID="CHK_SelectAll" runat="server" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </td>
                            </tr>
                            <tr id="trStatus" runat="server" visible="false">
                                <th>Status
                                </th>
                                <td>
                                    <asp:DropDownList ID="ddlStatus" runat="server" OnSelectedIndexChanged="ddlStatus_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                                </td>
                            </tr>
                            <tr id="trDate" runat="server" visible="false">
                                <th id="thDate" runat="server">Next Round Date
                                </th>
                                <td>
                                    <asp:TextBox ID="txtIntDate" runat="server"></asp:TextBox>
                                    <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtIntDate" Format="dd/MM/yyyy">
                                    </ajaxToolkit:CalendarExtender>
                                    <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender1" runat="server" Mask="99/99/9999" MaskType="Date"
                                        TargetControlID="txtIntDate">
                                    </ajaxToolkit:MaskedEditExtender>
                                </td>
                            </tr>
                            <tr id="trTime" runat="server" visible="false">
                                <th>Time
                                </th>
                                <td>
                                    <asp:TextBox ID="txtInTime" runat="server" Width="50px"></asp:TextBox>
                                    <ajaxToolkit:MaskedEditExtender
                                        ID="MaskedEditExtender3" runat="server" CultureName="en-US"
                                        Mask="99:99" MaskType="Time" TargetControlID="txtInTime" CultureAMPMPlaceholder="AM;PM" CultureCurrencySymbolPlaceholder="$" CultureDateFormat="MDY" CultureDatePlaceholder="/" CultureDecimalPlaceholder="." CultureThousandsPlaceholder="," CultureTimePlaceholder=":" Enabled="True">
                                    </ajaxToolkit:MaskedEditExtender>
                                </td>
                            </tr>
                            <tr id="trMode" runat="server" visible="false">
                                <th>Mode Of Interview</th>
                                <td>
                                    <asp:DropDownList ID="ddlMOI" runat="server"></asp:DropDownList>
                                </td>
                            </tr>
                            <%-- <tr>
                                <th>Remark
                                </th>
                                <td>
                                    <asp:TextBox ID="txtRemark" runat="server"></asp:TextBox>
                                </td>
                            </tr>--%>
                            <tr>
                                <td>
                                    <asp:TextBox ID="TextBox1" runat="server" Visible="false"></asp:TextBox>
                                </td>
                                <td style="text-align: right">
                                    <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" />
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>


            </table>
        </div>
    </div>
</asp:Content>

