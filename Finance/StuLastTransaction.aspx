<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/FullLength.master" AutoEventWireup="true" CodeFile="StuLastTransaction.aspx.cs" Inherits="Finance_BankAccount" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
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
       function validate() {
           var flag = true;
           var msg = "", ctrl = "";
           if (!CheckControl("<%=ddlhead.ClientID%>")) {
                  msg += "- Select Head from list \n";
                  if (ctrl == "")
                      ctrl = "<%=ddlhead.ClientID%>";
                flag = false;
           }
           if (!CheckControl("<%=ddlcount.ClientID%>")) {
               msg += "- Select Count from list \n";
               if (ctrl == "")
                   ctrl = "<%=ddlcount.ClientID%>";
                  flag = false;
           }
           if (!CheckControl("<%=txttodate.ClientID%>")) {
               msg += "- Enter Date \n";
               if (ctrl == "")
                   ctrl = "<%=txttodate.ClientID%>";
               flag = false;
           }
           if (!CheckControl("<%=txtfromdate.ClientID%>")) {
               msg += "- Enter Date \n";
               if (ctrl == "")
                   ctrl = "<%=txtfromdate.ClientID%>";
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
                Student Last Transaction
            </h2>

        </div>
    
    <div id="cBody">
        <div id="cHead">
            <table>
                <tr>
                    <th>Head<span class="required">*</span></th>
                    <th>Count Records<span class="required">*</span></th>
                    <th>To Date<span class="required">*</span></th>
                    <th>From Date<span class="required">*</span></th>
                    </tr>
                <tr>
                    <td>
                        <asp:DropDownList ID="ddlhead" runat="server"></asp:DropDownList>
                    </td>
                    <td><asp:DropDownList id=ddlcount runat="server">
                        <asp:ListItem Value="0" Text="Select"></asp:ListItem>
                        <asp:ListItem Value="10" Text="Last 10 Records"></asp:ListItem>
                        <asp:ListItem Value="20" Text="Last 20 Records"></asp:ListItem>
                        <asp:ListItem Value="50" Text="Last 50 Records"></asp:ListItem>
                        <asp:ListItem Value="100" Text="Last 100 Records"></asp:ListItem>
                        <asp:ListItem Value="200" Text="Last 200 Records"></asp:ListItem>
                        <asp:ListItem Value="500" Text="Last 500 Records"></asp:ListItem>

                        </asp:DropDownList></td>
                    <td><asp:TextBox ID="txttodate" runat="server"></asp:TextBox>
                        <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender2" runat="server" Mask="99/99/9999" MaskType="Date" TargetControlID="txttodate">
                                            </ajaxToolkit:MaskedEditExtender>
                                            <ajaxToolkit:CalendarExtender ID="CalendarExtender2" runat="server" Format="dd/MM/yyyy" TargetControlID="txttodate">
                                            </ajaxToolkit:CalendarExtender>

                    </td>
                    <td><asp:TextBox ID="txtfromdate" runat="server"></asp:TextBox>
                        <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender1" runat="server" Mask="99/99/9999" MaskType="Date" TargetControlID="txtfromdate">
                                            </ajaxToolkit:MaskedEditExtender>
                                            <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd/MM/yyyy" TargetControlID="txtfromdate">
                                            </ajaxToolkit:CalendarExtender>

                    </td>
                    <td><asp:Button ID="btnshow" runat="server" Text="Show" OnClick="btnshow_Click" /></td>
                </tr>
            </table>
          <table>
              
              <tr>
                  <td>
                      <div style="overflow: auto; width: 100%; height: 700px;">
                          <asp:GridView ID="gvshow" runat="server" AutoGenerateColumns="false" EmptyDataText="No Record Found" Width="100%" CssClass="gridDynamic">
                                        <Columns>
                                            <asp:TemplateField HeaderText="S.No.">
                                                <ItemTemplate>
                                                    <%# ((GridViewRow)Container).RowIndex + 1%>
                                                    .
                                                </ItemTemplate>
                                                <ItemStyle Width="30px" />
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="ENROLLMENT_NO" HeaderText="ENROLLMENT" />
                                            <asp:BoundField DataField="STU_FULL_NAME" HeaderText="NAME" />
                                            <asp:BoundField DataField="INS_VALUE" HeaderText="INSTITUTION"/>
                                            <asp:BoundField DataField="PGM_SHORT_NAME" HeaderText="COURSE" />
                                            <asp:BoundField DataField="BRN_SHORT_NAME" HeaderText="BRANCH" />
                                            <asp:BoundField DataField="FEE_MAIN_HEAD_NAME" HeaderText="HEAD NAME" />
                                            <asp:BoundField DataField="FEE_RCV_TRAN_AMT" HeaderText="AMOUNT" DataFormatString="{0:N2}" />
                                            <asp:BoundField DataField="NOC" HeaderText="NO OF TRAN" />
                                            <asp:BoundField DataField="FEE_RCV_RECEIPT_NO" HeaderText="RCPT NO" />
                                            <asp:BoundField DataField="EMP_NAME" HeaderText="TRAN BY" />
                                            <asp:BoundField DataField="FEE_RCV_REMARK" HeaderText="REMARK" />
                                            <asp:BoundField DataField="FEE_RCV_TRAN_DT" HeaderText="TRAN DATE" />
                                            
                                            
                                        </Columns>
                                    </asp:GridView>
                          </div>
                  </td>
                  
              </tr>
          </table>

        </div>
        <div id="cCenter">
           <!-- Content Header ex: Grids-->

        </div>
         <div id="cFooter">
              <!-- Content Header ex:Buttons-->

        </div>
</div>
</div>

</asp:Content>

