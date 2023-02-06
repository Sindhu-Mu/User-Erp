<%@ Page Language="C#" MasterPageFile="~/MasterPages/Login.master" AutoEventWireup="true"
    CodeFile="SignUp_2.aspx.cs" Inherits="signup_SignUp_2" Title="Sign Up" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script language="javascript" type="text/javascript">
        function SetUrls() {
            link = GetUrl(1);

            document.getElementById("linkLogin1").href = link;
        }
    </script>
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
            if (!CheckControl("<%=txtTocken.ClientID%>")) {
                msg += " * Enter your Token No.\n";
                if (ctrl == "")
                    ctrl = "<%=txtTocken.ClientID%>";
                flag = false;
            }
            if (!CheckControl("<%=txtLoginId.ClientID%>")) {
                msg += " * Enter your Login Id.\n";
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
            if (document.getElementById("<%=txtPassword.ClientID%>").length<7)
            {
                msg += " * Length of your password is less then 6.\n";
                if (ctrl == "")
                    ctrl = "<%=txtPassword.ClientID%>";
                flag = false;
            }
            if (document.getElementById("<%=txtRePassword.ClientID%>").length < 7) {
                msg += " * Length of your Re-password is less then 6.\n";
                if (ctrl == "")
                    ctrl = "<%=txtRePassword.ClientID%>";
                flag = false;
            }
            if (!CheckControl("<%=txtRePassword.ClientID%>")) {
                msg += " * Enter your Re-password.\n";
                if (ctrl == "")
                    ctrl = "<%=txtRePassword.ClientID%>";
                flag = false;
            }
            
            if (!CheckControl("<%=ddlQuestion.ClientID%>")) {
                msg += " * Select Question from list.\n";
                if (ctrl == "")
                    ctrl = "<%=ddlQuestion.ClientID%>";
                flag = false;
            }
            if (!CheckControl("<%=txtAnswer.ClientID%>")) {
                msg += " * Enter your answer.\n";
                if (ctrl == "")
                    ctrl = "<%=txtAnswer.ClientID%>";
                flag = false;
            }
            if (document.getElementById("<%=txtCaptcha.ClientID%>").value != document.getElementById("<%=lblCaptcha.ClientID%>").value)
            {
                this.location.reload();
            }
            if (msg != "") alert(msg);
            if (ctrl != "")
                document.getElementById(ctrl).focus();
            return flag;
        }
    </script>
    <table>
        <tr>
            <td class="headerMedium" style="font-weight: bold">Create credentials
            </td>
        </tr>
        <tr>
            <td>Enter your Employee Code and password to access your account. Choose a question
                and secret answer to help you reset your password if you forget it.
            </td>
        </tr>
        <tr>
            <td>
                <hr class="hrthick" />
            </td>
        </tr>
        <tr>
            <td style="font-style: italic">Create your Login Id and password
            </td>
        </tr>
        <tr>
            <td>
                <table>
                    <thead>
                        <tr>
                            <td style="width: 50px"></td>
                            <td style="width: 100px"></td>
                            <td style="width: 100px"><asp:Label runat="server" ID="lblRegistrationStatus" ForeColor="#FF3300"></asp:Label></td>
                        </tr>
                    </thead>
                    <tr>
                        <td>&nbsp;</td>
                        <td class="headerSmall" style="text-align: right">Token No</td>
                        <td>
                            <asp:TextBox ID="txtTocken" runat="server" Width="233px" ForeColor="Gray" ></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td></td>
                        <td class="headerSmall" style="text-align: right">Login Id:</td>
                        <td>
                            <asp:TextBox ID="txtLoginId" runat="server" Width="233px" ForeColor="Gray" ></asp:TextBox></td>
                    </tr>

                    <tr>
                        <td></td>
                        <td class="headerSmall" style="text-align: right">Password:</td>
                        <td>
                            <asp:TextBox ID="txtPassword" TextMode="Password" runat="server" Width="233px" MaxLength="10"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td></td>
                        <td></td>
                        <td class="blurdesc">Six-character minimum with no spaces
                        </td>
                    </tr>
                    <tr>
                        <td></td>
                        <td></td>
                        <td class="blurdesc">
                            <a href="http://windows.microsoft.com/en-US/windows-live/id-help-center" target="_blank">Learn how to create a strong, memorable password.</a></td>
                    </tr>
                    <tr>
                        <td></td>
                        <td style="text-align: right" class="headerSmall">Retype password:</td>
                        <td>
                            <asp:TextBox ID="txtRePassword" TextMode="Password" runat="server" Width="233px"
                                MaxLength="10"></asp:TextBox>
                            <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="Passwords do not match"
                                ControlToCompare="txtPassword" ControlToValidate="txtRePassword" EnableClientScript="true"
                                Display="Static" CssClass="blurdesc" ForeColor="gray"></asp:CompareValidator></td>
                    </tr>
                    <tr>
                        <td style="height: 15px">
                            <ajaxToolkit:PasswordStrength ID="PasswordStrength2" runat="server" TargetControlID="txtPassword"
                                RequiresUpperAndLowerCaseCharacters="false" MinimumNumericCharacters="1" MinimumSymbolCharacters="1"
                                MinimumUpperCaseCharacters="1" PreferredPasswordLength="6" DisplayPosition="RightSide"
                                PrefixText="Strength" StrengthIndicatorType="BarIndicator" BarBorderCssClass="BarBorder"
                                StrengthStyles="BarIndicatorweak;BarIndicatoraverage;BarIndicatorgood;">
                            </ajaxToolkit:PasswordStrength>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td>
                <hr />
            </td>
        </tr>
        <tr>
            <td style="font-style: italic">Create your password reset option
            </td>
        </tr>
        <tr>
            <td class="descSmall" style="padding-left: 10px">If you forget your password, you can provide the secret answer to reset it. <a target="_blank"
                href="http://windows.microsoft.com/en-US/windows-live/id-help-center">Learn more
                    about resetting your password</a></td>
        </tr>
        <tr>
            <td>
                <table>
                    <thead>
                        <tr>
                            <td style="width: 50px"></td>
                            <td style="width: 100px"></td>
                        </tr>
                    </thead>
                    <tr>
                        <td></td>
                        <td class="headerSmall" style="text-align: right">Question:</td>
                        <td>
                            <asp:DropDownList runat="server" ID="ddlQuestion" Width="233px">
                            </asp:DropDownList></td>
                    </tr>
                    <tr>
                        <td></td>
                        <td class="headerSmall" style="text-align: right">Secret Answer:</td>
                        <td>
                            <asp:TextBox ID="txtAnswer" runat="server" Width="233px"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td></td>
                        <td></td>
                      
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td>
                <hr />
            </td>
        </tr>
        <tr>
            <td style="font-style: italic">Verification
            </td>
        </tr>
        <tr>
            <td>
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <table>
                            <thead>
                                <tr>
                                    <td style="width: 50px"></td>
                                    <td style="width: 100px"></td>
                                    <td style="width: 70px"></td>
                                </tr>
                            </thead>
                            <tr>
                                <td></td>
                                <td></td>
                                <td>Enter the characters you see
                                </td>
                                <td>
                                    <asp:Button ID="btnNew" runat="server" Text="New" Font-Size="14px" CssClass="buttonlink"
                                        OnClick="btnNew_Click" />
                                </td>
                            </tr>
                            <tr>
                                <td></td>
                                <td></td>
                                <td>
                                    <div style="height: 50px; padding-top: 5px; padding-bottom: 15px">
                                        <asp:Label ID="lblCaptcha" runat="server" Width="200px"></asp:Label>
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <td></td>
                                <td></td>
                                <td colspan="2">
                                    <asp:TextBox ID="txtCaptcha" runat="server" Width="233px" CssClass="txtGroove"></asp:TextBox></td>
                            </tr>
                        </table>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td>
                <hr class="hrthick" />
            </td>
        </tr>
        <tr>
            <td style="height: 50px; vertical-align: bottom" align="right">
                <table>
                    <tr>
                        <td>
                            <asp:Button ID="btnNext" runat="server" Text="Next" OnClick="btnNext_Click" />
                        </td>
                        <td>
                            <a href="javascript:void(0)" id="linkLogin1">Cancel</a></td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>
