<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/FullLength.master" AutoEventWireup="true" CodeFile="TNP_Interview Shedule.aspx.cs" Inherits="TrainingAndPlacement_TNP_Interview_Shedule" %>

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

            if (!CheckControl("<%=ddlprofile.ClientID%>")) {
                msg += "- Please Select Company Profile\n";
                if (ctrl == "")
                    ctrl = "<%=ddlprofile.ClientID%>";
                flag = false;
            }

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

            if (!CheckControl("<%=ddlcourse.ClientID%>")) {
                msg += "- Please Select Course \n";
                if (ctrl == "")
                    ctrl = "<%=ddlcourse.ClientID%>";
                flag = false;
            }

            if (!CheckControl("<%=ddlbranch.ClientID%>")) {
                msg += "- Please Select Branch \n";
                if (ctrl == "")
                    ctrl = "<%=ddlbranch.ClientID%>";
                flag = false;
            }

            if (!CheckControl("<%=ddlsem.ClientID%>")) {
                msg += "- Please Select Semester \n";
                if (ctrl == "")
                    ctrl = "<%=ddlsem.ClientID%>";
                flag = false;
            }

            

            if (!CheckControl("<%=txtsalary.ClientID%>")) {
                msg += "- Please Enter Salary \n";
                if (ctrl == "")
                    ctrl = "<%=txtsalary.ClientID%>";
                flag = false;
            }

            if (!CheckControl("<%=txtvacancy.ClientID%>")) {
                msg += "- Please Enter Salary \n";
                if (ctrl == "")
                    ctrl = "<%=txtvacancy.ClientID%>";
                flag = false;
            }

            if (!CheckControl("<%=txtlocation.ClientID%>")) {
                msg += "- Please Enter Job Location \n";
                if (ctrl == "")
                    ctrl = "<%=txtlocation.ClientID%>";
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
            <h2>Interview Schedule</h2>
        </div>
        <hr />
         <table>
             <tr>
                    
                 <th>Company Profile<span class="required">*</span></th>
                 <th>Company<span class="required">*</span></th>
                 <th>Job Profile<span class="required">*</span></th>
                 <th>Course<span class="required">*</span></th>
                 <th>Branch<span class="required">*</span></th>
                <th>Sem<span class="required">*</span></th>
                 <th>Session</th>
                 </tr>
             <tr>
                 <td>
                     <asp:DropDownList ID="ddlprofile" runat="server" AutoPostBack="true" Width="130" OnSelectedIndexChanged="ddlprofile_SelectedIndexChanged"></asp:DropDownList>
                 </td>
                 
                 <td>
                     <asp:DropDownList ID="ddlcompany" runat="server" AutoPostBack="true" Width="130" OnSelectedIndexChanged="ddlcompany_SelectedIndexChanged"></asp:DropDownList>
                 </td>
                 <td>
                     <asp:DropDownList ID="ddljobprofile" runat="server" AutoPostBack="true" Width="130"></asp:DropDownList>
                 </td>
                 <td>
                     <asp:DropDownList ID="ddlcourse" runat="server" AutoPostBack="true" Width="130" OnSelectedIndexChanged="ddlcourse_SelectedIndexChanged"></asp:DropDownList>
                 </td>
                 <td>
                     <asp:DropDownList ID="ddlbranch" runat="server" AutoPostBack="true" Width="130">
                         <%--<asp:ListItem Text="All" Value="1"></asp:ListItem>--%>
                     </asp:DropDownList>
                 </td>
                  
                 <td>
                 <asp:DropDownList ID="ddlsem" runat="server" AutoPostBack="true" Width="130"></asp:DropDownList>
                     </td>
                 <td>
                     <asp:DropDownList ID="ddlSession" runat="server" AutoPostBack="true" Width="130"></asp:DropDownList>
                 </td>

             </tr>
             <tr>
                 <th>Salary<span class="required">*</span></th>
                 <td>
                     <asp:TextBox ID="txtsalary" runat="server"></asp:TextBox>
                 </td>
             </tr>
             <tr>
                 <th>Vacancy<span class="required">*</span></th>
                 <td>
                     <asp:TextBox ID="txtvacancy" runat="server"></asp:TextBox>
                 </td>
             </tr>
             <tr>
                 <th>Job Location<span class="required">*</span></th>
                 <td>
                     <asp:TextBox ID="txtlocation" runat="server"></asp:TextBox>
                 </td>
             </tr>
             <tr>
                 <th>Interview Date<span class="required">*</span></th>
                 <td>
                     <asp:TextBox ID="txtdate" runat="server"></asp:TextBox>
                 </td>
                 <ajaxToolkit:CalendarExtender ID="CalendarExtender4" runat="server" TargetControlID="txtdate" Format="dd/MM/yyyy">
                                                            </ajaxToolkit:CalendarExtender>
                   <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender2" runat="server" Mask="99/99/9999" MaskType="Date"
                                                                TargetControlID="txtdate">
                                                            </ajaxToolkit:MaskedEditExtender>
             </tr>
             <tr>
                 <th>Others</th>
                 <td>
                     <asp:TextBox ID="txtothers" runat="server" TextMode="MultiLine" Width="130"></asp:TextBox>
                 </td>
                 
             </tr>
             <tr>
                 <td>
                     <asp:Button ID="btnAdd" runat="server" text="Show" OnClick="btnAdd_Click" />
                 </td>
                 <td>
                     <asp:TextBox ID="txtxml" runat="server" Visible="false" Width="130"></asp:TextBox>
                 </td>
                 
             </tr>
         </table>
         <asp:GridView ID="GvShow" runat="server" AutoGenerateColumns="false" EmptyDataText="No Record Found" CssClass="gridDynamic" OnRowDeleting="GvShow_RowDeleting">
             <Columns>
                        <asp:TemplateField HeaderText="S.No.">
                            <ItemTemplate>
                                <%# ((GridViewRow)Container).RowIndex + 1%>
                                .
                            </ItemTemplate>
                        </asp:TemplateField>
                        
                        <asp:BoundField DataField="COMP_Name" HeaderText="Company" />
                        <asp:BoundField DataField="JOB_PROFILE" HeaderText="Job Profile" />
                        <asp:BoundField DataField="BRN_SHORT_NAME" HeaderText="Branch" />
                        <asp:BoundField DataField="ACA_SEM_NO" HeaderText="Sem" />
                 <asp:BoundField DataField="ACA_SESN_VALUE" HeaderText="Session" />
                  <asp:BoundField DataField="SALARY" HeaderText="Salary" />
                 <asp:BoundField DataField="VACANCY" HeaderText="Vacancy" />
                 <asp:BoundField DataField="JOB_LOCATION" HeaderText="Job Location" />
                 <asp:BoundField DataField="INTERVIEW_DT" HeaderText="Interview Date" DataFormatString="{0:dd/MM/yyyy}" />
                 <asp:BoundField DataField="OTHERS" HeaderText="Others" />
                 <asp:CommandField DeleteImageUrl="~/Siteimages/delete.jpg" ShowDeleteButton="True" ButtonType="Image" HeaderText="Delete">
                                                        <ItemStyle Width="50px" />
                                                    </asp:CommandField>
                 
                       </Columns>
        </asp:GridView>
         
                     <asp:Button ID="btnsave" runat="server" Text="Save" OnClick="btnsave_Click" />
                
        </div>
</asp:Content>

