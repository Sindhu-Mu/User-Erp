<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/FullLength.master" AutoEventWireup="true" CodeFile="BoysHostelAtt.aspx.cs" Inherits="Facility_BoysHostelAtt" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
       <script lang="javascript" type="text/javascript">
           function CheckControl(ctrl) {
               if (bTrim(document.getElementById(ctrl).value) == "" || bTrim(document.getElementById(ctrl).value) == "." || bTrim(document.getElementById(ctrl).value) == "Select") {
                   document.getElementById(ctrl).style.backgroundColor = "#fc6";
                   return false;
               }
               else {
                   document.getElementById(ctrl).style.backgroundColor = "#fff";
                   return true;
               }
           }
           function validate() {
               var flag = true;
               var msg = "", ctrl = "";
               if (!CheckControl("<%=txtDate.ClientID%>")) {
                msg += "- Enter Date\n";
                if (ctrl == "")
                    ctrl = "<%=txtDate.ClientID%>";
                flag = false;
            } if (msg != "") alert(msg);
            if (ctrl != "")
                document.getElementById(ctrl).focus();
            return flag;
        }
    </script>
    <div class="container">
        <div class="heading">
            <h2>Hostel Student Attendance</h2>
        </div>
        <div style="text-align:right;">
            <table>
                <tr>
                    <th>Date
                    </th>
                      </tr>
                 <tr>
                    <td>
                        <asp:TextBox ID="txtDate" runat="server" AutoCompleteType="None"></asp:TextBox>
                        <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtDate" Format="dd/MM/yyyy">
                        </ajaxToolkit:CalendarExtender>
                        <td>&nbsp;
                            </td>
                    <td>
                        <asp:Button ID="btnShow" runat="server" Text="Show" OnClick="btnShow_Click" />
                    </td>
                </tr>
            </table>
        </div>
        <div>
            <asp:GridView ID="gridAttendance" CssClass="gridDynamic" runat="server" AutoGenerateColumns="False" Caption="Daily Attendance">
                <Columns>
                    <asp:BoundField DataField="ENROLLMENT_NO" HeaderText="Enrollment No" />
                    <asp:BoundField DataField="STU_FULL_NAME" HeaderText="Name" />
                    <asp:BoundField DataField="ATT_DATE" HeaderText="Date" />
                    <asp:BoundField DataField="In_Time" HeaderText="In-Time" ItemStyle-Width="90px" />
                    <asp:BoundField DataField="Out_Time" HeaderText="Out-Time" ItemStyle-Width="90px" />

                </Columns>
            </asp:GridView>
        </div>
    </div>
</asp:Content>
