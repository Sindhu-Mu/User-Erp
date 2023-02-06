<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Short.master" AutoEventWireup="true" CodeFile="FeeFineAppDateCase.aspx.cs" Inherits="Finance_FeeFineAppDateCase" %>

<%@ Register Src="~/Control/Student.ascx" TagPrefix="uc1" TagName="Student" %>


    <asp:Content ID="Content1" ContentPlaceHolderID="ContentHolder1" runat="Server">
    <script language="javascript" type="text/javascript">
        // Client Side Validation Script

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

          
    if (!CheckControl("<%=txtEnroll.ClientID%>")) {
                 msg += "- Enter Enrollment No.\n";
                 if (ctrl == "")
                     ctrl = "<%=txtEnroll.ClientID%>";
                 flag = false;
             }

             if (msg != "") alert(msg);
             if (ctrl != "")
                 document.getElementById(ctrl).focus();
             return flag;
        }
        function validation1() {
            var flag = true;
            var msg = "", ctrl = "";

        if (!CheckControl("<%=txtRemark.ClientID%>")) {
            msg += "- Enter Remark.\n";
            if (ctrl == "")
                ctrl = "<%=txtRemark.ClientID%>";
                 flag = false;
        }
            if (!CheckControl("<%=txtEnroll.ClientID%>")) {
                msg += "- Enter Enrollment No.\n";
                if (ctrl == "")
                    ctrl = "<%=txtEnroll.ClientID%>";
                 flag = false;
             }
            if (CheckControl("<%=txtdate.ClientID%>")) {
                if (!CheckDate("<%=txtdate.ClientID%>")) {
                     msg += "- Invalid Format of Date.Please Enter in this[dd/MM/yyyy]\n";
                     if (ctrl == "")
                         ctrl = "<%=txtdate.ClientID%>";
                    flag = false;
                }
            }
            else {
                msg += "- Enter Date\n";
                if (ctrl == "")
                    ctrl = "<%=txtdate.ClientID%>";
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
            <h2>
           Fine Date Case

            </h2>
            <div>
                <table>
                    <tr>
                         <th>Enrollment</th>
                         <td>
                            <asp:TextBox ID="txtEnroll" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                       <th>Fine Start Date</th>
                        <td>
                            <asp:TextBox ID="txtdate" runat="server"></asp:TextBox>
                             <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender2" runat="server" Mask="99/99/9999" MaskType="Date" TargetControlID="txtdate">
                                            </ajaxToolkit:MaskedEditExtender>
                                            <ajaxToolkit:CalendarExtender ID="CalendarExtender2" runat="server" Format="dd/MM/yyyy" TargetControlID="txtdate">
                                            </ajaxToolkit:CalendarExtender>
                        </td>
                       
                    </tr>
                    <tr>
                        <th>Remark</th>
                         <td><asp:TextBox ID="txtRemark" runat="server" TextMode="MultiLine"></asp:TextBox></td>
                        <td>
                            <asp:Button ID="btnAdd" runat="server" Text="Add" OnClick="btnAdd_Click" />
                        </td>
                        <td>
                            <asp:TextBox ID="txtdata" runat="server" Visible="false"></asp:TextBox>
                        </td>
                    </tr>
                  

                </table>
            </div>
            <asp:GridView ID="gvAdd" runat="server" width="500px" CssClass="gridDynamic" DataKeyNames="STU_ADM_NO" OnRowDeleting ="gvAdd_RowDeleting" EmptyDataText="No Record Found" AutoGenerateColumns="false">
                <Columns>
                    <asp:TemplateField HeaderText="S.No.">
                        <ItemTemplate >
                            <%#((GridViewRow)Container).RowIndex+1 %>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField Headertext="ENROLLMENT" DataField="STU_ADM_NO" />
                    <asp:BoundField HeaderText="FINE DATE" DataField="FINE_START_DATE" DataFormatString="{0:dd/MM/yyyy}"/>
                    <asp:BoundField HeaderText="REMARK" DataField="REMARK" />
                     <asp:CommandField ButtonType="Image" DeleteImageUrl="~/images/delete.gif" ShowDeleteButton="True" />
                </Columns>
            </asp:GridView>
            <div>
                <table>
                    <tr>
                        <td>
                            <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click"/>
                        </td>
                    </tr>
                </table>
 
        </div>
        </div>
        
       
        </div>
   
</asp:Content>

