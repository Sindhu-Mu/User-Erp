<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/FullLength.master" AutoEventWireup="true" CodeFile="TodayBirthDay.aspx.cs" Inherits="Common_TodayBirthDay" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="container">
        <div class="heading">
            <h2>Todays Birthday</h2>
        </div>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <asp:DataList ID="DLBirthDay" runat="server" RepeatColumns="2" RepeatDirection="Horizontal">
                    <ItemTemplate>
                        <div style="float: left; width: 390px; height: 170px; background-image: url('../siteimages/list1.png'); background-repeat: no-repeat; background-position: left top">
                            <table width="100%" cellpadding="0" border="0" style="font-family: Arial; font-size: 12px; font-weight: bold; border-collapse: collapse">
                                <tr>
                                    <td colspan="3" style="padding-left: 3px; color: #FFF;">#<%# Eval("EMP_ID")%>-<%# Eval("EMP_NAME")%></td>

                                </tr>
                                <tr>
                                    <td style="width: 2%; height: 10px"></td>
                                    <td style="width: 98%; height: 10px"></td>

                                </tr>
                                <tr>
                                    <td style="width: 2%;"></td>
                                    <td width="98%">
                                        <table border="0" width="100%" cellpadding="0" style="border-collapse: collapse">
                                            <tr>
                                                <td width="76px" valign="top" style="padding-top: 3px">
                                                    <img border="0" src='<%# Eval("IMG")%>' style="border: 1px solid #000000; width: 78px; height: 100px; padding: 0" id="imgPhoto" runat="server" alt='<%# Eval("EMP_NAME")%>' /></td>
                                                <td style="width: 3px">&nbsp;</td>
                                                <td valign="top">
                                                    <table style="font-size: 11px;">

                                                           <tr>
                                                            <th>Institute</th>
                                                            <td>:</td>
                                                            <td><%# Eval("INS_VALUE") %></td>
                                                        </tr>                                                       
                                                         <tr>
                                                            <th>Department</th>
                                                            <td>:</td>
                                                            <td><%# Eval("DEPT_VALUE") %></td>
                                                        </tr>
                                                        <tr>
                                                            <th>Designation</th>
                                                            <td>:</td>
                                                            <td><%# Eval("DES_VALUE") %></td>
                                                        </tr>
                                                        
                                                        <tr>
                                                            <th>Mobile</th>
                                                            <td>:</td>
                                                            <td><%# Eval("PHONE") %></td>
                                                        </tr>
                                                        <tr>
                                                            <th>Email</th>
                                                            <td>:</td>
                                                            <td style="font-size:10px;"><%# Eval( "EMAIL") %></td>
                                                        </tr>
                                                       
                                                    </table>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>

                                </tr>
                            </table>
                        </div>
                    </ItemTemplate>
                </asp:DataList>

            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</asp:Content>

