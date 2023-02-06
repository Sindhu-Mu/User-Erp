<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/FullLength.master" AutoEventWireup="true" CodeFile="FeeRefund.aspx.cs" Inherits="Finance_BankAccount" %>

<%@ Register Src="~/Control/Student.ascx" TagPrefix="uc1" TagName="Student" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <script lang="javascript" type="text/javascript"> 
         // Client Side Validation Script
     function SelectAllCheckboxes(spanChk)
     {   
         var oItem = spanChk.children;
         var theBox= (spanChk.type=="checkbox") ? 
             spanChk : spanChk.children.item[0];
         xState=theBox.checked;
         elm=theBox.form.elements;

         for(i=0;i<elm.length;i++)
             if(elm[i].type=="checkbox" && 
                      elm[i].id!=theBox.id)
             {
                 //elm[i].click();
                 if(elm[i].checked!=xState)
                     elm[i].click();
                 //elm[i].checked=xState;
             }
     
     }
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

    function valid()
    {
             var flag=true;
             var msg="", ctrl="";    
    if(!CheckControl("<%=ddlSemester.ClientID%>"))
    {
        msg+="- Select semester no from list.\n";
        if(ctrl=="")
            ctrl="<%=ddlSemester.ClientID%>";
        flag=false;
    }    
    if(!CheckControl("<%=txtEnrollment.ClientID%>"))
    {
        msg+="- Enter Enrollment No.\n";
        if(ctrl=="")
            ctrl="<%=txtEnrollment.ClientID%>";
        flag=false;
    }     
    if(msg!="") alert(msg);
    if(ctrl!="") 
        document.getElementById(ctrl).focus();
    return flag;
} 
function Cashvalidat()
{	
		
    var flag=true;
    var msg="", ctrl="";
   
    if(!CheckControl("<%=txtModeAmount.ClientID%>"))
    {
        msg+="- Enter Amount \n";
        if(ctrl=="")
            ctrl="<%=txtModeAmount.ClientID%>";
        flag=false;
    }        
    if(msg!="") alert(msg);
    if(ctrl!="") 
        document.getElementById(ctrl).focus();        
    return flag;
}
function Othervalidat()
{	
		
    var flag=true;
    var msg="", ctrl="";
   
    if(!CheckControl("<%=txtRefNo.ClientID%>"))
    {
        msg+="- Enter Refrence no.\n";
        if(ctrl=="")
            ctrl="<%=txtRefNo.ClientID%>";
        flag=false;
    }    
    if(!CheckControl("<%=ddlBank.ClientID%>"))
     {
         msg+="- Select Bank Name from list.\n";
         if(ctrl=="")
             ctrl="<%=ddlBank.ClientID%>";
        flag=false;
    } 
    if(!CheckControl("<%=txtBranchName.ClientID%>"))
     {
         msg+="- Enter Branch Name.\n";
         if(ctrl=="")
             ctrl="<%=txtBranchName.ClientID%>";
        flag=false;
    }     
    if(!CheckControl("<%=ddlAcountNo.ClientID%>"))
     {
         msg+="- Select Account no from list.\n";
         if(ctrl=="")
             ctrl="<%=ddlAcountNo.ClientID%>";
        flag=false;
    }   
    if(CheckControl("<%=txtDate.ClientID%>"))
     {
         if(!CheckDate("<%=txtDate.ClientID%>"))
         {
             msg+="- Invalid Format of Date.Enter in this[dd/MM/yyyy]\n";
             if(ctrl=="")
                 ctrl="<%=txtDate.ClientID%>";     
         flag=false;
     }
 }
 else
 {      
     msg+="- Please enter Date\n";
     if(ctrl=="")
         ctrl="<%=txtDate.ClientID%>";       
        flag=false;
    }        
    if(!CheckControl("<%=txtModeAmount.ClientID%>"))
     {
         msg+="- Enter Amount \n";
         if(ctrl=="")
             ctrl="<%=txtModeAmount.ClientID%>";
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
                Fee Refund
            </h2>

        </div>    
    <div id="cBody">
        <div id="cHead">
           <!-- Content  Header ex: Filters-->
            <table border="0">
                                 
                                        <tr style="vertical-align: bottom; text-align: left">
                                            <td>
                                                Branch</td>
                                            <td>
                                                Semester</td>
                                            <td>
                                                Enrollment No</td>
                                            <td>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="height: 19px">
                                                <b>
                                                    <asp:DropDownList ID="ddlBranch" runat="server">
                                                    </asp:DropDownList></b></td>
                                            <td style="height: 19px">
                                                <asp:DropDownList ID="ddlSemester" runat="server">
                                                </asp:DropDownList></td>
                                            <td style="height: 19px">
                                                <asp:TextBox ID="txtEnrollment" runat="server" Width="164px" CssClass="textbox"></asp:TextBox></td>
                                            <td style="height: 19px">
                                                <asp:Button ID="btnShow" OnClick="btnShow_Click" runat="server" Width="60px" Text="Show"
                                                    CssClass="btnBrown"></asp:Button>
                                            </td>
                                        </tr>
                                   
                                </table>
            <br/>
            <uc1:Student runat="server" ID="Student" />
            <br/>
        </div>
        <div id="cCenter">
           <!-- Content Header ex: Grids-->
           
         
          <table  style="width:100%">
               <tr>
                            
                <td style="min-width:47%" valign="top">
                                                                <b>FEE<span style="color: #ff0000"> SUBMITTED</span></b>
                                                                <hr style="min-width:100%" />
                                                                <asp:GridView ID="gvFees" runat="server" Width="97%" CssClass="gridDynamic" ShowFooter="True"
                                                                    AutoGenerateColumns="False" DataKeyNames="FEE_DEMAND_ID,FEE_MAIN_HEAD_ID">
                                                                    <Columns>
                                                                        <asp:BoundField DataField="FEE_MAIN_HEAD_NAME" HeaderText="FEE HEAD" />
                                                                        <asp:BoundField DataField="FD_FEE_AMT" DataFormatString="{0:N2}" HeaderText="SUBMIT AMOUNT"
                                                                            FooterText="PAYMENT:-" />
                                                                        <asp:TemplateField>
                                                                            <HeaderTemplate>
                                                                                <input id="chkAll" onclick="javascript:SelectAllCheckboxes(this);" type="checkbox"
                                                                                    value="on" runat="server" style="border-right: 2px groove; border-top: 2px groove;
                                                                                    border-left: 2px groove; border-bottom: 2px groove" /></HeaderTemplate>
                                                                            <ItemTemplate>
                                                                                <asp:CheckBox ID="chk1" runat="server" /></ItemTemplate>
                                                                        </asp:TemplateField>
                                                                    </Columns>
                                                                </asp:GridView>
                                                            </td>
                                                        
               <td style="width: 3%; height: 483px;" rowspan="2">&nbsp;</td>
                <td style="width: 50%; height: 483px;" valign="top">
                                                <table width="100%" border="0">
                                                    <tbody>
                                                        <tr>
                                                            <td colspan="3">
                                                                <b>PAYMENT <span style="color: #ff0000">DETAIL</span></b>
                                                                <hr/>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="margin-top: 4px; margin-bottom: 3px" colspan="3">
                                                                <asp:RadioButtonList ID="RlistMode" runat="server" ForeColor="Black" AutoPostBack="True"
                                                                    OnSelectedIndexChanged="RlistMode_SelectedIndexChanged" RepeatDirection="Horizontal"
                                                                    Font-Bold="True" CellSpacing="0" CellPadding="0">
                                                                </asp:RadioButtonList></td>
                                                        </tr>
                                                        <tr style="text-align: left" id="trRefDetail" runat="server">
                                                            <td colspan="3">
                                                                <table  width="100%" border="0">
                                                                    <tbody>
                                                                        <tr>
                                                                            <td style="height: 21px">
                                                                                <b>
                                                                                    <asp:Label ID="lblRefType" runat="server"></asp:Label>&nbsp;</b>
                                                                            </td>
                                                                            <td style="height: 21px">
                                                                                <asp:TextBox ID="txtRefNo" runat="server" Width="150px" CssClass="textbox"></asp:TextBox>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <th>
                                                                                Bank Name</th>
                                                                            <td>
                                                                                <asp:DropDownList ID="ddlBank" runat="server" Width="200px">
                                                                                </asp:DropDownList>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <th>
                                                                                Branch Name</th>
                                                                            <td>
                                                                                <asp:TextBox ID="txtBranchName" runat="server" Width="150px" CssClass="textbox"></asp:TextBox>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <th>
                                                                                Account No</th>
                                                                            <td>
                                                                                <asp:DropDownList ID="ddlAcountNo" runat="server" Width="200px">
                                                                                </asp:DropDownList></td>
                                                                        </tr>
                                                                        <tr>
                                                                            <th>
                                                                                Date</th>
                                                                            <td>
                                                                                <asp:TextBox ID="txtDate" runat="server" Width="85px" CssClass="textbox"></asp:TextBox></td>
                                                                        </tr>
                                                                    </tbody>
                                                                </table>
                                                            </td>
                                                        </tr>
                                                        <tr style="text-align: left">
                                                            <th>
                                                                Amount</th>
                                                            <td>
                                                                <cc1:NumericTextBox ID="txtModeAmount" runat="server" Width="150px" CssClass="txtno"></cc1:NumericTextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <th style="height: 20px">
                                                            </th>
                                                            <td style="height: 20px">
                                                                <asp:Button ID="btnModeAdd" runat="server" Text="Add Detail" CssClass="btnBrown"
                                                                    OnClick="btnModeAdd_Click"></asp:Button>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="2" style="height: 213px">
                                                                <asp:GridView ID="gvRefDetail" runat="server" Width="100%" CssClass="gridDynamic"
                                                                    ShowFooter="True" AutoGenerateColumns="False" OnRowDeleting="gvRefDetail_RowDeleting">
                                                                    <Columns>
                                                                        <asp:TemplateField HeaderText="S.No.">
                                                                            <ItemTemplate>
                                                                                <%# ((GridViewRow)Container).RowIndex + 1%>
                                                                            </ItemTemplate>
                                                                            <ItemStyle Width="50px" />
                                                                        </asp:TemplateField>
                                                                        <asp:BoundField DataField="PAY_MODE" HeaderText="Pay Mode" />
                                                                        <asp:BoundField DataField="BANK" HeaderText="Bank" />
                                                                        <asp:BoundField HeaderText="REF. No" DataField="FEE_RFD_MODE_NO" />
                                                                        <asp:BoundField DataField="FEE_RFD_MODE_DT" HeaderText="Date" DataFormatString="{0:dd/MM/yyyy}"
                                                                            HtmlEncode="False" FooterText="Total:-">
                                                                            <FooterStyle HorizontalAlign="Right" />
                                                                        </asp:BoundField>
                                                                        <asp:BoundField DataField="FEE_RFD_MODE_AMT" HeaderText="Amount" DataFormatString="{0:N2}"
                                                                            HtmlEncode="False">
                                                                            <ItemStyle HorizontalAlign="Right" />
                                                                        </asp:BoundField>
                                                                        <asp:CommandField ButtonType="Image" DeleteImageUrl="~/images/delete.gif" ShowDeleteButton="True" />
                                                                    </Columns>
                                                                    <HeaderStyle ForeColor="#CC0000" />
                                                                </asp:GridView>
                                                                <ajaxToolkit:CalendarExtender ID="cde1" runat="server" TargetControlID="txtDate"
                                                                    Format="dd/MM/yyyy">
                                                                </ajaxToolkit:CalendarExtender>
                                                                <asp:TextBox ID="txtData" runat="server" Visible="False"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="right" colspan="2">
                                                                <asp:Button ID="btnRefund" runat="server" Text="Refund Fee " CssClass="btnBrown"
                                                                    OnClick="btnRefund_Click"></asp:Button></td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </td>
                                        </tr>
                                   
              </table>  
        </div>
         <div id="cFooter">
              <!-- Content Header ex:Buttons-->

        </div>
</div>
</div>

</asp:Content>

