<%@ Page Language="C#" AutoEventWireup="true" CodeFile="StudentIcardPrint.aspx.cs" Inherits="Academic_StudentIcardPrint" %>


<%@ PreviousPageType VirtualPath="StudentIcard.aspx" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>I Card</title>
    <meta http-equiv="X-UA-Compatible" content="IE=9" />
    <style type="text/css">
        @font-face {
            font-family: barcode;
            src: url(../css/free3of9/IDAutomationHC39M_FREE.otf);
        }
    </style>
    <style type="text/css">
        @media print {
            #card {
                page-break-after: always;
            }
        }

        #card {
            position: relative;
        }

        body {
            margin: 0px;
            padding: 0px;
        }

        #apDiv1 {
            position: relative;
            width: 350px;
            height: 250px;
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
            height: 114px;
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

        #apDiv5 {
            position: absolute;
            width: 301px;
            height: 60px;
            z-index: 4;
            left: 28px;
            top: 153px;
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
            width: 90%;
            height: 40px;
            z-index: 2;
            top: 1px;
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
            width: 190px;
            height: 95px;
            z-index: 8;
            left: 165px;
            top: 5px;
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
            width: 180px;
            height: 45px;
            z-index: 10;
            right: 7px;
            top: 90px;
        }
    </style>

</head>
<!--onload="window.print();window.location = 'StudentCardInput.aspx'-->
<body style="margin-top: 0px">
    <form id="form" runat="server">
 <asp:Repeater ID="repICard" runat="server" OnItemCommand="repICard_ItemCommand">

            <ItemTemplate>
                <div id="card">
                    <div id="apDiv1">
                        <div id="apDiv2">
                            <%--<img alt="Institute Image" src="<%# DataBinder.Eval(Container.DataItem, "INS")%>" style="width: 20px; height: 150px;" />--%>
                            <%# DataBinder.Eval(Container.DataItem, "INS_VALUE") %>
                        </div>
                        <div id="apDiv3">
                            <img alt="Student Image" style="width: 100px; height: 110px" src="<%# DataBinder.Eval(Container.DataItem, "STU_IMAGE") %>" />
                        </div>
                        <div id="apDiv4" style="font-size: 11px; text-align: center">
                            <%# DataBinder.Eval(Container.DataItem, "STU_NAME") %><br />
                            <%# DataBinder.Eval(Container.DataItem, "COURSE") %>
                        </div>
                        <div id="apDiv5" style="color: #fff; background-color: <%# DataBinder.Eval(Container.DataItem, "COLOR") %>">
                            <div id="apDiv7">
                                <img src="../images/sign/registrar.png" alt="sign" style="width: 50px; height: 25px; border: 0px" />
                            </div>
                            <div id="apDiv8" style="font-size: 10px; font-weight: 700;">
                                <table>
                                    <tr>
                                        <td>Fathers Name : <%# DataBinder.Eval(Container.DataItem, "FATHERS_NAME") %>&nbsp;&nbsp;&nbsp;BG:<%# DataBinder.Eval(Container.DataItem, "BLOOD_GP")%></td>
                                    </tr>
                                    <tr>
                                        <td>DOB : <%# DataBinder.Eval(Container.DataItem, "DT_O_BIRTH")%>&nbsp;&nbsp;Contact No. : <%# DataBinder.Eval(Container.DataItem, "STU_MOBILE")%></td>
                                    </tr>
                                    <tr>
                                        <td style="font-size: 8px">Address :<%# DataBinder.Eval(Container.DataItem, "ADDR")%></td>
                                    </tr>
                                </table>
                            </div>
                            <div id="apDiv9" style="font-size: 8px; text-align: center">Registrar</div>
                        </div>
                        <div id="apDiv6">
                            <%--<img alt="Batch Image" style="width: 10px; height: 60px" src="<%# DataBinder.Eval(Container.DataItem,"BATCH") %>" />--%>
                            <%# DataBinder.Eval(Container.DataItem, "BATCH_NAME") %>
                        </div>
                        <div id="apDiv10">
                            <img src="../Siteimages/mu_logo.png" alt="mu" style="width: 150px; height: 80px; border: 0px" />
                        </div>
                        <div id="apDiv12" style="text-align: center; font-size: 14px; font-family: barcode">

                            <%# DataBinder.Eval(Container.DataItem,"BARCODE2")%>
                            <%-- <img alt="barcode" style="height: 25px; width: 160px;" src="<%# DataBinder.Eval(Container.DataItem, "BARCODE") %>" />--%>
                        </div>
                        <%--<div id="apDiv11"><%# DataBinder.Eval(Container.DataItem, "STU_ADM_NO") %></div>--%>
                    </div>
                </div>

            </ItemTemplate>
        </asp:Repeater>
    </form>
</body>
</html>
