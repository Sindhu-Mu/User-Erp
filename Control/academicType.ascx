<%@ Control Language="C#" AutoEventWireup="true" CodeFile="academicType.ascx.cs"
    Inherits="control_academicType" %>
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
                    <th>Board<span class="required">*</span></th>
                    <td>
                        <asp:DropDownList ID="ddlBoard" runat="server" Width="200px">
                        </asp:DropDownList></td>
                </tr>
                <tr>
                    <th>School/College<span class="required">*</span></th>
                    <td>
                        <asp:TextBox ID="txtSchool" runat="server" MaxLength="100" TextMode="MultiLine" Rows="3"></asp:TextBox>
                        <ajaxToolkit:AutoCompleteExtender ID="AutoCompleteExtender2" runat="server" CompletionSetCount="12"
                                                        EnableCaching="true" MinimumPrefixLength="1" ServiceMethod="GetInstituteList"
                                                        ServicePath="~\AutoComplete.asmx" TargetControlID="txtSchool">
                                                    </ajaxToolkit:AutoCompleteExtender>
                    </td>
                </tr>
                <tr>
                    <th>Specialization<span class="required">*</span></th>
                    <td>
                        <asp:TextBox ID="txtSpec" runat="server"></asp:TextBox>
                        <ajaxToolkit:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" CompletionSetCount="12"
                                                        EnableCaching="true" MinimumPrefixLength="1" ServiceMethod="GetSpecilizationList"
                                                        ServicePath="~\AutoComplete.asmx" TargetControlID="txtSpec">
                                                    </ajaxToolkit:AutoCompleteExtender>
                    </td>
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
                        <cc1:NumericTextBox ID="txtTotalMks" runat="server"></cc1:NumericTextBox></td>
                </tr>
                <tr>
                    <th style="width: 160px">Obtained Marks<span class="required">*</span></th>
                    <td>
                        <cc1:NumericTextBox ID="txtObtMrks" runat="server" OnTextChanged="txtObtMrks_TextChanged" AutoPostBack="true"></cc1:NumericTextBox></td>
                </tr>
                <tr>
                    <th>Percentage<span class="required">*</span></th>
                    <td>
                        <cc1:NumericTextBox ID="txtPercentage" runat="server" MaxLength="5" AllowDecimal="true"
                            AllowNegative="false" DecimalPlaces="2" ReadOnly="true"></cc1:NumericTextBox>
                    </td>
                </tr>
                <tr>
                    <th></th>
                    <td>
                        <asp:Button ID="btnAddAcademic" runat="server" Text="Add" Width="49px" OnClick="btnAddAcademic_Click"
                            EnableViewState="false" />
                    </td>
                    <td>
                        <asp:Button ID="btnUpdate" runat="server" Text="Update" Width="49px" Visible="false" OnClick="btnUpdate_Click" />
                        <asp:TextBox ID="TextBox1" runat="server" Width="110px"
                            Visible="false"></asp:TextBox>
                    </td>
                </tr>
            </table>
        </td>

    </tr>
    <tr>
        <td>
            <asp:GridView ID="gridAcademic" runat="server" AutoGenerateColumns="false" DataKeyNames="KEYID"
                OnRowDeleting="gridAcademic_RowDeleting" OnRowCommand="gridAcademic_RowCommand" >
                <Columns>
                    <asp:TemplateField HeaderText="S.No.">
                        <ItemTemplate>
                            <%# ((GridViewRow)Container).RowIndex + 1%>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField HeaderText="Academic" DataField="ACA_BASE_FULL_NAME" />
                    <asp:BoundField HeaderText="Board" DataField="ACA_BRD_FULL_NAME" />
                    <asp:BoundField HeaderText="School" DataField="SCH" />
                    <asp:BoundField HeaderText="Specilization" DataField="SPEC" />
                    <asp:BoundField HeaderText="Year" DataField="YER" />
                    <asp:BoundField HeaderText="%age" DataField="PRSNT" />
                    <asp:CommandField SelectText="Edit" ShowSelectButton="True" />
                    <asp:CommandField ShowDeleteButton="true" />
                </Columns>
            </asp:GridView>
        </td>
    </tr>
</table>
