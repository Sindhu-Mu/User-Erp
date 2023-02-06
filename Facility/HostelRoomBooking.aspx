<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/FullLength.master" AutoEventWireup="true" CodeFile="HostelRoomBooking.aspx.cs" Inherits="Facility_BookRequisition" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

 
<script lang="javascript" type="text/javascript">

        function CheckControl(ctrl) {
            if (bTrim(document.getElementById(ctrl).value) == "" || bTrim(document.getElementById(ctrl).value) == "." || bTrim(document.getElementById(ctrl).value) == "Select") {
                document.getElementById(ctrl).style.backgroundColor = "#fc6";
                return false;
            }
            else
                document.getElementById(ctrl).style.backgroundColor = "#fff";
            return true;
        }
        function validate() {
            var flag = true;
            var msg = "", ctrl = "";
            if (!CheckControl("<%=ddlRoomCat.ClientID%>")) {
                    msg += "- Select Room Category.\n";
                    if (ctrl == "")
                        ctrl = "<%=ddlRoomCat.ClientID%>";
                    flag = false;
                }
                
            if (!CheckControl("<%=txtDate1.ClientID%>")) {
                msg += "- Enter Occupied Date.\n";
                if (ctrl == "")
                    ctrl = "<%=txtDate1.ClientID%>";
                 flag = false;
            }
            if (!CheckControl("<%=txtEnroll.ClientID%>")) {
                msg += "- Enter Enrollment.\n";
                if (ctrl == "")
                    ctrl = "<%=txtEnroll.ClientID%>";
                flag = false;
            }
                if (!CheckControl("<%=ddlFloor.ClientID%>")) {
                 msg += "- Select Floor.\n";
                 if (ctrl == "")
                     ctrl = "<%=ddlFloor.ClientID%>";
                      flag = false;
                }
            if (!CheckControl("<%=txtRemark.ClientID%>")) {
                msg += "- Enter Remark.\n";
                if (ctrl == "")
                    ctrl = "<%=txtRemark.ClientID%>";
                 flag = false;
             }
           
                  if (!CheckControl("<%=ddlRoomByFloor.ClientID%>")) {
                 msg += "- Select Room Category.\n";
                 if (ctrl == "")
                     ctrl = "<%=ddlRoomByFloor.ClientID%>";
                    flag = false;
                  }
            if (!CheckControl("<%=rbtn1.ClientID%>")) {
                msg += "- Select Allotment Type.\n";
                if (ctrl == "")
                    ctrl = "<%=rbtn1.ClientID%>";
                 flag = false;
             }
                if (msg != "") alert(msg);
                if (ctrl != "")
                    document.getElementById(ctrl).focus();
                return flag;
            }
    </script>  
<div>
    <asp:UpdatePanel ID="up1" runat="server">
        <ContentTemplate>

   <div id="divgrid" runat="server" visible="true" style="width:80%; overflow:auto;max-height: 300px;">
   <table >
       <tr>
           <td>
       <asp:GridView ID="gvRoom" runat="server" AutoGenerateColumns="false" DataKeyNames="STU_MAIN_ID,ID" CssClass="gridDynamic"
            OnRowCommand="gvRoom_RowCommand"  Caption="Request For Hostel">
             <Columns>
              <asp:TemplateField HeaderText="S.No">
               <ItemTemplate>
                <%# ((GridViewRow)Container).RowIndex + 1 %>
                </ItemTemplate>
               <ItemStyle Width="20px" />
              </asp:TemplateField>
               <asp:BoundField  DataField="ENROLLMENT_NO" HeaderText="ENROLLMENT"/> 
               <asp:BoundField  DataField="STU_FULL_NAME" HeaderText="NAME"/> 
               <asp:BoundField  DataField="FAC_ROOM_CATEGORY_NAME" HeaderText="ROOM CATEGORY"/> 
               <asp:BoundField  DataField="APPLY_TYPE_VALUE" HeaderText="APPLYING FOR"/> 
              <asp:CommandField ShowSelectButton="true" ButtonType="Button" SelectText="Select" HeaderText="Select" />
             </Columns>
             </asp:GridView>
            </td>
           </tr>
       </table>
       </div>
    <div id="div1" runat="server" visible="true">
        <hr />
      <table>
       <tr> 
           <th style="height: 44px">Room Category<span class="required">*</span></th>&nbsp&nbsp&nbsp&nbsp
           <th style="height: 44px">Select Floor<span class="required">*</span></th>&nbsp&nbsp&nbsp&nbsp
           <th style="height: 44px">Room By Floor<span class="required">*</span></th>&nbsp&nbsp&nbsp&nbsp
           </tr> 
       <tr>
           <td style="height: 15px; width:15px">
           <asp:DropDownList ID="ddlRoomCat" runat="server" AutoPostBack="true"></asp:DropDownList>
           </td>
            <td style="height: 31px">
            <asp:DropDownList ID="ddlFloor" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlFloor_SelectedIndexChanged1"></asp:DropDownList>
            </td>
           <td style="height: 31px">
           <asp:DropDownList ID="ddlRoomByFloor" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlRoomByFloor_SelectedIndexChanged"></asp:DropDownList>
           </td>
       
       </tr>
          </table>
    <table style="width:80%">
        <tr>
           <td style="height: 60px">
              Bed Left :- <asp:Label ID="lblBedLeft" runat="server" ForeColor="Red" Text="NO ROOM SELECTED"></asp:Label>
           </td>   
       </tr>
        </table>
    <table style="width:60%">

        <tr style="width:20%">
            <th>Enrollment:<span class="required">*</span></th>
            <th>Occupied Date:<span class="required">*</span></th>
            <th>Remark:<span class="required">*</span></th>
            <th>Allotment Type:<span class="required">*</span> </th>
        </tr>
       <tr>
           <td>
               <asp:TextBox ID="txtEnroll" runat="server" Width="100px"></asp:TextBox>    
           </td>  
           <td>
               <asp:TextBox ID="txtDate1" runat="server" Width="100px"></asp:TextBox>
                <ajaxToolkit:CalendarExtender ID="CalendarExtender1" Format="dd/MM/yyyy" runat="server" TargetControlID="txtDate1"></ajaxToolkit:CalendarExtender>
                 <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender1" runat="server" TargetControlID="txtDate1" Mask="99/99/9999"
                  MaskType="Date">
                 </ajaxToolkit:MaskedEditExtender>
           </td>
             <td>
              <asp:TextBox ID="txtRemark" runat="server" Width="100px"></asp:TextBox>
           </td>
           <td>
               <asp:RadioButtonList ID="rbtn1" runat="server" RepeatDirection="Horizontal">
                   <asp:ListItem Value="0">New</asp:ListItem>
                   <asp:ListItem Value="1" Selected>Old</asp:ListItem>
               </asp:RadioButtonList>
           </td>
           <td>
          </td>
       </tr>
        </table>
         <hr />
    <table style="width:80%">
       <tr>
           <td>
               <asp:GridView ID="gvRoomAllot" runat="server" AutoGenerateColumns="false" CssClass="gridDynamic"  DataKeyNames="ROOM_ID">
                   <Columns>
                       <asp:TemplateField HeaderText="S.No.">
                           <ItemTemplate>
                                 <%# ((GridViewRow)Container).RowIndex + 1 %>
                           </ItemTemplate>
                            <ItemStyle Width="20px" />
                       </asp:TemplateField>
                       <asp:BoundField HeaderText="STUDENT NAME" DataField="STU_NAME" />
                       <asp:BoundField HeaderText ="COURSE" DataField="PGM_SHORT_NAME" />
                       <asp:BoundField HeaderText="BRANCH" DataField="BRN_SHORT_NAME" />
                       <asp:BoundField HeaderText="OCCUPIED DATE" DataField="OCCUPIED_DATE" />
                       <asp:BoundField HeaderText="REMARK" DataField="ALLOTE_REMARK" />
                       </Columns>
               
               </asp:GridView>
           </td>
       </tr>    
       <tr>
           <td>
                <asp:Button ID="btnAssign" runat="server" Text="Assign" OnClick="btnAssign_Click" />
           </td>
       </tr>
        </table>
        </div>
    <div id="div2" runat="server" visible="true">
        <h3 style="color:red; margin:0px auto">No Pending Request</h3>
    </div>
           
      
     </ContentTemplate>
    </asp:UpdatePanel>
   
</div>
 
</asp:Content>

