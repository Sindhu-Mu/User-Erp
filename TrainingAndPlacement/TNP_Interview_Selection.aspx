<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/FullLength.master" AutoEventWireup="true" CodeFile="TNP_Interview_Selection.aspx.cs" Inherits="TrainingAndPlacement_TNP_Interview_Selection" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <div class="container">
         <div class="heading">
            <h2>Interview Selection</h2>
        </div>
        <hr />
        <table>
            <tr> 
                   <td>
                    <asp:TextBox ID="txtxml" Visible="false" runat="server"></asp:TextBox>
                </td>

              </tr>
            <tr>
                <td>
                    <asp:GridView ID="GvShow" runat="server" AutoGenerateColumns="false" width="300" EmptyDataText="No Record Found" CssClass="gridDynamic" OnRowDataBound="GvShow_RowDataBound">
             <Columns>
                        <asp:TemplateField HeaderText="S.No.">
                            <ItemTemplate>
                                <%# ((GridViewRow)Container).RowIndex + 1%>
                                .
                            </ItemTemplate>
                        </asp:TemplateField>
                        
                        <asp:BoundField DataField="ENROLLMENT_NO" HeaderText="Enrollment" />
                        <asp:BoundField DataField="STU_FULL_NAME" HeaderText="Name" />
                        <asp:BoundField DataField="BRN_SHORT_NAME" HeaderText="Branch" />
                      <asp:TemplateField HeaderText="Select">
                          <ItemTemplate>
                           <asp:DropDownList ID="ddlselect" runat="server" Width="130">
                           </asp:DropDownList>
                          </ItemTemplate>
                      </asp:TemplateField>
                     </Columns>
                        </asp:GridView>
                     <asp:Button ID="btnshow" runat="server" Text="Show" OnClick="btnshow_Click" />
                </td>
            </tr>
            </table>
         <asp:GridView ID="GvAdd" runat="server" AutoGenerateColumns="false" width="300" EmptyDataText="No Record Found" CssClass="gridDynamic">
             <Columns>
                        <asp:TemplateField HeaderText="S.No.">
                            <ItemTemplate>
                                <%# ((GridViewRow)Container).RowIndex + 1%>
                                .
                            </ItemTemplate>
                        </asp:TemplateField>
                        
                        <asp:BoundField DataField="ENROLLMENT_NO" HeaderText="Enrollment" />
                        <asp:BoundField DataField="STATUS_ID" HeaderText="STATUS" />
                        <%--<asp:BoundField DataField="STU_FULL_NAME" HeaderText="Name" />--%>
                 </Columns>
              </asp:GridView>
         <asp:Button ID="btnsave" runat="server" Text="Save" OnClick="btnsave_Click" />
         </div>
</asp:Content>

