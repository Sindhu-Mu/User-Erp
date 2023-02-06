<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/FullLength.master" AutoEventWireup="true" CodeFile="VehicleMain.aspx.cs" Inherits="Facility_VehicleMaster" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <script lang ="javascript" type="text/javascript">
        function CheckControl(ctrl) {
            if (bTrim(document.getElementById(ctrl).value) == "" || bTrim(document.getElementById(ctrl).value) == "." || bTrim(document.getElementById(ctrl).value) == "Select") {
                document.getElementById(ctrl).style.backgroundColor = "#fc6";
                return false;
            }
            else
                document.getElementById(ctrl).style.backgroundColor = "#fff";
            return true;
        }

        function validate() {
            var flag = true;
            var msg = "", ctrl = "";
            if (!CheckControl("<%=txtRegNo.ClientID%>")) {
                msg += "- Enter Registration Number. \n";
                if (ctrl == "")
                    ctrl = "<%=txtRegNo.ClientID%>";
                flag = false;
            }
            if (!CheckControl("<%=ddlVehType.ClientID%>")) {
                msg += "- Select Vehicle Type. \n";
                if (ctrl == "")
                    ctrl = "<%=ddlVehType.ClientID%>";
                flag = false;
            }
            if (!CheckControl("<%=txtSetCap.ClientID%>")) {
                msg += "- Enter Seat Capacity. \n";
                if (ctrl == "")
                    ctrl = "<%=txtSetCap.ClientID%>";
                flag = false;
            }
            if (msg != "") alert(msg);
            if (ctrl != "")
                document.getElementById(ctrl).focus();
            return flag;
        }
    </script>
    <div class="container">
        <div class="heading">
            <h2>Vehicle Master</h2>
        </div>
        <table>
            <tr>
                <td>
                    <table>
                        <tr>
                            <th>Registration Number<span class="required">*</span></th>
                            <th>Vehicle Category<span class="required">*</span></th>
                            <th>Vehicle Type<span class="required">*</span></th>
                            <th>Seating Capacity<span class="required">*</span></th>
                            <th>Model Year</th>
                            
                            
                        </tr>
                        <tr>
                            <td><asp:TextBox ID="txtRegNo" runat="server"></asp:TextBox></td>
                            <td><asp:RadioButtonList ID="rdVehCat" runat="server">
                                <asp:ListItem Text="Light Motor Vehicle" Value="LMV" Selected="True"></asp:ListItem>
                                <asp:ListItem Text="Heavy Motor Vehicle" Value="HMV" Selected="False"></asp:ListItem>
                                </asp:RadioButtonList></td>
                            <td><asp:DropDownList ID="ddlVehType" runat="server">
                                 <asp:ListItem Text="Select"></asp:ListItem>
                                <asp:ListItem Text="Bus"></asp:ListItem>
                                <asp:ListItem Text="Car"></asp:ListItem>
                                 <asp:ListItem Text="Jeep"></asp:ListItem>
                                 <asp:ListItem Text="Van"></asp:ListItem>
                                 <asp:ListItem Text="Ambulance"></asp:ListItem>
                                </asp:DropDownList></td>
                            <td><cc1:NumericTextBox ID="txtSetCap" runat="server"></cc1:NumericTextBox></td>
                            <td><asp:DropDownList ID="ddlModelYer" runat="server"></asp:DropDownList>
                            </td>
                           
                            
                        </tr>
                        <tr>
                            <th>Chasis Number</th>
                            <th>Engine Number</th>
                            <th>Model Type</th>
                            <th>Color</th>
                            <th>Insurance Upto</th>
                            
                        </tr>
                        <tr>
                             <td><asp:TextBox ID="txtchasis" runat="server"></asp:TextBox></td>
                            <td><asp:TextBox ID="txtEngine" runat="server"></asp:TextBox></td>
                            <td><asp:TextBox ID="txtModelTyp" runat="server"></asp:TextBox></td>
                            <td><asp:TextBox ID="txtColor" runat="server"></asp:TextBox></td>
                            <td><asp:TextBox ID="txtInsUpto" runat="server"></asp:TextBox>
                                <ajaxToolkit:CalendarExtender ID="CalendarExtender2" Format="dd/MM/yyyy" runat="server" TargetControlID="txtInsUpto"></ajaxToolkit:CalendarExtender>
                                <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender2" runat="server" TargetControlID="txtInsUpto" Mask="99/99/9999" MaskType="Date">
                                </ajaxToolkit:MaskedEditExtender>
                            </td>
                            
                        </tr>
                        <tr>
                            <th>Pollution Test Upto</th>
                            <th>Road Tax Upto</th>
                            <th>Road Permit Upto</th>
                            <th>Token Tax Upto</th>
                            <th>Fitness Upto</th>
                        </tr>
                        <tr>
                            <td><asp:TextBox ID="txtPolUpto" runat="server"></asp:TextBox>
                                <ajaxToolkit:CalendarExtender ID="CalendarExtender3" Format="dd/MM/yyyy" runat="server" TargetControlID="txtPolUpto"></ajaxToolkit:CalendarExtender>
                                <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender3" runat="server" TargetControlID="txtPolUpto" Mask="99/99/9999" MaskType="Date">
                                </ajaxToolkit:MaskedEditExtender>
                            </td>
                            <td><asp:TextBox ID="txtRoadTax" runat="server"></asp:TextBox>
                                <ajaxToolkit:CalendarExtender ID="CalendarExtender4" Format="dd/MM/yyyy" runat="server" TargetControlID="txtRoadTax"></ajaxToolkit:CalendarExtender>
                                <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender4" runat="server" TargetControlID="txtRoadTax" Mask="99/99/9999" MaskType="Date">
                                </ajaxToolkit:MaskedEditExtender>
                            </td>
                            <td><asp:TextBox ID="txtRoadPermit" runat="server"></asp:TextBox>
                                <ajaxToolkit:CalendarExtender ID="CalendarExtender5" Format="dd/MM/yyyy" runat="server" TargetControlID="txtRoadPermit"></ajaxToolkit:CalendarExtender>
                                <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender5" runat="server" TargetControlID="txtRoadPermit" Mask="99/99/9999" MaskType="Date">
                                </ajaxToolkit:MaskedEditExtender>
                            </td>
                            <td><asp:TextBox ID="txtTokenTax" runat="server"></asp:TextBox>
                                <ajaxToolkit:CalendarExtender ID="CalendarExtender6" Format="dd/MM/yyyy" runat="server" TargetControlID="txtTokenTax"></ajaxToolkit:CalendarExtender>
                                <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender6" runat="server" TargetControlID="txtTokenTax" Mask="99/99/9999" MaskType="Date">
                                </ajaxToolkit:MaskedEditExtender>
                            </td>
                            <td><asp:TextBox ID="txtFitness" runat="server"></asp:TextBox>
                                <ajaxToolkit:CalendarExtender ID="CalendarExtender7" Format="dd/MM/yyyy" runat="server" TargetControlID="txtFitness"></ajaxToolkit:CalendarExtender>
                                <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender7" runat="server" TargetControlID="txtFitness" Mask="99/99/9999" MaskType="Date">
                                </ajaxToolkit:MaskedEditExtender>
                            </td>
                            <td><asp:Button ID="btnSave" runat="server" Text="SAVE" OnClick="btnSave_Click"/></td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td>
                    <table>
                        <tr>
                            <td>
                                <asp:GridView ID="gvVehMain" runat="server" AutoGenerateColumns="false" CssClass="gridDynamic" DataKeyNames="VEH_ID" OnRowCommand="gvVehMain_RowCommand">
                                    <Columns>
                                        <asp:TemplateField HeaderText="S.No.">
                                               <ItemTemplate>
                                               <%# ((GridViewRow)Container).RowIndex + 1%>
                                               </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField HeaderText="Reg No" DataField="VEH_REG_NO" />
                                        <asp:BoundField HeaderText="Category" DataField="VEH_CAT" />
                                        <asp:BoundField HeaderText="Type" DataField="VEH_TYPE" />
                                        <asp:BoundField HeaderText="Seat" DataField="VEH_SEAT_CAPICITY" />
                                        <asp:BoundField HeaderText="Year" DataField="VEH_MODEL_YEAR" />
                                        <asp:BoundField HeaderText="Chasis No" DataField="VEH_CHASIS_NO" />
                                        <asp:BoundField HeaderText="Engine No" DataField="VEH_ENGINE_NO" />
                                        <asp:BoundField HeaderText="Color" DataField="VEH_COLOR" />
                                        <asp:BoundField HeaderText="Insurance Upto" DataField="VEH_INSURANCE_UPTO" />
                                        <asp:BoundField HeaderText="Pollution Upto" DataField="VEH_POLLUTION_UPTO" />
                                        <asp:BoundField HeaderText="Model Type" DataField="MODEL_TYPE" />
                                        <asp:BoundField HeaderText="RoadTax Upto" DataField="VEH_ROADTAX_DT" />
                                        <asp:BoundField HeaderText="Route Permit Upto" DataField="RTE_PERMIT_UPTO" />
                                        <asp:BoundField HeaderText="Token Tax Date" DataField="TOKEN_TAX_DT" />
                                        <asp:BoundField HeaderText="Fitness Upto" DataField="FITNESS_DT" />
                                       <asp:CommandField ButtonType="Image" SelectImageUrl="~/Siteimages/edit.gif" ShowSelectButton="True" HeaderText="Modify">
                                       <ItemStyle Width="40px" />
                                       </asp:CommandField>
                                    </Columns>
                                     <SelectedRowStyle BackColor="#FFFF99" />
                                </asp:GridView>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>

