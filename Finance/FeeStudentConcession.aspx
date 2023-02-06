<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/FullLength.master" AutoEventWireup="true" CodeFile="FeeStudentConcession.aspx.cs" Inherits="Finance_BankAccount" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <script lang="javascript" type="text/javascript"> 
         // Client Side Validation Script


         function SelectAllCheckboxes(spanChk) {
             var oItem = spanChk.children;
             var theBox = (spanChk.type == "checkbox") ?
                 spanChk : spanChk.children.item[0];
             xState = theBox.checked;
             elm = theBox.form.elements;

             for (i = 0; i < elm.length; i++)
                 if (elm[i].type == "checkbox" &&
                          elm[i].id != theBox.id) {
                     //elm[i].click();
                     if (elm[i].checked != xState)
                         elm[i].click();
                     //elm[i].checked=xState;
                 }

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

         function valid() {
             var flag = true;
             var msg = "", ctrl = "";
             if (!CheckControl("<%=ddlSession.ClientID%>")) {
        msg += "- Select Session from list.\n";
        if (ctrl == "")
            ctrl = "<%=ddlSession.ClientID%>";
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
                <!-- Page Heading-->
            Fee Student Concession
            </h2>

        </div>
    
    <div id="cBody">
        <div id="cHead">
           <!-- Content  Header ex: Filters-->
        <table >
        <tr>
            <th>
                Institute
            </th>
            <th>
                Course
            </th>
            <th>
                Branch
            </th>
             <th>
                Batch
            </th>
            <th>
                Session<span class="required">*</span>
            </th>
        </tr>
            <tr>
                <td>
                <asp:DropDownList ID="ddlInstitute" runat="server" OnSelectedIndexChanged="ddlInstitute_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                </td>
                <td>
                <asp:DropDownList ID="ddlCourse" runat="server" OnSelectedIndexChanged="ddlCourse_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                </td>
                <td>
                <asp:DropDownList ID="ddlBranch" runat="server"></asp:DropDownList>
                </td>
                <td>
                <asp:DropDownList ID="ddlBatch" runat="server"></asp:DropDownList>
                </td>
                <td>
                <asp:DropDownList ID="ddlSession" runat="server"></asp:DropDownList>
                </td>
                <td>
                <asp:Button ID="btnShow" runat="server" Text="Show" OnClick="btnShow_Click" />
                </td>
            </tr>
        </table>
        </div>
        <div id="cCenter">
           <!-- Content Header ex: Grids-->
         <asp:GridView ID="gvDetail" runat="server" AutoGenerateColumns="false" CssClass="gridDynamic" DataKeyNames="STU_CONC_ID">
             <Columns>
                 <asp:TemplateField HeaderText="s#">
                     <ItemTemplate>
                              <%# ((GridViewRow)Container).RowIndex + 1%>
                     </ItemTemplate>
                 </asp:TemplateField>
                 <asp:BoundField DataField="ENROLLMENT_NO" HeaderText="Enrollment#" />
                 <asp:BoundField DataField="STU_FULL_NAME" HeaderText="Name" />
                 <asp:BoundField DataField="PGM_SHORT_NAME" HeaderText="Course" />
                 <asp:BoundField DataField="ACA_SEM_ID" HeaderText="Sem" />
                 <asp:BoundField DataField="COURSE_FEE" HeaderText="Course Fee" />
                 <asp:BoundField DataField="CONC_PERCENTAGE" HeaderText="Concession(%)" />
                 <asp:BoundField DataField="CONC_RULE_NAME" HeaderText="Quota Name" />
                 <asp:BoundField DataField="CONCESSION" HeaderText="Concession(Amt.)" />
                  <asp:TemplateField>
                                        <HeaderTemplate>
                                            <input id="chkAll" onclick="javascript: SelectAllCheckboxes(this);" type="checkbox"
                                                value="on" runat="server" style="border-right: 2px groove; border-top: 2px groove;
                                                border-left: 2px groove; border-bottom: 2px groove" /></HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:CheckBox ID="chk1" runat="server" /></ItemTemplate>
                                    </asp:TemplateField>
             </Columns>
         </asp:GridView>
        </div>
         <div id="cFooter">
              <!-- Content Header ex:Buttons-->
        <table>
             <tr id ="trSave" runat="server">
                     <td>
                            &nbsp; Remark&nbsp;</td>
                     <td>
                            &nbsp;
                            <asp:TextBox ID="txtRemark" runat="server"></asp:TextBox>&nbsp;</td>
                     <td>
                            &nbsp;
                            <asp:Button ID="btnSave" runat="server" Text="Save" 
                                OnClick="btnSave_Click" /></td>
            </tr>
            <tr>
            <td>
                <asp:TextBox ID="txtData" runat="server" Visible="False"></asp:TextBox></td>
           </tr>
        </table>
        </div>
</div>
</div>

</asp:Content>

