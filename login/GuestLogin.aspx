<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Login.master" AutoEventWireup="true" CodeFile="GuestLogin.aspx.cs" Inherits="login_GuestLogin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
        <script language="javascript" type="text/javascript">
            function CheckControl(ctrl) {
                if (bTrim(document.getElementById(ctrl).value) == "" || bTrim(document.getElementById(ctrl).value) == ".") {
                    document.getElementById(ctrl).style.backgroundColor = "#fc6";
                    return false;
                }
                else
                    document.getElementById(ctrl).style.backgroundColor = "#fff";
                return true;
            }
            function validation() {

                var flag = true;
                var msg = "", ctrl = "";
                if (!CheckControl("<%=txtLoginId.ClientID%>")) {
                msg += " * Enter your Login id.\n";
                if (ctrl == "")
                    ctrl = "<%=txtLoginId.ClientID%>";
                flag = false;
            }
            if (!CheckControl("<%=txtPassword.ClientID%>")) {
                msg += " * Enter your password.\n";
                if (ctrl == "")
                    ctrl = "<%=txtPassword.ClientID%>";
                flag = false;
            }
            if (msg != "") alert(msg);
            if (ctrl != "")
                document.getElementById(ctrl).focus();
            return flag;
        }
    </script>
    <div>
        <asp:XmlDataSource ID="XmlDataSource1" runat="server" DataFile="~/App_Data/usage.xml"
            XPath="root/id"></asp:XmlDataSource>
        <asp:XmlDataSource ID="XmlDataSource2" runat="server" DataFile="~/App_Data/services.xml"
            XPath="root/id"></asp:XmlDataSource>
    </div>
    <table style="width: 100%;">
        <thead>
            <tr>

                <td style="width: 35%"></td>
                <td style="width: 35%"></td>
                <td style="width: 6%;"></td>
            </tr>
        </thead>
        <tr>
            <td>
                <div class="headerBig">
                    account allows you to..
                </div>
            </td>
            <td style="text-align: left">
                <div class="headerBig">
                    sign in to continue
                </div>
            </td>
        </tr>
        <tr>
            <td>
                <table style="margin-left: 10px;">
                    <tr>
                        <td>
                            <asp:Repeater runat="server" ID="rp1" DataSourceID="XmlDataSource1">
                                <ItemTemplate>
                                    <table>
                                        <tr>
                                            <td style="height: 20px"></td>
                                            <td></td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <img src=" <%#XPath("@image")%>" alt="" />
                                            </td>
                                            <td>
                                                <div class="headerSmall">
                                                    <%#XPath("header")%>
                                                </div>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td></td>
                                            <td class="descSmall">
                                                <%#XPath("desc")%>
                                                <br />
                                            </td>
                                        </tr>
                                    </table>
                                </ItemTemplate>
                            </asp:Repeater>
                        </td>
                    </tr>
                    <tr>
                        <td>&nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td class="headerMediumBlue">
                            &nbsp;</td>
                    </tr>
                     <tr>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                </table>
            </td>
            <td style="vertical-align: top">
                <table style="margin-left: 10px;">
                    <tr>
                        <td style="height: 20px"></td>
                    </tr>
                    <tr>
                        <td class="blur">Login Id:
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:TextBox ID="txtLoginId" runat="server" Width="233px"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td style="height: 15px"></td>
                    </tr>
                    <tr>
                        <td class="blur">Password:
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:TextBox ID="txtPassword" TextMode="Password" runat="server" Width="233px"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td style="height: 15px"></td>
                    </tr>

                    <tr>
                        <td style="text-align: right">
                            <asp:Button ID="btnLogin" runat="server" Text="Sign In" OnClick="btnLogin_Click" />
                        </td>
                    </tr>

                    <tr>
                        <td>
                            <a href="javascript:void(0)" id="resetLink">Can't access your account?</a></td>
                    </tr>
                    <tr>
                        <td style="height: 15px"></td>
                    </tr>
                    <tr>
                        <td class="headerMediumBlue">
                            <a href="../Common/ContactUs.html" class="aBlack" target="_blank" >Click Here for Help!!</a>
                        </td>
                    </tr>
                     <tr>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                </table>
            </td>
        </tr>


    </table>
</asp:Content>

