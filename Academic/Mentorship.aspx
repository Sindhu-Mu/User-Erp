<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/FullLength.master" AutoEventWireup="true" CodeFile="Mentorship.aspx.cs" Inherits="Academic_Mentorship" %>

<%@ Register Src="~/Control/StuFullProfile.ascx" TagPrefix="uc1" TagName="StuFullProfile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="container">
        <div class="heading">
            <h2>Mentorship</h2>
        </div>
        <div>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    
                    <table>
                        <tr>
                            <td>
                                <div style="height:250px; overflow:scroll">
                                    <asp:GridView ID="gvStu" runat="server" AutoGenerateColumns="false" CssClass="gridDynamic" OnRowCommand="gvStu_RowCommand" DataKeyNames="STU_MAIN_ID">
                                    <Columns>
                                        <asp:TemplateField HeaderText="S.No">
                                            <ItemTemplate>
                                                <%#((GridViewRow)Container).RowIndex +1 %>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField HeaderText="Enrollment No" DataField="ENROLLMENT_NO" />
                                        <asp:BoundField HeaderText="Name" DataField="STU_FULL_NAME" />
                                        <asp:BoundField HeaderText="Program" DataField="PGM_SHORT_NAME" />
                                        <asp:BoundField HeaderText="Branch" DataField="BRN_SHORT_NAME" />
                                        <asp:ButtonField ButtonType="Button" CommandName="Detail" Text="Detail" HeaderText="Detail" />
                                        <asp:ButtonField ButtonType="Button" CommandName="Contact" Text="Contact" HeaderText="Contact" />
                                    </Columns>
                                </asp:GridView>
                                    </div>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <uc1:StuFullProfile runat="server" ID="student" />
                            </td>
                        </tr>

                        <%--  <tr>
                            <td>
                                <ajaxToolkit:ModalPopupExtender DropShadow="false" runat="server" PopupControlID="Panel1"
                                    ID="ModalPopupExtender1" TargetControlID="tdss" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                    <ContentTemplate>
                                        <asp:Panel ID="Panel1" runat="server" Style="display: none; width: 60%" CssClass="modalPopup">
                                            <asp:Panel ID="Panel3" runat="server" Style="cursor: move; background-color: #DDDDDD; border: solid 1px Gray; color: Black">
                                                <table style="width: 100%">
                                                    <tr>
                                                        <td style="font-size: 14px; font-weight: bold">Paymet Detail
                                                        </td>
                                                        <td align="right">
                                                            <asp:ImageButton ID="CancelButton" runat="server" ImageUrl="~/Images/delete.gif" /></td>
                                                    </tr>
                                                </table>
                                            </asp:Panel>
                                            <div>
                                              
                                        </asp:Panel>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>
                        </tr>
                        <tr>
                            <td id="tdss" runat="server"></td>
                        </tr>--%>



                    </table>
                </ContentTemplate>
            </asp:UpdatePanel>

        </div>
    </div>
</asp:Content>

