<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/FullLength.master" AutoEventWireup="true" CodeFile="SectionChange.aspx.cs" Inherits="Academic_SectionChange" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <script lang="javascript" type="text/javascript">
        function CheckControl(ctrl) {
            if (bTrim(document.getElementById(ctrl).value) == "" || bTrim(document.getElementById(ctrl).value) == "Select" || bTrim(document.getElementById(ctrl).value) == ".") {
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
            if (!CheckControl("<%=ddlInstitution.ClientID%>")) {
                msg += "- Select Institute from list\n";
                if (ctrl == "")
                    ctrl = "<%=ddlInstitution.ClientID%>";
                flag = false;
            }
            if (!CheckControl("<%=ddlCourse.ClientID%>")) {
                msg += "- Select Program from list\n";
                if (ctrl == "")
                    ctrl = "<%=ddlCourse.ClientID%>";
                flag = false;
            }
            if (!CheckControl("<%=ddlBranch.ClientID%>")) {
                msg += "- Select Branch from list\n";
                if (ctrl == "")
                    ctrl = "<%=ddlBranch.ClientID%>";
                flag = false;
            }
            if (!CheckControl("<%=ddlSemester.ClientID%>")) {
                msg += "- Select Semester from list\n";
                if (ctrl == "")
                    ctrl = "<%=ddlSemester.ClientID%>";
                flag = false;
            }
            if (!CheckControl("<%=ddlSection.ClientID%>")) {
                msg += "- Select Section from list\n";
                if (ctrl == "")
                    ctrl = "<%=ddlSection.ClientID%>";
                flag = false;
            }
           

            if (msg != "") alert(msg);
            if (ctrl != "")
                document.getElementById(ctrl).focus();
            return flag;
        }

        function validation1() {

            var flag = true;
            var msg = "", ctrl = "";
            if (!CheckControl("<%=ddltosection.ClientID%>")) {
                msg += "- Select To Section from list\n";
                if (ctrl == "")
                    ctrl = "<%=ddltosection.ClientID%>";
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
            <h2>Section Change</h2>
        </div>
         <div>
    <table style="width: 90%; margin: 20px;">
            <tr>
                <th colspan="1">Institution<span class="required">*</span></th>
                <td>&nbsp;</td>
                <th>Course<span class="required">*</span></th>
                <td>&nbsp;</td>
                <th>Branch<span class="required">*</span></th>
                 <td>&nbsp;</td>
                <th>Semester<span class="required">*</span></th>
               
                <th>Section<span class="required">*</span></th>
                             
            </tr>
            <tr>
                <td style="vertical-align: top">
                    <asp:DropDownList ID="ddlInstitution" runat="server" Width="107px" OnSelectedIndexChanged="ddlInstitution_SelectedIndexChanged"
                        AutoPostBack="True">
                    </asp:DropDownList></td>
                <td>&nbsp;</td>
                <td>
                    <asp:DropDownList ID="ddlCourse" runat="server" Width="190px" OnSelectedIndexChanged="ddlCourse_SelectedIndexChanged"
                        AutoPostBack="True">
                    </asp:DropDownList></td>
                <td>&nbsp;</td>
                <td>
                    <asp:DropDownList ID="ddlBranch" runat="server" Width="173px">
                    </asp:DropDownList></td>
                <td>&nbsp;</td>

                <td style="vertical-align: top">
                    <asp:DropDownList ID="ddlSemester" runat="server" Width="100px">
                    </asp:DropDownList></td>
               
                <td><asp:DropDownList ID="ddlSection" runat="server" Width="100px">
                    <asp:ListItem Value="0">All</asp:ListItem>
                    <asp:ListItem Value="1">A</asp:ListItem>
                    <asp:ListItem Value="2">B</asp:ListItem>
                    <asp:ListItem Value="3">C</asp:ListItem>
                    <asp:ListItem Value="4">D</asp:ListItem>
                    </asp:DropDownList></td>

                <td>
                   
                   <asp:Button Text="Show" runat="server" ID="show" OnClick="show_Click" />
                 </td>
                   
            </tr>

        </table>
         </div>
    <div id="body_c" style="text-align: center; margin: 20px">
        <asp:GridView runat="server" ID="gvshow" Width="90%" AutoGenerateColumns="False" DataKeyNames="STU_MAIN_ID" CssClass="gridDynamic">
            <Columns>
                <asp:TemplateField HeaderText="S.No.">
                    <ItemTemplate>
                        <%# ((GridViewRow)Container).RowIndex + 1%>
                    </ItemTemplate>
                    <ItemStyle Width="20px" />
                </asp:TemplateField>
                <asp:BoundField DataField="ENROLLMENT_NO" HeaderText="Enrollment No" />
                <asp:BoundField DataField="STU_FULL_NAME" HeaderText="Name" />
                <asp:BoundField DataField="ACA_SEC_NAME" HeaderText="Section" />
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:CheckBox runat="server" ID="chkSelect" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>

        </asp:GridView>
    </div>
    <div>
        <table style="margin: 20px;">
            <tr>
                <th>To Section<span class="required">*</span></th>
               <th>Remark</th>
            </tr>
            <tr>
                 <td><asp:DropDownList ID="ddltosection" runat="server" Width="100px">
                    </asp:DropDownList></td>

                <td>
                    <asp:TextBox ID="txtRemark" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                 <td>
                   
                   <asp:Button Text="Save" runat="server" ID="btnSave" OnClick="btnSave_Click" />
                 </td>
                <td>
                     <asp:TextBox ID="txtxml" runat="server" Visible="false"></asp:TextBox>
                </td>
            </tr>
        </table>
    </div>
         </div>
</asp:Content>

