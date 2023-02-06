<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Short.master" AutoEventWireup="true" CodeFile="InterviewMain.aspx.cs" Inherits="HR_InterviewMain" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentHolder1" runat="Server">
     <script language ="javascript" type="text/javascript">

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

         function CheckControl(ctrl) {
             if (bTrim(document.getElementById(ctrl).value) == "" || bTrim(document.getElementById(ctrl).value) == ".") {
                 document.getElementById(ctrl).style.backgroundColor = "#fc6";
                 return false;
             }
             else
                 document.getElementById(ctrl).style.backgroundColor = "#fff";
             return true;
         }
         function validat() {
             var flag = true;
             var msg = "", ctrl = "";
             if (!CheckControl("<%=ddlJob.ClientID%>")) {
                msg += " * Select Job from list. \n";
                if (ctrl == "")
                    ctrl = "<%=ddlJob.ClientID%>";
                flag = false;
             }
             if (!CheckControl("<%=ddlRound.ClientID%>")) {
                 msg += " * Select Round from list. \n";
                 if (ctrl == "")
                     ctrl = "<%=ddlRound.ClientID%>";
                flag = false;
             }
             if (!CheckControl("<%=txtIntDate.ClientID%>")) {
                 msg += " * Enter Date. \n";
                 if (ctrl == "")
                     ctrl = "<%=txtIntDate.ClientID%>";
                 flag = false;
             }
             if (!CheckControl("<%=txtInTime.ClientID%>")) {
                 msg += " * Enter Time. \n";
                 if (ctrl == "")
                     ctrl = "<%=txtInTime.ClientID%>";
                 flag = false;
             }
             if (!CheckControl("<%=ddlMOI.ClientID%>")) {
                 msg += " * Select Mode Of Interview. \n";
                 if (ctrl == "")
                     ctrl = "<%=ddlMOI.ClientID%>";
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
            <h2>Interview Main
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
                                            <th>Job No.<span class="required">*</span>
                                            </th>
                                            <th>Round<span class="required">*</span>
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
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr id="trDetail" runat="server" visible="false">
                    <td>
                        <div>
                            <asp:GridView ID="gvDetail" runat="server" AutoGenerateColumns="false" CssClass="gridDynamic" EmptyDataText="No Record Found" DataKeyNames="INT_CAN_ID">
                                <Columns>
                                    <asp:TemplateField HeaderText="S.No.">
                                        <ItemTemplate><%#((GridViewRow)Container).RowIndex+1 %>.</ItemTemplate>
                                        <ItemStyle Width="15px" />
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="NAME" HeaderText="Name" />
                                    <asp:BoundField DataField="DATE" HeaderText="Interview Date" />
                                    <asp:BoundField DataField="TIME" HeaderText="Interview Time" />
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
                        </div>
                    </td>
                </tr>
                <tr id="trInt" runat="server" visible="false">
                    <td>
                        <table>
                            <tr >
                                <th id="thDate" runat="server">Interview Date<span class="required">*</span>
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
                            <tr >
                                <th>Time<span class="required">*</span>
                                </th>
                                <td>
                                    <asp:TextBox ID="txtInTime" runat="server" Width="40px"></asp:TextBox>
                                    <ajaxToolkit:MaskedEditExtender
                                        ID="MaskedEditExtender3" runat="server" CultureName="en-US"
                                        Mask="99:99" MaskType="Time" TargetControlID="txtInTime" CultureAMPMPlaceholder="AM;PM" CultureCurrencySymbolPlaceholder="$" CultureDateFormat="MDY" CultureDatePlaceholder="/" CultureDecimalPlaceholder="." CultureThousandsPlaceholder="," CultureTimePlaceholder=":" Enabled="True">
                                    </ajaxToolkit:MaskedEditExtender>
                                </td>
                            </tr>
                            <tr >
                                <th>Mode Of Interview<span class="required">*</span></th>
                                <td>
                                    <asp:DropDownList ID="ddlMOI" runat="server"></asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:TextBox ID="TextBox1" runat="server" Visible="false"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:Button id="btnSave" Text="Save" runat="server" OnClick="btnSave_Click"/>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </div>
    </div>
</asp:Content>

