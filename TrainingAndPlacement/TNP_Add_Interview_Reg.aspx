<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/FullLength.master" AutoEventWireup="true" CodeFile="TNP_Add_Interview_Reg.aspx.cs" Inherits="TrainingAndPlacement_TNP_Add_Interview_Reg" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <script lang="javascript" type="text/javascript">
        function CheckControl(ctrl) {
            if (bTrim(document.getElementById(ctrl).value) == "" || bTrim(document.getElementById(ctrl).value) == "-1") {
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

           

            if (!CheckControl("<%=ddlcompany.ClientID%>")) {
                msg += "- Please Select Company \n";
                if (ctrl == "")
                    ctrl = "<%=ddlcompany.ClientID%>";
                flag = false;
            }

            if (!CheckControl("<%=ddljobprofile.ClientID%>")) {
                msg += "- Please Select Job Profile \n";
                if (ctrl == "")
                    ctrl = "<%=ddljobprofile.ClientID%>";
                flag = false;
            }

            if (!CheckControl("<%=ddlInterviewDate.ClientID%>")) {
                msg += "- Please Select Interview Date \n";
                if (ctrl == "")
                    ctrl = "<%=ddlInterviewDate.ClientID%>";
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


        if (!CheckControl("<%=txtEnrollment.ClientID%>")) {
            msg += "- Please Enter Enrollment \n";
            if (ctrl == "")
                ctrl = "<%=txtEnrollment.ClientID%>";
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
            <h2>Add Interview Registeration</h2>
        </div>
        <hr />
        <table>
            <tr>
                <th>Company Name<span class="required">*</span></th>
                <th>Job Profile<span class="required">*</span></th>
                <th>Interview Date<span class="required">*</span></th>
            </tr>
            <tr>
                <td>
                    <asp:DropDownList ID="ddlcompany" runat="server" AutoPostBack="true" Width="130" OnSelectedIndexChanged="ddlcompany_SelectedIndexChanged"></asp:DropDownList>
                </td>
                <td>
                    <asp:DropDownList ID="ddljobprofile" runat="server" AutoPostBack="true" Width="130" OnSelectedIndexChanged="ddljobprofile_SelectedIndexChanged"></asp:DropDownList>
                </td>
                <td>
                    <asp:DropDownList ID="ddlInterviewDate" runat="server" AutoPostBack="true" Width="130"></asp:DropDownList>
                </td>
                <td>
                    <asp:Button ID="btnshow" runat="server" Text="Show" OnClick="btnshow_Click" />
                </td>
            </tr>
            </table>

        <asp:GridView ID="GvShow" runat="server" AutoGenerateColumns="false" width="300" EmptyDataText="No Record Found" CssClass="gridDynamic"> 
                         <Columns>
                        <asp:TemplateField HeaderText="S.No.">
                            <ItemTemplate>
                                <%# ((GridViewRow)Container).RowIndex + 1%>
                                .
                            </ItemTemplate>
                        </asp:TemplateField>
                        
                        <asp:BoundField DataField="ENROLLMENT_NO" HeaderText="Enrollment" />
                        <asp:BoundField DataField="STU_FULL_NAME" HeaderText="Name" />
                 </Columns>
              </asp:GridView>
          <table>
             <tr id="trOld" runat="server">
              <th>Enrollment<span class="required">*</span></th>
              <td>
                <asp:TextBox ID="txtEnrollment" runat="server" Width="250px"></asp:TextBox>
                <asp:Button ID="btnAdd" runat="server" Text="Add" OnClick="btnAdd_Click" />
              </td>
             </tr>
              <tr>
                  <td>
                      <ajaxToolkit:AutoCompleteExtender ID="AutoCompleteExtender2" runat="server" CompletionSetCount="12"
                       EnableCaching="true" MinimumPrefixLength="1" ServiceMethod="GetStudentList"
                       ServicePath="~\AutoComplete.asmx" TargetControlID="txtEnrollment" ContextKey="1,2,3,4,5,6">
                      </ajaxToolkit:AutoCompleteExtender>
                                                
                  </td>
              </tr>
              <tr> 
                   <td>
                    <asp:TextBox ID="txtxml" Visible="false" runat="server"></asp:TextBox>
                </td>

              </tr>
          </table>
          <asp:GridView ID="GvAdd" runat="server" AutoGenerateColumns="false" width="300" EmptyDataText="No Record Found" CssClass="gridDynamic">
             <Columns>
                        <asp:TemplateField HeaderText="S.No.">
                            <ItemTemplate>
                                <%# ((GridViewRow)Container).RowIndex + 1%>
                                .
                            </ItemTemplate>
                        </asp:TemplateField>
                        
                        <asp:BoundField DataField="ENROLLMENT_NO" HeaderText="Enrollment" />
                        <%--<asp:BoundField DataField="STU_FULL_NAME" HeaderText="Name" />--%>
                 </Columns>
              </asp:GridView>
        <asp:Button ID="btnsave" runat="server" Text="Save" OnClick="btnsave_Click" />
            </div>
    
</asp:Content>

