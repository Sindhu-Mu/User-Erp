<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/FullLength.master" AutoEventWireup="true" CodeFile="PaperClubbing.aspx.cs" Inherits="Academic_PaperClubbing" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script lang="javascript" type="text/javascript">
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
            if (!CheckControl("<%=ddlChoosePaper.ClientID%>")) {
                msg += " * Select Class Paper From list. \n";
                if (ctrl == "")
                    ctrl = "<%=ddlChoosePaper.ClientID%>";
                flag = false;
            }
            if (!CheckControl("<%=ddlPaper.ClientID%>")) {
                msg += " * Select Branch Paper Form List. \n";
                if (ctrl == "")
                    ctrl = "<%=ddlPaper.ClientID%>";
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
            <h2>Paper Clubbing </h2>
        </div>
        <div>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                    <div style="padding-top:10px;">
                        <div style="float:left;width:40%;">
                            <h3>Papers with Time-Table  </h3>
                            <table   style="width:100%;">
                                <tr>
                                    <th>Institute<span class="required">*</span></th>
                                    <td>
                                        <asp:DropDownList ID="ddlInst" runat="server"  OnSelectedIndexChanged="ddlInst_SelectedIndexChanged">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <th>Semester<span class="required">*</span></th>
                                    <td>
                                        <asp:DropDownList ID="ddlSemesterBound" runat="server"
                                            AutoPostBack="true" OnSelectedIndexChanged="ddlSemesterBound_SelectedIndexChanged">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <th>Class Name<span class="required">*</span></th>
                                    <td>
                                        <asp:DropDownList ID="ddlChooseClass" runat="server" OnSelectedIndexChanged="ddlChooseClass_SelectedIndexChanged" AutoPostBack="True">
                                        </asp:DropDownList></td>
                                </tr>
                               
                                <tr>
                                    <th>Course Name<span class="required">*</span></th>
                                    <td>
                                        <asp:DropDownList ID="ddlChoosePaper" runat="server">
                                        </asp:DropDownList></td>
                                </tr>
                                 <tr>
                                     <td>&nbsp;</td>
                                    <td>
                                        <asp:Button ID="btnMapped" runat="server" Text="Mapp"
                                            EnableViewState="false" OnClick="btnMapped_Click" />
                                        <asp:TextBox ID="txtData" runat="server" Visible="False"></asp:TextBox>
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <div style="float:left;width:5%;">
                            &nbsp;
                            </div>
                        <div style="float:left;width:40%;">
                            <h3>Papers without Time-Table</h3> 
                            <table style="width:100%;text-align:left;">
                                <tr>
                                    <th>Institute<span class="required">*</span></th>
                                    <td>
                                        <asp:DropDownList ID="ddlInstitution" runat="server" OnSelectedIndexChanged="ddlInstitution_SelectedIndexChanged" AutoPostBack="True">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <th>Program<span class="required">*</span></th>
                                    <td>
                                        <asp:DropDownList ID="ddlCourse" runat="server"
                                            AutoPostBack="true" OnSelectedIndexChanged="ddlCourse_SelectedIndexChanged">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <th>Branch<span class="required">*</span></th>
                                    <td>
                                        <asp:DropDownList ID="ddlBranch" runat="server">
                                        </asp:DropDownList></td>
                                </tr>
                                <tr>
                                    <th>Semester<span class="required">*</span></th>
                                    <td>
                                        <asp:DropDownList ID="ddlSemester" runat="server">
                                        </asp:DropDownList></td>
                                </tr>
                                <tr>
                                    <th>Section<span class="required">*</span></th>
                                    <td>
                                        <asp:DropDownList ID="ddlSection" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlSection_SelectedIndexChanged">
                                        </asp:DropDownList></td>
                                </tr>
                                <tr>
                                    <th>Course<span class="required">*</span></th>
                                    <td>
                                        <asp:DropDownList ID="ddlPaper" runat="server">
                                        </asp:DropDownList></td>
                                </tr>
                               <tr>
                                   <td colspan="2">
                                       &nbsp;
                                   </td>
                               </tr>
                                 <tr>
                                   <td style="text-align:right;" colspan="2">
                                      <asp:Button ID="btnSave" runat="server" Text="Save"
                            EnableViewState="false" OnClick="btnSave_Click" />
                                   </td>
                               </tr>
                            </table>
                        </div>

                        <div class="cleaner"></div>
                    </div>
                    <div>


                        <asp:GridView ID="gridPaperCombination" runat="server" CssClass="gridDynamic" AutoGenerateColumns="false"
                            EnableViewState="false" ShowHeader="false" OnRowDeleting="gridPaperCombination_RowDeleting"
                            DataKeyNames="TT_ID">
                            <Columns>
                                <asp:BoundField DataField="TT_ID">
                                    <ItemStyle Width="0px" />
                                </asp:BoundField>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        Paper Combination:
                                                                                    <%# DataBinder.Eval(Container.DataItem, "TT_ID")%>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="PAPER_CODE" />
                                <asp:CommandField ShowDeleteButton="true" />
                            </Columns>
                        </asp:GridView>
                    </div>
                   
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
</asp:Content>

