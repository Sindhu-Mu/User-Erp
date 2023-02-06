<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/FullLength.master" AutoEventWireup="true" CodeFile="FeeDailyReceived.aspx.cs" Inherits="Finance_BankAccount" %>

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
          function validate() {
              var flag = true;
              var msg = "", ctrl = "";
              if (!CheckControl("<%=ddlSession.ClientID%>")) {
                msg += "- Select Session from list \n";
                if (ctrl == "")
                    ctrl = "<%=ddlSession.ClientID%>";
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
            <h2>
                Fee Daily Received

            </h2>

        </div>
    
    <div id="cBody">
        <div id="cHead">
           <table>
              <tr>
            <td style="padding-left: 20px;">
                <asp:UpdatePanel ID="UP1" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <table>
                             <tr>
                                <th>Session<span class="required">*</span></th>
                                <td><asp:DropDownList ID="ddlSession" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlSession_SelectedIndexChanged"></asp:DropDownList></td>
                            </tr>
                        </table>
                        <table style="border-collapse: collapse; margin: 0px; border: 0px;">
                           
                            <tr>
                                <td id="tdins" runat="server">
                                    <b>INSTITUITON WISE </b>
                                </td>
                                <td>
                                </td>
                                <td id="tdcrs" runat="server">
                                    <b>COURSE WISE</b></td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:GridView ID="gvinstitute" runat="server" AutoGenerateColumns="false" EmptyDataText="No Record Found" OnRowCommand="gvinstitute_RowCommand" Width="100%" DataKeyNames="INS_ID">
                                        <Columns>
                                            <asp:TemplateField HeaderText="S.No.">
                                                <ItemTemplate>
                                                    <%# ((GridViewRow)Container).RowIndex + 1%>
                                                    .
                                                </ItemTemplate>
                                                <ItemStyle Width="30px" />
                                            </asp:TemplateField>
                                            <asp:ButtonField DataTextField="INS_VALUE" HeaderText="INSTITUTION" CommandName="INS" ControlStyle-ForeColor="Blue" />
                                            <asp:BoundField DataField="NOC" HeaderText="NO OF TRANSACTION" />
                                            <asp:BoundField DataField="AMOUNT" HeaderText="AMOUNT" DataFormatString="{0:N2}" />
                                        </Columns>
                                    </asp:GridView>
                                </td>
                                <td></td>
                                <td>
                                    <asp:GridView ID="gvcourse" runat="server" AutoGenerateColumns="false" EmptyDataText="No Record Found" OnRowCommand="gvcourse_RowCommand" DataKeyNames="INS_PGM_ID" Width="100%">
                                        <Columns>
                                            <asp:TemplateField HeaderText="S.No.">
                                                <ItemTemplate>
                                                    <%#((GridViewRow)Container).RowIndex +1 %>>
                                                </ItemTemplate>
                                                <ItemStyle Width="30px"/>
                                            </asp:TemplateField>
                                            <asp:ButtonField DataTextField="PGM_SHORT_NAME" HeaderText="COURSE" CommandName="COURSE" ControlStyle-ForeColor="Blue"/>
                                            <asp:BoundField DataField="NOC" HeaderText="NO OF TRANSACTION"/>
                                            <asp:BoundField DataField="AMOUNT" HeaderText="AMOUNT" DataFormatString="{0:N2}"/>
                                        </Columns>
                                    </asp:GridView>
                                </td>
                            </tr>
                            <tr>
                                <td id="tdbrn" runat="server">
                                    <b>BRANCH WISE</b>
                                </td>
                                <td>

                                </td>
                                <td id="tdsem" runat="server">
                                    <b>SEMESTER WISE</b>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:GridView ID="gvbranch" runat="server" AutoGenerateColumns="false" EmptyDataText="No Record Found" OnRowCommand="gvbranch_RowCommand" DataKeyNames="PGM_BRN_ID" Width="100%">
                                        <Columns>
                                            <asp:TemplateField HeaderText="S.NO.">
                                                <ItemTemplate>
                                                    <%#((GridViewRow)Container).RowIndex+1 %>
                                                </ItemTemplate>
                                                <ItemStyle Width="30px" />
                                            </asp:TemplateField>
                                            <asp:ButtonField DataTextField="BRN_SHORT_NAME" HeaderText="BRANCH" CommandName="BRANCH" ControlStyle-ForeColor="Blue" />
                                            <asp:BoundField DataField="NOC" HeaderText="NO OF TRANSACTION" />
                                            <asp:BoundField DataField="AMOUNT" HeaderText="AMOUNT" DataFormatString="{0:N2}" />
                                        </Columns>
                                    </asp:GridView>
                                </td>
                                <td>

                                </td>
                                <td>
                                    <asp:GridView ID="gvsemester" runat="server" AutoGenerateColumns="false" EmptyDataText="No Record Found"  DataKeyNames="ACA_SEM_ID" Width="100%">
                                        <Columns>
                                            <asp:TemplateField HeaderText="S.NO.">
                                                <ItemTemplate>
                                                    <%#((GridViewRow)Container).RowIndex+1 %>>
                                                </ItemTemplate>
                                                <ItemStyle Width="30px" />
                                            </asp:TemplateField>
                                            <asp:ButtonField DataTextField="ACA_SEM_ID" HeaderText="SEMESTER" CommandName="SEMESTER" />
                                            <asp:BoundField DataField="NOC" HeaderText="NO OF TRANSACTION" />
                                            <asp:BoundField DataField="AMOUNT" HeaderText="AMOUNT" DataFormatString="{0:N2}" />
                                        </Columns>
                                    </asp:GridView>
                                </td>
                            </tr>
                            <tr>
                                <td id="tdstu" runat="server" colspan="3">
                                    <b>STUDENT WISE</b>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="3">
                                    <asp:GridView id="gvstudent" runat="server" AutoGenerateColumns="false" EmptyDataText="No Record Found"  DataKeyNames="STU_MAIN_ID" Width="100%">
                                        <Columns>
                                            <asp:TemplateField HeaderText="S.NO.">
                                                <ItemTemplate>
                                                    <%#((GridViewRow)Container).RowIndex+1 %>>
                                                </ItemTemplate>
                                                <ItemStyle Width="30px" />
                                            </asp:TemplateField>
                                            <asp:ButtonField DataTextField="STU_MAIN_ID" HeaderText="ENROLLMENT" CommandName="ENROLL" />
                                            <asp:BoundField DataField="STU_FULL_NAME" HeaderText="NAME" />
                                            <asp:BoundField DataField="NOC" HeaderText="NO OF TRANSACTION" />
                                            <asp:BoundField DataField="AMOUNT" HeaderText="AMOUNT" DataFormatString="{0:N2}" />
                                        </Columns>
                                    </asp:GridView>

                                </td>
                            </tr>
                            </table>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
                  </tr>
        
           </table>
        </div>
        <div id="cCenter">
           <!-- Content Header ex: Grids-->

        </div>
         <div id="cFooter">
              <!-- Content Header ex:Buttons-->

        </div>
</div>
</div>

</asp:Content>

