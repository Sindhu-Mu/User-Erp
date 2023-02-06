<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/FullLength.master" AutoEventWireup="true" CodeFile="TNP_Comp_Profile_Main.aspx.cs" Inherits="TrainingAndPlacement_TNP_Comp_Profile_Main" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <script lang="javascript" type="text/javascript">
         function CheckControl(ctrl) {
             if (bTrim(document.getElementById(ctrl).value) == "" || bTrim(document.getElementById(ctrl).value) == "-1") {
                 document.getElementById(ctrl).style.backgroundColor = "#fc6";
                 return false;
             }
             else
                 document.getElementById(ctrl).style.backgroundColor = "#fff";
             return true;
         }
         function validation() {

             var flag = true;
             var msg = "", ctrl = "";

           

             
            if (!CheckControl("<%=txtcompprofile.ClientID%>")) {
                msg += "- Please Enter Company Profile \n";
                if (ctrl == "")
                    ctrl = "<%=txtcompprofile.ClientID%>";
                flag = false;
            }

                               
           
            if (msg != "") alert(msg);
            if (ctrl != "")
                document.getElementById(ctrl).focus();
            return flag;
         }
          </script>
     <div class="container">
         <div class="heading">
            <h2>Company Profile Main</h2>
        </div>
        <hr />
        <table>
            
            <tr> 
                <th>Company Profile</th>
                <td>
                    <asp:TextBox ID="txtcompprofile" runat="server"></asp:TextBox>
                </td>
               
            </tr>
            <tr>
                <td>
                    <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click"/>
                </td>
            </tr>
            </table>
            </div>
</asp:Content>

