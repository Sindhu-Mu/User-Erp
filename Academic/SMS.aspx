<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/FullLength.master" AutoEventWireup="true" CodeFile="SMS.aspx.cs" Inherits="Academic_SMS" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <div class="container">
        <div class="heading">
            <h2>SMS</h2>
        </div>
    <div>

    <table>

    <tr>
        <th>SMS Text:</th>
        <td>
    <asp:TextBox ID="txtSMS" runat="server" ></asp:TextBox></td>
 
   
        </tr>

        <tr>
            <th>Phone No:</th>
             <td>  <asp:TextBox ID="txtPhn" runat="server" TextMode="MultiLine"></asp:TextBox></td>
        </tr>
        <tr>
             <td><asp:Button ID="btnSMS" Text="SEND SMS" runat="server" OnClick="btnSMS_Click" /></td>
        </tr>
        </table>
        </div>
         </div>

</asp:Content>

