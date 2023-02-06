<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/FullLength.master" AutoEventWireup="true" CodeFile="UploadSalarySlip.aspx.cs" Inherits="PayRoll_UploadSalarySlip" %>

<%@ Register Src="~/Control/MonthYear.ascx" TagPrefix="uc1" TagName="MonthYear" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="content">
        <div id="heading" class="heading">
            <h2>Upload Salary Slip</h2>
        </div>

        <div id="bodyContent">
            <table>
                <tr>
                    <th>Month/Year</th>
                    <td>&nbsp;</td>
                    <th>File</th>
                    <td>&nbsp;</td>
                    </tr>
              <tr>
                  <td>
                      <uc1:MonthYear runat="server" ID="MonthYear" />
                  </td>
                  <td>&nbsp;</td>
                  <td>
                      <asp:FileUpload ID="upd1" runat="server" Width="267px" /></td>
                  <td>&nbsp;</td>
                  <td>
                      <asp:Button ID="btnUpload" runat="server" CssClass="btnCall" Text="Upload" OnClick="btnUpload_Click"
                          Font-Overline="False" Width="80px"></asp:Button></td>
              </tr>
            </table>
        </div>
        <div>
            <a style="font-size:20px;color:blue;" href="../Common/SalaryTemplate.xls"><u>Download Salary Template</u></a>
        </div>
    </div>
</asp:Content>

