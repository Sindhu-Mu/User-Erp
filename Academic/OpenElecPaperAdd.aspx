<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/FullLength.master" AutoEventWireup="true" CodeFile="OpenElecPaperAdd.aspx.cs" Inherits="Academic_OpenElecPaperAdd" %>

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
         function CheckAutoComplete(ctrl) {

             var Value = bTrim(document.getElementById(ctrl).value);
             if (Value.indexOf(":") > 0 && Value.length - 1 != Value.lastIndexOf(":")) {
                 document.getElementById(ctrl).style.backgroundColor = "#fff";
                 return true;
             }
             else
                 document.getElementById(ctrl).style.backgroundColor = "#fc6";
             return false;
         }
         function validation() {
             var flag = true;
             var msg = "", ctrl = "";
             if (!CheckControl("<%=ddlSubjectType.ClientID%>")) {
                 msg += " * Select Subject Type. \n";
                 if (ctrl == "")
                     ctrl = "<%=ddlMarksTemplate.ClientID%>";
                 flag = false;
             }
             if (!CheckControl("<%=txtPaperCode.ClientID%>")) {
                 msg += " * Enter Paper code. \n";
                 if (ctrl == "")
                     ctrl = "<%=txtPaperCode.ClientID%>";
                 flag = false;
             }

             if (!CheckControl("<%=txtSubject.ClientID%>")) {
                 msg += " * Enter Subject Name. \n";
                 if (ctrl == "")
                     ctrl = "<%=txtPaperCode.ClientID%>";
                 flag = false;
             }
             if (!CheckControl("<%=ddlMarksTemplate.ClientID%>")) {
                 msg += " * Select Marks Template. \n";
                 if (ctrl == "")
                     ctrl = "<%=ddlMarksTemplate.ClientID%>";
                 flag = false;
             }
             if (!CheckControl("<%=txtFaculty.ClientID%>")) {
                 msg += " * Enter Faculty . \n";
                 if (ctrl == "")
                     ctrl = "<%=txtPaperCode.ClientID%>";
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
            <h2>Open Elective Papers </h2>
        </div>
        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
            <ContentTemplate>
                <table>
                    <tr>
                       
                        <th>Subject Type<span style="color: red">*</span></th>
                        <th>Subject Name<span style="color: red">*</span></th>
                         <th>Paper Code<span style="color: red">*</span></th>
                        <th>Marks Template<span style="color: red">*</span></th>
                        <th>Faculty<span class="required">*</span></th>
                    </tr>
                    <tr>
                       
                        <td>
                            <asp:DropDownList ID="ddlSubjectType" runat="server" Width="100px" OnSelectedIndexChanged="ddlSubjectType_SelectedIndexChanged"  AutoPostBack="True"></asp:DropDownList>
                        </td>
                      
                        <td>
                             <asp:TextBox ID="txtSubject" runat="server" CssClass="textbox" Width="250px"></asp:TextBox>
                        </td>


                   
                        <td>
                            <asp:TextBox ID="txtPaperCode" runat="server" CssClass="textbox" Width="108px"></asp:TextBox>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlMarksTemplate" runat="server" Width="200px"  AutoPostBack="True"></asp:DropDownList>
                        </td>
                        
                      
                        <td>
                        <asp:TextBox ID="txtFaculty" runat="server" Width="200px"></asp:TextBox>
                                <ajaxToolkit:AutoCompleteExtender ID="autoComplete1" runat="server" CompletionInterval="500"
                                    CompletionSetCount="12" ContextKey="0,1,2,3,4" EnableCaching="true" MinimumPrefixLength="1"
                                    ServiceMethod="GetEmployeeList" ServicePath="~\AutoComplete.asmx" TargetControlID="txtFaculty">
                                </ajaxToolkit:AutoCompleteExtender>
                    </td>
                          <td>
                            <asp:Button ID="btnAdd" runat="server" Text="Add" CssClass="btnBrown" OnClick="btnAdd_Click" />

                        </td>
                    </tr>

                </table>
                <table >
                    <tr>
                        <td>
                            <tr>
                                <td>
                                    <asp:UpdatePanel ID="UpdatePanel5" runat="server" UpdateMode="Conditional">
                                        <ContentTemplate>
                                            <asp:GridView ID="gvPaper"  CssClass="gridDynamic" Caption="Open Elective Papers " runat="server"  AutoGenerateColumns="False" EnableViewState="True">
                                               

                                                <Columns>
                                                    <asp:TemplateField HeaderText="S.No.">
                                                        <ItemTemplate>
                                                            <%# ((GridViewRow)Container).RowIndex + 1%>
                                                        </ItemTemplate>
                                                        <ItemStyle Width="20px" />
                                                    </asp:TemplateField>

                                                    <asp:BoundField HeaderText="Paper Code" DataField="PAPER_CODE" />
                                                    <asp:BoundField HeaderText="Subject Name" DataField="SUB_NAME" />
                                                     <asp:BoundField HeaderText="Exam Template" DataField="EXAM_TEMP_MAIN_HEAD" />
                                                     <asp:BoundField HeaderText="Subject Type" DataField="SUB_TYPE_VALUE" />
                                                      <asp:BoundField HeaderText="Faculty" DataField="EMP_NAME" />
                                                </Columns>
                                            </asp:GridView>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </td>
                            </tr>
                            
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</asp:Content>

