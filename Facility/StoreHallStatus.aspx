<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Short.master" AutoEventWireup="true" CodeFile="StoreHallStatus.aspx.cs" Inherits="Facility_StoreHallStatus" %>

<%@ Register Src="~/Control/MonthYear.ascx" TagPrefix="uc1" TagName="MonthYear" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentHolder1" Runat="Server">
    <script lang ="javascript" type="text/javascript">

        function CheckControl(ctrl) {
            if (bTrim(document.getElementById(ctrl).value) == "" || bTrim(document.getElementById(ctrl).value) == "." || bTrim(document.getElementById(ctrl).value) == "Select") {
                document.getElementById(ctrl).style.backgroundColor = "#fc6";
                return false;
            }
            else
                document.getElementById(ctrl).style.backgroundColor = "#fff";
            return true;
        }

    function ValidateHall()
        {
            var flag = true;
            var msg = "", ctrl = "";
            if (!CheckControl("<%=ddlBookedHall.ClientID%>")) {
                msg += "- Select Complex.\n";
                if (ctrl == "")
                    ctrl = "<%=ddlBookedHall.ClientID%>";
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
           <h2>Hall Status</h2>
        </div>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                                        <table>
                                            <tr>
                                                <td>
                                                    <table>
                                                        <tr>
                                                            <th>Month/Year</th>
                                                            <td></td>
                                                             <th>Hall<span class="required">*</span></th>
                                                            </tr>
                                                        <tr>
                                                            <td><uc1:MonthYear runat="server" ID="MonthYear" /></td>
                                                            <td></td>
                                                            <td><asp:DropDownList ID="ddlBookedHall" runat="server"></asp:DropDownList></td>
                                                            <td><asp:Button ID="btnshow" runat="server" Text="View" OnClick="btnshow_Click" /></td>
                                                           </tr>
                                                        </table>
                                                    <table>
                                                        <tr>
                                                            <td>
                                                                <span style="background-color: #ff8080">Holidays</span> and <span style="background-color: #ffff80">
                                                                    Sundays</span> are Highlighted&nbsp;
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                            <td id="tdMain" runat="server">
                                            </td>
                                        </tr>
                                        </table>
                                    </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</asp:Content>

