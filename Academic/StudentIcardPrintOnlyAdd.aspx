<%@ Page Language="C#" AutoEventWireup="true" CodeFile="StudentIcardPrintOnlyAdd.aspx.cs" Inherits="Academic_StudentIcardPrint" %>

<%@ PreviousPageType VirtualPath="StudentIcardOnlyAdd.aspx" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>I Card</title>
    <meta http-equiv="X-UA-Compatible" content="IE=9" />
    <style type="text/css">
@font-face
{
font-family:barcode;
src: url(../css/free3of9/IDAutomationHC39M_FREE.otf);
}
</style>
<style type="text/css">
    @media print {
    #card {page-break-after: always;}
}
    #card {
        position:relative;
        
    }
body{
margin:0px;
padding:0px;
}
#apDiv1 {
    position:relative;
	width:328px;
	height:212px;
	z-index:1;
}
#apDiv2 {
	position:absolute;
	width:28px;
	height:213px;
	z-index:1;
	
    
}
#apDiv2 img{
    vertical-align: middle;
}
/**stu img**/
#apDiv3 {
	position:absolute;
	width:109px;
	height:114px;
	z-index:2;
	left:45px;
	top: 40px;
}
/**stu name**/
#apDiv4 {
	position:absolute;
	width:140px;
	height:23px;
	z-index:3;
	left:30px;
	top: 11px;
	
}
#apDiv5 {
	position:absolute;
	width:301px;
	height:60px;
	z-index:4;
	left: 28px;
	top: 153px;
}
/**stu batch**/
#apDiv6 {
	position:absolute;
	width:17px;
	height:96px;
	z-index:5;
	left:30px;
	top: 70px;
}
#apDiv7 {
	position:absolute;
	width:50px;
	height:30px;
	z-index:1;
	left: 244px;
	top:15px;
}
#apDiv8 {
	position:absolute;
	width:238px;
	height:40px;
	z-index:2;
	top: 1px;
}
#apDiv9 {
	position:absolute;
	width:51px;
	height:13px;
	z-index:3;
	left: 244px;
	top: 40px;
}
/**bar code**/
#apDiv10 {
	position:absolute;
	width:180px;
	height:45px;
	z-index:10;
	right:7px;
	top:15px;
	
}
#apDiv11 {
	position:absolute;
	width:180px;
	height:14px;
	z-index:12;
    right:7px;
	top:45px;
	font-size:12px;
	text-align:center;
}
#apDiv12 {
	position:absolute;
	width:190px;
	height:105px;
	z-index:8;
	left: 165px;
	top:60px;
}
</style>

</head>
<!--onload="window.print();window.location = 'StudentCardInput.aspx'-->
<body style="margin-top:0px">
    <form id="form" runat="server">
     <asp:Repeater ID="repICard" runat="server" OnItemCommand="repICard_ItemCommand" >
         
     <ItemTemplate>
        <div id="card"> 
     <div id="apDiv1">
  <div id="apDiv2"> 
  
  </div>
  <div id="apDiv3"></div>
  <div id="apDiv4" style="font-size:10px;text-align:center"> </div>
  <div id="apDiv5" >
    <div id="apDiv7"></div>
    <div id="apDiv8" style="font-size:10px">
    <table cellspacing="0px">
    <tr>
    <td>&nbsp;</td>
    </tr>
    <tr>
    <td>&nbsp;</td>
    </tr>
    <tr>
    <td style="background-color:black;color:yellow;">Address :<%# DataBinder.Eval(Container.DataItem, "ADDR")%></td>
    </tr>
    </table>
    </div>
    <div id="apDiv9" style="font-size:8px;text-align:center"></div>
  </div>
  <div id="apDiv6"></div>
  
         <div id="apDiv10" style="text-align:center;font-size:14px;font-family:barcode">
        
      
                                                               
                                                                <%-- <img alt="barcode" style="height: 25px; width: 160px;" src="<%# DataBinder.Eval(Container.DataItem, "BARCODE") %>" />--%>
                                                     
                                                            </div>
  <%--<div id="apDiv11"><%# DataBinder.Eval(Container.DataItem, "STU_ADM_NO") %></div>--%>
  <div id="apDiv12"></div>
</div>
             </div>
         
     </ItemTemplate>
     </asp:Repeater>
           </form>
   
</body>
</html>

