<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/FullLength.master" AutoEventWireup="true" CodeFile="InterviewCall.aspx.cs" Inherits="HR_InterviewCall" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="container">
        <div class="heading">
            <h2>Interview Call</h2>
        </div>
        <div>
            <table>
                <tr>
                    <td>
                        <table>
                            <tr>
                                <th>Job Details
                                </th>
                            </tr>
                            <tr>
                                <td>
                                    <div>
                                        <asp:GridView ID="gvJob" runat="server" AutoGenerateColumns="false" CssClass="gridDynamic" OnRowCommand="gvJob_RowCommand" DataKeyNames="JOB_ID">
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
                                                <asp:CommandField ButtonType="Button" SelectText="Applicants" ShowSelectButton="True" ItemStyle-Width="80px" />
                                            </Columns>
                                        </asp:GridView>
                                    </div>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr id="trApplicant" runat="server" visible="false">
                    <td>
                        <table>
                            <tr>
                                <th>Applicant Details
                                </th>
                            </tr>
                            <tr>
                                <td>
                                    <div>
                                        <asp:GridView ID="gvApplicant" runat="server" AutoGenerateColumns="false" CssClass="gridDynamic" OnRowCommand="gvApplicant_RowCommand" DataKeyNames="INT_CAN_ID">
                                            <Columns>
                                                <asp:TemplateField HeaderText="S#">
                                                    <ItemTemplate>
                                                        <%# ((GridViewRow )Container).RowIndex+1 %>.
                                                    </ItemTemplate>
                                                    <ItemStyle Width="15px" />
                                                </asp:TemplateField>
                                                <asp:BoundField HeaderText="Name" DataField="NAME" />
                                                <asp:BoundField HeaderText="Contact No." DataField="CONTACT_NO" />
                                                <asp:BoundField HeaderText="Mail" DataField="MAIL_ID" />
                                                <asp:BoundField HeaderText="Status" DataField="INT_STS_VALUE" />
                                                <asp:CommandField ButtonType="Button" SelectText="Details" ShowSelectButton="True" ItemStyle-Width="80px" />
                                            </Columns>
                                        </asp:GridView>
                                    </div>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr id="trDetails" runat="server" visible="false">
                    <td>
                        <table>
                            <tr>
                                <th>Basic Details
                                </th>
                            </tr>
                            <tr>
                                <td>
                                    <div>
                                        <asp:GridView ID="gvBasic" runat="server" AutoGenerateColumns="false" CssClass="gridDynamic" DataKeyNames="INT_CAN_ID">
                                            <Columns>
                                                <asp:BoundField DataField="NAME" HeaderText="Name" />
                                                <asp:BoundField DataField="CONTACT_NO" HeaderText="Contact No." />
                                                <asp:BoundField DataField="MAIL" HeaderText="Mail" />
                                                <asp:BoundField DataField="MAIL_DOM_VALUE" HeaderText="Mail Domain" />
                                                <asp:BoundField DataField="LOCATION" HeaderText="Location" />
                                                <asp:BoundField DataField="ADMIN_WORK" HeaderText="Admin.Work" />
                                                <asp:BoundField DataField="CURRENT_CTC" HeaderText="Current CTC" />
                                                <asp:BoundField DataField="EXPECTED_CTC" HeaderText="Expected CTC" />
                                                <asp:BoundField DataField="JOINING_DAYS" HeaderText="Notice Period(Days)" />
                                                <asp:BoundField DataField="REMARK" HeaderText="Remark" />
                                                <asp:CommandField ShowEditButton="True" ButtonType="Button" HeaderText="Update">
                                                    <ControlStyle CssClass="btnblue" />
                                                </asp:CommandField>
                                            </Columns>
                                        </asp:GridView>
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <th>Academic Details
                                </th>
                            </tr>
                            <tr>
                                <td>
                                    <div>
                                        <asp:GridView ID="gvAcademic" runat="server" AutoGenerateColumns="false" CssClass="gridDynamic" DataKeyNames="INT_CAN_ACA_ID">
                                            <Columns>
                                                <asp:TemplateField HeaderText="Academic">
                                                    <EditItemTemplate>
                                                        <asp:DropDownList ID="ddlAca" runat="server"></asp:DropDownList>
                                                    </EditItemTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblAca" runat="server" Text='<%#Eval("ACA_BASE_SHORT_NAME") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Qualification">
                                                    <EditItemTemplate>
                                                        <asp:DropDownList ID="ddlQual" runat="server"></asp:DropDownList>
                                                    </EditItemTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblQual" runat="server" Text='<%#Eval("ACA_CRS_VALUE") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Board">
                                                    <EditItemTemplate>
                                                        <asp:DropDownList ID="ddlBoard" runat="server"></asp:DropDownList>
                                                    </EditItemTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblBoard" runat="server" Text='<%#Eval("ACA_BRD_SHORT_NAME") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="School">
                                                    <EditItemTemplate>
                                                        <asp:TextBox ID="txtSchool" runat="server" Text='<%#Eval("SCH") %>'></asp:TextBox>
                                                    </EditItemTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblSchool" runat="server" Text='<%#Eval("SCH") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Specialisation">
                                                    <EditItemTemplate>
                                                        <asp:TextBox ID="txtSpec" runat="server" Text='<%#Eval("SPEC") %>'></asp:TextBox>
                                                    </EditItemTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblSpec" runat="server" Text='<%#Eval("SPEC") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Year">
                                                    <EditItemTemplate>
                                                        <asp:TextBox ID="txtYear" runat="server" Text='<%#Eval("YER") %>'></asp:TextBox>
                                                    </EditItemTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblYear" runat="server" Text='<%#Eval("YER") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="%age">
                                                    <EditItemTemplate>
                                                        <asp:TextBox ID="txtPrsnt" runat="server" Text='<%#Eval("PRSNT") %>'></asp:TextBox>
                                                    </EditItemTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblPrsnt" runat="server" Text='<%#Eval("PRSNT") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:CommandField ShowEditButton="True" ButtonType="Button" HeaderText="Update">
                                                    <ControlStyle CssClass="btnblue" />
                                                </asp:CommandField>
                                            </Columns>
                                        </asp:GridView>
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <th>Experience Details
                                </th>
                            </tr>
                            <tr>
                                <td>
                                    <div>
                                        <asp:GridView ID="gvExperience" runat="server" AutoGenerateColumns="false" CssClass="gridDynamic">
                                            <Columns>

                                                <asp:TemplateField HeaderText="Marks">
                                                    <EditItemTemplate>
                                                        <asp:TextBox ID="txtMarks" runat="server" Text='<%#Eval("MARKS") %>'></asp:TextBox>
                                                    </EditItemTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblMarks" runat="server" Text='<%#Eval("MARKS") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:CommandField ShowEditButton="True" ButtonType="Button" HeaderText="Update">
                                                    <ControlStyle CssClass="btnblue" />
                                                </asp:CommandField>
                                            </Columns>
                                        </asp:GridView>
                                    </div>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </div>
    </div>
</asp:Content>

