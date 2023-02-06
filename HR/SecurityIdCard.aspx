<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/FullLength.master" AutoEventWireup="true" CodeFile="SecurityIdCard.aspx.cs" Inherits="HR_SecurityIdCard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <div class="container">
        <div class="heading">
            <h2>Employee Id Card
            </h2>
        </div>
        <div>
            <asp:UpdatePanel ID="up1" runat="server">
                <ContentTemplate>
                    <table>
                        <tr>
                            <td>
                                <table>
                                    <tr>
                                        <td>Employee Code</td>
                                        <td>
                                            <asp:TextBox ID="txtCode" runat="server" /></td>
                                        <td>
                                            <asp:Button ID="btnPrint" runat="server" Text="Print" OnClick= "btnPrint_Click" /></td>

                                        <td>
                                            <asp:Button ID="btnShow" runat="server" Text="Show" OnClick="btnShow_Click"/>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:GridView ID="gvSecurity" runat="server" DataKeyNames="SUB_ID" AutoGenerateColumns="false" CellPadding="4" Height="79px"
                                    CssClass="gridDynamic">
                                    <Columns>
                                        <asp:BoundField DataField="EMP_CODE" HeaderText="EMP CODE " />
                                        <asp:BoundField DataField="EMP_NAME" HeaderText="EMP NAME " />
                                        <asp:BoundField DataField="FATHER_NAME" HeaderText="FATHER NAME " />
                                        <asp:BoundField DataField="DESIGNTN" HeaderText="DESIGNATION " />
                                        <asp:BoundField DataField="DOJ" HeaderText="DOJ " DataFormatString="{0:dd/MM/yyyy}" />
                                        <asp:BoundField DataField="DEPT" HeaderText="DEPT " />
                                        <asp:BoundField DataField="DOB" HeaderText="D.O.B " />
                                        <asp:BoundField DataField="BLD_GRP" HeaderText="BLOOD GRP " />
                                        <asp:BoundField DataField="ADRS" HeaderText="ADDRESS " />
                                        <asp:BoundField DataField="MOB" HeaderText="MOB " />
                                    </Columns>
                                </asp:GridView>
                            </td>
                        </tr>
                    </table>
                </ContentTemplate>
            </asp:UpdatePanel>


        </div>
    </div>

</asp:Content>

