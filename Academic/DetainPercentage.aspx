<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/FullLength.master" AutoEventWireup="true" CodeFile="DetainPercentage.aspx.cs" Inherits="Academic_DetainPercentage" %>

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
         function validation() {

             var flag = true;
             var msg = "", ctrl = "";
             if (!CheckControl("<%=ddlInstitution.ClientID%>")) {
                msg += "- Select Institution from list\n";
                if (ctrl == "")
                    ctrl = "<%=ddlInstitution.ClientID%>";
                flag = false; 9
            }
            if (!CheckControl("<%=ddlCourse.ClientID%>")) {
                msg += "- Select Program Name from list\n";
                if (ctrl == "")
                    ctrl = "<%=ddlCourse.ClientID%>";
                flag = false;
            }
            if (!CheckControl("<%=ddlBranch.ClientID%>")) {
                msg += "- Enter Branch Name\n";
                if (ctrl == "")
                    ctrl = "<%=ddlBranch.ClientID%>";
                flag = false;
            }
                     
            if (!CheckControl("<%=ddlSemester.ClientID%>")) {
                msg += "- Select Semester Type from list\n";
                if (ctrl == "")
                    ctrl = "<%=ddlSemester.ClientID%>";
                flag = false;
            }
            if (!CheckControl("<%=ddlPercentage.ClientID%>")) {
                msg += "- Enter Roll Formate of this Branch\n";
                if (ctrl == "")
                    ctrl = "<%=ddlPercentage.ClientID%>";
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
            <h2>Detain Percentage</h2>
        </div>
        <div>
            <table>                
                <tr>
                    <td>
                        <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
                            <ContentTemplate>
                                <table>
                                    <tr>
                                        <th>Institution<span class="required">*</span>
                                        </th>
                                        <th>Course<span class="required">*</span>
                                        </th>
                                        <th>Branch<span class="required">*</span>
                                        </th>
                                        <th>Sem<span class="required">*</span>
                                        </th>
                                        <th>Paper Type<span class="required">*</span>
                                        </th>
                                        <th>%age<span class="required">*</span>
                                        </th>
                                        <th>As On Date
                                        </th>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:DropDownList ID="ddlInstitution" runat="server" required="required" AutoPostBack="true"
                                                OnSelectedIndexChanged="ddlInstitution_SelectedIndexChanged">
                                            </asp:DropDownList>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlCourse" runat="server" required="required" AutoPostBack="true"
                                                OnSelectedIndexChanged="ddlCourse_SelectedIndexChanged" Width="130px">
                                            </asp:DropDownList>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlBranch" runat="server" required="required" Width="150px">
                                            </asp:DropDownList>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlSemester" runat="server" required="required" Width="70px">
                                            </asp:DropDownList>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlPaperType" runat="server" required="required" Width="75px">
                                                <asp:ListItem Value="0">Theory</asp:ListItem>
                                                <asp:ListItem Value="1">Practical</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlPercentage" runat="server" required="required" Width="80px">
                                            </asp:DropDownList>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtDate" runat="server" Width="85px" required="required" CssClass="textbox"></asp:TextBox>
                                            <ajaxToolkit:CalendarExtender ID="cal1" runat="server" TargetControlID="txtDate"
                                                Format="dd/MM/yyyy" PopupPosition="TopLeft">
                                            </ajaxToolkit:CalendarExtender>
                                            <ajaxToolkit:MaskedEditExtender ID="me1" runat="server" Mask="99/99/9999" MaskType="Date"
                                                TargetControlID="txtDate">
                                            </ajaxToolkit:MaskedEditExtender>
                                        </td>
                                        <td>
                                            <asp:Button ID="btnView" runat="server" Text="View" CssClass="btnBrown" OnClick="btnView_Click" />
                                        </td>
                                        <td>
                                            <asp:Button ID="btnPrtOriginal" runat="server" Text="Print" OnClick="btnPrtOriginal_Click" />
                                        </td>
                                        <td>
                                            <asp:Button ID="btnPrintReport" runat="server" Text="Print X" OnClick="btnPrintReport_Click" />
                                        </td>
                                        <td><asp:Button ID="BtnExport" runat="server" Text="Export To Excel" OnClick="BtnExport_Click" Width="105px" /></td>
                                    </tr>
                                    <tr>
                                <td colspan="5">
                                    <asp:UpdateProgress ID="upg1" runat="server" DisplayAfter="100" DynamicLayout="true">
                                        <ProgressTemplate>
                                            <img src="../Siteimages/loading.gif" alt="Data" />Loading....
                                        </ProgressTemplate>
                                    </asp:UpdateProgress>
                                </td>
                            </tr>
                                </table>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                </tr>
                <tr>
                    <td>
                        
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                                <ContentTemplate>
                                    <table style="width: 100%">
                                        <tr>
                                            <td>
                                                <asp:GridView ID="gridData" CssClass="gridDynamic" AlternatingRowStyle-CssClass="alt"
                                                    runat="server" AutoGenerateColumns="false" EnableViewState="false" EmptyDataText="No records found">
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="S.No.">
                                                            <ItemTemplate>
                                                                <%# ((GridViewRow)Container).RowIndex + 1%>
                                                        .
                                                            </ItemTemplate>
                                                            <ItemStyle Width="10px" />
                                                        </asp:TemplateField>
                                                        <asp:BoundField HeaderText="Enroll" DataField="ENROLLMENT_NO">
                                                            <ItemStyle HorizontalAlign="Center" />
                                                        </asp:BoundField>
                                                        <asp:BoundField HeaderText="Roll." DataField="SEM_ROLL_NO">
                                                            <ItemStyle HorizontalAlign="Center" />
                                                        </asp:BoundField>
                                                        <asp:BoundField HeaderText="Name" DataField="STU_FULL_NAME">
                                                            <ItemStyle HorizontalAlign="Left" />
                                                        </asp:BoundField>
                                                    </Columns>
                                                </asp:GridView>
                                            </td>
                                        </tr>
                                    </table>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                      
                    </td>
                </tr>
                <tr>
                    <td>
                        <table>
                            <tr>
                                <td>
                                    <span style="text-decoration: underline; font-weight: bold">Note: </span>
                                    <ul style="padding-top: 0px; padding-left: 20px">
                                        <li>All attendance percentage are commulative of Medical and Activity credits </li>
                                        <li>Medical credit is calculated to the maximum of 10% of the number of classes held
                                    during the period </li>
                                        <li>Activity credit is calculated to the maximum of 5% of the number of classes held
                                    during the period </li>
                                    </ul>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </div>
    </div>
</asp:Content>

