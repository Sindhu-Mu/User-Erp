<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/FullLength.master" AutoEventWireup="true" CodeFile="ViewNoticeCircular.aspx.cs" Inherits="Common_ViewNoticeCircular" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="container">
        <div class="heading">
            <h2>Notice & Circular</h2>
        </div>
        <div style="width:700px;margin:20px">
            <div class="post_section" style="margin-left:00px">
                <div >
                    <div style="border:solid 2px #808080">
                        <% 
                    if (qs != -1)
                    {
                        while (ie.MoveNext())
                        {
                            NoticePicker a = (NoticePicker)ie.Current; 
		                
		
                %>
                        <div style="padding:5px;background-color:#000000; color:white"> <%= a.newsDate%> - <%= a.newsHeading%><font style="float:right"> <a href="../UploadedFile/File/<%= a.dwfilename %>" target="_blank" style="color:white">Download </a></font></div>
                        <div style="padding:5px;"><%= a.newsDesc%></div>   
                        <%}
                          }
                          
                          
                          %> 
                    </div>
                    </div>
                        <br/>
                        <font style="font-size:20px;">Search Notice</font>
                <hr/>
                
                        <div style="text-align:right"><table>
                            <tr>
                                <th>Keyword</th>
                                <td>
                                    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                                </td>
                                <th>Date</th>
                                <td>
                                    <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                                    <ajaxToolkit:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="TextBox2"
                                        Format="dd/MM/yyyy">
                                    </ajaxToolkit:CalendarExtender>
                                </td>
                                <td>
                                    <asp:Button id="Button1" Text="Search" runat="server" OnClick="btnSearch_Click"/>
                                </td>
                            </tr>
                        </table>
                    </div>
                
                         <% 
                                while (enNot.MoveNext())
                                {
                                    NoticePicker b = (NoticePicker)enNot.Current; 
                            %>
                        <div style="background-color:#f5f0f2;color:#393b3c;padding:2px;margin-top:10px">
                            <div style="padding:5px"><%= b.newsDate%> - <%= b.newsHeading%> <font style="float:right"> <a href="../UploadedFile/File/<%= b.dwfilename %>" target="_blank">Download </a></font></div>
                            <hr/>
                            <div style="padding:5px"><%= b.newsDesc %><div style="text-align:right"><a class="more" href="ViewNoticeCircular.aspx?newsid=<%= b.newsID  %>" style="text-decoration: none">More...
                                    </a></div></div>
                        </div>
                        <%
                
                                dwid = dwid + 1;

                             }
                            %>
                    
            </div>
            </div>
        <div>
           <%-- <table border="0" width="100%" cellspacing="0" cellpadding="0" style="font-family: Tahoma; font-size: 11px">
                <tr>
                    <td width="22">&nbsp;</td>
                    <td>&nbsp;</td>
                    <td width="23">&nbsp;</td>
                </tr>
                <% 
                    if (qs != 0)
                    {
                        while (ie.MoveNext())
                        {
                            NoticePicker a = (NoticePicker)ie.Current; 
		                
		
                %>
                <tr>
                    <td style="height: 30px" width="22"></td>
                    <td align="left" style="height: 30px" valign="bottom">
                        <span>
                            <span style="color: #ff6633; font-size: 20px;"><strong><%= a.newsHeading%></strong></span></span></td>
                    <td style="height: 30px" width="23"></td>
                </tr>
                <tr>
                    <td width="22"></td>
                    <td align="left" style="padding-left: 1px">
                        <strong><span style="color: red">
                            <% if (a.newsDate != "")
                               {
                            %>
                              Published on : <%= a.newsDate%>

                            <%

                           } 
                            %>
                        
                        </span></strong></td>
                    <td width="23" style="color: #000000"></td>
                </tr>
                <tr style="color: #000000">
                    <td width="22">&nbsp;</td>
                    <td align="left" style="padding-left: 2px">
                        <%= a.newsDesc%></td>
                    <td width="23">&nbsp;</td>
                </tr>
                <tr style="color: #000000">
                    <td width="22" style="height: 35px">&nbsp;</td>
                    <td align="left" style="padding-left: 2px; height: 35px;">
                        <%
                        
                            if (a.dwfilename.Trim() == "".Trim())
                            {
                        
                        %>
                        <a href="#1">
                            <img border="0" id="img<%= dwid %>" src="images/button1.jpg" height="17" width="75" alt="Download" fp-style="fp-btn: Embossed Capsule 3; fp-font-size: 8; fp-proportional: 0" fp-title="Download" onmouseover="FP_swapImg(1,0,/*id*/'img<%= dwid %>',/*url*/'images/button2.jpg')" onmouseout="FP_swapImg(0,0,/*id*/'img<%= dwid %>',/*url*/'images/button1.jpg')" onmousedown="FP_swapImg(1,0,/*id*/'img<%= dwid %>',/*url*/'images/button3.jpg')" onmouseup="FP_swapImg(0,0,/*id*/'img<%= dwid %>',/*url*/'images/button2.jpg')"></a>

                        <%
                         
                            }
                            else
                            {
                        %>
                        <a href="DownloadFiles/<%= a.newsID %>.<%= a.dwfilename %>" target="_blank">
                            <img border="0" id="img1" src="images/button1.jpg" height="17" width="75" alt="Download" fp-style="fp-btn: Embossed Capsule 3; fp-font-size: 8; fp-proportional: 0" fp-title="Download" onmouseover="FP_swapImg(1,0,/*id*/'img<%= dwid %>',/*url*/'images/button2.jpg')" onmouseout="FP_swapImg(0,0,/*id*/'img<%= dwid %>',/*url*/'images/button1.jpg')" onmousedown="FP_swapImg(1,0,/*id*/'img<%= dwid %>',/*url*/'images/button3.jpg')" onmouseup="FP_swapImg(0,0,/*id*/'img<%= dwid %>',/*url*/'images/button2.jpg')"></a>
                        <%
                          
                          
                            }
                        %>
                        &nbsp;
                      
                          
                        
                    </td>
                    <td width="23" style="height: 35px">&nbsp;</td>
                </tr>
                <tr style="color: #000000">
                    <td style="height: 26px" width="22"></td>
                    <td align="left" style="padding-left: 2px; height: 26px; background-position: center center; background-image: url(images/splitter.jpg); background-repeat: no-repeat;"></td>
                    <td style="height: 26px" width="23"></td>
                </tr>
                <%
                            dwid = dwid + 1;

                        }
                    }
                %>


                <tr style="color: #000000">
                    <td width="22" style="height: 16px"></td>
                    <td align="left" style="height: 16px"></td>
                    <td width="23" style="height: 16px"></td>
                </tr>
               <%-- <tr style="color: #000000">
                    <td width="22" style="height: 45px" valign="top"></td>
                    <td align="left" style="height: 45px" valign="top">
                        <strong><span style="font-size: 20px;">Search</span></strong></td>
                    <td width="23" style="height: 45px" valign="top"></td>

                </tr>--%>
                <%--<tr>
                    <td colspan="2">
                        <table>
                            <tr>
                                <th>Keyword</th>
                                <td>
                                    <asp:TextBox ID="txtKey" runat="server"></asp:TextBox>
                                </td>
                                <th>Date</th>
                                <td>
                                    <asp:TextBox ID="txtDate" runat="server"></asp:TextBox>
                                    <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtDate"
                                        Format="dd/MM/yyyy">
                                    </ajaxToolkit:CalendarExtender>
                                </td>
                                <td>
                                    <asp:Button id="btnSearch" Text="Search" runat="server" OnClick="btnSearch_Click"/>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <% 
                    while (enNot.MoveNext())
                    {
                        NoticePicker b = (NoticePicker)enNot.Current; 
                %>
                <tr style="color: #000000">
                    <td width="22" style="height: 18px"></td>
                    <td align="left" style="height: 18px" valign="bottom">
                        <strong><span style="color: #ff3333">
                            <%= b.newsDate  %> &nbsp;-&nbsp;<%= b.newsHeading %><br />
                        </span></strong><%= b.newsDesc %>
                        <a href="ViewNoticeCircular.aspx?newsid=<%= b.newsID  %>" style="text-decoration: none">
                            <span style="color: #ff3333">(more...)</span>
                        </a>

                    </td>
                    <td width="23" style="height: 18px"></td>
                </tr>
                <tr style="color: #000000">
                    <td style="height: 48px" width="22" valign="bottom"></td>
                    <td align="left" style="height: 48px; padding-top: 10px;" valign="top">
                        <%

                                 if (b.dwfilename.Trim() == "".Trim())
                                 {

                        %>

                        <a href="#1">
                            <img border="0" id="img3" src="images/button1.jpg" height="17" width="75" alt="Download" fp-style="fp-btn: Embossed Capsule 3; fp-font-size: 8; fp-proportional: 0" fp-title="Download" onmouseover="FP_swapImg(1,0,/*id*/'img<%= dwid %>',/*url*/'images/button2.jpg')" onmouseout="FP_swapImg(0,0,/*id*/'img<%= dwid %>',/*url*/'images/button1.jpg')" onmousedown="FP_swapImg(1,0,/*id*/'img<%= dwid %>',/*url*/'images/button3.jpg')" onmouseup="FP_swapImg(0,0,/*id*/'img<%= dwid %>',/*url*/'images/button2.jpg')"></a>



                        <%
                            
                                }
                                else
                                {
                            
                        %>
                        <a href="<%= b.dwfilename %>" target="_blank">
                            <img border="0" id="img4" src="images/button1.jpg" height="17" width="75" alt="Download" fp-style="fp-btn: Embossed Capsule 3; fp-font-size: 8; fp-proportional: 0" fp-title="Download" onmouseover="FP_swapImg(1,0,/*id*/'img<%= dwid %>',/*url*/'images/button2.jpg')" onmouseout="FP_swapImg(0,0,/*id*/'img<%= dwid %>',/*url*/'images/button1.jpg')" onmousedown="FP_swapImg(1,0,/*id*/'img<%= dwid %>',/*url*/'images/button3.jpg')" onmouseup="FP_swapImg(0,0,/*id*/'img<%= dwid %>',/*url*/'images/button2.jpg')"></a>

                        <%
                             
                                }
                        %>
                            &nbsp;   
                                                         
                       
                    </td>

                    <td style="height: 48px" width="23" valign="bottom"></td>
                </tr>
                <%
                
                                dwid = dwid + 1;

                             }
                %>

                <tr style="color: #000000">
                    <td width="22">&nbsp;</td>
                    <td>&nbsp;</td>
                    <td width="23">&nbsp;</td>
                </tr>
            </table>--%>
        </div>
    </div>
</asp:Content>

