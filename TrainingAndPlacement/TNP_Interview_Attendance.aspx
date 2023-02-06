<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/FullLength.master" AutoEventWireup="true" CodeFile="TNP_Interview_Attendance.aspx.cs" Inherits="TrainingAndPlacement_TNP_Interview_Attendance" %>

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

            if (!CheckControl("<%=ddlinterviewdate.ClientID%>")) {
                msg += "- Please Select Interview Date \n";
                if (ctrl == "")
                    ctrl = "<%=ddlinterviewdate.ClientID%>";
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
            <h2>Interview Attendance</h2>
        </div>
        <hr />
        <table>


            <tr>
                <%--<th>Course</th>
                <th>Branch</th>
                <th>Sem</th>--%>
                <th>Company Name</th>
                <th>Job Profile</th>
                <th>Interview Date</th>
                </tr>
            <tr>
                <%--<td>
                    <asp:DropDownList ID="ddlcourse" runat="server" AutoPostBack="true" Width="130" OnSelectedIndexChanged="ddlcourse_SelectedIndexChanged"></asp:DropDownList>
                </td>
                <td>
                    <asp:DropDownList ID="ddlbranch" runat="server" AutoPostBack="true" Width="130"></asp:DropDownList>
                </td>
                <td>
                    <asp:DropDownList ID="ddlsem" runat="server" AutoPostBack="true" Width="130"></asp:DropDownList>
                </td>--%>
                <td>
                    <asp:DropDownList ID="ddlcompany" runat="server" AutoPostBack="true" Width="130" OnSelectedIndexChanged="ddlcompany_SelectedIndexChanged"></asp:DropDownList>
                </td>
                <td>
                    <asp:DropDownList ID="ddljobprofile" runat="server" AutoPostBack="true" width="130" OnSelectedIndexChanged="ddljobprofile_SelectedIndexChanged"></asp:DropDownList>
                </td>
                <td>
                   <asp:DropDownList ID="ddlinterviewdate" runat="server" AppendDataBoundItems="true" Width="130"></asp:DropDownList>
                </td>
                 <%-- <ajaxToolkit:CalendarExtender ID="CalendarExtender4" runat="server" TargetControlID="ddlinterviewdate" Format="dd/MM/yyyy">
                                                            </ajaxToolkit:CalendarExtender>
                   <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender2" runat="server" Mask="99/99/9999" MaskType="Date"
                                                                TargetControlID="txtDate">
                                                            </ajaxToolkit:MaskedEditExtender>--%>
                <td>
                     <asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click" />
                </td>
               
            </tr>
        </table>
         <table>
             <tr>
                 <td>
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
                        <asp:BoundField DataField="BRN_SHORT_NAME" HeaderText="Branch" />
                        <%--<asp:BoundField DataField="JOB_PROFILE" HeaderText="Job Profile" />--%>
                        <asp:TemplateField>
                        <HeaderTemplate>
                        <input id="chkAll" onclick="javascript: SelectAllCheckboxes(this);" type="checkbox"
                         value="on" runat="server" />All</HeaderTemplate>
                        <ItemTemplate>
                        <asp:CheckBox ID="chkSelect" runat="server" /></ItemTemplate>
                        <ItemStyle Width="20px" />
                        </asp:TemplateField>
                 </Columns>
              </asp:GridView>
                 </td>
             </tr>
             <tr>
                 <td>
                     <asp:Button ID="btnshow" runat="server" Text="Show" OnClick="btnshow_Click" />
                 </td>
             </tr>
             
         </table>
          
         
   <table>
         <tr> 
                   <td>
                    <asp:TextBox ID="txtxml" Visible="false" runat="server"></asp:TextBox>
                </td>

              </tr>
       <tr>
           <td>
                <asp:GridView ID="GvAdd" runat="server" AutoGenerateColumns="false" width="300" EmptyDataText="No Record Found" CssClass="gridDynamic">
             <Columns>
                        <asp:TemplateField HeaderText="S.No.">
                            <ItemTemplate>
                                <%# ((GridViewRow)Container).RowIndex + 1%>
                                .
                            </ItemTemplate>
                        </asp:TemplateField>
                        
                        <asp:BoundField DataField="ENROLLMENT_NO" HeaderText="Enrollment" />
                        <asp:BoundField DataField="STU_FULL_NAME" HeaderText="Name" />
                        <asp:BoundField DataField="BRN_SHORT_NAME" HeaderText="Branch" />
                       <asp:BoundField DataField="INT_ATT_STS" HeaderText="Attendance Status" />
                       
               </Columns>
              </asp:GridView>
           </td>
       </tr>
   </table>
          <asp:Button ID="btnsubmit" runat="server" Text="Submit" OnClick="btnsubmit_Click" />
         </div>
</asp:Content>

