<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/FullLength.master" AutoEventWireup="true" CodeFile="AcademicCalender.aspx.cs" Inherits="Academic_AcademicCalender" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div>
        <div class="heading">
            <h2>Academic Calender</h2>
        </div>
        <table>
            <tr>
                <td>
                    <ajaxToolkit:TabContainer ID="TabContainer1" runat="server" AutoPostBack="true" ActiveTabIndex="1">
                        <ajaxToolkit:TabPanel ID="TabPanel1" runat="server" HeaderText="Add Event">
                            <ContentTemplate>
                                <table>
                                    <tr>
                                        <th>Event Name</th>
                                        <td><asp:TextBox ID="txtEvnt" runat="server"></asp:TextBox></td>
                                        </tr>
                                    <tr>
                                        <th>Event Description</th>
                                        <td><asp:TextBox ID="txtEvntDesc" runat="server" TextMode="MultiLine"></asp:TextBox></td>
                                        <td><asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click"/></td>
                                    </tr>
                                    </table>
                                <table>
                                    <tr>
                                        <td><asp:GridView ID="gvEvent" runat="server" AutoGenerateColumns="False" CssClass="gridDynamic" DataKeyNames="ACA_EVENT_ID" OnRowCommand="gvEvent_RowCommand">
                                            <Columns>
                                                <asp:TemplateField HeaderText="S.No">
                                                   <ItemTemplate>
                                                       <%# ((GridViewRow)Container).RowIndex + 1%>
                                                   </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:BoundField HeaderText="Event Name" DataField="ACA_EVENT_VALUE" />
                                                <asp:BoundField HeaderText="Description" DataField="ACA_EVENT_DESC" />
                                                <asp:CommandField ButtonType="Image" SelectImageUrl="~/Siteimages/edit.gif" ShowSelectButton="True" HeaderText="Modify">
                                                        <ItemStyle Width="40px" />
                                                        </asp:CommandField>
                                                        <asp:TemplateField ShowHeader="False" HeaderText="Status">
                                                         <ItemStyle Width="20px" HorizontalAlign="Right" />
                                                         <ItemTemplate>
                                                         <asp:ImageButton ID="ImageButton1" runat="server" CausesValidation="false" CommandArgument='<%# Bind("ACA_EVENT_ID") %>'
                                                         ImageUrl='<%# Bind("STATUS_IMG") %>' CommandName='<%# Bind("STATUS_CMD") %>' ToolTip='<%# Bind("STATUS_TOOLTIP")%>' />
                                                  </ItemTemplate>
                                            </asp:TemplateField>
                                            </Columns>
                                            </asp:GridView></td>
                                    </tr>
                                </table>
                            </ContentTemplate>
                        </ajaxToolkit:TabPanel>
                        <ajaxToolkit:TabPanel ID="TabPanel2" runat="server" HeaderText="Event Schedule">
                            <ContentTemplate>
                                <table>
                                    <tr>
                                        <th>Event</th>
                                        <td><asp:DropDownList ID="ddlEvent" runat="server" AutoPostBack="True"></asp:DropDownList></td>
                                        <th>Start Date</th>
                                        <td><asp:TextBox ID="txtStartDt" runat="server"></asp:TextBox></td>
                                        <th>End Date</th>
                                        <td><asp:TextBox ID="txtEndDt" runat="server"></asp:TextBox></td>
                                   </tr>
                                    <tr>
                                        <th>Event For</th>
                                        <td><asp:DropDownList ID="ddlEventFor" runat="server" AutoPostBack="True">
                                            <asp:ListItem Value="0" Text="Select"></asp:ListItem>
                                             <asp:ListItem Value="1" Text="All"></asp:ListItem>
                                            <asp:ListItem Value="2" Text="ERP"></asp:ListItem>
                                            <asp:ListItem Value="3" Text="Student Portal"></asp:ListItem>
                                            </asp:DropDownList></td>
                                    </tr>
                                    <tr>
                                        <td>
                    <ajaxToolkit:CalendarExtender ID="CalendarExtender1" Format="dd/MM/yyyy" runat="server" TargetControlID="txtStartDt" Enabled="True"></ajaxToolkit:CalendarExtender>
                            <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender1" runat="server" TargetControlID="txtStartDt" Mask="99/99/9999"
                                MaskType="Date" CultureAMPMPlaceholder="" CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder="" CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder="" Enabled="True">
                            </ajaxToolkit:MaskedEditExtender>
                </td>
                                        <td>
<ajaxToolkit:CalendarExtender ID="CalendarExtender2" Format="dd/MM/yyyy" runat="server" TargetControlID="txtEndDt" Enabled="True"></ajaxToolkit:CalendarExtender>
                            <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender2" runat="server" TargetControlID="txtEndDt" Mask="99/99/9999"
                                MaskType="Date" CultureAMPMPlaceholder="" CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder="" CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder="" Enabled="True">
                            </ajaxToolkit:MaskedEditExtender>
                                        </td>
                                    </tr>
                                    </table>
                                <table>
                                       <tr>
                                        <td>
                                            <asp:FileUpload ID="FileUplod" runat="server" />
                                        </td>
                                        <td><asp:Button ID="btnSaveEvnt" runat="server" Text="Save" OnClick="btnSaveEvnt_Click" /></td>
                                    </tr>
                                </table>
                                <table>
                                    <tr>
                                        <td>
                                            <asp:GridView ID="GvEvntSch" runat="server" AutoGenerateColumns="False" CssClass="gridDynamic" DataKeyNames="EVENT_SCH_ID" OnRowCommand="GvEvntSch_RowCommand">
                                                <Columns>
                                                    <asp:TemplateField HeaderText="S.No">
                                                        <ItemTemplate>
                                                            <%#((GridViewRow)Container).RowIndex +1 %>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:BoundField HeaderText="Event Name" DataField="ACA_EVENT_VALUE"/>
                                                    <asp:BoundField HeaderText="Event Schedule" DataField="SCHEDULE_DT"/>
                                                    <asp:BoundField HeaderText="Event For" DataField="USE_FOR"/>
                                                    <asp:BoundField HeaderText="Document" DataField="UPLOADED_FILE"/>
                                                    <asp:BoundField HeaderText="Uploaded BY" DataField="EMP_NAME"/>
                                                    <asp:CommandField ButtonType="Image" SelectImageUrl="~/Siteimages/edit.gif" ShowSelectButton="True" HeaderText="Modify">
                                                        <ItemStyle Width="40px" />
                                                        </asp:CommandField>
                                                        <asp:TemplateField ShowHeader="False" HeaderText="Status">
                                                         <ItemStyle Width="20px" HorizontalAlign="Right" />
                                                         <ItemTemplate>
                                                         <asp:ImageButton ID="ImageButton1" runat="server" CausesValidation="false" CommandArgument='<%# Bind("EVENT_SCH_ID") %>'
                                                         ImageUrl='<%# Bind("STS_IMG") %>' CommandName='<%# Bind("STS_CMD") %>' ToolTip='<%# Bind("STS_TOOLTIP")%>' />
                                                  </ItemTemplate>
                                            </asp:TemplateField>
                                                </Columns>
                                            </asp:GridView>
                                        </td>
                                    </tr>
                                </table>
                            </ContentTemplate>
                        </ajaxToolkit:TabPanel>
                    </ajaxToolkit:TabContainer>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>

