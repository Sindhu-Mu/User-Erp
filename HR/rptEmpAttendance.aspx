<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Short.master" AutoEventWireup="true" CodeFile="rptEmpAttendance.aspx.cs" Inherits="HR_rptEmpAttendance" %>


<%@ Register Src="~/Control/MonthYear.ascx" TagPrefix="uc1" TagName="MonthYear" %>



<asp:Content ID="Content1" ContentPlaceHolderID="ContentHolder1" Runat="Server">
    <script lang="javascript" type="text/javascript">
        function CheckDate(ctrl) {
            var dt = document.getElementById(ctrl).value;
            if (!isDatecheck(dt, "dd/MM/yyyy")) {
                document.getElementById(ctrl).style.backgroundColor = "#fc6";
                return false;
            }
            else
                document.getElementById(ctrl).style.backgroundColor = "#fff";
            return true;
        }
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
        function CheckControl(ctrl) {
            if (bTrim(document.getElementById(ctrl).value) == "" || bTrim(document.getElementById(ctrl).value) == "Select" || bTrim(document.getElementById(ctrl).value) == ".") {
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
            if (!CheckAutoComplete("<%=txtEmployee.ClientID%>")) {
                msg += " * Enter Name with Code. \n";
                if (ctrl == "")
                    ctrl = "<%=txtEmployee.ClientID%>";
                   flag = false;
               }
               if (msg != "") alert(msg);
               if (ctrl != "")
                   document.getElementById(ctrl).focus();
               return flag;
           }

           function validate() {
               var flag = true;
               var msg = "", ctrl = "";
               if (!CheckAutoComplete("<%=txtEmployee.ClientID%>")) {
                msg += " * Enter Name with Code. \n";
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
            <h2>Attendance Status
            </h2>
        </div>
        <div>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <table>

                       
                        <tr>
                            <td valign="top">
                                <table>
                                    <tr>
                                        <th>Month/Year</th>
                                       
                                        <th>Attendance Status</th>
                                       
                                          <th>Employee Name with Code</th>
                                        <td></td>
                                    </tr>
                                    <tr>
                                        <td>
                                          
                                            <uc1:MonthYear runat="server" ID="MonthYear1" />

                                        </td>
                                       
                                        <td>
                                            <asp:DropDownList ID="ddlAttType" runat="server"></asp:DropDownList></td>
                                        <td>
                                            <asp:TextBox ID="txtEmployee" runat="server" placeholder="Employee Name or Text" Width="250px"></asp:TextBox></td>
                                        </td>
                                        <td>
                                            <asp:Button ID="btnShow" runat="server" Text="Show" OnClick="btnShow_Click"/></td>
                             <td>
                                <ajaxToolkit:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" CompletionSetCount="12"
                                    EnableCaching="true" MinimumPrefixLength="1" ServiceMethod="GetEmployeeList"
                                    ServicePath="~\AutoComplete.asmx" TargetControlID="txtEmployee" ContextKey="1,2,0,3">
                                </ajaxToolkit:AutoCompleteExtender>
                            </td>
                                    </tr>

                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:GridView ID="gridAttendance" CssClass="gridDynamic" DataKeyNames="dcDate" Caption="Month Attendance" runat="server" AutoGenerateColumns="False" OnDataBound="gridAttendance_DataBound" >
                                    <Columns>
                                        <asp:BoundField DataField="dcDay" HeaderText="Day" />
                                        <asp:BoundField DataField="dcWeekDay" HeaderText="Week Day" />
                                        <asp:BoundField DataField="dcDutyTime" HeaderText="Shift" ItemStyle-Width="150px"/>
                                        <asp:BoundField DataField="dcInTime" HeaderText="In-Time" ItemStyle-Width="100px"/>
                                        <asp:BoundField DataField="dcOutTime" HeaderText="Out-Time" ItemStyle-Width="100px"/>                                       
                                        <asp:BoundField DataField="dcStatus" HeaderText="Status" ItemStyle-Width="300px" />
                                     
                                    </Columns>
                                </asp:GridView>
                            </td>
                        </tr>
                    </table>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
</asp:Content>

