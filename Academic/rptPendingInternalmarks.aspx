<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/FullLength.master" AutoEventWireup="true" CodeFile="rptPendingInternalmarks.aspx.cs" Inherits="Academic_rptPendingInternalmarks" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script lang="javascript" type="text/javascript">

        function CheckControl(ctrl) {
            if (bTrim(document.getElementById(ctrl).value) == "" || bTrim(document.getElementById(ctrl).value) == "." || bTrim(document.getElementById(ctrl).value) == "Select") {
                document.getElementById(ctrl).style.backgroundColor = "#fc6";
                return false;
            }
            else
                document.getElementById(ctrl).style.backgroundColor = "#fff";
            return true;
        }

        function validateType() {
            var flag = true;
            var msg = "", ctrl = "";

            if (!CheckControl("<%=ddlIns.ClientID%>")) {
                msg += "- Select Institute.\n";
                if (ctrl == "")
                    ctrl = "<%=ddlIns.ClientID%>";
                flag = false;
            }
          
            if (!CheckControl("<%=ddlSem.ClientID%>")) {
                msg += "- Select Sem.\n";
                if (ctrl == "")
                    ctrl = "<%=ddlSem.ClientID%>";
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
            <h2>Pending Internal Marks</h2>
        </div>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <div>
                    <table>
                        <tr>

                            <th>By Institute<span class="required">*</span></th>
                            <th>By Program<span class="required">*</span></th>
                            <th>By Branch<span class="required">*</span></th>
                            <th>By Sem<span class="required">*</span></th>

                            <th></th>

                        </tr>
                        <tr>

                            <td>
                                <asp:DropDownList ID="ddlIns" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlIns_SelectedIndexChanged"></asp:DropDownList></td>
                            <td>
                                <asp:DropDownList ID="ddlPgm" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlPgm_SelectedIndexChanged"></asp:DropDownList></td>
                            <td>
                                <asp:DropDownList ID="ddlBranch" runat="server" AutoPostBack="True"></asp:DropDownList></td>
                            <td>
                                <asp:DropDownList ID="ddlSem" runat="server" AutoPostBack="True"></asp:DropDownList></td>
                            <td>
                                <asp:Button ID="btnView" runat="server" Text="View" OnClick="btnView_Click" /></td>

                        </tr>

                    </table>
                </div>

                <div style="height: 450px; overflow: auto">
                    <asp:GridView ID="gvPaperCode" runat="server" CssClass="gridDynamic" AutoGenerateColumns="true"  >
                        <Columns>
                            <asp:TemplateField HeaderText="S.No">
                                <ItemTemplate>
                                    <%#((GridViewRow)Container).RowIndex +1 %>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField HeaderText="Institute" DataField="INS_VALUE" /> 
                            <asp:BoundField HeaderText="Class Name" DataField="CLS_VALUE" /> 
                            <asp:BoundField HeaderText="Semester" DataField="ACA_SEM_ID" /> 
                            <asp:BoundField HeaderText="Paper Code" DataField="PAPER_CODE" /> 

                        </Columns>
                    </asp:GridView>
                </div>
                <div style="text-align:right;">
                    <asp:Button ID="btnExport" runat="server" Text="Export to Excel" OnClick="btnExport_Click" />
                </div>
            </ContentTemplate>
            <Triggers>
                <asp:PostBackTrigger ControlID="btnExport" />
            </Triggers>
        </asp:UpdatePanel>
    </div>
</asp:Content>


