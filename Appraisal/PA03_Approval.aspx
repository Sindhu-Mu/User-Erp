<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/FullLength.master" AutoEventWireup="true" CodeFile="PA03_Approval.aspx.cs" Inherits="Appraisal_PA03_Approval" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="container">
        <div class="heading">
            <h2>Performa: PA03</h2>
        </div>
        <div class="heading">
            <h3>Mangalayatan University</h3>
        </div>
        <div class="heading">
            <h3>Faculty Performance Appraisal System
            </h3>
        </div>
        <div class="heading">
            <h5>(<asp:Label ID="lblRFrom" runat="server"></asp:Label>
                to
                <asp:Label ID="lblRTo" runat="server"></asp:Label>
                ) 
            </h5>
        </div>
        <hr />
        <div>
            <table>
                <tr>
                    <td>
                        <table>
                            <tr>
                                <td>
                                    <div style="width: 450px; overflow: auto">
                                        <asp:GridView ID="gvReportInfo" runat="server" AutoGenerateColumns="False" GridLines="None"
                                            CssClass="gridDynamic" AlternatingRowStyle-CssClass="alt" DataKeyNames="PA03_FAC_ID"
                                            Width="95%" OnRowCommand="gvReportInfo_RowCommand">
                                            <Columns>
                                                <asp:TemplateField HeaderText="S.No.">
                                                    <ItemTemplate>
                                                        <%# ((GridViewRow)Container).RowIndex + 1%>
                                                    .
                                                    </ItemTemplate>
                                                    <ItemStyle Width="10px" />
                                                </asp:TemplateField>
                                                <asp:BoundField DataField="EMP_NAME" HeaderText="Faculty Name">
                                                    <ItemStyle Width="150px" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="PA03_FAC_YEAR" HeaderText="Year">
                                                    <ItemStyle Width="20px" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="PA03_FAC_SEM_TYPE" HeaderText="Sem Type">
                                                    <ItemStyle Width="40px" />
                                                </asp:BoundField>
                                                <asp:TemplateField ShowHeader="False">
                                                    <ItemTemplate>
                                                        <asp:Button ID="btn_Status" runat="server" CausesValidation="false" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>"
                                                            Text="Detail" />
                                                    </ItemTemplate>
                                                    <ItemStyle Width="25px"></ItemStyle>
                                                </asp:TemplateField>
                                            </Columns>
                                            <AlternatingRowStyle CssClass="alt" />
                                        </asp:GridView>
                                    </div>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td style="width: 800px; height: 500px">
                        <iframe id="ifram" runat="server" style="padding: 0; background-color: Transparent; width: 100%; height: 500px"
                            scrolling="yes" frameborder="0"></iframe>
                    </td>
                </tr>
                <tr>
                    <td>
                        <table>
                            <tr>
                                <th>Comments<span class="required">*</span></th>
                                <td>
                                    <asp:TextBox ID="txtComments" runat="server" MaxLength="1000" Rows="5" TextMode="MultiLine"
                                        Width="313px" Enabled="false"></asp:TextBox>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Button ID="btnSave" Text="Save" runat="server" Width="56px"
                            Enabled="false" OnClick="btnSave_Click" /></td>
                </tr>
            </table>
        </div>
    </div>
</asp:Content>

