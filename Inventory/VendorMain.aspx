<%@ Page Language="C#" AutoEventWireup="true" CodeFile="VendorMain.aspx.cs" Inherits="Inventory_VendorMain" MasterPageFile="~/MasterPages/FullLength.master" Title="ERP|Vendor" %>

<%@ Register Src="../control/email.ascx" TagName="email" TagPrefix="uc15" %>
<%@ Register Src="../control/address.ascx" TagName="address" TagPrefix="uc14" %>
<%@ Register Src="~/Control/phoneNumber.ascx" TagPrefix="uc9" TagName="phoneNumber" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="heading">
            <h2>Vendor Registration</h2>
        </div>
        <div>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <table>
                        <tr>
                            <td>
                                <asp:Wizard ID="newVendorWizard" runat="server" ActiveStepIndex="1" OnFinishButtonClick="newVendorWizard_FinishButtonClick">
                                    <SideBarButtonStyle CssClass="wizardSideButton" />
                                    <SideBarStyle CssClass="wizardSide" />
                                    <SideBarTemplate>
                                        <asp:DataList ID="SideBarList" runat="server">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="SideBarButton" runat="server" Enabled="true"></asp:LinkButton>
                                            </ItemTemplate>
                                            <SelectedItemTemplate>
                                                <asp:LinkButton ID="SideBarButton" runat="server" Enabled="false"></asp:LinkButton>
                                            </SelectedItemTemplate>
                                        </asp:DataList>
                                    </SideBarTemplate>
                                    <WizardSteps>
                                        <asp:WizardStep ID="WizardStep1" runat="server" StepType="Start" Title="Basic Info">
                                            <table class="wizardTable">
                                                <tr>
                                                    <td class="wizardStepHeader" colspan="2">Organisation Type
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <th>Vendor Name<span class="expected">*</span>
                                                    <td>
                                                        <asp:TextBox ID="txtVendor" runat="server" Width="221px"></asp:TextBox>
                                                        <asp:Button ID="Search" runat="server" Text="Show" />

                                                    </td>
                                                </tr>
                                                <tr>
                                                    <th>For Store<span class="required">*</span>
                                                    </th>
                                                    <td>
                                                        <asp:DropDownList ID="ddlStore" runat="server"></asp:DropDownList>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <th>Organisation Name<span class="required">*</span>

                                                    </th>
                                                    <td>
                                                        <asp:TextBox ID="txtOrgName" runat="server" Width="200px"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <th>Organisation Type<span class="expected">*</span>
                                                    </th>
                                                    <td id="tdCheckBox" runat="server">
                                                        <asp:CheckBoxList ID="ChListOrgType" runat="server">
                                                            <asp:ListItem Value="1">Original Equipment Manufacturer</asp:ListItem>
                                                            <asp:ListItem Value="2">General Order Supplier</asp:ListItem>
                                                            <asp:ListItem Value="3">Authorised Dealer(Pls.Attach Auth.Certificate)</asp:ListItem>
                                                            <asp:ListItem Value="4">Service Provider</asp:ListItem>
                                                            <asp:ListItem Value="5">Contractor</asp:ListItem>
                                                        </asp:CheckBoxList>
                                                    </td>
                                                </tr>

                                                <tr>
                                                    <th>PAN Number<span class="required">*</span>

                                                    </th>
                                                    <td>
                                                        <asp:TextBox ID="txtPanNo" runat="server" MaxLength="12" Width="140px"></asp:TextBox>
                                                    </td>
                                                </tr>

                                                <tr>
                                                    <th>Excise Registration Number<span class="expected">*</span>

                                                    </th>
                                                    <td>
                                                        <asp:TextBox ID="txtEXT" runat="server" Width="200px"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <th>VAT Number<span class="expected">*</span>

                                                    </th>
                                                    <td>
                                                        <asp:TextBox ID="txtVAT" runat="server" Width="200px"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <th>TIN Number<span class="expected">*</span>

                                                    </th>
                                                    <td>
                                                        <asp:TextBox ID="txtTIN" runat="server" Width="200px"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <th>Service Tax Number<span class="expected">*</span>

                                                    </th>
                                                    <td>
                                                        <asp:TextBox ID="txtTax" runat="server" Width="200px"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <th>Total Turn Over<span class="expected">*</span>

                                                    </th>
                                                    <td>
                                                        <cc1:NumericTextBox ID="txtTurnover" runat="server" AllowDecimal="True" AllowNegative="False" DecimalPlaces="-1"></cc1:NumericTextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <th>Financial Year<span class="expected">*</span>

                                                    </th>
                                                    <td>
                                                        <cc1:NumericTextBox ID="txtFinYear" runat="server" AllowDecimal="False" AllowNegative="False" DecimalPlaces="-1"></cc1:NumericTextBox>
                                                    </td>
                                                </tr>
                                            </table>
                                        </asp:WizardStep>
                                        <asp:WizardStep ID="WizardStep2" runat="server" Title="Contact Info" StepType="Step">
                                            <table class="wizardTable">
                                                <tr>
                                                    <td class="wizardStepHeader" colspan="2">Address & Contact
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2">
                                                        <asp:UpdatePanel ID="upAdd1" runat="server">
                                                            <ContentTemplate>
                                                                <uc14:address ID="ctrlAddress" runat="server"></uc14:address>
                                                            </ContentTemplate>
                                                        </asp:UpdatePanel>
                                                    </td>
                                                </tr>

                                                <tr>

                                                    <th>Mobile Number<span class="required">*</span>

                                                    </th>
                                                    <td>
                                                        <cc1:NumericTextBox ID="txtOrgMobileNo" runat="server" MaxLength="10" AllowDecimal="False"
                                                            AllowNegative="False" DecimalPlaces="-1"></cc1:NumericTextBox>

                                                    </td>

                                                </tr>
                                                <tr>

                                                    <th>Landline Number<span class="required">*</span>

                                                    </th>
                                                    <td>
                                                        <cc1:NumericTextBox ID="txtOrgPhone" runat="server" MaxLength="12" AllowDecimal="False"
                                                            AllowNegative="False" DecimalPlaces="-1"></cc1:NumericTextBox>

                                                    </td>
                                                </tr>
                                                <tr>

                                                    <th>Mail Id<span class="required">*</span>

                                                    </th>
                                                    <td>
                                                        <asp:TextBox ID="txtOrgMail" runat="server" Width="150px"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <th>Mail Domain<span class="required">*</span>

                                                    </th>
                                                    <td>
                                                        <asp:DropDownList ID="ddlOrgMainDomain" runat="server"></asp:DropDownList>
                                                    </td>
                                                </tr>
                                            </table>
                                        </asp:WizardStep>
                                        <asp:WizardStep ID="WizardStep3" StepType="Step" Title="Account Info">
                                            <table class="wizardTable">
                                                <tr>
                                                    <td class="wizardStepHeader">Bank Account Details
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:UpdatePanel ID="UpAccountDetail" runat="server">
                                                            <ContentTemplate>
                                                                <table>
                                                                    <tr>
                                                                        <th>Name Of the Bank<span class="required">*</span>

                                                                        </th>
                                                                        <td>
                                                                            <asp:DropDownList ID="ddlBank" runat="server"></asp:DropDownList>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <th>Bank Account Number<span class="required">*</span>

                                                                        </th>
                                                                        <td>
                                                                            <cc1:NumericTextBox ID="txtAccountNo" runat="server" CssClass="textbox"></cc1:NumericTextBox>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <th>Branch Address<span class="required">*</span>

                                                                        </th>
                                                                        <td>
                                                                            <asp:TextBox ID="txtBankAddress" runat="server" Width="200px" TextMode="MultiLine"></asp:TextBox>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <th>Type Of Account<span class="required">*</span>

                                                                        </th>
                                                                        <td>
                                                                            <asp:DropDownList ID="ddlType" runat="server" Width="120px">
                                                                                <asp:ListItem>Select</asp:ListItem>
                                                                                <asp:ListItem Value="Saving">Saving</asp:ListItem>
                                                                                <asp:ListItem Value="Current">Current</asp:ListItem>
                                                                            </asp:DropDownList>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <th>IFSC Code<span class="expected">*</span>

                                                                        </th>
                                                                        <td>
                                                                            <asp:TextBox ID="txtIFSC" runat="server" Width="200px"></asp:TextBox>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <th>RTGS Code<span class="expected">*</span>

                                                                        </th>
                                                                        <td>
                                                                            <asp:TextBox ID="txtRTGS" runat="server" Width="200px"></asp:TextBox>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </ContentTemplate>
                                                        </asp:UpdatePanel>

                                                    </td>
                                                </tr>

                                            </table>
                                        </asp:WizardStep>
                                        <asp:WizardStep ID="WizardStep4" Title="Contact Person Info" StepType="Step">
                                            <table class="wizardTable">
                                                <tr>
                                                    <td class="wizardStepHeader">Contact Person Details
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:UpdatePanel ID="upContactPerson" runat="server">
                                                            <ContentTemplate>
                                                                <table>
                                                                    <tr>
                                                                        <th>Full Name<span class="required">*</span>

                                                                        </th>
                                                                        <td>
                                                                            <asp:TextBox ID="txtName" runat="server" MaxLength="50" Width="140px"></asp:TextBox>

                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <th>Designation<span class="expected">*</span>

                                                                        </th>
                                                                        <td>
                                                                            <asp:TextBox ID="txtDesig" runat="server" Width="300px"></asp:TextBox>
                                                                        </td>
                                                                    </tr>

                                                                    <tr>
                                                                        <th>Mobile No.<span class="required">*</span>
                                                                        </th>
                                                                        <td>
                                                                            <cc1:NumericTextBox ID="txt_CPMobileNo" runat="server" MaxLength="10" AllowDecimal="False"
                                                                                AllowNegative="False" DecimalPlaces="-1"></cc1:NumericTextBox>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <th>Mail ID<span class="required">*</span>
                                                                        </th>
                                                                        <td>
                                                                            <asp:TextBox ID="txt_CPMailId" runat="server" Width="200px"></asp:TextBox>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <th>Mail Domain<span class="required">*</span>
                                                                        </th>
                                                                        <td>
                                                                            <asp:DropDownList ID="ddl_CPMailDomain" runat="server"></asp:DropDownList>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </ContentTemplate>
                                                        </asp:UpdatePanel>

                                                    </td>
                                                </tr>

                                            </table>
                                        </asp:WizardStep>
                                        <asp:WizardStep ID="WizardStep5" Title="Supplied Items" StepType="Step">
                                            <table class="wizardTable">
                                                <tr>
                                                    <td class="wizardStepHeader">Item Details
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:UpdatePanel ID="upItems" runat="server">
                                                            <ContentTemplate>
                                                                <table>
                                                                    <tr>
                                                                        <th>Item Category <span class="required">*</span>
                                                                        </th>
                                                                        <td>
                                                                            <asp:DropDownList ID="ddlItemCat" runat="server" Width="200px"></asp:DropDownList>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <th>&nbsp;Description<span class="expected">*</span>
                                                                        </th>
                                                                        <td>
                                                                            <asp:TextBox ID="txtItemDesc" runat="server" CssClass="textbox" Width="400px"></asp:TextBox>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </ContentTemplate>
                                                        </asp:UpdatePanel>
                                                    </td>
                                                </tr>

                                            </table>
                                        </asp:WizardStep>
                                        <asp:WizardStep ID="WizardStep6" StepType="Finish" runat="server" Title="Supported Documents">
                                            <table class="wizardTable">
                                                <tr>
                                                    <td class="wizardStepHeader">Attach Documents
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:UpdatePanel ID="upDocuments" runat="server">
                                                            <ContentTemplate>
                                                                <table>
                                                                    <tr>
                                                                        <th>Document Name<span>*</span>
                                                                        </th>
                                                                        <td>
                                                                            <asp:TextBox ID="txtDocName" runat="server" Width="200px"></asp:TextBox>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <th>Upload Document<span>*</span>
                                                                        </th>
                                                                        <td>
                                                                            <input id="upload_Doc" runat="server" class="textbox" name="File1" size="30" type="file" />
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </ContentTemplate>
                                                        </asp:UpdatePanel>
                                                    </td>
                                                </tr>
                                            </table>
                                        </asp:WizardStep>
                                    </WizardSteps>
                                </asp:Wizard>
                            </td>

                        </tr>
                        <tr>
                            <td>
                                <asp:TextBox ID="txtXML" runat="server" Visible="false"></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
</asp:Content>



