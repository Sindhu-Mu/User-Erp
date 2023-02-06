<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TemporaryEmployeeCard.aspx.cs" Inherits="HR_EmployeeCard"
    EnableViewState="false" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>I Card</title>
     <meta http-equiv="X-UA-Compatible" content="IE=9" />
    <style type="text/css">
        @font-face {
            font-family: barcode;
            src: url(../css/free3of9/IDAutomationHC39M_FREE.otf);
        }

        body {
            margin: 0px;
            padding: 0px;
        }

        #apDiv1 {
            position: absolute;
            width: 328px;
            height: 215px;
            z-index: 1;
        }

         #apDiv2 {
            position: absolute;
            width: 28px;
            height: 213px;
            z-index: 1;
            font-size: 20px;
            background-color: Black;
            text-align: center;
            font-weight: bold;
            color: #fff;
            writing-mode: vertical-lr;
            -webkit-transform: rotate(-180deg);
            -moz-transform: rotate(-180deg);
        }
        /**stu img**/
        #apDiv3 {
            position: absolute;
            width: 109px;
            height: 100px;
            text-align:center;
            z-index: 2;
            left: 45px;
            top: 40px;
        }
        /**stu name**/
        #apDiv4 {
            position: absolute;
            width: 140px;
            height: 23px;
            z-index: 3;
            left: 30px;
            top: 11px;
        }
        /**footer**/
        #apDiv5 {
            position: absolute;
            width: 301px;
            height: 70px;
            z-index: 4;
            left: 28px;
            top: 143px;
            color: #ffffff;
        }
        /**stu batch**/
        #apDiv6 {
            position: absolute;
            font-size: 11px;
            z-index: 5;
            left: 31px;
            top: 70px;
            text-align: center;
            font-weight: bold;
            writing-mode: vertical-lr;
            -webkit-transform: rotate(-180deg);
            -moz-transform: rotate(-180deg);
        }

        #apDiv7 {
            position: absolute;
            width: 50px;
            height: 30px;
            z-index: 1;
            left: 244px;
            top: 15px;
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
            width: 180px;
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
            top: 50px;
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
      <%#DataBinder.Eval(Container.DataItem,"DEPT_ALIAS")%>
 <%-- <img alt="Department Image" src="<%#DataBinder.Eval(Container.DataItem,"DEPT_IMAGE")%>"style="width:20px; height:150px;margin-left:5px;margin-top:10px" />--%>
  </div>
  <div id="apDiv3" ><img alt="Employee Image" style="width:90px;height:100px" src="<%# DataBinder.Eval(Container.DataItem, "EMP_IMAGE") %>"" /></div>
  <div id="apDiv4" style="font-size:10px;text-align:center"><%# DataBinder.Eval(Container.DataItem, "EMP_NAME") %><br/> <%# DataBinder.Eval(Container.DataItem, "DESIG_NAME") %></div>
  <div id="apDiv5" style="background-color: <%# DataBinder.Eval(Container.DataItem, "COLOR") %>">
    <div id="apDiv7"><img src="../images/sign/registrar.png" alt="sign" style="width: 50px; height: 25px; border: 0px" /></div>
    <div id="apDiv8" style="font-size:10px">
    <table cellspacing="0px">
    <tr>
    <td>Fathers Name : <%# DataBinder.Eval(Container.DataItem, "FATHER_NAME") %></td>
    </tr>
    <tr>
    <td>DOB : <%# DataBinder.Eval(Container.DataItem, "DOB")%>&nbsp;&nbsp;&nbsp;
    Blood Group : <%# DataBinder.Eval(Container.DataItem, "Blood_Group")%></td>
    </tr>
    <tr>
    <td>Address :<%# DataBinder.Eval(Container.DataItem, "PRESENT_ADD")%></td>
    </tr>
    <tr>
    <td>Contact No. : <%# DataBinder.Eval(Container.DataItem, "PHONE")%></td>
    </tr>
    </table>
    </div>
    <div id="apDiv9" style="font-size:8px;text-align:center">Registrar</div>
  </div>
  <div id="apDiv6"> <%#DataBinder.Eval(Container.DataItem,"SESSION_VALUE")%>
     <%-- <img alt="Batch Image" style="width:10px; height:60px" src="<%# DataBinder.Eval(Container.DataItem, "SESSION_IMAGE") %>" />--%></div>
  <div id="apDiv10" style="text-align:center;font-size:14px;font-family:barcode">
                                                                *<%# DataBinder.Eval(Container.DataItem,"EMPCODE")%>*
                                                                <%-- <img alt="barcode" style="height: 25px; width: 160px;" src="<%# DataBinder.Eval(Container.DataItem, "BARCODE") %>" />--%>
                                                     
                                                            </font></div>
  <div id="apDiv11"><%# DataBinder.Eval(Container.DataItem, "EMPCODE") %></div>
  <div id="apDiv12"><img src="http://192.168.1.5/EmployeePortal/images/mu.jpg" alt="mu" style="width:150px;height:90px;border:0px" />
      &nbsp;&nbsp;&nbsp;&nbsp; <p style="margin-top: -20px;margin-left:11px">valid upto one year</p>


  </div>
</div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </form>
        </div>
</body>
</html>
