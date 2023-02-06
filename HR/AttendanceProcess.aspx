<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/FullLength.master" AutoEventWireup="true" CodeFile="AttendanceProcess.aspx.cs" Inherits="HR_AttendanceProcess" %>

<%@ Register Src="../Control/MonthYear.ascx" TagName="MonthYear" TagPrefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
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
             if (!CheckControl("<%=ddlInstitution.ClientID%>")) {
                msg += " * Select Institute from list. \n";
                if (ctrl == "")
                    ctrl = "<%=ddlInstitution.ClientID%>";
                   flag = false;
             }
             if (!CheckControl("<%=ddlCodeType.ClientID%>")) {
                 msg += " * Select job type from list. \n";
                 if (ctrl == "")
                     ctrl = "<%=ddlCodeType.ClientID%>";
                flag = false;
            }
             if (!CheckControl("<%=txtClosingDate.ClientID%>")) {
                 msg += " * Enter Closing date. \n";
                 if (ctrl == "")
                     ctrl = "<%=txtClosingDate.ClientID%>";
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
            <h2>Attendance Process</h2>
        </div>
        <div>
            <asp:UpdateProgress ID="UpdateProgress1" runat="server">
                <ProgressTemplate>
                    <img src="../Siteimages/loading.gif" alt="loading" /></ProgressTemplate>
            </asp:UpdateProgress>

            <asp:UpdatePanel ID="updatePannel" runat="server">
                <ContentTemplate>

                    <table>
                        <tr>
                            <th>Month/Year</th>
                            <th>Institute<samp class="required"> *</samp></th>
                            <th>Employee Type<samp class="required"> *</samp></th>
                            <th>Closing Date<samp class="required"> *</samp></th>
                            <th>Process For</th>
                            <th></th>
                           <th></th>
                        </tr>
                        <tr>
                            <td>
                                <uc2:MonthYear ID="MonthYear1" runat="server" />
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlInstitution" runat="server"></asp:DropDownList></td>
                            <td>
                                <asp:DropDownList ID="ddlCodeType" runat="server" Width="105px">
                                    <asp:ListItem>Select</asp:ListItem>
                                    <asp:ListItem Value="1">Teaching</asp:ListItem>
                                    <asp:ListItem Value="0">Non-Teaching</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td>
                                <asp:TextBox ID="txtClosingDate" runat="server"></asp:TextBox>
                                <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtClosingDate" Format="dd/MM/yyyy">
                                </ajaxToolkit:CalendarExtender>
                                <td>
                                    <asp:DropDownList ID="ddlProcessType" runat="server" Width="105px">
                                        <asp:ListItem Value="0">Main</asp:ListItem>
                                        <asp:ListItem Value="1">Balance</asp:ListItem>
                                    </asp:DropDownList></td>
                            <td>
                                <asp:Button ID="btnProcess" runat="server" Text="Process" OnClick="btnProcess_Click" />
                            </td>
                            <td>
                                <asp:Button ID="btnProcessAgain" runat="server" Text="Process Again" />
                            </td>
                        </tr>
                    </table>
                    <table>
                        <tr>
                            <td>
                                <asp:GridView ID="gridView" runat="server" AutoGenerateColumns="false" CssClass="gridDynamic" OnRowCommand="dgShow_RowCommand" DataKeyNames="EMP_ID">
                                    <Columns>
                                        <asp:TemplateField HeaderText="Sr No.">
                                            <ItemTemplate>
                                                <%# ((GridViewRow)Container).RowIndex + 1%>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="EMP_NAME" HeaderText="Employee" />
                                        <asp:BoundField DataField="EMP_ID" HeaderText="Employee Code" />
                                        <asp:BoundField DataField="DEPT_VALUE" HeaderText="Department" />
                                        <asp:BoundField DataField="TOTAL" HeaderText="Total Days" />
                                        <asp:BoundField DataField="PRV" HeaderText="Previous Days" />
                                        <asp:BoundField DataField="NOD" HeaderText="Payble Days" />
                                        <asp:BoundField DataField="LOP" HeaderText="No. Of LOP" />
                                        <asp:CommandField SelectText="Detail" ShowSelectButton="True" HeaderText="Detail" ButtonType="Link">
                                            <ItemStyle Width="55px" />
                                        </asp:CommandField>
                                    </Columns>
                                </asp:GridView>

                                <div>
                                    <asp:GridView runat="server" ID="gvlop" AutoGenerateColumns="False" GridLines="None"
                                        CssClass="gridDynamic" EmptyDataText="No Records Found" ShowFooter="True">
                                        <Columns>
                                            <asp:TemplateField HeaderText="S.No.">
                                                <ItemTemplate>
                                                    <%# ((GridViewRow)Container).RowIndex + 1%>
                                                    .
                                                </ItemTemplate>
                                                <ItemStyle Width="20px" />
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="LOP_DT" DataFormatString="{0:dd/MM/yyyy}" HeaderText="Date" />
                                            <asp:BoundField DataField="LOP_NOD" HeaderText="NOD" />
                                            <asp:BoundField DataField="LOP_REASON" HeaderText="REASON" />
                                        </Columns>
                                    </asp:GridView>
                                </div>
                            </td>
                        </tr>

                        <tr>
                            <td>
                                <asp:Button ID="btnSubmit" Text="Submit Attendance" runat="server" Visible="false" OnClick="btnSubmit_Click" />
                            </td>
                        </tr>
                       
                    </table>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
</asp:Content>

