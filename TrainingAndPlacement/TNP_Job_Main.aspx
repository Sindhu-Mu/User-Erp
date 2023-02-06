<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/FullLength.master" AutoEventWireup="true" CodeFile="TNP_Job_Main.aspx.cs" Inherits="TrainingAndPlacement_TNP_Job_Main" %>

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



             if (!CheckControl("<%=ddlcompname.ClientID%>")) {
                 msg += "- Please Select Company \n";
                 if (ctrl == "")
                     ctrl = "<%=ddlcompname.ClientID%>";
                flag = false;
            }

            if (!CheckControl("<%=txtprofile.ClientID%>")) {
                 msg += "- Please Enter Job Profile \n";
                 if (ctrl == "")
                     ctrl = "<%=txtprofile.ClientID%>";
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
            <h2>Job Main</h2>
        </div>
        <hr />
        <table>
            <tr>
                <th>Company Name</th>
                <td>
                    <asp:DropDownList ID="ddlcompname" runat="server" AutoPostBack="false" Width="130"></asp:DropDownList>
                </td>
            </tr>
            <tr>
                
                <th>Job Profile</th>
                <td>
                    <asp:TextBox ID="txtprofile" runat="server" Width="130"></asp:TextBox>
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

