 <%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/FullLength.master" AutoEventWireup="true" CodeFile="rptStuAchvBeh.aspx.cs" Inherits="Academic_rptStuAchvBeh" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <div  class="container">
        <div class="heading">
            <h2>Student Achievements And Behaviour</h2>
        </div>
    <div>
       <table>
            <tr>
                        <td>
                            <asp:GridView ID="gvdTAILS" runat="server" AutoGenerateColumns="false" CssClass="gridDynamic">
                                <Columns>
                                     <asp:TemplateField HeaderText="S.No">
                                        <ItemTemplate>
                                            <%#((GridViewRow)Container).RowIndex +1 %>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField HeaderText="ENROLLMENT" DataField="ENROLLMENT_NO" />
                                    <asp:BoundField HeaderText="NAME" DataField="STU_FULL_NAME" />
                                    <asp:BoundField HeaderText="PROGRAMME" DataField="PGM_SHORT_NAME"/>
                                    <asp:BoundField HeaderText="BRANCH" DataField="BRN_SHORT_NAME" />
                                    <asp:BoundField HeaderText="BATCH" DataField="ACA_BATCH_NAME" />
                                    <asp:BoundField HeaderText="SEM" DataField="SEM_ID" />
                                    <asp:BoundField HeaderText="SESSION" DataField="ACA_SESN_VALUE" />
                                    <asp:BoundField HeaderText="TYPE" DataField="Type" />
                                    <asp:BoundField HeaderText="REMARK" DataField="REMARK" />
                                    <asp:BoundField HeaderText="INSERT BY" DataField="EMP_NAME" />
                                    <asp:BoundField HeaderText="INSERT DT" DataField="Date" />
                                </Columns>
                            </asp:GridView>
                        </td>
                    </tr>
       </table>
    </div>
         </div>
</asp:Content>

