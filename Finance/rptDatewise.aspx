<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/FullLength.master" AutoEventWireup="true" CodeFile="rptDatewise.aspx.cs" Inherits="Finance_rptDatewise" %>

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
            if (!CheckControl("<%=txtFromDate.ClientID%>")) {
                msg += "- Enter from Date\n";
                if (ctrl == "")
                    ctrl = "<%=txtFromDate.ClientID%>";
                   flag = false;
               }
               if (!CheckControl("<%=txtToDate.ClientID%>")) {
                msg += "- Enter Too Date\n";
                if (ctrl == "")
                    ctrl = "<%=txtToDate.ClientID%>";
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
            <div id="cHead">
                <div>
                    <table style="text-align: left; vertical-align: top">
                        <tr style="vertical-align: bottom;">
                            <th>From Date</th>
                            <td>&nbsp;</td>
                            <th>To Date</th>
                            <td>&nbsp;</td>

                        </tr>
                        <tr>
                            <td style="height: 19px">
                                <asp:TextBox ID="txtFromDate" runat="server"></asp:TextBox>
                                <ajaxToolkit:MaskedEditExtender ID="ME1" runat="server" Mask="99/99/9999" MaskType="Date" TargetControlID="txtFromDate">
                                </ajaxToolkit:MaskedEditExtender>
                                <ajaxToolkit:CalendarExtender ID="CalEx1" runat="server" Format="dd/MM/yyyy" TargetControlID="txtFromDate">
                                </ajaxToolkit:CalendarExtender>
                            </td>
                            <td>&nbsp;</td>
                            <td style="height: 19px">
                                <asp:TextBox ID="txtToDate" runat="server"></asp:TextBox>
                                <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender1" runat="server" Mask="99/99/9999" MaskType="Date" TargetControlID="txtToDate">
                                </ajaxToolkit:MaskedEditExtender>
                                <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd/MM/yyyy" TargetControlID="txtToDate">
                                </ajaxToolkit:CalendarExtender>
                            </td>
                            <td>&nbsp;</td>
                        </tr>
                    </table><br />
                </div>

                <div> <asp:Button ID="btnReport1" runat="server" Text="All Student" OnClick="btnReport1_Click" Height="40px" /><br />
                   <u><b>Click to get data of total outstaing of all active students except fist yesr students.</b></u>
                   
                </div>
                 <div>
                     <asp:Button ID="Button1" runat="server" Text="Ph.D. Scholars" OnClick="btnReport2_Click" Height="40px" /><br />
                   <u><b>Click to get data of total outstaing of Ph.D Scholars.</b></u>
                    
                </div>
            </div>
        </div>
    </div>
</asp:Content>

