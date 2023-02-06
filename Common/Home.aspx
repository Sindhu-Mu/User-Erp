<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Home.aspx.cs" Inherits="Common_Home" %>

<%@ Register Src="../control/menu.ascx" TagName="menu" TagPrefix="uc1" %>
<%@ Register Src="../Control/QuickLinks.ascx" TagName="QuickLinks" TagPrefix="uc2" %>
<%@ Register Src="../Control/ActionRequest.ascx" TagName="ActionRequest" TagPrefix="uc3" %>
<%@ Register Src="../Control/UseFullLink.ascx" TagName="UseFullLink" TagPrefix="uc4" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>ERP | Home</title>
    <link href="../css/FullLength.css" rel="stylesheet" type="text/css" />
    <link rel="icon" type="image/png" href="../Siteimages/favicon.ico" />
     <style type="text/css">
        .responsive {
            width:90%;
            max-width:230px;
            height:auto;
        }
    </style>
</head>
<body>
    <form runat="server">
        <div id="mu_wrapper">
            <div id="mu_header">
                <asp:ScriptManager ID="ScriptManager1" runat="server">
                </asp:ScriptManager>
                <table style="margin: 0; border-collapse: collapse" cellpadding="." cellspacing=".">
                    <tr>
                        <td style="margin: 0">
                            <img src="../siteimages/mu_logo.png" alt="logo" class="responsive" />
                        </td>
                        <td>
                            <div style="height: 16px;"></div>
                            <uc1:menu ID="Menu1" runat="server" ClientIDMode="Static"></uc1:menu>
                        </td>
                    </tr>
                </table>
                <!-- end of mu_menu -->


            </div>
            <!-- end of header -->

            <div id="mu_banner">

                <div id="about">
                    <img src="../images/emp_images/empImage.jpg" alt="" runat="server" id="ImgEmp" style="width: 100px; height: 120px;" /><br />
                    <asp:Label ID="lblUserCode" runat="server"></asp:Label><br />
                    <asp:Label ID="lblUserName" runat="server"></asp:Label><br />
                    <a href="../login/ChangePassword.aspx">Change Password</a><br />
                    <a href="../login/Default.aspx">Logout</a>
                </div>
                <div id="banner">

                    <p>
                        <script type="text/javascript" src="http://www.brainyquote.com/link/quotebr.js"></script>
                        <small><i><a href="http://www.brainyquote.com/quotes_of_the_day.html" target="_blank">more Quotes</a></i></small>
                    </p>
                </div>



            </div>
            <!-- end of mu_banner -->
            <%--<div id="mu_content_wrapper">
                <div class="mu_sidebar">
                    <uc2:QuickLinks ID="QuickLinks1" runat="server" />
                    <uc4:UseFullLink ID="UseFullLink1" runat="server" />
                </div>
                <!-- end of sidebar 1 -->
                <div class="mu_sidebar">
                    <div class="sidebar_box">
                        <uc3:ActionRequest ID="ActionRequest1" runat="server" />

                    </div>

                </div>
                <!-- end of mu_sidebar 2 -->

                <div id="mu_content">

                    <div class="post_section">

                        <h2>About Us</h2>
                        <img src="../siteimages/mu_image_01.jpg" alt="" />

                        <p>
                            The word Mangalayatan is fashioned by the combination of two words; Mangal & Ayatan, which refers to the Home (Place) that endows bliss (contentment) and positive vibrations.  Mangalayatan symbolizes the ultimate resource which underlines well-being and prosperity. 

Mangalayatan University has been created under the "Mangalayatan University, Uttar Pradesh Act" and notified by the Government of Uttar Pradesh as Act No. 32 of 2006, by its Gazette No. 362/VII-V-1-1(Ka)-12/2006 dated October 30, 2006, with the right to confer degrees under section (2f) and 22(1) of the UGC Act. 

Mangalayatan University has achieved distinction of being one of the premier educational centers of Northern India which believes in imparting quality education and to make its budding technocrats and professionals not only strong in their respective specialized streams but also good citizens. There are regular sports and curricular activities undertaken under the guidance of experienced and celebrated trainers. Approximately 3000 students are enrolled in Postgraduate, Undergraduate and Diploma Programs. 


                        </p>

                        <a href="#" class="more">Continue reading...</a>

                    </div>

                </div>

                <div class="cleaner"></div>

            </div>--%>
            <div id="mu_content_wrapper">
                <div class="mu_sidebar">
                    <uc2:QuickLinks ID="QuickLinks1" runat="server" />
                    <uc4:UseFullLink ID="UseFullLink1" runat="server" />
                </div>
                <!-- end of sidebar 1 -->
                <div class="mu_sidebar">
                    <div class="sidebar_box">
                        <uc3:ActionRequest ID="ActionRequest1" runat="server" />
                    </div>

                </div>
                <!-- end of mu_sidebar 2 -->

                <%--<div id="mu_content">

                    <div class="post_section">

                        <h2>About Us</h2>
                        <img src="../siteimages/mu_image_01.jpg" alt="" />

                        <p>
                            The word Mangalayatan is fashioned by the combination of two words; Mangal & Ayatan, which refers to the Home (Place) that endows bliss (contentment) and positive vibrations.  Mangalayatan symbolizes the ultimate resource which underlines well-being and prosperity. 

Mangalayatan University has been created under the "Mangalayatan University, Uttar Pradesh Act" and notified by the Government of Uttar Pradesh as Act No. 32 of 2006, by its Gazette No. 362/VII-V-1-1(Ka)-12/2006 dated October 30, 2006, with the right to confer degrees under section (2f) and 22(1) of the UGC Act. 

Mangalayatan University has achieved distinction of being one of the premier educational centers of Northern India which believes in imparting quality education and to make its budding technocrats and professionals not only strong in their respective specialized streams but also good citizens. There are regular sports and curricular activities undertaken under the guidance of experienced and celebrated trainers. Approximately 3000 students are enrolled in Postgraduate, Undergraduate and Diploma Programs. 


                        </p>

                        <a href="#" class="more">Continue reading...</a>

                    </div>

                </div>--%>
                <div id="mu_content" style="min-height: 700px">
                    <table style="width: 99%; margin-top: 10px; margin-left: 30px">
                        <tr style="text-align: center">
                            <td style="background-color: #c40c0c; font-weight: 600; color: #fff">Notice Circulars</td>
                        </tr>
                        <tr>
                            <td>
                                <% 
                                    while (enNot.MoveNext())
                                    {
                                        NoticePicker b = (NoticePicker)enNot.Current; 
                                %>
                                <div style="font-weight: bold"><%= b.newsHeading%></div>

                                <div>

                                    <div style="text-align: right">
                                        <a class="more" href="ViewNoticeCircular.aspx?newsid=<%= b.newsID  %>" style="text-decoration: none">More...
                                        </a>
                                    </div>
                                    <div>Published On:<%=b.newsDate%> <font style="float: right"><a href="../UploadedFile/File/<%= b.dwfilename %>" target="_blank">Download</a></font></div>
                                    <hr />
                                    <% 
                                    }   
                                    %>
                                </div>
                            </td>

                        </tr>
                    </table>
                </div>
                <div class="cleaner">
                </div>
            </div>
            <!-- end of mu_content_wrapper -->

        </div>
        <!-- end of mu_wrapper -->

        <div id="mu_footer_wrapper">
            <div id="mu_footer">
                <div class="section_w180px">
                    <h3>Download Section</h3>
                    <ul class="footer_menu_list">
                        <li><a href="../UploadedFile/VEHICLEREQUISITION.pdf" target="_blank" style="color:red;font-weight:200;">Vehicle Requisition Form</a></li>
                        <li><a href="../UploadedFile/House_Rent_Receipt.docx" target="_blank">House Rent Receipt</a></li>
                        <li><a href="../UploadedFile/Investment_declarationform.xls" target="_blank">Investment Declaration</a></li>
                        <li><a href="../UploadedFile/Library_Staff.jpg" target="_blank">Library Form</a></li>
                        <li><a href="../UploadedFile/Advance_Salary.docx" target="_blank">Advance Salary</a></li>
                        <li><a href="../UploadedFile/travelreimbursementform.xls" target="_blank">Travel Reimbursement</a></li>
                        <%--<li><a href="../UploadedFile/RefundApplicationForm.docx" target="_blank">Refund Form</a></li>--%>
                    </ul>
                </div>
                <div class="section_w180px">
                    <h3>Important Link's</h3>
                    <ul class="footer_menu_list">
                        <li><a href="../Common/ContactUs.html" target="_blank">Contact Us</a></li>
                        <li><a href="http://14.139.238.163/radiusmanager/user.php" target="_blank">Wi-Fi Password Reset</a></li>
                        <li><a href="../UploadedFile/Scan_20150314.pdf" target="_blank">Leave Rule</a></></li>
                        <li><a href="../UploadedFile/Leave_Application_Common.docx" target="_blank">Leave Application</a></li>
                        <li><a href="../UploadedFile/Academic_Leave.doc" target="_blank">Academic Leave</a></li>                        
                    </ul>
                </div>

                <div class="section_w180px">
                    <h3>Newspapers</h3>
                    <ul class="footer_menu_list">
                        <li><a href="http://timesofindia.indiatimes.com/" target="_blank">Times Of India</a></li>
                        <li><a href="http://www.hindustantimes.com/" target="_blank">Hindustan Times</a></li>
                        <li><a href="http://www.amarujala.com/" target="_blank">Amar Ujala</a></li>
                        <li><a href="http://economictimes.indiatimes.com/" target="_blank">The Economic Times</a></li>
                        <li><a href="http://www.jagran.com/" target="_blank">Danik Jagran</a></li>
                    </ul>
                </div>

                <div class="section_w180px">
                    <h3>Other Links</h3>
                    <ul class="footer_menu_list">
                        <li><a href="http://ieeexplore.ieee.org" target="_blank">IEEE Journals</a></li>
                        <li><a href=" http://online.sagepub.com" target="_blank">Sage Journals of IBM</a></li>
                        <li><a href="https://www.irctc.co.in/">IRCTC</a></li>
                        <li><a href="http://www.journeymart.com/de/india.aspx">Tourism In India</a></li>

                    </ul>
                </div>

                <%-- <div class="section_w180px">
                    <h3>XHTML/CSS Validators</h3>
                    <a href="http://validator.w3.org/check?uri=referer">
                        <img style="border: 0; width: 88px; height: 31px" src="http://www.w3.org/Icons/valid-xhtml10" alt="Valid XHTML 1.0 Transitional" width="88" height="31" vspace="8" border="." /></a>
                    <div class="margin_bottom_10"></div>
                    <a href="http://jigsaw.w3.org/css-validator/check/referer">
                        <img style="border: 0; width: 88px; height: 31px" src="http://jigsaw.w3.org/css-validator/images/vcss-blue" alt="Valid CSS!" vspace="8" border="." /></a>
                </div>--%>

                <div class="margin_bottom_20"></div>

                Copyright © 2016  <a href="http://www.Mangalayatan.in">Mangalayatan University</a> All rights reseved.
            </div>
            <!-- end of footer -->
        </div>
        <!-- end of footer wrapper -->
    </form>
</body>
</html>
