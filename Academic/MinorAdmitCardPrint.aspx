<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/MainPage.master" AutoEventWireup="true" CodeFile="MinorAdmitCardPrint.aspx.cs" Inherits="Academic_MinorAdmitCardPrint" %>

<%@ Register Src="~/Control/Student.ascx" TagPrefix="uc1" TagName="Student" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script language="javascript" type="text/javascript">
        function CheckControl(ctrl) {
            if (bTrim(document.getElementById(ctrl).value) == "" || bTrim(document.getElementById(ctrl).value) == ".") {
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
            if (!CheckControl("<%=ddlInstitute.ClientID%>")) {
                msg += " * Select institute from list. \n";
                if (ctrl == "")
                    ctrl = "<%=ddlInstitute.ClientID%>";
                flag = false;
            }
            if (!CheckControl("<%=ddlSem.ClientID%>")) {
                msg += " * Select Semester From list. \n";
                if (ctrl == "")
                    ctrl = "<%=ddlSem.ClientID%>";
                flag = false;
            }


            if (!CheckControl("<%=ddlStatus.ClientID%>")) {
                msg += " * Select Status from list.\n";
                if (ctrl == "")
                    ctrl = "<%=ddlStatus.ClientID%>";
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
            <h2>Minor Admit Card Print</h2>
        </div>
        <div>
            <table>
                <tr>
                    <th>Institute<span style="color: red">*</span></th>
                    <th>Program</th>
                    <th>Branch</th>
                    <th>Sem<span style="color: red">*</span></th>
                    <th>Status
                    <span style="color: red">*</span></th>
                     <th>Enrollment From</th>
                    <th>Enrollment To</th>
                </tr>
                <tr>
                    <td>
                        <asp:DropDownList ID="ddlInstitute" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlInstitute_SelectedIndexChanged"></asp:DropDownList>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlProgram" runat="server" Width="155px" AutoPostBack="true" OnSelectedIndexChanged="ddlProgram_SelectedIndexChanged"></asp:DropDownList>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlBranch" Width="80px" runat="server"></asp:DropDownList>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlSem" runat="server"></asp:DropDownList>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlStatus" runat="server">
                            <asp:ListItem Value="." Text="Select"></asp:ListItem>
                            <asp:ListItem Value="1" Text="Clear"></asp:ListItem>
                            <asp:ListItem Value="2" Text="Permitted"></asp:ListItem>

                        </asp:DropDownList>
                    </td>
                   <td>
                        <asp:TextBox ID="txtEnrollFrom" Width="120px" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <asp:TextBox ID="txtEnrollTo" Width="120px" runat="server"></asp:TextBox>
                    </td>
                     <td>
                        <asp:Button ID="btnShow" runat="server" Text="Show" OnClick="btnShow_Click" />
                        &nbsp;
                        <asp:Button ID="btnPrintTopSheet" runat="server" Text="Print Top Sheet" OnClick="btnPrintTopSheet_Click" />
                    </td>
                </tr>
                <tr>
                   
                </tr>
                <tr>
                    
                </tr>
            </table>
        </div>
        <div style="max-height: 500px; overflow: auto">
                        
            <asp:GridView ID="gvAdmitCard" runat="server" AutoGenerateColumns="false" CssClass="gridDynamic">
                <Columns>
                    <asp:TemplateField HeaderText="S#">
                        <ItemTemplate>
                            <%#((GridViewRow)Container).RowIndex+1 %>
                        </ItemTemplate>
                        <ItemStyle Width="20px" />
                    </asp:TemplateField>
                    <asp:BoundField HeaderText="Enrollment" DataField="ENROLLMENT_NO" />
                    <asp:BoundField HeaderText="Name" DataField="STU_FULL_NAME" />
                    <asp:BoundField HeaderText="Program" DataField="PGM_SHORT_NAME" />
                    <asp:BoundField HeaderText="Institute" DataField="INS_VALUE" />
                    <asp:BoundField HeaderText="Sem" DataField="ACA_SEM_ID" />

                </Columns>
            </asp:GridView>
            <asp:Button ID="btnPrint" runat="server" Text="Print" OnClick="btnPrint_Click"  />
        </div>
        <div style="padding-left: 300px">
        </div>
    </div>
</asp:Content>

