<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ShortlistedAppDetail.aspx.cs" Inherits="HR_ShortlistedAppDetail" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link href="../css/Main.css" rel="stylesheet" type="text/css" />
    <script lang="javascript" type="text/javascript">

        function refreshParent() {
            window.opener.location.href = window.opener.location.href;
            if (window.opener.progressWindow) {
                window.opener.progressWindow.close()
            }
            window.close();

        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div class="container">
        <div class="heading">
            <h2>Shortlisted Applicant Details</h2>
            <asp:ScriptManager ID="SM1" runat="server"></asp:ScriptManager>
        </div>
        <div>
            <table>
                <tr>
                    <td>
                        <table style="min-width: 710px">

                            <tr style="background-color: #9f0404; text-align: center; color: #FFFFFF; font-size: 14px; font-weight: bold;">
                                <td>Basic Info
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <table>
                                        <tr>
                                            <th>First Name<span class="required">*</span>
                                            </th>
                                            <td>
                                                <asp:Label ID="lblFName" runat="server" Width="200px"></asp:Label>
                                                <asp:TextBox ID="txtFirstName" runat="server" Width="200px" Visible="false"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <th>Middle Name<span class="expected">*</span>
                                            </th>
                                            <td>
                                                <asp:Label ID="lblMName" runat="server" Width="200px"></asp:Label>
                                                <asp:TextBox ID="txtMiddleName" runat="server" Width="200px" Visible="false"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <th>Last Name<span class="required">*</span></th>
                                            <td>
                                                <asp:Label ID="lblLName" runat="server" Width="200px"></asp:Label>
                                                <asp:TextBox ID="txtLastName" runat="server" Width="200px" Visible="false"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <th>Mail<span class="required">*</span>
                                            </th>
                                            <td>
                                                <asp:Label ID="lblMail" runat="server" Width="200px"></asp:Label>
                                                <asp:TextBox ID="txtMail" runat="server" Visible="false"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <th>Mail Domain<span class="required">*</span>
                                            </th>
                                            <td>
                                                <asp:Label ID="lblMailDomain" runat="server" Width="200px"></asp:Label>
                                                <asp:DropDownList ID="ddlMailDomain" runat="server" Visible="false"></asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <th>Location<span class="required">*</span>
                                            </th>
                                            <td>
                                                <asp:Label ID="lblLocation" runat="server" Width="200px"></asp:Label>
                                                <asp:TextBox ID="txtLocation" runat="server" Visible="false"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <th>Administration Work<span class="required"></span>
                                            </th>
                                            <td>
                                                <asp:Label ID="lblAdmin" runat="server" Width="200px"></asp:Label>
                                                <asp:DropDownList ID="ddlAdmin" runat="server" Visible="false">
                                                    <asp:ListItem Text="Yes" Value="1"></asp:ListItem>
                                                    <asp:ListItem Text="No" Value="0"></asp:ListItem>
                                                </asp:DropDownList>
                                            </td>

                                        </tr>
                                        <tr>
                                            <th>Current CTC<span class="required">*</span>
                                            </th>
                                            <td>
                                                <asp:Label ID="lblCurCTC" runat="server" Width="200px"></asp:Label>
                                                <cc1:NumericTextBox ID="txtCrntCTC" runat="server" AllowDecimal="true" AllowNegative="false" DecimalPlaces="2" Visible="false"></cc1:NumericTextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <th>Expected CTC<span class="required">*</span>
                                            </th>
                                            <td>
                                                <asp:Label ID="lblExpCTC" runat="server" Width="200px"></asp:Label>
                                                <cc1:NumericTextBox ID="txtExpctCTC" runat="server" AllowDecimal="true" AllowNegative="false" DecimalPlaces="2" Visible="false"></cc1:NumericTextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <th>Notice Period(Days)<span class="required">*</span>
                                            </th>
                                            <td>
                                                <asp:Label ID="lblNotPer" runat="server" Width="200px"></asp:Label>
                                                <cc1:NumericTextBox ID="txtDays" runat="server" AllowDecimal="false" AllowNegative="false" Visible="false"></cc1:NumericTextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <th>Remark
                                            </th>
                                            <td>
                                                <asp:Label ID="lblRemark" runat="server" Width="200px"></asp:Label>
                                                <asp:TextBox ID="txtRemark" runat="server" Visible="false"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <th></th>
                                            <td>
                                                <asp:Button ID="btnEdit" runat="server" Text="Edit" OnClick="btnEdit_Click" />
                                                <asp:Button ID="btnUpdateBasic" runat="server" Text="Update" OnClick="btnUpdateBasic_Click" Visible="false" />
                                                <asp:Button ID="btnCancelBasic" runat="server" Text="Cancel" OnClick="btnCancelBasic_Click" />
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>

                        </table>
                    </td>
                </tr>
                <tr>
                    <td>
                        <table style="min-width: 710px">
                            <tr id="trAcaHead" runat="server" style="background-color: #9f0404; text-align: center; color: #FFFFFF; font-size: 14px; font-weight: bold;">
                                <td>Academic Details
                                </td>
                            </tr>
                            <tr id="trAca" runat="server" visible="false">
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
                                                <cc1:NumericTextBox ID="txtObtMrks" runat="server" AutoPostBack="true" Width="68px" OnTextChanged="txtObtMrks_TextChanged"></cc1:NumericTextBox></td>
                                        </tr>
                                        <tr>
                                            <th>Percentage<span class="required">*</span></th>
                                            <td>
                                                <cc1:NumericTextBox ID="txtPercentage" runat="server" MaxLength="5" AllowDecimal="true"
                                                    AllowNegative="false" DecimalPlaces="2" Width="68px"></cc1:NumericTextBox>
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
                                                <asp:Button ID="btnAcaUpdate" runat="server" Text="Update" Width="60px"
                                                    EnableViewState="false" OnClick="btnAcaUpdate_Click" />
                                                <asp:Button ID="btnAcaCancel" runat="server" Text="Cancel" Width="60px"
                                                    EnableViewState="false" OnClick="btnAcaCancel_Click" />
                                                <asp:TextBox ID="TextBox1" runat="server" Width="110px"
                                                    Visible="false"></asp:TextBox></td>
                                        </tr>
                                    </table>
                                </td>

                            </tr>
                            <tr id="trAcaGrid" runat="server">
                                <td>
                                    <asp:GridView ID="gvAcademic" runat="server" AutoGenerateColumns="False" DataKeyNames="KEYID,INT_CAN_ACA_ID" OnRowCommand="gridAcademic_RowCommand" CssClass="gridDynamic">
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
                                            <asp:BoundField HeaderText="Specialisation" DataField="SPEC" />
                                            <asp:BoundField HeaderText="Year" DataField="YER" />
                                            <asp:BoundField HeaderText="%age" DataField="PRSNT" />
                                            <asp:CommandField SelectText="Edit" ShowSelectButton="True" />
                                        </Columns>
                                    </asp:GridView>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td>
                        <table style="min-width: 710px">
                            <tr id="trExpHead" runat="server" style="background-color: #9f0404; text-align: center; color: #FFFFFF; font-size: 14px; font-weight: bold;">
                                <td>Experience Detail
                                </td>
                            </tr>
                            <tr id="trExp" runat="server" visible="false">
                                <td>
                                    <table>
                                        <tr>
                                            <th>Experience Type<span class="expected">*</span></th>
                                            <td>
                                                <asp:DropDownList ID="ddlExpType" runat="server" Height="30px"></asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <th>Designation<span class="expected">*</span></th>
                                            <td>
                                                <asp:TextBox ID="txtDesignation" runat="server"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <th>
                                                <asp:LinkButton ID="lnkPrime" runat="server" Font-Bold="true">Organization</asp:LinkButton>
                                                <span class="expected">*</span></th>
                                            <td>
                                                <asp:DropDownList ID="ddlOrg" runat="server"></asp:DropDownList>
                                            </td>
                                        </tr>

                                        <tr>
                                            <th>From Date<span class="expected">*</span></th>
                                            <td>
                                                <asp:TextBox ID="txtFromDT" runat="server" Width="86px"></asp:TextBox>
                                                <ajaxToolkit:CalendarExtender ID="cal1" runat="server" TargetControlID="txtFromDT" Format="dd/MM/yyyy">
                                                </ajaxToolkit:CalendarExtender>
                                                <ajaxToolkit:MaskedEditExtender ID="me1" runat="server" Mask="99/99/9999" MaskType="Date"
                                                    TargetControlID="txtFromDT">
                                                </ajaxToolkit:MaskedEditExtender>
                                            </td>
                                        </tr>
                                        <tr>
                                            <th>To Date<span class="expected">*</span></th>
                                            <td>
                                                <asp:TextBox ID="txtToDT" runat="server" Width="86px"></asp:TextBox>
                                                <ajaxToolkit:CalendarExtender ID="cal2" runat="server" TargetControlID="txtToDT" Format="dd/MM/yyyy">
                                                </ajaxToolkit:CalendarExtender>
                                                <ajaxToolkit:MaskedEditExtender ID="me2" runat="server" Mask="99/99/9999" MaskType="Date"
                                                    TargetControlID="txtToDT">
                                                </ajaxToolkit:MaskedEditExtender>
                                            </td>
                                        </tr>
                                        <tr>
                                            <th>Job Description</th>
                                            <td>
                                                <asp:TextBox ID="txtJobDesc" runat="server" TextMode="MultiLine" Height="56px" Width="179px"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <th></th>
                                            <td>
                                                <asp:Button ID="btnExpUpdate" runat="server" Text="Update" OnClick="btnExpUpdate_Click" />
                                                <asp:Button ID="btnExpCancel" runat="server" Text="Cancel" Width="60px" />
                                                <asp:TextBox ID="TextBox2" runat="server" Visible="False"></asp:TextBox></td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr id="trExpGrid" runat="server">
                                <td>
                                    <asp:GridView ID="gvExperience" runat="server" AutoGenerateColumns="false" DataKeyNames="KEYID,ID"
                                        CssClass="gridDynamic" OnRowCommand="gvExperience_RowCommand" EmptyDataText="No Record Found">
                                        <Columns>
                                            <asp:TemplateField HeaderText="S.No.">
                                                <ItemTemplate>
                                                    <%# ((GridViewRow)Container).RowIndex + 1%>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField HeaderText="Type" DataField="EXP_TYPE_VALUE" />
                                            <asp:BoundField HeaderText="Designation" DataField="EXP_DESIG" />
                                            <asp:BoundField HeaderText="Office" DataField="ORG_NAME" />
                                            <asp:BoundField HeaderText="From Date" DataField="FRM_DATE" DataFormatString="{0:dd/MM/yyyy}" />
                                            <asp:BoundField HeaderText="To Date" DataField="TO_DATE" DataFormatString="{0:dd/MM/yyyy}" />
                                            <asp:CommandField SelectText="Edit" ShowSelectButton="True" />
                                        </Columns>
                                    </asp:GridView>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <ajaxToolkit:ModalPopupExtender ID="ModalPopupExtender" runat="server" BackgroundCssClass="modalBackground"
                                        CancelControlID="CancelButton" DropShadow="true" PopupControlID="Panel1" PopupDragHandleControlID="Panel3"
                                        TargetControlID="lnkPrime">
                                    </ajaxToolkit:ModalPopupExtender>
                                    <asp:Panel ID="Panel1" runat="server" CssClass="modalPopup" Style="display: none">
                                        <asp:Panel ID="Panel3" runat="server" Style="border-right: gray 1px solid; border-top: gray 1px solid; border-left: gray 1px solid; cursor: move; color: black; border-bottom: gray 1px solid; background-color: #dddddd">
                                            <div>
                                                <p>
                                                    <b>Organization </b>
                                                </p>
                                            </div>
                                        </asp:Panel>
                                        <div>
                                            <table class="entry">
                                                <tr>
                                                    <th>Organization <span class="required">*</span></th>
                                                    <td>
                                                        <asp:TextBox ID="txtOrgName" runat="server"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <th>Organization Type <span class="required">*</span></th>
                                                    <td>
                                                        <asp:DropDownList ID="ddlType" runat="server"></asp:DropDownList>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <th>Address<span class="required">*</span></th>
                                                    <td>
                                                        <asp:TextBox ID="txtAddress" runat="server" TextMode="MultiLine" Rows="5" Height="94px" Width="185px"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <th>State<span class="required">*</span></th>
                                                    <td>
                                                        <asp:DropDownList ID="ddlState" runat="server" Width="91px" AutoPostBack="True" OnSelectedIndexChanged="ddlState_SelectedIndexChanged">
                                                        </asp:DropDownList></td>
                                                </tr>
                                                <tr>
                                                    <th>City<span class="required">*</span></th>
                                                    <td>
                                                        <asp:DropDownList ID="ddlCity" runat="server" Width="91px">
                                                        </asp:DropDownList></td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2">
                                                        <asp:Button ID="btnOrgSave" runat="server" Text="Save" OnClick="btnOrgSave_Click"
                                                            Width="73px" />
                                                        <asp:Button ID="CancelButton" runat="server" Text="Cancel" />
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                    </asp:Panel>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td>
                        <table>
                            <tr>
                                <th>Interested <span class="required">*</span>
                                </th>
                                <td>
                                    <asp:DropDownList ID="ddlInt" runat="server" OnSelectedIndexChanged="ddlInt_SelectedIndexChanged" AutoPostBack="true">
                                        <asp:ListItem Text="Yes" Value="3"></asp:ListItem>
                                        <asp:ListItem Text="No" Value="2"></asp:ListItem>
                                    </asp:DropDownList>
                                </td>

                            </tr>
                            <tr id="trInt" runat="server" visible="false">
                                <th>Interview Date<span class="expected">*</span>
                                </th>
                                <td>
                                    <asp:TextBox ID="txtIntDate" runat="server"></asp:TextBox>
                                    <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtIntDate" Format="dd/MM/yyyy">
                                    </ajaxToolkit:CalendarExtender>
                                    <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender1" runat="server" Mask="99/99/9999" MaskType="Date"
                                        TargetControlID="txtIntDate">
                                    </ajaxToolkit:MaskedEditExtender>
                                </td>
                                <th>Interview Time
                                </th>
                                <td>
                                    <asp:TextBox ID="txtInTime" runat="server" Width="40px"></asp:TextBox>
                                    <ajaxToolkit:MaskedEditExtender
                                        ID="MaskedEditExtender3" runat="server" CultureName="en-US"
                                        Mask="99:99" MaskType="Time" TargetControlID="txtInTime" CultureAMPMPlaceholder="AM;PM" CultureCurrencySymbolPlaceholder="$" CultureDateFormat="MDY" CultureDatePlaceholder="/" CultureDecimalPlaceholder="." CultureThousandsPlaceholder="," CultureTimePlaceholder=":" Enabled="True">
                                    </ajaxToolkit:MaskedEditExtender>
                                </td>
                                <th>Mode Of Interview</th>
                                <td>
                                    <asp:DropDownList ID="ddlMOI" runat="server"></asp:DropDownList>
                                </td>
                            </tr>
                            
                        </table>
                    </td>
                </tr>
                <tr>
                    <td>
                        <table>
                            <tr style="text-align: right">
                                <td>
                                    <asp:Button ID="btnSave" runat="server" Text="Save Changes" OnClick="btnSave_Click" />
                                </td>
                                <td>
                                    <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click" />
                                </td>
                            </tr>
                        </table>
                    </td>

                </tr>
            </table>
        </div>
    </div>
    </form>
</body>
</html>














