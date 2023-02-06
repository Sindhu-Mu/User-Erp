<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/FullLength.master" AutoEventWireup="true" CodeFile="CopyPics.aspx.cs" Inherits="Academic_CopyPics" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <table>
         <tr>
                <th>Picture</th>
                <td>
                     
                </td>
            </tr>
        <tr>
            <td>
                <asp:Button ID="btnSave" runat="server" Text="SavePics" OnClick="btnSave_Click" /></td>
        </tr>
    </table>
</asp:Content>

