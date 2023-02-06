<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Student.ascx.cs" Inherits="Control_Student" %>
<link rel="stylesheet" type="text/css" href="../css/Profiles.css" />

<div id="div1" class="main-div-stu" runat="server">


    <div class="left-area">
        #<asp:Label ID="lblEnrollment" runat="server" Style="font-weight: 700"></asp:Label><br />
        <img id="imgPicture" runat="server" alt="Image" src="~/images/Stuimages/" style="width: 120px; height: 120px" />
        <br />
        <asp:Label ID="lblStatus" runat="server" Style="font-weight: 700"></asp:Label><br />
    </div>
    <div class="right-area">
        &nbsp;<asp:Label ID="lblName" runat="server" Font-Size="18px" Font-Names="Trebuchet MS" Font-Italic="true"></asp:Label>
        <hr />
        Father's Name:-<asp:Label ID="lblFatherName" runat="server" CssClass="label-detail"></asp:Label>&nbsp;,Mother's Name:-<asp:Label ID="lblMotherName" runat="server" CssClass="label-detail"></asp:Label>&nbsp;DOB:-<asp:Label ID="lblDob" runat="server" CssClass="label-detail"></asp:Label>
        <br />
        <asp:Label ID="lblAddress" runat="server" CssClass="label-detail"></asp:Label>
        <hr />
    
        Programme :-<asp:Label ID="lblCourse" runat="server" CssClass="label-detail"></asp:Label>
        (<asp:Label ID="lblBranch" runat="server" CssClass="label-detail"></asp:Label>)&nbsp; Semester :-&nbsp;<asp:Label ID="lblSem" runat="server" CssClass="label-detail"></asp:Label>
        &nbsp;Section:-<asp:Label ID="lblSection" runat="server" CssClass="label-detail"></asp:Label>&nbsp;Batch:-<asp:Label ID="lblBatch" runat="server" CssClass="label-detail"></asp:Label>
        Institute:- 
        <asp:Label ID="lblInstitute" runat="server" CssClass="label-detail"></asp:Label>
        <hr />
        Mobile No:-
            <asp:Label ID="lblMobile" runat="server" CssClass="label-detail"></asp:Label>
        &nbsp;and Email-ID:-<asp:Label ID="lblEmail" runat="server" CssClass="label-detail"></asp:Label>
         <hr /> Admission Type is -<asp:Label ID="lblAdmType" runat="server" ForeColor="Red" Font-Size="18px" Font-Names="Trebuchet MS" Font-Italic="true"> </asp:Label>
    </div>

</div>
