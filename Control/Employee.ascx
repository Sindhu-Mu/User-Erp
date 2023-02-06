<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Employee.ascx.cs" Inherits="Control_Employee" %>

<link rel="stylesheet" type="text/css" href="../css/Profiles.css" />

<div id="div1" class="main-div-2" runat="server">


    <div class="left-area">
        #<asp:Label ID="lblCode" runat="server" style="font-weight: 700"></asp:Label><br />
        <img id="imgPicture" runat="server" alt="Image" src="../images/emp_images/empImage.jpg" style="width: 120px; height: 120px" />
        <br />
        <asp:Label ID="lblStatus" runat="server" style="font-weight: 700"></asp:Label><br />
        <asp:Label ID="lblRlvngDate" runat="server"></asp:Label>



    </div>
    <div class="right-area">
        &nbsp;<asp:Label ID="lblName" runat="server" Font-Size="18px" Font-Names="Trebuchet MS" Font-Italic="true"></asp:Label>
        <hr  />
        Father's Name:-<asp:Label ID="lblFatherName" runat="server" CssClass="label-detail"></asp:Label>&nbsp;,DOB:-<asp:Label ID="lblDob" runat="server" CssClass="label-detail"></asp:Label>
        <%--Age:-<asp:Label ID="Label1" runat="server" CssClass="label-detail"></asp:Label>--%>
        <br />
        <asp:Label ID="lblAddress" runat="server" CssClass="label-detail"></asp:Label>
        <hr  />
        Working As :-<asp:Label ID="lblDesg" runat="server" CssClass="label-detail"></asp:Label>
        &nbsp;from 
                    <asp:Label ID="lblDoj" runat="server" CssClass="label-detail"></asp:Label>
        &nbsp;at 
                    <asp:Label ID="lblDepartment" runat="server" CssClass="label-detail"></asp:Label>,<asp:Label ID="lblInstitute" runat="server" CssClass="label-detail"></asp:Label>
        &nbsp;<br />
        under supervision of
                    <asp:Label ID="lblNextS" runat="server" CssClass="label-detail"></asp:Label>
        <hr />
        Mobile No:-
            <asp:Label ID="lblMobile" runat="server" CssClass="label-detail"></asp:Label>
        &nbsp;and Email-ID:-<asp:Label ID="lblEmail" runat="server" CssClass="label-detail"></asp:Label>

    </div>

</div>

