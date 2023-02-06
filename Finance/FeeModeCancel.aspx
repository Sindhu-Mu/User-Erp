<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/FullLength.master" AutoEventWireup="true" CodeFile="FeeModeCancel.aspx.cs" Inherits="Finance_BankAccount" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <script lang="javascript" type="text/javascript"> 
      

  function CheckDate(ctrl)
  {
      var dt=document.getElementById(ctrl).value;
      if(isDatecheck(dt,"dd/MM/yyyy")==false)
      {
          document.getElementById(ctrl).style.backgroundColor="#fc6";
          return false;
      }
      else
          document.getElementById(ctrl).style.backgroundColor="#fff";
      return true;
  } 
 
         function CheckControl(ctrl)
         {
             if(bTrim(document.getElementById(ctrl).value)=="" || bTrim(document.getElementById(ctrl).value)=="Select" || bTrim(document.getElementById(ctrl).value)==".")
             {	
                 document.getElementById(ctrl).style.backgroundColor="#fc6";
                 return false;
             }
             else
                 document.getElementById(ctrl).style.backgroundColor="#fff";
             return true;
         }

         function validate()
         {
             var flag=true;
             var msg="", ctrl=""; 
   
             if(!CheckControl("<%=ddlMode.ClientID%>"))
    {
        msg+="- Select mode from list.\n";
        if(ctrl=="")
            ctrl="<%=ddlMode.ClientID%>";
        flag=false;
    }
    if(msg!="") alert(msg);
    if(ctrl!="") 
        document.getElementById(ctrl).focus();
    return flag;  
}

function valid()
{
    var flag=true;
    var msg="", ctrl=""; 
   
    if(!CheckControl("<%=ddlReason.ClientID%>"))
    {
        msg+="- Select Reason from list.\n";
        if(ctrl=="")
            ctrl="<%=ddlReason.ClientID%>";
        flag=false;
    }    
    if(!CheckDate("<%=txtDateCnl.ClientID%>"))
    {
        msg+="- Enter Cancellation Date\n";
        if(ctrl=="")
            ctrl="<%=txtDateCnl.ClientID%>";
        flag=false;
    }    
  
    if(msg!="") alert(msg);
    if(ctrl!="") 
        document.getElementById(ctrl).focus();
    return flag;
} 
    </script>
    <div class="container">
        <div class="heading">
            <h2>
                <!-- Page Heading-->
            Fee Mode Cancel
            </h2>

        </div>
    
    <div id="cBody">
        <div id="cHead">
           <!-- Content  Header ex: Filters-->
            <table>
                    <tr>
                        <td>
                            Receipt No.</td>
                        <td>
                            Enrollment No.</td>
                        <td>
                            Receiving Date</td>
                        <td>
                            Mode Type<span style="color:Red">*</span></td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;
                            <asp:TextBox ID="txtReceipt" runat="server" CssClass="textbox"></asp:TextBox>&nbsp;</td>
                            
                        <td>
                            &nbsp;
                            <asp:TextBox ID="txtEnRoll" runat="server" CssClass="textbox"></asp:TextBox>&nbsp;</td>
                        <td>
                            &nbsp;
                            <asp:TextBox ID="txtDateRcv" runat="server" CssClass="textbox"></asp:TextBox>&nbsp;</td>
                        <td>
                            &nbsp;
                            <asp:DropDownList ID="ddlMode" runat="server" Width="150px">
                            </asp:DropDownList>&nbsp;</td>
                        <td>
                            &nbsp;
                            <asp:Button ID="btnShow" runat="server" Text="Show" CssClass="btnBrown" Width="55px"
                                OnClick="btnShow_Click" />&nbsp;</td>
                    </tr>
                </table>
        </div>
        <div id="cCenter">
           <!-- Content Header ex: Grids-->
            <asp:GridView ID="gridShow" runat="server" AutoGenerateColumns="False" Width="100%"
                                EmptyDataText="No Record Found" CssClass="gridDynamic" DataKeyNames="RCV_TRAN_MODE_ID"
                                OnRowDeleting="gridShow_RowDeleting">
                                <Columns>
                                    <asp:TemplateField HeaderText="S#">
                                        <ItemTemplate>
                                            <%# ((GridViewRow)Container).RowIndex + 1%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="ENROLLMENT_NO" HeaderText="Enrollment#" />
                                    <asp:BoundField DataField="FEE_RCV_RECEIPT_NO" HeaderText="Receipt#" />
                                    <asp:BoundField DataField="PAY_MODE_VALUE" HeaderText="MODE TYPE" />
                                    <asp:BoundField DataField="RCV_TRAN_MODE_AMT" HeaderText="AMOUNT" DataFormatString="{0:N2}"
                                        HtmlEncode="False"></asp:BoundField>
                                    <asp:CommandField ShowDeleteButton="true" ButtonType="Button" DeleteText="Cancel" />
                                </Columns>
                            </asp:GridView>
                        </td>
        </div>
         <div id="cFooter">
              <!-- Content Header ex:Buttons-->
             <table id="trReason" runat="server">
                                <tr>
                                    <td style="height: 18px">
                                        Reason<span style="color: Red">*</span></td>
                                    <td style="height: 18px">
                                        Date of Cancellation<span style="color: Red">*</span></td>
                                    <td style="height: 18px">
                                        Remark</td>
                                    <td>
                                        <asp:Label ID="Label1" runat="server" Visible="false"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td style="height: 23px">
                                        &nbsp;
                                        <asp:DropDownList ID="ddlReason" runat="server" Width="150px" AutoPostBack="true">
                                        </asp:DropDownList>&nbsp;</td>
                                    <td style="height: 23px">
                                        &nbsp;
                                        <asp:TextBox ID="txtDateCnl" runat="server" CssClass="textbox"></asp:TextBox>&nbsp;</td>
                                    <td style="height: 23px">
                                        &nbsp;
                                        <asp:TextBox ID="txtRemark" runat="server" CssClass="textbox"></asp:TextBox>&nbsp;</td>
                                    <td style="height: 23px">
                                        &nbsp;
                                        <asp:Button ID="btnOk" runat="server" Text="Ok" CssClass="btnBrown" Width="55px"
                                            OnClick="btnOk_Click" />&nbsp;</td>
                                </tr>
                            </table>
        </div>
</div>
</div>

</asp:Content>

