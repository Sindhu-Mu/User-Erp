<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/FullLength.master" AutoEventWireup="true" CodeFile="ShortlistApplicant.aspx.cs" Inherits="HR_ShortlistApplicant" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script lang="javascript" type="text/javascript">

        function SelectAllCheckboxes(spanChk) {


            var oItem = spanChk.children;
            var theBox = (spanChk.type == "checkbox") ?
                spanChk : spanChk.children.item[0];
            xState = theBox.checked;
            elm = theBox.form.elements;

            for (i = 0; i < elm.length; i++)
                if (elm[i].type == "checkbox" &&
                         elm[i].id != theBox.id) {

                    if (elm[i].checked != xState)
                        elm[i].click();
                }
        }
    </script>
    <div class="container">
        <div class="heading">
            <h2>Shortlist Applicants</h2>
        </div>
        <div>
            <table>
                <tr>
                    <td>
                        <table>
                            <tr>
                                <th>Job No.
                                </th>
                                <td>
                                    <asp:DropDownList ID="ddlJob" runat="server" OnSelectedIndexChanged="ddlJob_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                                </td>

                            </tr>
                        </table>
                    </td>

                </tr>
                <tr id="trDetails" runat="server" visible="false">
                    <td>
                        <table>
                            <tr>
                                <td>
                                    <table style="text-align:center">
                                        <tr>
                                            <td>
                                                <div style="max-height: 200px; overflow: auto">
                                                    <asp:GridView ID="gvDetail" runat="server" AutoGenerateColumns="false" CssClass="gridDynamic" Caption="Job Details" DataKeyNames="JOB_ID">
                                                        <Columns>
                                                            <asp:TemplateField HeaderText="S#">
                                                                <ItemTemplate>
                                                                    <%# ((GridViewRow )Container).RowIndex+1 %>.
                                                                </ItemTemplate>
                                                                <ItemStyle Width="15px" />
                                                            </asp:TemplateField>
                                                            <asp:BoundField DataField="DES_VALUE" HeaderText="Designation" />
                                                            <asp:BoundField DataField="DEPT_VALUE" HeaderText="Department" />
                                                            <asp:BoundField DataField="ACA_BASE_FULL_NAME" HeaderText="Min.Qualification" />
                                                            <asp:BoundField DataField="VACANCY" HeaderText="Vacancies" />
                                                            <asp:BoundField DataField="SELECTED" HeaderText="Selected" />
                                                            <asp:BoundField DataField="SALARY" HeaderText="Salary-Range" />
                                                        </Columns>
                                                    </asp:GridView>
                                                </div>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>

                            <tr>
                                <td>
                                    <asp:GridView ID="gvApplicant" runat="server" AutoGenerateColumns="false" CssClass="gridDynamic" DataKeyNames="INT_CAN_ID,MAP_ID,ACA_BASE_PRP" OnRowCommand="gvApplicant_RowCommand" EmptyDataText="No Record Found" Caption="Applicant Details">
                                        <Columns>
                                            <asp:TemplateField HeaderText="S.No.">
                                                <ItemTemplate><%#((GridViewRow)Container).RowIndex+1 %>.</ItemTemplate>
                                                <ItemStyle Width="15px" />
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="NAME" HeaderText="Name" />
                                            <asp:BoundField DataField="ACA_CRS_VALUE" HeaderText="Top Qualification" ItemStyle-Width="50px" />
                                            <asp:BoundField DataField="SPEC" HeaderText="Spec." ItemStyle-Width="30px" />
                                            <asp:BoundField DataField="YER" HeaderText="Year" ItemStyle-Width="20px" />
                                            <asp:BoundField DataField="CURRENT_CTC" HeaderText="Current CTC" />
                                            <asp:BoundField DataField="EXPECTED_CTC" HeaderText="Expected CTC" />
                                            <asp:BoundField DataField="EXP_DESIG" HeaderText="Cur.Designation" />
                                            <asp:BoundField DataField="ORG_NAME" HeaderText="Organistion" />
                                            <asp:CommandField ButtonType="Button" SelectText="Experience Detail" ShowSelectButton="True" ItemStyle-Width="80px" />
                                            <asp:TemplateField HeaderText="All">
                                                <HeaderTemplate>
                                                    <input id="chkAll" onclick="javascript: SelectAllCheckboxes(this);" type="checkbox"
                                                        value="on" runat="server" style="border-right: blue 2px groove; border-top: blue 2px groove; border-left: blue 2px groove; border-bottom: blue 2px groove" />
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:CheckBox ID="CHK_SelectAll" runat="server" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Button ID="btnSelect" runat="server" Text="Select Applicants From Old Entries" Width="220px" OnClick="btnSelect_Click" />
                                </td>
                            </tr>
                            <tr id="trOldApplicants" runat="server" visible="false">
                                <td>
                                    <asp:GridView ID="gvOldApplicants" runat="server" AutoGenerateColumns="false" CssClass="gridDynamic" DataKeyNames="INT_CAN_ID,MAP_ID,ACA_BASE_PRP"  EmptyDataText="No Record Found" Caption="Applicant Details" OnRowCommand="gvOldApplicants_RowCommand">
                                        <Columns>
                                            <asp:TemplateField HeaderText="S.No.">
                                                <ItemTemplate><%#((GridViewRow)Container).RowIndex+1 %>.</ItemTemplate>
                                                <ItemStyle Width="15px" />
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="NAME" HeaderText="Name" />
                                            <asp:BoundField DataField="ACA_CRS_VALUE" HeaderText="Top Qualification" ItemStyle-Width="50px" />
                                            <asp:BoundField DataField="SPEC" HeaderText="Spec." ItemStyle-Width="30px" />
                                            <asp:BoundField DataField="YER" HeaderText="Year" ItemStyle-Width="20px" />
                                            <asp:BoundField DataField="CURRENT_CTC" HeaderText="Current CTC" />
                                            <asp:BoundField DataField="EXPECTED_CTC" HeaderText="Expected CTC" />
                                            <asp:BoundField DataField="EXP_DESIG" HeaderText="Cur.Designation" />
                                            <asp:BoundField DataField="ORG_NAME" HeaderText="Organistion" />
                                            <asp:CommandField ButtonType="Button" SelectText="Experience Detail" ShowSelectButton="True" ItemStyle-Width="80px" />
                                            <asp:TemplateField HeaderText="All">
                                                <HeaderTemplate>
                                                    <input id="chkAll" onclick="javascript: SelectAllCheckboxes(this);" type="checkbox"
                                                        value="on" runat="server" style="border-right: blue 2px groove; border-top: blue 2px groove; border-left: blue 2px groove; border-bottom: blue 2px groove" />
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:CheckBox ID="CHK_SelectAll" runat="server" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align: right">
                                    <asp:TextBox ID="TextBox1" runat="server" Visible="false"></asp:TextBox>
                                    <asp:TextBox ID="txtRemark" runat="server"></asp:TextBox>
                                    <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" />
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td id="tdss" runat="server">&nbsp;
                       <ajaxToolkit:ModalPopupExtender ID="ModalPopupExtender1" runat="server" DropShadow="false" PopupControlID="Panel1" TargetControlID="tdss">
                       </ajaxToolkit:ModalPopupExtender>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Panel Style="display: none; width: 50%" ID="Panel1" runat="server">
                            <asp:Panel Style="border-right: gray 1px solid; border-top: gray 1px solid; border-left: gray 1px solid; cursor: move; color: black; border-bottom: gray 1px solid; background-color: #dddddd"
                                ID="Panel3" runat="server">
                                <table style="width: 100%">
                                    <tr>
                                        <td style="font-size: 14px; font-weight: bold">Experience Detail
                                        </td>
                                        <td style="text-align: right">
                                            <asp:ImageButton ID="CancelButton" runat="server" ImageUrl="~/Siteimages/cancel_icon.gif" /></td>
                                    </tr>
                                </table>
                            </asp:Panel>
                            <asp:GridView ID="gvExperience" runat="server" ShowFooter="True" Width="100%" AutoGenerateColumns="False"
                                EmptyDataText="No Experience" CssClass="gridDynamic">
                                <Columns>
                                    <asp:TemplateField HeaderText="S#">
                                        <ItemTemplate>
                                            <%# ((GridViewRow)Container).RowIndex + 1%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="EXP_DESIG" HeaderText="Designation" />
                                    <asp:BoundField DataField="EXP_TYPE_VALUE" HeaderText="Exp.Type" />
                                    <asp:BoundField DataField="ORG_NAME" HeaderText="Organistion" />
                                    <asp:BoundField DataField="FRM_DATE" HeaderText="From Date" DataFormatString="{0:dd/MM/yyyy}" />
                                    <asp:BoundField DataField="TO_DATE" HeaderText="To Date" DataFormatString="{0:dd/MM/yyyy}" />
                                </Columns>
                            </asp:GridView>
                        </asp:Panel>

                    </td>
                </tr>

            </table>
        </div>
    </div>
</asp:Content>

