<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/FullLength.master" AutoEventWireup="true" CodeFile="rptStudentDocument.aspx.cs" Inherits="Academic_rptStudentDocument" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="container">
        <div class="heading">
            <h2>Document Detail</h2>
        </div>
        <asp:UpdatePanel ID="Updatepanel1" runat="server">
            <ContentTemplate>
                <table>
                    <tr>
                        <td>
                            <table>
                                <tr>
                                    <th>By Institution</th>
                                    <th>By Program</th>
                                    <th>By Branch</th>
                                    <th>By Batch</th>
                                    <th>By Sem</th>
                                    <th>By Status</th>
                                </tr>
                                <tr>
                                    <td><asp:DropDownList ID="ddlIns" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlIns_SelectedIndexChanged"></asp:DropDownList></td>
                                    <td><asp:DropDownList ID="ddlCourse" runat="server" AutoPostBack="True" Width="150px" OnSelectedIndexChanged="ddlCourse_SelectedIndexChanged"></asp:DropDownList></td>
                                    <td><asp:DropDownList ID="ddlBranch" runat="server" AutoPostBack="True" Width="150px"></asp:DropDownList></td>
                                    <td><asp:DropDownList ID="ddlBatch" runat="server" AutoPostBack="True"></asp:DropDownList></td>
                                    <td><asp:DropDownList ID="ddlSem" runat="server" AutoPostBack="True"></asp:DropDownList></td>
                                    <td><asp:DropDownList ID="ddlsts" runat="server" AutoPostBack="True"></asp:DropDownList></td>
                                    <td>
                                    <asp:Button ID="btnView" runat="server" Text="View" OnClick="btnView_Click"/>
                                </td>
                                    
                                <td>
                                    <asp:Button ID="btnExport" runat="server" Text="Export to Excel" OnClick="btnExport_Click"/>
                                </td>
                                </tr>
                            </table>
                           
                               
                           
                        </td>
                    </tr>
                      <tr>
                                    <td><asp:CheckBoxList ID="ChDocument" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow"></asp:CheckBoxList>    
                               </tr>
                    <tr>
                        <td>
                            <asp:GridView ID="gvStuDeatil" runat="server" AutoGenerateColumns="false" CssClass="gridDynamic">
                                <Columns>
                                    <asp:TemplateField HeaderText="S.No">
                                        <ItemTemplate>
                                               <%# ((GridViewRow)Container).RowIndex + 1%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="ENROLLMENT_NO" HeaderText="Enrollemnt NO" />
                                    <asp:BoundField DataField="STU_FULL_NAME" HeaderText="Name" />
                                    <asp:BoundField DataField="PGM_SHORT_NAME" HeaderText="Program" />
                                    <asp:BoundField DataField="BRN_SHORT_NAME" HeaderText="Branch" />
                                    <asp:BoundField DataField="ACA_SEM_ID" HeaderText="Sem" />
                                    <asp:BoundField HeaderText="Collected" />
                                    <asp:BoundField HeaderText="Pending" />
                                </Columns>
                            </asp:GridView>
                        </td>
                    </tr>
                </table>
                
            </ContentTemplate>
            <Triggers>
                <asp:PostBackTrigger ControlID="btnExport"  />
            </Triggers>
        </asp:UpdatePanel>
        
    </div>
</asp:Content>

