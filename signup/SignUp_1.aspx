<%@ Page Language="C#" MasterPageFile="~/MasterPages/Login.master" AutoEventWireup="true"
    CodeFile="SignUp_1.aspx.cs" Inherits="signup_SignUp_1" Title="Sign Up" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
<script language="javascript" type="text/javascript">
function SetUrls()
{
var link = GetUrl(1);
document.getElementById("linkLogin1").href = link;
link = GetUrl(3);
document.getElementById("linkSignUp1").href = link;
}
</script>
    <table>
        <tr>
            <td class="headerMedium" style="font-weight: bold">
                Do you remember your Employee Code? 
            </td>
        </tr>
        <tr>
            <td style="height: 10px">
            </td>
        </tr>
        <tr>
            <td>
                If you have got you Employee Code in the format, the format is ##@@@ where # represent
                character and @ some digit.
            </td>
        </tr>
        <tr>
            <td>
                Use the digits, this will form your Login Id.</td>
        </tr>
        <tr>
            <td>
                If you have forgoten your Employee Code. Contact the HR Department for for the same.</td>
        </tr>
        <tr>
            <td>
                <table>
                    <tr>
                        <td style="padding-left:20px; padding-top:30px"><a href="javascript:void(0)" id="linkSignUp1">Continue</a>
                        </td>
                       <td style="padding-left:20px; padding-top:30px"><a href="javascript:void(0)" id="linkLogin1"> Cancel</a></td> 
                    </tr>
                </table>
                
            </td>
        </tr>
    </table>
</asp:Content>
