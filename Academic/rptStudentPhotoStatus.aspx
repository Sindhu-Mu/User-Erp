<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/FullLength.master" AutoEventWireup="true" CodeFile="rptStudentPhotoStatus.aspx.cs" Inherits="Academic_rptStudentPhotoStatus" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <div class="container">
        <div class="heading">
            <h2>Student Images</h2>
        </div>
        <div>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <div>
                    <table>
                        <tr>
                           
                            <th>By Batch</th>
                            <th>By Institute</th>
                            <th>By Program</th>
                            <th>By Branch</th>
                            <th>By Semester</th>
                            <th>By Section</th>
                        </tr>
                        <tr>
                          
                            <td>
                                <asp:DropDownList ID="ddlBatch" runat="server"></asp:DropDownList></td>
                            <td>
                                <asp:DropDownList ID="ddlIns" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlIns_SelectedIndexChanged"></asp:DropDownList></td>
                            <td>
                                <asp:DropDownList ID="ddlPgm" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlPgm_SelectedIndexChanged"></asp:DropDownList></td>
                            <td>
                                <asp:DropDownList ID="ddlBrn" runat="server" AutoPostBack="True"></asp:DropDownList></td>
                            <td>
                                <asp:DropDownList ID="ddlSem" runat="server" AutoPostBack="True"></asp:DropDownList></td>
                            <td>
                                <asp:DropDownList ID="ddlSec" runat="server" AutoPostBack="True"></asp:DropDownList>
                            </td>
                            <td>
                                <asp:Button ID="btnShow" runat="server" Text="Show" OnClick="btnShow_Click" /></td>
                            <td>
                                <asp:Button ID="btnExcel" runat="server" Text="Excel" OnClick="btnExcel_Click" /></td>
                        </tr>
                       
                    </table>
                </div>
                <div style="overflow:auto;max-height:400px;">
                    <asp:GridView ID="gvDetail" runat="server" AutoGenerateColumns="false" CssClass="gridDynamic" DataKeyNames="STU_MAIN_ID">
                        <Columns>
                            <asp:TemplateField HeaderText="S.No">
                                <ItemTemplate>
                                    <%#((GridViewRow)Container).RowIndex +1 %>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField HeaderText="Enrollment" DataField="ENROLLMENT_NO" />
                            <asp:BoundField HeaderText="Name" DataField="STU_FULL_NAME" />
                            <asp:BoundField HeaderText="Program" DataField="PGM_FULL_NAME" />
                            <asp:BoundField HeaderText="Semester" DataField="ACA_SEM_NO" />
                            <asp:BoundField HeaderText="Photos" DataField="IMG" />
                          <%--  <asp:TemplateField>                                
                                <ItemTemplate>
                                   <img id="ImgStu" runat="server" width="50" height="50" src='<%# Bind("IMG") %>' />
                                </ItemTemplate>
                                <ItemStyle Width="20px" />
                            </asp:TemplateField>--%>
                        </Columns>
                    </asp:GridView>
                </di>
            </ContentTemplate>
            <Triggers><asp:PostBackTrigger ControlID="btnExcel" /></Triggers>
        </asp:UpdatePanel>
            </div>
    </div>
</asp:Content>

