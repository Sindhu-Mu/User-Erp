<%@ Page Language="C#" AutoEventWireup="true" CodeFile="prtCopyCollection.aspx.cs" Inherits="Academic_prtCopyCollection" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Attendance Collection Sheet</title>
    <style type="text/css">
      
        .style4
        {
            font-size: 16px;
            font-style: italic;
            font-family:"Century Gothic";
            font-weight: bold;
        }
        .style5
        {
            font-size: medium;
            font-weight: bold;
        }
       
    </style>
</head>
<body onload="window.print();">
      <form id="form1" runat="server" >          
<table style="width:700px; font-family:Book Antiqua;font-size:14px;"  >
   
       <tr >
           <td id="tdMain" runat="server" > 
           </td>
       </tr>
                        
              
    </table>
    
    </form>
</body>
</html>
