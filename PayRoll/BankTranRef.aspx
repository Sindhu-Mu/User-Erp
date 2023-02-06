<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Short.master" AutoEventWireup="true" CodeFile="BankTranRef.aspx.cs" Inherits="PayRoll_BankTranRef" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentHolder1" Runat="Server">
    <div class="container">
    <div class="heading"><h2>Salary Transfer Reference</h2></div>
    <div id="bodyCenter" >
        <br/>
        <table align="center">
            <tr>
                <th>
                Reference</th>
                <th>Cheque Number</th>
            </tr>
            <tr>
                <td><asp:DropDownList ID="ddlRefNo" runat="server"></asp:DropDownList></td>
                <td><cc1:NumericTextBox ID="txtChkNo" runat="server"></cc1:NumericTextBox></td>
                <td><asp:Button runat="server" Text="Update" ID="btnUpdate" /></td>


            </tr>
            
            </table>
        <br/>
    </div>
        </div>
</asp:Content>

