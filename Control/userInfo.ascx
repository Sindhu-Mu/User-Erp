<%@ Control Language="C#" AutoEventWireup="true" CodeFile="userInfo.ascx.cs" Inherits="control_userInfo" %>
<%@ OutputCache VaryByParam="id" Duration="36000" Shared="true" %>
<%-- <img src="../images/emp/928.png" style="width: 110px; height: 100px;" alt="image" />--%>
<table style="width: 100%">
    <tr>
        <td>
            <a href="../user/MyProfile.aspx">
                <img src="../images/emp/928.png" style="width: 110px; height: 100px;" alt="image" /></a>
        </td>
        <td>
            <table style="text-align: left;">
                <tr>
                    <th style="text-align: left">
                        Code:</th>
                    <td style="text-align: left">
                        928</td>
                </tr>
                <tr>
                    <th style="text-align: left">
                        Name:</th>
                    <td style="text-align: left">
                        Rishab Sharma</td>
                </tr>
                <tr>
                    <th style="text-align: left">
                        DOJ:
                    </th>
                    <td style="text-align: left">
                        24/09/2012
                    </td>
                </tr>
                <tr>
                    <th style="text-align: left">
                        Mail:
                    </th>
                    <td>
                        <asp:HyperLink ID="linkMailInbox" runat="server" CssClass="aBlack" NavigateUrl="javascript:void(0)" Text=" Inbox" Target="_blank"></asp:HyperLink>&nbsp;|&nbsp;
                        <asp:HyperLink ID="linkMailCompose" runat="server" CssClass="aBlack" NavigateUrl="javascript:void(0)" Text=" Compose"></asp:HyperLink> 
                    </td>
                    
                </tr>
            </table>
        </td>
    </tr>
</table>
