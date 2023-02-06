<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/FullLength.master" AutoEventWireup="true" CodeFile="FeeFineMaster.aspx.cs" Inherits="StudentFinance_BankAccount" %>

<%@ Register Src="~/Control/Student.ascx" TagPrefix="uc1" TagName="Student" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
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
         function valid() {
             var flag = true;
             var msg = "", ctrl = "";

             if (!CheckControl("<%=ddlSemester.ClientID%>")) {
        msg += "- Select semester no from list.\n";
        if (ctrl == "")
            ctrl = "<%=ddlSemester.ClientID%>";
        flag = false;
    }
    if (!CheckControl("<%=txtEnrollment.ClientID%>")) {
                 msg += "- Enter Enrollment No.\n";
                 if (ctrl == "")
                     ctrl = "<%=txtEnrollment.ClientID%>";
        flag = false;
    }

    if (msg != "") alert(msg);
    if (ctrl != "")
        document.getElementById(ctrl).focus();
    return flag;
}
function validSave() {
    var flag = true;
    var msg = "", ctrl = "";

    if (!CheckControl("<%=txtEnrollment.ClientID%>")) {
        msg += "- Enter Enrollment No.\n";
        if (ctrl == "")
            ctrl = "<%=txtEnrollment.ClientID%>";
        flag = false;
    }
    if (!CheckControl("<%=ddlCase.ClientID%>")) {
        msg += "- Select Case from list.\n";
        if (ctrl == "")
            ctrl = "<%=ddlCase.ClientID%>";
        flag = false;
    }
    if (!CheckControl("<%=txtAmount.ClientID%>")) {
        msg += "- Enter Fine Amount.\n";
        if (ctrl == "")
            ctrl = "<%=txtAmount.ClientID%>";
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
             Fee Fine

            </h2>

        </div>
    
    <div id="cBody">
        <div id="cHead">
    
            <table style="width:100%; border:0" >
                <tbody>
                    <tr>
                        <td align="right">
                         <table>
             <tbody>
                 <tr>
                     <th>
                         Branch
                     </th>
                     <th>
                         Semester
                     </th>
                     <th>
                         Enrollment No.
                     </th>
                 </tr>
                 <tr>
                     <td>
                        <asp:DropDownList ID="ddlBranch" runat="server"></asp:DropDownList>
                     </td>
                     <td>
                        <asp:DropDownList ID="ddlSemester" runat="server"></asp:DropDownList>
                     </td>
                     <td>
                         <asp:TextBox ID="txtEnrollment" runat="server"></asp:TextBox>
                     </td>
                     <td>
                     <asp:Button ID="btnShow" runat="server" OnClick="btnShow_Click" Text="Show" />
                     </td>
                 </tr>
             </tbody>
         </table>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <uc1:Student runat="server" ID="Student" />
                        </td>
                    </tr>
                    <tr id="trfine" runat="server">
                        <td>
                            <table>
                                <tr>
                                    <th>Fine Case<span style="color:red">*</span></th>
                                    <th>Fine Amount<span style="color:red">*</span></th>
                                    <th>Remark</th>

                                </tr>
                                <tr>
                                    <td>
                                     <asp:DropDownList ID="ddlCase" runat="server" AutoPostBack="true"></asp:DropDownList>
                                    </td>
                                    <td>
                                    <cc1:NumericTextBox ID="txtAmount" runat="server" Width="150px" CssClass="txtno"></cc1:NumericTextBox>
                                    </td>
                                    <td>
                                    <asp:TextBox ID="txtRemark" runat="server"></asp:TextBox>
                                    </td>
                                    <td>
                                    <asp:Button  ID="btnSave" runat="server" OnClick="btnSave_Click" Text="Save"/>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>

                </tbody>
            </table>

        </div>
        <div id="cCenter">
         <asp:GridView ID="gvShow" runat="server" Width="100%" CssClass="gridDynamic" AutoGenerateColumns="false" 
             DataKeyNames="FINE_ID" OnRowDeleting="gvShow_RowDeleting" EmptyDataText="No Record Found.">
             <Columns>
                 <asp:TemplateField>
                    <ItemTemplate>
                        <%#((GridViewRow)Container).RowIndex+1 %>
                    </ItemTemplate>     
                 </asp:TemplateField>
                 <asp:BoundField DataField="ENROLLMENT_NO" HeaderText="Enrollment#" />
                 <asp:BoundField DataField="FINE_CASE" HeaderText="Case" />
                 <asp:BoundField DataField="FINE_AMT" HeaderText="Fine Amount" DataFormatString="{0:N2}"
                 HtmlEncode="False">
                 <ItemStyle HorizontalAlign="Right" /></asp:BoundField>
                 <asp:BoundField DataField="INSERT_DT" HeaderText="Insert Date" />                                         
                 <asp:CommandField ButtonType="Image" DeleteImageUrl="~/images/delete.gif" ShowDeleteButton="True" />
             </Columns>
             

              

         </asp:GridView>

        </div>
         <div id="cFooter">
              <!-- Content Header ex:Buttons-->
             <table>
                 <tr>
                     <td>
                         <asp:TextBox ID="txtData" runat="server" Visible="false"></asp:TextBox>
                     </td>
                 </tr>
             </table>

        </div>
</div>
</div>

</asp:Content>

