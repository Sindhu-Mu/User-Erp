<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Short.master" AutoEventWireup="true" CodeFile="OrganisationMain.aspx.cs" Inherits="HR_OrganisationMain" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentHolder1" runat="Server">
    <script lang="javascript" type="text/javascript">
        function CheckControl(ctrl) {
            if (bTrim(document.getElementById(ctrl).value) == "" || bTrim(document.getElementById(ctrl).value) == ".") {
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

            if (!CheckControl("<%=txtOrgName.ClientID%>")) {
                msg += " * Enter Organization Name \n";
                if (ctrl == "")
                    ctrl = "<%=txtOrgName.ClientID%>";
                flag = false;
            }
            if (!CheckControl("<%=ddlType.ClientID%>")) {
                msg += " * Select Organization Type \n";
                if (ctrl == "")
                    ctrl = "<%=ddlType.ClientID%>";
                flag = false;
            }
            if (!CheckControl("<%=txtAddress.ClientID%>")) {
                msg += " * Enter Address \n";
                if (ctrl == "")
                    ctrl = "<%=txtAddress.ClientID%>";
                flag = false;
            }
            if (!CheckControl("<%=ddlState.ClientID%>")) {
                msg += " * Select State \n";
                if (ctrl == "")
                    ctrl = "<%=ddlState.ClientID%>";
                flag = false;
            }
            if (!CheckControl("<%=ddlCity.ClientID%>")) {
                msg += " * Select City \n";
                if (ctrl == "")
                    ctrl = "<%=ddlCity.ClientID%>";
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
            <h2>Organisation Main
            </h2>
        </div>
        <div>
            <table>
                <tr>
                    <th>Organization <span class="required">*</span></th>
                    <th style="width: 170px">Organization Type <span class="required">*</span></th>

                    
                </tr>
                <tr>
                    <td valign="top">
                        <asp:TextBox ID="txtOrgName" runat="server" Width="300px " TextMode="MultiLine"></asp:TextBox>
                    </td>
                    <td valign="top" style="width: 170px">
                        <asp:DropDownList ID="ddlType" runat="server" Width="170px"></asp:DropDownList>
                    </td>



                </tr>
            </table>
            <table>
                <tr>
                    <th>Address<span class="required">*</span></th>
                    <th>State<span class="required">*</span></th>
                    <th>City<span class="required">*</span></th>

                </tr>
                <tr>
                    <td valign="top">
                        <asp:TextBox ID="txtAddress" runat="server" TextMode="MultiLine" Rows="5"></asp:TextBox>
                    </td>
                    <td valign="top">
                        <asp:DropDownList ID="ddlState" runat="server" Width="91px" AutoPostBack="True" OnSelectedIndexChanged="ddlState_SelectedIndexChanged">
                        </asp:DropDownList></td>
                    <td valign="top">
                        <asp:DropDownList ID="ddlCity" runat="server" Width="91px">
                        </asp:DropDownList></td>
                    <td valign="top">
                        <asp:Button ID="btnOrgSave" runat="server" Text="Save" OnClick="btnOrgSave_Click"
                            Width="73px" />
                    </td>

                </tr>
            </table>
            <table>
                <tr>
                    <td>
                        <div style="overflow: auto; max-height: 430px">
                            <asp:GridView ID="gvOrg" runat="server" DataKeyNames="ORG_ID" AutoGenerateColumns="false" OnRowCommand="gvOrg_RowCommand" CssClass="gridDynamic">
                                <Columns>
                                    <asp:TemplateField HeaderText="S.No.">
                                        <ItemTemplate>
                                            <%# ((GridViewRow)Container).RowIndex + 1%>
                                        </ItemTemplate>
                                        <ItemStyle Width="15px" />
                                    </asp:TemplateField>
                                    <asp:BoundField HeaderText="Org. Name" DataField="ORG_NAME" />
                                    <asp:BoundField HeaderText="Org. Type" DataField="OFF_TYPE_VALUE" ItemStyle-Width="50px" />
                                    <asp:BoundField HeaderText="Address" DataField="ORG_ADD" />
                                    <asp:BoundField HeaderText="City" DataField="CIT_VALUE" />
                                    <asp:BoundField HeaderText="State" DataField="STA_VALUE" />
                                    <asp:CommandField ButtonType="Image" SelectImageUrl="~/Siteimages/edit.gif" ShowSelectButton="True" HeaderText="Modify">
                                        <ItemStyle Width="40px" />
                                    </asp:CommandField>
                                    <asp:TemplateField ShowHeader="False" HeaderText="Status">
                                        <ItemStyle Width="20px" HorizontalAlign="Right" />
                                        <ItemTemplate>
                                            <asp:ImageButton ID="imgAct" runat="server" CausesValidation="false" CommandArgument='<%# Bind("ORG_ID") %>'
                                                ImageUrl='<%# Bind("STS_IMG") %>' CommandName='<%# Bind("STS_CMD") %>' ToolTip='<%# Bind("STS_TOOLTIP")%>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                </Columns>
                            </asp:GridView>
                        </div>
                    </td>
                </tr>
            </table>

        </div>
    </div>
</asp:Content>

