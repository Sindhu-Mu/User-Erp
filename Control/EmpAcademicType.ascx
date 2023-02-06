<%@ Control Language="C#" AutoEventWireup="true" CodeFile="EmpAcademicType.ascx.cs" Inherits="Control_EmpAcademicType" %>
<table style="width: 100%">
    <tr>
        <td>
            <table>
                <tr>
                    <th>Academic Base<span class="required">*</span></th>
                    <td>
                        <asp:DropDownList ID="ddlAcademicBase" runat="server">
                        </asp:DropDownList></td>
                </tr>
                <tr>
                    <th>Qualification Name<span class="required">*</span></th>
                    <td>
                        <asp:DropDownList ID="ddlQual" runat="server">
                        </asp:DropDownList></td>
                </tr>
                <tr>
                    <th>Board<span class="required">*</span></th>
                    <td>
                        <asp:DropDownList ID="ddlBoard" runat="server" Width="350px">
                        </asp:DropDownList></td>
                </tr>
                <tr>
                    <th>School/College<span class="required">*</span></th>
                    <td>
                        <asp:TextBox ID="txtSchool" runat="server" MaxLength="100" TextMode="MultiLine" Rows="3" Width="323px"></asp:TextBox></td>
                </tr>
                <tr>
                    <th>Base Type<span class="required">*</span></th>
                    <td>
                        <asp:DropDownList ID="ddlBaseType" runat="server">
                            <asp:ListItem Value="0">Regular</asp:ListItem>
                            <asp:ListItem Value="1">Distance</asp:ListItem>
                        </asp:DropDownList></td>
                </tr>
                <tr>
                    <th>Specialisation<span class="required">*</span></th>
                    <td>
                        <asp:TextBox ID="txtSpec" runat="server" Width="168px"></asp:TextBox></td>
                </tr>
                <tr>
                    <th>Year<span class="required">*</span></th>
                    <td>
                        <asp:DropDownList ID="ddlYear" runat="server">
                        </asp:DropDownList></td>
                </tr>
                <tr>
                    <th>Total Marks<span class="required">*</span></th>
                    <td>
                        <cc1:NumericTextBox ID="txtTotalMks" runat="server" Width="69px"></cc1:NumericTextBox></td>
                </tr>
                <tr>
                    <th style="width: 160px">Obtained Marks<span class="required">*</span></th>
                    <td>
                        <cc1:NumericTextBox ID="txtObtMrks" runat="server" OnTextChanged="txtObtMrks_TextChanged" AutoPostBack="true" Width="68px"></cc1:NumericTextBox></td>
                </tr>
                <tr>
                    <th>Percentage<span class="required">*</span></th>
                    <td>
                        <cc1:NumericTextBox ID="txtPercentage" runat="server" MaxLength="5" AllowDecimal="true"
                            AllowNegative="false" DecimalPlaces="2"  Width="68px"></cc1:NumericTextBox>
                    </td>
                </tr>
                <tr>
                    <th>Division<span class="required">*</span></th>
                    <td>
                        <asp:DropDownList ID="ddlDivision" runat="server">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <th></th>
                    <td>
                        <asp:Button ID="btnAddAcademic" runat="server" Text="Add" Width="49px" OnClick="btnAddAcademic_Click"
                            EnableViewState="false" />
                          <asp:Button ID="btnUpdate" runat="server" Text="Update" Width="49px" OnClick="btnUpdateAcademic_Click"
                            EnableViewState="false" Visible="False" />
                        <asp:TextBox ID="TextBox1" runat="server" Width="110px"
                            Visible="false"></asp:TextBox></td>
                </tr>
            </table>
        </td>

    </tr>
    <tr>
        <td>
            <asp:GridView ID="gridAcademic" runat="server" AutoGenerateColumns="False" DataKeyNames="KEYID,EMP_ACA_ID"
                OnRowDeleting="gridAcademic_RowDeleting" OnRowCommand="gridAcademic_RowCommand">
                <Columns>
                    <asp:TemplateField HeaderText="S.No.">
                        <ItemTemplate>
                            <%# ((GridViewRow)Container).RowIndex + 1%>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField HeaderText="Academic" DataField="ACA_BASE_FULL_NAME" />
                    <asp:BoundField HeaderText="Qualification" DataField="ACA_CRS_VALUE" />
                    <asp:BoundField HeaderText="Board" DataField="ACA_BRD_FULL_NAME" />
                    <asp:BoundField HeaderText="School" DataField="SCH" />
                    <asp:BoundField HeaderText="Pattern" DataField="PTRN_ID" />
                    <asp:BoundField HeaderText="Specialisation" DataField="SPEC" />
                    <asp:BoundField HeaderText="Year" DataField="YER" />
                    <asp:BoundField HeaderText="%age" DataField="PRSNT" />
                    <asp:CommandField SelectText="Edit" ShowSelectButton="True" />
                    <asp:CommandField ShowDeleteButton="true" />
                 
                </Columns>
            </asp:GridView>
        </td>
    </tr>
</table>
