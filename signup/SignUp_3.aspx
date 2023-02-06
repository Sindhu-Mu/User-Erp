<%@ Page Language="C#" MasterPageFile="~/MasterPages/Login.master" AutoEventWireup="true"
    CodeFile="SignUp_3.aspx.cs" Inherits="signup_SignUp_3" Title="Sign Up" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script language="javascript" type="text/javascript">
function AutoRedirect(sessionTimeout1)
{ 
    var sessionTimeout =  sessionTimeout1;
    if (sessionTimeout >= 0)
    {
        document.getElementById("lblSec").innerHTML = sessionTimeout/1000;
           sessionTimeout = sessionTimeout - 1000;  
        setTimeout("AutoRedirect("+sessionTimeout+");",1000);
   
    }
    else
    {
        window.location.href="../Login.aspx";
    }
}
    </script>

    <table>
        <tr>
            <td class="headerMedium" style="font-weight: bold; color: Green">
                Congrats, your account is succesfully created?
            </td>
        </tr>
        <tr>
            <td style="height: 30px">
            </td>
        </tr>
        <tr>
            <td>
                To review the Code of conduct <a href="../aggrement/Code of conduct.htm" target="_blank">
                    click here</a>
            </td>
        </tr>
        <tr>
            <td>
                Invidual rights hold as per the authority</td>
        </tr>
        <tr>
            <td style="height: 30px">
            </td>
        </tr>
        <tr>
            <td>
                You will be automatically redirected to <a href="../Login.aspx">Login Page</a> in
                <label id="lblSec">
                    30</label>
                sec.</td>
        </tr>
        <tr>
            <td style="height: 30px">
            </td>
        </tr>
        <tr>
            <td>
                Thanks & Regards</td>
        </tr>
    </table>
</asp:Content>
