<%@ Control Language="C#" AutoEventWireup="true" CodeFile="menu.ascx.cs" Inherits="control_menu" EnableViewState="true" %>
<link href="../css/menu.css" rel="stylesheet" />
<script type="text/javascript">
    function menuSize() {
        var mydiv = document.getElementById("ul_test");
        var curr_width = mydiv.style.width;
        // now add 10 to the width
        alert("ul" + curr_width);
        mydiv.style.width = curr_width + 10;
    }
    </script>
<asp:XmlDataSource ID="XmlDataSource1" runat="server"
    XPath="DATA/PAGE_HEAD_INF"></asp:XmlDataSource>
 <div id='cssmenu' runat="server" CliendIDMode="static">
 </div>
