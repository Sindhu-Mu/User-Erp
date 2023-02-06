<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/FullLength.master" AutoEventWireup="true" CodeFile="I_Card_Application.aspx.cs" Inherits="HR_I_Card_Application" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="container">
        <div class="heading">
            <h2>I-Card Details</h2>
        </div>
        <div>
            <table runat="server" style="border: 1px solid black">
                <tr>
                     <td>
                        <img id="imgEmp" runat="server" alt="Image" src="~/images/emp_images/empImage.jpg"
                            style="border: 1px solid #000000; height: 110px; width: 100px;" />
                    </td>
                </tr>
                  <tr>
                    <th>EMPLOYEE CODE</th>
                    <td>
                        <asp:Label ID="lblCode" runat="server"></asp:Label></td>

                </tr>
                <tr>
                    <th>NAME OF THE EMPLOYEE</th>
                    <td>
                        <asp:Label ID="lblname" runat="server"></asp:Label></td>
                   
                </tr>
                <tr>
                    <th>FATHER'S/HUSBAND'S NAME</th>
                    <td>
                        <asp:Label ID="lblfather" runat="server"></asp:Label></td>
                </tr>
                <tr>
                    <th>DESIGNATION</th>
                    <td>
                        <asp:Label ID="lbldesig" runat="server"></asp:Label></td>
                    </tr>
                <tr>
                    <th>DEPARTMENT</th>
                    <td>
                        <asp:Label ID="lbldepart" runat="server"></asp:Label></td></tr>
                    <tr><th>DATE OF JOINING</th>
                    <td>
                        <asp:Label ID="lblDOJ" runat="server"></asp:Label></td></tr>
                <tr> <th>DATE OF BIRTH</th>
                    <td>
                        <asp:Label ID="lblDOB" runat="server"></asp:Label></td></tr>
              
                <tr>
                   
                    <th>BLOOD GROUP</th>
                    <td>
                        <asp:Label ID="lblBlood" runat="server"></asp:Label></td>
                </tr>
                <tr>
                    <th>ADDRESS</th>
                    <td>
                        <asp:Label ID="lblAddress" runat="server"></asp:Label></td>
                </tr>
                <tr>
                    <th>CONTACT NO</th>
                    <td>
                        <asp:Label ID="lblContact" runat="server"></asp:Label></td>
                </tr>
                 <%--<tr>
                    <th>EMERGENCY CONTACT NO</th>
                    <td>
                        
                        <asp:TextBox ID="txtEmerConct" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator runat="server" id="reqName" controltovalidate="txtEmerConct" errormessage="Please enter emergency contact no." />
                    </td>
                </tr>--%>
                     <tr id="tr1" runat="server">
                    <th>UPLOAD PHOTO</th>
                    <td>
                        <asp:FileUpload ID="ImgUpload" runat="server" Width="249px" />
                        <span style="color: #f00; font-weight: bold;">.jpg Only</span> </td>
                </tr>
                <tr>
                    <td>
                        <asp:Button ID="btnSave" runat="server" Text="Apply" OnClick="btnSave_Click" ></asp:Button>

                    </td>
                </tr>
           
            </table>
        </div>
    </div>

</asp:Content>

