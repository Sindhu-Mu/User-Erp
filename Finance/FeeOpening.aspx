<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/FullLength.master" AutoEventWireup="true" CodeFile="FeeOpening.aspx.cs" Inherits="Finance_FeeOpening" %>

<%@ Register Src="~/Control/Student.ascx" TagPrefix="uc1" TagName="Student" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="container">
        <div class="heading">
            <h2>
                <!-- Page Heading-->
               Student Fee Opening
            </h2>

        </div>
        <div id="cBody">
        <div id="cHead">
           <!-- Content  Header ex: Filters-->
           Enrollment<asp:TextBox ID="txtEnrollment" runat="server" Width="250px"></asp:TextBox>&nbsp;&nbsp;
            <asp:Button ID="btnShow" runat="server" Text="Show" OnClick="btnShow_Click" />&nbsp;&nbsp;  
        </div>
        <div id="cCenter">
           <!-- Content Header ex: Grids-->
            <br/>
            <uc1:Student runat="server" ID="Student" />
            <br/>
            

            <asp:GridView ID="gvFees" runat="server" AutoGenerateColumns="False" Width="97%"
                                                    OnRowCancelingEdit="gvFees_RowCancelingEdit" DataKeyNames="FD_SUB_ID"
                                                    OnRowEditing="gvFees_RowEditing" OnRowUpdating="gvFees_RowUpdating" ShowFooter="True"
                                                    CssClass="gridDynamic">
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="S.No.">
                                                            <ItemTemplate>
                                                                <%# ((GridViewRow)Container).RowIndex + 1%>
                                                                .
                                                            </ItemTemplate>
                                                            <ItemStyle Width="20px" />
                                                        </asp:TemplateField>
                                                        <asp:BoundField DataField="FEE_MAIN_HEAD_NAME" HeaderText="FEE NAME" ReadOnly="True"
                                                            FooterText="TOTAL:-">
                                                            <FooterStyle Font-Bold="True" HorizontalAlign="Right" />
                                                            <ItemStyle Width="200px" />
                                                        </asp:BoundField>
                                                        <asp:TemplateField HeaderText="OPENING">
                                                            <EditItemTemplate>
                                                                <asp:TextBox ID="txtAmount" runat="server" CssClass="txtno" Text='<%# Bind("FD_FEE_AMOUNT") %>'></asp:TextBox>
                                                            </EditItemTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="Label1" runat="server" Text='<%# Bind("FD_FEE_AMOUNT", "{0:N2}") %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Right" />
                                                            <FooterStyle HorizontalAlign="Right" Font-Bold="True" />
                                                        </asp:TemplateField>
                                                        <asp:CommandField ButtonType="Button" ShowEditButton="True" HeaderText="MODIFY">
                                                            <ControlStyle CssClass="btnblue" />
                                                            <ItemStyle HorizontalAlign="Right" />
                                                        </asp:CommandField>
                                                    </Columns>
                                                </asp:GridView>
            <asp:HiddenField ID="HD1" runat="server" />
            <hr />
        </div>
         <div id="cFooter">
              <!-- Content Header ex:Buttons-->
             <br/>
            
             
        </div>
</div>
        </div>
</asp:Content>

