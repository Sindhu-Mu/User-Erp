<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/FullLength.master" AutoEventWireup="true" CodeFile="LeaveTransfer.aspx.cs" Inherits="Admin_LeaveTransfer" %>

<%@ Register Src="~/Control/MonthYear.ascx" TagPrefix="uc1" TagName="MonthYear" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    &nbsp;<script lang="javascript" type="text/javascript">
              function CheckControl(ctrl) {
                  if (bTrim(document.getElementById(ctrl).value) == "" || bTrim(document.getElementById(ctrl).value) == ".") {
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
                  if (!CheckControl("<%=ddlIns.ClientID%>")) {
                      msg += " * Select Institue \n";
                      if (ctrl == "")
                          ctrl = "<%=ddlIns.ClientID%>";
                          flag = false;
                      }
                      if (!CheckControl("<%=ddlDept.ClientID%>")) {
                      msg += " * Select Department \n";
                      if (ctrl == "")
                          ctrl = "<%=ddlDept.ClientID%>";
                    flag = false;
                }
                if (!CheckControl("<%=ddlPending.ClientID%>")) {
                      msg += " * Select Pending With \n";
                      if (ctrl == "")
                          ctrl = "<%=ddlPending.ClientID%>";
                    flag = false;
                }

                if (msg != "") alert(msg);
                if (ctrl != "")
                    document.getElementById(ctrl).focus();
                return flag;
            }

            function validationSave() {
                var flag = true;
                var msg = "", ctrl = "";
                if (!CheckControl("<%=ddlPending.ClientID%>")) {
                      msg += " * Select Pending With \n";
                      if (ctrl == "")
                          ctrl = "<%=ddlPending.ClientID%>";
                flag = false;
            }



            if (!CheckControl("<%=ddlTransfer.ClientID%>")) {
                      msg += " * Select Transfer To \n";
                      if (ctrl == "")
                          ctrl = "<%=ddlTransfer.ClientID%>";
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
            <h2>Leave Transfer</h2>
        </div>
        <div>
            <table>
                <tr>
                    <td>
                        <table>


                            <tr>
                                <th>Institute
                                </th>
                                <th>Department
                                </th>
                                <th>Pending With
                                </th>
                                <th>Month
                                </th>
                            </tr>
                            <tr>
                                <td>
                                    <asp:DropDownList ID="ddlIns" runat="server" OnSelectedIndexChanged="ddlIns_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlDept" runat="server" OnSelectedIndexChanged="ddlDept_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlPending" runat="server" OnSelectedIndexChanged="ddlPending_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                                </td>
                                <td>
                                    <uc1:monthyear runat="server" id="MonthYear1" />
                                </td>
                                <td>
                                    <asp:Button ID="btnShow" runat="server" Text="Show" OnClick="btnShow_Click" />
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr id="trGrid" runat="server">
                    <td>

                        <div>
                            <asp:GridView ID="gvDetail" runat="server" AutoGenerateColumns="false" DataKeyNames="LV_APP_ID" EmptyDataText="No Record Found">
                                <Columns>
                                    <asp:BoundField DataField="EMP_NAME" HeaderText="Name" />
                                    <asp:BoundField DataField="LV_VALUE" HeaderText="Leave" />
                                    <asp:BoundField DataField="FROM_DT" HeaderText="From Date" DataFormatString="{0:dd/MM/yyyy}" />
                                    <asp:BoundField DataField="TO_DT" HeaderText="To Date" DataFormatString="{0:dd/MM/yyyy}" />
                                    <asp:BoundField DataField="TOT_DAYS" HeaderText="Total days" />
                                    <asp:BoundField DataField="STS_VALUE" HeaderText="Status" />
                                    <asp:BoundField DataField="PENDING_WITH" HeaderText="Pending With" />
                                </Columns>
                            </asp:GridView>
                        </div>
                    </td>
                </tr>
                <tr id="trTransfer" runat="server" visible="false">
                    <td>
                        <table>
                            <tr>
                                <th>Transfer To:</th>
                                <td>
                                    <asp:DropDownList ID="ddlTransfer" runat="server"></asp:DropDownList>
                                </td>
                                <td>
                                    <asp:Button ID="btnTransfer" runat="server" Text="Transfer" OnClick="btnTransfer_Click" />
                                </td>
                                <td>
                                    <asp:TextBox ID="TextBox1" runat="server" Visible="false"></asp:TextBox>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </div>
    </div>
</asp:Content>
