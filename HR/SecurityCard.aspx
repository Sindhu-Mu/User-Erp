<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SecurityCard.aspx.cs" Inherits="HR_EmployeeCard"
    EnableViewState="false" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>I Card</title>
     <meta http-equiv="X-UA-Compatible" content="IE=9" />
    <style type="text/css">
        @font-face {
            font-family: barcode;
            src: url(../css/free3of9/FREE3OF9.TTF);
        }

        body {
            margin: 0px;
            padding: 0px;
        }

        #apDiv1 {
            position: absolute;
            width:212px;
            height:328px;
            z-index: 1;
            
        }

        #apDiv2 {
            position: absolute;
            top:10px;
            width: 212px;
            height:20px;
            z-index: 1;
            background-color:maroon;
            text-align:center;
            color:#fff;
           
           
        }

            #apDiv2 img {
                vertical-align: middle;
            }
        /**stu img**/
        #apDiv3 {
            position: absolute;
            width: 212px;
            height: 40px;
            text-align:center;
            z-index: 2;
            top: 34px;
           
        }
            #apDiv3 img {
                width: 180px;
            height: 30px;
            }
        /**stu name**/
        #apDiv4 {
            position: absolute;
            width: 212px;
            height: 100px;
            z-index: 3;
            top: 80px;
            text-align:center;
        }
            #apDiv4 img {
                text-align: center;
                width: 80px;
                height: 100px;
                margin: 0 auto;
            }
            #apDiv4 #img2 {
                text-align:center;
                width:10px;
                height:100px;
                margin:0 auto;
                
            }
            #apDiv4 #img3 {
                width:10px;
                height:100px;
                margin:0 auto;

            }
             #blank {
                min-width:10px;
                min-height:100px;
                max-width:10px;
                max-height:100px;
                

            }
        /**footer**/
        
        /**stu batch**/
        #apDiv6 {
            position: absolute;
            top:270px;
            width: 212px;
            height:20px;
            z-index: 30;
            background-color:maroon;
            text-align:center;
            color:#fff;
           
        }

        #apDiv7 {
             position: absolute;
            width: 212px;
           font-size:12px;
            z-index: 0;
            top: 230px;
            
            margin-right:10px;
            text-align:right;
        }
         .sign{
                max-width:60px;
                max-height:20px;
                min-width:60px;
                min-height:20px;
            }

        #apDiv8 {
            position: absolute;
            width: 235px;
            height: 40px;
            z-index: 2;
            top: 1px;
            padding-left: 3px;
        }

        #apDiv9 {
            position: absolute;
            width: 51px;
            height: 13px;
            z-index: 3;
            left: 244px;
            top: 40px;
        }
        /**bar code**/
        #apDiv10 {
            position: absolute;
            width: 200px;
            height: 45px;
            z-index: 6;
            right: 7px;
            top: 15px;
        }

        #apDiv11 {
            position: absolute;
            width: 180px;
            height: 14px;
            z-index: 12;
            right: 7px;
            top: 45px;
            font-size: 12px;
            text-align: center;
        }

        #apDiv12 {
            position: absolute;
            width: 190px;
            height: 105px;
            z-index: 8;
            left: 165px;
            top: 50px;
        }
        #apDiv5 {
           position: absolute;
            width: 212px;
           font-size:12px;
            z-index: 3;
            top: 180px;
            color:black;
          
            text-align:center;
        }
         #apDiv8 {
           position: absolute;
            width: 212px;
           font-size:10px;
            z-index:50;
            top: 290px;
          padding-left:5px;
          padding-right:5px;
            text-align:center;
        }
    </style>
</head>
<body>
    <div class="container">
    <form id="form1" runat="server">
        <div>
            <asp:Repeater ID="repICard" runat="server">
                <ItemTemplate>

                <div id="apDiv1">
                    <div id="apDiv2">
                        Identity Card
                    </div>
                    <div id="apDiv3">
                       
                        <img src="../images/security_images/logo.png" />
                        </div>
                    <div id="apDiv4">
                        <img src="../images/security_images/year.png" id="img2" />
                        <img src="../images/security_images/<%#Eval("EMP_CODE") %>.jpg" style="padding-right:10px;"/>                       
                        </div>
                    <div id="apDiv5">
                             <b><%#Eval("EMP_NAME") %></b>
                                                <br/>Employee Code : <%#Eval("EMP_CODE") %>
                        
                        <br/>Designation: <%#Eval("DESIGNTN") %>

                    </div>
                    <div id="apDiv7">
                        <img src="../images/security_images/Signature1.png" class="sign" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br/>
                        Authority Signature&nbsp;&nbsp;&nbsp;
                        </div>
                    <div id="apDiv6">
                        Aligarh
                        </div>
                     <div id="apDiv8">
Mangalayatan University, Ext.NCR,33rd<br /> 
Milestone,Mathura-Aligarh Highway,<br /> 
Beswan Aligarh-202145 (U.P) India.
                        </div>
                </div>


</ItemTemplate>
            </asp:Repeater>
        </div>
    </form>
        </div>
</body>
</html>
